using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BG3Cam
{
    public unsafe class Memory
    {
        public static readonly nint kernel = NativeLibrary.Load("kernel32.dll");
        public static readonly delegate* unmanaged[Stdcall]<int, int, int, nint> OpenProcess = (delegate* unmanaged[Stdcall]<int, int, int, nint>)NativeLibrary.GetExport(kernel, nameof(OpenProcess));
        public static readonly delegate* unmanaged[Stdcall]<nint, nint, byte[], int, out int, int> ReadProcessMemory2 = (delegate* unmanaged[Stdcall]<nint, nint, byte[], int, out int, int>)NativeLibrary.GetExport(kernel, nameof(ReadProcessMemory));
        [DllImport("kernel32")] static extern Boolean WriteProcessMemory(nint hProcess, nint lpBaseAddress, Byte[] buffer, Int32 nSize, out Int32 lpNumberOfBytesWritten);
        [DllImport("kernel32")] private static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, [Out()] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
        byte[] cache;
        Process proc;
        private nint processHandle;
        public Memory(Process proc)
        {
            this.proc = proc;
            var size = proc.MainModule.ModuleMemorySize;
            cache = new byte[size];
            ReadProcessMemory(proc.Handle, proc.MainModule.BaseAddress, cache, size, out _);
            processHandle = proc.Handle;
        }
        public nint GetProcessHandle()
        {
            return processHandle;
        }
        public T ReadProcessMemory<T>(nint addr)
        {
            var buffer = new byte[Marshal.SizeOf<T>()];
            ReadProcessMemory2(proc.Handle, addr, buffer, Marshal.SizeOf<T>(), out _);
            var structPtr = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var obj = Marshal.PtrToStructure<T>(structPtr.AddrOfPinnedObject());
            structPtr.Free();
            return obj;
        }
        public byte[] ReadProcessMemory(nint addr, int nBytes)
        {
            var buffer = new byte[nBytes];
            ReadProcessMemory2(proc.Handle, addr, buffer, nBytes, out _);
            return buffer;
        }
        public void WriteProcessMemory<T>(nint addr, T value)
        {
            var objSize = Marshal.SizeOf(value);
            var objBytes = new Byte[objSize];
            var objPtr = Marshal.AllocHGlobal(objSize);
            Marshal.StructureToPtr(value, objPtr, true);
            Marshal.Copy(objPtr, objBytes, 0, objSize);
            Marshal.FreeHGlobal(objPtr);
            WriteProcessMemory(proc.Handle, addr, objBytes, objBytes.Length, out _);
        }
        public void WriteProcessMemory(IntPtr addr, byte[] buffer)
        {
            int bytesWritten;
            if (!WriteProcessMemory(processHandle, addr, buffer, buffer.Length, out bytesWritten))
            {
                // Handle the error here if needed
                Debug.WriteLine("Error writing to process memory.");
            }
        }
        static bool MaskCheck(int nOffset, byte[] btPattern, string strMask, byte[] bytes)
        {
            //return btPattern.Select((b,i)=>(b,i)).All(b => strMask[b.b] == '?' || b.b == cache[nOffset + b.i]);
            for (var x = 0; x < btPattern.Length; x++)
            {
                if (strMask[x] == '?') continue;
                if ((strMask[x] == 'x') && (btPattern[x] != bytes[nOffset + x])) return false;
            }
            return true;
        }
        public static nint FindPattern(byte[] btPattern, string strMask, nint addr, int size, byte[] bytes)
        {
            for (var x = 0; x < size - strMask.Length; x++)
                if (MaskCheck(x, btPattern, strMask, bytes)) return addr + x;
            return 0;
        }
        public static List<nint> FindPatterns(byte[] btPattern, string strMask, nint addr, int size, byte[] bytes)
        {
            var ptrs = new List<nint>();
            for (var x = 0; x < size - strMask.Length; x++)
                if (MaskCheck(x, btPattern, strMask, bytes)) ptrs.Add(addr + x);
            return ptrs;
        }
        public nint FindPattern(string pattern, nint addr = 0, int size = 0, byte[] bytes = null)
        {
            if (bytes == null)
            {
                bytes = cache;
                if (addr == 0) addr = proc.MainModule.BaseAddress;
            }
            if (size == 0) size = bytes.Length;

            var arrayOfBytes = pattern.Split(' ').Select(b => b.Contains("?") ? (byte)0 : (byte)Convert.ToInt32(b, 16)).ToArray();
            var strMask = String.Join("", pattern.Split(' ').Select(b => b.Contains("?") ? '?' : 'x'));
            return FindPattern(arrayOfBytes, strMask, addr, size, bytes);
        }
        public List<nint> FindPatterns(string pattern, nint addr = 0, int size = 0, byte[] bytes = null)
        {
            if (bytes == null)
            {
                bytes = cache;
                if (addr == 0) addr = proc.MainModule.BaseAddress;
            }
            if (size == 0) size = bytes.Length;
            var arrayOfBytes = pattern.Split(' ').Select(b => b.Contains("?") ? (byte)0 : (byte)Convert.ToInt32(b, 16)).ToArray();
            var strMask = String.Join("", pattern.Split(' ').Select(b => b.Contains("?") ? '?' : 'x'));
            return FindPatterns(arrayOfBytes, strMask, addr, size, bytes);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenAI.TestFramework.Utils.Processes;

/// <summary>
/// A job provides a way to link several processes together on Windows. In this way, they can all be
/// terminated by calling the <see cref="Close"/> method. The OS will also automatically terminate
/// the linked processes if the owner process terminates.
/// </summary>
public class WindowsJob : IDisposable
{
    private IntPtr _jobHandle;
    private int _disposed;

    /// <summary>
    /// Creates a new job
    /// </summary>
    /// <param name="name">(Optional) The name to associate</param>
    public WindowsJob(string? name = null)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            throw new NotSupportedException("This is only supported on Windows platforms");
        }

        var securityAttributes = new SECURITY_ATTRIBUTES()
        {
            nLength = (uint)Marshal.SizeOf(typeof(SECURITY_ATTRIBUTES)),
            lpSecurityDescriptor = IntPtr.Zero,
            bInheritHandle = false
        };

        // Create the job handle
        _jobHandle = CreateJobObject(ref securityAttributes, name);
        if (_jobHandle == IntPtr.Zero)
        {
            throw new COMException("Failed to create job", Marshal.GetLastWin32Error());
        }

        // Set the job state so that all associated handles are closed
        var extendedInfo = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION()
        {
            BasicLimitInformation = new JOBOBJECT_BASIC_LIMIT_INFORMATION()
            {
                LimitFlags = JobObjectLimits.LIMIT_KILL_ON_JOB_CLOSE
            }
        };

        int length = Marshal.SizeOf(typeof(JOBOBJECT_EXTENDED_LIMIT_INFORMATION));
        IntPtr ptr = IntPtr.Zero;
        try
        {
            ptr = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(extendedInfo, ptr, false);

            bool success = SetInformationJobObject(
                _jobHandle,
                JOBOBJECTINFOCLASS.JobObjectExtendedLimitInformation,
                ptr,
                (uint)length);

            if (!success)
            {
                throw new COMException("Failed to set the job extended information", Marshal.GetLastWin32Error());
            }
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }

    /// <summary>
    /// Adds a process to the job
    /// </summary>
    /// <param name="process">The process to add</param>
    public void Add(Process process)
    {
        if (process == null)
        {
            throw new ArgumentNullException(nameof(process));
        }
        else if (process.Handle == IntPtr.Zero)
        {
            throw new ArgumentException("The specified process has a NULL handle");
        }

        bool success = AssignProcessToJobObject(_jobHandle, process.Handle);
        if (!success)
        {
            throw new COMException("Failed to add the process to the job", Marshal.GetLastWin32Error());
        }
    }

    /// <summary>
    /// Closes the job. This will close all linked processes
    /// </summary>
    public void Close()
    {
        CloseHandle(_jobHandle);
        _jobHandle = IntPtr.Zero;
    }

    /// <summary>
    /// Disposes of the job. This will also close all linked process.
    /// </summary>
    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            Close();
        }
    }

    #region native methods

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern IntPtr CreateJobObject([In] ref SECURITY_ATTRIBUTES lpJobAttributes, string? lpName);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern IntPtr OpenJobObject(uint dwDesiredAccess, bool bInheritHandles, string lpName);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SetInformationJobObject(
        [In] IntPtr hJob,
        JOBOBJECTINFOCLASS JobObjectInfoClass,
        [In] IntPtr lpJobObjectInfo,
        uint cbJobObjectInfoLength);

    [DllImport("kernel32.dll", SetLastError = true)]
#if NETFRAMEWORK
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
    [SuppressUnmanagedCodeSecurity]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CloseHandle(IntPtr hObject);

#endregion

    #region native types

    [StructLayout(LayoutKind.Sequential)]
    internal struct SECURITY_ATTRIBUTES
    {
        public uint nLength;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct JOBOBJECT_BASIC_LIMIT_INFORMATION
    {
        public Int64 PerProcessUserTimeLimit;
        public Int64 PerJobUserTimeLimit;
        public JobObjectLimits LimitFlags;
        public UIntPtr MinimumWorkingSetSize;
        public UIntPtr MaximumWorkingSetSize;
        public UInt32 ActiveProcessLimit;
        public UIntPtr Affinity;
        public UInt32 PriorityClass;
        public UInt32 SchedulingClass;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
    {
        public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
        public IO_COUNTERS IoInfo;
        public UIntPtr ProcessMemoryLimit;
        public UIntPtr JobMemoryLimit;
        public UIntPtr PeakProcessMemoryUsed;
        public UIntPtr PeakJobMemoryUsed;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IO_COUNTERS
    {
        public UInt64 ReadOperationCount;
        public UInt64 WriteOperationCount;
        public UInt64 OtherOperationCount;
        public UInt64 ReadTransferCount;
        public UInt64 WriteTransferCount;
        public UInt64 OtherTransferCount;
    }

    internal enum JOBOBJECTINFOCLASS
    {
        JobObjectExtendedLimitInformation = 9,
    }

    internal enum JobObjectLimits : UInt32
    {
        LIMIT_KILL_ON_JOB_CLOSE = 0x00002000,
    }
}

#endregion

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;

namespace Azure.Identity
{
    internal interface IProcess : IDisposable
    {
        bool HasExited { get; }
        int ExitCode { get; }
        ProcessStartInfo StartInfo { get; set; }

        event EventHandler Exited;
        event DataReceivedEventHandler OutputDataReceived;
        event DataReceivedEventHandler ErrorDataReceived;

        bool Start();
        void Kill();
        void BeginOutputReadLine();
        void BeginErrorReadLine();
        StreamWriter StandardInput { get; }
    }
}

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
        StreamReader StandardOutput { get; }
        StreamReader StandardError { get; }
        ProcessStartInfo StartInfo { get; set; }

        event EventHandler Exited;
        event DataReceivedEventWrapperHandler OutputDataReceived;
        event DataReceivedEventWrapperHandler ErrorDataReceived;

        void Start();
        void Kill();
    }
}

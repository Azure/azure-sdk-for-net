// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;

namespace Azure.Identity
{
    internal class ProcessService : IProcessService
    {
        public static IProcessService Default { get; } = new ProcessService();

        private ProcessService() { }

        public IProcess Create(ProcessStartInfo startInfo) => new ProcessWrapper(startInfo);

        private class ProcessWrapper : IProcess
        {
            private readonly Process _process;

            public ProcessWrapper(ProcessStartInfo processStartInfo)
            {
                _process = new Process
                {
                    StartInfo = processStartInfo,
                    EnableRaisingEvents = true
                };
            }

            public bool HasExited => _process.HasExited;
            public int ExitCode => _process.ExitCode;
            public StreamReader StandardOutput => _process.StandardOutput;
            public StreamReader StandardError => _process.StandardError;

            public ProcessStartInfo StartInfo
            {
                get => _process.StartInfo;
                set => _process.StartInfo = value;
            }

            public event EventHandler Exited
            {
                add => _process.Exited += value;
                remove => _process.Exited -= value;
            }

            public void Start() => _process.Start();
            public void Kill() => _process.Kill();
            public void Dispose() => _process.Dispose();
        }
    }
}

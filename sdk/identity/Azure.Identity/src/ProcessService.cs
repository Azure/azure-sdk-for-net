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

            public ProcessStartInfo StartInfo
            {
                get => _process.StartInfo;
                set => _process.StartInfo = value;
            }
            public StreamWriter StandardInput => _process.StandardInput;

            public event EventHandler Exited
            {
                add => _process.Exited += value;
                remove => _process.Exited -= value;
            }

            public event DataReceivedEventHandler OutputDataReceived
            {
                add => _process.OutputDataReceived += value;
                remove => _process.OutputDataReceived -= value;
            }

            public event DataReceivedEventHandler ErrorDataReceived
            {
                add => _process.ErrorDataReceived += value;
                remove => _process.ErrorDataReceived -= value;
            }

            public bool Start() => _process.Start();
            public void Kill() => _process.Kill();
            public void BeginOutputReadLine() => _process.BeginOutputReadLine();
            public void BeginErrorReadLine() => _process.BeginErrorReadLine();
            public void Dispose() => _process.Dispose();
        }
    }
}

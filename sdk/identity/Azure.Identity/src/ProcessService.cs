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

                _process.OutputDataReceived += HandleOutputDataReceived;
                _process.ErrorDataReceived += HandleErrorDataReceived;
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

            public event DataReceivedEventWrapperHandler OutputDataReceived;
            public event DataReceivedEventWrapperHandler ErrorDataReceived;

            private void HandleErrorDataReceived(object sender, DataReceivedEventArgs e) => ErrorDataReceived?.Invoke(this, new DataReceivedEventArgsWrapper(e));
            private void HandleOutputDataReceived(object sender, DataReceivedEventArgs e) => OutputDataReceived?.Invoke(this, new DataReceivedEventArgsWrapper(e));

            public void Start()
            {
                _process.Start();

                _process.BeginOutputReadLine();
                _process.BeginErrorReadLine();
            }

            public void Kill() => _process.Kill();
            public void Dispose() => _process.Dispose();
        }
    }
}

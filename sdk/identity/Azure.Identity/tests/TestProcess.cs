// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    internal sealed class TestProcess : IProcess
    {
        private bool _hasStarted;
        private bool _hasExited;
        private int _exitCode;
        private CancellationTokenSource _cts;
        private StreamReader _outputStreamReader;
        private StreamReader _errorStreamReader;
        private StreamWriter _outputStreamWriter;
        private StreamWriter _errorStreamWriter;
        private ProcessStartInfo _startInfo;

        public ProcessStartInfo StartInfo
        {
            get => _startInfo ??= new ProcessStartInfo();
            set => _startInfo = value;
        }

        public string Output { get; set; }
        public string Error { get; set; }
        public int? CodeOnExit { get; set; }
        public int Timeout { get; set; }
        public Exception ExceptionOnProcessKill { get; set; }

        public void Dispose()
        {
            _outputStreamReader?.Dispose();
            _errorStreamReader?.Dispose();
        }

        public bool HasExited
        {
            get
            {
                if (_hasStarted)
                {
                    return _hasExited;
                }

                throw new InvalidOperationException("No process is associated with this object");
            }
        }

        public int ExitCode
        {
            get
            {
                if (_hasExited)
                {
                    return _exitCode;
                }

                throw new InvalidOperationException();
            }
        }

        public StreamReader StandardOutput => _outputStreamReader;
        public StreamReader StandardError => _errorStreamReader;

        public event EventHandler Exited;
        public event EventHandler Started;

        public void Start()
        {
            _hasStarted = true;
            Started?.Invoke(this, EventArgs.Empty);

            Create(out _outputStreamReader, out _outputStreamWriter);
            Create(out _errorStreamReader, out _errorStreamWriter);

            if (Timeout > 0)
            {
                _cts = new CancellationTokenSource();
                Task.Delay(Timeout, _cts.Token).ContinueWith(FinishProcessRun);
            }
            else
            {
                Task.Run(FinishProcessRun);
            }
        }

        private void FinishProcessRun(Task delayTask)
        {
            if (!delayTask.IsCanceled)
            {
                FinishProcessRun();
            }
        }

        private void FinishProcessRun()
        {
            WriteToStream(Output, _outputStreamWriter);
            WriteToStream(Error, _errorStreamWriter);

            _hasExited = true;
            _exitCode = CodeOnExit ?? (Error != default ? 1 : 0);
            Exited?.Invoke(this, EventArgs.Empty);
        }

        private static void Create(out StreamReader reader, out StreamWriter writer)
        {
            var stream = new MemoryStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        private static void WriteToStream(string str, StreamWriter writer)
        {
            if (str == default)
            {
                return;
            }

            writer.Write(str);
            writer.Flush();
            writer.BaseStream.Seek(0, SeekOrigin.Begin);
        }

        public void Kill()
        {
            _cts?.Cancel();

            if (ExceptionOnProcessKill != default)
            {
                _hasExited = true;
                throw ExceptionOnProcessKill;
            }
        }
    }
}

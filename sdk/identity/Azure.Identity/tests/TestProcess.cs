// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests
{
    internal sealed class TestProcess : IProcess
    {
        private static readonly Lazy<Func<string, DataReceivedEventArgs>> s_createDataReceivedEventArgs = new Lazy<Func<string, DataReceivedEventArgs>>(
            () =>
            {
                ConstructorInfo constructor = typeof(DataReceivedEventArgs).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
                ParameterExpression dataParameter = Expression.Parameter(typeof(string), "data");
                NewExpression callConstructor = Expression.New(constructor, dataParameter);
                return Expression.Lambda<Func<string, DataReceivedEventArgs>>(callConstructor, dataParameter).Compile();
            });

        private bool _hasStarted;
        private bool _hasExited;
        private int _exitCode;
        private CancellationTokenSource _cts;
        private ProcessStartInfo _startInfo;

        public ProcessStartInfo StartInfo
        {
            get => _startInfo ??= new ProcessStartInfo();
            set => _startInfo = value;
        }

        public bool FailedToStart { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
        public int? CodeOnExit { get; set; }
        public int Timeout { get; set; }
        public Exception ExceptionOnProcessKill { get; set; }

        // An Action that will throw if the ProcessStartInfo conditions are met.
        public Action<TestProcess> ExceptionOnStartHandler { get; set; }

        public void Dispose() { }

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

        public StreamWriter StandardInput => throw new NotImplementedException();

        public event EventHandler Exited;
        public event EventHandler Started;
        public event DataReceivedEventHandler OutputDataReceived;
        public event DataReceivedEventHandler ErrorDataReceived;

        public bool Start()
        {
            if (ExceptionOnStartHandler != null)
            {
                ExceptionOnStartHandler(this);
            }

            if (FailedToStart)
            {
                return false;
            }

            _hasStarted = true;
            Started?.Invoke(this, EventArgs.Empty);

            if (Timeout > 0)
            {
                _cts = new CancellationTokenSource();
                Task.Delay(Timeout, _cts.Token).ContinueWith(FinishProcessRun);
            }
            else
            {
                Task.Run(FinishProcessRun);
            }

            return true;
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
            Notify(Output, OutputDataReceived);
            Notify(Error, ErrorDataReceived);

            _hasExited = true;
            _exitCode = CodeOnExit ?? (Error != default ? 1 : 0);
            Exited?.Invoke(this, EventArgs.Empty);
        }

        private void Notify(string data, DataReceivedEventHandler handler)
        {
            if (handler == default)
            {
                return;
            }

            Task.Run(
                () =>
                {
                    if (data != default)
                    {
                        handler(this, CreateDataReceivedEventArgs(data));
                    }
                    handler(this, CreateDataReceivedEventArgs(null));
                });
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

        public void BeginOutputReadLine() { }
        public void BeginErrorReadLine() { }

        private static DataReceivedEventArgs CreateDataReceivedEventArgs(string data) => s_createDataReceivedEventArgs.Value(data);
    }
}

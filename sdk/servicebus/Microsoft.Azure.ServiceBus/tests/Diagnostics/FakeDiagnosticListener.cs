// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public sealed class FakeDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        private  IDisposable _subscription;
        private class FakeDiagnosticSourceWriteObserver : IObserver<KeyValuePair<string, object>>
        {
            private readonly Action<KeyValuePair<string, object>> _writeCallback;

            public FakeDiagnosticSourceWriteObserver(Action<KeyValuePair<string, object>> writeCallback)
            {
                this._writeCallback = writeCallback;
            }

            public void OnCompleted()
            {
            }

            public void OnError(Exception error)
            {
            }

            public void OnNext(KeyValuePair<string, object> value)
            {
                _writeCallback(value);
            }
        }

        private readonly Action<KeyValuePair<string, object>> _writeCallback;

        private Func<string, object, object, bool> _writeObserverEnabled = (name, arg1, arg2) => false;

        public FakeDiagnosticListener(Action<KeyValuePair<string, object>> writeCallback)
        {
            this._writeCallback = writeCallback;            
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name.Equals("Microsoft.Azure.ServiceBus"))
            {
                _subscription = value.Subscribe(new FakeDiagnosticSourceWriteObserver(_writeCallback), IsEnabled);
            }
        }

        public void Enable()
        {
            _writeObserverEnabled = (name, arg1, arg2) => true;
        }

        public void Enable(Func<string, bool> writeObserverEnabled)
        {
            this._writeObserverEnabled = (name, arg1, arg2) => writeObserverEnabled(name);
        }

        public void Enable(Func<string, object, object, bool> writeObserverEnabled)
        {
            this._writeObserverEnabled = (name, arg1, arg2) => writeObserverEnabled(name, arg1, arg2);
        }

        public void Disable()
        {
            _writeObserverEnabled = (name, arg1, arg2) => false;
        }

        private bool IsEnabled(string s, object arg1, object arg2) =>
            _writeObserverEnabled(s, arg1, arg2);

        public void Dispose()
        {
            Disable();
            _subscription?.Dispose();
        }
    }
}
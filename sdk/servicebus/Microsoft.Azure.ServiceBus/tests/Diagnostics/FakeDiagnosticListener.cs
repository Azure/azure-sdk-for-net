// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public sealed class FakeDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        private  IDisposable subscription;
        private class FakeDiagnosticSourceWriteObserver : IObserver<KeyValuePair<string, object>>
        {
            private readonly Action<KeyValuePair<string, object>> writeCallback;

            public FakeDiagnosticSourceWriteObserver(Action<KeyValuePair<string, object>> writeCallback)
            {
                this.writeCallback = writeCallback;
            }

            public void OnCompleted()
            {
            }

            public void OnError(Exception error)
            {
            }

            public void OnNext(KeyValuePair<string, object> value)
            {
                writeCallback(value);
            }
        }

        private readonly Action<KeyValuePair<string, object>> writeCallback;

        private Func<string, object, object, bool> writeObserverEnabled = (name, arg1, arg2) => false;

        public FakeDiagnosticListener(Action<KeyValuePair<string, object>> writeCallback)
        {
            this.writeCallback = writeCallback;            
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
                subscription = value.Subscribe(new FakeDiagnosticSourceWriteObserver(writeCallback), IsEnabled);
            }
        }

        public void Enable()
        {
            writeObserverEnabled = (name, arg1, arg2) => true;
        }

        public void Enable(Func<string, bool> writeObserverEnabled)
        {
            this.writeObserverEnabled = (name, arg1, arg2) => writeObserverEnabled(name);
        }

        public void Enable(Func<string, object, object, bool> writeObserverEnabled)
        {
            this.writeObserverEnabled = (name, arg1, arg2) => writeObserverEnabled(name, arg1, arg2);
        }

        public void Disable()
        {
            writeObserverEnabled = (name, arg1, arg2) => false;
        }

        private bool IsEnabled(string s, object arg1, object arg2) =>
            writeObserverEnabled(s, arg1, arg2);

        public void Dispose()
        {
            Disable();
            subscription?.Dispose();
        }
    }
}
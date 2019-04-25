// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public sealed class FakeDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        private IDisposable subscription;
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
                this.writeCallback(value);
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
            if (value.Name.Equals("Microsoft.Azure.EventHubs"))
            {
                this.subscription = value.Subscribe(new FakeDiagnosticSourceWriteObserver(this.writeCallback), this.IsEnabled);
            }
        }

        public void Enable()
        {
            this.writeObserverEnabled = (name, arg1, arg2) => true;
        }

        public void Enable(Func<string, bool> writeObserverEnabled)
        {
            this.writeObserverEnabled = (name, arg1, arg2) => writeObserverEnabled(name);
        }

        public void Enable(Func<string, object, object, bool> writeObserverEnabled)
        {
            this.writeObserverEnabled = writeObserverEnabled;
        }

        public void Disable()
        {
            this.writeObserverEnabled = (name, arg1, arg2) => false;
        }

        private bool IsEnabled(string s, object arg1, object arg2)
        {
            return this.writeObserverEnabled.Invoke(s, arg1, arg2);
        }

        public void Dispose()
        {
            this.Disable();
            this.subscription?.Dispose();
        }
    }
}

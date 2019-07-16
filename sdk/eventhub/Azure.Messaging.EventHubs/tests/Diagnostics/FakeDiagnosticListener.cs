using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Messaging.EventHubs.Tests
{
    internal sealed class FakeDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        private IDisposable subscription;

        private readonly Action<KeyValuePair<string, object>> writeCallback;

        private Func<string, object, object, bool> writeObserverEnabled = (name, arg1, arg2) => false;

        public FakeDiagnosticListener(Action<KeyValuePair<string, object>> writeCallback)
        {
            this.writeCallback = writeCallback;
        }

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name.Equals("Azure.Messaging.EventHubs"))
            {
                this.subscription = value.Subscribe(new FakeDiagnosticSourceWriteObserver(this.writeCallback), this.IsEnabled);
            }
        }

        public void Enable(Func<string, object, object, bool> writeObserverEnabled)
        {
            this.writeObserverEnabled = writeObserverEnabled;
        }

        public void Disable()
        {
            this.writeObserverEnabled = (name, arg1, arg2) => false;
        }

        public bool IsEnabled(string s, object arg1, object arg2)
        {
            return this.writeObserverEnabled.Invoke(s, arg1, arg2);
        }

        public void Dispose()
        {
            this.Disable();
            this.subscription?.Dispose();
        }

        private class FakeDiagnosticSourceWriteObserver : IObserver<KeyValuePair<string, object>>
        {
            private readonly Action<KeyValuePair<string, object>> writeCallback;

            public FakeDiagnosticSourceWriteObserver(Action<KeyValuePair<string, object>> writeCallback)
            {
                this.writeCallback = writeCallback;
            }

            public void OnCompleted() { }

            public void OnError(Exception error) { }

            public void OnNext(KeyValuePair<string, object> value)
            {
                this.writeCallback(value);
            }
        }
    }
}

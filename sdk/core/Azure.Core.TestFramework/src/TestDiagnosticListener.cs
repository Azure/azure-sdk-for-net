// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Tests
{
    // DO NOT USE - use ClientDiagnosticListener instead
    public class TestDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        private readonly Func<DiagnosticListener, bool> _selector;

        private List<IDisposable> _subscriptions = new();

        public List<DiagnosticListener> Sources { get; } = new();
        public Action<(string Key, object Value, DiagnosticListener Listener)> EventCallback { get; set; }
        public Queue<(string Key, object Value, DiagnosticListener Listener)> Events { get; } = new();

        public Queue<(string Name, object Arg1, object Arg2)> IsEnabledCalls { get; } = new();

        public TestDiagnosticListener(string name) : this(source => source.Name == name)
        {
        }

        public TestDiagnosticListener(Func<DiagnosticListener, bool> selector)
        {
            _selector = selector;
            DiagnosticListener.AllListeners.Subscribe(this);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(DiagnosticListener value)
        {
            List<IDisposable> subscriptions = _subscriptions;
            if (_selector(value) && subscriptions != null)
            {
                lock (subscriptions)
                {
                    Sources.Add(value);
                    subscriptions.Add(value.Subscribe(new InternalListener(evt =>
                    {
                        lock (Events)
                        {
                            Events.Enqueue(evt);
                        }

                        EventCallback?.Invoke(evt);
                    }, value), IsEnabled));
                }
            }
        }

        private bool IsEnabled(string arg1, object arg2, object arg3)
        {
            lock (IsEnabledCalls)
            {
                IsEnabledCalls.Enqueue((arg1, arg2, arg3));
            }
            return true;
        }

        public void Dispose()
        {
            if (_subscriptions != null)
            {
                List<IDisposable> subscriptions = null;

                lock (_subscriptions)
                {
                    if (_subscriptions != null)
                    {
                        subscriptions = _subscriptions;
                        _subscriptions = null;
                    }
                }

                if (subscriptions != null)
                {
                    foreach (IDisposable subscription in subscriptions)
                    {
                        subscription.Dispose();
                    }
                }
            }
        }

        private class InternalListener : IObserver<KeyValuePair<string, object>>
        {
            private readonly Action<(string, object, DiagnosticListener)> _queue;

            private DiagnosticListener _listener;

            public InternalListener(
                Action<(string Key, object Value, DiagnosticListener Listener)> eventCallback,
                DiagnosticListener listener)
            {
                _queue = eventCallback;
                _listener = listener;
            }

            public void OnCompleted()
            {
            }

            public void OnError(Exception error)
            {
            }

            public void OnNext(KeyValuePair<string, object> value)
            {
                _queue((value.Key, value.Value, _listener));
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Tests
{
    public class TestDiagnosticListener : IObserver<DiagnosticListener>, IDisposable
    {
        private readonly Func<DiagnosticListener, bool> _selector;

        private List<IDisposable> _subscriptions = new List<IDisposable>();

        public Queue<(string Key, object Value, DiagnosticListener Listener)> Events { get; } =
            new Queue<(string Key, object Value, DiagnosticListener Listener)>();

        public Queue<(string, object, object)> IsEnabledCalls { get; } = new Queue<(string, object, object)>();

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
                    subscriptions.Add(value.Subscribe(new InternalListener(Events, value), IsEnabled));
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
            private readonly Queue<(string, object, DiagnosticListener)> _queue;

            private DiagnosticListener _listener;

            public InternalListener(
                Queue<(string, object, DiagnosticListener)> queue,
                DiagnosticListener listener)
            {
                _queue = queue;
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
                lock (_queue)
                {
                    _queue.Enqueue((value.Key, value.Value, _listener));
                }
            }
        }
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Tests
{
    public class TestDiagnosticListener : IObserver<DiagnosticListener>, IObserver<KeyValuePair<string, object>>, IDisposable
    {
        private readonly string _diagnosticSourceName;

        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public Queue<KeyValuePair<string, object>> Events { get; } = new Queue<KeyValuePair<string, object>>();

        public Queue<(string, object,  object)> IsEnabledCalls { get; } = new Queue<(string, object,  object)>();

        public TestDiagnosticListener(string diagnosticSourceName)
        {
            _diagnosticSourceName = diagnosticSourceName;
            DiagnosticListener.AllListeners.Subscribe(this);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(KeyValuePair<string, object> value)
        {
            Events.Enqueue(value);
        }

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name == _diagnosticSourceName)
            {
                _subscriptions.Add(value.Subscribe(this, IsEnabled));
            }
        }

        private bool IsEnabled(string arg1, object arg2, object arg3)
        {
            IsEnabledCalls.Enqueue((arg1, arg2, arg3));
            return true;
        }

        public void Dispose()
        {
            foreach (IDisposable subscription in _subscriptions)
            {
                subscription.Dispose();
            }
        }
    }
}

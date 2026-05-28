// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Azure.Core.Tests
{
    public class ClientDiagnosticListener : IObserver<KeyValuePair<string, object>>, IObserver<DiagnosticListener>, IDisposable
    {
        private readonly Func<string, bool> _sourceNameFilter;
        private readonly AsyncLocal<bool> _collectThisStack;

        private List<IDisposable> _subscriptions = new List<IDisposable>();
        private readonly Action<ProducedDiagnosticScope> _scopeStartCallback;

        public List<ProducedDiagnosticScope> Scopes { get; } = new List<ProducedDiagnosticScope>();

        public ClientDiagnosticListener(string name, bool asyncLocal = false, Action<ProducedDiagnosticScope> scopeStartCallback = default)
            : this(n => n == name, asyncLocal, scopeStartCallback)
        {
        }

        public ClientDiagnosticListener(Func<string, bool> filter, bool asyncLocal = false, Action<ProducedDiagnosticScope> scopeStartCallback = default)
        {
            if (asyncLocal)
            {
                _collectThisStack = new AsyncLocal<bool> { Value = true };
            }
            _sourceNameFilter = filter;
            _scopeStartCallback = scopeStartCallback;
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
            if (_collectThisStack?.Value == false) return;

            lock (Scopes)
            {
                // Check for disposal
                if (_subscriptions == null) return;

                var startSuffix = ".Start";
                var stopSuffix = ".Stop";
                var exceptionSuffix = ".Exception";

                if (value.Key.EndsWith(startSuffix))
                {
                    var name = value.Key.Substring(0, value.Key.Length - startSuffix.Length);
                    PropertyInfo propertyInfo = value.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links");
                    var links = propertyInfo?.GetValue(value.Value) as IEnumerable<Activity> ?? Array.Empty<Activity>();

                    var scope = new ProducedDiagnosticScope()
                    {
                        Name = name,
                        Activity = Activity.Current,
                        Links = links.Select(a => new ProducedLink(a.ParentId, a.TraceStateString)).ToList(),
                        LinkedActivities = links.ToList()
                    };

                    Scopes.Add(scope);
                    _scopeStartCallback?.Invoke(scope);
                }
                else if (value.Key.EndsWith(stopSuffix))
                {
                    var name = value.Key.Substring(0, value.Key.Length - stopSuffix.Length);
                    foreach (ProducedDiagnosticScope producedDiagnosticScope in Scopes)
                    {
                        if (producedDiagnosticScope.Activity.Id == Activity.Current.Id)
                        {
                            producedDiagnosticScope.IsCompleted = true;
                            return;
                        }
                    }
                    throw new InvalidOperationException($"Event '{name}' was not started");
                }
                else if (value.Key.EndsWith(exceptionSuffix))
                {
                    var name = value.Key.Substring(0, value.Key.Length - exceptionSuffix.Length);
                    foreach (ProducedDiagnosticScope producedDiagnosticScope in Scopes)
                    {
                        if (producedDiagnosticScope.Activity.Id == Activity.Current.Id)
                        {
                            if (producedDiagnosticScope.IsCompleted)
                            {
                                throw new InvalidOperationException("Scope should not be stopped when calling Failed");
                            }

                            producedDiagnosticScope.Exception = (Exception)value.Value;
                        }
                    }
                }
            }
        }

        public void OnNext(DiagnosticListener value)
        {
            if (_sourceNameFilter(value.Name) && _subscriptions != null)
            {
                lock (Scopes)
                {
                    if (_subscriptions != null)
                    {
                        _subscriptions.Add(value.Subscribe(this));
                    }
                }
            }
        }

        public void Dispose()
        {
            if (_subscriptions == null)
            {
                return;
            }

            List<IDisposable> subscriptions;
            lock (Scopes)
            {
                subscriptions = _subscriptions;
                _subscriptions = null;
            }

            foreach (IDisposable subscription in subscriptions)
            {
                subscription.Dispose();
            }

            foreach (ProducedDiagnosticScope producedDiagnosticScope in Scopes)
            {
                var activity = producedDiagnosticScope.Activity;
                var operationName = activity.OperationName;
                // traverse the activities and check for duplicates among ancestors
                while (activity != null)
                {
                    if (operationName == activity.Parent?.OperationName)
                    {
#if NET5_0_OR_GREATER
                        // Throw this exception lazily on Dispose, rather than when the scope is started, so that we don't trigger a bunch of other
                        // erroneous exceptions relating to scopes not being completed/started that hide the actual issue
                        throw new InvalidOperationException($"A scope has already started for event '{producedDiagnosticScope.Name}'");
#endif
                    }

                    activity = activity.Parent;
                }

                if (!producedDiagnosticScope.IsCompleted)
                {
                    throw new InvalidOperationException($"'{producedDiagnosticScope.Name}' scope is not completed");
                }
            }
        }

        public ProducedDiagnosticScope AssertScopeStarted(string name, params KeyValuePair<string, string>[] expectedAttributes) =>
            AssertScopeStartedInternal(name, false, expectedAttributes);

        private ProducedDiagnosticScope AssertScopeStartedInternal(string name, bool remove, params KeyValuePair<string, string>[] expectedAttributes)
        {
            lock (Scopes)
            {
                var foundScopeNames = Scopes.Select(s => s.Name);
                foreach (ProducedDiagnosticScope producedDiagnosticScope in Scopes)
                {
                    if (producedDiagnosticScope.Name == name)
                    {
                        foreach (KeyValuePair<string, string> expectedAttribute in expectedAttributes)
                        {
                            if (!producedDiagnosticScope.Activity.Tags.Contains(expectedAttribute))
                            {
                                throw new InvalidOperationException($"Attribute {expectedAttribute} not found, existing attributes: {string.Join(",", producedDiagnosticScope.Activity.Tags)}");
                            }
                        }

                        if (remove)
                        {
                            Scopes.Remove(producedDiagnosticScope);
                        }

                        return producedDiagnosticScope;
                    }
                }
                throw new InvalidOperationException($"Event '{name}' was not started. Found scope names:\n{string.Join("\n", foundScopeNames)}\n");
            }
        }

        public ProducedDiagnosticScope AssertScope(string name, params KeyValuePair<string, string>[] expectedAttributes) =>
            AssertScopeInternal(name, false, expectedAttributes);

        public ProducedDiagnosticScope AssertAndRemoveScope(string name, params KeyValuePair<string, string>[] expectedAttributes) =>
            AssertScopeInternal(name, true, expectedAttributes);

        private ProducedDiagnosticScope AssertScopeInternal(string name, bool remove,
            params KeyValuePair<string, string>[] expectedAttributes)
        {
            ProducedDiagnosticScope scope = AssertScopeStartedInternal(name, remove, expectedAttributes);
            if (!scope.IsCompleted)
            {
                throw new InvalidOperationException($"'{name}' is not completed");
            }

            return scope;
        }

        public ProducedDiagnosticScope AssertScopeException(string name, Action<Exception> action = null)
        {
            ProducedDiagnosticScope scope = AssertScopeStarted(name);

            if (scope.Exception == null)
            {
                throw new InvalidOperationException($"Scope '{name}' is not marked as failed");
            }

            action?.Invoke(scope.Exception);

            return scope;
        }

        public class ProducedDiagnosticScope
        {
            public string Name { get; set; }
            public Activity Activity { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsFailed => Exception != null;
            public Exception Exception { get; set; }
            public List<ProducedLink> Links { get; set; } = new List<ProducedLink>();
            public List<Activity> LinkedActivities { get; set; } = new List<Activity>();

            public override string ToString()
            {
                return Name;
            }
        }

        public struct ProducedLink
        {
            public ProducedLink(string id)
            {
                Traceparent = id;
                Tracestate = null;
            }

            public ProducedLink(string traceparent, string tracestate)
            {
                Traceparent = traceparent;
                Tracestate = tracestate;
            }

            public string Traceparent { get; set; }
            public string Tracestate { get; set; }
        }
    }
}

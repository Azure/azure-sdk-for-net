// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal sealed class ScopeGroupHandler : IScopeHandler
    {
        private static readonly AsyncLocal<IScopeHandler> _currentAsyncLocal = new AsyncLocal<IScopeHandler>();
        private readonly string _groupName;
        private Dictionary<string, ChildScopeInfo> _childScopes;

        public static IScopeHandler Current => _currentAsyncLocal.Value;

        public ScopeGroupHandler(string groupName)
        {
            _groupName = groupName;
            _currentAsyncLocal.Value = this;
        }

        public DiagnosticScope CreateScope(ClientDiagnostics diagnostics, string name)
        {
            if (IsGroup(name))
            {
                return diagnostics.CreateScope(name);
            }

            _childScopes ??= new Dictionary<string, ChildScopeInfo>();
            _childScopes[name] = new ChildScopeInfo(diagnostics, name);
            return default;
        }

        public void Start(string name, in DiagnosticScope scope)
        {
            if (IsGroup(name))
            {
                scope.Start();
            }
            else
            {
                _childScopes[name].StartDateTime = DateTime.UtcNow;
            }
        }

        public void Dispose(string name, in DiagnosticScope scope)
        {
            if (!IsGroup(name))
            {
                return;
            }

            var succeededScope = _childScopes?.Values.LastOrDefault(i => i.Exception == default);
            if (succeededScope != null)
            {
                SucceedChildScope(succeededScope);
            }

            scope.Dispose();
            _currentAsyncLocal.Value = default;
        }

        public void Fail(string name, in DiagnosticScope scope, Exception exception)
        {
            if (_childScopes == default)
            {
                scope.Failed(exception);
                return;
            }

            if (IsGroup(name))
            {
                if (exception is OperationCanceledException)
                {
                    var canceledScope = _childScopes.Values.Last(i => i.Exception == exception);
                    FailChildScope(canceledScope);
                }
                else
                {
                    foreach (var childScope in _childScopes.Values)
                    {
                        FailChildScope(childScope);
                    }
                }

                scope.Failed(exception);
            }
            else
            {
                _childScopes[name].Exception = exception;
            }
        }

        private static void SucceedChildScope(ChildScopeInfo scopeInfo)
        {
            using DiagnosticScope scope = scopeInfo.Diagnostics.CreateScope(scopeInfo.Name);
            scope.SetStartTime(scopeInfo.StartDateTime);
            scope.Start();
        }

        private static void FailChildScope(ChildScopeInfo scopeInfo)
        {
            using DiagnosticScope scope = scopeInfo.Diagnostics.CreateScope(scopeInfo.Name);
            scope.SetStartTime(scopeInfo.StartDateTime);
            scope.Start();
            scope.Failed(scopeInfo.Exception);
        }

        private bool IsGroup(string name) => string.Equals(name, _groupName, StringComparison.Ordinal);

        private class ChildScopeInfo
        {
            public ClientDiagnostics Diagnostics { get; }
            public string Name { get; }
            public DateTime StartDateTime { get; set; }
            public Exception Exception { get; set; }

            public ChildScopeInfo(ClientDiagnostics diagnostics, string name)
            {
                Diagnostics = diagnostics;
                Name = name;
            }
        }
    }
}

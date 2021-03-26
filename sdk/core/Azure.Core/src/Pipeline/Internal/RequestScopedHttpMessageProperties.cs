// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Core.Pipeline
{
    internal static class RequestScopedHttpMessageProperties
    {
        private static readonly AsyncLocal<HttpMessagePropertiesScope?> CurrentHttpMessagePropertiesScope = new AsyncLocal<HttpMessagePropertiesScope?>();

        internal static IDisposable StartScope(string name, object value)
        {
            CurrentHttpMessagePropertiesScope.Value = new HttpMessagePropertiesScope(name, value, CurrentHttpMessagePropertiesScope.Value);

            return CurrentHttpMessagePropertiesScope.Value;
        }

        internal static void AddHttpMessageProperties(HttpMessage message)
        {
            if (CurrentHttpMessagePropertiesScope.Value != null)
            {
                foreach (KeyValuePair<string, object> kvp in CurrentHttpMessagePropertiesScope.Value.Properties)
                {
                    message.SetProperty(kvp.Key, kvp.Value);
                }
            }
        }

        private class HttpMessagePropertiesScope : IDisposable
        {
            private readonly HttpMessagePropertiesScope? _parent;
            private bool _disposed;

            internal HttpMessagePropertiesScope(string name, object value, HttpMessagePropertiesScope? parent)
            {
                Argument.AssertNotNullOrWhiteSpace(name, nameof(name));
                Argument.AssertNotNull(value, nameof(value));
                if (parent != null)
                {
                    Properties = new Dictionary<string, object>(parent.Properties);
                }
                else
                {
                    Properties = new Dictionary<string, object>();
                }
                Properties[name] = value;
                _parent = parent;
            }

            public Dictionary<string, object> Properties { get; }

            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }
                CurrentHttpMessagePropertiesScope.Value = _parent;
                _disposed = true;
            }
        }
    }
}

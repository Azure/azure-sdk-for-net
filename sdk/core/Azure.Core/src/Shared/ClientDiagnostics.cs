// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Reflection;

#nullable enable

namespace Azure.Core.Pipeline
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal sealed class ClientDiagnostics
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly string? _resourceProviderNamespace;
        private readonly DiagnosticListener? _source;

        public bool IsActivityEnabled { get;  }

        public ClientDiagnostics(string clientNamespace, string? resourceProviderNamespace, bool isActivityEnabled)
        {
            _resourceProviderNamespace = resourceProviderNamespace;
            IsActivityEnabled = isActivityEnabled;
            if (IsActivityEnabled)
            {
                _source = new DiagnosticListener(clientNamespace);
            }
        }

        public ClientDiagnostics(ClientOptions options) : this(
            options.GetType().Namespace,
            GetResourceProviderNamespace(options.GetType().Assembly),
            options.Diagnostics.IsDistributedTracingEnabled)
        {
        }

        public DiagnosticScope CreateScope(string name)
        {
            if (_source == null)
            {
                return default;
            }
            var scope = new DiagnosticScope(name, _source);

            if (_resourceProviderNamespace != null)
            {
                scope.AddAttribute("az.namespace", _resourceProviderNamespace);
            }
            return scope;
        }

        internal static string? GetResourceProviderNamespace(Assembly assembly)
        {
            foreach (var customAttribute in assembly.GetCustomAttributes(true))
            {
                // Weak bind internal shared type
                var attributeType = customAttribute.GetType();
                if (attributeType.Name == "AzureResourceProviderNamespaceAttribute")
                {
                    return attributeType.GetProperty("ResourceProviderNamespace")?.GetValue(customAttribute) as string;
                }
            }

            return null;
        }
    }
}

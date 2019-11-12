// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core;

#nullable enable

namespace Azure.Core.Pipeline
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    [Obsolete("This type is only available for backwards compatibility with the 12.0.0 version of Storage libraries. It should not be used for new development.", true)]
    internal sealed class ClientDiagnostics
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly DiagnosticListener? _source;

        public ClientDiagnostics(string clientNamespace, bool isActivityEnabled)
        {
            if (isActivityEnabled)
            {
                _source = new DiagnosticListener(clientNamespace);
            }
        }

        public ClientDiagnostics(ClientOptions options) : this(options.GetType().Namespace, options.Diagnostics.IsDistributedTracingEnabled)
        {
        }

        public DiagnosticScope CreateScope(string name)
        {
            if (_source == null)
            {
                return default;
            }
            return new DiagnosticScope(name, _source);
        }
    }
}

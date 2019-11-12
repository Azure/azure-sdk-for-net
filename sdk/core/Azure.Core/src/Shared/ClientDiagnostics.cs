// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Core;

#nullable enable

#if StorageSDK
namespace Azure.Storage.Shared
#else
namespace Azure.Core.Pipeline
#endif
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
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

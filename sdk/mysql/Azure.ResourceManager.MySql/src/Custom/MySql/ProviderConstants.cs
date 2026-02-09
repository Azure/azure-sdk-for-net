// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Pipeline;

namespace Azure.ResourceManager.MySql
{
    internal static class ProviderConstants
    {
        public static string DefaultProviderNamespace { get; } = ClientDiagnostics.GetResourceProviderNamespace(typeof(ProviderConstants).Assembly);
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault
{
    internal partial class KeyVaultPipeline
    {
        public KeyVaultPipeline(ClientDiagnostics clientDiagnostics)
        {
            Diagnostics = clientDiagnostics;
        }
    }
}

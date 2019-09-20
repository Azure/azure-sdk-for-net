// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Keys.Tests
{
    internal class MockKeyVaultPipeline : IKeyVaultPipeline
    {
        public DiagnosticScope CreateScope(string name) => new DiagnosticScope();
    }
}

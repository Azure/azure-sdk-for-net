// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Relationships.Mocking
{
    public partial class MockableRelationshipsResourceGroupResource
    {
        // TODO: Remove this workaround after regenerating with the fix for
        // https://github.com/Azure/azure-sdk-for-net/issues/62600 (resource-type API-version overrides).
        private ContainsRelationships ContainsRelationshipsRestClient
        {
            get
            {
                if (_containsRelationshipsRestClient == null)
                {
                    TryGetApiVersion("Microsoft.Relationships/contains", out string apiVersion);
                    _containsRelationshipsRestClient = new ContainsRelationships(
                        ContainsRelationshipsClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint,
                        apiVersion ?? "2026-08-01");
                }
                return _containsRelationshipsRestClient;
            }
        }
    }
}

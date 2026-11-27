// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Relationships.Mocking
{
    public partial class MockableRelationshipsResourceGroupResource
    {
        // These contains list operations have no resource association in generator metadata,
        // so their generated REST client does not apply resource-type API-version overrides.
        // Explicitly use the known resource-type key to preserve ArmClientOptions.SetApiVersion behavior.
        // There is currently no general solution because ArmClientOptions only configures
        // resource-type API versions, not versions for individual non-resource operations.
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

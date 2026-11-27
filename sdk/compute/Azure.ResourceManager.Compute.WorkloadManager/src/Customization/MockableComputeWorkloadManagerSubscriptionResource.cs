// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.WorkloadManager.Mocking
{
    // Remove after https://github.com/Azure/azure-sdk-for-net/issues/62600 is fixed in the pinned generator.
    [CodeGenSuppress("WorkloadSpacesRestClient")]
    public partial class MockableComputeWorkloadManagerSubscriptionResource
    {
        private WorkloadSpaces WorkloadSpacesRestClient
        {
            get
            {
                if (_workloadSpacesRestClient == null)
                {
                    TryGetApiVersion(WorkloadSpaceResource.ResourceType, out string apiVersion);
                    _workloadSpacesRestClient = new WorkloadSpaces(
                        WorkloadSpacesClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint,
                        apiVersion ?? "2026-11-01-preview");
                }
                return _workloadSpacesRestClient;
            }
        }
    }
}

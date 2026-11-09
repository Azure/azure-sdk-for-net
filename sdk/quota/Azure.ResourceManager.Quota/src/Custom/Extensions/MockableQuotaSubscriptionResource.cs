// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Quota.Mocking
{
    [CodeGenSuppress("IncomingQuotaTransfersRestClient")]
    public partial class MockableQuotaSubscriptionResource
    {
        // The pinned generator bypasses API-version overrides for mockable providers.
        // Remove when the fix for https://github.com/Azure/azure-sdk-for-net/issues/62600 is included.
        private IncomingQuotaTransfers IncomingQuotaTransfersRestClient
        {
            get
            {
                if (_incomingQuotaTransfersRestClient == null)
                {
                    TryGetApiVersion(IncomingQuotaTransferResource.ResourceType, out string apiVersion);
                    _incomingQuotaTransfersRestClient = new IncomingQuotaTransfers(
                        IncomingQuotaTransfersClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint,
                        apiVersion ?? "2026-09-01-preview");
                }
                return _incomingQuotaTransfersRestClient;
            }
        }
    }
}

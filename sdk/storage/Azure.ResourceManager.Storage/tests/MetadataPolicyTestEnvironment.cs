// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;

namespace Azure.ResourceManager.Storage.Tests
{
    public class MetadataPolicyTestEnvironment : StorageManagementTestEnvironment
    {
        public string MetadataPolicyEndpoint => GetRecordedVariable("METADATA_POLICY_ENDPOINT");

        protected override TokenCredential CreateDeveloperCredential()
        {
            return new AzureCliCredential(new AzureCliCredentialOptions
            {
                TenantId = TenantId
            });
        }
    }
}

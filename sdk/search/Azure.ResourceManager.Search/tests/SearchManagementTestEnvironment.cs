// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.Search.Tests
{
    public class SearchManagementTestEnvironment : TestEnvironment
    {
        public string ExistingResourceGroup => GetRecordedOptionalVariable("EXISTING_RESOURCE_GROUP");

        public AzureLocation GetSearchLocation(string defaultLocation = "westus") =>
            GetRecordedOptionalVariable("LOCATION") ?? defaultLocation;

        protected override TokenCredential CreateDeveloperCredential()
        {
            string tenantId = GetOptionalVariable("TENANT_ID");
            if (tenantId is null)
            {
                return base.CreateDeveloperCredential();
            }

            return new AzureCliCredential(new AzureCliCredentialOptions
            {
                TenantId = tenantId
            });
        }
    }
}

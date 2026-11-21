// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchManagementTestEnvironment : TestEnvironment
    {
        // Older recordings do not contain LOCATION and used East US.
        public AzureLocation BatchLocation => new AzureLocation(GetRecordedOptionalVariable("LOCATION") ?? "eastus");

        public string BatchResourceGroup => GetRecordedVariable("batch_resource_group");

        public string BatchAccountName => GetRecordedVariable("batch_account_name");

        public string BatchAccountURI => GetRecordedVariable("batch_account_uri");

        public string BatchAccountKey => GetRecordedVariable("batch_account_key");

        public string BatchUserSubAccountName => GetRecordedVariable("batch_usersub_account_name");

        public string BatchUserSubAccountURI => GetRecordedVariable("batch_usersub_account_uri");

        public string BatchUserSubAccountKey => GetRecordedVariable("batch_usersub_account_key");

        public string DiskEncryptionSetId => GetRecordedVariable("diskencryptionset_id");

        public string CmkKeyvalutKeyUriWithVersion => GetRecordedVariable("cmk_keyvalut_keyUriWithVersion");

        public string UserAssignedIdentity => GetRecordedVariable("useridentity_id");

        protected override TokenCredential CreateDeveloperCredential()
        {
            var useCliAuth = GetOptionalVariable("USE_CLI_AUTH");
            if (useCliAuth != null && bool.Parse(useCliAuth))
            {
                return new AzureCliCredential(new AzureCliCredentialOptions { TenantId = GetVariable("TENANT_ID") });
            }

            return base.CreateDeveloperCredential();
        }
    }
}

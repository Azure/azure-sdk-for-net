// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class BatchLiveTestEnvironment : TestEnvironment
    {
        public string BatchAccountName => GetRecordedVariable("batch_account_name");

        public string BatchAccountURI => GetRecordedVariable("batch_account_uri");

        public string BatchAccountKey => GetRecordedVariable("batch_account_key", options => options.IsSecret(SanitizedValue.Base64));

        public string BatchUserSubAccountName => GetRecordedVariable("batch_usersub_account_name");

        public string BatchUserSubAccountURI => GetRecordedVariable("batch_usersub_account_uri");

        public string BatchUserSubAccountKey => GetRecordedVariable("batch_usersub_account_key", options => options.IsSecret(SanitizedValue.Base64));

        public string DiskEncryptionSetId => GetRecordedVariable("diskencryptionset_id");

        public string CmkKeyvalutKeyUriWithVersion => GetRecordedVariable("cmk_keyvalut_keyUriWithVersion");

        protected override TokenCredential CreateDeveloperCredential()
        {
            string useAzureCli = GetOptionalVariable("USE_AZURE_CLI_CREDENTIAL");
            if (useAzureCli != null && bool.Parse(useAzureCli))
            {
                return new AzureCliCredential(new AzureCliCredentialOptions
                {
                    TenantId = TenantId,
                    ProcessTimeout = TimeSpan.FromMinutes(1)
                });
            }

            return base.CreateDeveloperCredential();
        }
    }
}

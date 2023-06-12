// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Analytics.Purview.Tests;

namespace Azure.Analytics.Purview.Sharing.Tests
{
    public class SentSharesClientTestBase : RecordedTestBase<PurviewShareTestEnvironment>
    {
        public SentSharesClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
            this.BodyKeySanitizers.Add(new Core.TestFramework.Models.BodyKeySanitizer("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testResourceGroup/providers/Microsoft.Storage/storageAccounts/providerTestStorageAccount") { JsonPath = "properties.artifact.storeReference.referenceName" });
            this.BodyKeySanitizers.Add(new Core.TestFramework.Models.BodyKeySanitizer("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testResourceGroup/providers/Microsoft.Storage/storageAccounts/providerTestStorageAccount") { JsonPath = "value[0].properties.artifact.storeReference.referenceName" });
            this.BodyKeySanitizers.Add(new Core.TestFramework.Models.BodyKeySanitizer("9299795a-3979-4c95-a2fa-2431ea9171f2") { JsonPath = "properties.targetActiveDirectoryId" });
            this.BodyKeySanitizers.Add(new Core.TestFramework.Models.BodyKeySanitizer("9299795a-3979-4c95-a2fa-2431ea9171f2") { JsonPath = "value[0].properties.targetActiveDirectoryId" });

            this.UriRegexSanitizers.Add(new Core.TestFramework.Models.UriRegexSanitizer(@"[A-Za-z0-9-\-]*.purview.azure.com", "myaccountname.purview.azure.com"));
            this.HeaderRegexSanitizers.Add(new Core.TestFramework.Models.HeaderRegexSanitizer("Operation-Location", "myaccountname.purview.azure.com") { Regex = @"[A-Za-z0-9-\-]*.purview.azure.com" });
            this.HeaderRegexSanitizers.Add(new Core.TestFramework.Models.HeaderRegexSanitizer("Operation-Id", "myaccountname.purview.azure.com") { Regex = @"[A-Za-z0-9-\-]*.purview.azure.com" });
        }

        public SentSharesClient GetSentSharesClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new SentSharesClient(TestEnvironment.Endpoint.ToString(), TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Analytics.Purview.Tests;
using Azure.Core.TestFramework.Models;

namespace Azure.Analytics.Purview.Sharing.Tests
{
    public class SentSharesClientTestBase : RecordedTestBase<PurviewShareTestEnvironment>
    {
        public SentSharesClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
            this.AddPurviewSanitizers();
            this.BodyKeySanitizers.Add(new BodyKeySanitizer("properties.artifact.storeReference.referenceName") { Value = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testResourceGroup/providers/Microsoft.Storage/storageAccounts/providerTestStorageAccount" });
            this.BodyKeySanitizers.Add(new BodyKeySanitizer("value[0].properties.artifact.storeReference.referenceName") { Value = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testResourceGroup/providers/Microsoft.Storage/storageAccounts/providerTestStorageAccount" });
            this.BodyKeySanitizers.Add(new BodyKeySanitizer("properties.targetActiveDirectoryId") { Value = "9299795a-3979-4c95-a2fa-2431ea9171f2" });
            this.BodyKeySanitizers.Add(new BodyKeySanitizer("value[0].properties.targetActiveDirectoryId") { Value = "9299795a-3979-4c95-a2fa-2431ea9171f2" });

            this.UriRegexSanitizers.Add(new UriRegexSanitizer(@"[A-Za-z0-9-\-]*.purview.azure.com") { Value = "myaccountname.purview.azure.com" });
            this.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Operation-Location")
            {
                Regex = @"[A-Za-z0-9-\-]*.purview.azure.com",
                Value = "myaccountname.purview.azure.com"
            });
            this.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Operation-Id")
            {
                Regex = @"[A-Za-z0-9-\-]*.purview.azure.com",
                Value = "myaccountname.purview.azure.com"
            });
        }

        public SentSharesClient GetSentSharesClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewShareClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new SentSharesClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
        }
    }
}

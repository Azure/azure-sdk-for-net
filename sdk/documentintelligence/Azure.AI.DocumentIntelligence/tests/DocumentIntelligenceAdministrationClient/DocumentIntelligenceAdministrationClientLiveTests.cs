// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentIntelligenceAdministrationClientLiveTests : DocumentIntelligenceLiveTestBase
    {
        public DocumentIntelligenceAdministrationClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/40054")]
        public async Task DocumentIntelligenceAdministrationClientCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentIntelligenceAdministrationClient(useTokenCredential: true);

            Response<ResourceDetails> response = await client.GetResourceInfoAsync();
            Response rawResponse = response.GetRawResponse();

            Assert.That(rawResponse.Status, Is.EqualTo(200));
        }
    }
}

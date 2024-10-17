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
        public async Task DocumentIntelligenceAdministrationClientCanAuthenticateWithApiKey()
        {
            var client = CreateDocumentIntelligenceAdministrationClient(useApiKey: true);

            Response<ResourceDetails> response = await client.GetResourceInfoAsync();
            Response rawResponse = response.GetRawResponse();

            Assert.That(rawResponse.Status, Is.EqualTo(200));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentIntelligenceClientLiveTests : DocumentIntelligenceLiveTestBase
    {
        public DocumentIntelligenceClientLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/40054")]
        public async Task DocumentIntelligenceClientCanAuthenticateWithTokenCredential()
        {
            var client = CreateDocumentIntelligenceClient(useTokenCredential: true);

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.Blank)
            };

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content);
            Response rawResponse = operation.GetRawResponse();

            Assert.That(rawResponse.Status, Is.EqualTo(200));
        }
    }
}

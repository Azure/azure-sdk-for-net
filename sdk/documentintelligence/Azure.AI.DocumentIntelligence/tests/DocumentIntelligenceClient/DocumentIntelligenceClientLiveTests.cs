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
        public async Task DocumentIntelligenceClientCanAuthenticateWithApiKey()
        {
            var client = CreateDocumentIntelligenceClient(useApiKey: true);

            var uriSource = DocumentIntelligenceTestEnvironment.CreateUri(TestFile.Blank);
            var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource);

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
            Response rawResponse = operation.GetRawResponse();

            Assert.That(rawResponse.Status, Is.EqualTo(200));
        }
    }
}

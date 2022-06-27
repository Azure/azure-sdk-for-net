// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.LoadTestService.Tests
{
    public class LoadTestServiceClientTest: RecordedTestBase<LoadTestServiceClientTestEnvironment>
    {
        public LoadTestServiceClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */
        private TestClient CreateClient()
        {
            return InstrumentClient(new TestClient (
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new AzureLoadTestingClientOptions())
            ));
        }
        [Test]
        public void TestOperation()
        {
            Assert.IsTrue(true);
        }
        [RecordedTest]
        public async Task CreateorUpdateLoadTest()
        {
            var client = CreateClient();
            string test_id = Guid.NewGuid().ToString();
            TestModel inputTestModel = new TestModel();
            inputTestModel.testId = "a011890b-12cd-000a-0150-12aed8880000";
            inputTestModel.displayName = "dotnetTest";
            inputTestModel.resourceId = "/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/yashika-rg/providers/Microsoft.LoadTestService/loadtests/loadtestsdk";
            inputTestModel.loadTestConfig = new LoadTestConfig();
            inputTestModel.loadTestConfig.engineInstances = 1;
            string testId = "a011890b-12cd-000a-0150-12aed8880000";
            string jsonString = JsonSerializer.Serialize(inputTestModel);
            RequestContent content = RequestContent.Create(jsonString);
            var response = await client.CreateOrUpdateTestAsync(testId, content);
            Assert.IsNotNull(response);
        }

        [RecordedTest]
        public async Task GetTest()
        {
            TestClient client = CreateClient();
            string test_id = "a011890b-12cd-004d-015d-12aed8880000";
            var response = await client.GetLoadTestAsync(test_id);
            Assert.IsNotNull(response);
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}

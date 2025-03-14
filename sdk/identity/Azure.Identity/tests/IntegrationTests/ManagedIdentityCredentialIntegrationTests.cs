// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialIntegrationTests : IdentityRecordedTestBase
    {
        private HttpPipeline _pipeline;

        public ManagedIdentityCredentialIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() {
            var options = new TokenCredentialOptions();
            _pipeline = HttpPipelineBuilder.Build(InstrumentClientOptions(options), Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
        }

        [RecordedTest]
        [SyncOnly]
        // This test leverages the test app found in Azure.Identity\integration\WebApp
        // It validates that ManagedIdentityCredential can acquire a token in an actual Azure Web App environment
        public async Task CallIntegrationTestWebApp()
        {
            var testEndpoint = new Uri($"https://{TestEnvironment.IdentityTestWebName}.azurewebsites.net/test");
            Request request = _pipeline.CreateRequest();
            request.Uri.Reset(testEndpoint);
            Response response = await _pipeline.SendRequestAsync(request, default);

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.AreEqual("Successfully acquired a token from ManagedIdentityCredential", response.Content.ToString(), response.Content.ToString());
        }

        [RecordedTest]
        [SyncOnly]
        // This test leverages the test app found in Azure.Identity\integration\Integration.Identity.Func
        // It validates that ManagedIdentityCredential can acquire a token in an actual Azure Web App environment
        public async Task CallIntegrationTestAzFunction()
        {
            var testEndpoint = new Uri($"https://{TestEnvironment.IdentityTestAzFuncName}.azurewebsites.net/api/function1");
            Request request = _pipeline.CreateRequest();
            request.Uri.Reset(testEndpoint);
            Response response = await _pipeline.SendRequestAsync(request, default);

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.AreEqual("Successfully acquired a token from ManagedIdentityCredential", response.Content.ToString(), response.Content.ToString());
        }
    }
}

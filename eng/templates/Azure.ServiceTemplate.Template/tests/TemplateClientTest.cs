// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ServiceTemplate.Template.Tests
{
    public class TemplateClientTest: RecordedTestBase<TemplateClientTestEnvironment>
    {
        public TemplateClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* Greate the client and instrument it as following. */
        // private TemplateClient CreateClient()
        // {
        //     var httpHandler = new HttpClientHandler();
        //     httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
        //     {
        //         return true;
        //     };
        //     var options = new TemplateClientOptions { Transport = new HttpClientTransport(httpHandler) };
        //     var client = InstrumentClient(
        //         new TemplateClient(TestEnvironment.Endpoint, TestEnvironment.<other-client-parameters>, TestEnvironment.Credential, InstrumentClientOptions(options)));
        //     return client;
        // }
        // Add Test here as following.
        // [RecordedTest]
        // public async Task TestOperation()
        // {
        // }

        [RecordedTest]
        public void TestOperation()
        {
            Assert.IsTrue(true);
        }

        // Add live tests here. If you need more information please refer https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing and
        // here are some examples: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/tests/AccessControlClientLiveTests.cs.

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

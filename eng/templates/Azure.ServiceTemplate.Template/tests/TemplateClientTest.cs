// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ServiceTemplate.Template.Tests
{
    public class TemplateClientTest: RecordedTestBase<TemplateClientTestEnvironment>
    {
        public TemplateClientTest(bool isAsync) : base(isAsync)
        {
        }

        private TemplateClient CreateClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new TemplateClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var client = InstrumentClient(
                new TemplateClient(TestEnvironment.AccountEndPoint, TestEnvironment.InstanceId, TestEnvironment.Credential, InstrumentClientOptions(options)));
            return client;
        }

        [RecordedTest]
        public async Task TestOperation()
        {
            Assert.IsTrue(true);
        }

        // Add live tests here. If you need more information please refer https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing and
        // here are some examples: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/tests/AccessControlClientLiveTests.cs.

        #region Helpers

        private void SerializeResource(ref Utf8JsonWriter writer, Resource resource)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("name");
            writer.WriteStringValue(resource.Name);

            writer.WritePropertyName("id");
            writer.WriteStringValue(resource.Id);

            writer.WriteEndObject();
        }
        #endregion
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints.Tests
{
    public class ManagedPrivateEndpointsClientTests : ClientTestBase
    {
        private string managedPrivateEndpointJson = @"{
                    ""type"": ""Microsoft.Synapse/workspaces/managedVirtualNetworks/managedPrivateEndpoints"",
                    ""name"": ""myPrivateEndpoint"",
                    ""properties"": {
                            ""name"": ""myPrivateEndpoint"",
                      ""privateLinkResourceId"": ""/subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/myResourceGroup/providers/Microsoft.Storage/accounts/myStorageAccount"",
                      ""groupId"": ""blob"",
                      ""provisioningState"": ""Succeeded"",
                      ""connectionState"": {
                                ""status"": ""Approved"",
                        ""description"": """",
                        ""actionsRequired"": """"
                      },
                      ""fqdns"": [
                        ""[hostname1].[domain].[tld]"",
                        ""[hostname2].[domain].[tld]""
                      ],
                      ""isCompliant"": true
                    }
                }";

        public ManagedPrivateEndpointsClientTests(bool isAsync) : base(isAsync)
        {
        }

        private readonly Uri _url = new Uri("https://exampleworkspace.dev.azuresynapse.net");

        private ManagedPrivateEndpointsClient CreateTestClient(ManagedPrivateEndpointsClientOptions.ServiceVersion version, HttpPipelineTransport transport)
        {
            var options = new ManagedPrivateEndpointsClientOptions(version)
            {
                Transport = transport
            };

            var client = InstrumentClient(new ManagedPrivateEndpointsClient(_url, new MockCredential(), options));

            return client;
        }

        [Test]
        public async Task OptionsSetStableVersionQueryParameter()
        {
            var response = new MockResponse(200);
            response.SetContent(managedPrivateEndpointJson);

            var mockTransport = new MockTransport(response);

            ManagedPrivateEndpointsClient previewClient = CreateTestClient(ManagedPrivateEndpointsClientOptions.ServiceVersion.V2020_12_01, mockTransport);

            Response<ManagedPrivateEndpoint> endpoint = await previewClient.GetAsync("default", "TestEndpoint");

            MockRequest request = mockTransport.SingleRequest;

            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.IsTrue(request.Uri.ToString().Contains(ManagedPrivateEndpointsClientOptions.ServiceVersion.V2020_12_01.ToVersionString()));
        }
    }
}

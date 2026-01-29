// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

public class UnitTestsSamples
{
    public class MockTransportTests : ClientTestBase
    {
        public MockTransportTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void MockTypesTest()
        {
            #region Snippet:MockTypesBasics
            MockCredential credential = new();

            MockPipelineTransport mockTransport = new(message => new MockPipelineResponse(200));

            MockClientOptions options = new() { Transport = mockTransport };
            MockClient client = new(new Uri("https://example.com"), credential, options);
            #endregion
        }

        [Test]
        public void MockTransportReturnsConfiguredResponse()
        {
            #region Snippet:MockTransportBasics
            // Create a mock transport that returns a 200 response
            MockPipelineTransport mockTransport = new(_ =>
                new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"countryRegion":{"isoCode":"US"},"ipAddress":"8.8.8.8"}""")));

            MapsClientOptions options = new()
            {
                Transport = mockTransport
            };
            #endregion
        }

        [Test]
        public void MockTransportCanSimulateErrors()
        {
            #region Snippet:ErrorScenarioTesting
            // Create a mock transport that returns an error response
            MockPipelineTransport mockTransport = new(_ =>
                new MockPipelineResponse(401, "Unauthorized")
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Invalid subscription key"}""")));

            MapsClientOptions options = new()
            {
                Transport = mockTransport
            };

            // Timeout
            mockTransport = new MockPipelineTransport(message =>
            {
                throw new TaskCanceledException("Request timed out");
            });

            // Server error
            mockTransport = new MockPipelineTransport(message =>
                new MockPipelineResponse(500, "Internal Server Error")
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"error":"Server error occurred"}""")));
            #endregion
        }

        [Test]
        public async Task AccessRequest()
        {
            #region Snippet:RequestValidation
            var mockTransport = new MockPipelineTransport(_ => new MockPipelineResponse(200));
            mockTransport.ExpectSyncPipeline = !IsAsync;

            var options = new MapsClientOptions();
            options.Transport = mockTransport;

            // Call client methods
            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri("https://example.com"),
                new ApiKeyCredential("fake-key"),
                options));

            var result = await client.GetCountryCodeAsync("test");

            var request = mockTransport.Requests[0];
            #endregion
        }

        [Test]
        public async Task MockTransportWorksBothSyncAndAsync()
        {
            #region Snippet:UnitTestSyncAsync
            MockPipelineTransport mockTransport = new(_ =>
                new MockPipelineResponse(200)
                    .WithContent(System.Text.Encoding.UTF8.GetBytes("""{"id":"test","success":true}""")));
            mockTransport.ExpectSyncPipeline = !IsAsync;

            MapsClientOptions options = new();
            options.Transport = mockTransport;

            MapsClient client = CreateProxyFromClient(new MapsClient(
                new Uri("https://example.com"),
                new ApiKeyCredential("fake-key"),
                options));

            var result = await client.GetCountryCodeAsync("test");
            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class DeliveryReportsRestClientTests
    {
        [Test]
        public void DeliveryReportsRestClient_NullClientDiagnostics_ShouldThrow()
        {
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DeliveryReportsRestClient(null, httpPipeline, uri));
        }

        [Test]
        public void DeliveryReportsRestClient_NullHttpPipeline_ShouldThrow()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var endpoint = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DeliveryReportsRestClient(clientDiagnostics, null, endpoint));
        }

        [Test]
        public void DeliveryReportsRestClient_NullEndpoint_ShouldThrow()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());

            Assert.Throws<ArgumentNullException>(() => new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, null));
        }

        [Test]
        public void DeliveryReportsRestClient_NullVersion_ShouldThrow()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, uri, null));
        }

        [Test]
        public async Task DeliveryReportsRestClient_GetAsyncWithNullMessageId_ShouldThrow()
        {
            var client = CreateDeliveryReportsRestClient();

            try
            {
                await client.GetAsync(null);
                Assert.Fail("Expected ArgumentException to be thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("outgoingMessageId", ex.ParamName);
            }
        }

        [Test]
        public void DeliveryReportsRestClient_GetWithValidMessageId_ShouldCreateValidRequest()
        {
            var client = CreateDeliveryReportsRestClient();
            var messageId = "test-message-id-12345";

            var message = client.CreateGetRequest(messageId);

            Assert.NotNull(message);
            Assert.AreEqual("GET", message.Request.Method.Method);
            StringAssert.Contains("/deliveryReports/", message.Request.Uri.ToString());
            StringAssert.Contains(messageId, message.Request.Uri.ToString());
            StringAssert.Contains("api-version", message.Request.Uri.ToString());
        }

        [Test]
        [TestCase("msg-123")]
        [TestCase("a1b2c3d4-e5f6-7890-abcd-ef1234567890")]
        [TestCase("simple-id")]
        public void DeliveryReportsRestClient_GetWithVariousValidMessageIds_ShouldCreateValidRequest(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            var message = client.CreateGetRequest(messageId);

            Assert.NotNull(message);
            StringAssert.Contains(messageId, message.Request.Uri.ToString());
        }

        private static DeliveryReportsRestClient CreateDeliveryReportsRestClient()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("https://test.communication.azure.com");

            return new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, endpoint);
        }
    }
}

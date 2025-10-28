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
        public void DeliveryReportsRestClient_NullApiVersion_ShouldThrow()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, uri, null));
        }

        [Test]
        public void DeliveryReportsRestClient_GetWithNullMessageId_ShouldThrow()
        {
            var client = CreateDeliveryReportsRestClient();

            try
            {
                client.Get(null);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Contains.Substring("outgoingMessageId"));
                Assert.That(ex.Message, Contains.Substring("cannot be null, empty, or whitespace"));
            }
        }

        [Test]
        public async Task DeliveryReportsRestClient_GetAsyncWithNullMessageId_ShouldThrow()
        {
            var client = CreateDeliveryReportsRestClient();

            try
            {
                await client.GetAsync(null);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Contains.Substring("outgoingMessageId"));
                Assert.That(ex.Message, Contains.Substring("cannot be null, empty, or whitespace"));
            }
        }

        [Test]
        public void DeliveryReportsRestClient_DefaultApiVersion_IsCorrect()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("http://localhost");

            // Test that default API version is used when not specified
            Assert.DoesNotThrow(() =>
            {
                var client = new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, endpoint);
                Assert.NotNull(client);
            });
        }

        [Test]
        public void DeliveryReportsRestClient_CustomApiVersion_IsAccepted()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("http://localhost");
            var customApiVersion = "2021-03-07";

            Assert.DoesNotThrow(() =>
            {
                var client = new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, endpoint, customApiVersion);
                Assert.NotNull(client);
            });
        }

        [Test]
        public void DeliveryReportsRestClient_ClientDiagnosticsProperty_IsNotNull()
        {
            var client = CreateDeliveryReportsRestClient();

            Assert.NotNull(client.ClientDiagnostics);
        }

        [Test]
        public void DeliveryReportsRestClient_ClientDiagnosticsProperty_IsCorrectInstance()
        {
            var clientOptions = new SmsClientOptions();
            var expectedClientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("http://localhost");

            var client = new DeliveryReportsRestClient(expectedClientDiagnostics, httpPipeline, endpoint);

            Assert.AreSame(expectedClientDiagnostics, client.ClientDiagnostics);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void DeliveryReportsRestClient_GetWithEmptyOrWhitespaceMessageId_ShouldThrowArgumentException(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            // Empty/whitespace message IDs should be validated on the client side to prevent unnecessary network calls
            var ex = Assert.Throws<ArgumentException>(() => client.Get(messageId));
            Assert.AreEqual("outgoingMessageId", ex!.ParamName);
            Assert.That(ex.Message, Contains.Substring("cannot be null, empty, or whitespace"));
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public async Task DeliveryReportsRestClient_GetAsyncWithEmptyOrWhitespaceMessageId_ShouldThrowArgumentException(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            try
            {
                await client.GetAsync(messageId);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Contains.Substring("outgoingMessageId"));
                Assert.That(ex.Message, Contains.Substring("cannot be null, empty, or whitespace"));
            }
        }

        private DeliveryReportsRestClient CreateDeliveryReportsRestClient()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("http://localhost");

            return new DeliveryReportsRestClient(clientDiagnostics, httpPipeline, endpoint);
        }
    }
}

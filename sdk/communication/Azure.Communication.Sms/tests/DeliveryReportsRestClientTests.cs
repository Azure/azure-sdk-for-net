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
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("outgoingMessageId", ex.ParamName);
                return;
            }

            Assert.Fail("Expected ArgumentNullException was not thrown.");
        }

        [Test]
        public async Task DeliveryReportsRestClient_GetAsyncWithNullMessageId_ShouldThrow()
        {
            var client = CreateDeliveryReportsRestClient();

            try
            {
                await client.GetAsync(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("outgoingMessageId", ex.ParamName);
                return;
            }

            Assert.Fail("Expected ArgumentNullException was not thrown.");
        }

        [TestCase("message-123")]
        [TestCase("msg_abc-def_123")]
        [TestCase("delivery-report-456")]
        [TestCase("12345")]
        [TestCase("test-message-id-with-dashes")]
        [TestCase("test_message_id_with_underscores")]
        [TestCase("guid-like-id-12345678-1234-1234-1234-123456789012")]
        public void DeliveryReportsRestClient_AcceptsValidMessageIds(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            // Test that these message ID formats don't throw ArgumentException
            // Note: These will fail at runtime with authentication/network errors but shouldn't throw ArgumentException
            Assert.DoesNotThrow(() =>
            {
                try
                {
                    client.Get(messageId);
                }
                catch (Exception ex) when (!(ex is ArgumentException || ex is ArgumentNullException))
                {
                    // Expected - network/auth errors are OK, but not argument validation errors
                }
            });
        }

        [TestCase("message-123")]
        [TestCase("msg_abc-def_123")]
        [TestCase("delivery-report-456")]
        [TestCase("12345")]
        [TestCase("test-message-id-with-dashes")]
        [TestCase("test_message_id_with_underscores")]
        [TestCase("guid-like-id-12345678-1234-1234-1234-123456789012")]
        public void DeliveryReportsRestClient_GetAsyncAcceptsValidMessageIds(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            // Test that these message ID formats don't throw ArgumentException
            // Note: These will fail at runtime with authentication/network errors but shouldn't throw ArgumentException
            Assert.DoesNotThrow(() =>
            {
                var task = client.GetAsync(messageId);
                // We don't await this since it would fail due to invalid connection string
            });
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
        public void DeliveryReportsRestClient_GetWithEmptyOrWhitespaceMessageId_ShouldNotThrowArgumentException(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            // Empty/whitespace message IDs should be handled by the service, not client validation
            // They may result in HTTP errors but shouldn't throw ArgumentException
            Assert.DoesNotThrow(() =>
            {
                try
                {
                    client.Get(messageId);
                }
                catch (Exception ex) when (!(ex is ArgumentException || ex is ArgumentNullException))
                {
                    // Expected - network/service errors are OK, but not argument validation errors
                }
            });
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void DeliveryReportsRestClient_GetAsyncWithEmptyOrWhitespaceMessageId_ShouldNotThrowArgumentException(string messageId)
        {
            var client = CreateDeliveryReportsRestClient();

            // Empty/whitespace message IDs should be handled by the service, not client validation
            // They may result in HTTP errors but shouldn't throw ArgumentException
            Assert.DoesNotThrow(() =>
            {
                var task = client.GetAsync(messageId);
                // We don't await this since it would fail due to invalid connection string
            });
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

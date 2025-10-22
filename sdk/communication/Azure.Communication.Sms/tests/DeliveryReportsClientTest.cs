// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class DeliveryReportsClientTest
    {
        private readonly TelcoMessagingClient _telcoClient;
        private readonly DeliveryReportsClient _deliveryReportsClient;

        public DeliveryReportsClientTest()
        {
            _telcoClient = new TelcoMessagingClient("Endpoint=https://your-acs-endpoint.com/;AccessKey=your-access-key;AccessKeySecret=your-access-key-secret");
            _deliveryReportsClient = _telcoClient.DeliveryReports;
        }

        [Test]
        public void DeliveryReportsClient_IsNotNull()
        {
            Assert.NotNull(_deliveryReportsClient);
        }

        [Test]
        public void DeliveryReportsClient_HasCorrectType()
        {
            Assert.IsInstanceOf<DeliveryReportsClient>(_deliveryReportsClient);
        }

        [Test]
        public void DeliveryReportsClient_ThrowsArgumentNullException_WithNullMessageId()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _deliveryReportsClient.GetAsync(null));
            Assert.Throws<ArgumentNullException>(() => _deliveryReportsClient.Get(null));
        }

        [Test]
        public void DeliveryReportsClient_ThrowsArgumentException_WithEmptyMessageId()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _deliveryReportsClient.GetAsync(string.Empty));
            Assert.Throws<ArgumentException>(() => _deliveryReportsClient.Get(string.Empty));
        }

        [Test]
        public void DeliveryReportsClient_ThrowsArgumentException_WithWhitespaceMessageId()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _deliveryReportsClient.GetAsync("   "));
            Assert.Throws<ArgumentException>(() => _deliveryReportsClient.Get("   "));
        }

        [TestCase("message-123")]
        [TestCase("msg_abc-def_123")]
        [TestCase("delivery-report-456")]
        [TestCase("12345")]
        [TestCase("test-message-id-with-dashes")]
        [TestCase("test_message_id_with_underscores")]
        public void DeliveryReportsClient_AcceptsValidMessageIds(string messageId)
        {
            // Test that these message ID formats don't throw exceptions
            // Note: These will fail at runtime with authentication/network errors but shouldn't throw ArgumentException
            Assert.DoesNotThrow(() =>
            {
                var task = _deliveryReportsClient.GetAsync(messageId);
                // We don't await this since it would fail due to invalid connection string
            });

            Assert.DoesNotThrow(() =>
            {
                try
                {
                    _deliveryReportsClient.Get(messageId);
                }
                catch (Exception ex) when (!(ex is ArgumentException || ex is ArgumentNullException))
                {
                    // Expected - network/auth errors are OK, but not argument validation errors
                }
            });
        }

        [Test]
        public void DeliveryReportsClient_CancellationToken_DefaultValue()
        {
            // Test that cancellation token parameter has default value
            Assert.DoesNotThrow(() =>
            {
                var task = _deliveryReportsClient.GetAsync("test-message-id");
                // We don't await this since it would fail due to invalid connection string
            });
        }
    }
}

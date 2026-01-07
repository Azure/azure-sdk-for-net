// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientDeliveryReportTests
    {
        [Test]
        public void GetDeliveryReport_WithNullMessageId_ShouldThrow()
        {
            var smsClient = CreateSmsClient();

            Assert.Throws<ArgumentNullException>(() => smsClient.GetDeliveryReport(null));
        }

        [Test]
        public void GetDeliveryReport_WithEmptyMessageId_ShouldThrow()
        {
            var smsClient = CreateSmsClient();

            Assert.Throws<ArgumentException>(() => smsClient.GetDeliveryReport(string.Empty));
        }

        [Test]
        public void GetDeliveryReport_WithWhitespaceMessageId_ShouldThrow()
        {
            var smsClient = CreateSmsClient();

            Assert.Throws<ArgumentException>(() => smsClient.GetDeliveryReport("   "));
        }

        [Test]
        public void GetDeliveryReportAsync_WithNullMessageId_ShouldThrow()
        {
            var smsClient = CreateSmsClient();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await smsClient.GetDeliveryReportAsync(null));
        }

        [Test]
        public void GetDeliveryReportAsync_WithEmptyMessageId_ShouldThrow()
        {
            var smsClient = CreateSmsClient();

            Assert.ThrowsAsync<ArgumentException>(async () => await smsClient.GetDeliveryReportAsync(string.Empty));
        }

        [Test]
        public void GetDeliveryReportAsync_WithWhitespaceMessageId_ShouldThrow()
        {
            var smsClient = CreateSmsClient();

            Assert.ThrowsAsync<ArgumentException>(async () => await smsClient.GetDeliveryReportAsync("   "));
        }

        [Test]
        [TestCase("msg-123")]
        [TestCase("a1b2c3d4-e5f6-7890-abcd-ef1234567890")]
        [TestCase("OutboundSMS_12345")]
        public void GetDeliveryReport_WithVariousValidMessageIds_ShouldAccept(string messageId)
        {
            var smsClient = CreateSmsClient();

            // This will fail with network call, but validates the parameter is accepted
            try
            {
                smsClient.GetDeliveryReport(messageId);
            }
            catch (RequestFailedException)
            {
                // Expected - we're just validating the parameter validation logic
                Assert.Pass("Parameter validation passed");
            }
        }

        [Test]
        [TestCase("msg-123")]
        [TestCase("a1b2c3d4-e5f6-7890-abcd-ef1234567890")]
        [TestCase("OutboundSMS_12345")]
        public async Task GetDeliveryReportAsync_WithVariousValidMessageIds_ShouldAccept(string messageId)
        {
            var smsClient = CreateSmsClient();

            // This will fail with network call, but validates the parameter is accepted
            try
            {
                await smsClient.GetDeliveryReportAsync(messageId);
            }
            catch (RequestFailedException)
            {
                // Expected - we're just validating the parameter validation logic
                Assert.Pass("Parameter validation passed");
            }
        }

        private static SmsClient CreateSmsClient()
        {
            return new SmsClient("Endpoint=https://test.communication.azure.com/;AccessKey=dGVzdA==");
        }

        private static Response<object> CreateMockDeliveryReportResponse()
        {
            var mockResponse = new Mock<Response<object>>();
            // Note: DeliveryReport has internal constructors and is auto-generated
            // This is a placeholder for unit test structure - actual tests would use mocked REST client
            mockResponse.Setup(r => r.Value).Returns(new object());
            return mockResponse.Object;
        }
    }
}

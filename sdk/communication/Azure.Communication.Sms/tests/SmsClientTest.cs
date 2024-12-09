// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTest
    {
        public string TestConnectionString = "Endpoint=https://your-acs-endpoint.com/;AccessKey=your-access-key;AccessKeySecret=your-access-key-secret";

        [Test]
        public void SmsClient_ThrowsWithNullKeyCredential()
        {
            AzureKeyCredential? nullCredential = null;
            Uri uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new SmsClient(uri, nullCredential));
        }

        [Test]
        public void SmsClient_ThrowsWithNullUri()
        {
            AzureKeyCredential mockCredential = new AzureKeyCredential("mockKey");

            Assert.Throws<ArgumentNullException>(() => new SmsClient(null, mockCredential));
        }

        [Test]
        public void SmsClient_KeyCredential_ValidParameters()
        {
            AzureKeyCredential mockCredential = new AzureKeyCredential("mockKey");
            Uri uri = new Uri("http://localhost");

            Assert.DoesNotThrow(() => new SmsClient(uri, mockCredential));
        }

        [Test]
        public void SmsClient_TokenCredential_NullOptions()
        {
            TokenCredential mockCredential = new MockCredential();
            Uri endpoint = new Uri("http://localhost");

            Assert.DoesNotThrow(() => new SmsClient(endpoint, mockCredential, null));
        }

        [Test]
        public void SmsClient_ThrowsWithNullOrEmptyConnectionString()
        {
            Assert.Throws<ArgumentException>(() => new SmsClient(string.Empty));
            Assert.Throws<ArgumentNullException>(() => new SmsClient(null));
        }

        [Test]
        public void SmsClientOptions_ThrowsWithInvalidVersion()
        {
            var invalidServiceVersion = (SmsClientOptions.ServiceVersion)99;

            Assert.Throws<ArgumentOutOfRangeException>(() => new SmsClientOptions(invalidServiceVersion));
        }

        [Test]
        public void SmsClient_InitializesOptOutsClient_SingleArgConstructor()
        {
            var smsClient = new SmsClient(TestConnectionString);

            Assert.NotNull(smsClient.OptOuts);
        }

        [Test]
        public void SmsClient_InitializesOptOutsClient_TwoArgConstructor()
        {
            var smsClient = new SmsClient(TestConnectionString, new SmsClientOptions(SmsClientOptions.ServiceVersion.V2021_03_07));

            Assert.NotNull(smsClient.OptOuts);
        }

        [Test]
        public void SmsClient_InitializesOptOutsClient_ThreeArgConstructor()
        {
            AzureKeyCredential mockCredential = new AzureKeyCredential("mockKey");
            Uri endpoint = new Uri("http://localhost");
            var smsClient = new SmsClient(endpoint, mockCredential, new SmsClientOptions(SmsClientOptions.ServiceVersion.V2021_03_07));

            Assert.NotNull(smsClient.OptOuts);
        }

        [Test]
        public void SmsClient_InitializesOptOutsClient_ThreeArgConstructor_WithTokenCredential()
        {
            TokenCredential mockCredential = new MockCredential();
            Uri endpoint = new Uri("http://localhost");
            var smsClient = new SmsClient(endpoint, mockCredential, new SmsClientOptions(SmsClientOptions.ServiceVersion.V2021_03_07));

            Assert.NotNull(smsClient.OptOuts);
        }

        [TestCaseSource(nameof(TestDataForSingleSms))]
        public async Task SendSmsAsyncOverload_PassesToGeneratedOne(string expectedFrom, string expectedTo, string expectedMessage, SmsSendOptions expectedOptions)
        {
            Mock<SmsClient> mockClient = new Mock<SmsClient>() { CallBase = true };
            Response<SmsSendResult>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SmsSendOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string from, string to, string message, SmsSendOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(expectedMessage, message);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<SmsSendResult>>().Object;
                });

            Response<SmsSendResult> actualResponse = await mockClient.Object.SendAsync(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestDataForSingleSms))]
        public void SendSmsOverload_PassesToGeneratedOne(string expectedFrom, string expectedTo, string expectedMessage, SmsSendOptions expectedOptions)
        {
            Mock<SmsClient> mockClient = new Mock<SmsClient>() { CallBase = true };
            Response<SmsSendResult>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SmsSendOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .Returns((string from, string to, string message, SmsSendOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(expectedMessage, message);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<SmsSendResult>>().Object;
                });

            Response<SmsSendResult> actualResponse = mockClient.Object.Send(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        private static IEnumerable<object?[]> TestDataForSingleSms()
        {
            SmsSendOptions?[] optionsCombinations = new[]
            {
                new SmsSendOptions(enableDeliveryReport: true) { Tag = "custom-tag" },
                new SmsSendOptions(enableDeliveryReport: true) { Tag = null },
                null,
            };

            return optionsCombinations
                .Select(sendOptions => new object?[] { "+14255550123", "+14255550234", "Hello 👋", sendOptions });
        }

        private static Expression<Func<SmsClient, TResult>> BuildExpression<TResult>(Expression<Func<SmsClient, TResult>> expression)
            => expression;
    }
}

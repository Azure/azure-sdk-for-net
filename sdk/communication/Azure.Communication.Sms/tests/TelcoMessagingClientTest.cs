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
    public class TelcoMessagingClientTest
    {
        public string TestConnectionString = "Endpoint=https://your-acs-endpoint.com/;AccessKey=your-access-key;AccessKeySecret=your-access-key-secret";

        [Test]
        public void TelcoMessagingClient_ThrowsWithNullKeyCredential()
        {
            AzureKeyCredential? nullCredential = null;
            Uri uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new TelcoMessagingClient(uri, nullCredential));
        }

        [Test]
        public void TelcoMessagingClient_ThrowsWithNullUri()
        {
            AzureKeyCredential mockCredential = new AzureKeyCredential("mockKey");

            Assert.Throws<ArgumentNullException>(() => new TelcoMessagingClient(null, mockCredential));
        }

        [Test]
        public void TelcoMessagingClient_KeyCredential_ValidParameters()
        {
            AzureKeyCredential mockCredential = new AzureKeyCredential("mockKey");
            Uri uri = new Uri("http://localhost");

            Assert.DoesNotThrow(() => new TelcoMessagingClient(uri, mockCredential));
        }

        [Test]
        public void TelcoMessagingClient_TokenCredential_NullOptions()
        {
            TokenCredential mockCredential = new MockCredential();
            Uri endpoint = new Uri("http://localhost");

            Assert.DoesNotThrow(() => new TelcoMessagingClient(endpoint, mockCredential, null));
        }

        [Test]
        public void TelcoMessagingClient_ThrowsWithNullOrEmptyConnectionString()
        {
            Assert.Throws<ArgumentException>(() => new TelcoMessagingClient(string.Empty));
            Assert.Throws<ArgumentNullException>(() => new TelcoMessagingClient(null));
        }

        [Test]
        public void TelcoMessagingClientOptions_ThrowsWithInvalidVersion()
        {
            var invalidServiceVersion = (TelcoMessagingClientOptions.ServiceVersion)99;

            Assert.Throws<ArgumentOutOfRangeException>(() => new TelcoMessagingClientOptions(invalidServiceVersion));
        }

        [Test]
        public void TelcoMessagingClient_InitializesSubClients_SingleArgConstructor()
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString);

            Assert.NotNull(telcoClient.Sms);
            Assert.NotNull(telcoClient.OptOuts);
            Assert.NotNull(telcoClient.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_InitializesSubClients_TwoArgConstructor()
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString, new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07));

            Assert.NotNull(telcoClient.Sms);
            Assert.NotNull(telcoClient.OptOuts);
            Assert.NotNull(telcoClient.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_InitializesSubClients_ThreeArgConstructor()
        {
            AzureKeyCredential mockCredential = new AzureKeyCredential("mockKey");
            Uri endpoint = new Uri("http://localhost");
            var telcoClient = new TelcoMessagingClient(endpoint, mockCredential, new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07));

            Assert.NotNull(telcoClient.Sms);
            Assert.NotNull(telcoClient.OptOuts);
            Assert.NotNull(telcoClient.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_InitializesSubClients_ThreeArgConstructor_WithTokenCredential()
        {
            TokenCredential mockCredential = new MockCredential();
            Uri endpoint = new Uri("http://localhost");
            var telcoClient = new TelcoMessagingClient(endpoint, mockCredential, new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07));

            Assert.NotNull(telcoClient.Sms);
            Assert.NotNull(telcoClient.OptOuts);
            Assert.NotNull(telcoClient.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_SubClientsAreNotNull_AllConstructors()
        {
            // Test connection string constructor
            var client1 = new TelcoMessagingClient(TestConnectionString);
            Assert.NotNull(client1.Sms);
            Assert.NotNull(client1.OptOuts);
            Assert.NotNull(client1.DeliveryReports);

            // Test connection string + options constructor
            var client2 = new TelcoMessagingClient(TestConnectionString, new TelcoMessagingClientOptions());
            Assert.NotNull(client2.Sms);
            Assert.NotNull(client2.OptOuts);
            Assert.NotNull(client2.DeliveryReports);

            // Test endpoint + key credential constructor
            AzureKeyCredential keyCredential = new AzureKeyCredential("mockKey");
            Uri endpoint = new Uri("http://localhost");
            var client3 = new TelcoMessagingClient(endpoint, keyCredential);
            Assert.NotNull(client3.Sms);
            Assert.NotNull(client3.OptOuts);
            Assert.NotNull(client3.DeliveryReports);

            // Test endpoint + token credential constructor
            TokenCredential tokenCredential = new MockCredential();
            var client4 = new TelcoMessagingClient(endpoint, tokenCredential);
            Assert.NotNull(client4.Sms);
            Assert.NotNull(client4.OptOuts);
            Assert.NotNull(client4.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClientOptions_ValidServiceVersions()
        {
            // Test each valid service version
            Assert.DoesNotThrow(() => new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07));
            Assert.DoesNotThrow(() => new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2025_08_01_Preview));
        }

        [Test]
        public void TelcoMessagingClientOptions_CorrectApiVersionMapping()
        {
            var options1 = new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07);
            Assert.AreEqual("2021-03-07", options1.ApiVersion);

            var options2 = new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2025_08_01_Preview);
            Assert.AreEqual("2025-08-01-preview", options2.ApiVersion);
        }

        [Test]
        public void TelcoMessagingClient_UsesLatestApiVersionByDefault()
        {
            var options = new TelcoMessagingClientOptions();
            Assert.AreEqual("2025-08-01-preview", options.ApiVersion);
        }

        [Test]
        public void TelcoMessagingClient_SubClientTypes_CorrectTypes()
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString);

            Assert.IsInstanceOf<SmsSubClient>(telcoClient.Sms);
            Assert.IsInstanceOf<OptOutsClient>(telcoClient.OptOuts);
            Assert.IsInstanceOf<DeliveryReportsClient>(telcoClient.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_WithConnectionStringOptions_SameSubClients()
        {
            var options = new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07);
            var telcoClient1 = new TelcoMessagingClient(TestConnectionString, options);
            var telcoClient2 = new TelcoMessagingClient(TestConnectionString, options);

            // Each client should have its own instances
            Assert.AreNotSame(telcoClient1.Sms, telcoClient2.Sms);
            Assert.AreNotSame(telcoClient1.OptOuts, telcoClient2.OptOuts);
            Assert.AreNotSame(telcoClient1.DeliveryReports, telcoClient2.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_WithKeyCredentialOptions_SameSubClients()
        {
            AzureKeyCredential keyCredential = new AzureKeyCredential("mockKey");
            Uri endpoint = new Uri("http://localhost");
            var options = new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07);

            var telcoClient1 = new TelcoMessagingClient(endpoint, keyCredential, options);
            var telcoClient2 = new TelcoMessagingClient(endpoint, keyCredential, options);

            // Each client should have its own instances
            Assert.AreNotSame(telcoClient1.Sms, telcoClient2.Sms);
            Assert.AreNotSame(telcoClient1.OptOuts, telcoClient2.OptOuts);
            Assert.AreNotSame(telcoClient1.DeliveryReports, telcoClient2.DeliveryReports);
        }

        [Test]
        public void TelcoMessagingClient_WithTokenCredentialOptions_SameSubClients()
        {
            TokenCredential tokenCredential = new MockCredential();
            Uri endpoint = new Uri("http://localhost");
            var options = new TelcoMessagingClientOptions(TelcoMessagingClientOptions.ServiceVersion.V2021_03_07);

            var telcoClient1 = new TelcoMessagingClient(endpoint, tokenCredential, options);
            var telcoClient2 = new TelcoMessagingClient(endpoint, tokenCredential, options);

            // Each client should have its own instances
            Assert.AreNotSame(telcoClient1.Sms, telcoClient2.Sms);
            Assert.AreNotSame(telcoClient1.OptOuts, telcoClient2.OptOuts);
            Assert.AreNotSame(telcoClient1.DeliveryReports, telcoClient2.DeliveryReports);
        }

        [TestCaseSource(nameof(TestDataForSingleSms))]
        public async Task SmsSubClient_SendAsyncOverload_PassesToGeneratedOne(string expectedFrom, string expectedTo, string expectedMessage, SmsSendOptions expectedOptions)
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString);
            Mock<SmsSubClient> mockSmsClient = new Mock<SmsSubClient>() { CallBase = true };
            Response<SmsSendResult>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SmsSendOptions>(), It.IsAny<CancellationToken>()));

            mockSmsClient
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

            Response<SmsSendResult> actualResponse = await mockSmsClient.Object.SendAsync(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockSmsClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestDataForSingleSms))]
        public void SmsSubClient_SendOverload_PassesToGeneratedOne(string expectedFrom, string expectedTo, string expectedMessage, SmsSendOptions expectedOptions)
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString);
            Mock<SmsSubClient> mockSmsClient = new Mock<SmsSubClient>() { CallBase = true };
            Response<SmsSendResult>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SmsSendOptions>(), It.IsAny<CancellationToken>()));

            mockSmsClient
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

            Response<SmsSendResult> actualResponse = mockSmsClient.Object.Send(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockSmsClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestDataForMultipleSms))]
        public async Task SmsSubClient_SendAsyncOverload_MultipleRecipients_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo, string expectedMessage, SmsSendOptions expectedOptions)
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString);
            Mock<SmsSubClient> mockSmsClient = new Mock<SmsSubClient>() { CallBase = true };
            Response<IReadOnlyList<SmsSendResult>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpressionForMultiple(x => x.SendAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<string>(), It.IsAny<SmsSendOptions>(), It.IsAny<CancellationToken>()));

            mockSmsClient
                .Setup(callExpression)
                .ReturnsAsync((string from, IEnumerable<string> to, string message, SmsSendOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.IsTrue(expectedTo.SequenceEqual(to));
                    Assert.AreEqual(expectedMessage, message);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<IReadOnlyList<SmsSendResult>>>().Object;
                });

            Response<IReadOnlyList<SmsSendResult>> actualResponse = await mockSmsClient.Object.SendAsync(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockSmsClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestDataForMultipleSms))]
        public void SmsSubClient_SendOverload_MultipleRecipients_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo, string expectedMessage, SmsSendOptions expectedOptions)
        {
            var telcoClient = new TelcoMessagingClient(TestConnectionString);
            Mock<SmsSubClient> mockSmsClient = new Mock<SmsSubClient>() { CallBase = true };
            Response<IReadOnlyList<SmsSendResult>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpressionForMultiple(x => x.Send(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<string>(), It.IsAny<SmsSendOptions>(), It.IsAny<CancellationToken>()));

            mockSmsClient
                .Setup(callExpression)
                .Returns((string from, IEnumerable<string> to, string message, SmsSendOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.IsTrue(expectedTo.SequenceEqual(to));
                    Assert.AreEqual(expectedMessage, message);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<IReadOnlyList<SmsSendResult>>>().Object;
                });

            Response<IReadOnlyList<SmsSendResult>> actualResponse = mockSmsClient.Object.Send(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockSmsClient.Verify(callExpression, Times.Once());
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

        private static IEnumerable<object?[]> TestDataForMultipleSms()
        {
            SmsSendOptions?[] optionsCombinations = new[]
            {
                new SmsSendOptions(enableDeliveryReport: true) { Tag = "custom-tag" },
                new SmsSendOptions(enableDeliveryReport: true) { Tag = null },
                null,
            };

            string[] recipients = new[] { "+14255550234", "+14255550345" };

            return optionsCombinations
                .Select(sendOptions => new object?[] { "+14255550123", recipients, "Hello 👋", sendOptions });
        }

        private static Expression<Func<SmsSubClient, TResult>> BuildExpression<TResult>(Expression<Func<SmsSubClient, TResult>> expression)
            => expression;

        private static Expression<Func<SmsSubClient, TResult>> BuildExpressionForMultiple<TResult>(Expression<Func<SmsSubClient, TResult>> expression)
            => expression;
    }
}

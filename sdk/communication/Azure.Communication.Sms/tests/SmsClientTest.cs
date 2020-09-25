// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientTest
    {

        [TestCaseSource(nameof(TestData))]
        public async Task SendSmsAsyncOverload_PassesToGeneratedOne(PhoneNumber expectedFrom, PhoneNumber expectedTo, string expectedMessage, SendSmsOptions expectedOptions)
        {
            Mock<SmsClient> mockClient = new Mock<SmsClient>() { CallBase = true };
            Response<SendSmsResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.SendAsync(It.IsAny<PhoneNumber>(), It.IsAny<IEnumerable<PhoneNumber>>(), It.IsAny<string>(), It.IsAny<SendSmsOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((PhoneNumber from, IEnumerable<PhoneNumber> to, string message, SendSmsOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to.Single());
                    Assert.AreEqual(expectedMessage, message);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<SendSmsResponse>>().Object;
                });

            Response<SendSmsResponse> actualResponse = await mockClient.Object.SendAsync(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public void SendSmsOverload_PassesToGeneratedOne(PhoneNumber expectedFrom, PhoneNumber expectedTo, string expectedMessage, SendSmsOptions expectedOptions)
        {
            Mock<SmsClient> mockClient = new Mock<SmsClient>() { CallBase = true };
            Response<SendSmsResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.Send(It.IsAny<PhoneNumber>(), It.IsAny<IEnumerable<PhoneNumber>>(), It.IsAny<string>(), It.IsAny<SendSmsOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .Returns((PhoneNumber from, IEnumerable<PhoneNumber> to, string message, SendSmsOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to.Single());
                    Assert.AreEqual(expectedMessage, message);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<SendSmsResponse>>().Object;
                });

            Response<SendSmsResponse> actualResponse = mockClient.Object.Send(expectedFrom, expectedTo, expectedMessage, expectedOptions, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        private static IEnumerable<object?[]> TestData()
        {
            SendSmsOptions?[] optionsCombinations = new[]
            {
                new SendSmsOptions { EnableDeliveryReport = true },
                new SendSmsOptions { EnableDeliveryReport = false },
                new SendSmsOptions { EnableDeliveryReport = null },
                null,
            };

            return optionsCombinations
                .Select(sendOptions => new object?[] { new PhoneNumber("+18001230000"), new PhoneNumber("+18005670000"), "Hello 👋", sendOptions });
        }

        private static Expression<Func<SmsClient, TResult>> BuildExpression<TResult>(Expression<Func<SmsClient, TResult>> expression)
            => expression;
    }
}

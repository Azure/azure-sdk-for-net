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

namespace Azure.Communication.Calling.Server.Tests
{
    public class CallClientTest
    {
        [TestCaseSource(nameof(TestData))]
        public async Task CreateCallAsyncOverload_PassesToGeneratedOne(CommunicationIdentifier expectedSource, IEnumerable<CommunicationIdentifier> expectedTargets, CreateCallOptions expectedOptions)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response<CreateCallResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.CreateCallAsync(It.IsAny<CommunicationIdentifier>(), It.IsAny<IEnumerable<CommunicationIdentifier>>(), It.IsAny<CreateCallOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((CommunicationIdentifier source, CommunicationIdentifier to, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedSource, source);
                    Assert.AreEqual(expectedTargets, targets);
                    Assert.AreEqual(cancellationToken, token);
                    Assert.AreEqual(expectedOptions, options);
                    return expectedResponse = new Mock<Response<CreateCallResponse>>().Object;
                });

            Response<CreateCallResponse> actualResponse = await mockClient.Object.CreateCallAsync(expectedSource, expectedTargets, expectedOptions, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public void SendSmsOverload_PassesToGeneratedOne(string expectedCallLegId)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Task<Response> expectedResponse = new Mock<Task<Response>>().Object;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.DeleteCallAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .Returns((string callLegId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse;
                });

            Task<Response> actualResponse = mockClient.Object.DeleteCallAsync(expectedCallLegId);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        private static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>(){
                new object?[] {
                    new CommunicationUserIdentifier("50125645-5dca-4193-877d-4608ed2a0bc2"),
                    new PhoneNumberIdentifier("+14052882361"),
                    new CreateCallOptions(new Uri($"AppCallbackUrl"), new List<CallModality> { CallModality.Audio }, new List<EventSubscriptionType> { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived })
                },
            };
        }

        private static Expression<Func<CallClient, TResult>> BuildExpression<TResult>(Expression<Func<CallClient, TResult>> expression)
            => expression;
    }
}

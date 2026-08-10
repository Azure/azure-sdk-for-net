// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Amqp
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpReceiver" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpReceiverTests
    {
        /// <summary>
        ///   The set of test cases for respecting basic retry configuration.
        /// </summary>
        ///
        private static IEnumerable<object[]> RetryOptionTestCases()
        {
            yield return new object[] { new ServiceBusRetryOptions { MaxRetries = 3, Delay = TimeSpan.FromMilliseconds(1), MaxDelay = TimeSpan.FromMilliseconds(10), Mode = ServiceBusRetryMode.Fixed } };
            yield return new object[] { new ServiceBusRetryOptions { MaxRetries = 0, Delay = TimeSpan.FromMilliseconds(1), MaxDelay = TimeSpan.FromMilliseconds(10), Mode = ServiceBusRetryMode.Fixed } };
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresEntityName(string entityName)
        {
            Assert.That(() => new AmqpReceiver(
                entityPath: entityName,
                receiveMode: ServiceBusReceiveMode.PeekLock,
                prefetchCount: 0,
                connectionScope: Mock.Of<AmqpConnectionScope>(),
                retryPolicy: Mock.Of<ServiceBusRetryPolicy>(),
                identifier: "someIdentifier",
                sessionId: default,
                isSessionReceiver: default,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                cancellationToken: CancellationToken.None),
                Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresConnectionScope()
        {
            Assert.That(() => new AmqpReceiver(
                entityPath: "someQueue",
                receiveMode: ServiceBusReceiveMode.PeekLock,
                prefetchCount: 0,
                connectionScope: null,
                retryPolicy: Mock.Of<ServiceBusRetryPolicy>(),
                identifier: "someIdentifier",
                sessionId: default,
                isSessionReceiver: default,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                cancellationToken: CancellationToken.None),
            Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheRetryPolicy()
        {
            Assert.That(() => new AmqpReceiver(
                entityPath: "someQueue",
                receiveMode: ServiceBusReceiveMode.PeekLock,
                prefetchCount: 0,
                connectionScope: Mock.Of<AmqpConnectionScope>(),
                retryPolicy: null,
                identifier: "someIdentifier",
                sessionId: default,
                isSessionReceiver: default,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                cancellationToken: CancellationToken.None),
            Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheReceiverAsClosed()
        {
            var receiver = CreateReceiver();

            Assert.That(receiver.IsClosed, Is.False, "The receiver should not be closed on creation");

            await receiver.CloseAsync(CancellationToken.None);
            Assert.That(receiver.IsClosed, Is.True, "The receiver should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            AmqpReceiver receiver = CreateReceiver();

            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReceiveAsyncAppliesTheRetryPolicy(ServiceBusRetryOptions retryOptions)
        {
            var entityName = "entityName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new ServiceBusException(isTransient: true, "Test");
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();
            uint prefetchCount = 0;
            var sessionId = "sessionId";
            bool isSession = true;

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), cancellationToken: CancellationToken.None);
            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.GeneralError));

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaxRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReceiveAsyncConsidersOperationCanceledExceptionAsRetriable(ServiceBusRetryOptions retryOptions)
        {
            var entityName = "entityName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new OperationCanceledException();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();
            uint prefetchCount = 0;
            var sessionId = "sessionId";
            bool isSession = true;

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), cancellationToken: CancellationToken.None);
            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.ServiceTimeout));

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaxRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReceiveAsyncAppliesTheRetryPolicyForAmqpErrors(ServiceBusRetryOptions retryOptions)
        {
            var entityName = "entityName";
            var tokenValue = "123ABC";
            var mockLogger = new Mock<ServiceBusEventSource>();
            var retryPolicy = new BasicRetryPolicy(retryOptions)
            {
                Logger = mockLogger.Object
            };
            var retriableException = new Error
            {
                Condition = AmqpClientConstants.ServerBusyError.ToString()
            }.ToMessagingContractException();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();
            uint prefetchCount = 0;
            var sessionId = "sessionId";
            bool isSession = true;

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), cancellationToken: CancellationToken.None);
            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.ServiceBusy));
            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaxRetries));

            mockLogger
                .Verify(
                    log => log.RunOperationExceptionEncountered(It.IsAny<string>()),
                Times.Exactly(retryOptions.MaxRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var entityName = "entityName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions());
            var exception = new OperationCanceledException("", new ArgumentNullException());
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();
            uint prefetchCount = 0;
            var sessionId = "sessionId";
            bool isSession = true;

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), cancellationToken: CancellationToken.None);
            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<ArgumentNullException>());

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()),
                Times.Once());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var exception = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpClientConstants.ArgumentError }));
            var entityName = "entityName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions());
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();
            uint prefetchCount = 0;
            var sessionId = "sessionId";
            bool isSession = true;

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), cancellationToken: CancellationToken.None);
            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<ArgumentException>());

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<Guid?>(),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncDoesNotRetryOnTaskCanceled()
        {
            var exception = new TaskCanceledException();
            var entityName = "entityName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions());
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();
            uint prefetchCount = 0;
            var sessionId = "sessionId";
            bool isSession = true;

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ServiceBusReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<bool>(),
                   It.IsAny<Guid?>(),
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), cancellationToken: CancellationToken.None);
            Assert.That(async () => await receiver.ReceiveMessagesAsync(
                100,
                default,
                cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<Guid?>(),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        /// <summary>
        ///   Builds a management <see cref="AmqpResponseMessage"/> for the get-message-sessions
        ///   operation so the parsing branches can be exercised without a live AMQP round-trip.
        /// </summary>
        private static AmqpResponseMessage CreateGetSessionsResponse(
            AmqpResponseStatusCode statusCode,
            object sessionIdsValue = null,
            bool includeSessionIdsKey = true,
            bool omitMapBody = false,
            AmqpSymbol? errorCondition = null)
        {
            AmqpMessage message;
            if (omitMapBody)
            {
                // A non-map value body causes AmqpResponseMessage.Map to be null.
                message = AmqpMessage.Create(new AmqpValue { Value = "not-a-map" });
            }
            else
            {
                var body = new AmqpMap();
                if (includeSessionIdsKey)
                {
                    body[ManagementConstants.Properties.SessionIds] = sessionIdsValue;
                }
                message = AmqpMessage.Create(new AmqpValue { Value = body });
            }

            message.ApplicationProperties.Map[ManagementConstants.Response.StatusCode] = (int)statusCode;
            if (errorCondition.HasValue)
            {
                message.ApplicationProperties.Map[ManagementConstants.Response.ErrorCondition] = errorCondition.Value;
            }

            return AmqpResponseMessage.CreateResponse(message);
        }

        [Test]
        public void ParseGetMessageSessionsResponseReturnsSessionIdsFromStringArray()
        {
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new[] { "session-1", "session-2" });

            var result = AmqpReceiver.ParseGetMessageSessionsResponse(response);

            Assert.That(result, Is.EqualTo(new[] { "session-1", "session-2" }));
        }

        [Test]
        public void ParseGetMessageSessionsResponseReturnsSessionIdsFromObjectArray()
        {
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new object[] { "session-1", "session-2" });

            var result = AmqpReceiver.ParseGetMessageSessionsResponse(response);

            Assert.That(result, Is.EqualTo(new[] { "session-1", "session-2" }));
        }

        [Test]
        public void ParseGetMessageSessionsResponseReturnsEmptyForNoContent()
        {
            var response = CreateGetSessionsResponse(AmqpResponseStatusCode.NoContent);

            var result = AmqpReceiver.ParseGetMessageSessionsResponse(response);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseGetMessageSessionsResponseReturnsEmptyForMessageNotFound()
        {
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.NotFound,
                errorCondition: AmqpClientConstants.MessageNotFoundError);

            var result = AmqpReceiver.ParseGetMessageSessionsResponse(response);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseGetMessageSessionsResponseThrowsForMissingMapBody()
        {
            var response = CreateGetSessionsResponse(AmqpResponseStatusCode.OK, omitMapBody: true);

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>());
        }

        [Test]
        public void ParseGetMessageSessionsResponseThrowsForMissingSessionIdsKey()
        {
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, includeSessionIdsKey: false);

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>());
        }

        [Test]
        public void ParseGetMessageSessionsResponseThrowsForUnexpectedPayloadType()
        {
            var response = CreateGetSessionsResponse(AmqpResponseStatusCode.OK, sessionIdsValue: 42);

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>());
        }

        [Test]
        public void ParseGetMessageSessionsResponseReturnsEmptySessionIdInStringArray()
        {
            // Empty string is a valid session id and must be returned, not rejected by the parser.
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new[] { "session-1", "" });

            var result = AmqpReceiver.ParseGetMessageSessionsResponse(response);

            Assert.That(result, Is.EqualTo(new[] { "session-1", "" }));
        }

        [Test]
        public void ParseGetMessageSessionsResponseReturnsEmptySessionIdInObjectArray()
        {
            // Empty string is a valid session id and must be returned, not rejected.
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new object[] { "session-1", "" });

            var result = AmqpReceiver.ParseGetMessageSessionsResponse(response);

            Assert.That(result, Is.EqualTo(new[] { "session-1", "" }));
        }

        [Test]
        public void ParseGetMessageSessionsResponseThrowsForNonStringInObjectArray()
        {
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new object[] { "session-1", 5 });

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>());
        }

        [Test]
        public void ParseGetMessageSessionsResponseReportsAllNullIndexesInStringArray()
        {
            // Null entries at indexes 0 and 2 are invalid: the parser must finish iterating and
            // report both. The empty string at index 1 is valid and must not be flagged.
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new string[] { null, "", null });

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>()
                    .With.Message.Contains("index 0 was null")
                    .And.Message.Contains("index 2 was null"));
        }

        [Test]
        public void ParseGetMessageSessionsResponseReportsAllInvalidIndexesInObjectArray()
        {
            // Invalid entries at indexes 0 (null) and 2 (non-string): the parser must finish
            // iterating and report both, including the offending type. The empty string at index 1
            // is valid and must not be flagged.
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.OK, new object[] { null, "", 5 });

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>()
                    .With.Message.Contains("index 0 was null")
                    .And.Message.Contains("index 2").And.Message.Contains("Int32"));
        }

        [Test]
        public void ParseGetMessageSessionsResponseThrowsForNotFoundWithoutMessageNotFound()
        {
            var response = CreateGetSessionsResponse(
                AmqpResponseStatusCode.NotFound,
                errorCondition: new AmqpSymbol("com.microsoft:entity-not-found"));

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>());
        }

        [Test]
        public void ParseGetMessageSessionsResponseThrowsForOtherStatusCode()
        {
            var response = CreateGetSessionsResponse(AmqpResponseStatusCode.InternalServerError);

            Assert.That(
                () => AmqpReceiver.ParseGetMessageSessionsResponse(response),
                Throws.InstanceOf<ServiceBusException>());
        }

        private AmqpReceiver CreateReceiver() =>
            new AmqpReceiver(
                "someQueue",
                ServiceBusReceiveMode.PeekLock,
                0,
                Mock.Of<AmqpConnectionScope>(),
                Mock.Of<ServiceBusRetryPolicy>(),
                "someIdentifier",
                default,
                default,
                false,
                Mock.Of<AmqpMessageConverter>(),
                cancellationToken: default);

        /// <summary>
        ///   Verifies the fail-loudly backstop: a non-exclusive session receiver whose endpoint returns a link
        ///   without an assigned session lock token throws <see cref="NotSupportedException" /> rather than silently
        ///   degrading (the endpoint does not support non-exclusive session locking).
        /// </summary>
        ///
        [Test]
        public void OpenReceiverLinkThrowsNotSupportedWhenNonExclusiveSessionLacksToken()
        {
            var mockScope = AmqpConnectionScopeTests.CreateMockReceiverScope();
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { MaxRetries = 0, TryTimeout = TimeSpan.FromSeconds(10) });

            // The mock builds a real link via CreateReceivingLinkAsync, whose attach response carries no
            // non-exclusive session filter, so the receiver reads no assigned token and the backstop fires.
            // sessionId is left null only to reach that path; the backstop itself is independent of which
            // session is accepted.
            var receiver = new AmqpReceiver(
                "fake/path",
                ServiceBusReceiveMode.PeekLock,
                0,
                mockScope.Object,
                retryPolicy,
                "someIdentifier",
                sessionId: null,
                isSessionReceiver: true,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                isSessionExclusive: false,
                sessionLockToken: null,
                cancellationToken: CancellationToken.None);

            Assert.That(async () => await receiver.OpenLinkAsync(CancellationToken.None),
                Throws.InstanceOf<NotSupportedException>().And.Message.EqualTo(Resources.NonExclusiveSessionModeNotSupported));
        }

        /// <summary>
        ///   Verifies that the token the caller supplied to take a session over is handed to the connection scope,
        ///   which is what puts it into the outbound composite filter. Without this, the receiver could silently drop
        ///   the token and every other test would still pass, because the tests that observe the resulting attach are
        ///   driven by the scope directly rather than through the receiver.
        /// </summary>
        ///
        [Test]
        public void OpenLinkPresentsTheSuppliedSessionLockTokenToTheScope()
        {
            var presentedToken = Guid.NewGuid();
            var mockScope = AmqpConnectionScopeTests.CreateMockReceiverScope(presentedToken);
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { MaxRetries = 0, TryTimeout = TimeSpan.FromSeconds(10) });

            var receiver = new AmqpReceiver(
                "fake/path",
                ServiceBusReceiveMode.PeekLock,
                0,
                mockScope.Object,
                retryPolicy,
                "someIdentifier",
                sessionId: "sessionId",
                isSessionReceiver: true,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                isSessionExclusive: false,
                sessionLockToken: presentedToken,
                cancellationToken: CancellationToken.None);

            // The mock link carries no session-locked-until property, so the open faults once the link is returned.
            // That is a precondition rather than the assertion; the hop under test has already happened by then, and
            // the verification below is what discriminates.
            Assert.That(async () => await receiver.OpenLinkAsync(CancellationToken.None), Throws.Exception);

            mockScope.Verify(scope => scope.OpenReceiverLinkAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan>(),
                It.IsAny<uint>(),
                It.IsAny<ServiceBusReceiveMode>(),
                It.IsAny<string>(),
                It.IsAny<bool>(),
                It.IsAny<bool>(),
                presentedToken,
                It.IsAny<CancellationToken>()),
                Times.Once,
                "The token supplied for takeover must be handed to the scope so it reaches the outbound filter.");
        }

        /// <summary>
        ///   Verifies that when the service honors a non-exclusive session, the receiver surfaces the assigned lock
        ///   token through its SessionLockToken and does not trip the fail-loudly backstop. The token arrives in the
        ///   composite non-exclusive session filter echoed back on the attach response, carried as an AMQP uuid
        ///   (<see cref="System.Guid" />).
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkSurfacesAssignedTokenForNonExclusiveSession()
        {
            var assignedToken = Guid.NewGuid();
            var mockScope = AmqpConnectionScopeTests.CreateMockReceiverScope(assignedToken);
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { MaxRetries = 0, TryTimeout = TimeSpan.FromSeconds(10) });

            var receiver = new AmqpReceiver(
                "fake/path",
                ServiceBusReceiveMode.PeekLock,
                0,
                mockScope.Object,
                retryPolicy,
                "someIdentifier",
                sessionId: null,
                isSessionReceiver: true,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                isSessionExclusive: false,
                sessionLockToken: null,
                cancellationToken: CancellationToken.None);

            Assert.That(async () => await receiver.OpenLinkAsync(CancellationToken.None), Throws.Nothing);
            Assert.That(receiver.SessionLockToken, Is.EqualTo(assignedToken), "The assigned token should be surfaced on the receiver.");
            Assert.That(receiver.SessionId, Is.EqualTo("sessionId"), "The session id echoed in the session filter should be surfaced on the receiver.");
        }

        /// <summary>
        ///   Verifies that a non-exclusive session receiver settles over the management link rather than the receive
        ///   link. A non-exclusive session can be taken over, after which the current holder settles messages that were
        ///   delivered to the previous holder's link, so they have no delivery on its own link. Routing every
        ///   disposition over the management link is what keeps settlement working across a takeover.
        /// </summary>
        ///
        [Test]
        [TestCase(SettleOperation.Complete)]
        [TestCase(SettleOperation.Abandon)]
        [TestCase(SettleOperation.Defer)]
        [TestCase(SettleOperation.DeadLetter)]
        public async Task NonExclusiveSessionSettlesOverTheManagementLink(SettleOperation operation)
        {
            var assignedToken = Guid.NewGuid();
            var mockScope = AmqpConnectionScopeTests.CreateMockReceiverScope(assignedToken);
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { MaxRetries = 0, TryTimeout = TimeSpan.FromSeconds(5) });

            // The management link is never reachable here; the assertion is on whether the receiver reaches for it at
            // all, which is what the routing decision determines.
            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("management link reached"));

            var receiver = new AmqpReceiver(
                "fake/path",
                ServiceBusReceiveMode.PeekLock,
                0,
                mockScope.Object,
                retryPolicy,
                "someIdentifier",
                sessionId: null,
                isSessionReceiver: true,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                isSessionExclusive: false,
                sessionLockToken: null,
                cancellationToken: CancellationToken.None);

            await receiver.OpenLinkAsync(CancellationToken.None);

            Assert.That(receiver.IsSessionExclusive, Is.False, "The receiver should report the non-exclusive mode it was created with.");
            Assert.That(receiver.SessionLockToken, Is.EqualTo(assignedToken), "The receiver should surface the token the service assigned, which is what ServiceBusSessionReceiver reports as a string.");

            Assert.That(async () => await SettleAsync(receiver, operation),
                Throws.Exception, $"{operation} should fail, because the mocked management link is unreachable.");

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()),
                Times.AtLeastOnce(),
                $"A non-exclusive session receiver should settle {operation} over the management link.");
        }

        /// <summary>
        ///   The settle operations that <c>UseRequestResponseDisposition</c> routes. Each carries its own copy of the
        ///   guard, so a single-site regression would ship green if only one were exercised.
        /// </summary>
        ///
        public enum SettleOperation
        {
            Complete,
            Abandon,
            Defer,
            DeadLetter
        }

        private static Task SettleAsync(AmqpReceiver receiver, SettleOperation operation) => operation switch
        {
            SettleOperation.Complete => receiver.CompleteAsync(Guid.NewGuid(), CancellationToken.None),
            SettleOperation.Abandon => receiver.AbandonAsync(Guid.NewGuid(), null, CancellationToken.None),
            SettleOperation.Defer => receiver.DeferAsync(Guid.NewGuid(), null, CancellationToken.None),
            SettleOperation.DeadLetter => receiver.DeadLetterAsync(Guid.NewGuid(), "reason", "description", null, CancellationToken.None),
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };

        /// <summary>
        ///   Verifies the other half of the routing decision: an exclusive session receiver settles over its own
        ///   receive link and never reaches for the management link, which is the behavior that predates non-exclusive
        ///   session locking and must stay unchanged.
        /// </summary>
        ///
        [Test]
        [TestCase(SettleOperation.Complete)]
        [TestCase(SettleOperation.Abandon)]
        [TestCase(SettleOperation.Defer)]
        [TestCase(SettleOperation.DeadLetter)]
        public void ExclusiveSessionDoesNotSettleOverTheManagementLink(SettleOperation operation)
        {
            var mockScope = AmqpConnectionScopeTests.CreateMockReceiverScope();
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { MaxRetries = 0, TryTimeout = TimeSpan.FromSeconds(5) });

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("management link reached"));

            var receiver = new AmqpReceiver(
                "fake/path",
                ServiceBusReceiveMode.PeekLock,
                0,
                mockScope.Object,
                retryPolicy,
                "someIdentifier",
                sessionId: "sessionId",
                isSessionReceiver: true,
                isProcessor: false,
                messageConverter: Mock.Of<AmqpMessageConverter>(),
                cancellationToken: CancellationToken.None);

            Assert.That(receiver.IsSessionExclusive, Is.True, "A receiver created without the non-exclusive option should report the exclusive mode.");
            Assert.That(receiver.SessionLockToken, Is.Null, "An exclusive session carries no lock token, so ServiceBusSessionReceiver reports null rather than a string.");

            // The link is deliberately not opened. The routing decision is made before any link is used, so settling
            // fails either way; the assertion is on which link the receiver reaches for. Were the decision made on
            // "is a session receiver" alone, an exclusive receiver would reach the management link and fail this.
            Assert.That(async () => await SettleAsync(receiver, operation),
                Throws.Exception, $"{operation} should fail, because the mocked receive link cannot settle.");

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()),
                Times.Never(),
                $"An exclusive session receiver should settle {operation} over its receive link.");
        }
    }
}

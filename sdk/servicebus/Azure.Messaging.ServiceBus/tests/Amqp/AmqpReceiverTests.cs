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
        ///   Verifies that <see cref="AmqpReceiver.CloseAsync" /> completes normally under an already-canceled
        ///   token when no links were ever opened. Both cancellation checks deliberately sit inside the link
        ///   guards, so a receiver with nothing to tear down has no work to cancel and closes.
        ///
        ///   This is an intentional asymmetry with <c>AmqpSender.CloseAsync</c>, which checks the token
        ///   unconditionally before inspecting its links. Hoisting a check to the top of this method to
        ///   "complete the mirroring" would break this test, which is the point of pinning it.
        /// </summary>
        ///
        [Test]
        public void CloseWithCanceledTokenCompletesWhenNoLinksAreOpen()
        {
            var receiver = CreateReceiver();
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await receiver.CloseAsync(cancellationSource.Token),
                Throws.Nothing,
                "A receiver with no opened links has no work to cancel and should close.");

            Assert.That(receiver.IsClosed, Is.True,
                "The receiver should be marked as closed after a close that ran to completion.");

            Assert.That(receiver.RequestResponseLockedMessages.IsDisposed, Is.True,
                "A close that ran to completion should dispose the set of locked messages.");
        }

        /// <summary>
        ///   Verifies that a later <see cref="AmqpReceiver.CloseAsync" /> cannot resurrect a receiver that is
        ///   already closed: a caller that does not own the close returns through the guard rather than reaching
        ///   the restore in the catch, so the flag and the disposed set both survive.
        ///
        ///   This pins the invariant, not the race. It closes sequentially, so it would also pass the former
        ///   non-atomic implementation; the interleaving it describes needs two callers inside the claim window
        ///   at once, which is why the claim is made with <see cref="Interlocked" />. That interleaving is not
        ///   deterministically reproducible in a unit test.
        /// </summary>
        ///
        [Test]
        public async Task CloseWithCanceledTokenDoesNotReopenAnAlreadyClosedReceiver()
        {
            var receiver = CreateReceiver();
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            await receiver.CloseAsync(CancellationToken.None);

            Assert.That(async () => await receiver.CloseAsync(cancellationSource.Token),
                Throws.Nothing,
                "A close of an already-closed receiver should return through the guard rather than throw.");

            Assert.That(receiver.IsClosed, Is.True,
                "A canceled close must not clear the closed flag of a receiver that was already closed.");

            Assert.That(receiver.RequestResponseLockedMessages.IsDisposed, Is.True,
                "The set of locked messages must stay disposed once the close has completed.");
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
        ///   Verifies that an endpoint which refuses the composite filter it does not recognize surfaces the same
        ///   <see cref="NotSupportedException" /> as the missing-token backstop. An endpoint without non-exclusive
        ///   session locking declines this way rather than honoring the attach, so this is the path a caller meets
        ///   first, and both paths mean the endpoint does not offer the feature. Both the fresh attach and the
        ///   takeover attach send the filter, so both are covered.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void OpenReceiverLinkThrowsNotSupportedWhenEndpointRefusesTheNonExclusiveFilter(bool takingSessionOver)
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.NotAllowed,
                Description = "The link 'abc' contains invalid filter type. System only support Jms or Apache selector filter type."
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false, takingSessionOver: takingSessionOver);

            Assert.That(async () => await receiver.OpenLinkAsync(CancellationToken.None),
                Throws.InstanceOf<NotSupportedException>()
                    .And.Message.EqualTo(Resources.NonExclusiveSessionModeNotSupported)
                    .And.InnerException.SameAs(attachFailure),
                "The refusal should be reported as an unsupported feature, keeping the original error for diagnostics.");
        }

        /// <summary>
        ///   Verifies that a refusal which is not about the filter keeps its own exception. The condition is a
        ///   general refusal rather than one reserved for the filter, so matching on it alone would report an
        ///   unrelated problem as a missing feature. The description below stands for any other refusal that
        ///   condition carries, rather than a wording the endpoint is known to send.
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkPreservesRefusalsUnrelatedToTheNonExclusiveFilter()
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.NotAllowed,
                Description = "The link 'abc' reports a problem of its own."
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false);
            var thrown = await CaptureOpenLinkFailure(receiver);

            Assert.That(thrown, Is.Not.Null, "The attach failure should surface to the caller.");
            Assert.That(thrown, Is.InstanceOf<InvalidOperationException>(), "A refusal that does not name the filter should keep the exception its condition maps to.");
            Assert.That(thrown.Message, Does.Contain("reports a problem of its own"), "The endpoint's own description should reach the caller.");
        }

        /// <summary>
        ///   Verifies that a refusal carrying no description keeps its own exception, rather than the description
        ///   check faulting on the missing text.
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkPreservesRefusalsThatCarryNoDescription()
        {
            var attachFailure = new AmqpException(new Error { Condition = AmqpErrorCode.NotAllowed });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false);
            var thrown = await CaptureOpenLinkFailure(receiver);

            Assert.That(thrown, Is.InstanceOf<InvalidOperationException>(), "A refusal with no description should keep the exception its condition maps to.");
            Assert.That(thrown, Is.Not.InstanceOf<NotSupportedException>(), "A refusal with no description should not be read as the endpoint declining the filter.");
        }

        /// <summary>
        ///   Verifies that the session id a caller chooses cannot make an unrelated refusal look like the endpoint
        ///   declining the filter. The description carries the link name in quotes, and that name renders the
        ///   session id, so a session id repeating the text the match looks for would otherwise be enough. A session
        ///   id carrying quotes of its own is covered too, since the quotes are what frame the name.
        /// </summary>
        ///
        [Test]
        [TestCase("contains invalid filter type")]
        [TestCase("x' contains invalid filter type '")]
        [TestCase("'invalid filter type'")]
        public async Task OpenReceiverLinkIgnoresTheMatchedTextWhenItComesFromTheSessionId(string sessionId)
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.NotAllowed,
                Description = $"The link 'sb://mine/queue:session-id:{sessionId}' reports a problem of its own."
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false);
            var thrown = await CaptureOpenLinkFailure(receiver);

            Assert.That(thrown, Is.InstanceOf<InvalidOperationException>(), "Text supplied by the caller should not be read as the endpoint declining the filter.");
            Assert.That(thrown, Is.Not.InstanceOf<NotSupportedException>(), "A session id repeating the matched text should not report the feature as unavailable.");
        }

        /// <summary>
        ///   Verifies that a session id carrying an apostrophe still lets a genuine refusal be recognized. An
        ///   apostrophe is legal in a session id and appears in the quoted link name, so a search framed on matched
        ///   quote pairs would stop inside the name and leave the endpoint's own text unread. The search begins after
        ///   the final quote, which the name's closing quote supplies however many quotes the session id holds.
        /// </summary>
        ///
        [Test]
        [TestCase("o'brien-order")]
        [TestCase("tenant's-queue")]
        [TestCase("a'b'c'd")]
        public void OpenReceiverLinkRecognizesTheRefusalWhenTheSessionIdCarriesAnApostrophe(string sessionId)
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.NotAllowed,
                Description = $"The link 'sb://mine/queue:session-id:{sessionId}' contains invalid filter type. System only support Jms or Apache selector filter type."
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false);

            Assert.That(async () => await receiver.OpenLinkAsync(CancellationToken.None),
                Throws.InstanceOf<NotSupportedException>()
                    .And.Message.EqualTo(Resources.NonExclusiveSessionModeNotSupported),
                "A session id containing an apostrophe should not keep the endpoint's refusal from being recognized.");
        }

        /// <summary>
        ///   Verifies that the refusal is recognized by its condition as well as its description. The description
        ///   alone would report any error whose text happens to name a filter as the feature being unavailable.
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkPreservesFilterTextCarriedByAnotherCondition()
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.InternalError,
                Description = "The link 'abc' contains invalid filter type. System only support Jms or Apache selector filter type."
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false);
            var thrown = await CaptureOpenLinkFailure(receiver);

            Assert.That(thrown, Is.Not.Null, "The attach failure should surface to the caller.");
            Assert.That(thrown, Is.Not.InstanceOf<NotSupportedException>(), "A refusal carrying another condition should keep the exception that condition maps to.");
        }

        /// <summary>
        ///   Verifies the shapes a description can take around the quoted link name. A description with no quote is
        ///   not the refusal being looked for, and searching it whole would put the session id back within reach; a
        ///   quote after the filter text begins the search past it, so a reworded refusal reports its own exception
        ///   rather than the feature being unavailable.
        /// </summary>
        ///
        [Test]
        [TestCase("contains invalid filter type with no quoted link name", TestName = "OpenReceiverLinkLeavesAnUnquotedDescriptionAlone")]
        [TestCase("The link 'abc' contains invalid filter type. Support 'Jms' or 'Apache'.", TestName = "OpenReceiverLinkLeavesARefusalQuotingItsOwnTailAlone")]
        [TestCase("The link 'abc'", TestName = "OpenReceiverLinkLeavesADescriptionEndingInAQuoteAlone")]
        public async Task OpenReceiverLinkOnlyReadsTheTextAfterTheQuotedLinkName(string description)
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.NotAllowed,
                Description = description
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: false);
            var thrown = await CaptureOpenLinkFailure(receiver);

            Assert.That(thrown, Is.Not.Null, "The attach failure should surface to the caller.");
            Assert.That(thrown, Is.InstanceOf<InvalidOperationException>(), "Only the text after the quoted link name identifies the refusal, so these keep the exception the condition maps to.");
        }

        /// <summary>
        ///   Verifies that an exclusive session receiver is unaffected by the translation. An exclusive receiver
        ///   never sends the composite filter, so a refusal naming a filter came from something else and reporting
        ///   it as a non-exclusive feature gap would be misleading.
        /// </summary>
        ///
        [Test]
        public async Task OpenReceiverLinkLeavesFilterRefusalsAloneForExclusiveSessions()
        {
            var attachFailure = new AmqpException(new Error
            {
                Condition = AmqpErrorCode.NotAllowed,
                Description = "The link 'abc' contains invalid filter type. System only support Jms or Apache selector filter type."
            });

            var receiver = CreateReceiverForAttachFailure(attachFailure, isSessionExclusive: true);
            var thrown = await CaptureOpenLinkFailure(receiver);

            Assert.That(thrown, Is.InstanceOf<InvalidOperationException>(), "An exclusive session receiver should keep the exception the refusal's condition maps to.");
            Assert.That(thrown.Message, Does.Contain("invalid filter type"), "The endpoint's own description should reach the caller.");
        }

        /// <summary>
        ///   Opens the receiver's link and returns the exception it failed with, or <c>null</c> when it succeeded.
        /// </summary>
        ///
        /// <param name="receiver">The receiver whose link should be opened.</param>
        ///
        /// <returns>The exception the link open failed with, or <c>null</c> when it succeeded.</returns>
        ///
        private static async Task<Exception> CaptureOpenLinkFailure(AmqpReceiver receiver)
        {
            try
            {
                await receiver.OpenLinkAsync(CancellationToken.None);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        /// <summary>
        ///   Builds a session receiver whose scope fails the attach with the requested exception.
        /// </summary>
        ///
        /// <param name="attachFailure">The exception the attach should fail with.</param>
        /// <param name="isSessionExclusive">Whether the receiver requests an exclusive session.</param>
        /// <param name="takingSessionOver">Whether a non-exclusive receiver presents a token to take a session over, rather than accepting one fresh.</param>
        ///
        /// <returns>A receiver whose link open reaches <paramref name="attachFailure"/>.</returns>
        ///
        private static AmqpReceiver CreateReceiverForAttachFailure(
            Exception attachFailure,
            bool isSessionExclusive,
            bool takingSessionOver = true)
        {
            var mockScope = AmqpConnectionScopeTests.CreateMockReceiverScope(attachFailure: attachFailure);
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { MaxRetries = 0, TryTimeout = TimeSpan.FromSeconds(10) });

            return new AmqpReceiver(
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
                isSessionExclusive: isSessionExclusive,
                sessionLockToken: (isSessionExclusive || !takingSessionOver) ? null : Guid.NewGuid(),
                cancellationToken: CancellationToken.None);
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

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
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), CancellationToken.None);
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
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), CancellationToken.None);
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
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), CancellationToken.None);
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
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), CancellationToken.None);
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
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), CancellationToken.None);
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
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ServiceBusReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession, false, Mock.Of<AmqpMessageConverter>(), CancellationToken.None);
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
                    It.IsAny<CancellationToken>()),
                Times.Once());
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
                default);
    }
}

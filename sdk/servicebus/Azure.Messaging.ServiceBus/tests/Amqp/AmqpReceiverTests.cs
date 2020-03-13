// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
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
            yield return new object[] { new ServiceBusRetryOptions { MaximumRetries = 3, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = ServiceBusRetryMode.Fixed } };
            yield return new object[] { new ServiceBusRetryOptions { MaximumRetries = 0, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = ServiceBusRetryMode.Fixed } };
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
                receiveMode: ReceiveMode.PeekLock,
                prefetchCount: 0,
                connectionScope: Mock.Of<AmqpConnectionScope>(),
                retryPolicy: Mock.Of<ServiceBusRetryPolicy>(),
                sessionId: default,
                identifier: "someIdentifier",
                isSessionReceiver: default),
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
                receiveMode: ReceiveMode.PeekLock,
                prefetchCount: 0,
                connectionScope: null,
                retryPolicy: Mock.Of<ServiceBusRetryPolicy>(),
                identifier: "someIdentifier",
                sessionId: default,
                isSessionReceiver: default),
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
                receiveMode: ReceiveMode.PeekLock,
                prefetchCount: 0,
                connectionScope: Mock.Of<AmqpConnectionScope>(),
                retryPolicy: null,
                identifier: "someIdentifier",
                sessionId: default,
                isSessionReceiver: default),
            Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpReceiver.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheConsumerAsClosed()
        {
            var receiver = CreateReceiver();

            Assert.That(receiver.IsClosed, Is.False, "The receiver should not be closed on creation");

            await receiver.CloseAsync(CancellationToken.None);
            Assert.That(receiver.IsClosed, Is.True, "The receiver should be marked as closed after closing");
        }

        ///// <summary>
        /////   Verifies functionality of the <see cref="AmqpReceiver.ReceiveAsync" />
        /////   method.
        ///// </summary>
        /////
        //[Test]
        //[TestCase(-32768)]
        //[TestCase(-1)]
        //[TestCase(0)]
        //public void ReceiveAsyncValidatesTheMaximumMessageCount(int count)
        //{
        //    var eventHub = "eventHubName";
        //    var consumerGroup = "$DEFAULT";
        //    var partition = "3";
        //    var eventPosition = EventPosition.FromOffset(123);
        //    var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
        //    var retriableException = new EventHubsException(true, "Test");
        //    var mockConverter = new Mock<AmqpMessageConverter>();
        //    var mockCredential = new Mock<TokenCredential>();
        //    var mockScope = new Mock<AmqpConnectionScope>();

        //    using var cancellationSource = new CancellationTokenSource();

        //    var consumer = new AmqpReceiver(eventHub, consumerGroup, partition, eventPosition, true, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
        //    Assert.That(async () => await consumer.ReceiveAsync(count, null, cancellationSource.Token), Throws.InstanceOf<ArgumentException>());
        //}

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

            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
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
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession);
            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.GeneralError));

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
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
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var receiver = new AmqpReceiver(entityName, ReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession);
            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ServiceTimeout));

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
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
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new Error
            {
                Condition = AmqpError.ServerBusyError.ToString()
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
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);


            var receiver = new AmqpReceiver(entityName, ReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession);
            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ServiceBusy));
            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
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
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession);
            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<ArgumentNullException>());

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
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
            var exception = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
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
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession);
            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<ArgumentException>());

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<ReceiveMode>(),
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
        public void ReceiveAsyncDoesntRetryOnTaskCanceled()
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
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<ReceiveMode>(),
                   It.IsAny<string>(),
                   It.IsAny<bool>(),
                   It.IsAny<CancellationToken>()))
               .Throws(exception);

            var receiver = new AmqpReceiver(entityName, ReceiveMode.PeekLock, prefetchCount, mockScope.Object, retryPolicy, "someIdentifier", sessionId, isSession);
            Assert.That(async () => await receiver.ReceiveBatchAsync(100, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

            mockScope
                .Verify(scope => scope.OpenReceiverLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<ReceiveMode>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        private AmqpReceiver CreateReceiver() =>
            new AmqpReceiver(
                "someQueue",
                ReceiveMode.PeekLock,
                0,
                Mock.Of<AmqpConnectionScope>(),
                Mock.Of<ServiceBusRetryPolicy>(),
                "someIdentifier",
                default,
                default);
    }
}

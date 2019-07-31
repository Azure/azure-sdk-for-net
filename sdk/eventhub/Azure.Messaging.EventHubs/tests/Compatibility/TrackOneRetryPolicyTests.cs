// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Compatibility;
using Azure.Messaging.EventHubs.Errors;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneRetryPolicy" />
    ///   class.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneRetryPolicyTests
    {
        /// <summary>
        ///   Validates functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSourcePolicy()
        {
            Assert.That(() => new TrackOneRetryPolicy(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneRetryPolicy.OnGetNextRetryInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RetryIsNotInvokedForNonRetriableException()
        {
            var noRetryException = new Exception("NO RETRY!");
            var retryPolicy = new TrackOneRetryPolicy(Mock.Of<EventHubRetryPolicy>());

            Assert.That(TrackOne.RetryPolicy.IsRetryableException(noRetryException), Is.False, "The base exception is considered as retriable by the TrackOne.RetryPolicy; this shouldn't be the case.");
            Assert.That(retryPolicy.GetNextRetryInterval(noRetryException, TimeSpan.FromHours(4), 0), Is.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneRetryPolicy.OnGetNextRetryInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RetryIsInvokedForRetriableNonEventHubsException()
        {
            var retryCount = 99;
            var lastException = new OperationCanceledException("RETRY!");
            var expectedInterval = TimeSpan.FromMinutes(65);
            var mockRetryPolicy = new Mock<EventHubRetryPolicy>();
            var retryPolicy = new TrackOneRetryPolicy(mockRetryPolicy.Object);

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => Object.ReferenceEquals(value, lastException)), It.Is<int>(value => value == retryCount)))
                .Returns(expectedInterval);

            Assert.That(TrackOne.RetryPolicy.IsRetryableException(lastException), Is.True, "The operation canceled exception should be considered as retriable by the TrackOne.RetryPolicy.");
            Assert.That(retryPolicy.GetNextRetryInterval(lastException, TimeSpan.FromHours(4), retryCount), Is.EqualTo(expectedInterval));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneRetryPolicy.OnGetNextRetryInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RetryIsInvokedForRetriableTrackOneEventHubsException()
        {
            var retryCount = 99;
            var lastException = new TrackOne.EventHubsTimeoutException("RETRY!");
            var mappedException = lastException.MapToTrackTwoException();
            var expectedInterval = TimeSpan.FromMinutes(65);
            var mockRetryPolicy = new Mock<EventHubRetryPolicy>();
            var retryPolicy = new TrackOneRetryPolicy(mockRetryPolicy.Object);

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<EventHubsException>(value => value.GetType() == mappedException.GetType()), It.Is<int>(value => value == retryCount)))
                .Returns(expectedInterval);

            Assert.That(TrackOne.RetryPolicy.IsRetryableException(lastException), Is.True, "The timeout exception should be considered as retriable by the TrackOne.RetryPolicy.");
            Assert.That(retryPolicy.GetNextRetryInterval(lastException, TimeSpan.FromHours(4), retryCount), Is.EqualTo(expectedInterval));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneRetryPolicy.OnGetNextRetryInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RetryIsNotInvokedForWhenNoTimeRemains()
        {
            var lastException = new OperationCanceledException("RETRY!");
            var retryPolicy = new TrackOneRetryPolicy(Mock.Of<EventHubRetryPolicy>());

            Assert.That(TrackOne.RetryPolicy.IsRetryableException(lastException), Is.True, "The operation canceled exception should be considered as retriable by the TrackOne.RetryPolicy.");
            Assert.That(retryPolicy.GetNextRetryInterval(lastException, TimeSpan.Zero, 0), Is.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneRetryPolicy.OnGetNextRetryInterval" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RetryIntervalIsCancelledWhenLargerThanRemainingTime()
        {
            var retryCount = 99;
            var lastException = new OperationCanceledException("RETRY!");
            var mockRetryPolicy = new Mock<EventHubRetryPolicy>();
            var retryPolicy = new TrackOneRetryPolicy(mockRetryPolicy.Object);

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => Object.ReferenceEquals(value, lastException)), It.Is<int>(value => value == retryCount)))
                .Returns(TimeSpan.FromHours(4));

            Assert.That(TrackOne.RetryPolicy.IsRetryableException(lastException), Is.True, "The operation canceled exception should be considered as retriable by the TrackOne.RetryPolicy.");
            Assert.That(retryPolicy.GetNextRetryInterval(lastException, TimeSpan.FromSeconds(30), retryCount), Is.Null);
        }
    }
}

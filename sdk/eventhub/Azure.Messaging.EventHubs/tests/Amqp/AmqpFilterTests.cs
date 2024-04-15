﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.Amqp.Encoding;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpFilter" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpFilterTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildFilterExpressionEnsuresAnEventPositionIsFilterable()
        {
            // Unset all properties for the event position.

            var position = EventPosition.FromOffset(1);
            position.Offset = null;

            Assert.That(() => AmqpFilter.BuildFilterExpression(position), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildFilterExpressionPrefersSequenceNumber()
        {
            // Set all properties for the event position.

            var offset = "1";
            var sequenceNumber = 222;
            var replicationSegment = 4;
            var eventPosition = EventPosition.FromSequenceNumber(sequenceNumber, replicationSegment);
            eventPosition.Offset = offset;
            eventPosition.EnqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");

            var filter = AmqpFilter.BuildFilterExpression(eventPosition);
            Assert.That(filter, Contains.Substring(AmqpFilter.SequenceNumberName), "The sequence number should have precedence for filtering.");
            Assert.That(filter, Contains.Substring(sequenceNumber.ToString()), "The sequence number value should be present in the filter.");
            Assert.That(filter, Contains.Substring(replicationSegment.ToString()), "The replication segment value should be present in the filter.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildFilterExpressionPrefersOffsetToEnqueuedTime()
        {
            // Set all properties for the event position.

            var offset = 2345;
            var position = EventPosition.FromOffset(offset);
            position.EnqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");

            var filter = AmqpFilter.BuildFilterExpression(position);
            Assert.That(filter, Contains.Substring(AmqpFilter.SequenceNumberName), "The sequence number should have precedence over the enqueued time for filtering.");
            Assert.That(filter, Contains.Substring(offset.ToString()), "The sequence number value should be present in the filter.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildFilterExpressionUsesEnqueuedTime()
        {
            // Set all properties for the event position.

            var enqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var position = EventPosition.FromEnqueuedTime(enqueuedTime);

            var filter = AmqpFilter.BuildFilterExpression(position);
            Assert.That(filter, Contains.Substring(AmqpFilter.EnqueuedTimeName), "The enqueued time should have been used.");
            Assert.That(filter, Contains.Substring(enqueuedTime.ToUnixTimeMilliseconds().ToString()), "The enqueued time value should be present in the filter.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildFilterExpressionAllowsEarliest()
        {
            Assert.That(() => AmqpFilter.BuildFilterExpression(EventPosition.Earliest), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildFilterExpressionAllowsLatest()
        {
            Assert.That(() => AmqpFilter.BuildFilterExpression(EventPosition.Latest), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void BuildFilterExpressionHonorsInclusiveFlagForOffset(bool inclusive)
        {
            var comparison = (inclusive) ? ">=" : ">";
            var position = EventPosition.FromOffset(1);
            position.IsInclusive = inclusive;

            var filter = AmqpFilter.BuildFilterExpression(position);
            Assert.That(filter, Contains.Substring(comparison), "The comparison should be based on the inclusive flag.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void BuildFilterExpressionHonorsInclusiveFlagForSequenceNumber(bool inclusive)
        {
            var comparison = (inclusive) ? ">=" : ">";
            var position = EventPosition.FromSequenceNumber(123, inclusive);
            var filter = AmqpFilter.BuildFilterExpression(position);

            Assert.That(filter, Contains.Substring(comparison), "The comparison should be based on the inclusive flag.");
            Assert.That(filter, Contains.Substring(":123"), "The filter should set replicationSegment:sequenceNumber.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void BuildFilterExpressionHonorsInclusiveFlagForSequenceNumberAndReplicationSegment(bool inclusive)
        {
            var comparison = (inclusive) ? ">=" : ">";
            var position = EventPosition.FromSequenceNumber(123, 4, inclusive);
            var filter = AmqpFilter.BuildFilterExpression(position);

            Assert.That(filter, Contains.Substring(comparison), "The comparison should be based on the inclusive flag.");
            Assert.That(filter, Contains.Substring("4:123"), "The filter should set replicationSegment:sequenceNumber.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.BuildFilterExpression(EventPosition)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void BuildFilterExpressionIgnoresInclusiveFlagForEnqueuedTime(bool inclusive)
        {
            var position = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-27T12:00:00Z"));
            position.IsInclusive = inclusive;

            var filter = AmqpFilter.BuildFilterExpression(position);
            Assert.That(filter, Does.Not.Contain("="), "The comparison should not consider the inclusive flag.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.CreateConsumerFilter" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateConsumerFilterValidatesTheExpression(string expression)
        {
            Assert.That(() => AmqpFilter.CreateConsumerFilter(expression), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpFilter.CreateConsumerFilter" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerFilterCreatesTheFilter()
        {
            var expression = "test > 1";
            var filter = AmqpFilter.CreateConsumerFilter(expression);

            Assert.That(filter, Is.Not.Null, "The filter should have been created");
            Assert.That(filter.DescriptorName, Is.EqualTo((AmqpSymbol)AmqpFilter.ConsumerFilterName), "The filter name should have been populated");
            Assert.That(filter.DescriptorCode, Is.EqualTo(AmqpFilter.ConsumerFilterCode), "The filter code should have been populated");
            Assert.That(filter.Value, Is.EqualTo(expression), "The filter expression should have been used as the body of the filter");
        }
    }
}

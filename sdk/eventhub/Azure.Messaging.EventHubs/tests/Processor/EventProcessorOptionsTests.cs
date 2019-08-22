// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Processor
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessorOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventProcessorOptions
            {
                InitialEventPosition = EventPosition.FromOffset(55),
                MaximumMessageCount = 43,
                MaximumReceiveWaitTime = TimeSpan.FromMinutes(65)
            };

            var clone = options.Clone();

            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.Not.SameAs(options), "The clone should be a different instance.");

            Assert.That(clone.InitialEventPosition, Is.EqualTo(options.InitialEventPosition), "The initial event position of the clone should match.");
            Assert.That(clone.MaximumMessageCount, Is.EqualTo(options.MaximumMessageCount), "The maximum message count of the clone should match.");
            Assert.That(clone.MaximumReceiveWaitTime, Is.EqualTo(options.MaximumReceiveWaitTime), "The maximum receive wait time of the clone should match.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventProcessorOptions.MaximumMessageCount" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        public void MaximumMessageCountIsValidated()
        {
            var options = new EventProcessorOptions();
            Assert.That(() => options.MaximumMessageCount = 0, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventProcessorOptions.MaximumReceiveWaitTime" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        public void MaximumReceiveWaitTimeIsValidated()
        {
            var options = new EventProcessorOptions();
            Assert.That(() => options.MaximumReceiveWaitTime = TimeSpan.FromSeconds(-1), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.MaximumReceiveWaitTime" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumReceiveWaitTimeAllowsNull()
        {
            var options = new EventProcessorOptions();
            Assert.That(() => options.MaximumReceiveWaitTime = null, Throws.Nothing);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Consumer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ReadEventOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ReadOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="ReadEventOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new ReadEventOptions
            {
                OwnerLevel = 99,
                TrackLastEnqueuedEventProperties = false,
                MaximumWaitTime = TimeSpan.FromMinutes(65),
                CacheEventCount = 1,
                PrefetchCount = 0
            };

            ReadEventOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.OwnerLevel, Is.EqualTo(options.OwnerLevel), "The owner level of the clone should match.");
            Assert.That(clone.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "The tracking of last event information of the clone should match.");
            Assert.That(clone.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The maximum wait time of the clone should match.");
            Assert.That(clone.CacheEventCount, Is.EqualTo(options.CacheEventCount), "The event cache count of the clone should match.");
            Assert.That(clone.PrefetchCount, Is.EqualTo(options.PrefetchCount), "The prefetch count of the clone should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ReadEventOptions.MaximumWaitTime" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void MaximumWaitTimeIsValidated()
        {
            Assert.That(() => new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(-1) }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ReadEventOptions.MaximumWaitTime" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumWaitTimeAllowsNull()
        {
            var options = new ReadEventOptions();
            Assert.That(() => options.MaximumWaitTime = null, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ReadEventOptions.CacheEventCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void CacheEventCountIsValidated()
        {
            Assert.That(() => new ReadEventOptions { CacheEventCount = 0 }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ReadEventOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchCountIsValidated()
        {
            Assert.That(() => new ReadEventOptions { PrefetchCount = -1 }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ReadEventOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchCountAllowsZero()
        {
            Assert.That(() => new ReadEventOptions { PrefetchCount = 0 }, Throws.Nothing);
        }
    }
}

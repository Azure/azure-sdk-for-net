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
                MaximumWaitTime = TimeSpan.FromMinutes(65)
            };

            ReadEventOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.OwnerLevel, Is.EqualTo(options.OwnerLevel), "The owner level of the clone should match.");
            Assert.That(clone.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "The tracking of last event information of the clone should match.");
            Assert.That(clone.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The default maximum wait time of the clone should match.");
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
    }
}

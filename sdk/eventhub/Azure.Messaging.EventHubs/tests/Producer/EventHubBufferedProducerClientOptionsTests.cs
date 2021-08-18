// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubBufferedProducerClientOptions"/>
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    internal class EventHubBufferedProducerClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition"/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void MaximumConcurrentSendsPerPartitionTooLarge()
        {
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSendsPerPartition = 80 };

<<<<<<< HEAD
<<<<<<< HEAD
            Assert.Throws<ArgumentOutOfRangeException>(() => { options.MaximumConcurrentSendsPerPartition = 800; });
=======
            Assert.Throws<ArgumentException>(() => { options.MaximumConcurrentSendsPerPartition = 800; });
>>>>>>> 88750fe801 (Adding skeleton files)
=======
            Assert.Throws<ArgumentOutOfRangeException>(() => { options.MaximumConcurrentSendsPerPartition = 800; });
>>>>>>> 4a59397f3f (test typo)
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition"/>
        ///   property.
        /// </summary>
        [Test]
        public void MaximumConcurrentSendsPerPartitionTooSmall()
        {
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSendsPerPartition = 80 };

<<<<<<< HEAD
<<<<<<< HEAD
            Assert.Throws<ArgumentOutOfRangeException>(() => { options.MaximumConcurrentSendsPerPartition = 0; });
=======
            Assert.Throws<ArgumentException>(() => { options.MaximumConcurrentSendsPerPartition = 0; });
>>>>>>> 88750fe801 (Adding skeleton files)
=======
            Assert.Throws<ArgumentOutOfRangeException>(() => { options.MaximumConcurrentSendsPerPartition = 0; });
>>>>>>> 4a59397f3f (test typo)
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition"/>
        ///   property.
        /// </summary>
        [Test]
        public void MaximumConcurrentSendsPerPartitionInRange()
        {
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSendsPerPartition = 80 };

            Assert.DoesNotThrow(() => { options.MaximumConcurrentSendsPerPartition = 50; });
        }
    }
}

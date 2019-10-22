// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BlobPartitionManager" />
    ///   class.
    /// </summary>
    ///
    public class BlobPartitionManagerTests
    {
        /// <summary>
        ///    Verifies functionality of the <see cref="BlobPartitionManager" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresBlobContainerClient()
        {
            Assert.That(() => new BlobPartitionManager(null), Throws.InstanceOf<ArgumentException>());
        }
    }
}

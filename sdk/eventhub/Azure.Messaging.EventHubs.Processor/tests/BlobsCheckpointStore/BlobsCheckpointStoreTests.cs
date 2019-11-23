// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="Processor.BlobsCheckpointStore" />
    ///   class.
    /// </summary>
    ///
    public class BlobsCheckpointStoreTests
    {
        /// <summary>
        ///    Verifies functionality of the <see cref="Processor.BlobsCheckpointStore" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresBlobContainerClient()
        {
            Assert.That(() => new Processor.BlobsCheckpointStore(null), Throws.InstanceOf<ArgumentException>());
        }
    }
}

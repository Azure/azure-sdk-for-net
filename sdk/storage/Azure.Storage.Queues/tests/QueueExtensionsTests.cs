// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class QueueExtensionsTests
    {
        [Test]
        public void ToQueueProperties_NullResponse_ReturnsNull()
        {
            Response response = null;

            var result = response.ToQueueProperties();

            Assert.IsNull(result);
        }

        [Test]
        public void ToUpdateReceipt_NullResponse_ReturnsNull()
        {
            Response response = null;

            var result = response.ToUpdateReceipt();

            Assert.IsNull(result);
        }
    }
}

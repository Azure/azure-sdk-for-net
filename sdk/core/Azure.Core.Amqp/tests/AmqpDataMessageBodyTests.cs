// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpDataMessageBodyTests
    {
        [Test]
        public void CanCreateDataBody()
        {
            var body = new AmqpMessageBody(Array.Empty<ReadOnlyMemory<byte>>());
            Assert.AreEqual(AmqpMessageBodyType.Data, body.BodyType);
            Assert.IsTrue(body.TryGetData(out var data));
            Assert.NotNull(data);

            body = new AmqpMessageBody(null);
            Assert.AreEqual(AmqpMessageBodyType.Data, body.BodyType);
            Assert.IsTrue(body.TryGetData(out data));
            Assert.NotNull(data);
        }
    }
}

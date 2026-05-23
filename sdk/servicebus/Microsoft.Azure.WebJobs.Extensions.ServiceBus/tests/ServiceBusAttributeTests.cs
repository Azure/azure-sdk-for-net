// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusAttributeTests
    {
        [Test]
        public void Constructor_Success()
        {
            ServiceBusAttribute attribute = new ServiceBusAttribute("testqueue");
            Assert.AreEqual("testqueue", attribute.QueueOrTopicName);
        }
    }
}

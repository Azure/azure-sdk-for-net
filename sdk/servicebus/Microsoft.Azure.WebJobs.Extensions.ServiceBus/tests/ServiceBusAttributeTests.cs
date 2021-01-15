// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusAttributeTests
    {
        [Fact]
        public void Constructor_Success()
        {
            ServiceBusAttribute attribute = new ServiceBusAttribute("testqueue");
            Assert.Equal("testqueue", attribute.QueueOrTopicName);
        }
    }
}

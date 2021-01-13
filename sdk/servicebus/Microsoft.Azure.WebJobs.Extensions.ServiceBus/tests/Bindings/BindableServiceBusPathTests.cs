// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class BindableServiceBusPathTests
    {
        [Fact]
        public void Create_IfNonParameterizedPattern_ReturnsBoundPath()
        {
            const string queueOrTopicNamePattern = "queue-name-with-no-parameters";

            IBindableServiceBusPath path = BindableServiceBusPath.Create(queueOrTopicNamePattern);

            Assert.NotNull(path);
            Assert.Equal(queueOrTopicNamePattern, path.QueueOrTopicNamePattern);
            Assert.True(path.IsBound);
        }

        [Fact]
        public void Create_IfParameterizedPattern_ReturnsNotBoundPath()
        {
            const string queueOrTopicNamePattern = "queue-{name}-with-{parameter}";

            IBindableServiceBusPath path = BindableServiceBusPath.Create(queueOrTopicNamePattern);

            Assert.NotNull(path);
            Assert.Equal(queueOrTopicNamePattern, path.QueueOrTopicNamePattern);
            Assert.False(path.IsBound);
        }

        [Fact]
        public void Create_IfNullPattern_Throws()
        {
            ExceptionAssert.ThrowsArgumentNull(() => BindableServiceBusPath.Create(null), "queueOrTopicNamePattern");
        }

        [Fact]
        public void Create_IfMalformedPattern_PropagatesThrownException()
        {
            const string queueNamePattern = "malformed-queue-{name%";

            ExceptionAssert.ThrowsFormat(
                () => BindableServiceBusPath.Create(queueNamePattern),
                "Invalid template 'malformed-queue-{name%'. Missing closing bracket at position 17.");
        }
    }
}

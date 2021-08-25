// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class BindableServiceBusPathTests
    {
        [Test]
        public void Create_IfNonParameterizedPattern_ReturnsBoundPath()
        {
            const string queueOrTopicNamePattern = "queue-name-with-no-parameters";

            IBindableServiceBusPath path = BindableServiceBusPath.Create(queueOrTopicNamePattern);

            Assert.NotNull(path);
            Assert.AreEqual(queueOrTopicNamePattern, path.QueueOrTopicNamePattern);
            Assert.True(path.IsBound);
        }

        [Test]
        public void Create_IfParameterizedPattern_ReturnsNotBoundPath()
        {
            const string queueOrTopicNamePattern = "queue-{name}-with-{parameter}";

            IBindableServiceBusPath path = BindableServiceBusPath.Create(queueOrTopicNamePattern);

            Assert.NotNull(path);
            Assert.AreEqual(queueOrTopicNamePattern, path.QueueOrTopicNamePattern);
            Assert.False(path.IsBound);
        }

        [Test]
        public void Create_IfNullPattern_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => BindableServiceBusPath.Create(null), "queueOrTopicNamePattern");
        }

        [Test]
        public void Create_IfMalformedPattern_PropagatesThrownException()
        {
            const string queueNamePattern = "malformed-queue-{name%";

            Assert.Throws<FormatException>(
                () => BindableServiceBusPath.Create(queueNamePattern),
                "Invalid template 'malformed-queue-{name%'. Missing closing bracket at position 17.");
        }
    }
}

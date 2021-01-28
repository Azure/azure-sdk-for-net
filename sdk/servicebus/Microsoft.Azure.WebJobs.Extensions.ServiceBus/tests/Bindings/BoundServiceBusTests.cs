// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class BoundServiceBusTests
    {
        [Test]
        public void Bind_IfNotNullBindingData_ReturnsResolvedQueueName()
        {
            const string queueOrTopicNamePattern = "queue-name-with-no-parameters";
            var bindingData = new Dictionary<string, object> { { "name", "value" } };
            IBindableServiceBusPath path = new BoundServiceBusPath(queueOrTopicNamePattern);

            string result = path.Bind(bindingData);

            Assert.AreEqual(queueOrTopicNamePattern, result);
        }

        [Test]
        public void Bind_IfNullBindingData_ReturnsResolvedQueueName()
        {
            const string queueOrTopicNamePattern = "queue-name-with-no-parameters";
            IBindableServiceBusPath path = new BoundServiceBusPath(queueOrTopicNamePattern);

            string result = path.Bind(null);

            Assert.AreEqual(queueOrTopicNamePattern, result);
        }
    }
}

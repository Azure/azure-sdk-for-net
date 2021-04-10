// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class ParameterizedServiceBusPathTests
    {
        [Test]
        public void Bind_IfNotNullBindingData_ReturnsResolvedQueueName()
        {
            const string queueOrTopicNamePattern = "queue-{name}-with-{parameter}";
            var bindingData = new Dictionary<string, object> { { "name", "name" }, { "parameter", "parameter" } };
            IBindableServiceBusPath path = CreateProductUnderTest(queueOrTopicNamePattern);

            string result = path.Bind(bindingData);

            Assert.AreEqual("queue-name-with-parameter", result);
        }

        [Test]
        public void Bind_IfNullBindingData_Throws()
        {
            const string queueOrTopicNamePattern = "queue-{name}-with-{parameter}";
            IBindableServiceBusPath path = CreateProductUnderTest(queueOrTopicNamePattern);

            Assert.Throws<ArgumentNullException>(() => path.Bind(null), "bindingData");
        }

        private static IBindableServiceBusPath CreateProductUnderTest(string queueOrTopicNamePattern)
        {
            BindingTemplate template = BindingTemplate.FromString(queueOrTopicNamePattern);
            IBindableServiceBusPath path = new ParameterizedServiceBusPath(template);
            return path;
        }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Bindings;
using Xunit;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class ParameterizedServiceBusPathTests
    {
        [Fact]
        public void Bind_IfNotNullBindingData_ReturnsResolvedQueueName()
        {
            const string queueOrTopicNamePattern = "queue-{name}-with-{parameter}";
            var bindingData = new Dictionary<string, object> { { "name", "name" }, { "parameter", "parameter" } };
            IBindableServiceBusPath path = CreateProductUnderTest(queueOrTopicNamePattern);

            string result = path.Bind(bindingData);

            Assert.Equal("queue-name-with-parameter", result);
        }

        [Fact]
        public void Bind_IfNullBindingData_Throws()
        {
            const string queueOrTopicNamePattern = "queue-{name}-with-{parameter}";
            IBindableServiceBusPath path = CreateProductUnderTest(queueOrTopicNamePattern);

            ExceptionAssert.ThrowsArgumentNull(() => path.Bind(null), "bindingData");
        }

        private static IBindableServiceBusPath CreateProductUnderTest(string queueOrTopicNamePattern)
        {
            BindingTemplate template = BindingTemplate.FromString(queueOrTopicNamePattern);
            IBindableServiceBusPath path = new ParameterizedServiceBusPath(template);
            return path;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    public class RulePropertiesTests
    {
        [Test]
        public void CanCreateRulePropertiesFromFactory()
        {
            var filter = new SqlRuleFilter("PROPERTY(@propertyName) = @stringPropertyValue");
            var action = new SqlRuleAction("SET a='b'");
            var properties = ServiceBusModelFactory.RuleProperties(
                "ruleName",
                filter,
                action);
            Assert.AreEqual("ruleName", properties.Name);
            Assert.AreEqual(filter, properties.Filter);
            Assert.AreEqual(action, properties.Action);
        }
    }
}

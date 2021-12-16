// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Administration
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

        [Test]
        public void CanCreateRulePropertiesWithSqlFilterFromOptions()
        {
            var options = new CreateRuleOptions("rule")
            {
                Filter = new SqlRuleFilter("PROPERTY(@propertyName) = @stringPropertyValue"),
                Action = new SqlRuleAction("SET a='b'")
            };
            var properties = new RuleProperties(options);

            Assert.AreEqual(options, new CreateRuleOptions(properties));
        }

        [Test]
        public void CanCreateRulePropertiesWithCorrelationFilterFromOptions()
        {
            var options = new CreateRuleOptions("rule")
            {
                Filter = new CorrelationRuleFilter
                {
                    ApplicationProperties =
                    {
                        {"propertyName", "value"}
                    }
                },
                Action = new SqlRuleAction("SET a='b'")
            };
            var properties = new RuleProperties(options);

            Assert.AreEqual(options, new CreateRuleOptions(properties));
        }
    }
}

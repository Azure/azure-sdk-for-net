// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Management;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.RuleManager
{
    public class RuleTests
    {
        [Test]
        public void SqlFilterValidation()
        {
            Assert.That(
                () => new SqlRuleFilter(null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                () => new SqlRuleFilter(string.Empty),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => new SqlRuleFilter(new string('a', Constants.MaximumSqlRuleFilterStatementLength + 1)),
                Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SqlRuleActionValidation()
        {
            Assert.That(
                () => new SqlRuleAction(null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                () => new SqlRuleAction(string.Empty),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => new SqlRuleAction(new string('a', Constants.MaximumSqlRuleActionStatementLength + 1)),
                Throws.InstanceOf<ArgumentException>());
        }
    }
}

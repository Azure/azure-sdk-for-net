// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Filters;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.RuleManager
{
    public class RuleTests
    {
        [Test]
        public void SqlFilterValidation()
        {
            Assert.That(
                () => new SqlFilter(null),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(
                () => new SqlFilter(string.Empty),
                Throws.InstanceOf<ArgumentException>());
            Assert.That(
                () => new SqlFilter(new string('a', Constants.MaximumSqlFilterStatementLength + 1)),
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

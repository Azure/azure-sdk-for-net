// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class LogicalOperatorTests
    {
        [Test]
        public void LogicalOperator_ValidOr()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 5)
                .Or()
                .Compare("Humidity", QueryComparisonOperator.Equal, 10);
            query.GetLogicText()
                .Should()
                .Be("Temperature = 5 OR Humidity = 10");
        }

        [Test]
        public void LogicalOperator_ValidAnd()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 5)
                .And()
                .Compare("Humidity", QueryComparisonOperator.Equal, 10);
            query.GetLogicText()
                .Should()
                .Be("Temperature = 5 AND Humidity = 10");
        }
    }
}

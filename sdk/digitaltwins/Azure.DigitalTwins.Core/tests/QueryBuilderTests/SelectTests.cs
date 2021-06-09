// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class SelectTests
    {
        [Test]
        public void SelectQueryTests()
        {
            var query1 = new SelectQuery(null, null);
            query1.Select("*");
            query1.Stringify()
                .Should()
                .Be("SELECT *");

            var query2 = new SelectQuery(null, null);
            query2.SelectCount();
            query2.Stringify()
                .Should()
                .Be("SELECT COUNT()");

            var query3 = new SelectQuery(null, null);
            query3.SelectTop(5);
            query3.Stringify()
                .Should()
                .Be("SELECT TOP(5)");

            var query4 = new SelectQuery(null, null);
            query4.SelectOverride("Room, Temperature");
            query4.Stringify()
                .Should()
                .Be("SELECT Room, Temperature");
        }
    }
}

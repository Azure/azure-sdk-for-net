// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class SelectQueryTests
    {
        [Test]
        public void SelectQuery_All()
        {
            var query = new SelectQuery(null, null);
            query.Select("*");
            query.Stringify()
                .Should()
                .Be("SELECT *");
        }

        [Test]
        public void SelectQuery_Count()
        {
            var query = new SelectQuery(null, null);
            query.SelectCount();
            query.Stringify()
                .Should()
                .Be("SELECT COUNT()");
        }

        [Test]
        public void SelectQuery_Top()
        {
            var query = new SelectQuery(null, null);
            query.SelectTop(5);
            query.Stringify()
                .Should()
                .Be("SELECT TOP(5)");
        }

        [Test]
        public void SelectQuery_Override()
        {
            var query = new SelectQuery(null, null);
            query.Select("Room, Temperature");
            query.Stringify()
                .Should()
                .Be("SELECT Room, Temperature");
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
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
            query.SelectAll();
            query.GetQueryText()
                .Should()
                .Be("SELECT *");
        }

        [Test]
        public void SelectQuery_Count()
        {
            var query = new SelectQuery(null, null);
            query.SelectCount();
            query.GetQueryText()
                .Should()
                .Be("SELECT COUNT()");
        }

        [Test]
        public void SelectQuery_Top()
        {
            var query = new SelectQuery(null, null);
            query.SelectTop(5, "Temperature");
            query.GetQueryText()
                .Should()
                .Be("SELECT TOP(5) Temperature");
        }

        [Test]
        public void SelectQuery_TopAll()
        {
            var query = new SelectQuery(null, null);
            query.SelectTopAll(5);
            query.GetQueryText()
                .Should()
                .Be("SELECT TOP(5)");
        }

        [Test]
        public void SelectQuery_Override()
        {
            var query = new SelectQuery(null, null);
            query.Select("Room, Temperature");
            query.GetQueryText()
                .Should()
                .Be("SELECT Room, Temperature");
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class QueryBuilderTests
    {
        [Test]
        public void SelectSinglePropertyTests()
        {
            new AdtQueryBuilder().Select("*").From(AdtCollection.DigitalTwins).Build().ToString().Should().Be("SELECT * FROM DIGITALTWINS");
            new AdtQueryBuilder().Select("Room").From(AdtCollection.DigitalTwins).Build().ToString().Should().Be("SELECT Room FROM DIGITALTWINS");
        }

        [Test]
        public void SelectMultiplePropertyTests()
        {
            new AdtQueryBuilder().Select("Room", "Factory").From(AdtCollection.DigitalTwins).Build().ToString().Should().Be("SELECT Room, Factory FROM DIGITALTWINS");
        }

        [Test]
        public void SelectAggregateTests()
        {
            // TODO -- look into if we can pass parameters into TOP and COUNT like property names
            new AdtQueryBuilder().SelectTop(5).From(AdtCollection.DigitalTwins).Build().ToString().Should().Be("SELECT TOP(5) FROM DIGITALTWINS");
            new AdtQueryBuilder().SelectCount("*").From(AdtCollection.DigitalTwins).Build().ToString().Should().Be("SELECT COUNT() FROM DIGITALTWINS");
        }
    }
}

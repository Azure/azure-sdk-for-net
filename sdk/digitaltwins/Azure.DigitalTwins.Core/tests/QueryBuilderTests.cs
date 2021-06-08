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
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT * FROM DIGITALTWINS");

            new AdtQueryBuilder()
                .Select("Room")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT Room FROM DIGITALTWINS");
        }

        [Test]
        public void SelectMultiplePropertyTests()
        {
            new AdtQueryBuilder()
                .Select("Room", "Factory")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT Room, Factory FROM DIGITALTWINS");

            new AdtQueryBuilder()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DIGITALTWINS");
        }

        [Test]
        public void SelectAggregateTests()
        {
            new AdtQueryBuilder()
                .SelectTop(5)
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(5) FROM DIGITALTWINS");

            new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT COUNT() FROM DIGITALTWINS");

            new AdtQueryBuilder()
                .SelectTop(3, "Temperature", "Humidity")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS");

            new AdtQueryBuilder()
                .SelectTop(3, "Temperature")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature FROM DIGITALTWINS");
        }

        [Test]
        public void OverrideTests()
        {
            new AdtQueryBuilder()
                .SelectOverride("TOP(3) Room, Temperature")
                .From(AdtCollection.DIGITALTWINS)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DIGITALTWINS");
        }
    }
}

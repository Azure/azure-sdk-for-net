// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests.QueryBuilderTests
{
    public class FullQueryTests
    {
        [Test]
        public void SelectSinglePropertyTests()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins");

            new AdtQueryBuilder()
                .Select("Room")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void SelectMultiplePropertyTests()
        {
            new AdtQueryBuilder()
                .Select("Room", "Factory")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT Room, Factory FROM DigitalTwins");

            new AdtQueryBuilder()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void SelectAggregateTests()
        {
            new AdtQueryBuilder()
                .SelectTop(5)
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");

            new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");

            new AdtQueryBuilder()
                .SelectTop(3, "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");

            new AdtQueryBuilder()
                .SelectTop(3, "Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature FROM DigitalTwins");
        }

        [Test]
        public void OverrideTests()
        {
            new AdtQueryBuilder()
                .SelectOverride("TOP(3) Room, Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }
    }
}

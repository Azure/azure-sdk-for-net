// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests.QueryBuilderTests
{
    public class AdtQueryBuilderTests
    {
        [Test]
        public void AdtQueryBuilder_Select_AllSimple()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SingleProperty()
        {
            new AdtQueryBuilder()
                .Select("Room")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
    }

        [Test]
        public void AdtQueryBuilder_Select_MultipleProperties()
        {
            new AdtQueryBuilder()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Aggregates_Top_All()
        {
            new AdtQueryBuilder()
                .SelectTop(5)
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Aggregates_Top_Properties()
        {
            new AdtQueryBuilder()
                .SelectTop(3, "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void AdtQueryBuilder_Select_Aggregates_Count()
        {
            new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Override()
        {
            new AdtQueryBuilder()
                .SelectOverride("TOP(3) Room, Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Where_Comparison()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.GreaterOrEqual, 50)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void AdtQueryBuilder_Where_Contains()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .NotContains("Location", new string[] { "Paris", "Tokyo", "Madrid", "Prague" })
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void AdtQueryBuilder_Where_Override()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .CustomClause("IS_OF_MODEL('dtmi:example:room;1', exact)")
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void AdtQueryBuilder_Where_IsOfModel()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfModel("dtmi:example:room;1", true)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void AdtQueryBuilder_Where_IsBool()
        {
            new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.Relationships)
                .Where()
                .IsOfType("isOccupied", AdtDataType.AdtBool)
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT * FROM Relationships WHERE IS_BOOL(isOccupied)");
        }

        [Test]
        public void AdtQueryBuilder_Where_MultipleWhere()
        {
            new AdtQueryBuilder()
                .Select("Temperature")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsDefined("Humidity")
                .CustomClause("Occupants < 10")
                .Build()
                .Stringify()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");
        }
    }
}

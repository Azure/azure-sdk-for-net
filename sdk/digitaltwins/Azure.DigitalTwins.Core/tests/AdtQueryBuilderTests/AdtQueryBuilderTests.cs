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
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .BuildLogic()
                .GetQueryText()
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
                .GetQueryText()
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
                .GetQueryText()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Aggregates_Top_All()
        {
            new AdtQueryBuilder()
                .SelectTopAll(5)
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
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
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void AdtQueryBuilder_Select_Aggregates_Count()
        {
            new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Override()
        {
            new AdtQueryBuilder()
                .SelectCustom("TOP(3) Room, Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAs()
        {
            new AdtQueryBuilder()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAsChainedWithSelect()
        {
            new AdtQueryBuilder()
                .Select("Occupants", "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Occupants, T, Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAs_CustomFrom()
        {
            new AdtQueryBuilder()
                .SelectAs("T.Temperature", "Temp")
                .FromCustom("DigitalTwins T")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature AS Temp FROM DigitalTwins T");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAs_FromAlias()
        {
            new AdtQueryBuilder()
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .From(AdtCollection.DigitalTwins, "T")
                .Where()
                .Compare("T.Temperature", QueryComparisonOperator.GreaterOrEqual, 50)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE T.Temperature >= 50");
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
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void AdtQueryBuilder_Where_Contains()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .NotContains("Location", new string[] { "Paris", "Tokyo", "Madrid", "Prague" })
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void AdtQueryBuilder_Where_Override()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .CustomClause("IS_OF_MODEL('dtmi:example:room;1', exact)")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void AdtQueryBuilder_Where_IsOfModel()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfModel("dtmi:example:room;1", true)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void AdtQueryBuilder_Where_IsBool()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.Relationships)
                .Where()
                .IsOfType("isOccupied", AdtDataType.AdtBool)
                .Build()
                .GetQueryText()
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
                .And()
                .CustomClause("Occupants < 10")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");
        }

        [Test]
        public void AdtQueryBuilder_MultipleNested()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Parenthetical(q => q
                    .IsOfType("Humidity", AdtDataType.AdtNumber)
                    .Or()
                    .IsOfType("Humidity", AdtDataType.AdtPrimative))
                .Or()
                .Parenthetical(q => q
                    .IsOfType("Temperature", AdtDataType.AdtNumber)
                    .Or()
                    .IsOfType("Temperature", AdtDataType.AdtPrimative))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE (IS_NUMBER(Humidity) OR IS_PRIMATIVE(Humidity)) OR (IS_NUMBER(Temperature) OR IS_PRIMATIVE(Temperature))");
        }

        [Test]
        public void AdtQueryBuilder_Select_Null()
        {
            new AdtQueryBuilder()
                .Select(null)
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_EmptyString()
        {
            new AdtQueryBuilder()
                .Select("")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_FromCustom_Null()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .FromCustom(null)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM");
        }

        [Test]
        public void AdtQueryBuilder_FromCustom_EmptyString()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .FromCustom("")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_Null()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfModel(null)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('')");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_Is_Of_Type()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfType(null, AdtDataType.AdtBool)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_BOOL()");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_StartsEndsWith_Null()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .StartsWith(null, null)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE STARTSWITH(, '')");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_ContainsNotContains_Null()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Contains(null, null)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE  IN []");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_Compare_Null()
        {
            new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare(null, QueryComparisonOperator.Equal, 10)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE  = 10");
        }
    }
}

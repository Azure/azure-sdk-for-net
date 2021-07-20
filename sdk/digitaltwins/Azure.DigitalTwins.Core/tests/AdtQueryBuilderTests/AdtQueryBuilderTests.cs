// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests.QueryBuilderTests
{
    public class AdtQueryBuilderTests
    {
        // TODO -- rename all test per new object name
        [Test]
        public void AdtQueryBuilder_Select_AllSimple()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SingleProperty()
        {
            new AdtQuery()
                .Select("Room")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_MultipleProperties()
        {
            new AdtQuery()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Aggregates_Top_All()
        {
            new AdtQuery()
                .SelectTopAll(5)
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Aggregates_Top_Properties()
        {
            new AdtQuery()
                .SelectTop(3, "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void AdtQueryBuilder_Select_Aggregates_Count()
        {
            new AdtQuery()
                .SelectCount()
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_Override()
        {
            new AdtQuery()
                .SelectCustom("TOP(3) Room, Temperature")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAs()
        {
            new AdtQuery()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAsChainedWithSelect()
        {
            new AdtQuery()
                .Select("Occupants", "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT Occupants, T, Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAs_CustomFrom()
        {
            new AdtQuery()
                .SelectAs("T.Temperature", "Temp")
                .FromCustom("DigitalTwins T")
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature AS Temp FROM DigitalTwins T");
        }

        [Test]
        public void AdtQueryBuilder_Select_SelectAs_FromAlias()
        {
            new AdtQuery()
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .From(AdtCollection.DigitalTwins, "T")
                .Compare("T.Temperature", QueryComparisonOperator.GreaterOrEqual, 50)
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE T.Temperature >= 50");
        }

        [Test]
        public void AdtQueryBuilder_From_MultipleFrom()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .From(AdtCollection.Relationships)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void AdtQueryBuilder_Where_Comparison()
        {
            new AdtQuery()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Compare("Temperature", QueryComparisonOperator.GreaterOrEqual, 50)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void AdtQueryBuilder_Where_Contains()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .NotContains("Location", new string[] { "Paris", "Tokyo", "Madrid", "Prague" })
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void AdtQueryBuilder_Where_Override()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .WhereCustom("IS_OF_MODEL('dtmi:example:room;1', exact)")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void AdtQueryBuilder_Where_IsOfModel()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfModel("dtmi:example:room;1", true)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void AdtQueryBuilder_Where_IsBool()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.Relationships)
                .WhereIsOfType("isOccupied", AdtDataType.AdtBool)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships WHERE IS_BOOL(isOccupied)");
        }

        [Test]
        public void AdtQueryBuilder_Where_MultipleWhere()
        {
            new AdtQuery()
                .Select("Temperature")
                .From(AdtCollection.DigitalTwins)
                .WhereIsDefined("Humidity")
                .And()
                .WhereCustom("Occupants < 10")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");
        }

        //[Test]
        //public void AdtQueryBuilder_MultipleNested()
        //{
        //    new AdtQuery()
        //        .SelectAll()
        //        .From(AdtCollection.DigitalTwins)
        //        .Parenthetical(q => q
        //            .WhereIsOfType("Humidity", AdtDataType.AdtNumber)
        //            .Or()
        //            .WhereIsOfType("Humidity", AdtDataType.AdtPrimative))
        //        .Or()
        //        .Parenthetical(q => q
        //            .WhereIsOfType("Temperature", AdtDataType.AdtNumber)
        //            .Or()
        //            .WhereIsOfType("Temperature", AdtDataType.AdtPrimative))
        //        .GetQueryText()
        //        .Should()
        //        .Be("SELECT * FROM DigitalTwins WHERE (IS_NUMBER(Humidity) OR IS_PRIMATIVE(Humidity)) OR (IS_NUMBER(Temperature) OR IS_PRIMATIVE(Temperature))");
        //}

        [Test]
        public void AdtQueryBuilder_Select_Null()
        {
            new AdtQuery()
                .Select(null)
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_Select_EmptyString()
        {
            new AdtQuery()
                .Select("")
                .From(AdtCollection.DigitalTwins)
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void AdtQueryBuilder_FromCustom_Null()
        {
            new AdtQuery()
                .SelectAll()
                .FromCustom(null)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM");
        }

        [Test]
        public void AdtQueryBuilder_FromCustom_EmptyString()
        {
            new AdtQuery()
                .SelectAll()
                .FromCustom("")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_Null()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfModel(null)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('')");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_Is_Of_Type()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfType(null, AdtDataType.AdtBool)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_BOOL()");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_StartsEndsWith_Null()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .WhereStartsWith(null, null)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE STARTSWITH(, '')");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_ContainsNotContains_Null()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Contains(null, null)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE  IN []");
        }

        [Test]
        public void AdtQueryBuilder_WhereLogic_Compare_Null()
        {
            new AdtQuery()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Compare(null, QueryComparisonOperator.Equal, 10)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE  = 10");
        }
    }
}

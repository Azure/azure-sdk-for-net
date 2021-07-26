// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests.QueryBuilderTests
{
    public class DigitalTwinsQueryBuilderTests
    {
        [Test]
        public void DigitalTwinsQueryBuilder_Select_AllSimple()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SingleProperty()
        {
            new DigitalTwinsQueryBuilder()
                .Select("Room")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_AliasedConstructor()
        {
            new DigitalTwinsQueryBuilder(AdtCollection.DigitalTwins, "T")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T FROM DigitalTwins T");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_AliasedConstructorWithSelectArgs()
        {
            new DigitalTwinsQueryBuilder(AdtCollection.DigitalTwins, "T")
                .Select("T.Temperature", "T.Humidity")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity FROM DigitalTwins T");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_MultipleProperties()
        {
            new DigitalTwinsQueryBuilder()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Aggregates_Top_All()
        {
            new DigitalTwinsQueryBuilder()
                .SelectTopAll(5)
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Aggregates_Top_Properties()
        {
            new DigitalTwinsQueryBuilder()
                .SelectTop(3, "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void DigitalTwinsQueryBuilder_Select_Aggregates_Count()
        {
            new DigitalTwinsQueryBuilder()
                .SelectCount()
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Override()
        {
            new DigitalTwinsQueryBuilder()
                .SelectCustom("TOP(3) Room, Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SelectAs()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SelectAsChainedWithSelect()
        {
            new DigitalTwinsQueryBuilder()
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
        public void DigitalTwinsQueryBuilder_Select_SelectAs_CustomFrom()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAs("T.Temperature", "Temp")
                .FromCustom("DigitalTwins T")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature AS Temp FROM DigitalTwins T");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SelectAs_FromAlias()
        {
            new DigitalTwinsQueryBuilder()
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .From(AdtCollection.DigitalTwins, "T")
                .Where(q => q.Compare("T.Temperature", QueryComparisonOperator.GreaterOrEqual, 50))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE T.Temperature >= 50");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_From_MultipleFrom()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .From(AdtCollection.Relationships)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_Comparison()
        {
            new DigitalTwinsQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.Compare("Temperature", QueryComparisonOperator.GreaterOrEqual, 50))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_Contains()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.NotContains("Location", new string[] { "Paris", "Tokyo", "Madrid", "Prague" }))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_Override()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.Custom("IS_OF_MODEL('dtmi:example:room;1', exact)"))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_IsOfModel()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1", true))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_IsBool()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.Relationships)
                .Where(q => q.IsOfType("isOccupied", AdtDataType.AdtBool))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships WHERE IS_BOOL(isOccupied)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_MultipleWhere()
        {
            new DigitalTwinsQueryBuilder()
                .Select("Temperature")
                .From(AdtCollection.DigitalTwins)
                .Where(q => q
                    .IsDefined("Humidity")
                    .And()
                    .Custom("Occupants < 10"))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_MultipleNested()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q
                    .Parenthetical(q => q
                        .IsOfType("Humidity", AdtDataType.AdtNumber)
                        .Or()
                        .IsOfType("Humidity", AdtDataType.AdtPrimitive))
                    .Or()
                    .Parenthetical(q => q
                        .IsOfType("Temperature", AdtDataType.AdtNumber)
                        .Or()
                        .IsOfType("Temperature", AdtDataType.AdtPrimitive)))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE (IS_NUMBER(Humidity) OR IS_PRIMITIVE(Humidity)) OR (IS_NUMBER(Temperature) OR IS_PRIMITIVE(Temperature))");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_NestedAnd()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q
                    .IsOfModel("dtmi:example:room;1")
                    .And(q => q
                        .IsDefined("Temperature")
                        .And()
                        .Compare("Temperature", QueryComparisonOperator.Equal, 30)))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1') AND (IS_DEFINED(Temperature) AND Temperature = 30)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_NestedOr()
        {
            new DigitalTwinsQueryBuilder()
                .SelectCount()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q
                    .Custom("Humidity < 10")
                    .Or(q => q
                        .Compare("Temperature", QueryComparisonOperator.LessThan, 40)
                        .And()
                        .IsOfType("Temperature", AdtDataType.AdtNumber)))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins WHERE Humidity < 10 OR (Temperature < 40 AND IS_NUMBER(Temperature))");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Null()
        {
            new DigitalTwinsQueryBuilder()
                .Select(null)
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_EmptyString()
        {
            new DigitalTwinsQueryBuilder()
                .Select("")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_FromCustom_Null()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .FromCustom(null)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_FromCustom_EmptyString()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .FromCustom("")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_Null()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.IsOfModel(null))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('')");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_Is_Of_Type()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.IsOfType(null, AdtDataType.AdtBool))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_BOOL()");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_StartsEndsWith_Null()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.StartsWith(null, null))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE STARTSWITH(, '')");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_ContainsNotContains_Null()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.Contains(null, null))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IN []");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_Compare_Null()
        {
            new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where(q => q.Compare(null, QueryComparisonOperator.Equal, 10))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE = 10");
        }
    }
}

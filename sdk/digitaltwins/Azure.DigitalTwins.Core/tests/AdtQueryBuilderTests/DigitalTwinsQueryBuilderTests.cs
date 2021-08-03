// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SingleProperty()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("Room")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_AliasedConstructor()
        {
            new DigitalTwinsQueryBuilderMethodDriven(DigitalTwinsCollection.DigitalTwins, "T")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T FROM DigitalTwins T");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_AliasedConstructorWithSelectArgs()
        {
            new DigitalTwinsQueryBuilderMethodDriven(DigitalTwinsCollection.DigitalTwins, "T")
                .Select("T.Temperature", "T.Humidity")
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity FROM DigitalTwins T");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_MultipleProperties()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Aggregates_Top_All()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectTopAll(5)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Aggregates_Top_Properties()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectTop(3, "Temperature", "Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void DigitalTwinsQueryBuilder_Select_Aggregates_Count()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectCount()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Override()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectCustom("TOP(3) Room, Temperature")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SelectAs()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SelectAsChainedWithSelect()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("Occupants", "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT Occupants, T, Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_SelectAs_CustomFrom()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
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
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Where(q => q.Compare("T.Temperature", QueryComparisonOperator.GreaterOrEqual, 50))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE T.Temperature >= 50");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_From_MultipleFrom()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .From(DigitalTwinsCollection.Relationships)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_Comparison()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("*")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Compare("Temperature", QueryComparisonOperator.GreaterOrEqual, 50))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_Contains()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.NotContains("Location", new string[] { "Paris", "Tokyo", "Madrid", "Prague" }))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_Override()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Custom("IS_OF_MODEL('dtmi:example:room;1', exact)"))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_IsOfModel()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1", true))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_IsBool()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.Relationships)
                .Where(q => q.IsOfType("isOccupied", DigitalTwinsDataType.DigitalTwinsBool))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships WHERE IS_BOOL(isOccupied)");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Where_MultipleWhere()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("Temperature")
                .From(DigitalTwinsCollection.DigitalTwins)
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
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Precedence(q => q
                        .IsOfType("Humidity", DigitalTwinsDataType.DigitalTwinsNumber)
                        .Or()
                        .IsOfType("Humidity", DigitalTwinsDataType.DigitalTwinsPrimative))
                    .Or()
                    .Precedence(q => q
                        .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber)
                        .Or()
                        .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsPrimative)))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE (IS_NUMBER(Humidity) OR IS_PRIMITIVE(Humidity)) OR (IS_NUMBER(Temperature) OR IS_PRIMITIVE(Temperature))");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_NestedAnd()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
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
            new DigitalTwinsQueryBuilderMethodDriven()
                .SelectCount()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Custom("Humidity < 10")
                    .Or(q => q
                        .Compare("Temperature", QueryComparisonOperator.LessThan, 40)
                        .And()
                        .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber)))
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins WHERE Humidity < 10 OR (Temperature < 40 AND IS_NUMBER(Temperature))");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_Null()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select(null)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_Select_EmptyString()
        {
            new DigitalTwinsQueryBuilderMethodDriven()
                .Select("")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void DigitalTwinsQueryBuilder_FromCustom_Null_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .FromCustom(null)
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void DigitalTwinsQueryBuilder_FromCustom_EmptyString_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .FromCustom("")
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_Null_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel(null))
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_Is_Of_Type_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfType(null, DigitalTwinsDataType.DigitalTwinsBool))
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_StartsEndsWith_Null_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.StartsWith(null, null))
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_ContainsNotContains_Null_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Contains(null, null))
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void DigitalTwinsQueryBuilder_WhereLogic_Compare_Null_Throws()
        {
            Func<string> act = () => new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Compare(null, QueryComparisonOperator.Equal, 10))
                .Build()
                .GetQueryText();

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Select_NonGeneric()
        {
            new DigitalTwinsQueryBuilderLinqDriven().ToString().Should().Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void Select_SingeProperty_NonGeneric()
        {
            new DigitalTwinsQueryBuilderLinqDriven()
                .Select("Room")
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void Where_NonGeneric()
        {
            new DigitalTwinsQueryBuilderLinqDriven()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");

            new DigitalTwinsQueryBuilderLinqDriven()
                .Where($"Temperature >= {50}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");

            string[] cities = new string[] { "Paris", "Tokyo", "Madrid", "Prague" };
            new DigitalTwinsQueryBuilderLinqDriven()
                .Where($"Location NIN {cities}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void Select_AllSimple()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().ToString().Should().Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void Select_SingleProperty()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Room")
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Room)
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAllRelationships()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void Select_MultipleProperties()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Room, r => r.Factory, r => r.Temperature, r => r.Humidity)
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");

            var digitalTwinsQuery = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>();
            digitalTwinsQuery = digitalTwinsQuery.Select("Room", "Factory", "Temperature", "Humidity");
            digitalTwinsQuery
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAsWithoutLinq()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Humidity")
                .SelectAs("Room", "R")
                .SelectAs("Temperature", "Temp")
                .Select("Factory")
                .ToString()
                .Should()
                .Be("SELECT Humidity, Room AS R, Temperature AS Temp, Factory FROM DigitalTwins");
        }

        [Test]
        public void Select_Aggregates_Top_All()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Take(5)
                .ToString()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");
        }

        [Test]
        public void Select_Aggregates_Top_Properties()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Temperature", "Humidity")
                .Take(3)
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Temperature, r => r.Humidity)
                .Take(3)
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void Select_Aggregates_Count()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Count()
                .ToString()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void Select_Override()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .SelectCustom("TOP(3) Room, Temperature")
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAs()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAsChainedWithSelect()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Occupants", "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .GetQueryText()
                .Should()
                .Be("SELECT Occupants, T, Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAs_CustomFrom()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>("DigitalTwins T")
                .SelectAs("T.Temperature", "Temp")
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature AS Temp FROM DigitalTwins T");
        }

        [Test]
        public void Select_SelectAs_FromAlias()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>(DigitalTwinsCollection.DigitalTwins, "T")
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .Where(r => r.Temperature >= 50)
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE Temperature >= 50");
        }

        [Test]
        public void From_FromAlias()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Where(r => r.Temperature >= 50)
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE Temperature >= 50");
        }

        [Test]
        public void From_FromCustom()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("T.Temperature")
                .SelectAs("T.Humidity", "Hum")
                .FromCustom("DigitalTwins T")
                .Where(r => r.Temperature >= 50)
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature, T.Humidity AS Hum FROM DigitalTwins T WHERE Temperature >= 50");
        }

        [Test]
        public void From_OverrideConstructor()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .From(DigitalTwinsCollection.Relationships)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void Where_Comparison()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where($"Temperature >= {50}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => r.Temperature >= 50)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void Where_Contains()
        {
            string city = "Paris";
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where($"Location NIN [{city}, 'Tokyo', 'Madrid', 'Prague']")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");

            string[] cities = new string[] { "Paris", "Tokyo", "Madrid", "Prague" };
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where($"Location NIN {cities}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void Where_Override()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .WhereCustom($"IS_OF_MODEL('dtmi:example:room;1', exact)")
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void Where_IsOfModel()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1"))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1')");
        }

        [Test]
        public void Where_IsBool()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsBool(r.IsOccupied))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_BOOL(IsOccupied)");
        }

        [Test]
        public void Where_IsDefined()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Temperature))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_DEFINED(Temperature)");
        }

        [Test]
        public void Where_IsPrimitive()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
               .Where(r => DigitalTwinsFunctions.IsPrimitive(r.Temperature))
               .ToString()
               .Should()
               .Be("SELECT * FROM DigitalTwins WHERE IS_PRIMITIVE(Temperature)");
        }

        [Test]
        public void Where_IsNumber()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
               .Where(r => DigitalTwinsFunctions.IsNumber(r.Temperature))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_NUMBER(Temperature)");
        }

        [Test]
        public void Where_IsString()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsString(r.Factory))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_STRING(Factory)");
        }

        [Test]
        public void Where_IsObject()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsObject(r.Factory))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OBJECT(Factory)");
        }

        [Test]
        public void Where_IsNull()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsNull(r.Temperature))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_NULL(Temperature)");
        }

        [Test]
        public void Where_MultipleWhere()
        {
            int count = 10;
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Temperature")
                .Where($"IS_DEFINED(Humidity) AND Occupants < {count}")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Temperature")
                .Where($"IS_DEFINED(Humidity)")
                .Where($"Occupants < {count}")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Temperature)
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Humidity) && r.Occupants < 10)
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");
        }

        [Test]
        public void Where_StartEndsWith()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.StartsWith(r.Room, "3"))
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE STARTSWITH(Room, '3')");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => r.Room.EndsWith("3"))
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE ENDSWITH(Room, '3')");
        }

        [Test]
        public void MultipleNested()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => (DigitalTwinsFunctions.IsNumber(r.Humidity) || DigitalTwinsFunctions.IsPrimitive(r.Humidity))
                    || (DigitalTwinsFunctions.IsNumber(r.Temperature) || DigitalTwinsFunctions.IsPrimitive(r.Temperature)))
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE " +
                "(IS_NUMBER(Humidity) OR IS_PRIMITIVE(Humidity)) OR " +
                "(IS_NUMBER(Temperature) OR IS_PRIMITIVE(Temperature))");

            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
               .Where(r => (DigitalTwinsFunctions.IsNumber(r.Humidity) || DigitalTwinsFunctions.IsPrimitive(r.Humidity)) &&
                   (DigitalTwinsFunctions.IsNumber(r.Temperature) || DigitalTwinsFunctions.IsPrimitive(r.Temperature)))
               .GetQueryText()
               .Should()
               .Be("SELECT * FROM DigitalTwins WHERE " +
               "(IS_NUMBER(Humidity) OR IS_PRIMITIVE(Humidity)) AND " +
               "(IS_NUMBER(Temperature) OR IS_PRIMITIVE(Temperature))");
        }

        [Test]
        public void Select_EmptyString()
        {
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("")
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void FromCustom_Null()
        {
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act = () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Where_StartsEndsWith_Null()
        {
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act = () =>
                new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                    .Where(r => DigitalTwinsFunctions
                    .StartsWith(null, null));

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Where_IsOfModel_Null()
        {
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act1 = () =>
                new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                    .Where(r => DigitalTwinsFunctions.IsOfModel(null));

            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act2 = () =>
                new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                    .Where(r => DigitalTwinsFunctions.IsOfModel(null, true));

            act1.Should().Throw<InvalidOperationException>();
            act2.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Where_IsOfType_Null()
        {
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>>[] funcs = new Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>>[]
            {
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsString(null)),
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsDefined(null)),
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsObject(null)),
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsBool(null)),
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsPrimitive(null)),
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsNull(null)),
                () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsNumber(null)),
            };

            foreach (Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> func in funcs)
            {
                func.Should().Throw<InvalidOperationException>();
            }
        }

        [Test]
        public void Where_ContainsNotContains_Null()
        {
            string[] cities = null;
            string property = null;
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act = () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where($"{property} NIN {cities}");
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Where_Comparison_Null()
        {
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act = () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Where($"Temperature >= {null}");
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Select_Null()
        {
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act1 = () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().SelectCustom(null);
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act2 = () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().SelectAs(null, null);
            Func<DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>> act3 = () => new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>().Select(r => null);

            act1.Should().Throw<ArgumentNullException>();
            act2.Should().Throw<ArgumentNullException>();
            act3.Should().Throw<InvalidOperationException>();
        }
    }
}

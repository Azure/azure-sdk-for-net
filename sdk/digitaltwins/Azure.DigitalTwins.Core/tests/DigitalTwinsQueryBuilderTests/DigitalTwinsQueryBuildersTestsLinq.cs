// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.QueryBuilder.Linq;
using Azure.DigitalTwins.Core.Tests.QueryBuilderTests;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests.AdtQueryBuilderTests
{
    public class DigitalTwinsQueryBuildersTestsLinq
    {
        [Test]
        public void Select_NonGeneric()
        {
            new DigitalTwinsQueryBuilder().ToString().Should().Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void Select_SingeProperty_NonGeneric()
        {
            new DigitalTwinsQueryBuilder()
                .Select("Room")
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void Where_NonGeneric()
        {
            new DigitalTwinsQueryBuilder()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");

            new DigitalTwinsQueryBuilder()
                .Where($"Temperature >= {50}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");

            string[] cities = new string[] { "Paris", "Tokyo", "Madrid", "Prague" };
            new DigitalTwinsQueryBuilder()
                .Where($"Location NIN {cities}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void Select_AllSimple()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>().ToString().Should().Be("SELECT * FROM DigitalTwins");
        }

        [Test]
        public void Select_SingleProperty()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("Room")
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Room)
                .ToString()
                .Should()
                .Be("SELECT Room FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAllRelationships()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void Select_MultipleProperties()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("Room", "Factory", "Temperature", "Humidity")
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Room, r => r.Factory, r => r.Temperature, r => r.Humidity)
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");

            var digitalTwinsQuery = new DigitalTwinsQueryBuilder<ConferenceRoom>();
            digitalTwinsQuery = digitalTwinsQuery.Select("Room", "Factory", "Temperature", "Humidity");
            digitalTwinsQuery
                .ToString()
                .Should()
                .Be("SELECT Room, Factory, Temperature, Humidity FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAsWithoutLinq()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
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
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Take(5)
                .ToString()
                .Should()
                .Be("SELECT TOP(5) FROM DigitalTwins");
        }

        [Test]
        public void Select_Aggregates_Top_Properties()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("Temperature", "Humidity")
                .Take(3)
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Temperature, r => r.Humidity)
                .Take(3)
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Temperature, Humidity FROM DigitalTwins");
        }

        public void Select_Aggregates_Count()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Count()
                .ToString()
                .Should()
                .Be("SELECT COUNT() FROM DigitalTwins");
        }

        [Test]
        public void Select_Override()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .SelectCustom("TOP(3) Room, Temperature")
                .ToString()
                .Should()
                .Be("SELECT TOP(3) Room, Temperature FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAs()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature AS Temp, Humidity AS Hum FROM DigitalTwins");
        }

        [Test]
        public void Select_SelectAsChainedWithSelect()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
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
            new DigitalTwinsQueryBuilder<ConferenceRoom>("DigitalTwins T")
                .SelectAs("T.Temperature", "Temp")
                .GetQueryText()
                .Should()
                .Be("SELECT T.Temperature AS Temp FROM DigitalTwins T");
        }

        [Test]
        public void Select_SelectAs_FromAlias()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>(DigitalTwinsCollection.DigitalTwins, "T")
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
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
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
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
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
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .From(DigitalTwinsCollection.Relationships)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM Relationships");
        }

        [Test]
        public void Where_Comparison()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where($"Temperature >= {50}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => r.Temperature >= 50)
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Temperature >= 50");
        }

        [Test]
        public void Where_Contains()
        {
            string city = "Paris";
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where($"Location NIN [{city}, 'Tokyo', 'Madrid', 'Prague']")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");

            string[] cities = new string[] { "Paris", "Tokyo", "Madrid", "Prague" };
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where($"Location NIN {cities}")
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE Location NIN ['Paris', 'Tokyo', 'Madrid', 'Prague']");
        }

        [Test]
        public void Where_Override()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .WhereCustom($"IS_OF_MODEL('dtmi:example:room;1', exact)")
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");
        }

        [Test]
        public void Where_IsOfModel()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1"))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1')");
        }

        [Test]
        public void Where_IsBool()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsBool(r.IsOccupied))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_BOOL(IsOccupied)");
        }

        [Test]
        public void Where_IsDefined()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Temperature))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_DEFINED(Temperature)");
        }

        [Test]
        public void Where_IsPrimitive()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
               .Where(r => DigitalTwinsFunctions.IsPrimitive(r.Temperature))
               .ToString()
               .Should()
               .Be("SELECT * FROM DigitalTwins WHERE IS_PRIMITIVE(Temperature)");
        }

        [Test]
        public void Where_IsNumber()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
               .Where(r => DigitalTwinsFunctions.IsNumber(r.Temperature))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_NUMBER(Temperature)");
        }

        [Test]
        public void Where_IsString()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsString(r.Factory))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_STRING(Factory)");
        }

        [Test]
        public void Where_IsObject()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsObject(r.Factory))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_OBJECT(Factory)");
        }

        [Test]
        public void Where_IsNull()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsNull(r.Temperature))
                .ToString()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE IS_NULL(Temperature)");
        }

        [Test]
        public void Where_MultipleWhere()
        {
            int count = 10;
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("Temperature")
                .Where($"IS_DEFINED(Humidity) AND Occupants < {count}")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("Temperature")
                .Where($"IS_DEFINED(Humidity)")
                .Where($"Occupants < {count}")
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Temperature)
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Humidity) && r.Occupants < 10)
                .GetQueryText()
                .Should()
                .Be("SELECT Temperature FROM DigitalTwins WHERE IS_DEFINED(Humidity) AND Occupants < 10");
        }

        [Test]
        public void Where_StartEndsWith()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.StartsWith(r.Room, "3"))
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE STARTSWITH(Room, '3')");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => r.Room.EndsWith("3"))
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE ENDSWITH(Room, '3')");
        }

        [Test]
        public void MultipleNested()
        {
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => (DigitalTwinsFunctions.IsNumber(r.Humidity) || DigitalTwinsFunctions.IsPrimitive(r.Humidity))
                    || (DigitalTwinsFunctions.IsNumber(r.Temperature) || DigitalTwinsFunctions.IsPrimitive(r.Temperature)))
                .GetQueryText()
                .Should()
                .Be("SELECT * FROM DigitalTwins WHERE " +
                "(IS_NUMBER(Humidity) OR IS_PRIMITIVE(Humidity)) OR " +
                "(IS_NUMBER(Temperature) OR IS_PRIMITIVE(Temperature))");

            new DigitalTwinsQueryBuilder<ConferenceRoom>()
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
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("")
                .GetQueryText()
                .Should()
                .Be("SELECT  FROM DigitalTwins");
        }

        [Test]
        public void FromCustom_Null()
        {
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act = () => new DigitalTwinsQueryBuilder<ConferenceRoom>(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Where_StartsEndsWith_Null()
        {
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act = () =>
                new DigitalTwinsQueryBuilder<ConferenceRoom>()
                    .Where(r => DigitalTwinsFunctions
                    .StartsWith(null, null));

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Where_IsOfModel_Null()
        {
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act1 = () =>
                new DigitalTwinsQueryBuilder<ConferenceRoom>()
                    .Where(r => DigitalTwinsFunctions.IsOfModel(null));

            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act2 = () =>
                new DigitalTwinsQueryBuilder<ConferenceRoom>()
                    .Where(r => DigitalTwinsFunctions.IsOfModel(null, true));

            act1.Should().Throw<InvalidOperationException>();
            act2.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Where_IsOfType_Null()
        {
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>>[] funcs = new Func<DigitalTwinsQueryBuilder<ConferenceRoom>>[]
            {
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsString(null)),
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsDefined(null)),
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsObject(null)),
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsBool(null)),
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsPrimitive(null)),
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsNull(null)),
                () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where(r => DigitalTwinsFunctions.IsNumber(null)),
            };

            foreach (Func<DigitalTwinsQueryBuilder<ConferenceRoom>> func in funcs)
            {
                func.Should().Throw<InvalidOperationException>();
            }
        }

        [Test]
        public void Where_ContainsNotContains_Null()
        {
            string[] cities = null;
            string property = null;
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act = () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where($"{property} NIN {cities}");
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Where_Comparison_Null()
        {
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act = () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Where($"Temperature >= {null}");
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Select_Null()
        {
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act1 = () => new DigitalTwinsQueryBuilder<ConferenceRoom>().SelectCustom(null);
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act2 = () => new DigitalTwinsQueryBuilder<ConferenceRoom>().SelectAs(null, null);
            Func<DigitalTwinsQueryBuilder<ConferenceRoom>> act3 = () => new DigitalTwinsQueryBuilder<ConferenceRoom>().Select(r => null);

            act1.Should().Throw<ArgumentNullException>();
            act2.Should().Throw<ArgumentNullException>();
            act3.Should().Throw<InvalidOperationException>();
        }
    }
}

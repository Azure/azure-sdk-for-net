// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.QueryBuilder.Linq;

namespace Azure.DigitalTwins.Core.Samples.QueryBuilders
{
    public class QueryBuilderSamplesLinq
    {
        public static void DigitalTwinsQueryBuilderLinqDrivenSamples()
        {
            #region Snippet:DigitalTwinsQueryBuilderNonGeneric
            // Note that if no Select() method, SELECT("*") is the default
            new DigitalTwinsQueryBuilder().Build();
            new DigitalTwinsQueryBuilder<BasicDigitalTwin>().Build();

            // SELECT * FROM DigitalTwins
            new DigitalTwinsQueryBuilder().Build().GetQueryText();
            new DigitalTwinsQueryBuilder<BasicDigitalTwin>().Build().GetQueryText();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressionBenefits
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // Note how C# operators like == can be used directly in the Where() method
            // SELECT * FROM DigitalTwins WHERE Temperature = 50
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => r.Temperature == 50)
                .Build();
            #endregion

            // SELECT * FROM DigitalTwins
            DigitalTwinsQueryBuilder<BasicDigitalTwin> simplestQueryLinq = new DigitalTwinsQueryBuilder().Build();

            // SELECT * FROM Relationsips
            DigitalTwinsQueryBuilder<BasicDigitalTwin> simplestQueryRelationshipsLinq = new DigitalTwinsQueryBuilder(DigitalTwinsCollection.Relationships)
                .Build();

            // Use LINQ expressions to select defined properties in type T of DigitalTwinsQueryBuilder
            // SELECT Temperature From DigitalTwins
            DigitalTwinsQueryBuilder<ConferenceRoom> selectSingleProperty = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Temperature)
                .Build();

            // Note that SelectTop() and SelectTopAll() are replaced with Take()
            // SELECT TOP(3) FROM DIGITALTWINS
            DigitalTwinsQueryBuilder<ConferenceRoom> queryWithSelectTopLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Take(3)
                .Build();

            // Strings are valid ways to denote selectable properties as an alternative to LINQ expressions
            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilder<ConferenceRoom> queryWithSelectTopPropertyLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select("Temperature", "Humidity")
                .Take(3)
                .Build();

            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilder<ConferenceRoom> queryWithSelectRelationshipsLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .Count()
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilder<ConferenceRoom> queryWithIsOfModelLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1"))
                .Build();

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressionsFunctions
            // SELECT * FROM DigitalTwins WHERE IS_DEFINED(Temperature)
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Temperature))
                .Build();

            // SELECT * FROM DigitalTwins WHERE IS_BOOL(IsOccupied)
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsBool(r.IsOccupied))
                .Build();

            // If no properties of type T are needed, use an underscore in the LINQ expression
            // SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .Build();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderFromMethodLinqExpressions
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // pass in an optional string as a second parameter of From() to alias a collection
            // SELECT Temperature FROM DigitalTwins T
            new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();

            // Override the queryable collection set in the constructor with any From() method
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilder<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .Select(r => r.Temperature)
                .FromCustom("DigitalTwins")
                .Build();
            #endregion

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilder<BasicDigitalTwin> queryWithMultiplePropertiesLinq = new DigitalTwinsQueryBuilder()
                .Select("Room", "Temperature")
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilder<ConferenceRoom> queryWithComparisonWhereClauseLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => r.Temperature < 5)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilder<BasicDigitalTwin> queryWithIsOfModelExactLinq = new DigitalTwinsQueryBuilder()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilder<ConferenceRoom> logicalOps_SingleAndLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => r.Temperature == 50 && DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true)).Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilder<ConferenceRoom> logicalOps_SingleOrLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r => (r.Temperature == 50 || DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true)) && r.IsOccupied == true).Build();

            #region Snippet:DigitalTwinsQueryBuilder_ComplexConditionsLinqExpressions
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilder<ConferenceRoom> logicalOps_MultipleOrLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(r =>
                    r.Temperature == 50 ||
                    DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true) ||
                    DigitalTwinsFunctions.IsNumber(r.Temperature))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
            // OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
            DigitalTwinsQueryBuilder<ConferenceRoom> logicalOpsNestedLinq = new DigitalTwinsQueryBuilder<ConferenceRoom>()
                .Where(
                    r =>
                        (
                            DigitalTwinsFunctions.IsNumber(r.Humidity)
                            ||
                            DigitalTwinsFunctions.IsDefined(r.Humidity)
                        )
                        &&
                        DigitalTwinsFunctions.IsOfModel("dtmi:example:hvac;1")
                        &&
                        DigitalTwinsFunctions.IsNull(r.Occupants)
                    )
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilderOverrideLinqExpressions
            // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
            new DigitalTwinsQueryBuilder()
            .SelectCustom("TOP(3) Room, Temperature")
            .Build();
            #endregion

            // SELECT Temperature AS Temp, Humidity AS HUM FROM DigitalTwins
            DigitalTwinsQueryBuilder<BasicDigitalTwin> selectAsSampleLinq = new DigitalTwinsQueryBuilder(DigitalTwinsCollection.DigitalTwins, "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .Build();

            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilder<BasicDigitalTwin> selectAndSelectAsLinq = new DigitalTwinsQueryBuilder()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// Samples for QueryBuilder.
    /// </summary>
    public static class QueryBuilderSamples
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            #region Snippet:DigitalTwinsQueryBuilder

            // SELECT * FROM DIGITALTWINS
            DigitalTwinsQueryBuilderV1 simplestQuery = new DigitalTwinsQueryBuilderV1().Select("*").From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT * FROM DIGITALTWINS
            // Note that the this is the same as the previous query, just with the pre-built SelectAll() method that can be used
            // interchangeably with Select("*")
            DigitalTwinsQueryBuilderV1 simplestQuerySelectAll = new DigitalTwinsQueryBuilderV1().SelectAll().From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            // Note that if no property is specified, the SelectTopAll() method can be used instead of SelectTop()
            DigitalTwinsQueryBuilderV1 queryWithSelectTop = new DigitalTwinsQueryBuilderV1()
                .SelectTopAll(3)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilderV1 queryWithSelectTopProperty = new DigitalTwinsQueryBuilderV1()
                .SelectTop(3, "Temperature", "Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilderV1 queryWithSelectRelationships = new DigitalTwinsQueryBuilderV1()
                .SelectCount()
                .From(DigitalTwinsCollection.Relationships)
                .Build();


            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilderV1 queryWithIsOfModel = new DigitalTwinsQueryBuilderV1()
                .Select("*")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1"))
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderToString

            string basicQueryStringFormat = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilderV1 queryWithMultipleProperties = new DigitalTwinsQueryBuilderV1()
                .Select("Room", "Temperature")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilderV1 queryWithComparisonWhereClause = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Compare("Temperature", QueryComparisonOperator.LessThan, 5))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilderV1 queryWithIsOfModelExact = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderV1 logicalOps_SingleAnd = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .And()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderV1 logicalOps_SingleOr = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            #region Snippet:DigitalTwinsQueryBuilder_ComplexConditions
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilderV1 logicalOps_MultipleOr = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true)
                    .Or()
                    .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
            // OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
            DigitalTwinsQueryBuilderV1 logicalOpsNested = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Precedence(q => q
                        .IsOfType("Humidity", DigitalTwinsDataType.DigitalTwinsNumber)
                        .Or()
                        .IsDefined("Humidity"))
                .And()
                .Precedence(q => q
                    .IsOfModel("dtmi:example:hvac;1")
                    .And()
                    .IsNull("Occupants")))
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilderOverride
            // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
            new DigitalTwinsQueryBuilderV1()
            .SelectCustom("TOP(3) Room, Temperature")
            .From(DigitalTwinsCollection.DigitalTwins)
            .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_SubjectiveConditionsWorkaround
            // SELECT * FROM DIGITALTWINS WHERE (Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)) AND IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilderV1 subjectiveLogicalOps = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true)
                    .And()
                    .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            DigitalTwinsQueryBuilderV1 objectiveLogicalOps = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Precedence(q => q
                        .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                        .Or()
                        .IsOfModel("dtmi:example:room;1", true))
                .And()
                .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_Aliasing
            // SELECT Temperature AS Temp, Humidity AS HUM FROM DigitalTwins
            DigitalTwinsQueryBuilderV1 selectAsSample = new DigitalTwinsQueryBuilderV1()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilderV1 selectAndSelectAs = new DigitalTwinsQueryBuilderV1()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT T FROM DigitalTwins T
            DigitalTwinsQueryBuilderV1 anotherSelectAsSample = new DigitalTwinsQueryBuilderV1()
                .Select("T")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();


            // SELECT T.Temperature, T.Humdity FROM DigitalTwins T
            DigitalTwinsQueryBuilderV1 collectionAliasing = new DigitalTwinsQueryBuilderV1()
                .Select("T.Temperature", "T.Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT T.Temperature AS Temp, T.Humidity AS Hum FROM DigitalTwins T
            // WHERE T.Temerpature = 50 AND T.Humidity = 30
            DigitalTwinsQueryBuilderV1 bothAliasingTypes = new DigitalTwinsQueryBuilderV1()
                .SelectAs("T.Temperature", "Temp")
                .SelectAs("T.Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Where(q => q
                    .Compare("T.Temperature", QueryComparisonOperator.Equal, 50)
                    .And()
                    .Compare("T.Humidity", QueryComparisonOperator.Equal, 30))
                .Build();

            #endregion
        }
    }
}

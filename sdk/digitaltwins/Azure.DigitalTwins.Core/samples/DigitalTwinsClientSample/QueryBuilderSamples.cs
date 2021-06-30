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
            AdtQueryBuilder simplestQuery = new AdtQueryBuilder().Select("*").From(AdtCollection.DigitalTwins).Build();

            // SELECT * FROM DIGITALTWINS
            // Note that the this is the same as the previous query, just with the prebuilt SelectAll() method that can be used
            // interchangeably with Select("*")
            AdtQueryBuilder simplestQuerySelectAll = new AdtQueryBuilder().SelectAll().From(AdtCollection.DigitalTwins).Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            // Note that if no property is specfied, the SelectTopAll() method can be used instead of SelectTop()
            AdtQueryBuilder queryWithSelectTop = new AdtQueryBuilder()
                .SelectTopAll(3)
                .From(AdtCollection.DigitalTwins)
                .Build();

            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            AdtQueryBuilder queryWithSelectTopProperty = new AdtQueryBuilder()
                .SelectTop(3, "Temperature", "Humidity")
                .From(AdtCollection.DigitalTwins)
                .Build();

            // SELECT COUNT() FROM RELATIONSHIPS
            AdtQueryBuilder queryWithSelectRelationships = new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.Relationships)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            AdtQueryBuilder queryWithIsOfModel = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfModel("dtmi:example:room;1")
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderToString

            string basicQueryStringFormat = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Build()
                .GetQueryText();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            AdtQueryBuilder queryWithMultipleProperties = new AdtQueryBuilder()
                .Select("Room", "Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            AdtQueryBuilder queryWithComparisonWhereClause = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.LessThan, 5)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            AdtQueryBuilder queryWithIsOfModelExact = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfModel("dtmi:example:room;1", true)
                .Build();
            
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            AdtQueryBuilder logicalOps_SingleAnd = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .And()
                .IsOfModel("dtmi:example:room;1", true)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            AdtQueryBuilder logicalOps_SingleOr = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .Or()
                .IsOfModel("dtmi:example:room;1", true)
                .Build();

            #region Snippet:DigitalTwinsQueryBuilder_ComplexConditions
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
            AdtQueryBuilder logicalOps_MultipleOr = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .Or()
                .IsOfModel("dtmi:example:room;1", true)
                .Or()
                .IsOfType("Temperature", AdtDataType.AdtNumber)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
            // OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
            AdtQueryBuilder logicalOpsNested = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Parenthetical(q => q
                    .IsOfType("Humidity", AdtDataType.AdtNumber)
                    .Or()
                    .IsDefined("Humidity"))
                .And()
                .Parenthetical(q => q
                    .IsOfModel("dtmi:example:hvac;1")
                    .And()
                    .IsNull("Occupants"))
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilderOverride
            // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
            new AdtQueryBuilder()
            .SelectCustom("TOP(3) Room, Temperature")
            .From(AdtCollection.DigitalTwins)
            .Build();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_SubjectiveConditionsWorkaround
            // SELECT * FROM DIGITALTWINS WHERE (Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)) AND IS_NUMBER(Temperature)
            AdtQueryBuilder subjectiveLogicalOps = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .Or()
                .IsOfModel("dtmi:example:room;1", true)
                .And()
                .IsOfType("Temperature", AdtDataType.AdtNumber)
                .Build();

            AdtQueryBuilder objectiveLogicalOps = new AdtQueryBuilder()
                .SelectAll()
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Parenthetical(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true))
                .And()
                .IsOfType("Temperature", AdtDataType.AdtNumber)
                .Build();
            #endregion
        }
    }
}

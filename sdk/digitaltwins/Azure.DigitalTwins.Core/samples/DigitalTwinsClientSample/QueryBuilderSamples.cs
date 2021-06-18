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

            // SELECT TOP(3) FROM DIGITALTWINS
            AdtQueryBuilder queryWithSelectTop = new AdtQueryBuilder()
                .SelectTop(3)
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
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            AdtQueryBuilder queryWithMultipleProperties = new AdtQueryBuilder()
                .Select("Room", "Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            AdtQueryBuilder queryWithComparisonWhereClause = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .Compare("Temperature", QueryComparisonOperator.LessThan, 5)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            AdtQueryBuilder queryWithIsOfModelExact = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where()
                .IsOfModel("dtmi:example:room;1", true)
                .Build();
        }
    }
}

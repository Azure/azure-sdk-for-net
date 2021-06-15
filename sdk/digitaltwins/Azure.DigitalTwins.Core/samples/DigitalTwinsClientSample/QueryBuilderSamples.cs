// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.Queries.QueryBuilders;
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
            AdtQueryBuilder sample1 = new AdtQueryBuilder().Select("*").From(AdtCollection.DigitalTwins).Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            AdtQueryBuilder sample2 = new AdtQueryBuilder()
                .SelectTop(3)
                .From(AdtCollection.DigitalTwins)
                .Build();

            // SELECT COUNT() FROM RELATIONSHIPS
            AdtQueryBuilder sample3 = new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.Relationships)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            AdtQueryBuilder sample4 = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfModel("dtmi:example:room;1")
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderToString

            string string1 = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Build()
                .Stringify();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            AdtQueryBuilder query5 = new AdtQueryBuilder()
                .Select("Room", "Temperature")
                .From(AdtCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            AdtQueryBuilder query6 = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .WhereComparison("Temperature", QueryComparisonOperator.LessThan, "6")
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            AdtQueryBuilder query7 = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfModel("dtmi:example:room;1", true)
                .Build();
        }
    }
}

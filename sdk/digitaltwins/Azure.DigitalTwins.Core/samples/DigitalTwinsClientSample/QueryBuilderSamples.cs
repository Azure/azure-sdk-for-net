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
        public static void main()
        {
            // SELECT * FROM DIGITALTWINS
            AdtQueryBuilder query1 = new AdtQueryBuilder().Select("*").From(AdtCollection.DIGITALTWINS).Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("Room")
            AdtQueryBuilder query2 = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DIGITALTWINS)
                .WhereIsOfModel("Room")
                .Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            AdtQueryBuilder query3 = new AdtQueryBuilder()
                .SelectTop(3)
                .From(AdtCollection.DIGITALTWINS)
                .Build();

            // SELECT COUNT() FROM RELATIONSHIPS
            AdtQueryBuilder query4 = new AdtQueryBuilder()
                .SelectCount()
                .From(AdtCollection.RELATIONSHIPS)
                .Build();

            // SELECT Room, Temperature From DIGTIALTWINS
            AdtQueryBuilder query5 = new AdtQueryBuilder()
                .Select("Room", "Temperature")
                .From(AdtCollection.DIGITALTWINS)
                .Build();
        }
    }
}

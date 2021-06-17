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
            var queryWithComparisonWhereClause = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .Where("Temperature", QueryComparisonOperator.LessThan, "6")
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            AdtQueryBuilder query7 = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfModel("dtmi:example:room;1", true)
                .Build();

            AdtQueryBuilder experimentWithIntermediateWhere = new AdtQueryBuilder()
                .Select("*")
                .From(AdtCollection.DigitalTwins, "hi")
                .Where()
                .IsTrue(q => q
                    .IsOfType("Humidity", AdtDataType.AdtNumber)
                    .Or()
                    .IsOfType("Humidity", AdtDataType.AdtPrimative))
                .Or()
                .IsTrue(q => q
                    .IsOfType("Temperature", AdtDataType.AdtNumber)
                    .Or()
                    .IsOfType("Temperature", AdtDataType.AdtPrimative))

                .Build();

            AdtQueryBuilder experimentWithIntermediateWhere2 = new AdtQueryBuilder()
            .Select("*")
                .From(AdtCollection.DigitalTwins, "hi")
                .Where()
                .Where("1") //isTrue
                .Or()
                .Where("2")
                .Or()
                .Where("3")
                .Or()
                    .Where("4")
                    .Where("5")
                .Build();

            //            SELECT * FROM DIGITALTWINS WHERE 1 OR 2 OR 3 OR 4 AND 5
            //            SELECT * FROM DIGITALTWINS WHERE 1 OR (2 OR (3 OR (4 AND 5)))

            AdtQueryBuilder experimentWithIntermediateWhere3 = new AdtQueryBuilder()
            .Select("*")
                .From(AdtCollection.DigitalTwins, "hi")
                .Where()
                .Where("1")
                .Or()
                .Where("2")
                .And()
                .Where("3")
                .Or()
                .Where("4")
                .Build();

            // WHERE 1 OR (2 AND 3) OR (4))
            // WHERE (1 OR 2) AND (3 OR 4)

            // SELECT * FROM DigitalTwins WHERE
            //  (
            //      1
            //      OR
            //      2
            //  )
            //  AND
            //  (
            //      3
            //      OR
            //      4
            //  )
        }
    }
}

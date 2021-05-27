// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
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
            // string query1Str = "SELECT * FROM DIGITALTWINS";
            ADTQuery query1 = new ADTQuery().Select("*").From(ADTCollection.DigitalTwins);

            // string query2Str = "SELECT * FROM DIGITALTWINS WHERE Temperature <= 50";
            ADTQuery query2 = new ADTQuery().Select("*").From(ADTCollection.DigitalTwins).Where(new ComparisonCondition("Temperature", "<=", "50"));

            // NOTE - this uses aliasing, which is not supported yet
            // string query3Str = "SELECT Room FROM DIGITALTWINS DT WHERE IS_OF_MODEL(DT, 'dtmi:example:room;1', exact)";
            ADTQuery query3 = new ADTQuery()
                .Select("Room")
                .From(ADTCollection.DigitalTwins)
                .WhereIsOfModel("Room", true);

            // string query4Str = "SELECT * FROM DIGITALTWINS WHERE IS_BOOL(Occupied)";
            ADTQuery query4 = new ADTQuery()
                .Select("*")
                .From(ADTCollection.DigitalTwins)
                .Where(new IsCondition(IsType.BOOL, "Occupied"));

            // string query5Str = "SELECT * FROM Relationships WHERE STARTSWITH(T.$dtId, 'small-')";
            ADTQuery query5 = new ADTQuery()
                .Select("*")
                .From(ADTCollection.Relationship)
                .Where(new StartsEndsWithCondition(WithType.STARTSWTIH, "T.$dtId", "small-"));

            // string query6Str = "SELECT TOP(3) FROM DIGITALTWINS WHERE Location IN ['London', 'Madrid', 'Singapore']";
            ADTQuery query6 = new ADTQuery()
                .SelectTop(3)
                .From(ADTCollection.DigitalTwins)
                .Where(new ContainsCondition("Location", new string[] { "London", "Madrid", "Singapore" }));
        }
    }
}

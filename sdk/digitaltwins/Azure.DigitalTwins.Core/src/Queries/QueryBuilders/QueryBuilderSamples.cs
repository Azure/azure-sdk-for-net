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
            //"SELECT * FROM DIGITALTWINS";
            AdtQuery query1 = new AdtQuery().Select("*").From(AdtCollection.DigitalTwins);

            ////"SELECT * FROM DIGITALTWINS WHERE Temperature <= 50";
            //ADTQuery query2 = new ADTQuery().Select("*").From(ADTCollection.DigitalTwins).Where(new ComparisonCondition("Temperature", "<=", "50"));

            ////"SELECT Room FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)";
            //ADTQuery query3 = new ADTQuery()
            //    .Select("Room")
            //    .From(ADTCollection.DigitalTwins)
            //    .WhereIsOfModel("dtmi:example:room;1", true);

            ////"SELECT * FROM DIGITALTWINS WHERE IS_BOOL(Occupied)";
            //ADTQuery query4 = new ADTQuery()
            //    .Select("*")
            //    .From(ADTCollection.DigitalTwins)
            //    .Where(new IsCondition(IsType.BOOL, "Occupied"));

            ////"SELECT * FROM Relationships WHERE STARTSWITH(T.$dtId, 'small-')";
            //ADTQuery query5 = new ADTQuery()
            //    .Select("*")
            //    .From(ADTCollection.Relationship)
            //    .Where(new StartsEndsWithCondition(WithType.STARTSWTIH, "T.$dtId", "small-"));

            //ADTQuery query6 = new ADTQuery()
            //    .Select("*")
            //    .From(ADTCollection.Relationship)
            //    .WhereStartsWith("T.$dtId", "small-");

            ////"SELECT TOP(3) FROM DIGITALTWINS WHERE Location IN ['London', 'Madrid', 'Singapore']";
            //ADTQuery query7 = new ADTQuery()
            //    .SelectTop(3)
            //    .From(ADTCollection.DigitalTwins)
            //    .Where(new ContainsCondition("Location", new string[] { "London", "Madrid", "Singapore" }));

            AdtQuery query8 = new AdtQuery()
                .Select("*")
                .From(AdtCollection.DigitalTwins)
                .WhereIsOfModel("Room");
        }
    }
}

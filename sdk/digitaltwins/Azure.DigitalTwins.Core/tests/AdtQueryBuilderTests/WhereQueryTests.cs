// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class WhereQueryTests
    {
        [Test]
        public void WhereQuery_Comparison()
        {
            var query = new WhereQuery(null);
            query.Where("Temperature", QueryComparisonOperator.Equal, "5");
            query.GetQueryText()
                .Should()
                .Be("WHERE Temperature = 5");
        }

        [Test]
        public void WhereQuery_StringPropertyComparison()
        {
            var query = new WhereQuery(null);
            query.Where("RoomType", QueryComparisonOperator.Equal, "Hospital");
            query.GetQueryText()
                .Should()
                .Be("WHERE RoomType = 'Hospital'");
        }

        [Test]
        public void WhereQuery_Contains()
        {
            var query = new WhereQuery(null);
            query.Where("Owner", QueryContainsOperator.In, new string[] { "John", "Sally", "Marshall" });
            query.GetQueryText()
                .Should()
                .Be("WHERE Owner IN ['John', 'Sally', 'Marshall']");
        }

        [Test]
        public void WhereQuery_Override()
        {
            var query = new WhereQuery(null);
            query.Where("Temperature = 5");
            query.GetQueryText()
                .Should()
                .Be("WHERE Temperature = 5");
        }

        [Test]
        public void WhereQuery_IsDefined()
        {
            var query = new WhereQuery(null);
            query.WhereIsDefined("Temperature");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_DEFINED(Temperature)");
        }

        [Test]
        public void WhereQuery_IsNull()
        {
            var query = new WhereQuery(null);
            query.WhereIsNull("Humidity");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_NULL(Humidity)");
        }

        [Test]
        public void WhereQuery_StartsWith()
        {
            var query = new WhereQuery(null);
            query.WhereStartsWith("$dtId", "area1-");
            query.GetQueryText()
                .Should()
                .Be("WHERE STARTSWITH($dtId, 'area1-')");
        }

        [Test]
        public void WhereQuery_EndsWith()
        {
            var query = new WhereQuery(null);
            query.WhereEndsWith("$dtId", "-small");
            query.GetQueryText()
                .Should()
                .Be("WHERE ENDSWITH($dtId, '-small')");
        }

        [Test]
        public void WhereQuery_IsOfModel()
        {
            var query1 = new WhereQuery(null);
            query1.WhereIsOfModel("dtmi:example:room;1", true);
            query1.GetQueryText()
                .Should()
                .Be("WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");

            var query2 = new WhereQuery(null);
            query2.WhereIsOfModel("dtmi:example:room;1");
            query2.GetQueryText()
                .Should()
                .Be("WHERE IS_OF_MODEL('dtmi:example:room;1')");
        }

        [Test]
        public void WhereQuery_IsBool()
        {
            var query = new WhereQuery(null);
            query.WhereIsBool("HasTemperature");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_BOOL(HasTemperature)");
        }

        [Test]
        public void WhereQuery_IsNumber()
        {
            var query = new WhereQuery(null);
            query.WhereIsNumber("Contains");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_NUMBER(Contains)");
        }

        [Test]
        public void WhereQuery_IsString()
        {
            var query = new WhereQuery(null);
            query.WhereIsString("Status");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_STRING(Status)");
        }

        [Test]
        public void WhereQuery_IsPrimative()
        {
            var query = new WhereQuery(null);
            query.WhereIsPrimative("area");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_PRIMATIVE(area)");
        }

        [Test]
        public void WhereQuery_IsObject()
        {
            var query = new WhereQuery(null);
            query.WhereIsObject("MapObject");
            query.GetQueryText()
                .Should()
                .Be("WHERE IS_OBJECT(MapObject)");
        }

        [Test]
        public void WhereQuery_MultipleQueryies()
        {
            var query = new WhereQuery(null);
            query.Where("Temperature", QueryComparisonOperator.Equal, "50")
                .WhereIsDefined("Humidity");
            query.GetQueryText()
                .Should()
                .Be("WHERE Temperature = 50 AND IS_DEFINED(Humidity)");
        }
    }
}

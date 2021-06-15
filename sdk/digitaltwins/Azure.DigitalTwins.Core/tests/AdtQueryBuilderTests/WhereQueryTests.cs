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
            query.WhereComparison("Temperature", QueryComparisonOperator.Equal, "5");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE TEMPERATURE = 5");
        }

        [Test]
        public void WhereQuery_Contains()
        {
            var query = new WhereQuery(null);
            query.WhereContains("Owner", QueryContainOperator.IN, new string[] { "John", "Sally", "Marshall" });
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE OWNER IN ['JOHN', 'SALLY', 'MARSHALL']");
        }

        [Test]
        public void WhereQuery_Override()
        {
            var query = new WhereQuery(null);
            query.WhereOverride("Temperature = 5");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE TEMPERATURE = 5");
        }

        [Test]
        public void WhereQuery_IsDefined()
        {
            var query = new WhereQuery(null);
            query.WhereIsDefined("Temperature");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_DEFINED(TEMPERATURE)");
        }

        [Test]
        public void WhereQuery_IsNull()
        {
            var query = new WhereQuery(null);
            query.WhereIsNull("Humidity");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_NULL(HUMIDITY)");
        }

        [Test]
        public void WhereQuery_StartsWith()
        {
            var query = new WhereQuery(null);
            query.WhereStartsWith("$dtId", "area1-");
            query.Stringify()
                .Should()
                .Be("WHERE STARTSWITH($dtId, 'area1-')");
        }

        [Test]
        public void WhereQuery_EndsWith()
        {
            var query = new WhereQuery(null);
            query.WhereEndsWith("$dtId", "-small");
            query.Stringify()
                .Should()
                .Be("WHERE ENDSWITH($dtId, '-small')");
        }

        [Test]
        public void WhereQuery_IsOfModel()
        {
            var query1 = new WhereQuery(null);
            query1.WhereIsOfModel("dtmi:example:room;1", true);
            query1.Stringify()
                .Should()
                .Be("WHERE IS_OF_MODEL('dtmi:example:room;1', exact)");

            var query2 = new WhereQuery(null);
            query2.WhereIsOfModel("dtmi:example:room;1");
            query2.Stringify()
                .Should()
                .Be("WHERE IS_OF_MODEL('dtmi:example:room;1')");
        }

        [Test]
        public void WhereQuery_IsBool()
        {
            var query = new WhereQuery(null);
            query.WhereIsBool("HasTemperature");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_BOOL(HASTEMPERATURE)");
        }

        [Test]
        public void WhereQuery_IsNumber()
        {
            var query = new WhereQuery(null);
            query.WhereIsNumber("Contains");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_NUMBER(CONTAINS)");
        }

        [Test]
        public void WhereQuery_IsString()
        {
            var query = new WhereQuery(null);
            query.WhereIsString("Status");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_STRING(STATUS)");
        }

        [Test]
        public void WhereQuery_IsPrimative()
        {
            var query = new WhereQuery(null);
            query.WhereIsPrimative("area");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_PRIMATIVE(AREA)");
        }

        [Test]
        public void WhereQuery_IsObject()
        {
            var query = new WhereQuery(null);
            query.WhereIsObject("MapObject");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE IS_OBJECT(MAPOBJECT)");
        }

        [Test]
        public void WhereQuery_MultipleQueryies()
        {
            var query = new WhereQuery(null);
            query.WhereComparison("Temperature", QueryComparisonOperator.Equal, "50")
                .WhereIsDefined("Humidity");
            query.Stringify()
                .ToUpper()
                .Should()
                .Be("WHERE TEMPERATURE = 50 AND IS_DEFINED(HUMIDITY)");
        }
    }
}

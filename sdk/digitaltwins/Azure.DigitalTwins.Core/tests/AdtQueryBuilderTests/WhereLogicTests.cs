// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.DigitalTwins.Core.QueryBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class WhereLogicTests
    {
        [Test]
        public void WhereLogic_Comparison()
        {
            var query = new WhereLogic(null);
            query.Comparison("Temperature", QueryComparisonOperator.Equal, "5");
            query.GetQueryText()
                .Should()
                .Be("Temperature = 5");
        }

        [Test]
        public void WhereLogic_StringPropertyComparison()
        {
            var query = new WhereLogic(null);
            query.Comparison("RoomType", QueryComparisonOperator.Equal, "Hospital");
            query.GetQueryText()
                .Should()
                .Be("RoomType = 'Hospital'");
        }

        [Test]
        public void WhereLogic_Contains()
        {
            var query = new WhereLogic(null);
            query.Contains("Owner", QueryContainsOperator.In, new string[] { "John", "Sally", "Marshall" });
            query.GetQueryText()
                .Should()
                .Be("Owner IN ['John', 'Sally', 'Marshall']");
        }

        [Test]
        public void WhereLogic_Override()
        {
            var query = new WhereLogic(null);
            query.Override("Temperature = 5");
            query.GetQueryText()
                .Should()
                .Be("Temperature = 5");
        }

        [Test]
        public void WhereLogic_IsDefined()
        {
            var query = new WhereLogic(null);
            query.IsDefined("Temperature");
            query.GetQueryText()
                .Should()
                .Be("IS_DEFINED(Temperature)");
        }

        [Test]
        public void WhereLogic_IsNull()
        {
            var query = new WhereLogic(null);
            query.IsNull("Humidity");
            query.GetQueryText()
                .Should()
                .Be("IS_NULL(Humidity)");
        }

        [Test]
        public void WhereLogic_StartsWith()
        {
            var query = new WhereLogic(null);
            query.StartsWith("$dtId", "area1-");
            query.GetQueryText()
                .Should()
                .Be("STARTSWITH($dtId, 'area1-')");
        }

        [Test]
        public void WhereLogic_EndsWith()
        {
            var query = new WhereLogic(null);
            query.EndsWith("$dtId", "-small");
            query.GetQueryText()
                .Should()
                .Be("ENDSWITH($dtId, '-small')");
        }

        [Test]
        public void WhereLogic_IsOfModel()
        {
            var query1 = new WhereLogic(null);
            query1.IsOfModel("dtmi:example:room;1", true);
            query1.GetQueryText()
                .Should()
                .Be("IS_OF_MODEL('dtmi:example:room;1', exact)");

            var query2 = new WhereLogic(null);
            query2.IsOfModel("dtmi:example:room;1");
            query2.GetQueryText()
                .Should()
                .Be("IS_OF_MODEL('dtmi:example:room;1')");
        }

        [Test]
        public void WhereLogic_IsOfType_Bool()
        {
            var query = new WhereLogic(null);
            query.IsOfType("HasTemperature", AdtDataType.AdtBool);
            query.GetQueryText()
                .Should()
                .Be("IS_BOOL(HasTemperature)");
        }

        [Test]
        public void WhereLogic_IsOfType_Number()
        {
            var query = new WhereLogic(null);
            query.IsOfType("Contains", AdtDataType.AdtNumber);
            query.GetQueryText()
                .Should()
                .Be("IS_NUMBER(Contains)");
        }

        [Test]
        public void WhereLogic_IsOfType_String()
        {
            var query = new WhereLogic(null);
            query.IsOfType("Status", AdtDataType.AdtString);
            query.GetQueryText()
                .Should()
                .Be("IS_STRING(Status)");
        }

        [Test]
        public void WhereLogic_IsOfType_Primative()
        {
            var query = new WhereLogic(null);
            query.IsOfType("area", AdtDataType.AdtPrimative);
            query.GetQueryText()
                .Should()
                .Be("IS_PRIMATIVE(area)");
        }

        [Test]
        public void WhereLogic_IsOfType_Object()
        {
            var query = new WhereLogic(null);
            query.IsOfType("MapObject", AdtDataType.AdtObject);
            query.GetQueryText()
                .Should()
                .Be("IS_OBJECT(MapObject)");
        }

        [Test]
        public void WhereLogic_MultipleQueryies()
        {
            var query = new WhereLogic(null);
            query.Comparison("Temperature", QueryComparisonOperator.Equal, "50")
                .IsDefined("Humidity");
            query.GetQueryText()
                .Should()
                .Be("Temperature = 50 AND IS_DEFINED(Humidity)");
        }
    }
}

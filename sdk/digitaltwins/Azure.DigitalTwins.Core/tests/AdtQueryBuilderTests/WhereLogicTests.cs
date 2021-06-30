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
            query.Compare("Temperature", QueryComparisonOperator.Equal, 5);
            query.GetLogicText()
                .Should()
                .Be("Temperature = 5");
        }

        [Test]
        public void WhereLogic_Comparison_Float()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 5.5);
            query.GetLogicText()
                .Should()
                .Be("Temperature = 5.5");
        }

        [Test]
        public void WhereLogic_NumberWithStringComparison()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, "5");
            query.GetLogicText()
                .Should()
                .Be("Temperature = '5'");
        }

        [Test]
        public void WhereLogic_StringPropertyComparison()
        {
            var query = new WhereLogic(null);
            query.Compare("RoomType", QueryComparisonOperator.Equal, "Hospital");
            query.GetLogicText()
                .Should()
                .Be("RoomType = 'Hospital'");
        }

        [Test]
        public void WhereLogic_Contains()
        {
            var query = new WhereLogic(null);
            query.Contains("Owner", new string[] { "John", "Sally", "Marshall" });
            query.GetLogicText()
                .Should()
                .Be("Owner IN ['John', 'Sally', 'Marshall']");
        }

        [Test]
        public void WhereLogic_Override()
        {
            var query = new WhereLogic(null);
            query.CustomClause("Temperature = 5");
            query.GetLogicText()
                .Should()
                .Be("Temperature = 5");
        }

        [Test]
        public void WhereLogic_IsDefined()
        {
            var query = new WhereLogic(null);
            query.IsDefined("Temperature");
            query.GetLogicText()
                .Should()
                .Be("IS_DEFINED(Temperature)");
        }

        [Test]
        public void WhereLogic_IsNull()
        {
            var query = new WhereLogic(null);
            query.IsNull("Humidity");
            query.GetLogicText()
                .Should()
                .Be("IS_NULL(Humidity)");
        }

        [Test]
        public void WhereLogic_StartsWith()
        {
            var query = new WhereLogic(null);
            query.StartsWith("$dtId", "area1-");
            query.GetLogicText()
                .Should()
                .Be("STARTSWITH($dtId, 'area1-')");
        }

        [Test]
        public void WhereLogic_EndsWith()
        {
            var query = new WhereLogic(null);
            query.EndsWith("$dtId", "-small");
            query.GetLogicText()
                .Should()
                .Be("ENDSWITH($dtId, '-small')");
        }

        [Test]
        public void WhereLogic_IsOfModel()
        {
            var query1 = new WhereLogic(null);
            query1.IsOfModel("dtmi:example:room;1", true);
            query1.GetLogicText()
                .Should()
                .Be("IS_OF_MODEL('dtmi:example:room;1', exact)");

            var query2 = new WhereLogic(null);
            query2.IsOfModel("dtmi:example:room;1");
            query2.GetLogicText()
                .Should()
                .Be("IS_OF_MODEL('dtmi:example:room;1')");
        }

        [Test]
        public void WhereLogic_IsOfType_Bool()
        {
            var query = new WhereLogic(null);
            query.IsOfType("HasTemperature", AdtDataType.AdtBool);
            query.GetLogicText()
                .Should()
                .Be("IS_BOOL(HasTemperature)");
        }

        [Test]
        public void WhereLogic_IsOfType_Number()
        {
            var query = new WhereLogic(null);
            query.IsOfType("Contains", AdtDataType.AdtNumber);
            query.GetLogicText()
                .Should()
                .Be("IS_NUMBER(Contains)");
        }

        [Test]
        public void WhereLogic_IsOfType_String()
        {
            var query = new WhereLogic(null);
            query.IsOfType("Status", AdtDataType.AdtString);
            query.GetLogicText()
                .Should()
                .Be("IS_STRING(Status)");
        }

        [Test]
        public void WhereLogic_IsOfType_Primative()
        {
            var query = new WhereLogic(null);
            query.IsOfType("area", AdtDataType.AdtPrimative);
            query.GetLogicText()
                .Should()
                .Be("IS_PRIMATIVE(area)");
        }

        [Test]
        public void WhereLogic_IsOfType_Object()
        {
            var query = new WhereLogic(null);
            query.IsOfType("MapObject", AdtDataType.AdtObject);
            query.GetLogicText()
                .Should()
                .Be("IS_OBJECT(MapObject)");
        }

        [Test]
        public void WhereLogic_MultipleQueryies_And()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .And()
                .IsDefined("Humidity");
            query.GetLogicText()
                .Should()
                .Be("Temperature = 50 AND IS_DEFINED(Humidity)");
        }

        [Test]
        public void WhereLogic_MultipleQueryies_Or()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .Or()
                .IsDefined("Humidity");
            query.GetLogicText()
                .Should()
                .Be("Temperature = 50 OR IS_DEFINED(Humidity)");
        }

        [Test]
        public void WhereLogic_NestedQueries()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .And()
                .Parenthetical(q => q
                   .IsOfType("Humidity", AdtDataType.AdtNumber)
                   .And()
                   .IsOfType("Humidity", AdtDataType.AdtPrimative));
            query.GetLogicText()
                .Should()
                .Be("Temperature = 50 AND (IS_NUMBER(Humidity) AND IS_PRIMATIVE(Humidity))");
        }

        [Test]
        public void WhereLogic_NestedWithinNestedQueries()
        {
            var query = new WhereLogic(null);
            query.Compare("Temperature", QueryComparisonOperator.Equal, 50)
                .And()
                .Parenthetical(q => q
                   .IsOfType("Humidity", AdtDataType.AdtNumber)
                   .And()
                   .Parenthetical(q => q
                        .IsOfModel("dtmi:example:room;1", true)
                        .Or()
                        .IsOfType("isOccupied", AdtDataType.AdtBool)));
            query.GetLogicText()
                .Should()
                .Be("Temperature = 50 AND (IS_NUMBER(Humidity) AND (IS_OF_MODEL('dtmi:example:room;1', exact) OR IS_BOOL(isOccupied)))");
        }

        [Test]
        public void WhereLogic_MultipleNestedQueries()
        {
            var query = new WhereLogic(null);
            query.Parenthetical(q => q
                    .IsOfType("Humidity", AdtDataType.AdtNumber)
                    .Or()
                    .IsOfType("Humidity", AdtDataType.AdtPrimative))
                .Or()
                .Parenthetical(q => q
                    .IsOfType("Temperature", AdtDataType.AdtNumber)
                    .Or()
                    .IsOfType("Temperature", AdtDataType.AdtPrimative));
            query.GetLogicText()
                .Should()
                .Be("(IS_NUMBER(Humidity) OR IS_PRIMATIVE(Humidity)) OR (IS_NUMBER(Temperature) OR IS_PRIMATIVE(Temperature))");
        }
    }
}

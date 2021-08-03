using Azure.DigitalTwins.Core.QueryBuilder;
using Azure.DigitalTwins.Core.QueryBuilder.Fluent;

namespace Azure.DigitalTwins.Core.Samples
{
    public static class QueryBuilderSamples
    {
        public static void DigitalTwinsQueryBuilderMethodDrivenSamples()
        {
            #region Snippet:DigitalTwinsQueryBuilder

            // SELECT * FROM DIGITALTWINS
            DigitalTwinsQueryBuilder simplestQuery = new DigitalTwinsQueryBuilder().Select("*").From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT * FROM DIGITALTWINS
            // Note that the this is the same as the previous query, just with the pre-built SelectAll() method that can be used
            // interchangeably with Select("*")
            DigitalTwinsQueryBuilder simplestQuerySelectAll = new DigitalTwinsQueryBuilder().SelectAll().From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            // Note that if no property is specified, the SelectTopAll() method can be used instead of SelectTop()
            DigitalTwinsQueryBuilder queryWithSelectTop = new DigitalTwinsQueryBuilder()
                .SelectTopAll(3)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilder queryWithSelectTopProperty = new DigitalTwinsQueryBuilder()
                .SelectTop(3, "Temperature", "Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilder queryWithSelectRelationships = new DigitalTwinsQueryBuilder()
                .SelectCount()
                .From(DigitalTwinsCollection.Relationships)
                .Build();


            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilder queryWithIsOfModel = new DigitalTwinsQueryBuilder()
                .Select("*")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1"))
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderToString

            string basicQueryStringFormat = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilder queryWithMultipleProperties = new DigitalTwinsQueryBuilder()
                .Select("Room", "Temperature")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilder queryWithComparisonWhereClause = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Compare("Temperature", QueryComparisonOperator.LessThan, 5))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilder queryWithIsOfModelExact = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilder logicalOps_SingleAnd = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .And()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilder logicalOps_SingleOr = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            #region Snippet:DigitalTwinsQueryBuilderBuild
            // construct query and build string representation
            DigitalTwinsQueryBuilder builtQuery = new DigitalTwinsQueryBuilder()
                .SelectTopAll(5)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.GreaterThan, 50))
                .Build();

            // SELECT TOP(5) From DigitalTwins WHERE Temperature > 50
            string builtQueryString = builtQuery.GetQueryText();

            // if not rebuilt, string representation does not update, even if new methods are chained
            // SELECT TOP(5) From DigitalTwins WHERE Temperature > 50
            builtQuery.Select("Humidity").GetQueryText();

            // string representation updated after Build() called again
            // SELECT TOP(5) Humidity From DigitalTwins WHERE Temperature > 50
            builtQuery.Build().GetQueryText();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_ComplexConditions
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilder logicalOps_MultipleOr = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true)
                    .Or()
                    .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
            // OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
            DigitalTwinsQueryBuilder logicalOpsNested = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Precedence(q => q
                        .IsOfType("Humidity", DigitalTwinsDataType.DigitalTwinsNumber)
                        .Or()
                        .IsDefined("Humidity"))
                .And()
                .Precedence(q => q
                    .IsOfModel("dtmi:example:hvac;1")
                    .And()
                    .IsNull("Occupants")))
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilderOverride
            // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
            new DigitalTwinsQueryBuilder()
            .SelectCustom("TOP(3) Room, Temperature")
            .From(DigitalTwinsCollection.DigitalTwins)
            .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_SubjectiveConditionsWorkaround
            // SELECT * FROM DIGITALTWINS WHERE (Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)) AND IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilder subjectiveLogicalOps = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true)
                    .And()
                    .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            DigitalTwinsQueryBuilder objectiveLogicalOps = new DigitalTwinsQueryBuilder()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Precedence(q => q
                        .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                        .Or()
                        .IsOfModel("dtmi:example:room;1", true))
                .And()
                .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_Aliasing
            // SELECT Temperature AS Temp, Humidity AS HUM FROM DigitalTwins
            DigitalTwinsQueryBuilder selectAsSample = new DigitalTwinsQueryBuilder()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilder selectAndSelectAs = new DigitalTwinsQueryBuilder()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT T FROM DigitalTwins T
            DigitalTwinsQueryBuilder anotherSelectAsSample = new DigitalTwinsQueryBuilder()
                .Select("T")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();


            // SELECT T.Temperature, T.Humdity FROM DigitalTwins T
            DigitalTwinsQueryBuilder collectionAliasing = new DigitalTwinsQueryBuilder()
                .Select("T.Temperature", "T.Humidity")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();


            // SELECT T.Temperature AS Temp, T.Humidity AS Hum FROM DigitalTwins T
            // WHERE T.Temerpature = 50 AND T.Humidity = 30
            DigitalTwinsQueryBuilder bothAliasingTypes = new DigitalTwinsQueryBuilder()
                .SelectAs("T.Temperature", "Temp")
                .SelectAs("T.Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Where(q => q
                    .Compare("T.Temperature", QueryComparisonOperator.Equal, 50)
                    .And()
                    .Compare("T.Humidity", QueryComparisonOperator.Equal, 30))
                .Build();

            #endregion
        }
    }
}

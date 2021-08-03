using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Samples
{
    public static class QueryBuilderSamples
    {
        public static void DigitalTwinsQueryBuilderV1Samples()
        {
            #region Snippet:DigitalTwinsQueryBuilder

            // SELECT * FROM DIGITALTWINS
            DigitalTwinsQueryBuilderV1 simplestQuery = new DigitalTwinsQueryBuilderV1().Select("*").From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT * FROM DIGITALTWINS
            // Note that the this is the same as the previous query, just with the pre-built SelectAll() method that can be used
            // interchangeably with Select("*")
            DigitalTwinsQueryBuilderV1 simplestQuerySelectAll = new DigitalTwinsQueryBuilderV1().SelectAll().From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            // Note that if no property is specified, the SelectTopAll() method can be used instead of SelectTop()
            DigitalTwinsQueryBuilderV1 queryWithSelectTop = new DigitalTwinsQueryBuilderV1()
                .SelectTopAll(3)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilderV1 queryWithSelectTopProperty = new DigitalTwinsQueryBuilderV1()
                .SelectTop(3, "Temperature", "Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilderV1 queryWithSelectRelationships = new DigitalTwinsQueryBuilderV1()
                .SelectCount()
                .From(DigitalTwinsCollection.Relationships)
                .Build();


            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilderV1 queryWithIsOfModel = new DigitalTwinsQueryBuilderV1()
                .Select("*")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1"))
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderToString

            string basicQueryStringFormat = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilderV1 queryWithMultipleProperties = new DigitalTwinsQueryBuilderV1()
                .Select("Room", "Temperature")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilderV1 queryWithComparisonWhereClause = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Compare("Temperature", QueryComparisonOperator.LessThan, 5))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilderV1 queryWithIsOfModelExact = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderV1 logicalOps_SingleAnd = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .And()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderV1 logicalOps_SingleOr = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            #region Snippet:DigitalTwinsQueryBuilderBuild
            // construct query and build string representation
            DigitalTwinsQueryBuilderV1 builtQuery = new DigitalTwinsQueryBuilderV1()
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
            DigitalTwinsQueryBuilderV1 logicalOps_MultipleOr = new DigitalTwinsQueryBuilderV1()
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
            DigitalTwinsQueryBuilderV1 logicalOpsNested = new DigitalTwinsQueryBuilderV1()
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
            new DigitalTwinsQueryBuilderV1()
            .SelectCustom("TOP(3) Room, Temperature")
            .From(DigitalTwinsCollection.DigitalTwins)
            .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_SubjectiveConditionsWorkaround
            // SELECT * FROM DIGITALTWINS WHERE (Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)) AND IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilderV1 subjectiveLogicalOps = new DigitalTwinsQueryBuilderV1()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true)
                    .And()
                    .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            DigitalTwinsQueryBuilderV1 objectiveLogicalOps = new DigitalTwinsQueryBuilderV1()
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
            DigitalTwinsQueryBuilderV1 selectAsSample = new DigitalTwinsQueryBuilderV1()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilderV1 selectAndSelectAs = new DigitalTwinsQueryBuilderV1()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT T FROM DigitalTwins T
            DigitalTwinsQueryBuilderV1 anotherSelectAsSample = new DigitalTwinsQueryBuilderV1()
                .Select("T")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();


            // SELECT T.Temperature, T.Humdity FROM DigitalTwins T
            DigitalTwinsQueryBuilderV1 collectionAliasing = new DigitalTwinsQueryBuilderV1()
                .Select("T.Temperature", "T.Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT T.Temperature AS Temp, T.Humidity AS Hum FROM DigitalTwins T
            // WHERE T.Temerpature = 50 AND T.Humidity = 30
            DigitalTwinsQueryBuilderV1 bothAliasingTypes = new DigitalTwinsQueryBuilderV1()
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

        public static void DigitalTwinsQueryBuilderV2Samples()
        {
            #region Snippet:DigitalTwinsQueryBuilderNonGeneric
            new DigitalTwinsQueryBuilderV2().Build();
            new DigitalTwinsQueryBuilderV2<BasicDigitalTwin>().Build();

            // SELECT * FROM DigitalTwins
            new DigitalTwinsQueryBuilderV2().Build().GetQueryText();
            new DigitalTwinsQueryBuilderV2<BasicDigitalTwin>().Build().GetQueryText();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressionBenefits
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // Note how C# operators like == can be used directly in a query
            // SELECT * FROM DigitalTwins WHERE Temperature = 50
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => r.Temperature == 50)
                .Build();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressions

            // SELECT * FROM DigitalTwins
            DigitalTwinsQueryBuilderV2<BasicDigitalTwin> simplestQueryLINQ = new DigitalTwinsQueryBuilderV2().Build();

            // SELECT * FROM Relationsips
            DigitalTwinsQueryBuilderV2<BasicDigitalTwin> simplestQueryRelationshipsLINQ = new DigitalTwinsQueryBuilderV2(DigitalTwinsCollection.Relationships)
                .Build();

            // Use LINQ expressions to select defined properties in type T of DigitalTwinsQueryBuilder
            // SELECT Temperature From DigitalTwins
            DigitalTwinsQueryBuilderV2<ConferenceRoom> selectSingleProperty = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Select(r => r.Temperature)
                .Build();

            // Note that SelectTop() and SelectTopAll() are replaced with Take()
            // SELECT TOP(3) FROM DIGITALTWINS
            DigitalTwinsQueryBuilderV2<ConferenceRoom> queryWithSelectTopLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Take(3)
                .Build();

            // Strings are valid ways to denote selectable properties as an alternative to LINQ expressions
            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilderV2<ConferenceRoom> queryWithSelectTopPropertyLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Select("Temperature", "Humidity")
                .Take(3)
                .Build();

            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilderV2<ConferenceRoom> queryWithSelectRelationshipsLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .Count()
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilderV2<ConferenceRoom> queryWithIsOfModelLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1"))
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressionsFunctions
            // SELECT * FROM DigitalTwins WHERE IS_DEFINED(Temperature)
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Temperature))
                .Build();

            // SELECT * FROM DigitalTwins WHERE IS_BOOL(IsOccupied)
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsBool(r.IsOccupied))
                .Build();

            // If no properties of type T are needed, use an underscore in the LINQ expression
            // SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .Build();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderFromMethodLinqExpressions
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // pass in an optional string as a second parameter of From() to alias a collection
            // SELECT Temperature FROM DigitalTwins T
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();

            // Override the queryable collection set in the constructor with any From() method
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilderV2<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .Select(r => r.Temperature)
                .FromCustom("DigitalTwins")
                .Build();
            #endregion

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilderV2<BasicDigitalTwin> queryWithMultiplePropertiesLINQ = new DigitalTwinsQueryBuilderV2()
                .Select("Room", "Temperature")
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilderV2<ConferenceRoom> queryWithComparisonWhereClauseLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => r.Temperature < 5)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilderV2<BasicDigitalTwin> queryWithIsOfModelExactLINQ = new DigitalTwinsQueryBuilderV2()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderV2<ConferenceRoom> logicalOps_SingleAndLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => r.Temperature == 50 && DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true)).Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderV2<ConferenceRoom> logicalOps_SingleOrLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => (r.Temperature == 50 || DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true)) && r.IsOccupied == true).Build();

            #region Snippet:DigitalTwinsQueryBuilder_ComplexConditionsLinqExpressions
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilderV2<ConferenceRoom> logicalOps_MultipleOrLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r => r.Temperature == 50 ||
                DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true) ||
                DigitalTwinsFunctions.IsNumber(r.Temperature))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
            // OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
            DigitalTwinsQueryBuilderV2<ConferenceRoom> logicalOpsNestedLINQ = new DigitalTwinsQueryBuilderV2<ConferenceRoom>()
                .Where(r =>
                    (DigitalTwinsFunctions.IsNumber(r.Humidity)
                        || DigitalTwinsFunctions.IsDefined(r.Humidity))
                    &&
                    (DigitalTwinsFunctions.IsOfModel("dtmi:example:hvac;1")
                        && DigitalTwinsFunctions.IsNull(r.Occupants)))
                .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilderOverrideLinqExpressions
            // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
            new DigitalTwinsQueryBuilderV2()
            .SelectCustom("TOP(3) Room, Temperature")
            .Build();
            #endregion

            // SELECT Temperature AS Temp, Humidity AS HUM FROM DigitalTwins
            DigitalTwinsQueryBuilderV2<BasicDigitalTwin> selectAsSampleLINQ = new DigitalTwinsQueryBuilderV2(DigitalTwinsCollection.DigitalTwins, "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .Build();

            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilderV2<BasicDigitalTwin> selectAndSelectAsLINQ = new DigitalTwinsQueryBuilderV2()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();
        }
    }
}

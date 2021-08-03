using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Samples
{
    public static class QueryBuilderSamples
    {
        public static void DigitalTwinsQueryBuilderMethodDrivenSamples()
        {
            #region Snippet:DigitalTwinsQueryBuilder

            // SELECT * FROM DIGITALTWINS
            DigitalTwinsQueryBuilderMethodDriven simplestQuery = new DigitalTwinsQueryBuilderMethodDriven().Select("*").From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT * FROM DIGITALTWINS
            // Note that the this is the same as the previous query, just with the pre-built SelectAll() method that can be used
            // interchangeably with Select("*")
            DigitalTwinsQueryBuilderMethodDriven simplestQuerySelectAll = new DigitalTwinsQueryBuilderMethodDriven().SelectAll().From(DigitalTwinsCollection.DigitalTwins).Build();

            // SELECT TOP(3) FROM DIGITALTWINS
            // Note that if no property is specified, the SelectTopAll() method can be used instead of SelectTop()
            DigitalTwinsQueryBuilderMethodDriven queryWithSelectTop = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectTopAll(3)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilderMethodDriven queryWithSelectTopProperty = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectTop(3, "Temperature", "Humidity")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilderMethodDriven queryWithSelectRelationships = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectCount()
                .From(DigitalTwinsCollection.Relationships)
                .Build();


            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilderMethodDriven queryWithIsOfModel = new DigitalTwinsQueryBuilderMethodDriven()
                .Select("*")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1"))
                .Build();

            #endregion Snippet:DigitalTwinsQueryBuilder

            #region Snippet:DigitalTwinsQueryBuilderToString

            string basicQueryStringFormat = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build()
                .GetQueryText();

            #endregion Snippet:DigitalTwinsQueryBuilderToString

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilderMethodDriven queryWithMultipleProperties = new DigitalTwinsQueryBuilderMethodDriven()
                .Select("Room", "Temperature")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilderMethodDriven queryWithComparisonWhereClause = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.Compare("Temperature", QueryComparisonOperator.LessThan, 5))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilderMethodDriven queryWithIsOfModelExact = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderMethodDriven logicalOps_SingleAnd = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .And()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderMethodDriven logicalOps_SingleOr = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true))
                .Build();

            #region Snippet:DigitalTwinsQueryBuilderBuild
            // construct query and build string representation
            DigitalTwinsQueryBuilderMethodDriven builtQuery = new DigitalTwinsQueryBuilderMethodDriven()
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
            DigitalTwinsQueryBuilderMethodDriven logicalOps_MultipleOr = new DigitalTwinsQueryBuilderMethodDriven()
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
            DigitalTwinsQueryBuilderMethodDriven logicalOpsNested = new DigitalTwinsQueryBuilderMethodDriven()
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
            new DigitalTwinsQueryBuilderMethodDriven()
            .SelectCustom("TOP(3) Room, Temperature")
            .From(DigitalTwinsCollection.DigitalTwins)
            .Build();

            #endregion

            #region Snippet:DigitalTwinsQueryBuilder_SubjectiveConditionsWorkaround
            // SELECT * FROM DIGITALTWINS WHERE (Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)) AND IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilderMethodDriven subjectiveLogicalOps = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAll()
                .From(DigitalTwinsCollection.DigitalTwins)
                .Where(q => q
                    .Compare("Temperature", QueryComparisonOperator.Equal, 50)
                    .Or()
                    .IsOfModel("dtmi:example:room;1", true)
                    .And()
                    .IsOfType("Temperature", DigitalTwinsDataType.DigitalTwinsNumber))
                .Build();

            DigitalTwinsQueryBuilderMethodDriven objectiveLogicalOps = new DigitalTwinsQueryBuilderMethodDriven()
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
            DigitalTwinsQueryBuilderMethodDriven selectAsSample = new DigitalTwinsQueryBuilderMethodDriven()
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilderMethodDriven selectAndSelectAs = new DigitalTwinsQueryBuilderMethodDriven()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();


            // SELECT T FROM DigitalTwins T
            DigitalTwinsQueryBuilderMethodDriven anotherSelectAsSample = new DigitalTwinsQueryBuilderMethodDriven()
                .Select("T")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();


            // SELECT T.Temperature, T.Humdity FROM DigitalTwins T
            DigitalTwinsQueryBuilderMethodDriven collectionAliasing = new DigitalTwinsQueryBuilderMethodDriven()
                .Select("T.Temperature", "T.Humidity")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();


            // SELECT T.Temperature AS Temp, T.Humidity AS Hum FROM DigitalTwins T
            // WHERE T.Temerpature = 50 AND T.Humidity = 30
            DigitalTwinsQueryBuilderMethodDriven bothAliasingTypes = new DigitalTwinsQueryBuilderMethodDriven()
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

        public static void DigitalTwinsQueryBuilderLinqDrivenSamples()
        {
            #region Snippet:DigitalTwinsQueryBuilderNonGeneric
            // Note that if no Select() method, SELECT("*") is the default
            new DigitalTwinsQueryBuilderLinqDriven().Build();
            new DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin>().Build();

            // SELECT * FROM DigitalTwins
            new DigitalTwinsQueryBuilderLinqDriven().Build().GetQueryText();
            new DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin>().Build().GetQueryText();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressionBenefits
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // Note how C# operators like == can be used directly in the Where() method
            // SELECT * FROM DigitalTwins WHERE Temperature = 50
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => r.Temperature == 50)
                .Build();
            #endregion

            // SELECT * FROM DigitalTwins
            DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin> simplestQueryLinq = new DigitalTwinsQueryBuilderLinqDriven().Build();

            // SELECT * FROM Relationsips
            DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin> simplestQueryRelationshipsLINQ = new DigitalTwinsQueryBuilderLinqDriven(DigitalTwinsCollection.Relationships)
                .Build();

            // Use LINQ expressions to select defined properties in type T of DigitalTwinsQueryBuilder
            // SELECT Temperature From DigitalTwins
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> selectSingleProperty = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Temperature)
                .Build();

            // Note that SelectTop() and SelectTopAll() are replaced with Take()
            // SELECT TOP(3) FROM DIGITALTWINS
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> queryWithSelectTopLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Take(3)
                .Build();

            // Strings are valid ways to denote selectable properties as an alternative to LINQ expressions
            // SELECT TOP(3) Temperature, Humidity FROM DIGITALTWINS
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> queryWithSelectTopPropertyLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select("Temperature", "Humidity")
                .Take(3)
                .Build();

            // SELECT COUNT() FROM RELATIONSHIPS
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> queryWithSelectRelationshipsLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .Count()
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL("dtmi:example:room;1")
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> queryWithIsOfModelLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1"))
                .Build();

            #region Snippet:DigitalTwinsQueryBuilderLinqExpressionsFunctions
            // SELECT * FROM DigitalTwins WHERE IS_DEFINED(Temperature)
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsDefined(r.Temperature))
                .Build();

            // SELECT * FROM DigitalTwins WHERE IS_BOOL(IsOccupied)
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => DigitalTwinsFunctions.IsBool(r.IsOccupied))
                .Build();

            // If no properties of type T are needed, use an underscore in the LINQ expression
            // SELECT * FROM DigitalTwins WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .Build();
            #endregion

            #region Snippet:DigitalTwinsQueryBuilderFromMethodLinqExpressions
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins)
                .Build();

            // pass in an optional string as a second parameter of From() to alias a collection
            // SELECT Temperature FROM DigitalTwins T
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Select(r => r.Temperature)
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();

            // Override the queryable collection set in the constructor with any From() method
            // SELECT Temperature FROM DigitalTwins
            new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>(DigitalTwinsCollection.Relationships)
                .Select(r => r.Temperature)
                .FromCustom("DigitalTwins")
                .Build();
            #endregion

            // SELECT Room, Temperature From DIGTIALTWINS
            DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin> queryWithMultiplePropertiesLINQ = new DigitalTwinsQueryBuilderLinqDriven()
                .Select("Room", "Temperature")
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE TEMPERATURE < 5
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> queryWithComparisonWhereClauseLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => r.Temperature < 5)
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE IS_OF_MODEL('dtmi:example:room;1', exact)
            DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin> queryWithIsOfModelExactLINQ = new DigitalTwinsQueryBuilderLinqDriven()
                .Where(_ => DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 AND IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> logicalOps_SingleAndLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => r.Temperature == 50 && DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true)).Build();

            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact)
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> logicalOps_SingleOrLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => (r.Temperature == 50 || DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true)) && r.IsOccupied == true).Build();

            #region Snippet:DigitalTwinsQueryBuilder_ComplexConditionsLinqExpressions
            // SELECT * FROM DIGITALTWINS WHERE Temperature = 50 OR IS_OF_MODEL("dtmi..", exact) OR IS_NUMBER(Temperature)
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> logicalOps_MultipleOrLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
                .Where(r => r.Temperature == 50 ||
                DigitalTwinsFunctions.IsOfModel("dtmi:example:room;1", true) ||
                DigitalTwinsFunctions.IsNumber(r.Temperature))
                .Build();

            // SELECT * FROM DIGITALTWINS WHERE (IS_NUMBER(Humidity) OR IS_DEFINED(Humidity)) 
            // OR (IS_OF_MODEL("dtmi:example:hvac;1") AND IS_NULL(Occupants))
            DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom> logicalOpsNestedLINQ = new DigitalTwinsQueryBuilderLinqDriven<ConferenceRoom>()
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
            new DigitalTwinsQueryBuilderLinqDriven()
            .SelectCustom("TOP(3) Room, Temperature")
            .Build();
            #endregion

            // SELECT Temperature AS Temp, Humidity AS HUM FROM DigitalTwins
            DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin> selectAsSampleLINQ = new DigitalTwinsQueryBuilderLinqDriven(DigitalTwinsCollection.DigitalTwins, "T")
                .SelectAs("Temperature", "Temp")
                .SelectAs("Humidity", "Hum")
                .Build();

            // SELECT Temperature, Humidity AS Hum FROM DigitalTwins
            DigitalTwinsQueryBuilderLinqDriven<BasicDigitalTwin> selectAndSelectAsLINQ = new DigitalTwinsQueryBuilderLinqDriven()
                .Select("Temperature")
                .SelectAs("Humidity", "Hum")
                .From(DigitalTwinsCollection.DigitalTwins, "T")
                .Build();
        }
    }
}

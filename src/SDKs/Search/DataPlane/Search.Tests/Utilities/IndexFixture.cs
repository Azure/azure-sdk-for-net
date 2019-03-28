// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Net.Http;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class IndexFixture : SearchServiceFixture
    {
        public string IndexName { get; private set; }

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            SearchServiceClient searchClient = this.GetSearchServiceClient();

            IndexName = SearchTestUtilities.GenerateName();

            // This is intentionally a different index definition than the one returned by IndexTests.CreateTestIndex().
            // That index is meant to exercise serialization of the index definition itself, while this one is tuned
            // more for exercising document serialization, indexing, and querying operations.
            var index =
                new Index()
                {
                    Name = IndexName,
                    Fields = new[]
                    {
                        Field.New("hotelId", DataType.String, isKey: true, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("hotelName", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: false),
                        Field.NewSearchableString("description", AnalyzerName.EnLucene),
                        Field.NewSearchableString("descriptionFr", AnalyzerName.FrLucene),
                        Field.New("category", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("tags", DataType.Collection(DataType.String), isSearchable: true, isFilterable: true, isFacetable: true),
                        Field.New("parkingIncluded", DataType.Boolean, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("smokingAllowed", DataType.Boolean, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("lastRenovationDate", DataType.DateTimeOffset, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.New("rating", DataType.Int32, isFilterable: true, isSortable: true, isFacetable: true),
                        Field.NewComplex("address", isCollection: false, fields: new[]
                        {
                            Field.New("streetAddress", DataType.String, isSearchable: true),
                            Field.New("city", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                            Field.New("stateProvince", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                            Field.New("country", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true),
                            Field.New("postalCode", DataType.String, isSearchable: true, isFilterable: true, isSortable: true, isFacetable: true)
                        }),
                        Field.New("location", DataType.GeographyPoint, isFilterable: true, isSortable: true),
                        Field.NewComplex("rooms", isCollection: true, fields: new[]
                        {
                            Field.NewSearchableString("description", AnalyzerName.EnLucene),
                            Field.NewSearchableString("descriptionFr", AnalyzerName.FrLucene),
                            Field.New("type", DataType.String, isSearchable: true, isFilterable: true, isFacetable: true),
                            Field.New("baseRate", DataType.Double, isFilterable: true, isFacetable: true),
                            Field.New("bedOptions", DataType.String, isSearchable: true, isFilterable: true, isFacetable: true),
                            Field.New("sleepsCount", DataType.Int32, isFilterable: true, isFacetable: true),
                            Field.New("smokingAllowed", DataType.Boolean, isFilterable: true, isFacetable: true),
                            Field.New("tags", DataType.Collection(DataType.String), isSearchable: true, isFilterable: true, isFacetable: true)
                        })
                    },
                    Suggesters = new[]
                    {
                        new Suggester(
                            name: "sg", 
                            sourceFields: new[] { "description", "hotelName" })
                    },
                    ScoringProfiles = new[]
                    {
                        new ScoringProfile("nearest")
                        {
                            FunctionAggregation = ScoringFunctionAggregation.Sum,
                            Functions = new[]
                            {
                                new DistanceScoringFunction("location", 2, new DistanceScoringParameters("myloc", 100))
                            }
                        }
                    }
                };

            searchClient.Indexes.Create(index);

            // Give the index time to stabilize before running tests.
            // TODO: Remove this workaround once the retry hang bug is fixed.
            TestUtilities.Wait(TimeSpan.FromSeconds(20));
        }

        public SearchIndexClient GetSearchIndexClient(string indexName = null, params DelegatingHandler[] handlers)
        {
            indexName = indexName ?? IndexName;
            return GetSearchIndexClientForKey(indexName, PrimaryApiKey);
        }

        public SearchIndexClient GetSearchIndexClientForQuery(
            string indexName = null, 
            params DelegatingHandler[] handlers)
        {
            indexName = indexName ?? IndexName;
            return GetSearchIndexClientForKey(indexName, QueryApiKey);
        }

        private SearchIndexClient GetSearchIndexClientForKey(
            string indexName, 
            string apiKey, 
            params DelegatingHandler[] handlers)
        {
            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            SearchIndexClient client =
                MockContext.GetServiceClientWithCredentials<SearchIndexClient>(
                    currentEnvironment,
                    new SearchCredentials(apiKey),
                    internalBaseUri: true,
                    handlers: handlers);

            client.SearchServiceName = SearchServiceName;
            client.SearchDnsSuffix = currentEnvironment.GetSearchDnsSuffix(SearchServiceName);
            client.IndexName = indexName;
            return client;
        }
    }
}

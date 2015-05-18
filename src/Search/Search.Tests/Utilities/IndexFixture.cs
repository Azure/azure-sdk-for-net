// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Net;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class IndexFixture : SearchServiceFixture
    {
        public IndexFixture()
        {
            SearchServiceClient searchClient = this.GetSearchServiceClient();

            IndexName = TestUtilities.GenerateName();

            // This is intentionally a different index definition than the one returned by IndexTests.CreateTestIndex().
            // That index is meant to exercise serialization of the index definition itself, while this one is tuned
            // more for exercising document serialization, indexing, and querying operations.
            var index =
                new Index()
                {
                    Name = IndexName,
                    Fields = new[]
                    {
                        new Field("hotelId", DataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("baseRate", DataType.Double) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("description", DataType.String) { IsSearchable = true },
                        new Field("descriptionFr", AnalyzerName.FrLucene),
                        new Field("hotelName", DataType.String) { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("category", DataType.String) { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("tags", DataType.Collection(DataType.String)) { IsSearchable = true, IsFilterable = true, IsFacetable = true },
                        new Field("parkingIncluded", DataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("smokingAllowed", DataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("lastRenovationDate", DataType.DateTimeOffset) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("rating", DataType.Int32) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("location", DataType.GeographyPoint) { IsFilterable = true, IsSortable = true }
                    },
                    Suggesters = new[]
                    {
                        new Suggester(
                            name: "sg", 
                            searchMode: SuggesterSearchMode.AnalyzingInfixMatching, 
                            sourceFields: new[] { "description", "hotelName" })
                    },
                    ScoringProfiles = new[]
                    {
                        new ScoringProfile("nearest")
                        {
                            FunctionAggregation = ScoringFunctionAggregation.Sum,
                            Functions = new[]
                            {
                                new DistanceScoringFunction(new DistanceScoringParameters("myloc", 100), "location", 2)
                            }
                        }
                    }
                };

            IndexDefinitionResponse createIndexResponse = searchClient.Indexes.Create(index);
            Assert.Equal(HttpStatusCode.Created, createIndexResponse.StatusCode);

            // Give the index time to stabilize before running tests.
            // TODO: Remove this workaround once the retry hang bug is fixed.
            TestUtilities.Wait(TimeSpan.FromSeconds(20));
        }

        public string IndexName { get; private set; }

        public SearchIndexClient GetSearchIndexClient(string indexName = null)
        {
            indexName = indexName ?? IndexName;
            return GetSearchIndexClientForKey(indexName, PrimaryApiKey);
        }

        public SearchIndexClient GetSearchIndexClientForQuery(string indexName = null)
        {
            indexName = indexName ?? IndexName;
            return GetSearchIndexClientForKey(indexName, QueryApiKey);
        }

        private SearchIndexClient GetSearchIndexClientForKey(string indexName, string apiKey)
        {
            var factory = new CSMTestEnvironmentFactory();
            TestEnvironment currentEnvironment = factory.GetTestEnvironment();

            Uri baseUri = 
                new Uri(
                    currentEnvironment.GetBaseSearchUri(ExecutionMode.CSM, SearchServiceName), 
                    String.Format("indexes/{0}/", indexName));

            SearchIndexClient client = new SearchIndexClient(new SearchCredentials(apiKey), baseUri);
            return TestBaseCopy.AddMockHandler<SearchIndexClient>(ref client);
        }
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public sealed class IndexManagementTests : SearchTestBase<SearchServiceFixture>
    {
        public static Index CreateTestIndex()
        {
            string indexName = SearchTestUtilities.GenerateName();

            var index = new Index()
            {
                Name = indexName,
                Fields = new[]
                {
                    new Field("hotelId", DataType.String) { IsKey = true, IsSearchable = false, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("baseRate", DataType.Double) { IsKey = false, IsSearchable = false, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("description", DataType.String) { IsKey = false, IsSearchable = true, IsFilterable = false, IsSortable = false, IsFacetable = false },
                    new Field("description_fr", AnalyzerName.FrLucene) { IsFilterable = false, IsSortable = false, IsFacetable = false },
                    new Field("description_custom", DataType.String) { IsSearchable = true, IsFilterable = false, IsSortable = false, IsFacetable = false, SearchAnalyzer = AnalyzerName.Stop, IndexAnalyzer = AnalyzerName.Stop },
                    new Field("hotelName", DataType.String) { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("category", DataType.String) { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("tags", DataType.Collection(DataType.String)) { IsSearchable = true, IsFilterable = true, IsSortable = false, IsFacetable = true },
                    new Field("parkingIncluded", DataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("smokingAllowed", DataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("lastRenovationDate", DataType.DateTimeOffset) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("rating", DataType.Int32) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("location", DataType.GeographyPoint) { IsFilterable = true, IsSortable = true, IsFacetable = false, IsRetrievable = true },
                    new Field("totalGuests", DataType.Int64) { IsFilterable = true, IsSortable = true, IsFacetable = true, IsRetrievable = false },
                    new Field("profitMargin", DataType.Double)
                },
                ScoringProfiles = new[]
                {
                    new ScoringProfile("MyProfile")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Average,
                        Functions = new ScoringFunction[]
                        {
                            new MagnitudeScoringFunction(
                                "rating",
                                boost: 2.0,
                                boostingRangeStart: 1,
                                boostingRangeEnd: 4,
                                shouldBoostBeyondRangeByConstant: true,
                                interpolation: ScoringFunctionInterpolation.Constant),
                            new DistanceScoringFunction(
                                "location",
                                boost: 1.5,
                                referencePointParameter: "loc",
                                boostingDistance: 5,
                                interpolation: ScoringFunctionInterpolation.Linear),
                            new FreshnessScoringFunction(
                                "lastRenovationDate",
                                boost: 1.1,
                                boostingDuration: TimeSpan.FromDays(365),   //aka.ms/sre-codescan/disable
                                interpolation: ScoringFunctionInterpolation.Logarithmic)
                        },
                        TextWeights = new TextWeights()
                        {
                            Weights = new Dictionary<string, double>() { { "description", 1.5 }, { "category", 2.0 } }
                        }
                    },
                    new ScoringProfile("ProfileTwo")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Maximum,
                        Functions = new[]
                        {
                            new TagScoringFunction(
                                "tags",
                                boost: 1.5,
                                tagsParameter: "mytags",
                                interpolation: ScoringFunctionInterpolation.Linear)
                        }
                    },
                    new ScoringProfile("ProfileThree")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Minimum,
                        Functions = new[]
                        {
                            // Set ShouldBoostBeyondRangeByConstant explicitly to false. The API returns the default (false) if you pass in null, so we
                            // need to do this to ensure that comparisons work after round trips.
                            new MagnitudeScoringFunction("rating", 3.0, new MagnitudeScoringParameters(0, 10) { ShouldBoostBeyondRangeByConstant = false })
                            {
                                Interpolation = ScoringFunctionInterpolation.Quadratic
                            }
                        }
                    },
                    new ScoringProfile("ProfileFour")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.FirstMatching,
                        Functions = new[]
                        {
                            // Set ShouldBoostBeyondRangeByConstant explicitly to false. The API returns the default (false) if you pass in null, so we
                            // need to do this to ensure that comparisons work after round trips.
                            new MagnitudeScoringFunction("rating", 3.14, new MagnitudeScoringParameters(1, 5) { ShouldBoostBeyondRangeByConstant = false })
                            {
                                Interpolation = ScoringFunctionInterpolation.Constant
                            }
                        }
                    }
                },
                DefaultScoringProfile = "MyProfile",
                CorsOptions = new CorsOptions()
                {
                    AllowedOrigins = new[] { "http://tempuri.org", "http://localhost:80" },
                    MaxAgeInSeconds = 60
                },
                Suggesters = new[]
                {
                    new Suggester("FancySuggester", SuggesterSearchMode.AnalyzingInfixMatching, "hotelName")
                }
            };

            return index;
        }

        [Fact]
        public void CreateIndexReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                Index createdIndex = searchClient.Indexes.Create(index);
                
                AssertIndexesEqual(index, createdIndex);
            });
        }

        [Fact]
        public void CreateIndexReturnsCorrectDefaultValues()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index inputIndex = CreateTestIndex();
                
                // Default values for field properties are tested elsewhere.
                inputIndex.CorsOptions = new CorsOptions() { AllowedOrigins = new[] { "*" } };
                inputIndex.ScoringProfiles = new[]
                {
                    new ScoringProfile("MyProfile")
                    {
                        Functions = new ScoringFunction[]
                        {
                            new MagnitudeScoringFunction(
                                "rating", 
                                boost: 2.0, 
                                boostingRangeStart: 1, 
                                boostingRangeEnd: 4)
                        }
                    }
                };

                Index resultIndex = searchClient.Indexes.Create(inputIndex);

                Assert.False(resultIndex.CorsOptions.MaxAgeInSeconds.HasValue); // No value means use the default age.
                Assert.Equal(ScoringFunctionAggregation.Sum, resultIndex.ScoringProfiles[0].FunctionAggregation);

                var function = resultIndex.ScoringProfiles[0].Functions[0] as MagnitudeScoringFunction;
                Assert.NotNull(function);
                Assert.False(function.Parameters.ShouldBoostBeyondRangeByConstant);
                Assert.Equal(ScoringFunctionInterpolation.Linear, function.Interpolation);
            });
        }

        [Fact]
        public void CreateIndexFailsWithUsefulMessageOnUserError()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();
                index.Fields[0].IsKey = false;

                const string ExpectedMessageFormat =
                    "The request is invalid. Details: index : Found 0 key fields in index '{0}'. " +
                    "Each index must have exactly one key field.";

                SearchAssert.ThrowsCloudException(
                    () => searchClient.Indexes.Create(index),
                    HttpStatusCode.BadRequest,
                    String.Format(ExpectedMessageFormat, index.Name));
            });
        }

        [Fact]
        public void GetIndexReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                searchClient.Indexes.Create(index);
                Index createdIndex = searchClient.Indexes.Get(index.Name);

                AssertIndexesEqual(index, createdIndex);
            });
        }

        [Fact]
        public void GetIndexThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                SearchAssert.ThrowsCloudException(() => searchClient.Indexes.Get("thisindexdoesnotexist"), HttpStatusCode.NotFound);
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanUpdateIndexDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index fullFeaturedIndex = CreateTestIndex();
                Index initialIndex = CreateTestIndex();

                // Start out with no scoring profiles and different CORS options.
                initialIndex.Name = fullFeaturedIndex.Name;
                initialIndex.ScoringProfiles = new ScoringProfile[0];
                initialIndex.DefaultScoringProfile = null;
                initialIndex.CorsOptions.AllowedOrigins = new[] { "*" };

                Index index = searchClient.Indexes.Create(initialIndex);

                // Give the index time to stabilize before continuing the test.
                // TODO: Remove this workaround once the retry hang bug is fixed.
                TestUtilities.Wait(TimeSpan.FromSeconds(20));

                // Now update the index.
                index.ScoringProfiles = fullFeaturedIndex.ScoringProfiles;
                index.DefaultScoringProfile = fullFeaturedIndex.DefaultScoringProfile;
                index.CorsOptions.AllowedOrigins = fullFeaturedIndex.CorsOptions.AllowedOrigins;

                Index updatedIndex = searchClient.Indexes.CreateOrUpdate(index);

                AssertIndexesEqual(fullFeaturedIndex, updatedIndex);
            });
        }

        [Fact]
        public void CreateOrUpdateIndexIfNotExistsFailsOnExistingResource()
        {
            Run(() => AccessConditionTests.CreateOrUpdateIfNotExistsFailsOnExistingResource(CreateOrUpdateIndex, CreateTestIndex, MutateIndex));
        }

        [Fact]
        public void CreateOrUpdateIndexIfNotExistsSucceedsOnNoResource()
        {
            Run(() => AccessConditionTests.CreateOrUpdateIfNotExistsSucceedsOnNoResource(CreateOrUpdateIndex, CreateTestIndex));
        }

        [Fact]
        public void UpdateIndexIfExistsSucceedsOnExistingResource()
        {
            Run(() => AccessConditionTests.UpdateIfExistsSucceedsOnExistingResource(CreateOrUpdateIndex, CreateTestIndex, MutateIndex));
        }

        [Fact]
        public void UpdateIndexIfExistsFailsOnNoResource()
        {
            Run(() => AccessConditionTests.UpdateIfExistsFailsOnNoResource(CreateOrUpdateIndex, CreateTestIndex));
        }

        [Fact]
        public void UpdateIndexIfNotChangedSucceedsWhenResourceUnchanged()
        {
            Run(() => AccessConditionTests.UpdateIfNotChangedSucceedsWhenResourceUnchanged(CreateOrUpdateIndex, CreateTestIndex, MutateIndex));
        }

        [Fact]
        public void UpdateIndexIfNotChangedFailsWhenResourceChanged()
        {
            Run(() => AccessConditionTests.UpdateIfNotChangedFailsWhenResourceChanged(CreateOrUpdateIndex, CreateTestIndex, MutateIndex));
        }

        [Fact]
        public void DeleteIndexIfNotChangedWorksOnlyOnCurrentResource()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                AccessConditionTests.DeleteIfNotChangedWorksOnlyOnCurrentResource(
                    searchClient.Indexes.Delete,
                    () => searchClient.Indexes.CreateOrUpdate(index),
                    x => searchClient.Indexes.CreateOrUpdate(MutateIndex(x)),
                    index.Name);
            });
        }

        [Fact]
        public void DeleteIndexIfExistsWorksOnlyWhenResourceExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                AccessConditionTests.DeleteIfExistsWorksOnlyWhenResourceExists(
                    searchClient.Indexes.Delete,
                    () => searchClient.Indexes.CreateOrUpdate(index),
                    index.Name);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenIndexDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                AzureOperationResponse<Index> createOrUpdateResponse = 
                    searchClient.Indexes.CreateOrUpdateWithHttpMessagesAsync(index).Result;
                Assert.Equal(HttpStatusCode.Created, createOrUpdateResponse.Response.StatusCode);
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void DeleteIndexIsIdempotent()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                // Try delete before the index even exists.
                AzureOperationResponse deleteResponse = 
                    searchClient.Indexes.DeleteWithHttpMessagesAsync(index.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);

                AzureOperationResponse<Index> createResponse = 
                    searchClient.Indexes.CreateWithHttpMessagesAsync(index).Result;
                Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);

                // Now delete twice.
                deleteResponse = searchClient.Indexes.DeleteWithHttpMessagesAsync(index.Name).Result;
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                deleteResponse = searchClient.Indexes.DeleteWithHttpMessagesAsync(index.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanCreateAndGetIndexStats()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                searchClient.Indexes.Create(index);

                IndexGetStatisticsResult stats = searchClient.Indexes.GetStatistics(index.Name);
                Assert.Equal(0, stats.DocumentCount);
                Assert.Equal(0, stats.StorageSize);
            });
        }

        [Fact]
        public void CanCreateAndDeleteIndex()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();
                searchClient.Indexes.Create(index);

                searchClient.Indexes.Delete(index.Name);
                
                Assert.False(searchClient.Indexes.Exists(index.Name));
            });
        }

        [Fact]
        public void CanCreateAndListIndexes()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index1 = CreateTestIndex();
                Index index2 = CreateTestIndex();

                searchClient.Indexes.Create(index1);
                searchClient.Indexes.Create(index2);

                IndexListResult listResponse = searchClient.Indexes.List();
                Assert.Equal(2, listResponse.Indexes.Count);

                IList<string> indexNames = listResponse.Indexes.Select(i => i.Name).ToList();
                Assert.Contains(index1.Name, indexNames);
                Assert.Contains(index2.Name, indexNames);

                indexNames = searchClient.Indexes.ListNames();
                Assert.Equal(2, indexNames.Count);
                Assert.Contains(index1.Name, indexNames);
                Assert.Contains(index2.Name, indexNames);
            });
        }

        [Fact]
        public void ExistsReturnsTrueForExistingIndex()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Index index = CreateTestIndex();
                client.Indexes.Create(index);

                Assert.True(client.Indexes.Exists(index.Name));
            });
        }

        [Fact]
        public void ExistsReturnsFalseForNonExistingIndex()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Assert.False(client.Indexes.Exists("invalidindex"));
            });
        }

        private static Index MutateIndex(Index index)
        {
            index.CorsOptions.AllowedOrigins = new[] { "*" };
            return index;
        }

        private static void AssertIndexesEqual(Index expected, Index actual)
        {
            Assert.Equal(expected, actual, new ModelComparer<Index>());
        }

        private Index CreateOrUpdateIndex(Index index, SearchRequestOptions options, AccessCondition condition) =>
            Data.GetSearchServiceClient().Indexes.CreateOrUpdate(index, null, options, condition);
    }
}

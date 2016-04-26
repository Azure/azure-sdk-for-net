// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public sealed class IndexManagementTests : SearchTestBase<SearchServiceFixture>
    {
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

                CloudException e = Assert.Throws<CloudException>(() => searchClient.Indexes.Create(index));
                const string ExpectedMessageFormat =
                    "The request is invalid. Details: index : Found 0 key fields in index '{0}'. " +
                    "Each index must have exactly one key field.";

                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Contains(String.Format(ExpectedMessageFormat, index.Name), e.Message);
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
                CloudException e = 
                    Assert.Throws<CloudException>(() => searchClient.Indexes.Get("thisindexdoesnotexist"));
                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
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

        [Fact]
        public void CanUseAllAnalyzerNamesInIndexDefinition()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();

                Index index = 
                    new Index() 
                    { 
                        Name = SearchTestUtilities.GenerateName(),
                        Fields = new[] { new Field("id", DataType.String) { IsKey = true } }.ToList()
                    };

                AnalyzerName[] allAnalyzers =
                    (from field in typeof(AnalyzerName).GetFields()
                    where field.FieldType == typeof(AnalyzerName) && field.IsStatic
                    select field.GetValue(null)).Cast<AnalyzerName>().ToArray();

                for (int i = 0; i < allAnalyzers.Length; i++)
                {
                    string fieldName = String.Format("field{0}", i);

                    DataType fieldType = (i % 2 == 0) ? DataType.String : DataType.Collection(DataType.String);
                    index.Fields.Add(new Field(fieldName, fieldType, allAnalyzers[i]));
                }

                client.Indexes.Create(index);
            });
        }

        private static Index CreateTestIndex()
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
                            new MagnitudeScoringFunction("rating", 3.0, new MagnitudeScoringParameters(0, 10))
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
                            new MagnitudeScoringFunction("rating", 3.14, new MagnitudeScoringParameters(1, 5))
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

        private static void AssertIndexesEqual(Index expected, Index actual)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);
            
            Assert.Equal(expected.Name, actual.Name);

            AssertCollectionsEqual(expected.Fields, actual.Fields, AssertFieldsEqual);
            AssertCollectionsEqual(expected.ScoringProfiles, actual.ScoringProfiles, AssertScoringProfilesEqual);

            Assert.Equal(expected.DefaultScoringProfile, actual.DefaultScoringProfile);

            AssertCorsOptionsEqual(expected.CorsOptions, actual.CorsOptions);

            AssertCollectionsEqual(expected.Suggesters, actual.Suggesters, AssertSuggestersEqual);
        }

        private static void AssertFieldsEqual(Field expected, Field actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(expected.IsKey, actual.IsKey);
            Assert.Equal(expected.IsFacetable, actual.IsFacetable);
            Assert.Equal(expected.IsFilterable, actual.IsFilterable);
            Assert.Equal(expected.IsRetrievable, actual.IsRetrievable);
            Assert.Equal(expected.IsSearchable, actual.IsSearchable);
            Assert.Equal(expected.IsSortable, actual.IsSortable);
            Assert.Equal(expected.Analyzer, actual.Analyzer);
        }

        private static void AssertScoringProfilesEqual(ScoringProfile expected, ScoringProfile actual)
        {
            Assert.Equal(expected.Name, actual.Name);

            if (expected.TextWeights == null)
            {
                Assert.Null(actual.TextWeights);
            }
            else
            {
                AssertCollectionsEqual(
                    expected.TextWeights.Weights, 
                    actual.TextWeights.Weights, 
                    AssertTextWeightsEqual);
            }

            AssertCollectionsEqual(expected.Functions, actual.Functions, AssertScoringFunctionsEqual);
        }

        private static void AssertCorsOptionsEqual(CorsOptions expected, CorsOptions actual)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);

            AssertCollectionsEqual(expected.AllowedOrigins, actual.AllowedOrigins);
            
            Assert.Equal(expected.MaxAgeInSeconds, actual.MaxAgeInSeconds);
        }

        private static void AssertSuggestersEqual(Suggester expected, Suggester actual)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.SearchMode, actual.SearchMode);

            AssertCollectionsEqual(expected.SourceFields, actual.SourceFields);
        }

        private static void AssertTextWeightsEqual(
            KeyValuePair<string, double> expected, 
            KeyValuePair<string, double> actual)
        {
            Assert.Equal(expected.Key, actual.Key);
            Assert.Equal(expected.Value, actual.Value);
        }

        private static void AssertScoringFunctionsEqual(ScoringFunction expected, ScoringFunction actual)
        {
            Assert.IsType(expected.GetType(), actual);
            Assert.Equal(expected.FieldName, actual.FieldName);
            Assert.Equal(expected.Boost, actual.Boost);
            Assert.Equal(expected.Interpolation, actual.Interpolation);

            var expectedMagnitudeFunction = expected as MagnitudeScoringFunction;
            var expectedFreshnessFunction = expected as FreshnessScoringFunction;
            var expectedDistanceFunction = expected as DistanceScoringFunction;
            var expectedTagFunction = expected as TagScoringFunction;

            if (expectedMagnitudeFunction != null)
            {
                AssertMagnitudeScoringFunctionsEqual(expectedMagnitudeFunction, (MagnitudeScoringFunction)actual);
            }
            else if (expectedFreshnessFunction != null)
            {
                AssertFreshnessScoringFunctionsEqual(expectedFreshnessFunction, (FreshnessScoringFunction)actual);
            }
            else if (expectedDistanceFunction != null)
            {
                AssertDistanceScoringFunctionsEqual(expectedDistanceFunction, (DistanceScoringFunction)actual);
            }
            else if (expectedTagFunction != null)
            {
                AssertTagScoringFunctionsEqual(expectedTagFunction, (TagScoringFunction)actual);
            }
            else
            {
                Assert.True(false, "Unexpected scoring function type.");
            }
        }

        private static void AssertMagnitudeScoringFunctionsEqual(
            MagnitudeScoringFunction expected, 
            MagnitudeScoringFunction actual)
        {
            Assert.NotNull(expected.Parameters);
            Assert.NotNull(actual.Parameters);

            Assert.Equal(expected.Parameters.BoostingRangeEnd, actual.Parameters.BoostingRangeEnd);
            Assert.Equal(expected.Parameters.BoostingRangeStart, actual.Parameters.BoostingRangeStart);
            Assert.Equal(
                expected.Parameters.ShouldBoostBeyondRangeByConstant.GetValueOrDefault(), 
                actual.Parameters.ShouldBoostBeyondRangeByConstant.GetValueOrDefault());
        }

        private static void AssertFreshnessScoringFunctionsEqual(
            FreshnessScoringFunction expected,
            FreshnessScoringFunction actual)
        {
            Assert.NotNull(expected.Parameters);
            Assert.NotNull(actual.Parameters);

            Assert.Equal(expected.Parameters.BoostingDuration, actual.Parameters.BoostingDuration);
        }

        private static void AssertDistanceScoringFunctionsEqual(
            DistanceScoringFunction expected,
            DistanceScoringFunction actual)
        {
            Assert.NotNull(expected.Parameters);
            Assert.NotNull(actual.Parameters);

            Assert.Equal(expected.Parameters.BoostingDistance, actual.Parameters.BoostingDistance);
            Assert.Equal(expected.Parameters.ReferencePointParameter, actual.Parameters.ReferencePointParameter);
        }

        private static void AssertTagScoringFunctionsEqual(
            TagScoringFunction expected,
            TagScoringFunction actual)
        {
            Assert.NotNull(expected.Parameters);
            Assert.NotNull(actual.Parameters);

            Assert.Equal(expected.Parameters.TagsParameter, actual.Parameters.TagsParameter);
        }

        private static void AssertCollectionsEqual<T>(
            IEnumerable<T> expected, 
            IEnumerable<T> actual, 
            Action<T, T> assertElementsEqual = null)
        {
            assertElementsEqual = assertElementsEqual ?? ((a, b) => Assert.Equal(a, b));

            Assert.NotNull(expected);
            Assert.NotNull(actual);

            T[] expectedArray = expected.ToArray();
            T[] actualArray = actual.ToArray();

            Assert.Equal(expectedArray.Length, actualArray.Length);

            for (int i = 0; i < expectedArray.Length; i++)
            {
                T expectedElement = expectedArray[i];
                T actualElement = actualArray[i];

                assertElementsEqual(expectedElement, actualElement);
            }
        }
    }
}

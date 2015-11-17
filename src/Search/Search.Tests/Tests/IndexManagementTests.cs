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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class IndexManagementTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CreateIndexReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
                
                AssertIndexesEqual(index, createResponse.Index);
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
                            new MagnitudeScoringFunction(new MagnitudeScoringParameters(1, 4), "rating", 2.0)
                        }
                    }
                };

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(inputIndex);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                Index resultIndex = createResponse.Index;

                const long ExpectedMaxAgeInSeconds = 5 * 60;
                Assert.Equal(ExpectedMaxAgeInSeconds, resultIndex.CorsOptions.MaxAgeInSeconds);

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

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                IndexDefinitionResponse getResponse = searchClient.Indexes.Get(index.Name);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                AssertIndexesEqual(index, getResponse.Index);
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

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(initialIndex);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Give the index time to stabilize before continuing the test.
                // TODO: Remove this workaround once the retry hang bug is fixed.
                TestUtilities.Wait(TimeSpan.FromSeconds(20));

                // Now update the index.
                Index index = createResponse.Index;
                index.ScoringProfiles = fullFeaturedIndex.ScoringProfiles;
                index.DefaultScoringProfile = fullFeaturedIndex.DefaultScoringProfile;
                index.CorsOptions.AllowedOrigins = fullFeaturedIndex.CorsOptions.AllowedOrigins;

                IndexDefinitionResponse updateResponse = searchClient.Indexes.CreateOrUpdate(index);
                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

                AssertIndexesEqual(fullFeaturedIndex, updateResponse.Index);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenIndexDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();

                IndexDefinitionResponse createOrUpdateResponse = searchClient.Indexes.CreateOrUpdate(index);
                Assert.Equal(HttpStatusCode.Created, createOrUpdateResponse.StatusCode);
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
                AzureOperationResponse deleteResponse = searchClient.Indexes.Delete(index.Name);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Now delete twice.
                deleteResponse = searchClient.Indexes.Delete(index.Name);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                deleteResponse = searchClient.Indexes.Delete(index.Name);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
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

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                IndexGetStatisticsResponse stats = searchClient.Indexes.GetStatistics(index.Name);
                Assert.Equal(HttpStatusCode.OK, stats.StatusCode);
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

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Explicitly delete the index to test the Delete operation. Otherwise the UndoHandler would delete it.
                AzureOperationResponse deleteResponse = searchClient.Indexes.Delete(index.Name);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
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

                IndexDefinitionResponse createResponse = searchClient.Indexes.Create(index1);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                createResponse = searchClient.Indexes.Create(index2);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                IndexListResponse listResponse = searchClient.Indexes.List();
                Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
                Assert.Equal(2, listResponse.Indexes.Count);

                IEnumerable<string> indexNames = listResponse.Indexes.Select(i => i.Name);
                Assert.Contains(index1.Name, indexNames);
                Assert.Contains(index2.Name, indexNames);

                IndexListNamesResponse listNamesResponse = searchClient.Indexes.ListNames();
                Assert.Equal(HttpStatusCode.OK, listNamesResponse.StatusCode);
                Assert.Equal(2, listNamesResponse.IndexNames.Count);

                indexNames = listNamesResponse.IndexNames;
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

                Index index = new Index() { Name = TestUtilities.GenerateName() };
                index.Fields.Add(new Field("id", DataType.String) { IsKey = true });

                var allAnalyzers =
                    new[]
                    {
                        AnalyzerName.ArLucene,
                        AnalyzerName.CsLucene,
                        AnalyzerName.DaLucene,
                        AnalyzerName.DeLucene,
                        AnalyzerName.ElLucene,
                        AnalyzerName.EnLucene,
                        AnalyzerName.EsLucene,
                        AnalyzerName.FiLucene,
                        AnalyzerName.FrLucene,
                        AnalyzerName.HiLucene,
                        AnalyzerName.HuLucene,
                        AnalyzerName.IdLucene,
                        AnalyzerName.ItLucene,
                        AnalyzerName.JaLucene,
                        AnalyzerName.KoLucene,
                        AnalyzerName.LvLucene,
                        AnalyzerName.NlLucene,
                        AnalyzerName.NoLucene,
                        AnalyzerName.PlLucene,
                        AnalyzerName.PtBRLucene,
                        AnalyzerName.PtPTLucene,
                        AnalyzerName.RoLucene,
                        AnalyzerName.RuLucene,
                        AnalyzerName.StandardAsciiFoldingLucene,
                        AnalyzerName.StandardLucene,
                        AnalyzerName.SvLucene,
                        AnalyzerName.ThLucene,
                        AnalyzerName.ZhHansLucene,
                        AnalyzerName.ZhHantLucene,
                        AnalyzerName.ArMicrosoft,
                        AnalyzerName.BgMicrosoft,
                        AnalyzerName.BnMicrosoft,
                        AnalyzerName.CaMicrosoft,
                        AnalyzerName.CsMicrosoft,
                        AnalyzerName.DaMicrosoft,
                        AnalyzerName.DeMicrosoft,
                        AnalyzerName.ElMicrosoft,
                        AnalyzerName.EnMicrosoft,
                        AnalyzerName.EsMicrosoft,
                        AnalyzerName.EtMicrosoft,
                        AnalyzerName.FiMicrosoft,
                        AnalyzerName.FrMicrosoft,
                        AnalyzerName.HeMicrosoft,
                        AnalyzerName.HiMicrosoft,
                        AnalyzerName.HrMicrosoft,
                        AnalyzerName.HuMicrosoft,
                        AnalyzerName.GuMicrosoft,
                        AnalyzerName.IdMicrosoft,
                        AnalyzerName.IsMicrosoft,
                        AnalyzerName.ItMicrosoft,
                        AnalyzerName.JaMicrosoft,
                        AnalyzerName.KnMicrosoft,
                        AnalyzerName.LtMicrosoft,
                        AnalyzerName.LvMicrosoft,
                        AnalyzerName.NlMicrosoft,
                        AnalyzerName.NbMicrosoft,
                        AnalyzerName.MlMicrosoft,
                        AnalyzerName.MsMicrosoft,
                        AnalyzerName.MrMicrosoft,
                        AnalyzerName.PaMicrosoft,
                        AnalyzerName.PlMicrosoft,
                        AnalyzerName.PtPtMicrosoft,
                        AnalyzerName.PtBrMicrosoft,
                        AnalyzerName.RoMicrosoft,
                        AnalyzerName.RuMicrosoft,
                        AnalyzerName.SkMicrosoft,
                        AnalyzerName.SlMicrosoft,
                        AnalyzerName.SrCyrillicMicrosoft,
                        AnalyzerName.SrLatinMicrosoft,
                        AnalyzerName.SvMicrosoft,
                        AnalyzerName.TaMicrosoft,
                        AnalyzerName.TeMicrosoft,
                        AnalyzerName.TrMicrosoft,
                        AnalyzerName.ThMicrosoft,
                        AnalyzerName.UkMicrosoft,
                        AnalyzerName.UrMicrosoft,
                        AnalyzerName.ViMicrosoft,
                        AnalyzerName.ZhHansMicrosoft,
                        AnalyzerName.ZhHantMicrosoft
                    };

                for (int i = 0; i < allAnalyzers.Length; i++)
                {
                    string fieldName = String.Format("field{0}", i);

                    DataType fieldType = (i % 2 == 0) ? DataType.String : DataType.Collection(DataType.String);
                    index.Fields.Add(new Field(fieldName, fieldType, allAnalyzers[i]));
                }

                IndexDefinitionResponse createResponse = client.Indexes.Create(index);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
            });
        }

        private static Index CreateTestIndex()
        {
            string indexName = TestUtilities.GenerateName();

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
                                new MagnitudeScoringParameters(1, 4) { ShouldBoostBeyondRangeByConstant = true },
                                "rating",
                                2.0) { Interpolation = ScoringFunctionInterpolation.Constant },
                            new DistanceScoringFunction(
                                new DistanceScoringParameters("loc", 5),
                                "location",
                                1.5) { Interpolation = ScoringFunctionInterpolation.Linear },
                            new FreshnessScoringFunction(
                                new FreshnessScoringParameters(TimeSpan.FromDays(365)),
                                "lastRenovationDate",
                                1.1) { Interpolation = ScoringFunctionInterpolation.Logarithmic }
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
                            new TagScoringFunction(new TagScoringParameters("mytags"), "tags", 1.5)
                            {
                                Interpolation = ScoringFunctionInterpolation.Linear
                            }
                        }
                    },
                    new ScoringProfile("ProfileThree")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Minimum,
                        Functions = new[]
                        {
                            new MagnitudeScoringFunction(new MagnitudeScoringParameters(0, 10), "rating", 3.0)
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
                            new MagnitudeScoringFunction(new MagnitudeScoringParameters(1, 5), "rating", 3.14)
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
                expected.Parameters.ShouldBoostBeyondRangeByConstant, 
                actual.Parameters.ShouldBoostBeyondRangeByConstant);
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

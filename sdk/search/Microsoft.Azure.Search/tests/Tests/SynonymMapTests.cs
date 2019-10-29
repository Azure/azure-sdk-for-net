// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Xunit;

    public sealed class SynonymMapTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CreateSynonymMapReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSynonymMap(searchClient, CreateTestSynonymMap());
            });
        }

        [Fact]
        public void CreateSynonymMapFailsWithUsefulMessageOnUserError()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SynonymMap synonymMap = CreateTestSynonymMap();
                synonymMap.Synonyms = "a => b => c"; // invalid

                SearchAssert.ThrowsCloudException(
                    () => searchClient.SynonymMaps.Create(synonymMap),
                    HttpStatusCode.BadRequest,
                    "Syntax error in line 1: 'a => b => c'. Only one explicit mapping (=>) can be specified in a synonym rule.");
            });
        }

        [Fact]
        public void GetSynonymMapReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndGetSynonymMap(searchClient, CreateTestSynonymMap());
            });
        }

        [Fact]
        public void GetSynonymMapThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SearchAssert.ThrowsCloudException(
                    () => searchClient.SynonymMaps.Get("thisSynonymMapdoesnotexist"),
                    HttpStatusCode.NotFound);
            });
        }

        [Fact]
        public void CanUpdateSynonymMap()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SynonymMap initial = CreateTestSynonymMap();

                searchClient.SynonymMaps.Create(initial);

                SynonymMap updatedExpected = CreateTestSynonymMap();
                updatedExpected.Name = initial.Name;
                updatedExpected.Synonyms = "new_aaa, new_bbb";

                SynonymMap updatedActual = searchClient.SynonymMaps.CreateOrUpdate(updatedExpected);

                AssertSynonymMapsEqual(updatedExpected, updatedActual);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenSynonymMapDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SynonymMap synonymMap = CreateTestSynonymMap();

                AzureOperationResponse<SynonymMap> response =
                    searchClient.SynonymMaps.CreateOrUpdateWithHttpMessagesAsync(synonymMap).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            });
        }

        [Fact]
        public void CreateOrUpdateSynonymMapIfNotExistsFailsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsFailsOnExistingResource(
                    Data.GetSearchServiceClient().SynonymMaps.CreateOrUpdate,
                    CreateTestSynonymMap,
                    MutateSynonymMap);
            });
        }

        [Fact]
        public void CreateOrUpdateSynonymMapIfNotExistsSucceedsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsSucceedsOnNoResource(
                    Data.GetSearchServiceClient().SynonymMaps.CreateOrUpdate,
                    CreateTestSynonymMap);
            });
        }

        [Fact]
        public void UpdateSynonymMapIfExistsSucceedsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsSucceedsOnExistingResource(
                    Data.GetSearchServiceClient().SynonymMaps.CreateOrUpdate,
                    CreateTestSynonymMap,
                    MutateSynonymMap);
            });
        }

        [Fact]
        public void UpdateSynonymMapIfExistsFailsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsFailsOnNoResource(
                    Data.GetSearchServiceClient().SynonymMaps.CreateOrUpdate,
                    CreateTestSynonymMap);
            });
        }

        [Fact]
        public void UpdateSynonymMapIfNotChangedSucceedsWhenResourceUnchanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedSucceedsWhenResourceUnchanged(
                    Data.GetSearchServiceClient().SynonymMaps.CreateOrUpdate,
                    CreateTestSynonymMap,
                    MutateSynonymMap);
            });
        }

        [Fact]
        public void UpdateSynonymMapIfNotChangedFailsWhenResourceChanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedFailsWhenResourceChanged(
                    Data.GetSearchServiceClient().SynonymMaps.CreateOrUpdate,
                    CreateTestSynonymMap,
                    MutateSynonymMap);
            });
        }

        [Fact]
        public void DeleteSynonymMapIfNotChangedWorksOnlyOnCurrentResource()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SynonymMap synonymMap = CreateTestSynonymMap();

                AccessConditionTests.DeleteIfNotChangedWorksOnlyOnCurrentResource(
                    searchClient.SynonymMaps.Delete,
                    () => searchClient.SynonymMaps.CreateOrUpdate(synonymMap),
                    x => searchClient.SynonymMaps.CreateOrUpdate(MutateSynonymMap(x)),
                    synonymMap.Name);
            });
        }

        [Fact]
        public void DeleteSynonymMapIfExistsWorksOnlyWhenResourceExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SynonymMap synonymMap = CreateTestSynonymMap();

                AccessConditionTests.DeleteIfExistsWorksOnlyWhenResourceExists(
                    searchClient.SynonymMaps.Delete,
                    () => searchClient.SynonymMaps.CreateOrUpdate(synonymMap),
                    synonymMap.Name);
            });
        }

        [Fact]
        public void DeleteSynonymMapIsIdempotent()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SynonymMap synonymMap = CreateTestSynonymMap();

                // Try delete before the SynonymMap even exists.
                AzureOperationResponse deleteResponse =
                    searchClient.SynonymMaps.DeleteWithHttpMessagesAsync(synonymMap.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);

                searchClient.SynonymMaps.Create(synonymMap);

                // Now delete twice.
                deleteResponse = searchClient.SynonymMaps.DeleteWithHttpMessagesAsync(synonymMap.Name).Result;
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                deleteResponse = searchClient.SynonymMaps.DeleteWithHttpMessagesAsync(synonymMap.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);
            });
        }

        [Fact]
        public void CanCreateAndListSynonymMaps()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                // Create a SynonymMap of each supported type
                SynonymMap synonymMap1 = CreateTestSynonymMap();
                SynonymMap synonymMap2 = CreateTestSynonymMap();

                searchClient.SynonymMaps.Create(synonymMap1);
                searchClient.SynonymMaps.Create(synonymMap2);

                SynonymMapListResult listResponse = searchClient.SynonymMaps.List();
                Assert.Equal(2, listResponse.SynonymMaps.Count);

                IEnumerable<string> synonymMapNames = listResponse.SynonymMaps.Select(i => i.Name);
                Assert.Contains(synonymMap1.Name, synonymMapNames);
                Assert.Contains(synonymMap2.Name, synonymMapNames);
            });
        }

        [Fact]
        public void ExistsReturnsTrueForExistingSynonymMap()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                SynonymMap synonymMap = CreateTestSynonymMap();
                client.SynonymMaps.Create(synonymMap);

                Assert.True(client.SynonymMaps.Exists(synonymMap.Name));
            });
        }

        [Fact]
        public void ExistsReturnsFalseForNonExistingSynonymMap()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Assert.False(client.SynonymMaps.Exists("nonexistent"));
            });
        }

        private void CreateAndValidateSynonymMap(SearchServiceClient searchClient, SynonymMap expectedSynonymMap)
        {
            SynonymMap actualSynonymMap = searchClient.SynonymMaps.Create(expectedSynonymMap);

            try
            {
                AssertSynonymMapsEqual(expectedSynonymMap, actualSynonymMap);
            }
            finally
            {
                searchClient.SynonymMaps.Delete(expectedSynonymMap.Name);
            }
        }

        private void CreateAndGetSynonymMap(SearchServiceClient searchClient, SynonymMap expectedSynonymMap)
        {
            searchClient.SynonymMaps.Create(expectedSynonymMap);

            try
            {
                SynonymMap actualSynonymMap = searchClient.SynonymMaps.Get(expectedSynonymMap.Name);
                AssertSynonymMapsEqual(expectedSynonymMap, actualSynonymMap);
            }
            finally
            {
                searchClient.SynonymMaps.Delete(expectedSynonymMap.Name);
            }
        }

        private static void AssertSynonymMapsEqual(SynonymMap expected, SynonymMap actual)
        {
            Assert.Equal(expected, actual, new DataPlaneModelComparer<SynonymMap>());
        }

        private static SynonymMap CreateTestSynonymMap()
        {
            return new SynonymMap(name: SearchTestUtilities.GenerateName(), synonyms: "word1,word2");
        }

        private static SynonymMap MutateSynonymMap(SynonymMap synonymMap)
        {
            synonymMap.Synonyms = "mutated1, mutated2";
            return synonymMap;
        }
    }
}

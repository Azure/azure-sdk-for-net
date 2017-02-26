// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using OperationalInsights.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace OperationalInsights.Test.ScenarioTests
{
    public class SearchOperationsTests : TestBase
    {

        [Fact]
        public void CanGetSearchResultsAndUpdate()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                // Rasha's workspace is the only one in int with cold data, which is necessary to test the update search method
                string resourceGroupName = "OI-Default-East-US";
                string workspaceName = "rasha";
                int topCount = 25;

                SearchGetSearchResultsParameters parameters = new SearchGetSearchResultsParameters();
                parameters.Query = "*";
                parameters.Top = topCount;
                var searchResult = client.Search.GetSearchResults(resourceGroupName, workspaceName, parameters);
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.__metadata);
                Assert.NotNull(searchResult.Value);
                Assert.Equal(searchResult.Value.Count, topCount);

                var updatedSearchResult = client.Search.UpdateSearchResults(
                    resourceGroupName,
                    workspaceName,
                    searchResult.__metadata.RequestId);
                Assert.NotNull(updatedSearchResult);
                Assert.NotNull(searchResult.__metadata);
                Assert.NotNull(searchResult.Value);
            }
        }

        [Fact]
        public void CanGetSchema()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";

                var schemaResult = client.Search.GetSchema(resourceGroupName, workspaceName);

                Assert.NotNull(schemaResult);
                Assert.NotNull(schemaResult.__metadata);
                Assert.Equal(schemaResult.__metadata.ResultType, "schema");
                Assert.NotNull(schemaResult.Value);
                Assert.NotEqual(schemaResult.Value.Count, 0);
            }
        }

        [Fact]
        public void CanGetSavedSearchesAndResults()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";

                var savedSearchesResult = client.Search.ListSavedSearches(resourceGroupName, workspaceName);

                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(savedSearchesResult.Value.Count, 0);

                String[] idStrings = savedSearchesResult.Value[0].Id.Split('/');
                string id = idStrings[idStrings.Length - 1];

                var savedSearchResult = client.Search.GetSavedSearch(
                    resourceGroupName,
                    workspaceName,
                    id);
                Assert.NotNull(savedSearchResult);
                Assert.NotNull(savedSearchResult.Etag);
                Assert.NotEqual(savedSearchResult.Etag, "");
                Assert.NotNull(savedSearchResult.Id);
                Assert.NotEqual(savedSearchResult.Id, "");
                Assert.NotNull(savedSearchResult.Query);
                Assert.NotEqual(savedSearchResult.Query, "");

                var savedSearchResults = client.Search.GetSavedSearchResults(resourceGroupName, workspaceName, id);
                Assert.NotNull(savedSearchResults);
                Assert.NotNull(savedSearchResults.__metadata);
                Assert.NotNull(savedSearchResults.Value);
                Assert.NotEqual(savedSearchResults.Value.Count, 0);
            }
        }

        [Fact]
        public void CanCreateOrUpdateAndDeleteSavedSearches()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";
                string newSavedSearchId = "test-new-saved-search-id-2015";

                SearchCreateOrUpdateSavedSearchParameters parameters = new SearchCreateOrUpdateSavedSearchParameters();
                parameters.Version = 1;
                parameters.Query = "* | measure Count() by Computer";
                parameters.DisplayName = "Create or Update Saved Search Test";
                parameters.Category = " Saved Search Test Category";
                parameters.Tags = new List<Tag>() { new Tag() { Name = "Group", Value = "Computer" } };

                var result = client.Search.ListSavedSearches(resourceGroupName, workspaceName);

                client.Search.CreateOrUpdateSavedSearch(
                    resourceGroupName,
                    workspaceName,
                    newSavedSearchId,
                    parameters);

                // Verify that the saved search was saved
                var savedSearchesResult = client.Search.ListSavedSearches(resourceGroupName, workspaceName);
                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(savedSearchesResult.Value.Count, 0);
                Assert.NotNull(savedSearchesResult.Value[0].Id);
                Assert.NotNull(savedSearchesResult.Value[0].Query);
                bool foundSavedSearch = false;
                for (int i = 0; i < savedSearchesResult.Value.Count; i++)
                {
                    if (savedSearchesResult.Value[i].Category.Equals(parameters.Category)
                        && savedSearchesResult.Value[i].Version == parameters.Version
                        && savedSearchesResult.Value[i].Query.Equals(parameters.Query)
                        && savedSearchesResult.Value[i].DisplayName.Equals(parameters.DisplayName)
                        && savedSearchesResult.Value[i].Tags[0].Name.Equals(parameters.Tags[0].Name)
                        && savedSearchesResult.Value[i].Tags[0].Value.Equals(parameters.Tags[0].Value))
                    {
                        foundSavedSearch = true;
                        parameters.Etag = savedSearchesResult.Value[i].Etag;
                    }
                }
                Assert.True(foundSavedSearch);

                // Test updating a saved search
                parameters.Query = "*";
                parameters.Tags = new List<Tag>() { new Tag() { Name = "Source", Value = "Test2" } };
                client.Search.CreateOrUpdateSavedSearch(
                    resourceGroupName,
                    workspaceName,
                    newSavedSearchId,
                    parameters);

                // Verify that the saved search was saved
                savedSearchesResult = client.Search.ListSavedSearches(resourceGroupName, workspaceName);
                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(savedSearchesResult.Value.Count, 0);
                Assert.NotNull(savedSearchesResult.Value[0].Id);
                Assert.Equal(savedSearchesResult.Value[0].Query, "*");
                foundSavedSearch = false;
                for (int i = 0; i < savedSearchesResult.Value.Count; i++)
                {
                    if (savedSearchesResult.Value[i].Category.Equals(parameters.Category)
                        && savedSearchesResult.Value[i].Version == parameters.Version
                        && savedSearchesResult.Value[i].Query.Equals(parameters.Query)
                        && savedSearchesResult.Value[i].DisplayName.Equals(parameters.DisplayName)
                        && savedSearchesResult.Value[i].Tags[0].Name.Equals(parameters.Tags[0].Name)
                        && savedSearchesResult.Value[i].Tags[0].Value.Equals(parameters.Tags[0].Value))
                    {
                        foundSavedSearch = true;
                    }
                }
                Assert.True(foundSavedSearch);

                // Test the function to delete a saved search
                client.Search.DeleteSavedSearch(resourceGroupName, workspaceName, newSavedSearchId);
                savedSearchesResult = client.Search.ListSavedSearches(resourceGroupName, workspaceName);

                foundSavedSearch = false;
                for (int i = 0; i < savedSearchesResult.Value.Count; i++)
                {
                    if (savedSearchesResult.Value[i].Category.Equals(parameters.Category)
                        && savedSearchesResult.Value[i].Version == parameters.Version
                        && savedSearchesResult.Value[i].Query.Equals(parameters.Query)
                        && savedSearchesResult.Value[i].DisplayName.Equals(parameters.DisplayName))
                    {
                        foundSavedSearch = true;
                    }
                }
                Assert.False(foundSavedSearch);
            }
        }
    }
}
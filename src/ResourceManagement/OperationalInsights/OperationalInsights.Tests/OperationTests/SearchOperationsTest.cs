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
using Microsoft.Azure.Test;
using OperationalInsights.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Tests.OperationTests
{
    public class SearchOperationsTest : TestBase
    {

        [Fact]
        public void CanGetSearchResultsAndUpdate()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                // Rasha's workspace is the only one in int with cold data, which is necessary to test the update search method
                string resourceGroupName = "OI-Default-East-US";
                string workspaceName = "rasha";
                int topCount = 25;

                SearchGetSearchResultsParameters parameters = new SearchGetSearchResultsParameters();
                parameters.Query = "*";
                parameters.Top = topCount;
                var searchResult = client.Search.GetSearchResults(resourceGroupName, workspaceName, parameters);
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.Metadata);
                Assert.NotNull(searchResult.Value);
                Assert.Equal(searchResult.Value.Count, topCount);

                var updatedSearchResult = client.Search.UpdateSearchResults(
                    resourceGroupName,
                    workspaceName,
                    searchResult.Metadata.SearchId);
                Assert.NotNull(updatedSearchResult);
                Assert.NotNull(searchResult.Metadata);
                Assert.NotNull(searchResult.Value);
            }
        }

        [Fact]
        public void CanGetSchema()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";

                var schemaResult = client.Search.GetSchema(resourceGroupName, workspaceName);

                Assert.NotNull(schemaResult);
                Assert.NotNull(schemaResult.Metadata);
                Assert.Equal(schemaResult.Metadata.ResultType, "schema");
                Assert.NotNull(schemaResult.Value);
                Assert.NotEqual(schemaResult.Value.Count, 0);
            }
        }

        [Fact]
        public void CanGetSavedSearchesAndResults()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

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
                Assert.NotNull(savedSearchResult.ETag);
                Assert.NotEqual(savedSearchResult.ETag, "");
                Assert.NotNull(savedSearchResult.Id);
                Assert.NotEqual(savedSearchResult.Id, "");
                Assert.NotNull(savedSearchResult.Properties);
                Assert.NotNull(savedSearchResult.Properties.Query);
                Assert.NotEqual(savedSearchResult.Properties.Query, "");

                var savedSearchResults = client.Search.GetSavedSearchResults(resourceGroupName, workspaceName, id);
                Assert.NotNull(savedSearchResults);
                Assert.NotNull(savedSearchResults.Metadata);
                Assert.NotNull(savedSearchResults.Value);
                Assert.NotEqual(savedSearchResults.Value.Count, 0);
            }
        }

        [Fact]
        public void CanCreateOrUpdateAndDeleteSavedSearches()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = TestHelper.GetOperationalInsightsManagementClient(handler);

                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";
                string newSavedSearchId = "test-new-saved-search-id-2015";

                SearchCreateOrUpdateSavedSearchParameters parameters = new SearchCreateOrUpdateSavedSearchParameters();
                parameters.Properties = new SavedSearchProperties();
                parameters.Properties.Version = 1;
                parameters.Properties.Query = "* | measure Count() by Computer";
                parameters.Properties.DisplayName = "Create or Update Saved Search Test";
                parameters.Properties.Category = " Saved Search Test Category";
                parameters.Properties.Tags = new List<Tag>() { new Tag() { Name = "Group", Value = "Computer" } };

                var result = client.Search.ListSavedSearches(resourceGroupName, workspaceName);

                var createSavedSearchResults = client.Search.CreateOrUpdateSavedSearch(
                    resourceGroupName,
                    workspaceName,
                    newSavedSearchId,
                    parameters);
                Assert.NotNull(createSavedSearchResults);

                // Verify that the saved search was saved
                var savedSearchesResult = client.Search.ListSavedSearches(resourceGroupName, workspaceName);
                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(savedSearchesResult.Value.Count, 0);
                Assert.NotNull(savedSearchesResult.Value[0].Id);
                Assert.NotNull(savedSearchesResult.Value[0].Properties);
                bool foundSavedSearch = false;
                for (int i = 0; i < savedSearchesResult.Value.Count; i++)
                {
                    SavedSearchProperties properties = savedSearchesResult.Value[i].Properties;
                    if (properties.Category.Equals(parameters.Properties.Category)
                        && properties.Version == parameters.Properties.Version
                        && properties.Query.Equals(parameters.Properties.Query)
                        && properties.DisplayName.Equals(parameters.Properties.DisplayName)
                        && properties.Tags[0].Name.Equals(parameters.Properties.Tags[0].Name)
                        && properties.Tags[0].Value.Equals(parameters.Properties.Tags[0].Value))
                    {
                        foundSavedSearch = true;
                        parameters.ETag = savedSearchesResult.Value[i].ETag;
                    }
                }
                Assert.True(foundSavedSearch);

                // Test updating a saved search
                parameters.Properties.Query = "*";
                parameters.Properties.Tags = new List<Tag>() { new Tag() { Name = "Source", Value = "Test2" } };
                var updateSavedSearchResults = client.Search.CreateOrUpdateSavedSearch(
                    resourceGroupName,
                    workspaceName,
                    newSavedSearchId,
                    parameters);
                Assert.NotNull(updateSavedSearchResults);
                // Verify that the saved search was saved
                savedSearchesResult = client.Search.ListSavedSearches(resourceGroupName, workspaceName);
                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(savedSearchesResult.Value.Count, 0);
                Assert.NotNull(savedSearchesResult.Value[0].Id);
                Assert.NotNull(savedSearchesResult.Value[0].Properties);
                foundSavedSearch = false;
                for (int i = 0; i < savedSearchesResult.Value.Count; i++)
                {
                    SavedSearchProperties properties = savedSearchesResult.Value[i].Properties;
                    if (properties.Category.Equals(parameters.Properties.Category)
                        && properties.Version == parameters.Properties.Version
                        && properties.Query.Equals(parameters.Properties.Query)
                        && properties.DisplayName.Equals(parameters.Properties.DisplayName)
                        && properties.Tags[0].Name.Equals(parameters.Properties.Tags[0].Name)
                        && properties.Tags[0].Value.Equals(parameters.Properties.Tags[0].Value))
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
                    SavedSearchProperties properties = savedSearchesResult.Value[i].Properties;
                    if (properties.Category.Equals(parameters.Properties.Category)
                        && properties.Version == parameters.Properties.Version
                        && properties.Query.Equals(parameters.Properties.Query)
                        && properties.DisplayName.Equals(parameters.Properties.DisplayName))
                    {
                        foundSavedSearch = true;
                    }
                }
                Assert.False(foundSavedSearch);
            }
        }

    }
}

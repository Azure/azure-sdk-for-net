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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                // Since we are testing search operations, we can't just create a brand new workspace 
                // because there are no ARM APIs to ingest data to a workspace. 
                // But any workspace with data ingested should be good for this test.
                string resourceGroupName = "OI-Default-East-US";
                string workspaceName = "rasha";
                int topCount = 25;

                SearchParameters parameters = new SearchParameters();
                parameters.Query = "*";
                parameters.Top = topCount;
                var searchResult = client.Workspaces.GetSearchResults(resourceGroupName, workspaceName, parameters);
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.Metadata);
                Assert.NotNull(searchResult.Value);
                Assert.Equal(searchResult.Value.Count, topCount);

                var updatedSearchResult = client.Workspaces.UpdateSearchResults(
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                // Since we are testing search operations, we can't just create a brand new workspace 
                // because there are no ARM APIs to ingest data to a workspace. 
                // But any workspace with data ingested should be good for this test.
                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";

                var schemaResult = client.Workspaces.GetSchema(resourceGroupName, workspaceName);

                Assert.NotNull(schemaResult);
                Assert.NotNull(schemaResult.Metadata);
                Assert.Equal("schema", schemaResult.Metadata.ResultType);
                Assert.NotNull(schemaResult.Value);
                Assert.NotEqual(0, schemaResult.Value.Count);
            }
        }

        [Fact]
        public void CanGetSavedSearchesAndResults()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                // Since we are testing search operations, we can't just create a brand new workspace 
                // because there are no ARM APIs to ingest data to a workspace. 
                // But any workspace with data ingested should be good for this test.
                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";

                var savedSearchesResult = client.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);

                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(0, savedSearchesResult.Value.Count);

                String[] idStrings = savedSearchesResult.Value[0].Id.Split('/');
                string id = idStrings[idStrings.Length - 1];

                var savedSearchResult = client.SavedSearches.Get(
                    resourceGroupName,
                    workspaceName,
                    id);
                Assert.NotNull(savedSearchResult);
                Assert.NotNull(savedSearchResult.Etag);
                Assert.NotEqual("", savedSearchResult.Etag);
                Assert.NotNull(savedSearchResult.Id);
                Assert.NotEqual("", savedSearchResult.Id);
                Assert.NotNull(savedSearchResult.Query);
                Assert.NotEqual("", savedSearchResult.Query);

                var savedSearchResults = client.SavedSearches.GetResults(resourceGroupName, workspaceName, id);
                Assert.NotNull(savedSearchResults);
                Assert.NotNull(savedSearchResults.Metadata);
                Assert.NotNull(savedSearchResults.Value);
                Assert.NotEqual(0, savedSearchResults.Value.Count);
            }
        }

        [Fact]
        public void CanCreateOrUpdateAndDeleteSavedSearches()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);

                // Since we are testing search operations, we can't just create a brand new workspace 
                // because there are no ARM APIs to ingest data to a workspace. 
                // But any workspace with data ingested should be good for this test.
                string resourceGroupName = "mms-eus";
                string workspaceName = "workspace-861bd466-5400-44be-9552-5ba40823c3aa";
                string newSavedSearchId = "test-new-saved-search-id-2015";

                SavedSearch parameters = new SavedSearch();
                parameters.Version = 1;
                parameters.Query = "* | measure Count() by Computer";
                parameters.DisplayName = "Create or Update Saved Search Test";
                parameters.Category = " Saved Search Test Category";
                parameters.Tags = new List<Tag>() { new Tag() { Name = "Group", Value = "Computer" } };

                var result = client.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);
                
                var savedSearchCreateResponse = client.SavedSearches.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    newSavedSearchId,
                    parameters);

                Assert.NotNull(savedSearchCreateResponse.Id);
                Assert.NotNull(savedSearchCreateResponse.Etag);
                Assert.Equal(savedSearchCreateResponse.Query, parameters.Query);
                Assert.Equal(savedSearchCreateResponse.DisplayName, parameters.DisplayName);
                Assert.Equal(savedSearchCreateResponse.Tags[0].Name, parameters.Tags[0].Name);
                Assert.Equal(savedSearchCreateResponse.Tags[0].Value, parameters.Tags[0].Value);

                // Verify that the saved search was saved
                var savedSearchesResult = client.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);
                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(0, savedSearchesResult.Value.Count);
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
                var savedSearchUpdateResponse = client.SavedSearches.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    newSavedSearchId,
                    parameters);

                Assert.NotNull(savedSearchUpdateResponse.Id);
                Assert.NotNull(savedSearchUpdateResponse.Etag);
                Assert.Equal(savedSearchUpdateResponse.Query, parameters.Query);
                Assert.Equal(savedSearchUpdateResponse.DisplayName, parameters.DisplayName);
                Assert.Equal(savedSearchUpdateResponse.Tags[0].Name, parameters.Tags[0].Name);
                Assert.Equal(savedSearchUpdateResponse.Tags[0].Value, parameters.Tags[0].Value);

                // Verify that the saved search was saved
                savedSearchesResult = client.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);
                Assert.NotNull(savedSearchesResult);
                Assert.NotNull(savedSearchesResult.Value);
                Assert.NotEqual(0, savedSearchesResult.Value.Count);
                Assert.NotNull(savedSearchesResult.Value[0].Id);
                Assert.Equal("*", savedSearchesResult.Value[0].Query);
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
                client.SavedSearches.Delete(resourceGroupName, workspaceName, newSavedSearchId);
                savedSearchesResult = client.SavedSearches.ListByWorkspace(resourceGroupName, workspaceName);

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
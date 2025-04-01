// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Search : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void Search()
    {
        #region Snippet:ExtensionsSearch
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
#endif
        AIProjectClient client = new(connectionString);
        SearchClient searchClient = client.GetSearchClient("index");

        SearchResults<SearchDocument> response = searchClient.Search<SearchDocument>("luxury hotel");
        foreach (SearchResult<SearchDocument> result in response.GetResults())
        {
            SearchDocument doc = result.Document;
            string id = (string)doc["HotelId"];
            string name = (string)doc["HotelName"];
            Console.WriteLine($"{id}: {name}");
        }
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task SearchAsync()
    {
        #region Snippet:ExtensionsSearchAsync
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
#endif
        AIProjectClient client = new(connectionString);
        SearchClient searchClient = client.GetSearchClient("index");

        SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>("luxury hotel");
        await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
        {
            SearchDocument doc = result.Document;
            string id = (string)doc["HotelId"];
            string name = (string)doc["HotelName"];
            Console.WriteLine($"{id}: {name}");
        }
        #endregion
    }

    [Test]
    public void ThrowsWhenNoConnection()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        AIProjectClient client = new AIProjectClient(connectionString);

        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            SearchClient searchClient = client.GetSearchClient("index");
        });

        Assert.AreEqual(
            $"No connections found for '{ConnectionType.AzureAISearch}'. At least one connection is required. Please add a new connection in the Azure AI Foundry portal by following the instructions here: https://aka.ms/azsdk/azure-ai-projects/how-to/connections-add",
            ex.Message);
        Console.WriteLine(ex.Message);
    }
}

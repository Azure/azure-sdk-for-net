// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Search : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public void Search()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        AIProjectClient client = new AIProjectClient(connectionString);
        SearchClient searchClient = client.GetSearchClient("index");

        SearchResults<SearchDocument> response = searchClient.Search<SearchDocument>("luxury hotel");
        foreach (SearchResult<SearchDocument> result in response.GetResults())
        {
            SearchDocument doc = result.Document;
            string id = (string)doc["HotelId"];
            string name = (string)doc["HotelName"];
            Console.WriteLine($"{id}: {name}");
        }
    }
}

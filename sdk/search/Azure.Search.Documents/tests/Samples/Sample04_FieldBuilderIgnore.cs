// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name
    public class FieldBuilderIgnore :  SearchTestBase
    {
        public FieldBuilderIgnore(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, SearchClientOptions.LatestVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [SyncOnly]
        public async Task CreateIndex()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_CreateIndex
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

            // Define client options to use camelCase when serializing property names.
            SearchClientOptions options = new SearchClientOptions(ServiceVersion)
            {
                Serializer = new JsonObjectSerializer(
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    })
            };

            // Create a service client.
            AzureKeyCredential credential = new AzureKeyCredential(key);
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential, options);
#if !SNIPPET
            indexClient = resources.GetIndexClient(options);
#endif

            // Create the FieldBuilder using the same serializer.
            FieldBuilder fieldBuilder = new FieldBuilder
            {
                Serializer = options.Serializer
            };

            // Create the index using FieldBuilder.
#if SNIPPET
            SearchIndex index = new SearchIndex("movies")
#else
            SearchIndex index = new SearchIndex(Recording.Random.GetName())
#endif
            {
                Fields = fieldBuilder.Build(typeof(Movie)),
                Suggesters =
                {
                    // Suggest query terms from the "name" field.
                    new SearchSuggester("n", "name")
                }
            };

            // Define the "genre" field as a string.
            SearchableField genreField = new SearchableField("genre")
            {
                AnalyzerName = LexicalAnalyzerName.Values.EnLucene,
                IsFacetable = true,
                IsFilterable = true
            };
            index.Fields.Add(genreField);

            // Create the index.
            indexClient.CreateIndex(index);
            #endregion Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_CreateIndex

            // Make sure the index is removed.
            resources.IndexName = index.Name;

            #region Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_UploadDocument
            Movie movie = new Movie
            {
                Id = Guid.NewGuid().ToString("n"),
                Name = "The Lord of the Rings: The Return of the King",
                Genre = MovieGenre.Fantasy,
                Year = 2003,
                Rating = 9.1
            };

            // Add a movie to the index.
            SearchClient searchClient = indexClient.GetSearchClient(index.Name);
            searchClient.UploadDocuments(new[] { movie });
            #endregion Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_UploadDocument
        }
    }

    #region Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_Types
    public class Movie
    {
        [SimpleField(IsKey = true)]
        public string Id { get; set; }

        [SearchableField(IsSortable = true, AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
        public string Name { get; set; }

        [FieldBuilderIgnore]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MovieGenre Genre { get; set; }

        [SimpleField(IsFacetable = true, IsFilterable = true, IsSortable = true)]
        public int Year { get; set; }

        [SimpleField(IsFilterable = true, IsSortable = true)]
        public double Rating { get; set; }
    }

    public enum MovieGenre
    {
        Unknown,
        Action,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Romance,
        SciFi,
    }
    #endregion Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_Types
#pragma warning restore SA1649 // File name should match first type name
#pragma warning restore SA1402 // File may only contain a single type
}

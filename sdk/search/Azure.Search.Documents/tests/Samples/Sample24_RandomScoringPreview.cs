// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [RecordedTest]
        public async Task RandomScoringEndToEnd()
        {
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string indexName = PreviewName();

            #region Snippet:Azure_Search_Documents_Sample24_RandomScoring_Create
            SearchIndex index = new SearchIndex(indexName)
            {
                Fields =
                {
                    new SimpleField("id", SearchFieldDataType.String) { IsKey = true, IsFilterable = true },
                    new SearchableField("title"),
                    new SimpleField("rating", SearchFieldDataType.Int32) { IsFilterable = true }
                },
                ScoringProfiles =
                {
                    new ScoringProfile("randomUnseeded") { Functions = { new RandomScoringFunction() } },
                    new ScoringProfile("randomSeeded")
                    {
                        Functions = { new RandomScoringFunction { Parameters = new RandomScoringParameters("randomSeed") } }
                    }
                }
            };
            await indexClient.CreateIndexAsync(index);
            #endregion
            resources.TrackIndex(indexName);
            SearchIndex stored = await indexClient.GetIndexAsync(indexName);
            Assert.That(stored.ScoringProfiles.Single(profile => profile.Name == "randomSeeded").Functions.Single(),
                Is.TypeOf<RandomScoringFunction>());

            SearchClient searchClient = CreatePreviewSearchClient(resources, indexName);
            SearchDocument[] documents = Enumerable.Range(1, 20).Select(number => new SearchDocument
            {
                ["id"] = number.ToString(CultureInfo.InvariantCulture),
                ["title"] = "Hotel guest benefits",
                ["rating"] = (number - 1) % 5 + 1
            }).ToArray();
            await UploadPreviewDocumentsAsync(searchClient, documents);

            #region Snippet:Azure_Search_Documents_Sample24_RandomScoring_Query
            SearchOptions options = new SearchOptions
            {
                ScoringProfile = "randomSeeded",
                ScoringParameters = { "randomSeed-12345" },
                Select = { "id", "rating" },
                Size = 20,
                IncludeTotalCount = true
            };
            SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>("hotel", options);
            List<SearchResult<SearchDocument>> first = new List<SearchResult<SearchDocument>>();
            await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
            {
                first.Add(result);
                Console.WriteLine($"{result.Document["id"]}: {result.Score}");
            }
            // Reuse a seed to keep ordering stable while paging an unchanged result set.
            options.Size = 5;
            options.Skip = 5;
            SearchResults<SearchDocument> secondPage = await searchClient.SearchAsync<SearchDocument>("hotel", options);
            #endregion
            Assert.That(response.TotalCount, Is.EqualTo(20));
            Assert.That(first.Select(result => result.Document["id"]), Is.EquivalentTo(documents.Select(document => document["id"])));
            Assert.That(first.All(result => result.Score.HasValue && !double.IsNaN(result.Score.Value) &&
                !double.IsInfinity(result.Score.Value)), Is.True);
            List<SearchResult<SearchDocument>> page = await ReadPreviewResultsAsync(secondPage);
            Assert.That(page.Select(result => result.Document["id"]),
                Is.EqualTo(first.Skip(5).Take(5).Select(result => result.Document["id"])));

            options.Skip = 0;
            options.Size = 20;
            foreach (long seed in new[] { 12345L, 0L, -42L, long.MinValue, long.MaxValue })
            {
                options.ScoringParameters.Clear();
                options.ScoringParameters.Add("randomSeed-" + seed.ToString(CultureInfo.InvariantCulture));
                List<SearchResult<SearchDocument>> seeded = await ReadPreviewResultsAsync(
                    (await searchClient.SearchAsync<SearchDocument>("hotel", options)).Value);
                List<SearchResult<SearchDocument>> repeated = await ReadPreviewResultsAsync(
                    (await searchClient.SearchAsync<SearchDocument>("hotel", options)).Value);
                Assert.That(seeded.Select(result => (result.Document["id"], result.Score)),
                    Is.EqualTo(repeated.Select(result => (result.Document["id"], result.Score))));
                Assert.That(seeded.Count, Is.EqualTo(20));
            }
            options.ScoringParameters.Clear();
            options.ScoringParameters.Add("randomSeed-98765");
            List<SearchResult<SearchDocument>> rotated = await ReadPreviewResultsAsync(
                (await searchClient.SearchAsync<SearchDocument>("hotel", options)).Value);
            Assert.That(rotated.Select(result => result.Document["id"]),
                Is.Not.EqualTo(first.Select(result => result.Document["id"])));

            options.ScoringParameters.Clear();
            options.ScoringParameters.Add("randomSeed-12345");
            options.Filter = "rating ge 4";
            List<SearchResult<SearchDocument>> filtered = await ReadPreviewResultsAsync(
                (await searchClient.SearchAsync<SearchDocument>("hotel", options)).Value);
            Assert.That(filtered.Select(result => result.Document["id"]),
                Is.EqualTo(first.Where(result => Convert.ToInt32(result.Document["rating"], CultureInfo.InvariantCulture) >= 4)
                    .Select(result => result.Document["id"])));

            options.Filter = null;
            options.ScoringProfile = "randomUnseeded";
            options.ScoringParameters.Clear();
            List<SearchResult<SearchDocument>> unseeded = await ReadPreviewResultsAsync(
                (await searchClient.SearchAsync<SearchDocument>("hotel", options)).Value);
            Assert.That(unseeded.Select(result => result.Document["id"]),
                Is.EquivalentTo(documents.Select(document => document["id"])));
            options.ScoringProfile = "randomSeeded";
            RequestFailedException missingSeed = Assert.ThrowsAsync<RequestFailedException>(
                async () => await searchClient.SearchAsync<SearchDocument>("hotel", options));
            Assert.That(missingSeed.Status, Is.EqualTo(400));
        }

        #region Snippet:Azure_Search_Documents_Sample24_ReadResults
        private static async Task<List<SearchResult<SearchDocument>>> ReadPreviewResultsAsync(SearchResults<SearchDocument> response)
        {
            List<SearchResult<SearchDocument>> results = new List<SearchResult<SearchDocument>>();
            await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
            {
                results.Add(result);
            }
            return results;
        }
        #endregion
    }
}

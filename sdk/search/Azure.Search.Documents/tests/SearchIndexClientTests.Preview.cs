// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Preview-only index management tests. These tests only compile and run
    /// in preview builds (when the package version contains a pre-release suffix).
    ///
    /// GA Promotion Workflow:
    /// 1. Remove the #if AZURE_SEARCH_PREVIEW / #endif wrappers from this file
    /// 2. Move test methods to SearchIndexClientTests.cs (or keep here without #if — team choice)
    /// 3. Change [ServiceVersion(Min = CurrentPreviewVersion)] to the new GA version
    /// 4. Update CurrentGAVersion in SearchTestBase
    /// </summary>
    public partial class SearchIndexClientTests
    {
        // search-preview:2026-11-01-preview {
        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_11_01_Preview)]
        public async Task RandomScoringParametersRoundtrip()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            resources.IndexName = Recording.Random.GetName(8);
            SearchIndex index = SearchResources.GetHotelIndex(resources.IndexName);
            index.ScoringProfiles.Clear();
            index.ScoringProfiles.Add(new ScoringProfile("random-order")
            {
                Functions =
                {
                    new RandomScoringFunction
                    {
                        Parameters = new RandomScoringParameters("randomSeed")
                    }
                }
            });

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex created = await client.CreateIndexAsync(index);
            RandomScoringFunction createdFunction = created.ScoringProfiles.Single().Functions.Single() as RandomScoringFunction;
            Assert.IsNotNull(createdFunction);
            Assert.AreEqual("randomSeed", createdFunction.Parameters.SeedParameter);

            SearchIndex fetched = await client.GetIndexAsync(resources.IndexName);
            RandomScoringFunction fetchedFunction = fetched.ScoringProfiles.Single().Functions.Single() as RandomScoringFunction;
            Assert.IsNotNull(fetchedFunction);
            Assert.AreEqual("randomSeed", fetchedFunction.Parameters.SeedParameter);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_11_01_Preview)]
        public async Task KnowledgeSourceFacetFilterAutoConfigurationRoundtrip()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);
            string sourceName = Recording.Random.GetName(8);
            SearchIndexClient client = resources.GetIndexClient();
            var source = new SearchIndexKnowledgeSource(sourceName, new SearchIndexKnowledgeSourceParameters(resources.IndexName)
            {
                SemanticConfigurationName = "my-semantic-config",
                QueryHints = new SearchIndexKnowledgeSourceQueryHints
                {
                    Filters =
                    {
                        new SearchIndexKnowledgeSourceFilterHint("category")
                        {
                            AutoConfiguration = new SearchIndexKnowledgeSourceFilterHintAutoConfiguration
                            {
                                CacheTtl = 300,
                                MaxFacetValueCount = 32
                            }
                        }
                    }
                }
            });

            bool created = false;
            try
            {
                await client.CreateKnowledgeSourceAsync(source);
                created = true;
                SearchIndexKnowledgeSource fetched = (SearchIndexKnowledgeSource)(await client.GetKnowledgeSourceAsync(sourceName)).Value;
                SearchIndexKnowledgeSourceFilterHintAutoConfiguration configuration =
                    fetched.SearchIndexParameters.QueryHints.Filters.Single().AutoConfiguration;
                Assert.IsNotNull(configuration);
                Assert.AreEqual(300, configuration.CacheTtl);
                Assert.AreEqual(32, configuration.MaxFacetValueCount);
            }
            finally
            {
                if (created)
                {
                    await client.DeleteKnowledgeSourceAsync(sourceName, cancellationToken: CancellationToken.None);
                }
            }
        }
        // search-preview:2026-11-01-preview }
    }
}
#endif

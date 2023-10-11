// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.samples.VectorSearch
{
    public partial class VectorSearchUsingFieldBuilder : SearchTestBase
    {
        public VectorSearchUsingFieldBuilder(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, SearchClientOptions.ServiceVersion.V2023_10_01_Preview, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task CreateVectorIndexUsingFieldBuilder()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Index_UsingFieldBuilder
                string vectorSearchProfile = "my-vector-profile";
                string vectorSearchHnswConfig = "my-hsnw-vector-config";

                string indexName = "MyDocument";
#if !SNIPPET
                indexName = Recording.Random.GetName();
                resources.IndexName = indexName;
#endif
                // Create Index
                SearchIndex searchIndex = new SearchIndex(indexName)
                {
                    Fields = new FieldBuilder().Build(typeof(MyDocument)),
                    VectorSearch = new()
                    {
                        Profiles =
                    {
                        new VectorSearchProfile(vectorSearchProfile, vectorSearchHnswConfig)
                    },
                        Algorithms =
                    {
                        new HnswVectorSearchAlgorithmConfiguration(vectorSearchHnswConfig)
                    }
                    },
                };
                #endregion

                Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
                Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Create_Index_FieldBuilder
                Uri endpoint = new(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
                AzureKeyCredential credential = new(key);

                SearchIndexClient indexClient = new(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif
                await indexClient.CreateIndexAsync(searchIndex);
                #endregion

                SearchIndex createdIndex = await indexClient.GetIndexAsync(indexName);
                Assert.AreEqual(indexName, createdIndex.Name);
                Assert.AreEqual(searchIndex.Fields.Count, createdIndex.Fields.Count);
            }
            finally
            {
                await resources.GetIndexClient().DeleteIndexAsync(resources.IndexName);
            }
        }

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_FieldBuilder_Model
        public class MyDocument
        {
            [SimpleField(IsKey = true, IsFilterable = true, IsSortable = true)]
            public string Id { get; set; }

            [SearchableField(IsFilterable = true, IsSortable = true)]
            public string Name { get; set; }

            [SearchableField(AnalyzerName = "en.microsoft")]
            public string Description { get; set; }

            [SearchableField(VectorSearchDimensions = "1536", VectorSearchProfile = "my-vector-profile")]
            public IReadOnlyList<float> DescriptionVector { get; set; }
        }
        #endregion
    }
}

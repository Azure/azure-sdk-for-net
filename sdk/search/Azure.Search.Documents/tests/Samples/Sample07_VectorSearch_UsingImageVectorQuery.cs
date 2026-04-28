// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;
#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2026_04_01), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
    public partial class VectorSearchUsingImageVectorQuery : SearchTestBase
    {
        public VectorSearchUsingImageVectorQuery(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create Azure AI Vision resources.")]
        public async Task SingleVectorSearchUsingImageUrl()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Using_ImageUrl
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif
                SearchResults<ImageHotel> response = await searchClient.SearchAsync<ImageHotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries =
                            {
                                new VectorizableImageUrlQuery
                                {
                                    Url = new Uri("https://example.com/hotel-exterior.jpg"),
                                    KNearestNeighborsCount = 3,
                                    Fields = { "DescriptionImageVector" }
                                }
                            }
                        }
                    });

                int count = 0;
                Console.WriteLine("Image URL Vector Search Results:");
                await foreach (SearchResult<ImageHotel> result in response.GetResultsAsync())
                {
                    count++;
                    ImageHotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results: {count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName, cancellationToken: CancellationToken.None);
            }
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create Azure AI Vision resources.")]
        public async Task SingleVectorSearchUsingImageBinary()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Using_ImageBinary
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
                // A small placeholder base64-encoded image used only in non-snippet (test) context
                string base64Image = Convert.ToBase64String(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });
#else
                // Read image bytes and convert to base64
                byte[] imageBytes = System.IO.File.ReadAllBytes("path/to/your/image.jpg");
                string base64Image = Convert.ToBase64String(imageBytes);
#endif

                SearchResults<ImageHotel> response = await searchClient.SearchAsync<ImageHotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries =
                            {
                                new VectorizableImageBinaryQuery
                                {
                                    Base64Image = base64Image,
                                    KNearestNeighborsCount = 3,
                                    Fields = { "DescriptionImageVector" }
                                }
                            }
                        }
                    });

                int count = 0;
                Console.WriteLine("Image Binary Vector Search Results:");
                await foreach (SearchResult<ImageHotel> result in response.GetResultsAsync())
                {
                    count++;
                    ImageHotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results: {count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName, cancellationToken: CancellationToken.None);
            }
        }

        private async Task<SearchIndexClient> CreateIndex(SearchResources resources, string name)
        {
            string aiVisionEndpoint = Environment.GetEnvironmentVariable("AIVISION_ENDPOINT");
            string aiVisionKey = Environment.GetEnvironmentVariable("AIVISION_KEY");
            if (string.IsNullOrEmpty(aiVisionEndpoint) || string.IsNullOrEmpty(aiVisionKey))
            {
                Assert.Ignore("Azure AI Vision was not deployed");
            }

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Image_Vector_Search_Index
            string vectorSearchProfileName = "my-image-vector-profile";
            string vectorSearchHnswConfig = "my-hnsw-vector-config";
            string vectorizerName = "my-ai-vision-vectorizer";
            int modelDimensions = 1024;

            string indexName = "hotel";
#if !SNIPPET
            indexName = name;
#endif
            SearchIndex searchIndex = new(indexName)
            {
                Fields =
                {
                    new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
                    new SearchableField("Description") { IsFilterable = true },
                    new VectorSearchField("DescriptionImageVector", modelDimensions, vectorSearchProfileName),
                },
                VectorSearch = new()
                {
                    Profiles =
                    {
                        new VectorSearchProfile(vectorSearchProfileName, vectorSearchHnswConfig)
                        {
                            VectorizerName = vectorizerName
                        }
                    },
                    Algorithms =
                    {
                        new HnswAlgorithmConfiguration(vectorSearchHnswConfig)
                    },
                    Vectorizers =
                    {
                        new WebApiVectorizer(vectorizerName)
                        {
                            Parameters = new WebApiVectorizerParameters
                            {
                                Uri = new Uri(Environment.GetEnvironmentVariable("AIVISION_ENDPOINT")),
                                HttpHeaders =
                                {
                                    ["api-key"] = Environment.GetEnvironmentVariable("AIVISION_KEY")
                                }
                            }
                        }
                    }
                },
            };
            #endregion

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Image_Vector_Search_Create_Index
            Uri endpoint = new(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
            AzureKeyCredential credential = new(key);

            SearchIndexClient indexClient = new(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif
            await indexClient.CreateIndexAsync(searchIndex);
            #endregion

            return indexClient;
        }

        private async Task<SearchClient> UploadDocuments(SearchResources resources, string indexName)
        {
            Uri endpoint = resources.Endpoint;
            string key = resources.PrimaryApiKey;
            AzureKeyCredential credential = new AzureKeyCredential(key);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Image_Vector_Search_Upload_Documents
            SearchClient searchClient = new(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            ImageHotel[] hotelDocuments = GetHotelDocuments();
            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
            #endregion

            return searchClient;
        }

        public static ImageHotel[] GetHotelDocuments()
        {
            return new[]
            {
                new ImageHotel()
                {
                    HotelId = "1",
                    HotelName = "Fancy Stay",
                    Description = "Best hotel in town if you like luxury hotels.",
#if !SNIPPET
                    DescriptionImageVector = VectorSearchEmbeddings.Hotel1VectorizeDescription,
#else
                    // Populate DescriptionImageVector by calling your image vectorization service
                    // with an image that represents this hotel.
                    DescriptionImageVector = new ReadOnlyMemory<float>()
#endif
                },
                new ImageHotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
#if !SNIPPET
                    DescriptionImageVector = VectorSearchEmbeddings.Hotel2VectorizeDescription,
#else
                    DescriptionImageVector = new ReadOnlyMemory<float>()
#endif
                },
            };
        }
    }

    #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Image_Vector_Search_Hotel_Model
    public class ImageHotel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public ReadOnlyMemory<float> DescriptionImageVector { get; set; }
    }
    #endregion
}

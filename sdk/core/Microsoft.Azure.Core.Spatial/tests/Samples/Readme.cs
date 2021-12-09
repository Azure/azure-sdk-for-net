// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using Azure;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Microsoft.Azure.Core.Spatial.Tests.Samples
{
    public class Readme
    {
        [Test]
        public void SearchSample()
        {
            MockResponse response = new MockResponse(200);
            response.SetContent(@"{
                ""value"": [
                    {
                        ""@search.score"": 1.0,
                        ""id"": ""1"",
                        ""name"": ""Mount Rainier"",
                        ""summit"": {
                            ""type"": ""Point"",
                            ""coordinates"": [
                                -121.76044,
                                46.85287
                            ]
                        }
                    }
                ]
            }");

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", "https://sample.search.windows.net");
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", "sample");

            #region Snippet:Microsoft_Azure_Core_Spatial_Samples_Readme_SearchSample
            // Get the Azure Cognitive Search endpoint and read-only API key.
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create serializer options with our converter to deserialize geographic points.
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions
            {
                Converters =
                {
                    new MicrosoftSpatialGeoJsonConverter()
                },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            SearchClientOptions clientOptions = new SearchClientOptions
            {
#if !SNIPPET
                Transport = new MockTransport(response),
#endif
                Serializer = new JsonObjectSerializer(serializerOptions)
            };

            SearchClient client = new SearchClient(endpoint, "mountains", credential, clientOptions);
            Response<SearchResults<Mountain>> results = client.Search<Mountain>("Rainier");

            foreach (SearchResult<Mountain> result in results.Value.GetResults())
            {
                Mountain mountain = result.Document;
                Console.WriteLine("https://www.bing.com/maps?cp={0}~{1}&sp=point.{0}_{1}_{2}",
                    mountain.Summit.Latitude,
                    mountain.Summit.Longitude,
                    Uri.EscapeDataString(mountain.Name));
            }
            #endregion Snippet:Microsoft_Azure_Core_Spatial_Samples_Readme_SearchSample

            Mountain _mountain = results.Value.GetResults().Single().Document;
            Assert.AreEqual("Mount Rainier", _mountain.Name);
            Assert.AreEqual(-121.76044, _mountain.Summit.Longitude);
            Assert.AreEqual(46.85287, _mountain.Summit.Latitude);
        }

        #region Snippet:Microsoft_Azure_Core_Spatial_Samples_Readme_Model
        public class Mountain
        {
            [SimpleField(IsKey = true)]
            public string Id { get; set; }

            [SearchableField(IsSortable = true, AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
            public string Name { get; set; }

            [SimpleField(IsFacetable = true, IsFilterable = true)]
            public GeographyPoint Summit { get; set; }
        }
        #endregion Snippet:Microsoft_Azure_Core_Spatial_Samples_Readme_Model
    }
}

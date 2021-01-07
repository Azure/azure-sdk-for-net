// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Microsoft.Azure.Core.NewtonsoftJson.Tests.Samples
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
                        ""uuid"": ""efe8857f-1d74-41e2-9ff1-4943a9ad69d5"",
                        ""title"": ""The Lord of the Rings: The Return of the King"",
                        ""description"": ""Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring."",
                        ""rating"": 9.1
                    }
                ]
            }");

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", "https://sample.search.windows.net");
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", "sample");

            #region Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_SearchSample
            // Get the Azure Cognitive Search endpoint and read-only API key.
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create serializer options with default converters for Azure SDKs.
            JsonSerializerSettings serializerSettings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();

            // Serialize property names using camelCase by default.
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            SearchClientOptions clientOptions = new SearchClientOptions
            {
                /*@@*/ Transport = new MockTransport(response),
                Serializer = new NewtonsoftJsonObjectSerializer(serializerSettings)
            };

            SearchClient client = new SearchClient(endpoint, "movies", credential, clientOptions);
            Response<SearchResults<Movie>> results = client.Search<Movie>("Return of the King");

            foreach (SearchResult<Movie> result in results.Value.GetResults())
            {
                Movie movie = result.Document;

                Console.WriteLine(movie.Title);
                Console.WriteLine(movie.Description);
                Console.WriteLine($"Rating: {movie.Rating}\n");
            }
            #endregion Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_SearchSample

            Movie _movie = results.Value.GetResults().Single().Document;
            Assert.AreEqual("efe8857f-1d74-41e2-9ff1-4943a9ad69d5", _movie.Id);
            Assert.AreEqual("The Lord of the Rings: The Return of the King", _movie.Title);
            Assert.AreEqual("Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", _movie.Description);
            Assert.AreEqual(9.1, _movie.Rating, 0.01);
        }

        [Test]
        public void DefaultSerializerSettings()
        {
            #region Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_DefaultSerializerSettings
            JsonSerializerSettings serializerSettings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();

            // Serialize property names using camelCase by default.
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Add converters as needed, for example, to convert movie genres to an enum.
            serializerSettings.Converters.Add(new StringEnumConverter());

            SearchClientOptions clientOptions = new SearchClientOptions
            {
                Serializer = new NewtonsoftJsonObjectSerializer(serializerSettings)
            };
            #endregion Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_DefaultSerializerSettings

            Assert.AreEqual(2, serializerSettings.Converters.Count);
            Assert.That(serializerSettings.Converters, Has.Some.TypeOf(typeof(NewtonsoftJsonETagConverter)));
            Assert.That(serializerSettings.Converters, Has.Some.TypeOf(typeof(StringEnumConverter)));
        }

        #region Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_Model
        public class Movie
        {
            [JsonProperty("uuid")]
            public string Id { get; private set; } = Guid.NewGuid().ToString();

            public string Title { get; set; }

            public string Description { get; set; }

            public float Rating { get; set; }
        }
        #endregion Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_Model
    }
}

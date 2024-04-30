// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
    public static partial class VectorSearchCommons
    {
        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_GetEmbeddings
        public static ReadOnlyMemory<float> GetEmbeddings(string input)
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
            AzureKeyCredential credential = new AzureKeyCredential(key);

            OpenAIClient openAIClient = new OpenAIClient(endpoint, credential);
            EmbeddingsOptions embeddingsOptions = new("text-embedding-ada-002", new string[] { input });

            Embeddings embeddings = openAIClient.GetEmbeddings(embeddingsOptions);
            return embeddings.Data[0].Embedding;
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Hotel_Document
        public static Hotel[] GetHotelDocuments()
        {
            return new[]
            {
                new Hotel()
                {
                    HotelId = "1",
                    HotelName = "Fancy Stay",
                    Description =
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel.",
                    DescriptionVector = GetEmbeddings(
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel."),
                    Category = "Luxury",
                    CategoryVector = GetEmbeddings("Luxury")
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    DescriptionVector = GetEmbeddings("Cheapest hotel in town. Infact, a motel."),
                    Category = "Budget",
                    CategoryVector = GetEmbeddings("Budget")
                },
#if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    DescriptionVector = GetEmbeddings("Very popular hotel in town."),
                    Category = "Budget",
                    CategoryVector = GetEmbeddings("Budget")
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionVector = GetEmbeddings("Modern architecture, very polite staff and very clean. Also very affordable."),
                    Category = "Luxury",
                    CategoryVector = GetEmbeddings("Luxury")
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    DescriptionVector = GetEmbeddings("The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities."),
                    Category = "Boutique",
                    CategoryVector = GetEmbeddings("Boutique")
                }
#endif
                // Add more hotel documents here...
            };
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_GetEmbeddings_WithDimensions
        public static ReadOnlyMemory<float> GetEmbeddingsWithDimensions(string input)
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
            AzureKeyCredential credential = new AzureKeyCredential(key);

            OpenAIClient openAIClient = new OpenAIClient(endpoint, credential);
            EmbeddingsOptions embeddingsOptions = new("my-text-embedding-3-small", new string[] { input })
            {
                Dimensions = 256
            };

            Embeddings embeddings = openAIClient.GetEmbeddings(embeddingsOptions);
            return embeddings.Data[0].Embedding;
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Documents
        public static Hotel[] GetDocuments()
        {
            return new[]
            {
                new Hotel()
                {
                    HotelId = "1",
                    HotelName = "Fancy Stay",
                    Description =
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel.",
                    DescriptionVector = GetEmbeddingsWithDimensions(
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel."),
                    Category = "Luxury",
                    CategoryVector = GetEmbeddingsWithDimensions("Luxury")
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    DescriptionVector = GetEmbeddingsWithDimensions("Cheapest hotel in town. Infact, a motel."),
                    Category = "Budget",
                    CategoryVector = GetEmbeddingsWithDimensions("Budget")
                },
#if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    DescriptionVector = GetEmbeddingsWithDimensions("Very popular hotel in town."),
                    Category = "Budget",
                    CategoryVector = GetEmbeddingsWithDimensions("Budget")
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionVector = GetEmbeddingsWithDimensions("Modern architecture, very polite staff and very clean. Also very affordable."),
                    Category = "Luxury",
                    CategoryVector = GetEmbeddingsWithDimensions("Luxury")
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    DescriptionVector = GetEmbeddingsWithDimensions("The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities."),
                    Category = "Boutique",
                    CategoryVector = GetEmbeddingsWithDimensions("Boutique")
                }
#endif
                // Add more hotel documents here...
            };
        }
        #endregion
    }

    #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Model
    public class Hotel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string Description { get; set; }
        public ReadOnlyMemory<float> DescriptionVector { get; set; }
        public string Category { get; set; }
        public ReadOnlyMemory<float> CategoryVector { get; set; }
    }
    #endregion
}

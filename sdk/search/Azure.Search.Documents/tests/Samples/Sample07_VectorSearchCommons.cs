// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.OpenAI;
using OpenAI.Embeddings;
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

            AzureOpenAIClient openAIClient = new AzureOpenAIClient(endpoint, credential);
            EmbeddingClient embeddingClient = openAIClient.GetEmbeddingClient("text-embedding-ada-002");

            OpenAIEmbedding embedding = embeddingClient.GenerateEmbedding(input);
            return embedding.ToFloats();
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
#if !SNIPPET
                    DescriptionVector = VectorSearchEmbeddings.Hotel1VectorizeDescription,
#else
                    DescriptionVector = GetEmbeddings(
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel."),
#endif
                    Category = "Luxury",
#if !SNIPPET
                    CategoryVector = VectorSearchEmbeddings.LuxuryVectorizeCategory
#else
                    CategoryVector = GetEmbeddings("Luxury")
#endif
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
#if !SNIPPET
                    DescriptionVector = VectorSearchEmbeddings.Hotel2VectorizeDescription,
#else
                    DescriptionVector = GetEmbeddings("Cheapest hotel in town. Infact, a motel."),
#endif
                    Category = "Budget",
#if !SNIPPET
                    CategoryVector = VectorSearchEmbeddings.BudgetVectorizeCategory
#else
                    CategoryVector = GetEmbeddings("Budget")
#endif
                },
#if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel3VectorizeDescription,
                    Category = "Budget",
                    CategoryVector = VectorSearchEmbeddings.BudgetVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel7VectorizeDescription,
                    Category = "Luxury",
                    CategoryVector = VectorSearchEmbeddings.LuxuryVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel9VectorizeDescription,
                    Category = "Boutique",
                    CategoryVector = VectorSearchEmbeddings.BoutiqueVectorizeCategory
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

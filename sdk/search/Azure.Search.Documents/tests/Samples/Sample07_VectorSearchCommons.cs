﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
    public static partial class VectorSearchCommons
    {
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
                    DescriptionVector = VectorSearchEmbeddings.Hotel1VectorizeDescription,
                    Category = "Luxury",
                    CategoryVector = VectorSearchEmbeddings.LuxuryVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel2VectorizeDescription,
                    Category = "Budget",
                    CategoryVector = VectorSearchEmbeddings.BudgetVectorizeCategory
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

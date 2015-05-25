// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Linq;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class DocumentsFixture : IndexFixture
    {
        public readonly Hotel[] TestDocuments =
            new[]
            {
                new Hotel()
                {
                    HotelId = "1",
                    BaseRate = 199.0,
                    Description =
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel.",
                    DescriptionFr = 
                        "Meilleur hôtel en ville si vous aimez les hôtels de luxe. Ils ont une magnifique piscine " +
                        "à débordement, un spa et un concierge très utile. L'emplacement est parfait – en plein " +
                        "centre, à proximité de toutes les attractions touristiques. Nous recommandons fortement " +
                        "cet hôtel.",
                    HotelName = "Fancy Stay",
                    Category = "Luxury",
                    Tags = new[] { "pool", "view", "wifi", "concierge" },
                    ParkingIncluded = false,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(2010, 6, 27, 0, 0, 0, TimeSpan.Zero),
                    Rating = 5,
                    Location = GeographyPoint.Create(47.678581, -122.131577)
                },
                new Hotel()
                {
                    HotelId = "2",
                    BaseRate = 79.99,
                    Description = "Cheapest hotel in town",
                    DescriptionFr = "Hôtel le moins cher en ville",
                    HotelName = "Roach Motel",
                    Category = "Budget",
                    Tags = new[] { "motel", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = true,
                    LastRenovationDate = new DateTimeOffset(1982, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    Rating = 1,
                    Location = GeographyPoint.Create(49.678581, -122.131577)
                },
                new Hotel()
                {
                    HotelId = "3",
                    BaseRate = 129.99,
                    Description = "Most popular hotel in town",
                    DescriptionFr = "Hôtel le plus populaire en ville",
                    HotelName = "EconoStay",
                    Category = "Budget",
                    Tags = new[] { "wifi", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(1995, 7, 1, 0, 0, 0, TimeSpan.Zero),
                    Rating = 4,
                    Location = GeographyPoint.Create(46.678581, -122.131577)
                },
                new Hotel()
                {
                    HotelId = "4",
                    BaseRate = 129.99,
                    Description = "Pretty good hotel",
                    DescriptionFr = "Assez bon hôtel",
                    HotelName = "Express Rooms",
                    Category = "Budget",
                    Tags = new[] { "wifi", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(1995, 7, 1, 0, 0, 0, TimeSpan.Zero),
                    Rating = 4,
                    Location = GeographyPoint.Create(48.678581, -122.131577)
                },
                new Hotel()
                {
                    HotelId = "5",
                    BaseRate = 129.99,
                    Description = "Another good hotel",
                    DescriptionFr = "Un autre bon hôtel",
                    HotelName = "Comfy Place",
                    Category = "Budget",
                    Tags = new[] { "wifi", "budget" },
                    ParkingIncluded = true,
                    SmokingAllowed = false,
                    LastRenovationDate = new DateTimeOffset(2012, 8, 12, 0, 0, 0, TimeSpan.Zero),
                    Rating = 4,
                    Location = GeographyPoint.Create(48.678581, -122.131577)
                },
                new Hotel()
                {
                    HotelId = "6",
                    BaseRate = 279.99,
                    Description = "Surprisingly expensive",
                    LastRenovationDate = null
                }
            };

        public DocumentsFixture()
        {
            SearchIndexClient indexClient = this.GetSearchIndexClient();

            var batch = IndexBatch.Create(TestDocuments.Select(d => IndexAction.Create(d)));
            indexClient.Documents.Index(batch);

            SearchTestUtilities.WaitForIndexing();
        }
    }
}

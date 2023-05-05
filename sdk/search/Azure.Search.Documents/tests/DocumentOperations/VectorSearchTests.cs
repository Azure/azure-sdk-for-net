// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public partial class VectorSearch : SearchTestBase
    {
        public VectorSearch(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task SingleVectorSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            IList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription;
            Assert.NotNull(vectorizedResult);
            Assert.GreaterOrEqual(vectorizedResult.Count, 1);
            await Task.Delay(TimeSpan.FromSeconds(1));

            Vector vector = new Vector(){ K = 3, Fields = "DescriptionVector" };
            foreach (var v in vectorizedResult)
            {
                vector.Value.Add(v);
            }
            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                   null,
                   new SearchOptions
                   {
                       Vector = vector,
                       Select = { "HotelId", "HotelName" }
                   });

            int count = 0;
            await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
            {
                count++;
                Hotel doc = result.Document;
                Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
            }
            Assert.AreEqual(3, count); // HotelId - 3, 1, 5
        }
    }
}

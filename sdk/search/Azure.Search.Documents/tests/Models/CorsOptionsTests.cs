// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class CorsOptionsTests
    {
        [Test]
        public void MaxAgeInSecondsNull()
        {
            JsonDocument doc = JsonDocument.Parse(@"{
    ""allowedOrigins"": [
        ""*""
    ],
    ""maxAgeInSeconds"": null
}");

            CorsOptions sut = CorsOptions.DeserializeCorsOptions(doc.RootElement);

            CollectionAssert.AreEqual(sut.AllowedOrigins, new[] { "*" });
            Assert.IsNull(sut.MaxAgeInSeconds);
        }
    }
}

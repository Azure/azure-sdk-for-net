// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsErrorTests
    {
        // TODO: use async?

        //public TextAnalyticsErrorTests()
        //{
        //}

        //[Test]
        //public async Task ConvertTextAnalyticsErrorToException()
        //{
        //    using JsonDocument json = await JsonDocument.Parse();
        //    JsonElement root = json.RootElement;

        //    var mockResponse = new MockResponse(200);

        //    var mockResults = new List<RecognizeEntitiesResult>()
        //    {
        //        new RecognizeEntitiesResult("1", new TextDocumentStatistics(), new List<NamedEntity>()
        //        {
        //            new NamedEntity("EntityText0", "EntityType0", "EntitySubType0", 0, 1, 0.5),
        //            new NamedEntity("EntityText1", "EntityType1", "EntitySubType1", 0, 1, 0.5),
        //        }),
        //        new RecognizeEntitiesResult("2", new TextDocumentStatistics(), new List<NamedEntity>()
        //        {
        //            new NamedEntity("EntityText0", "EntityType0", "EntitySubType0", 0, 1, 0.5),
        //            new NamedEntity("EntityText1", "EntityType1", "EntitySubType1", 0, 1, 0.5),
        //        }),
        //    };
        //    var mockResultCollection = new RecognizeEntitiesResultCollection(mockResults,
        //        new TextDocumentBatchStatistics(2, 2, 0, 2),
        //        "modelVersion");

        //    var mockResponse = new MockResponse(200);
        //    mockResponse.SetContent(SerializationHelpers.Serialize(mockResultCollection, SerializeRecognizeEntitiesResultCollection));

        //    var mockTransport = new MockTransport(mockResponse);
        //    TextAnalyticsClient client = CreateTestClient(mockTransport);

        //    var inputs = new List<TextDocumentInput>()
        //    {
        //        new TextDocumentInput("1", "TextDocument1"),
        //        new TextDocumentInput("2", "TextDocument2"),
        //    };

        //    var response = await client.RecognizeEntitiesAsync(inputs, new TextAnalyticsRequestOptions());
        //    var resultCollection = response.Value;

        //    Assert.AreEqual("1", resultCollection[0].Id);
        //    Assert.AreEqual("2", resultCollection[1].Id);
        //}

        //[Test]
        //public async Task ConvertTextAnalyticsErrorToException_Inner()
        //{
        //}

        //[Test]
        //public async Task ConvertTextAnalyticsErrorToException_InnerAndDetails()
        //{
        //}


        //[Test]
        //public async Task ConvertTextAnalyticsErrorToException_TwoInners()
        //{
        //}
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests verifying that <see cref="DocumentChartFigure.Content"/> is deserialized whether the service
    /// returns the Chart.js config as a JSON object or as an escaped JSON string.
    /// </summary>
    [TestFixture]
    public class DocumentChartFigureContentTests
    {
        private static readonly ModelReaderWriterOptions s_jsonOptions = new("J");

        private const string ChartJs = @"{""type"":""bar"",""data"":{""labels"":[""Q1"",""Q2""],""datasets"":[{""data"":[120,180]}]}}";

        [Test]
        public void DocumentChartFigure_ObjectContent_DeserializesChartConfig()
        {
            var figure = DeserializeFromJson<DocumentChartFigure>(ChartFigureJson(ChartJs));

            AssertChartConfig(figure);
        }

        [Test]
        public void DocumentChartFigure_StringContent_DeserializesChartConfig()
        {
            // SERVICE-FIX: Service can return the Chart.js config as an escaped JSON string
            var figure = DeserializeFromJson<DocumentChartFigure>(ChartFigureJson(JsonSerializer.Serialize(ChartJs)));

            AssertChartConfig(figure);
        }

        [Test]
        public void AnalysisResult_StringChartContent_Deserializes()
        {
            string json = $@"{{
                ""analyzerId"": ""prebuilt-documentSearch"",
                ""apiVersion"": ""2025-11-01"",
                ""createdAt"": ""2026-11-07T08:55:49Z"",
                ""contents"": [{{
                    ""kind"": ""document"",
                    ""mimeType"": ""application/pdf"",
                    ""startPageNumber"": 1,
                    ""endPageNumber"": 1,
                    ""unit"": ""inch"",
                    ""figures"": [{ChartFigureJson(JsonSerializer.Serialize(ChartJs))}]
                }}]
            }}";

            var result = DeserializeFromJson<AnalysisResult>(json);

            var document = (DocumentContent)result.Contents.Single();
            AssertChartConfig((DocumentChartFigure)document.Figures.Single());
        }

        #region Helpers

        private static string ChartFigureJson(string content) => $@"{{
            ""kind"": ""chart"",
            ""id"": ""1.1"",
            ""source"": ""D(1,1.0474,2.451,5.6558,2.4468,5.6638,5.1986,1.0554,5.2043)"",
            ""span"": {{ ""offset"": 162, ""length"": 101 }},
            ""description"": ""Revenue by quarter"",
            ""content"": {content}
        }}";

        private static void AssertChartConfig(DocumentChartFigure figure)
        {
            Assert.AreEqual("1.1", figure.Id);
            Assert.AreEqual("Revenue by quarter", figure.Description);
            CollectionAssert.AreEquivalent(new[] { "type", "data" }, figure.Content.Keys);
            Assert.AreEqual("bar", figure.Content["type"].ToObjectFromJson<string>());
            using JsonDocument data = JsonDocument.Parse(figure.Content["data"]);
            Assert.AreEqual(2, data.RootElement.GetProperty("labels").GetArrayLength());
        }

        private static T DeserializeFromJson<T>(string json) where T : IJsonModel<T>
        {
            T prototype = (T)Activator.CreateInstance(typeof(T), nonPublic: true)!;
            return prototype.Create(BinaryData.FromString(json), s_jsonOptions)!;
        }

        #endregion
    }
}

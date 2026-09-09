// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    [TestFixture]
    public class AnalysisResultInfosTests
    {
        private const string LlmStatsMessage = "completion calls: 2; embedding calls: 1; avg completion latency: 5.75s; total completion latency: 11.50s; avg embedding latency: 0.94s; total embedding latency: 0.94s";

        [Test]
        public void DeserializeInfosFromPrebuiltInvoiceResponse()
        {
            string json = $$"""
                {
                  "analyzerId": "prebuilt-invoice",
                  "apiVersion": "2026-06-01-preview",
                  "infos": [
                    {
                      "code": "LLMStats",
                      "message": "{{LlmStatsMessage}}"
                    }
                  ],
                  "contents": [
                    {
                      "kind": "document",
                      "mimeType": "application/pdf",
                      "analyzerId": "prebuilt-invoice",
                      "markdown": "# CONTOSO INVOICE",
                      "startPageNumber": 1,
                      "endPageNumber": 1,
                      "unit": "inch"
                    }
                  ]
                }
                """;

            AnalysisResult result = ModelReaderWriter.Read<AnalysisResult>(BinaryData.FromString(json))!;

            Assert.AreEqual(1, result.Infos.Count);
            Assert.AreEqual("LLMStats", result.Infos[0].Code);
            Assert.AreEqual(LlmStatsMessage, result.Infos[0].Message);
            Assert.AreEqual(1, result.Contents.Count);
            Assert.IsInstanceOf<DocumentContent>(result.Contents[0]);
            Assert.AreEqual("prebuilt-invoice", result.Contents[0].AnalyzerId);
        }

        [Test]
        public void DeserializeMissingInfosAsEmptyCollection()
        {
            const string json = """
                {
                  "analyzerId": "prebuilt-invoice",
                  "apiVersion": "2026-06-01-preview",
                  "contents": []
                }
                """;

            AnalysisResult result = ModelReaderWriter.Read<AnalysisResult>(BinaryData.FromString(json))!;

            Assert.IsEmpty(result.Infos);
        }
    }
}

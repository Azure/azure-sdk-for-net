// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task ExtractPdfMetadataAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingExtractPdfMetadata
#if SNIPPET
            string filePath = "<path-to-pdf-with-embedded-metadata>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_metadata.pdf");
#endif
            BinaryData pdfData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

            Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-layout",
                pdfData);

            DocumentContent document = operation.Value.Contents
                .OfType<DocumentContent>()
                .First();

            foreach (var metadata in document.Metadata.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{metadata.Key}: {metadata.Value}");
            }

            if (!document.Metadata.ContainsKey("createdAt"))
            {
                Console.WriteLine("createdAt: (not returned)");
            }
            #endregion

            Assert.Multiple(() =>
            {
                Assert.That(document.Metadata["author"], Is.EqualTo("Contoso Metadata Team"));
                Assert.That(document.Metadata["contentType"], Is.EqualTo("application/pdf"));
                Assert.That(document.Metadata["language"], Is.EqualTo("en-US"));
                Assert.That(document.Metadata["pageCount"], Is.EqualTo("1"));
                Assert.That(document.Metadata["title"], Is.EqualTo("Contoso Metadata Extraction Sample"));
            });
        }

        [RecordedTest]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task ExtractDocxMetadataAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingExtractDocxMetadata
#if SNIPPET
            string filePath = "<path-to-docx-with-embedded-metadata>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_metadata.docx");
#endif
            BinaryData docxData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

            Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-layout",
                docxData);

            DocumentContent document = operation.Value.Contents
                .OfType<DocumentContent>()
                .First();

            foreach (var metadata in document.Metadata.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{metadata.Key}: {metadata.Value}");
            }
            #endregion

            Assert.Multiple(() =>
            {
                Assert.That(document.Metadata["author"], Is.EqualTo("Contoso Metadata Team"));
                Assert.That(document.Metadata["characterCount"], Is.EqualTo("207"));
                Assert.That(document.Metadata["contentType"], Is.EqualTo("application/vnd.openxmlformats-officedocument.wordprocessingml.document"));
                Assert.That(document.Metadata["createdAt"], Is.EqualTo("2026-07-16T19:00:00Z"));
                Assert.That(document.Metadata["lastModifiedAt"], Is.EqualTo("2026-07-16T20:30:00Z"));
                Assert.That(document.Metadata["lastModifiedBy"], Is.EqualTo(Mode == RecordedTestMode.Playback ? "Sanitized" : "Megan Bowen"));
                Assert.That(document.Metadata["pageCount"], Is.EqualTo("1"));
                Assert.That(document.Metadata["title"], Is.EqualTo("Contoso Metadata Extraction Sample"));
                Assert.That(document.Metadata["wordCount"], Is.EqualTo("29"));
            });
        }
    }
}

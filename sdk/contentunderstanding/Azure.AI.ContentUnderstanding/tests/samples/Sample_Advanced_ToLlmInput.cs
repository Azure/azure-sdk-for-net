// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
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
        public async Task ToLlmInputAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions(_serviceVersion));
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));
            var previewOptions = _serviceVersion == ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview
                ? InstrumentClientOptions(new ContentUnderstandingClientOptions(ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview))
                : null;
            var previewClient = previewOptions != null
                ? InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, previewOptions))
                : null;

            // ==============================================================
            // 1. OUTPUT OPTIONS — Fields-only, markdown-only, metadata
            // ==============================================================

            #region Snippet:ContentUnderstandingToLlmInput
            // Analyze an invoice to get a result we can demonstrate options with.
            Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");

            Operation<AnalysisResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalysisInput { Uri = invoiceUrl } });

            AnalysisResult result = operation.Value;

            // Convert to LLM-ready text (YAML front matter + markdown)
            string text = result.ToLlmInput();
            Console.WriteLine("Default output (fields + markdown):");
            Console.WriteLine(text);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInput
            Assert.IsNotNull(text, "LLM input text should not be null");
            Assert.That(text, Does.Contain("mimeType: application/pdf"));
            Assert.That(text, Does.Contain("fields:"));
            Assert.That(text, Does.Contain("VendorName:"));
            Assert.That(text, Does.Contain("<!-- InputPageNumber: 1 -->"));
            Console.WriteLine("Default output verified");
            #endregion

            #region Snippet:ContentUnderstandingToLlmInputOptions
            // Fields-only mode — smaller token footprint when you only need structured data.
            // Useful for agentic workflows where the LLM only needs extracted values.
            string fieldsOnly = result.ToLlmInput(options: new LlmInputOptions { IncludeMarkdown = false });
            Console.WriteLine("\n--- Fields only (includeMarkdown: false) ---");
            Console.WriteLine(fieldsOnly);

            // Markdown-only mode — when you only need the document text.
            // Useful for summarization or when fields are not relevant.
            string markdownOnly = result.ToLlmInput(options: new LlmInputOptions { IncludeFields = false });
            Console.WriteLine("\n--- Markdown only (includeFields: false) ---");
            Console.WriteLine(markdownOnly);

            // Custom metadata — nested under customMetadata: so it never collides with
            // helper-owned keys (mimeType, fields, metadata, …). Useful for RAG pipelines
            // to track document source, department, batch, etc.
            string withCustomMetadata = result.ToLlmInput(
                new Dictionary<string, object>
                {
                    ["source"] = "invoice.pdf",
                    ["department"] = "finance"
                });
            Console.WriteLine("\n--- With customMetadata ---");
            Console.WriteLine(withCustomMetadata);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputOptions
            // Fields-only: has fields, no markdown body
            Assert.That(fieldsOnly, Does.Contain("fields:"));
            Assert.That(fieldsOnly, Does.Not.Contain("<!-- InputPageNumber:"));
            Assert.That(fieldsOnly.TrimEnd(), Does.EndWith("---"));

            // Markdown-only: has markdown, no fields
            Assert.That(markdownOnly, Does.Not.Contain("fields:"));
            Assert.That(markdownOnly, Does.Contain("<!-- InputPageNumber: 1 -->"));

            // customMetadata appears between mimeType and fields
            Assert.That(withCustomMetadata, Does.Contain("customMetadata:"));
            Assert.That(withCustomMetadata, Does.Contain("source: invoice.pdf"));
            Assert.That(withCustomMetadata, Does.Contain("department: finance"));
            int mimeIdx = withCustomMetadata.IndexOf("mimeType:");
            int customIdx = withCustomMetadata.IndexOf("customMetadata:");
            int fieldsIdx = withCustomMetadata.IndexOf("fields:");
            Assert.That(customIdx, Is.GreaterThan(mimeIdx));
            Assert.That(fieldsIdx, Is.GreaterThan(customIdx));
            Console.WriteLine("Output options verified");
            #endregion

            // ==============================================================
            // 2. PREVIEW API VERSION: ANALYSIS METADATA IN FRONT MATTER
            // ==============================================================

            if (previewClient != null)
            {
                #region Snippet:ContentUnderstandingToLlmInputMetadataFromAnalysisResultPreview
                // This scenario requires preview API version 2026-06-01-preview.
#if SNIPPET
                string metadataPdfPath = "<path-to-pdf-with-embedded-metadata>";
#else
                string metadataPdfPath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_metadata.pdf");
#endif
                BinaryData metadataPdfData = BinaryData.FromBytes(File.ReadAllBytes(metadataPdfPath));

                Operation<AnalysisResult> metadataOperation = await previewClient.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    "prebuilt-layout",
                    metadataPdfData);

                // ToLlmInput includes AnalysisContent.Metadata under the "metadata" block.
                string metadataText = metadataOperation.Value.ToLlmInput();
                Console.WriteLine("\n--- Preview metadata from analysis result ---");
                Console.WriteLine(metadataText);
                #endregion

                #region Assertion:ContentUnderstandingToLlmInputMetadataFromAnalysisResultPreview
                Assert.That(metadataText, Does.Contain("mimeType: application/pdf"));
                Assert.That(metadataText, Does.Contain("metadata:"));
                Assert.That(metadataText, Does.Contain("author: Contoso Metadata Team"));
                Assert.That(metadataText, Does.Contain("contentType: application/pdf"));
                Assert.That(metadataText, Does.Contain("language: en-US"));
                Assert.That(metadataText, Does.Contain("pageCount: '1'"));
                Assert.That(metadataText, Does.Contain("title: Contoso Metadata Extraction Sample"));
                Console.WriteLine("Preview analysis metadata output verified");
                #endregion
            }

            // ==============================================================
            // 3. MULTI-PAGE PDF WITH CONTENT RANGE
            // ==============================================================

            #region Snippet:ContentUnderstandingToLlmInputContentRange
            Uri multiPageUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/mixed_financial_invoices.pdf");

            // Analyze specific pages using ContentRange.
            // Page markers in the output will use the original document page numbers,
            // so markers will say <!-- InputPageNumber: 2 -->, <!-- InputPageNumber: 3 -->,
            // <!-- InputPageNumber: 5 --> (not renumbered 1, 2, 3).
            Operation<AnalysisResult> multiPageOperation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[]
                {
                    new AnalysisInput
                    {
                        Uri = multiPageUrl,
                        ContentRange = ContentRange.Combine(ContentRange.Pages(2, 3), ContentRange.Page(5))
                    }
                });

            AnalysisResult multiPageResult = multiPageOperation.Value;
            string multiPageText = multiPageResult.ToLlmInput();
            Console.WriteLine("\n--- Multi-page PDF with content range ---");
            Console.WriteLine(multiPageText);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputContentRange
            Assert.That(multiPageText, Does.Contain("mimeType: application/pdf"));
            Assert.That(multiPageText, Does.Contain("pages:"));
            Assert.That(multiPageText, Does.Contain("2-3").Or.Contains("'2-3'"),
                "'pages' value should include '2-3' (original page numbers preserved)");
            Assert.That(multiPageText, Does.Contain("<!-- InputPageNumber:"));

            // Page markers in the markdown body should use the original page numbers
            // (<!-- InputPageNumber: 2 -->, <!-- InputPageNumber: 3 -->, <!-- InputPageNumber: 5 -->),
            // not renumbered (1, 2, 3).
            Assert.That(multiPageText, Does.Not.Contain("<!-- InputPageNumber: 1 -->"),
                "Page marker '<!-- InputPageNumber: 1 -->' should not appear — we only requested pages 2-3,5");
            Assert.That(multiPageText, Does.Contain("<!-- InputPageNumber: 2 -->"),
                "Page marker '<!-- InputPageNumber: 2 -->' should appear in the markdown body");
            Assert.That(multiPageText, Does.Contain("<!-- InputPageNumber: 3 -->"),
                "Page marker '<!-- InputPageNumber: 3 -->' should appear in the markdown body");
            Assert.That(multiPageText, Does.Contain("<!-- InputPageNumber: 5 -->"),
                "Page marker '<!-- InputPageNumber: 5 -->' should appear in the markdown body");

            Console.WriteLine("Multi-page content range output verified");
            #endregion

            // ==============================================================
            // 4. MULTI-SEGMENT VIDEO
            // ==============================================================

            #region Snippet:ContentUnderstandingToLlmInputVideo
            Uri videoUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/videos/sdk_samples/FlightSimulator.mp4");

            // Analyze a video — the result may contain multiple segments.
            // LlmInputHelper renders each segment with its time range in the front matter
            // (e.g., timeRange: 00:00 – 00:15) and separates segments with ***** dividers.
            Operation<AnalysisResult> videoOperation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-videoSearch",
                inputs: new[] { new AnalysisInput { Uri = videoUrl } });

            AnalysisResult videoResult = videoOperation.Value;
            string videoText = videoResult.ToLlmInput();
            Console.WriteLine($"\nVideo produced {videoResult.Contents!.Count} segment(s)");
            Console.WriteLine("\n--- Multi-segment video ---");
            Console.WriteLine(videoText);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputVideo
            Assert.That(videoText, Does.Contain("mimeType: video/mp4"));
            Assert.IsTrue(videoResult.Contents!.Count >= 1, "Video should produce 1 or more segments");
            if (videoResult.Contents!.Count > 1)
            {
                // 'timeRange:' front matter and '*****' dividers only appear when the
                // video is split into multiple segments.
                Assert.That(videoText, Does.Contain("timeRange:"));
                Assert.That(videoText, Does.Contain("*****"));
            }
            Console.WriteLine($"Video output verified ({videoResult.Contents!.Count} segment(s))");
            #endregion

            // ==============================================================
            // 5. AUDIO WITH CONTENT RANGE
            // ==============================================================

            #region Snippet:ContentUnderstandingToLlmInputAudio
            Uri audioUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/audio/callCenterRecording.mp3");

            // Analyze a specific time range of an audio file (first 10 seconds).
            // For audio, ContentRange uses milliseconds: "0-10000" means 0s to 10s.
            Operation<AnalysisResult> audioOperation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-audioSearch",
                inputs: new[]
                {
                    new AnalysisInput
                    {
                        Uri = audioUrl,
                        ContentRange = new ContentRange("0-10000")
                    }
                });

            AnalysisResult audioResult = audioOperation.Value;

            // Include customMetadata to track the source file in RAG pipelines
            string audioText = audioResult.ToLlmInput(
                new Dictionary<string, object> { ["source"] = "callCenterRecording.mp3" });
            Console.WriteLine("\n--- Audio with content range and customMetadata ---");
            Console.WriteLine(audioText);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputAudio
            Assert.That(audioText, Does.Contain("mimeType: audio/mpeg"));
            Assert.That(audioText, Does.Contain("customMetadata:"));
            Assert.That(audioText, Does.Contain("source: callCenterRecording.mp3"));
            Console.WriteLine("Audio with content range output verified");
            #endregion
        }
    }
}

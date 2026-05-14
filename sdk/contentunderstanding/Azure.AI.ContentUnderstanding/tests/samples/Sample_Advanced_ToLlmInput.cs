// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

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
            Assert.That(text, Does.Contain("contentType: document"));
            Assert.That(text, Does.Contain("fields:"));
            Assert.That(text, Does.Contain("VendorName:"));
            Assert.That(text, Does.Contain("<!-- page 1 -->"));
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

            // Custom metadata — add your own key-value pairs to the YAML front matter.
            // Useful for RAG pipelines to track document source, department, batch, etc.
            string withMetadata = result.ToLlmInput(
                new Dictionary<string, object>
                {
                    ["source"] = "invoice.pdf",
                    ["department"] = "finance"
                });
            Console.WriteLine("\n--- With metadata ---");
            Console.WriteLine(withMetadata);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputOptions
            // Fields-only: has fields, no markdown body
            Assert.That(fieldsOnly, Does.Contain("fields:"));
            Assert.That(fieldsOnly, Does.Not.Contain("<!-- page"));
            Assert.That(fieldsOnly.TrimEnd(), Does.EndWith("---"));

            // Markdown-only: has markdown, no fields
            Assert.That(markdownOnly, Does.Not.Contain("fields:"));
            Assert.That(markdownOnly, Does.Contain("<!-- page 1 -->"));

            // Metadata: metadata appears between contentType and fields
            Assert.That(withMetadata, Does.Contain("source: invoice.pdf"));
            Assert.That(withMetadata, Does.Contain("department: finance"));
            int ctIdx = withMetadata.IndexOf("contentType:");
            int srcIdx = withMetadata.IndexOf("source:");
            int fieldsIdx = withMetadata.IndexOf("fields:");
            Assert.That(srcIdx, Is.GreaterThan(ctIdx));
            Assert.That(fieldsIdx, Is.GreaterThan(srcIdx));
            Console.WriteLine("Output options verified");
            #endregion

            // ==============================================================
            // 2. MULTI-PAGE PDF WITH CONTENT RANGE
            // ==============================================================

            #region Snippet:ContentUnderstandingToLlmInputContentRange
            Uri multiPageUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/mixed_financial_invoices.pdf");

            // Analyze specific pages using ContentRange.
            // Page markers in the output will use the original document page numbers,
            // so even though we only requested pages 2-3 and 5, the markers will say
            // <!-- page 2 -->, <!-- page 3 -->, <!-- page 5 --> (not 1, 2, 3).
            Operation<AnalysisResult> multiPageOperation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[]
                {
                    new AnalysisInput
                    {
                        Uri = multiPageUrl,
                        ContentRange = new ContentRange("2-3,5")
                    }
                });

            AnalysisResult multiPageResult = multiPageOperation.Value;
            string multiPageText = multiPageResult.ToLlmInput();
            Console.WriteLine("\n--- Multi-page PDF with content range ---");
            Console.WriteLine(multiPageText);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputContentRange
            Assert.That(multiPageText, Does.Contain("contentType: document"));
            Assert.That(multiPageText, Does.Contain("pages:"));
            Assert.That(multiPageText, Does.Contain("2-3, 5").Or.Contains("'2-3, 5'"),
                "'pages' value should be '2-3, 5' (original page numbers preserved)");
            Assert.That(multiPageText, Does.Contain("<!-- page"));

            // Page markers in the markdown body should use the original page numbers
            // (<!-- page 2 -->, <!-- page 3 -->, <!-- page 5 -->), not renumbered (1, 2, 3).
            Assert.That(multiPageText, Does.Not.Contain("<!-- page 1 -->"),
                "Page marker '<!-- page 1 -->' should not appear — we only requested pages 2-3, 5");
            Assert.That(multiPageText, Does.Contain("<!-- page 2 -->"),
                "Page marker '<!-- page 2 -->' should appear in the markdown body");
            Assert.That(multiPageText, Does.Contain("<!-- page 3 -->"),
                "Page marker '<!-- page 3 -->' should appear in the markdown body");
            Assert.That(multiPageText, Does.Contain("<!-- page 5 -->"),
                "Page marker '<!-- page 5 -->' should appear in the markdown body");

            Console.WriteLine("Multi-page content range output verified");
            #endregion

            // ==============================================================
            // 3. MULTI-SEGMENT VIDEO
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
            Assert.That(videoText, Does.Contain("contentType: audioVisual"));
            Assert.IsTrue(videoResult.Contents!.Count > 1, "Video should produce multiple segments");
            Assert.That(videoText, Does.Contain("timeRange:"));
            Assert.That(videoText, Does.Contain("*****"));
            Console.WriteLine("Multi-segment video output verified");
            #endregion

            // ==============================================================
            // 4. AUDIO WITH CONTENT RANGE
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

            // Include metadata to track the source file in RAG pipelines
            string audioText = audioResult.ToLlmInput(
                new Dictionary<string, object> { ["source"] = "callCenterRecording.mp3" });
            Console.WriteLine("\n--- Audio with content range and metadata ---");
            Console.WriteLine(audioText);
            #endregion

            #region Assertion:ContentUnderstandingToLlmInputAudio
            Assert.That(audioText, Does.Contain("contentType: audioVisual"));
            Assert.That(audioText, Does.Contain("source: callCenterRecording.mp3"));
            Console.WriteLine("Audio with content range output verified");
            #endregion
        }
    }
}

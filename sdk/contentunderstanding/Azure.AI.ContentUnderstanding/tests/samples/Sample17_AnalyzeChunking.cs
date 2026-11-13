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
        public async Task AnalyzeChunkingAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            string analyzerId = Recording.GetVariable(
                "chunkingAnalyzerId",
                $"test_chunking_{Recording.Random.NewGuid():N}")!;

            try
            {
                #region Snippet:ContentUnderstandingCreateAnalyzerWithSemanticChunking
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Analyzer with semantic chunking",
                    Config = new ContentAnalyzerConfig
                    {
                        ShouldReturnDetails = true,
                        EnableLayout = true,
                        ChunkingStrategy = new SemanticChunkingStrategy
                        {
                            MaxTokens = 300
                        }
                    }
                };
#if SNIPPET
                string completionModel = "<completion-model-name>";
#else
                string completionModel = ModelProfile.CompletionModel;
#endif
                analyzer.Models["completion"] = completionModel;

                await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);
                #endregion

                #region Snippet:ContentUnderstandingAnalyzeWithSemanticChunking
#if SNIPPET
                // Use the SDK sample invoice shipped under tests/samples/SampleFiles/
                string filePath = "sample_invoice.pdf";
#else
                string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
#endif
                BinaryData binaryData = BinaryData.FromBytes(File.ReadAllBytes(filePath));
                Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    binaryData);

                AnalysisResult result = operation.Value;
                DocumentContent documentContent = (DocumentContent)result.Contents!.First();
                #endregion

                #region Snippet:ContentUnderstandingReadSemanticChunks
                string[] chunkMarkdowns = (documentContent.Chunks ?? Enumerable.Empty<DocumentChunk>())
                    .Select(chunk => string.Join(
                        Environment.NewLine,
                        chunk.Spans.Select(span => documentContent.Markdown.Substring(span.Offset, span.Length))))
                    .ToArray();

                Console.WriteLine($"Chunk count: {chunkMarkdowns.Length}");
                for (int index = 0; index < chunkMarkdowns.Length; index++)
                {
                    Console.WriteLine($"--- Chunk {index + 1} ---");
                    Console.WriteLine(chunkMarkdowns[index]);
                }
                #endregion

                #region Assertion:ContentUnderstandingAnalyzeChunking
                Assert.IsNotNull(operation, "Analyze operation should not be null");
                Assert.IsTrue(operation.HasCompleted, "Analyze operation should complete");
                Assert.IsTrue(operation.HasValue, "Analyze operation should have a value");

                Assert.IsNotNull(result, "Analysis result should not be null");
                Assert.IsNotNull(result.Contents, "Analysis contents should not be null");
                Assert.IsTrue(result.Contents!.Count > 0, "Analysis should return at least one content item");
                Assert.IsInstanceOf<DocumentContent>(result.Contents.First(), "First content should be a document");

                var createdAnalyzer = await client.GetAnalyzerAsync(analyzerId);
                Assert.IsNotNull(createdAnalyzer.Value.Config, "Analyzer config should not be null");
                Assert.IsNotNull(createdAnalyzer.Value.Config!.ChunkingStrategy, "Chunking strategy should be set");
                Assert.IsInstanceOf<SemanticChunkingStrategy>(
                    createdAnalyzer.Value.Config.ChunkingStrategy,
                    "Chunking strategy should be semantic");

                var semanticChunking = (SemanticChunkingStrategy)createdAnalyzer.Value.Config.ChunkingStrategy;
                Assert.AreEqual(300, semanticChunking.MaxTokens, "Semantic chunk max token size should match");

                Assert.IsNotNull(documentContent.Chunks, "Chunks should not be null when chunking is enabled");
                Assert.That(documentContent.Chunks!.Count, Is.GreaterThanOrEqualTo(2), "Invoice should produce multiple semantic chunks");
                Assert.AreEqual(documentContent.Chunks.Count, chunkMarkdowns.Length, "Rendered chunk count should match Chunks");

                // sample_invoice.pdf typically splits header/party info, line items, and totals into separate chunks.
                Assert.That(chunkMarkdowns[0], Does.Contain("INVOICE"));
                Assert.That(chunkMarkdowns[0], Does.Contain("CONTOSO"));
                Assert.That(string.Join("\n", chunkMarkdowns), Does.Contain("Consulting Services"));
                Assert.That(chunkMarkdowns[chunkMarkdowns.Length - 1], Does.Contain("AMOUNT DUE").Or.Contain("THANK YOU"));

                foreach (DocumentChunk chunk in documentContent.Chunks)
                {
                    Assert.IsNotNull(chunk.Spans, "Chunk spans should not be null");
                    Assert.IsTrue(chunk.Spans.Count > 0, "Chunk should contain at least one span");
                    foreach (ContentSpan span in chunk.Spans)
                    {
                        Assert.IsTrue(span.Length > 0, "Chunk span length should be positive");
                    }
                }
                #endregion
            }
            finally
            {
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                }
                catch
                {
                    // Ignore cleanup errors in tests.
                }
            }
        }
    }
}

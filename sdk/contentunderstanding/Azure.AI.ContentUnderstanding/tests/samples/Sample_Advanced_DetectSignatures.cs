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
        public async Task DetectSignaturesAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingDetectSignatures
#if SNIPPET
            string filePath = "<path-to-image-that-contains-signatures>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_signature.png");
#endif
            BinaryData imageData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

            Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-layout",
                imageData);

            DocumentContent document = operation.Value.Contents
                .OfType<DocumentContent>()
                .First();

            Console.WriteLine($"Found {document.Signatures.Count} signature(s).");
            foreach (DocumentSignature signature in document.Signatures)
            {
                Console.WriteLine($"Signature ID: {signature.Id}");
                Console.WriteLine($"  Role: {signature.Role?.ToString() ?? "(not available)"}");
                Console.WriteLine($"  Source: {signature.Source}");

                if (signature.Span is not null)
                {
                    Console.WriteLine($"  Span: offset={signature.Span.Offset}, length={signature.Span.Length}");
                    string markdownFragment = document.Markdown.Substring(
                        signature.Span.Offset,
                        signature.Span.Length);
                    Console.WriteLine($"  Markdown: {markdownFragment}");
                }
            }
            #endregion

            Assert.IsTrue(operation.HasCompleted);
            Assert.That(document.Signatures, Has.Count.GreaterThanOrEqualTo(2));
            Assert.That(document.Signatures.All(signature => !string.IsNullOrWhiteSpace(signature.Id)), Is.True);
            Assert.That(document.Signatures.All(signature => !string.IsNullOrWhiteSpace(signature.Source)), Is.True);
        }
    }
}

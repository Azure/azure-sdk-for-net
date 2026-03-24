// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Drawing;
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
        /// <summary>
        /// Demonstrates how to access and use <see cref="ContentSource"/> grounding references
        /// from analysis results. Content sources identify the exact location in the original
        /// content where a field value was extracted from.
        ///
        /// For document/image content, sources are <see cref="DocumentSource"/> instances
        /// with page number, polygon coordinates, and a computed bounding box.
        /// </summary>
        [RecordedTest]
        public async Task ContentSourceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingContentSourceFromAnalysis
            // Analyze an invoice to get fields with grounding sources.
            Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");
            Operation<AnalysisResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalysisInput { Uri = invoiceUrl } });

            AnalysisResult result = operation.Value;
            DocumentContent documentContent = (DocumentContent)result.Contents!.First();

            // Iterate over all fields and access their grounding sources.
            foreach (var kvp in documentContent.Fields)
            {
                string fieldName = kvp.Key;
                ContentField field = kvp.Value;

                Console.WriteLine($"Field: {fieldName} = {field.Value}");

                // Sources identify where the field value appears in the original content.
                // For documents, each source is a DocumentSource with page number and polygon.
                if (field.Sources != null)
                {
                    foreach (ContentSource source in field.Sources)
                    {
                        if (source is DocumentSource docSource)
                        {
                            Console.WriteLine($"  Source: page {docSource.PageNumber}");

                            // Polygon: the precise region (rotated quadrilateral) around the text.
                            if (docSource.Polygon != null)
                            {
                                string coords = string.Join(", ", docSource.Polygon.Select(p => $"({p.X:F4},{p.Y:F4})"));
                                Console.WriteLine($"  Polygon: [{coords}]");
                            }

                            // BoundingBox: axis-aligned rectangle computed from the polygon —
                            // convenient for drawing highlight overlays.
                            if (docSource.BoundingBox.HasValue)
                            {
                                RectangleF bbox = docSource.BoundingBox.Value;
                                Console.WriteLine($"  BoundingBox: x={bbox.X:F4}, y={bbox.Y:F4}, w={bbox.Width:F4}, h={bbox.Height:F4}");
                            }
                        }
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingContentSourceFromAnalysis
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents!.Count > 0);
            Assert.IsInstanceOf<DocumentContent>(result.Contents.First());

            // Verify at least one field has grounding sources
            bool hasDocumentSource = false;
            foreach (var kvp in documentContent.Fields)
            {
                if (kvp.Value.Sources != null)
                {
                    foreach (var source in kvp.Value.Sources)
                    {
                        Assert.IsInstanceOf<DocumentSource>(source, $"Sources for document fields should be DocumentSource, got {source.GetType().Name}");
                        var ds = (DocumentSource)source;
                        Assert.IsTrue(ds.PageNumber >= 1, $"PageNumber should be >= 1, got {ds.PageNumber}");
                        Assert.IsNotNull(ds.Polygon, "Polygon should not be null for document sources with coordinates");
                        Assert.IsTrue(ds.Polygon!.Count >= 3, $"Polygon should have at least 3 points, got {ds.Polygon.Count}");
                        Assert.IsTrue(ds.BoundingBox.HasValue, "BoundingBox should be computed from polygon");
                        Assert.IsTrue(ds.BoundingBox!.Value.Width > 0, "BoundingBox width should be > 0");
                        Assert.IsTrue(ds.BoundingBox!.Value.Height > 0, "BoundingBox height should be > 0");
                        hasDocumentSource = true;
                    }
                }
            }
            Assert.IsTrue(hasDocumentSource, "At least one field should have DocumentSource grounding");
            #endregion

            #region Snippet:ContentUnderstandingContentSourceParse
            // Get the grounding source from a real analysis result and round-trip it.
            // Find a field that has grounding sources.
            ContentField fieldWithSource = documentContent.Fields.Values
                .First(f => f.Sources != null);

            // Convert the parsed sources back to their wire-format string using ToRawString().
            string sourceString = fieldWithSource.Sources!.ToRawString();
            Console.WriteLine($"Source wire format: {sourceString}");

            // Parse the wire-format string back into typed ContentSource instances.
            ContentSource[] roundTripped = ContentSource.Parse(sourceString);
            DocumentSource roundTrippedDoc = (DocumentSource)roundTripped[0];
            Console.WriteLine($"Round-tripped: page {roundTrippedDoc.PageNumber}, polygon points: {roundTrippedDoc.Polygon?.Count ?? 0}");
            Console.WriteLine($"  BoundingBox: {roundTrippedDoc.BoundingBox}");

            // Find a field with multiple source segments (e.g., multi-line addresses).
            ContentField multiSourceField = documentContent.Fields.Values
                .First(f => f.Sources != null && f.Sources.Length > 1);
            string multiSourceString = multiSourceField.Sources!.ToRawString();
            Console.WriteLine($"Multi-segment wire format: {multiSourceString}");

            ContentSource[] multiParsed = ContentSource.Parse(multiSourceString);
            Console.WriteLine($"Multi-segment: {multiParsed.Length} sources on pages {string.Join(", ", multiParsed.OfType<DocumentSource>().Select(s => s.PageNumber))}");

            // ContentSource.Parse() also handles page-only format (no polygon coordinates).
            // Construct a page-only source string from a real field's page number.
            int realPageNumber = ((DocumentSource)fieldWithSource.Sources![0]).PageNumber;
            ContentSource[] pageOnlySources = ContentSource.Parse($"D({realPageNumber})");
            DocumentSource pageOnly = (DocumentSource)pageOnlySources[0];
            Console.WriteLine($"Page-only source: page {pageOnly.PageNumber}, polygon: {(pageOnly.Polygon != null ? "yes" : "none")}");
            #endregion

            #region Assertion:ContentUnderstandingContentSourceParse
            // Verify round-trip: sources → ToRawString → Parse → same data
            Assert.IsTrue(roundTripped.Length >= 1);
            Assert.IsInstanceOf<DocumentSource>(roundTripped[0]);
            Assert.AreEqual(((DocumentSource)fieldWithSource.Sources![0]).PageNumber, roundTrippedDoc.PageNumber);
            Assert.IsNotNull(roundTrippedDoc.Polygon);
            Assert.IsTrue(roundTrippedDoc.BoundingBox.HasValue);

            // Verify multi-segment round-trip
            Assert.IsTrue(multiParsed.Length > 1, $"Expected multiple segments, got {multiParsed.Length}");
            Assert.AreEqual(multiSourceField.Sources!.Length, multiParsed.Length);

            // Verify page-only document source
            Assert.AreEqual(1, pageOnlySources.Length);
            Assert.AreEqual(realPageNumber, pageOnly.PageNumber);
            Assert.IsNull(pageOnly.Polygon, "Page-only source should have null polygon");
            Assert.IsNull(pageOnly.BoundingBox, "Page-only source should have null BoundingBox");
            #endregion
        }
    }
}

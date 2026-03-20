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
        /// Two source types are supported:
        /// <list type="bullet">
        /// <item><see cref="DocumentSource"/> — page + polygon coordinates for documents/images</item>
        /// <item><see cref="AudioVisualSource"/> — timestamp + optional bounding box for audio/video</item>
        /// </list>
        /// </summary>
        [RecordedTest]
        public async Task ContentSourceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingContentSourceFromAnalysis
            // Analyze an invoice to get fields with grounding sources.
            Uri invoiceUrl = new Uri("https://github.com/Azure-Samples/azure-ai-content-understanding-assets/blob/main/document/invoice.pdf");
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
            // ContentSource.Parse() can parse raw source strings into typed instances.
            // The raw format uses prefixes: D(...) for documents, AV(...) for audio/video.

            // Parse a single document source: page 1 with a 4-point polygon
            ContentSource[] docSources = ContentSource.Parse("D(1,0.5712,0.3381,0.7276,0.3381,0.7276,0.3534,0.5712,0.3534)");
            DocumentSource doc = (DocumentSource)docSources[0];
            Console.WriteLine($"Parsed document source: page {doc.PageNumber}, {doc.Polygon!.Count} polygon points");
            Console.WriteLine($"  BoundingBox: {doc.BoundingBox}");

            // Parse a page-only document source (no coordinates)
            ContentSource[] pageOnlySources = ContentSource.Parse("D(3)");
            DocumentSource pageOnly = (DocumentSource)pageOnlySources[0];
            Console.WriteLine($"Page-only source: page {pageOnly.PageNumber}, polygon: {(pageOnly.Polygon != null ? "yes" : "none")}");

            // Parse an audio/visual source: timestamp at 5000 ms (no bounding box)
            ContentSource[] avSources = ContentSource.Parse("AV(5000)");
            AudioVisualSource av = (AudioVisualSource)avSources[0];
            Console.WriteLine($"Audio/visual source: time {av.Time.TotalMilliseconds} ms, bbox: {(av.BoundingBox.HasValue ? "yes" : "none")}");

            // Parse an audio/visual source with bounding box: 5000 ms at (100,200) size 50x60
            ContentSource[] avWithBbox = ContentSource.Parse("AV(5000,100,200,50,60)");
            AudioVisualSource avBbox = (AudioVisualSource)avWithBbox[0];
            Console.WriteLine($"AV with bbox: time {avBbox.Time.TotalMilliseconds} ms, bbox: {avBbox.BoundingBox}");

            // Parse multiple segments separated by semicolons
            ContentSource[] multiSources = ContentSource.Parse("D(1,0.1,0.2,0.3,0.2,0.3,0.4,0.1,0.4);D(2,0.5,0.6,0.7,0.6,0.7,0.8,0.5,0.8)");
            Console.WriteLine($"Multi-segment: {multiSources.Length} sources across pages {((DocumentSource)multiSources[0]).PageNumber} and {((DocumentSource)multiSources[1]).PageNumber}");

            // Reconstruct the wire format from parsed sources
            string wireFormat = multiSources.ToRawString();
            Console.WriteLine($"Reconstructed wire format: {wireFormat}");
            #endregion

            #region Assertion:ContentUnderstandingContentSourceParse
            // Verify single document source parsing
            Assert.AreEqual(1, docSources.Length);
            Assert.IsInstanceOf<DocumentSource>(docSources[0]);
            Assert.AreEqual(1, doc.PageNumber);
            Assert.AreEqual(4, doc.Polygon!.Count);
            Assert.IsTrue(doc.BoundingBox.HasValue);

            // Verify page-only document source
            Assert.AreEqual(1, pageOnlySources.Length);
            Assert.AreEqual(3, pageOnly.PageNumber);
            Assert.IsNull(pageOnly.Polygon, "Page-only source should have null polygon");
            Assert.IsNull(pageOnly.BoundingBox, "Page-only source should have null BoundingBox");

            // Verify audio/visual source without bounding box
            Assert.AreEqual(1, avSources.Length);
            Assert.IsInstanceOf<AudioVisualSource>(avSources[0]);
            Assert.AreEqual(TimeSpan.FromMilliseconds(5000), av.Time);
            Assert.IsFalse(av.BoundingBox.HasValue, "Audio-only AV source should have no BoundingBox");

            // Verify audio/visual source with bounding box
            Assert.AreEqual(1, avWithBbox.Length);
            Assert.AreEqual(TimeSpan.FromMilliseconds(5000), avBbox.Time);
            Assert.IsTrue(avBbox.BoundingBox.HasValue);
            Assert.AreEqual(new Rectangle(100, 200, 50, 60), avBbox.BoundingBox!.Value);

            // Verify multi-segment parsing
            Assert.AreEqual(2, multiSources.Length);
            Assert.AreEqual(1, ((DocumentSource)multiSources[0]).PageNumber);
            Assert.AreEqual(2, ((DocumentSource)multiSources[1]).PageNumber);

            // Verify round-trip: parse → ToRawString → parse again
            ContentSource[] reparsed = ContentSource.Parse(wireFormat);
            Assert.AreEqual(multiSources.Length, reparsed.Length);
            Assert.AreEqual(((DocumentSource)multiSources[0]).PageNumber, ((DocumentSource)reparsed[0]).PageNumber);
            Assert.AreEqual(((DocumentSource)multiSources[1]).PageNumber, ((DocumentSource)reparsed[1]).PageNumber);
            #endregion
        }
    }
}

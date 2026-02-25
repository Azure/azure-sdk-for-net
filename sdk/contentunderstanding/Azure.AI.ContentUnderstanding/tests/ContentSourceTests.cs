// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Drawing;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContentSource"/>, <see cref="DocumentSource"/>,
    /// <see cref="AudioVisualSource"/>, and the <see cref="ContentField.Sources"/> property.
    /// </summary>
    [TestFixture]
    public class ContentSourceTests
    {
        #region DocumentSource Parsing

        [Test]
        public void DocumentSource_Parse_SingleSegment_ExtractsPageAndPolygon()
        {
            var sources = DocumentSource.Parse("D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");

            Assert.AreEqual(1, sources.Length);
            var source = sources[0];
            Assert.AreEqual(1, source.PageNumber);
            Assert.IsNotNull(source.Polygon);
            Assert.AreEqual(4, source.Polygon!.Count);
            AssertPointApproximate(new PointF(0.5712f, 1.4062f), source.Polygon[0]);
            AssertPointApproximate(new PointF(2.1087f, 1.4088f), source.Polygon[1]);
            AssertPointApproximate(new PointF(2.1084f, 1.5762f), source.Polygon[2]);
            AssertPointApproximate(new PointF(0.5709f, 1.5736f), source.Polygon[3]);
        }

        [Test]
        public void DocumentSource_Parse_PageNumber_IsExtractedCorrectly()
        {
            var sources = DocumentSource.Parse("D(3,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)");
            Assert.AreEqual(3, sources[0].PageNumber);
        }

        [Test]
        public void DocumentSource_Parse_RawValue_PreservesOriginalString()
        {
            string raw = "D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)";
            var sources = DocumentSource.Parse(raw);
            Assert.AreEqual(raw, sources[0].RawValue);
            Assert.AreEqual(raw, sources[0].ToString());
        }

        [Test]
        public void DocumentSource_Parse_MultiRegion_ReturnsMultipleSources()
        {
            string input = "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(1,2.0,2.0,3.0,2.0,3.0,3.0,2.0,3.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)";
            var sources = DocumentSource.Parse(input);

            Assert.AreEqual(3, sources.Length);
            Assert.AreEqual(1, sources[0].PageNumber);
            Assert.AreEqual(1, sources[1].PageNumber);
            Assert.AreEqual(2, sources[2].PageNumber);
        }

        [Test]
        public void DocumentSource_Parse_WrongPrefix_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => DocumentSource.Parse("AV(5000)"));
        }

        [Test]
        public void DocumentSource_Parse_MalformedInput_ThrowsFormatException()
        {
            // 3 params: page + 1 coordinate pair (too few — need at least 3 pairs)
            Assert.Throws<FormatException>(() => DocumentSource.Parse("D(1,2,3)"));
        }

        [Test]
        public void DocumentSource_Parse_Null_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => DocumentSource.Parse(null!));
        }

        [Test]
        public void DocumentSource_Parse_Empty_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => DocumentSource.Parse(""));
        }

        [Test]
        public void DocumentSource_Parse_BoundingBox_ComputedFromPolygon()
        {
            var sources = DocumentSource.Parse("D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");
            var source = sources[0];

            Assert.IsNotNull(source.BoundingBox);
            var bbox = source.BoundingBox!.Value;
            // Min X = 0.5709, Min Y = 1.4062, Max X = 2.1087, Max Y = 1.5762
            Assert.AreEqual(0.5709f, bbox.X, 0.0001f);
            Assert.AreEqual(1.4062f, bbox.Y, 0.0001f);
            Assert.AreEqual(2.1087f - 0.5709f, bbox.Width, 0.001f);
            Assert.AreEqual(1.5762f - 1.4062f, bbox.Height, 0.001f);
        }

        [Test]
        public void DocumentSource_Parse_InvalidPageNumber_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => DocumentSource.Parse("D(0,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)"));
        }

        [Test]
        public void DocumentSource_Parse_PageOnly_HasNullPolygonAndBoundingBox()
        {
            var sources = DocumentSource.Parse("D(1)");
            var source = sources[0];

            Assert.AreEqual(1, source.PageNumber);
            Assert.IsNull(source.Polygon);
            Assert.IsNull(source.BoundingBox);
        }

        [Test]
        public void DocumentSource_Parse_TrianglePolygon_Accepts3Points()
        {
            var sources = DocumentSource.Parse("D(1,0.0,0.0,1.0,0.0,0.5,1.0)");
            var source = sources[0];

            Assert.AreEqual(1, source.PageNumber);
            Assert.IsNotNull(source.Polygon);
            Assert.AreEqual(3, source.Polygon!.Count);
            AssertPointApproximate(new PointF(0.0f, 0.0f), source.Polygon[0]);
            AssertPointApproximate(new PointF(1.0f, 0.0f), source.Polygon[1]);
            AssertPointApproximate(new PointF(0.5f, 1.0f), source.Polygon[2]);
        }

        [Test]
        public void DocumentSource_Parse_Pentagon_Accepts5Points()
        {
            var sources = DocumentSource.Parse("D(1,0.0,0.0,1.0,0.0,1.5,0.5,0.5,1.0,0.0,0.5)");
            var source = sources[0];

            Assert.AreEqual(1, source.PageNumber);
            Assert.IsNotNull(source.Polygon);
            Assert.AreEqual(5, source.Polygon!.Count);
        }

        [Test]
        public void DocumentSource_Parse_OddCoordCount_ThrowsFormatException()
        {
            // page + 3 coords (odd number of coords after page)
            Assert.Throws<FormatException>(() => DocumentSource.Parse("D(1,0.0,0.0,1.0)"));
        }

        #endregion

        #region AudioVisualSource Parsing

        [Test]
        public void AudioVisualSource_Parse_WithBoundingBox_ExtractsAllFields()
        {
            var sources = AudioVisualSource.Parse("AV(5000,100,200,50,60)");
            var source = sources[0];

            Assert.AreEqual(TimeSpan.FromMilliseconds(5000), source.Time);
            Assert.IsNotNull(source.BoundingBox);
            Assert.AreEqual(100, source.BoundingBox!.Value.X);
            Assert.AreEqual(200, source.BoundingBox.Value.Y);
            Assert.AreEqual(50, source.BoundingBox.Value.Width);
            Assert.AreEqual(60, source.BoundingBox.Value.Height);
        }

        [Test]
        public void AudioVisualSource_Parse_TimeOnly_HasNullBoundingBox()
        {
            var sources = AudioVisualSource.Parse("AV(5000)");
            var source = sources[0];

            Assert.AreEqual(TimeSpan.FromMilliseconds(5000), source.Time);
            Assert.IsNull(source.BoundingBox);
        }

        [Test]
        public void AudioVisualSource_Parse_RawValue_PreservesOriginalString()
        {
            string raw = "AV(5000,100,200,50,60)";
            var sources = AudioVisualSource.Parse(raw);
            Assert.AreEqual(raw, sources[0].RawValue);
            Assert.AreEqual(raw, sources[0].ToString());
        }

        [Test]
        public void AudioVisualSource_Parse_WrongPrefix_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => AudioVisualSource.Parse("D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)"));
        }

        [Test]
        public void AudioVisualSource_Parse_InvalidParamCount_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => AudioVisualSource.Parse("AV(5000,100,200)"));
        }

        [Test]
        public void AudioVisualSource_Parse_Null_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => AudioVisualSource.Parse(null!));
        }

        [Test]
        public void AudioVisualSource_Parse_MultiSegment_ReturnsMultipleSources()
        {
            string input = "AV(0,100,200,50,60);AV(1000,105,205,50,60)";
            var sources = AudioVisualSource.Parse(input);

            Assert.AreEqual(2, sources.Length);
            Assert.AreEqual(TimeSpan.Zero, sources[0].Time);
            Assert.AreEqual(TimeSpan.FromMilliseconds(1000), sources[1].Time);
        }

        #endregion

        #region ContentSource.Parse

        [Test]
        public void ContentSource_Parse_DocumentPrefix_ReturnsDocumentSource()
        {
            var sources = ContentSource.Parse("D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)");
            Assert.AreEqual(1, sources.Length);
            Assert.IsInstanceOf<DocumentSource>(sources[0]);
        }

        [Test]
        public void ContentSource_Parse_AudioVisualPrefix_ReturnsAudioVisualSource()
        {
            var sources = ContentSource.Parse("AV(5000,100,200,50,60)");
            Assert.AreEqual(1, sources.Length);
            Assert.IsInstanceOf<AudioVisualSource>(sources[0]);
        }

        [Test]
        public void ContentSource_Parse_UnknownPrefix_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => ContentSource.Parse("R(1,2,3)"));
        }

        [Test]
        public void ContentSource_Parse_Null_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => ContentSource.Parse(null!));
        }

        [Test]
        public void ContentSource_Parse_MultiRegionDocument_ReturnsAll()
        {
            string input = "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)";
            var sources = ContentSource.Parse(input);

            Assert.AreEqual(2, sources.Length);
            Assert.IsInstanceOf<DocumentSource>(sources[0]);
            Assert.IsInstanceOf<DocumentSource>(sources[1]);
        }

        [Test]
        public void ContentSource_Parse_SingleSegment_ReturnsSingleElement()
        {
            var sources = ContentSource.Parse("AV(5000)");
            Assert.AreEqual(1, sources.Length);
            Assert.IsInstanceOf<AudioVisualSource>(sources[0]);
        }

        #endregion

        #region ContentField.Sources Integration

        [Test]
        public void ContentField_Sources_NullSource_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentStringField(source: null);
            Assert.IsNull(field.Sources);
        }

        [Test]
        public void ContentField_Sources_EmptySource_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentStringField(source: "");
            Assert.IsNull(field.Sources);
        }

        [Test]
        public void ContentField_Sources_ValidDocumentSource_ReturnsParsedArray()
        {
            var field = ContentUnderstandingModelFactory.ContentStringField(
                source: "D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");

            var sources = field.Sources;
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources!.Length);
            Assert.IsInstanceOf<DocumentSource>(sources[0]);

            var doc = (DocumentSource)sources[0];
            Assert.AreEqual(1, doc.PageNumber);
            Assert.IsNotNull(doc.Polygon);
            Assert.AreEqual(4, doc.Polygon!.Count);
        }

        [Test]
        public void ContentField_Sources_MultiRegion_ReturnsMultipleSources()
        {
            var field = ContentUnderstandingModelFactory.ContentStringField(
                source: "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)");

            var sources = field.Sources;
            Assert.IsNotNull(sources);
            Assert.AreEqual(2, sources!.Length);
        }

        #endregion

        #region ToRawString Extension

        [Test]
        public void ContentSourceExtensions_ToRawString_JoinsSources()
        {
            string input = "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)";
            var sources = ContentSource.Parse(input);

            string result = sources.ToRawString();
            Assert.AreEqual(input, result);
        }

        [Test]
        public void ContentSourceExtensions_ToRawString_SingleSource()
        {
            string input = "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)";
            var sources = ContentSource.Parse(input);

            string result = sources.ToRawString();
            Assert.AreEqual(input, result);
        }

        [Test]
        public void ContentSourceExtensions_ToRawString_Null_ThrowsArgumentNullException()
        {
            ContentSource[]? sources = null;
            Assert.Throws<ArgumentNullException>(() => sources!.ToRawString());
        }

        #endregion

        #region Real Recording Data

        [Test]
        public void DocumentSource_Parse_RealInvoiceSource_ParsesCorrectly()
        {
            // Real source value from invoice test recording
            var sources = DocumentSource.Parse("D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");
            var source = sources[0];

            Assert.AreEqual(1, source.PageNumber);
            Assert.IsNotNull(source.Polygon);
            Assert.AreEqual(4, source.Polygon!.Count);

            // Verify the coordinates match the real data
            Assert.AreEqual(0.5712f, source.Polygon[0].X, 0.0001f);
            Assert.AreEqual(1.4062f, source.Polygon[0].Y, 0.0001f);
            Assert.AreEqual(2.1087f, source.Polygon[1].X, 0.0001f);
            Assert.AreEqual(1.4088f, source.Polygon[1].Y, 0.0001f);
            Assert.AreEqual(2.1084f, source.Polygon[2].X, 0.0001f);
            Assert.AreEqual(1.5762f, source.Polygon[2].Y, 0.0001f);
            Assert.AreEqual(0.5709f, source.Polygon[3].X, 0.0001f);
            Assert.AreEqual(1.5736f, source.Polygon[3].Y, 0.0001f);
        }

        #endregion

        #region Helpers

        private static void AssertPointApproximate(PointF expected, PointF actual, float tolerance = 0.0001f)
        {
            Assert.AreEqual(expected.X, actual.X, tolerance, $"X coordinate mismatch");
            Assert.AreEqual(expected.Y, actual.Y, tolerance, $"Y coordinate mismatch");
        }

        #endregion
    }
}

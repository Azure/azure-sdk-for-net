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
    /// <see cref="AudioVisualSource"/>, and the <see cref="ContentField.GroundingSources"/> property.
    /// </summary>
    [TestFixture]
    public class ContentSourceTests
    {
        #region DocumentSource Parsing

        [Test]
        public void DocumentSource_Parse_SingleSegment_ExtractsPageAndPolygon()
        {
            var source = DocumentSource.Parse("D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");

            Assert.AreEqual(1, source.PageNumber);
            Assert.AreEqual(4, source.Polygon.Count);
            AssertPointApproximate(new PointF(0.5712f, 1.4062f), source.Polygon[0]);
            AssertPointApproximate(new PointF(2.1087f, 1.4088f), source.Polygon[1]);
            AssertPointApproximate(new PointF(2.1084f, 1.5762f), source.Polygon[2]);
            AssertPointApproximate(new PointF(0.5709f, 1.5736f), source.Polygon[3]);
        }

        [Test]
        public void DocumentSource_Parse_PageNumber_IsExtractedCorrectly()
        {
            var source = DocumentSource.Parse("D(3,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)");
            Assert.AreEqual(3, source.PageNumber);
        }

        [Test]
        public void DocumentSource_Parse_RawValue_PreservesOriginalString()
        {
            string raw = "D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)";
            var source = DocumentSource.Parse(raw);
            Assert.AreEqual(raw, source.RawValue);
            Assert.AreEqual(raw, source.ToString());
        }

        [Test]
        public void DocumentSource_ParseAll_MultiRegion_ReturnsMultipleSources()
        {
            string input = "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(1,2.0,2.0,3.0,2.0,3.0,3.0,2.0,3.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)";
            var sources = DocumentSource.ParseAll(input);

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
            var source = DocumentSource.Parse("D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");

            var bbox = source.BoundingBox;
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

        #endregion

        #region AudioVisualSource Parsing

        [Test]
        public void AudioVisualSource_Parse_WithBoundingBox_ExtractsAllFields()
        {
            var source = AudioVisualSource.Parse("AV(5000,100,200,50,60)");

            Assert.AreEqual(5000, source.TimeMs);
            Assert.IsNotNull(source.BoundingBox);
            Assert.AreEqual(100, source.BoundingBox!.Value.X);
            Assert.AreEqual(200, source.BoundingBox.Value.Y);
            Assert.AreEqual(50, source.BoundingBox.Value.Width);
            Assert.AreEqual(60, source.BoundingBox.Value.Height);
        }

        [Test]
        public void AudioVisualSource_Parse_TimeOnly_HasNullBoundingBox()
        {
            var source = AudioVisualSource.Parse("AV(5000)");

            Assert.AreEqual(5000, source.TimeMs);
            Assert.IsNull(source.BoundingBox);
        }

        [Test]
        public void AudioVisualSource_Parse_RawValue_PreservesOriginalString()
        {
            string raw = "AV(5000,100,200,50,60)";
            var source = AudioVisualSource.Parse(raw);
            Assert.AreEqual(raw, source.RawValue);
            Assert.AreEqual(raw, source.ToString());
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
        public void AudioVisualSource_ParseAll_MultiSegment_ReturnsMultipleSources()
        {
            string input = "AV(0,100,200,50,60);AV(1000,105,205,50,60)";
            var sources = AudioVisualSource.ParseAll(input);

            Assert.AreEqual(2, sources.Length);
            Assert.AreEqual(0, sources[0].TimeMs);
            Assert.AreEqual(1000, sources[1].TimeMs);
        }

        #endregion

        #region TrackletSource Parsing

        [Test]
        public void TrackletSource_Parse_SplitsPairCorrectly()
        {
            var tracklet = TrackletSource.Parse("AV(0,100,200,50,60)-AV(1000,105,205,50,60)");

            Assert.AreEqual(0, tracklet.Start.TimeMs);
            Assert.AreEqual(100, tracklet.Start.BoundingBox!.Value.X);
            Assert.AreEqual(1000, tracklet.End.TimeMs);
            Assert.AreEqual(105, tracklet.End.BoundingBox!.Value.X);
        }

        [Test]
        public void TrackletSource_Parse_PreservesRawValue()
        {
            string raw = "AV(0,100,200,50,60)-AV(1000,105,205,50,60)";
            var tracklet = TrackletSource.Parse(raw);
            Assert.AreEqual(raw, tracklet.RawValue);
            Assert.AreEqual(raw, tracklet.ToString());
        }

        [Test]
        public void TrackletSource_Parse_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => TrackletSource.Parse("AV(5000)"));
        }

        [Test]
        public void TrackletSource_Parse_Null_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => TrackletSource.Parse(null!));
        }

        #endregion

        #region ContentSource.Parse Dispatch

        [Test]
        public void ContentSource_Parse_DocumentPrefix_ReturnsDocumentSource()
        {
            var source = ContentSource.Parse("D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)");
            Assert.IsInstanceOf<DocumentSource>(source);
        }

        [Test]
        public void ContentSource_Parse_AudioVisualPrefix_ReturnsAudioVisualSource()
        {
            var source = ContentSource.Parse("AV(5000,100,200,50,60)");
            Assert.IsInstanceOf<AudioVisualSource>(source);
        }

        [Test]
        public void ContentSource_Parse_TrackletPair_ReturnsTrackletSource()
        {
            var source = ContentSource.Parse("AV(0,100,200,50,60)-AV(1000,105,205,50,60)");
            Assert.IsInstanceOf<TrackletSource>(source);

            var tracklet = (TrackletSource)source;
            Assert.AreEqual(0, tracklet.Start.TimeMs);
            Assert.AreEqual(1000, tracklet.End.TimeMs);
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

        #endregion

        #region ContentSource.ParseAll

        [Test]
        public void ContentSource_ParseAll_MultiRegionDocument_ReturnsAll()
        {
            string input = "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)";
            var sources = ContentSource.ParseAll(input);

            Assert.AreEqual(2, sources.Length);
            Assert.IsInstanceOf<DocumentSource>(sources[0]);
            Assert.IsInstanceOf<DocumentSource>(sources[1]);
        }

        [Test]
        public void ContentSource_ParseAll_SingleSegment_ReturnsSingleElement()
        {
            var sources = ContentSource.ParseAll("AV(5000)");
            Assert.AreEqual(1, sources.Length);
            Assert.IsInstanceOf<AudioVisualSource>(sources[0]);
        }

        [Test]
        public void ContentSource_ParseAll_MultiTracklet_ReturnsTrackletSources()
        {
            string input = "AV(0,100,200,50,60)-AV(1000,105,205,50,60);AV(5000,200,180,50,60)-AV(7000,210,190,50,60)";
            var sources = ContentSource.ParseAll(input);

            Assert.AreEqual(2, sources.Length);
            Assert.IsInstanceOf<TrackletSource>(sources[0]);
            Assert.IsInstanceOf<TrackletSource>(sources[1]);

            var t1 = (TrackletSource)sources[0];
            var t2 = (TrackletSource)sources[1];
            Assert.AreEqual(0, t1.Start.TimeMs);
            Assert.AreEqual(1000, t1.End.TimeMs);
            Assert.AreEqual(5000, t2.Start.TimeMs);
            Assert.AreEqual(7000, t2.End.TimeMs);
        }

        [Test]
        public void ContentField_GroundingSources_TrackletPair_ReturnsTrackletSource()
        {
            var field = ContentUnderstandingModelFactory.StringField(
                source: "AV(0,100,200,50,60)-AV(1000,105,205,50,60)");

            var sources = field.GroundingSources;
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources!.Length);
            Assert.IsInstanceOf<TrackletSource>(sources[0]);

            var tracklet = (TrackletSource)sources[0];
            Assert.AreEqual(0, tracklet.Start.TimeMs);
            Assert.AreEqual(1000, tracklet.End.TimeMs);
        }

        #endregion

        #region ContentField.GroundingSources Integration

        [Test]
        public void ContentField_GroundingSources_NullSource_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.StringField(source: null);
            Assert.IsNull(field.GroundingSources);
        }

        [Test]
        public void ContentField_GroundingSources_EmptySource_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.StringField(source: "");
            Assert.IsNull(field.GroundingSources);
        }

        [Test]
        public void ContentField_GroundingSources_ValidDocumentSource_ReturnsParsedArray()
        {
            var field = ContentUnderstandingModelFactory.StringField(
                source: "D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");

            var sources = field.GroundingSources;
            Assert.IsNotNull(sources);
            Assert.AreEqual(1, sources!.Length);
            Assert.IsInstanceOf<DocumentSource>(sources[0]);

            var doc = (DocumentSource)sources[0];
            Assert.AreEqual(1, doc.PageNumber);
            Assert.AreEqual(4, doc.Polygon.Count);
        }

        [Test]
        public void ContentField_GroundingSources_MultiRegion_ReturnsMultipleSources()
        {
            var field = ContentUnderstandingModelFactory.StringField(
                source: "D(1,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0);D(2,0.0,0.0,1.0,0.0,1.0,1.0,0.0,1.0)");

            var sources = field.GroundingSources;
            Assert.IsNotNull(sources);
            Assert.AreEqual(2, sources!.Length);
        }

        #endregion

        #region Real Recording Data

        [Test]
        public void DocumentSource_Parse_RealInvoiceSource_ParsesCorrectly()
        {
            // Real source value from invoice test recording
            var source = DocumentSource.Parse("D(1,0.5712,1.4062,2.1087,1.4088,2.1084,1.5762,0.5709,1.5736)");

            Assert.AreEqual(1, source.PageNumber);
            Assert.AreEqual(4, source.Polygon.Count);

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

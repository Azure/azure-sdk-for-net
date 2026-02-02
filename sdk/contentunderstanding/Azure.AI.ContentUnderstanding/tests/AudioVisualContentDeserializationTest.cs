// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="AudioVisualContent"/> custom deserialization.
    /// Tests the custom DeserializeAudioVisualContent method that handles service response format variations.
    /// </summary>
    [TestFixture]
    public class AudioVisualContentDeserializationTest
    {
        private static readonly ModelReaderWriterOptions DefaultOptions = new ModelReaderWriterOptions("W");

        #region KeyFrameTimesMs Casing Tests

        [Test]
        public void Deserialize_KeyFrameTimesMs_LowercaseK_DeserializesCorrectly()
        {
            // Arrange - lowercase 'k' as per TypeSpec definition
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 10000,
                ""keyFrameTimesMs"": [100, 500, 1000, 2500]
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("video"), content.Kind);
            Assert.AreEqual("video/mp4", content.MimeType);
            Assert.AreEqual(0, content.StartTimeMs);
            Assert.AreEqual(10000, content.EndTimeMs);
            Assert.IsNotNull(content.KeyFrameTimesMs);
            Assert.AreEqual(4, content.KeyFrameTimesMs.Count);
            Assert.AreEqual(100, content.KeyFrameTimesMs[0]);
            Assert.AreEqual(500, content.KeyFrameTimesMs[1]);
            Assert.AreEqual(1000, content.KeyFrameTimesMs[2]);
            Assert.AreEqual(2500, content.KeyFrameTimesMs[3]);
        }

        [Test]
        public void Deserialize_KeyFrameTimesMs_UppercaseK_DeserializesCorrectly()
        {
            // Arrange - uppercase 'K' as the service sometimes returns
            // SERVICE-FIX: This tests the service response format workaround
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""KeyFrameTimesMs"": [200, 800, 1500]
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.KeyFrameTimesMs);
            Assert.AreEqual(3, content.KeyFrameTimesMs.Count);
            Assert.AreEqual(200, content.KeyFrameTimesMs[0]);
            Assert.AreEqual(800, content.KeyFrameTimesMs[1]);
            Assert.AreEqual(1500, content.KeyFrameTimesMs[2]);
        }

        [Test]
        public void Deserialize_KeyFrameTimesMs_BothCasings_UsesFirst()
        {
            // Arrange - Both casings present (edge case)
            // The implementation should use the first one encountered
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""keyFrameTimesMs"": [100, 200],
                ""KeyFrameTimesMs"": [300, 400]
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.KeyFrameTimesMs);
            // Should use the first one encountered (lowercase 'k')
            Assert.AreEqual(2, content.KeyFrameTimesMs.Count);
            Assert.AreEqual(100, content.KeyFrameTimesMs[0]);
            Assert.AreEqual(200, content.KeyFrameTimesMs[1]);
        }

        #endregion

        #region Null Property Tests

        [Test]
        public void Deserialize_NullFields_HandledCorrectly()
        {
            // Arrange - fields property is null
            var json = @"{
                ""kind"": ""audio"",
                ""mimeType"": ""audio/mpeg"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 30000,
                ""fields"": null
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("audio"), content.Kind);
            Assert.IsNotNull(content.Fields); // Should be empty dictionary, not null
            Assert.AreEqual(0, content.Fields.Count);
        }

        [Test]
        public void Deserialize_NullWidth_HandledCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""width"": null,
                ""height"": 720
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNull(content.Width);
            Assert.AreEqual(720, content.Height);
        }

        [Test]
        public void Deserialize_NullHeight_HandledCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""width"": 1920,
                ""height"": null
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(1920, content.Width);
            Assert.IsNull(content.Height);
        }

        [Test]
        public void Deserialize_NullCameraShotTimesMs_HandledCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""cameraShotTimesMs"": null
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.CameraShotTimesMs);
            Assert.AreEqual(0, content.CameraShotTimesMs.Count);
        }

        [Test]
        public void Deserialize_NullKeyFrameTimesMs_HandledCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""keyFrameTimesMs"": null
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.KeyFrameTimesMs);
            Assert.AreEqual(0, content.KeyFrameTimesMs.Count);
        }

        [Test]
        public void Deserialize_NullTranscriptPhrases_HandledCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""audio"",
                ""mimeType"": ""audio/wav"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""transcriptPhrases"": null
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.TranscriptPhrases);
            Assert.AreEqual(0, content.TranscriptPhrases.Count);
        }

        [Test]
        public void Deserialize_NullSegments_HandledCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 10000,
                ""segments"": null
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.Segments);
            Assert.AreEqual(0, content.Segments.Count);
        }

        [Test]
        public void Deserialize_WithSegmentsArray_DeserializesCorrectly()
        {
            // Arrange - segments as non-empty array to cover the deserialization branch
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 30000,
                ""segments"": [
                    {
                        ""segmentId"": ""segment-1"",
                        ""category"": ""scene"",
                        ""startTimeMs"": 0,
                        ""endTimeMs"": 10000
                    },
                    {
                        ""segmentId"": ""segment-2"",
                        ""category"": ""scene"",
                        ""startTimeMs"": 10000,
                        ""endTimeMs"": 20000
                    }
                ]
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.Segments);
            Assert.AreEqual(2, content.Segments.Count);
            Assert.AreEqual("segment-1", content.Segments[0].SegmentId);
            Assert.AreEqual("scene", content.Segments[0].Category);
            Assert.AreEqual(0, content.Segments[0].StartTimeMs);
            Assert.AreEqual(10000, content.Segments[0].EndTimeMs);
            Assert.AreEqual("segment-2", content.Segments[1].SegmentId);
        }

        [Test]
        public void Deserialize_NullElement_ReturnsNull()
        {
            // Arrange
            var json = "null";
            var element = JsonDocument.Parse(json).RootElement;

            // Act
            var content = AudioVisualContent.DeserializeAudioVisualContent(element, DefaultOptions);

            // Assert
            Assert.IsNull(content);
        }

        #endregion

        #region Complete Object Tests

        [Test]
        public void Deserialize_MinimalVideoContent_DeserializesCorrectly()
        {
            // Arrange - Minimal required properties
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 60000
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("video"), content.Kind);
            Assert.AreEqual("video/mp4", content.MimeType);
            Assert.AreEqual(0, content.StartTimeMs);
            Assert.AreEqual(60000, content.EndTimeMs);
            Assert.IsNull(content.Width);
            Assert.IsNull(content.Height);
            Assert.IsNull(content.AnalyzerId);
            Assert.IsNull(content.Category);
            Assert.IsNull(content.Path);
            Assert.IsNull(content.Markdown);
        }

        [Test]
        public void Deserialize_MinimalAudioContent_DeserializesCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""audio"",
                ""mimeType"": ""audio/wav"",
                ""startTimeMs"": 1000,
                ""endTimeMs"": 5000
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("audio"), content.Kind);
            Assert.AreEqual("audio/wav", content.MimeType);
            Assert.AreEqual(1000, content.StartTimeMs);
            Assert.AreEqual(5000, content.EndTimeMs);
        }

        [Test]
        public void Deserialize_FullVideoContent_DeserializesCorrectly()
        {
            // Arrange - All properties populated
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""analyzerId"": ""prebuilt-video"",
                ""category"": ""entertainment"",
                ""path"": ""videos/sample.mp4"",
                ""markdown"": ""# Video Analysis\n\nThis is a sample video."",
                ""startTimeMs"": 0,
                ""endTimeMs"": 120000,
                ""width"": 1920,
                ""height"": 1080,
                ""cameraShotTimesMs"": [0, 15000, 45000, 90000],
                ""keyFrameTimesMs"": [0, 5000, 10000, 20000, 30000]
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("video"), content.Kind);
            Assert.AreEqual("video/mp4", content.MimeType);
            Assert.AreEqual("prebuilt-video", content.AnalyzerId);
            Assert.AreEqual("entertainment", content.Category);
            Assert.AreEqual("videos/sample.mp4", content.Path);
            Assert.AreEqual("# Video Analysis\n\nThis is a sample video.", content.Markdown);
            Assert.AreEqual(0, content.StartTimeMs);
            Assert.AreEqual(120000, content.EndTimeMs);
            Assert.AreEqual(1920, content.Width);
            Assert.AreEqual(1080, content.Height);
            Assert.AreEqual(4, content.CameraShotTimesMs.Count);
            Assert.AreEqual(5, content.KeyFrameTimesMs.Count);
        }

        [Test]
        public void Deserialize_WithFields_DeserializesCorrectly()
        {
            // Arrange - With nested fields
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 30000,
                ""fields"": {
                    ""title"": {
                        ""type"": ""string"",
                        ""valueString"": ""Sample Video Title""
                    },
                    ""duration"": {
                        ""type"": ""number"",
                        ""valueNumber"": 30.5
                    }
                }
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.Fields);
            Assert.AreEqual(2, content.Fields.Count);
            Assert.IsTrue(content.Fields.ContainsKey("title"));
            Assert.IsTrue(content.Fields.ContainsKey("duration"));
            Assert.IsInstanceOf<StringField>(content.Fields["title"]);
            Assert.IsInstanceOf<NumberField>(content.Fields["duration"]);
        }

        #endregion

        #region Array Property Tests

        [Test]
        public void Deserialize_CameraShotTimesMs_DeserializesCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 60000,
                ""cameraShotTimesMs"": [0, 5000, 12000, 25000, 40000, 55000]
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(6, content.CameraShotTimesMs.Count);
            Assert.AreEqual(0, content.CameraShotTimesMs[0]);
            Assert.AreEqual(5000, content.CameraShotTimesMs[1]);
            Assert.AreEqual(55000, content.CameraShotTimesMs[5]);
        }

        [Test]
        public void Deserialize_EmptyCameraShotTimesMs_DeserializesCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""cameraShotTimesMs"": []
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.CameraShotTimesMs);
            Assert.AreEqual(0, content.CameraShotTimesMs.Count);
        }

        [Test]
        public void Deserialize_EmptyKeyFrameTimesMs_DeserializesCorrectly()
        {
            // Arrange
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""keyFrameTimesMs"": []
            }";

            // Act
            var content = DeserializeFromJson(json);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.KeyFrameTimesMs);
            Assert.AreEqual(0, content.KeyFrameTimesMs.Count);
        }

        #endregion

        #region Format Options Tests

        [Test]
        public void Deserialize_WithFormatJ_CapturesUnknownProperties()
        {
            // Arrange - Use "J" format which captures unknown properties in additionalBinaryDataProperties
            var options = new ModelReaderWriterOptions("J");
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""unknownProperty1"": ""custom value"",
                ""unknownProperty2"": 42,
                ""unknownObject"": { ""nested"": true }
            }";

            // Act
            using var document = JsonDocument.Parse(json);
            var content = AudioVisualContent.DeserializeAudioVisualContent(document.RootElement, options);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("video"), content.Kind);
            Assert.AreEqual("video/mp4", content.MimeType);
            // Note: additionalBinaryDataProperties is internal, but the deserialization should not throw
            // and all known properties should be correctly parsed
            Assert.AreEqual(0, content.StartTimeMs);
            Assert.AreEqual(5000, content.EndTimeMs);
        }

        [Test]
        public void Deserialize_WithFormatW_IgnoresUnknownProperties()
        {
            // Arrange - Use "W" (wire) format which ignores unknown properties
            var options = new ModelReaderWriterOptions("W");
            var json = @"{
                ""kind"": ""audio"",
                ""mimeType"": ""audio/wav"",
                ""startTimeMs"": 100,
                ""endTimeMs"": 3000,
                ""customExtension"": ""ignored value""
            }";

            // Act
            using var document = JsonDocument.Parse(json);
            var content = AudioVisualContent.DeserializeAudioVisualContent(document.RootElement, options);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("audio"), content.Kind);
            Assert.AreEqual("audio/wav", content.MimeType);
            Assert.AreEqual(100, content.StartTimeMs);
            Assert.AreEqual(3000, content.EndTimeMs);
        }

        [Test]
        public void Deserialize_WithFormatJ_MultipleUnknownPropertyTypes()
        {
            // Arrange - Various unknown property types with "J" format
            var options = new ModelReaderWriterOptions("J");
            var json = @"{
                ""kind"": ""video"",
                ""mimeType"": ""video/webm"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 10000,
                ""width"": 1280,
                ""height"": 720,
                ""extraString"": ""test"",
                ""extraNumber"": 123.45,
                ""extraBool"": true,
                ""extraArray"": [1, 2, 3],
                ""extraNull"": null
            }";

            // Act
            using var document = JsonDocument.Parse(json);
            var content = AudioVisualContent.DeserializeAudioVisualContent(document.RootElement, options);

            // Assert
            Assert.IsNotNull(content);
            Assert.AreEqual(new MediaContentKind("video"), content.Kind);
            Assert.AreEqual("video/webm", content.MimeType);
            Assert.AreEqual(1280, content.Width);
            Assert.AreEqual(720, content.Height);
        }

        #endregion

        #region Helper Methods

        private static AudioVisualContent DeserializeFromJson(string json)
        {
            using var document = JsonDocument.Parse(json);
            return AudioVisualContent.DeserializeAudioVisualContent(document.RootElement, DefaultOptions);
        }

        #endregion
    }
}

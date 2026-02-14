// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="AudioVisualContent"/> custom deserialization logic,
    /// specifically the SERVICE-FIX for KeyFrameTimesMs casing and null-handling branches.
    /// </summary>
    [TestFixture]
    public class AudioVisualContentDeserializationTest
    {
        private static readonly ModelReaderWriterOptions JsonOptions = new ModelReaderWriterOptions("J");

        private static AudioVisualContent DeserializeFromJson(string json)
        {
            var binaryData = BinaryData.FromString(json);
            return ModelReaderWriter.Read<AudioVisualContent>(binaryData, JsonOptions)!;
        }

        #region Null value handling

        [Test]
        public void Deserialize_NullJsonElement_ReturnsNull()
        {
            // Test the null path: if (element.ValueKind == JsonValueKind.Null) return null;
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 10000,
                ""width"": null,
                ""height"": null,
                ""cameraShotTimesMs"": null,
                ""keyFrameTimesMs"": null,
                ""transcriptPhrases"": null,
                ""segments"": null
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.IsNull(result.Width);
            Assert.IsNull(result.Height);
            // Null arrays should be initialized as empty (ChangeTrackingList)
            Assert.IsNotNull(result.CameraShotTimesMs);
            Assert.AreEqual(0, result.CameraShotTimesMs.Count);
            Assert.IsNotNull(result.KeyFrameTimesMs);
            Assert.AreEqual(0, result.KeyFrameTimesMs.Count);
            Assert.IsNotNull(result.TranscriptPhrases);
            Assert.AreEqual(0, result.TranscriptPhrases.Count);
            Assert.IsNotNull(result.Segments);
            Assert.AreEqual(0, result.Segments.Count);
        }

        #endregion

        #region KeyFrameTimesMs casing SERVICE-FIX

        [Test]
        public void Deserialize_KeyFrameTimesMs_LowercaseK_Works()
        {
            // Test the standard TypeSpec casing: "keyFrameTimesMs"
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 60000,
                ""keyFrameTimesMs"": [1000, 2000, 3000]
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.KeyFrameTimesMs);
            Assert.AreEqual(3, result.KeyFrameTimesMs.Count);
            Assert.AreEqual(1000, result.KeyFrameTimesMs[0]);
            Assert.AreEqual(2000, result.KeyFrameTimesMs[1]);
            Assert.AreEqual(3000, result.KeyFrameTimesMs[2]);
        }

        [Test]
        public void Deserialize_KeyFrameTimesMs_UppercaseK_Works()
        {
            // Test the SERVICE-FIX casing: "KeyFrameTimesMs" (capital K)
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 60000,
                ""KeyFrameTimesMs"": [5000, 10000]
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.KeyFrameTimesMs);
            Assert.AreEqual(2, result.KeyFrameTimesMs.Count);
            Assert.AreEqual(5000, result.KeyFrameTimesMs[0]);
            Assert.AreEqual(10000, result.KeyFrameTimesMs[1]);
        }

        #endregion

        #region Minimal required fields

        [Test]
        public void Deserialize_MinimalFields_Works()
        {
            // Test with only the minimum required fields
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 100,
                ""endTimeMs"": 5000
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.StartTimeMs);
            Assert.AreEqual(5000, result.EndTimeMs);
            Assert.IsNull(result.MimeType);
            Assert.IsNull(result.AnalyzerId);
            Assert.IsNull(result.Category);
            Assert.IsNull(result.Path);
            Assert.IsNull(result.Markdown);
            Assert.IsNull(result.Width);
            Assert.IsNull(result.Height);
        }

        #endregion

        #region All fields populated

        [Test]
        public void Deserialize_AllFieldsPopulated_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""mimeType"": ""video/mp4"",
                ""analyzerId"": ""prebuilt-videoSearch"",
                ""category"": ""video"",
                ""path"": ""/content/0"",
                ""markdown"": ""# Video Content"",
                ""fields"": {
                    ""Description"": {
                        ""type"": ""string"",
                        ""valueString"": ""A sample video""
                    }
                },
                ""startTimeMs"": 0,
                ""endTimeMs"": 120000,
                ""width"": 1920,
                ""height"": 1080,
                ""cameraShotTimesMs"": [0, 5000, 10000],
                ""keyFrameTimesMs"": [2500, 7500],
                ""transcriptPhrases"": [
                    {
                        ""startTimeMs"": 0,
                        ""endTimeMs"": 3000,
                        ""text"": ""Hello world""
                    }
                ],
                ""segments"": [
                    {
                        ""segmentId"": ""seg1"",
                        ""category"": ""intro"",
                        ""startTimeMs"": 0,
                        ""endTimeMs"": 5000
                    }
                ]
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual("video/mp4", result.MimeType);
            Assert.AreEqual("prebuilt-videoSearch", result.AnalyzerId);
            Assert.AreEqual("video", result.Category);
            Assert.AreEqual("/content/0", result.Path);
            Assert.AreEqual("# Video Content", result.Markdown);

            Assert.IsNotNull(result.Fields);
            Assert.IsTrue(result.Fields.ContainsKey("Description"));

            Assert.AreEqual(0, result.StartTimeMs);
            Assert.AreEqual(120000, result.EndTimeMs);
            Assert.AreEqual(1920, result.Width);
            Assert.AreEqual(1080, result.Height);

            Assert.AreEqual(3, result.CameraShotTimesMs.Count);
            Assert.AreEqual(0, result.CameraShotTimesMs[0]);
            Assert.AreEqual(5000, result.CameraShotTimesMs[1]);
            Assert.AreEqual(10000, result.CameraShotTimesMs[2]);

            Assert.AreEqual(2, result.KeyFrameTimesMs.Count);
            Assert.AreEqual(2500, result.KeyFrameTimesMs[0]);
            Assert.AreEqual(7500, result.KeyFrameTimesMs[1]);

            Assert.AreEqual(1, result.TranscriptPhrases.Count);
            Assert.AreEqual("Hello world", result.TranscriptPhrases[0].Text);

            Assert.AreEqual(1, result.Segments.Count);
            Assert.AreEqual("seg1", result.Segments[0].SegmentId);
            Assert.AreEqual("intro", result.Segments[0].Category);
        }

        #endregion

        #region Fields deserialization with null

        [Test]
        public void Deserialize_NullFields_SetsEmptyDictionary()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 1000,
                ""fields"": null
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            // When fields is null in JSON, it should not be set (stays as default empty)
            Assert.IsNotNull(result.Fields);
            Assert.AreEqual(0, result.Fields.Count);
        }

        #endregion

        #region Unknown properties handling (format != "W")

        [Test]
        public void Deserialize_UnknownProperties_ArePreservedInJFormat()
        {
            // When format is "J" (not "W"), unknown properties should be stored as additional binary data
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""someUnknownProperty"": ""unknownValue"",
                ""anotherUnknownProp"": 42
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.StartTimeMs);
            Assert.AreEqual(5000, result.EndTimeMs);

            // Re-serialize to verify unknown properties are preserved (round-trip)
            var serialized = ModelReaderWriter.Write(result, JsonOptions);
            Assert.IsNotNull(serialized);
            var serializedString = serialized.ToString();
            Assert.IsTrue(serializedString.Contains("someUnknownProperty"), "Unknown property should be preserved in round-trip");
            Assert.IsTrue(serializedString.Contains("unknownValue"), "Unknown property value should be preserved");
        }

        #endregion

        #region CameraShotTimesMs deserialization

        [Test]
        public void Deserialize_CameraShotTimesMs_EmptyArray_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""cameraShotTimesMs"": []
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CameraShotTimesMs);
            Assert.AreEqual(0, result.CameraShotTimesMs.Count);
        }

        [Test]
        public void Deserialize_CameraShotTimesMs_WithValues_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 30000,
                ""cameraShotTimesMs"": [0, 10000, 20000]
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.CameraShotTimesMs.Count);
            Assert.AreEqual(0, result.CameraShotTimesMs[0]);
            Assert.AreEqual(10000, result.CameraShotTimesMs[1]);
            Assert.AreEqual(20000, result.CameraShotTimesMs[2]);
        }

        #endregion

        #region TranscriptPhrases deserialization

        [Test]
        public void Deserialize_TranscriptPhrases_EmptyArray_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""transcriptPhrases"": []
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.TranscriptPhrases);
            Assert.AreEqual(0, result.TranscriptPhrases.Count);
        }

        [Test]
        public void Deserialize_TranscriptPhrases_WithMultipleItems_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 10000,
                ""transcriptPhrases"": [
                    {
                        ""speaker"": ""Speaker1"",
                        ""startTimeMs"": 0,
                        ""endTimeMs"": 3000,
                        ""locale"": ""en-US"",
                        ""text"": ""First phrase""
                    },
                    {
                        ""speaker"": ""Speaker2"",
                        ""startTimeMs"": 3000,
                        ""endTimeMs"": 6000,
                        ""locale"": ""en-US"",
                        ""text"": ""Second phrase""
                    }
                ]
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.TranscriptPhrases.Count);
            Assert.AreEqual("Speaker1", result.TranscriptPhrases[0].Speaker);
            Assert.AreEqual("First phrase", result.TranscriptPhrases[0].Text);
            Assert.AreEqual("Speaker2", result.TranscriptPhrases[1].Speaker);
            Assert.AreEqual("Second phrase", result.TranscriptPhrases[1].Text);
        }

        #endregion

        #region Segments deserialization

        [Test]
        public void Deserialize_Segments_EmptyArray_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""segments"": []
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Segments);
            Assert.AreEqual(0, result.Segments.Count);
        }

        [Test]
        public void Deserialize_Segments_WithMultipleItems_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 60000,
                ""segments"": [
                    {
                        ""segmentId"": ""seg1"",
                        ""category"": ""intro"",
                        ""startTimeMs"": 0,
                        ""endTimeMs"": 20000
                    },
                    {
                        ""segmentId"": ""seg2"",
                        ""category"": ""main"",
                        ""startTimeMs"": 20000,
                        ""endTimeMs"": 60000
                    }
                ]
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Segments.Count);
            Assert.AreEqual("seg1", result.Segments[0].SegmentId);
            Assert.AreEqual("intro", result.Segments[0].Category);
            Assert.AreEqual("seg2", result.Segments[1].SegmentId);
            Assert.AreEqual("main", result.Segments[1].Category);
        }

        #endregion

        #region Width/Height deserialization

        [Test]
        public void Deserialize_WidthAndHeight_Populated_Works()
        {
            var json = @"{
                ""kind"": ""audioVisual"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 5000,
                ""width"": 3840,
                ""height"": 2160
            }";

            var result = DeserializeFromJson(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(3840, result.Width);
            Assert.AreEqual(2160, result.Height);
        }

        #endregion

        #region Round-trip serialization

        [Test]
        public void RoundTrip_AudioVisualContent_PreservesData()
        {
            // Create via ModelFactory
            var original = ContentUnderstandingModelFactory.AudioVisualContent(
                mimeType: "video/mp4",
                analyzerId: "test-analyzer",
                startTimeMs: 0,
                endTimeMs: 60000,
                width: 1280,
                height: 720,
                cameraShotTimesMs: new long[] { 0, 15000, 30000 },
                keyFrameTimesMs: new long[] { 5000, 25000, 45000 }
            );

            // Serialize and deserialize
            var serialized = ModelReaderWriter.Write(original, JsonOptions);
            var deserialized = ModelReaderWriter.Read<AudioVisualContent>(serialized, JsonOptions)!;

            Assert.IsNotNull(deserialized);
            Assert.AreEqual("video/mp4", deserialized.MimeType);
            Assert.AreEqual("test-analyzer", deserialized.AnalyzerId);
            Assert.AreEqual(0, deserialized.StartTimeMs);
            Assert.AreEqual(60000, deserialized.EndTimeMs);
            Assert.AreEqual(1280, deserialized.Width);
            Assert.AreEqual(720, deserialized.Height);
            Assert.AreEqual(3, deserialized.CameraShotTimesMs.Count);
            Assert.AreEqual(3, deserialized.KeyFrameTimesMs.Count);
        }

        #endregion
    }
}

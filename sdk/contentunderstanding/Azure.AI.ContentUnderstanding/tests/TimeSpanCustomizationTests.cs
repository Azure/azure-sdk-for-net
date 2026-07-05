// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests verifying that the TimeSpan customizations on
    /// <see cref="AudioVisualContent"/>, <see cref="AudioVisualContentSegment"/>,
    /// <see cref="TranscriptPhrase"/>, and <see cref="TranscriptWord"/>
    /// correctly convert millisecond wire-format values to <see cref="TimeSpan"/>.
    /// </summary>
    [TestFixture]
    public class TimeSpanCustomizationTests
    {
        private static readonly ModelReaderWriterOptions s_jsonOptions = new("J");

        #region AudioVisualContent

        [Test]
        public void AudioVisualContent_StartTime_ReturnsTimeSpanFromMs()
        {
            var content = DeserializeAudioVisualContent(startTimeMs: 5000, endTimeMs: 10000);

            Assert.AreEqual(TimeSpan.FromMilliseconds(5000), content.StartTime);
        }

        [Test]
        public void AudioVisualContent_EndTime_ReturnsTimeSpanFromMs()
        {
            var content = DeserializeAudioVisualContent(startTimeMs: 0, endTimeMs: 123456);

            Assert.AreEqual(TimeSpan.FromMilliseconds(123456), content.EndTime);
        }

        [Test]
        public void AudioVisualContent_KeyFrameTimes_ConvertsListToTimeSpan()
        {
            string json = @"{
                ""kind"": ""audioVisual"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 30000,
                ""keyFrameTimesMs"": [0, 5000, 15000, 30000]
            }";

            var content = DeserializeFromJson<AudioVisualContent>(json);

            Assert.AreEqual(4, content.KeyFrameTimes.Count);
            Assert.AreEqual(TimeSpan.Zero, content.KeyFrameTimes[0]);
            Assert.AreEqual(TimeSpan.FromSeconds(5), content.KeyFrameTimes[1]);
            Assert.AreEqual(TimeSpan.FromSeconds(15), content.KeyFrameTimes[2]);
            Assert.AreEqual(TimeSpan.FromSeconds(30), content.KeyFrameTimes[3]);
        }

        [Test]
        public void AudioVisualContent_KeyFrameTimes_HandlesCapitalKFromService()
        {
            // SERVICE-FIX: Service returns "KeyFrameTimesMs" with capital K
            string json = @"{
                ""kind"": ""audioVisual"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 10000,
                ""KeyFrameTimesMs"": [1000, 2000, 3000]
            }";

            var content = DeserializeFromJson<AudioVisualContent>(json);

            Assert.AreEqual(3, content.KeyFrameTimes.Count);
            Assert.AreEqual(TimeSpan.FromSeconds(1), content.KeyFrameTimes[0]);
            Assert.AreEqual(TimeSpan.FromSeconds(2), content.KeyFrameTimes[1]);
            Assert.AreEqual(TimeSpan.FromSeconds(3), content.KeyFrameTimes[2]);
        }

        [Test]
        public void AudioVisualContent_CameraShotTimes_ConvertsListToTimeSpan()
        {
            string json = @"{
                ""kind"": ""audioVisual"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": 0,
                ""endTimeMs"": 60000,
                ""cameraShotTimesMs"": [0, 12500, 25000, 37500, 50000]
            }";

            var content = DeserializeFromJson<AudioVisualContent>(json);

            Assert.AreEqual(5, content.CameraShotTimes.Count);
            Assert.AreEqual(TimeSpan.Zero, content.CameraShotTimes[0]);
            Assert.AreEqual(TimeSpan.FromMilliseconds(12500), content.CameraShotTimes[1]);
            Assert.AreEqual(TimeSpan.FromMilliseconds(50000), content.CameraShotTimes[4]);
        }

        [Test]
        public void AudioVisualContent_EmptyLists_ReturnEmptyTimeSpanLists()
        {
            var content = DeserializeAudioVisualContent(startTimeMs: 0, endTimeMs: 1000);

            Assert.IsNotNull(content.KeyFrameTimes);
            Assert.AreEqual(0, content.KeyFrameTimes.Count);
            Assert.IsNotNull(content.CameraShotTimes);
            Assert.AreEqual(0, content.CameraShotTimes.Count);
        }

        [Test]
        public void AudioVisualContent_ZeroMs_ReturnsTimeSpanZero()
        {
            var content = DeserializeAudioVisualContent(startTimeMs: 0, endTimeMs: 0);

            Assert.AreEqual(TimeSpan.Zero, content.StartTime);
            Assert.AreEqual(TimeSpan.Zero, content.EndTime);
        }

        [Test]
        public void AudioVisualContent_LargeMs_ReturnsCorrectTimeSpan()
        {
            // 2 hours, 30 minutes, 45 seconds = 9045000 ms
            var content = DeserializeAudioVisualContent(startTimeMs: 0, endTimeMs: 9045000);

            Assert.AreEqual(TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30) + TimeSpan.FromSeconds(45), content.EndTime);
        }

        #endregion

        #region AudioVisualContentSegment

        [Test]
        public void AudioVisualContentSegment_StartTime_ReturnsTimeSpanFromMs()
        {
            string json = @"{
                ""segmentId"": ""seg-1"",
                ""category"": ""video"",
                ""span"": { ""offset"": 0, ""length"": 100 },
                ""startTimeMs"": 3000,
                ""endTimeMs"": 8000
            }";

            var segment = DeserializeFromJson<AudioVisualContentSegment>(json);

            Assert.AreEqual(TimeSpan.FromSeconds(3), segment.StartTime);
            Assert.AreEqual(TimeSpan.FromSeconds(8), segment.EndTime);
        }

        [Test]
        public void AudioVisualContentSegment_SubSecondPrecision()
        {
            string json = @"{
                ""segmentId"": ""seg-2"",
                ""category"": ""video"",
                ""span"": { ""offset"": 0, ""length"": 50 },
                ""startTimeMs"": 1500,
                ""endTimeMs"": 2750
            }";

            var segment = DeserializeFromJson<AudioVisualContentSegment>(json);

            Assert.AreEqual(TimeSpan.FromMilliseconds(1500), segment.StartTime);
            Assert.AreEqual(TimeSpan.FromMilliseconds(2750), segment.EndTime);
        }

        #endregion

        #region TranscriptPhrase

        [Test]
        public void TranscriptPhrase_StartTime_ReturnsTimeSpanFromMs()
        {
            string json = @"{
                ""startTimeMs"": 12000,
                ""endTimeMs"": 15000,
                ""text"": ""Hello world"",
                ""words"": []
            }";

            var phrase = DeserializeFromJson<TranscriptPhrase>(json);

            Assert.AreEqual(TimeSpan.FromSeconds(12), phrase.StartTime);
            Assert.AreEqual(TimeSpan.FromSeconds(15), phrase.EndTime);
        }

        [Test]
        public void TranscriptPhrase_SubSecondPrecision()
        {
            string json = @"{
                ""startTimeMs"": 500,
                ""endTimeMs"": 1200,
                ""text"": ""Quick"",
                ""words"": []
            }";

            var phrase = DeserializeFromJson<TranscriptPhrase>(json);

            Assert.AreEqual(TimeSpan.FromMilliseconds(500), phrase.StartTime);
            Assert.AreEqual(TimeSpan.FromMilliseconds(1200), phrase.EndTime);
        }

        #endregion

        #region TranscriptWord

        [Test]
        public void TranscriptWord_StartTime_ReturnsTimeSpanFromMs()
        {
            string json = @"{
                ""startTimeMs"": 100,
                ""endTimeMs"": 400,
                ""text"": ""hello""
            }";

            var word = DeserializeFromJson<TranscriptWord>(json);

            Assert.AreEqual(TimeSpan.FromMilliseconds(100), word.StartTime);
            Assert.AreEqual(TimeSpan.FromMilliseconds(400), word.EndTime);
        }

        [Test]
        public void TranscriptWord_ZeroMs_ReturnsTimeSpanZero()
        {
            string json = @"{
                ""startTimeMs"": 0,
                ""endTimeMs"": 0,
                ""text"": ""start""
            }";

            var word = DeserializeFromJson<TranscriptWord>(json);

            Assert.AreEqual(TimeSpan.Zero, word.StartTime);
            Assert.AreEqual(TimeSpan.Zero, word.EndTime);
        }

        #endregion

        #region Helpers

        private static AudioVisualContent DeserializeAudioVisualContent(long startTimeMs, long endTimeMs)
        {
            string json = $@"{{
                ""kind"": ""audioVisual"",
                ""mimeType"": ""video/mp4"",
                ""startTimeMs"": {startTimeMs},
                ""endTimeMs"": {endTimeMs}
            }}";

            return DeserializeFromJson<AudioVisualContent>(json);
        }

        private static T DeserializeFromJson<T>(string json) where T : IJsonModel<T>
        {
            // Use IJsonModel<T>.Create to deserialize, which invokes the generated
            // Deserialize* methods and correctly maps [CodeGenMember] backing fields.
            // The generated types have an internal parameterless constructor for deserialization.
            T prototype = (T)Activator.CreateInstance(typeof(T), nonPublic: true)!;
            return prototype.Create(BinaryData.FromString(json), s_jsonOptions)!;
        }

        #endregion
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for AudioVisualContent to customize serialization/deserialization.
    /// </summary>
    // SERVICE-FIX: Suppress DeserializeAudioVisualContent to fix KeyFrameTimesMs property name casing inconsistency (service returns "KeyFrameTimesMs" instead of "keyFrameTimesMs")
    [CodeGenSuppress("DeserializeAudioVisualContent", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class AudioVisualContent
    {
        internal static AudioVisualContent DeserializeAudioVisualContent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MediaContentKind kind = default;
            string mimeType = default;
            string analyzerId = default;
            string category = default;
            string path = default;
            string markdown = default;
            IDictionary<string, ContentField> fields = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            long startTimeMs = default;
            long endTimeMs = default;
            int? width = default;
            int? height = default;
            IList<long> cameraShotTimesMs = default;
            IList<long> keyFrameTimesMs = default;
            IList<TranscriptPhrase> transcriptPhrases = default;
            IList<AudioVisualContentSegment> segments = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("kind"u8))
                {
                    kind = new MediaContentKind(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("mimeType"u8))
                {
                    mimeType = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("analyzerId"u8))
                {
                    analyzerId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("category"u8))
                {
                    category = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("path"u8))
                {
                    path = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("markdown"u8))
                {
                    markdown = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("fields"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, ContentField> dictionary = new Dictionary<string, ContentField>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        dictionary.Add(prop0.Name, ContentField.DeserializeContentField(prop0.Value, options));
                    }
                    fields = dictionary;
                    continue;
                }
                if (prop.NameEquals("startTimeMs"u8))
                {
                    startTimeMs = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("endTimeMs"u8))
                {
                    endTimeMs = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("width"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    width = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("height"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    height = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("cameraShotTimesMs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<long> array = new List<long>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt64());
                    }
                    cameraShotTimesMs = array;
                    continue;
                }
                // SERVICE-FIX: Handle both "keyFrameTimesMs" (TypeSpec definition) and "KeyFrameTimesMs" (service response format - capital K)
                if (prop.NameEquals("keyFrameTimesMs"u8) || prop.NameEquals("KeyFrameTimesMs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    // Only set if not already set (to avoid overwriting if both casings are present)
                    if (keyFrameTimesMs == null)
                    {
                        List<long> array = new List<long>();
                        foreach (var item in prop.Value.EnumerateArray())
                        {
                            array.Add(item.GetInt64());
                        }
                        keyFrameTimesMs = array;
                    }
                    continue;
                }
                if (prop.NameEquals("transcriptPhrases"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TranscriptPhrase> array = new List<TranscriptPhrase>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(TranscriptPhrase.DeserializeTranscriptPhrase(item, options));
                    }
                    transcriptPhrases = array;
                    continue;
                }
                if (prop.NameEquals("segments"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AudioVisualContentSegment> array = new List<AudioVisualContentSegment>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(AudioVisualContentSegment.DeserializeAudioVisualContentSegment(item, options));
                    }
                    segments = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AudioVisualContent(
                kind,
                mimeType,
                analyzerId,
                category,
                path,
                markdown,
                fields ?? new ChangeTrackingDictionary<string, ContentField>(),
                additionalBinaryDataProperties,
                startTimeMs,
                endTimeMs,
                width,
                height,
                cameraShotTimesMs ?? new ChangeTrackingList<long>(),
                keyFrameTimesMs ?? new ChangeTrackingList<long>(),
                transcriptPhrases ?? new ChangeTrackingList<TranscriptPhrase>(),
                segments ?? new ChangeTrackingList<AudioVisualContentSegment>());
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive.TestDataGenerator.Models
{
    /// <summary>
    /// Categories of test data that can be generated.
    /// </summary>
    [Flags]
    public enum TestDataCategory
    {
        None = 0,
        Speech = 1,
        Tones = 2,
        Noise = 4,
        Formats = 8,
        Mixed = 16,
        All = Speech | Tones | Noise | Formats | Mixed
    }

    /// <summary>
    /// Configuration for Azure Speech Services.
    /// </summary>
    public class AzureSpeechConfig
    {
        public string? SubscriptionKey { get; set; }
        public string? Region { get; set; }
        public string? EndpointId { get; set; }
        public List<string> Voices { get; set; } = new();
        public List<string> Languages { get; set; } = new();
        public int DefaultSampleRate { get; set; } = 24000;
    }

    /// <summary>
    /// Test phrases organized by category.
    /// </summary>
    public class TestPhrases
    {
        public Dictionary<string, List<TestPhrase>> Categories { get; set; } = new();

        public IEnumerable<TestPhrase> GetAllPhrases()
        {
            foreach (var category in Categories.Values)
            {
                foreach (var phrase in category)
                {
                    yield return phrase;
                }
            }
        }

        public IEnumerable<TestPhrase> GetCategory(string categoryName)
        {
            if (Categories.TryGetValue(categoryName, out var phrases))
            {
                return phrases;
            }
            return Array.Empty<TestPhrase>();
        }
    }

    /// <summary>
    /// Individual test phrase with metadata.
    /// </summary>
    public class TestPhrase
    {
        public string Id { get; set; } = "";
        public string Text { get; set; } = "";
        public string? Description { get; set; }
        public string? ExpectedDuration { get; set; }
        public List<string>? Languages { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }
    }

    /// <summary>
    /// Audio format specifications.
    /// </summary>
    public class AudioFormat
    {
        public string Name { get; set; } = "";
        public string Codec { get; set; } = "";
        public int SampleRate { get; set; }
        public int BitsPerSample { get; set; }
        public int Channels { get; set; }
        public string FileExtension { get; set; } = "";
    }

    /// <summary>
    /// Metadata about generated test data.
    /// </summary>
    public class TestDataMetadata
    {
        public DateTime GeneratedAt { get; set; }
        public string Version { get; set; } = "";
        public int TotalFiles { get; set; }
        public List<string> Categories { get; set; } = new();
        public int PhraseCount { get; set; }
        public Dictionary<string, int> FilesByCategory { get; set; } = new();
    }

    /// <summary>
    /// Voice configuration for speech generation.
    /// </summary>
    public class VoiceConfig
    {
        public string Name { get; set; } = "";
        public string Language { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Type { get; set; } = ""; // Neural, Standard, etc.
        public Dictionary<string, string>? Properties { get; set; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Validates test audio files meet requirements.
    /// </summary>
    public static class TestDataValidator
    {
        /// <summary>
        /// Validates that required test audio files exist in the test directory
        /// </summary>
        public static void ValidateRequiredTestFiles(string testAudioPath)
        {
            var requiredTestFiles = new List<string>
            {
                Path.Combine(testAudioPath, "Basic", "hello.wav"),
                Path.Combine(testAudioPath, "Questions", "whats_weather_in_seattle.wav")
            };

            foreach (var file in requiredTestFiles)
            {
                if (!File.Exists(file))
                {
                    TestContext.WriteLine($"Warning: Required test file not found: {file}");
                }
            }
        }

        /// <summary>
        /// Checks if a file is a valid WAV file
        /// </summary>
        public static ValidationResult ValidateAudioFile(string filePath)
        {
            var result = new ValidationResult { FilePath = filePath };

            try
            {
                if (!File.Exists(filePath))
                {
                    result.Errors.Add($"File not found: {filePath}");
                    return result;
                }

                var fileInfo = new FileInfo(filePath);

                // Check file size
                if (fileInfo.Length == 0)
                {
                    result.Errors.Add("File is empty");
                }
                else if (fileInfo.Length > 10 * 1024 * 1024) // 10MB
                {
                    result.Warnings.Add($"File is large ({fileInfo.Length / 1024 / 1024}MB)");
                }

                // Validate WAV header
                using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using var reader = new BinaryReader(fs);

                // Check RIFF header
                if (new string(reader.ReadChars(4)) != "RIFF")
                {
                    result.Errors.Add("Not a valid RIFF file");
                    return result;
                }

                reader.ReadInt32(); // File size minus 8 bytes

                // Check WAVE format
                if (new string(reader.ReadChars(4)) != "WAVE")
                {
                    result.Errors.Add("Not a valid WAVE file");
                    return result;
                }

                // Look for fmt chunk
                bool foundFmt = false;
                bool foundData = false;

                while (fs.Position < fs.Length - 8 && !(foundFmt && foundData))
                {
                    string chunkId = new string(reader.ReadChars(4));
                    int chunkSize = reader.ReadInt32();

                    if (chunkId == "fmt ")
                    {
                        foundFmt = true;

                        // Read format info
                        short audioFormat = reader.ReadInt16();
                        if (audioFormat != 1) // PCM = 1
                        {
                            result.Warnings.Add($"Non-PCM format: {audioFormat}");
                        }

                        short channels = reader.ReadInt16();
                        result.Channels = channels;

                        int sampleRate = reader.ReadInt32();
                        result.SampleRate = sampleRate;

                        reader.ReadInt32(); // Byte rate
                        reader.ReadInt16(); // Block align

                        short bitsPerSample = reader.ReadInt16();
                        result.BitDepth = bitsPerSample;

                        if (bitsPerSample != 16)
                        {
                            result.Warnings.Add($"Not 16-bit PCM: {bitsPerSample} bits per sample");
                        }

                        fs.Seek(chunkSize - 16, SeekOrigin.Current); // Skip remaining format data
                    }
                    else if (chunkId == "data")
                    {
                        foundData = true;
                        result.Duration = TimeSpan.FromSeconds((double)chunkSize / (result.SampleRate * result.Channels * (result.BitDepth / 8)));
                        fs.Seek(chunkSize, SeekOrigin.Current); // Skip data
                    }
                    else
                    {
                        fs.Seek(chunkSize, SeekOrigin.Current); // Skip other chunks
                    }
                }

                if (!foundFmt)
                {
                    result.Errors.Add("No format chunk found");
                }

                if (!foundData)
                {
                    result.Errors.Add("No data chunk found");
                }

                // Check sample rate
                var validSampleRates = new[] { 8000, 16000, 24000, 48000 };
                if (!Array.Exists(validSampleRates, sr => sr == result.SampleRate))
                {
                    result.Warnings.Add($"Unusual sample rate: {result.SampleRate}Hz");
                }

                // Check duration
                if (result.Duration.TotalSeconds < 0.1)
                {
                    result.Warnings.Add($"Very short audio: {result.Duration.TotalMilliseconds}ms");
                }
                else if (result.Duration.TotalMinutes > 5)
                {
                    result.Warnings.Add($"Very long audio: {result.Duration.TotalMinutes} minutes");
                }

                result.IsValid = result.Errors.Count == 0;
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Failed to read audio: {ex.Message}");
                result.IsValid = false;
            }

            return result;
        }

        /// <summary>
        /// Creates test data directory structure if it doesn't exist
        /// </summary>
        public static void EnsureTestDataDirectoryStructure(string testAudioPath)
        {
            var directories = new[]
            {
                "Basic",
                "Questions",
                "WithIssues",
                "Formats",
                "Languages",
                "LongForm",
                "Commands",
                "Mixed",
                "Noise",
                "Tones"
            };

            foreach (var dir in directories)
            {
                Directory.CreateDirectory(Path.Combine(testAudioPath, dir));
            }
        }

        /// <summary>
        /// Validation result for audio file checks
        /// </summary>
        public class ValidationResult
        {
            public string FilePath { get; set; } = string.Empty;
            public bool IsValid { get; set; }
            public List<string> Errors { get; } = new List<string>();
            public List<string> Warnings { get; } = new List<string>();
            public TimeSpan Duration { get; set; }
            public int SampleRate { get; set; }
            public int Channels { get; set; }
            public int BitDepth { get; set; }

            public override string ToString()
            {
                return $"{Path.GetFileName(FilePath)}: {(IsValid ? "Valid" : "Invalid")} - {SampleRate}Hz, {Channels}ch, {BitDepth}bit, {Duration.TotalSeconds:F1}s";
            }
        }
    }
}

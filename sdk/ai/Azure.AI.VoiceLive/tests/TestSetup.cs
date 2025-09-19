// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.IO;

namespace Azure.AI.VoiceLive.Tests
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void SetupOnce()
        {
            // Ensure test audio directories exist
            string testAudioPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Audio");
            TestDataValidator.EnsureTestDataDirectoryStructure(testAudioPath);

            // Generate basic test tones if needed
            GeneratePlaceholderTestAudio(testAudioPath);

            // Validate required test files
            TestDataValidator.ValidateRequiredTestFiles(testAudioPath);

            TestContext.WriteLine($"Test environment setup complete. Audio path: {testAudioPath}");
        }

        /// <summary>
        /// Generates minimal test audio files for testing if they don't exist
        /// </summary>
        private void GeneratePlaceholderTestAudio(string testAudioPath)
        {
            // Generate basic tone files
            GenerateToneIfMissing(Path.Combine(testAudioPath, "Tones", "1khz_sine.wav"), 1000);
            GenerateToneIfMissing(Path.Combine(testAudioPath, "Tones", "440hz_sine.wav"), 440);

            // Generate simulated speech patterns
            GenerateSpeechPatternIfMissing(
                Path.Combine(testAudioPath, "Basic", "synthetic_hello.wav"),
                TimeSpan.FromSeconds(1));

            GenerateSpeechPatternIfMissing(
                Path.Combine(testAudioPath, "Questions", "synthetic_question.wav"),
                TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Generates a tone file if it doesn't exist
        /// </summary>
        private void GenerateToneIfMissing(string filePath, double frequency)
        {
            if (!File.Exists(filePath))
            {
                TestContext.WriteLine($"Generating tone file: {filePath}");

                var toneData = TestAudioGenerator.GenerateTone(
                    frequency,
                    TimeSpan.FromSeconds(2));

                var wavData = TestAudioGenerator.WrapInWavHeader(toneData);
                File.WriteAllBytes(filePath, wavData);
            }
        }

        /// <summary>
        /// Generates a simulated speech pattern if file doesn't exist
        /// </summary>
        private void GenerateSpeechPatternIfMissing(string filePath, TimeSpan duration)
        {
            if (!File.Exists(filePath))
            {
                TestContext.WriteLine($"Generating speech pattern file: {filePath}");
                /*
                var audioData = TestAudioGenerator.GenerateMockAudioResponse(
                    (int)duration.TotalMilliseconds);

                var wavData = TestAudioGenerator.WrapInWavHeader(audioData);
                File.WriteAllBytes(filePath, wavData);
                */
            }
        }
    }
}

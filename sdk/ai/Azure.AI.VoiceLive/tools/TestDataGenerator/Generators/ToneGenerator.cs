// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Azure.AI.VoiceLive.TestDataGenerator.Models;

namespace Azure.AI.VoiceLive.TestDataGenerator.Generators
{
    /// <summary>
    /// Generates tone-based test audio files without external dependencies.
    /// </summary>
    public class ToneGenerator : ITestDataGenerator
    {
        private readonly ILogger _logger;

        public TestDataCategory Category => TestDataCategory.Tones;

        public ToneGenerator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task GenerateAsync(string outputPath, TestPhrases phrases)
        {
            var tonesPath = Path.Combine(outputPath, "Tones");
            Directory.CreateDirectory(tonesPath);

            // Generate standard test tones
            var tones = new[]
            {
                (440.0, "A4", TimeSpan.FromSeconds(1)),      // Standard A note
                (880.0, "A5", TimeSpan.FromSeconds(1)),      // Higher A note  
                (220.0, "A3", TimeSpan.FromSeconds(1)),      // Lower A note
                (1000.0, "1kHz", TimeSpan.FromSeconds(2)),   // 1kHz test tone
                (2000.0, "2kHz", TimeSpan.FromSeconds(1)),   // 2kHz test tone
                (500.0, "500Hz", TimeSpan.FromSeconds(3)),   // Low frequency
            };

            foreach (var (frequency, name, duration) in tones)
            {
                var fileName = $"tone_{name}_{duration.TotalSeconds}s.wav";
                var filePath = Path.Combine(tonesPath, fileName);
                
                var audioData = GenerateTone(frequency, duration);
                var wavData = CreateWavFile(audioData, 24000, 1);
                
                await File.WriteAllBytesAsync(filePath, wavData);
                _logger.LogDebug($"Generated tone: {filePath}");
            }

            // Generate silence files
            var silenceDurations = new[] { 0.5, 1.0, 2.0, 5.0 };
            foreach (var duration in silenceDurations)
            {
                var fileName = $"silence_{duration}s.wav";
                var filePath = Path.Combine(tonesPath, fileName);
                
                var audioData = GenerateSilence(TimeSpan.FromSeconds(duration));
                var wavData = CreateWavFile(audioData, 24000, 1);
                
                await File.WriteAllBytesAsync(filePath, wavData);
                _logger.LogDebug($"Generated silence: {filePath}");
            }

            _logger.LogInformation($"Generated {tones.Length + silenceDurations.Length} tone/silence files");
        }

        public void PreviewGeneration(string outputPath, TestPhrases phrases)
        {
            _logger.LogInformation("Tone Generation Preview:");
            _logger.LogInformation("  Would generate tone files: A4, A5, A3, 1kHz, 2kHz, 500Hz");
            _logger.LogInformation("  Would generate silence files: 0.5s, 1s, 2s, 5s");
        }

        private byte[] GenerateTone(double frequencyHz, TimeSpan duration, int sampleRate = 24000, double amplitude = 0.5)
        {
            int samples = (int)(duration.TotalSeconds * sampleRate);
            var buffer = new byte[samples * 2]; // 16-bit PCM

            for (int i = 0; i < samples; i++)
            {
                double angle = 2 * Math.PI * frequencyHz * i / sampleRate;
                short value = (short)(Math.Sin(angle) * short.MaxValue * amplitude);

                // Little-endian byte order
                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
        }

        private byte[] GenerateSilence(TimeSpan duration, int sampleRate = 24000)
        {
            int totalSamples = (int)(duration.TotalSeconds * sampleRate);
            return new byte[totalSamples * 2]; // 16-bit PCM = 2 bytes per sample
        }

        private byte[] CreateWavFile(byte[] pcmData, int sampleRate = 24000, int channels = 1)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);

            // WAV header
            writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(36 + pcmData.Length);
            writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));
            writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));
            writer.Write(16); // fmt chunk size
            writer.Write((short)1); // PCM format
            writer.Write((short)channels);
            writer.Write(sampleRate);
            writer.Write(sampleRate * channels * 2); // byte rate
            writer.Write((short)(channels * 2)); // block align
            writer.Write((short)16); // bits per sample
            writer.Write(System.Text.Encoding.ASCII.GetBytes("data"));
            writer.Write(pcmData.Length);
            writer.Write(pcmData);

            return ms.ToArray();
        }
    }
}
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
    /// Generates noise-based test audio files for testing audio processing robustness.
    /// </summary>
    public class NoiseGenerator : ITestDataGenerator
    {
        private readonly ILogger _logger;
        private readonly Random _random = new();

        public TestDataCategory Category => TestDataCategory.Noise;

        public NoiseGenerator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task GenerateAsync(string outputPath, TestPhrases phrases)
        {
            var noisePath = Path.Combine(outputPath, "Noise");
            Directory.CreateDirectory(noisePath);

            // Generate different types of noise
            await GenerateWhiteNoise(noisePath);
            await GeneratePinkNoise(noisePath);
            await GenerateBrownNoise(noisePath);

            _logger.LogInformation("Generated noise test files");
        }

        public void PreviewGeneration(string outputPath, TestPhrases phrases)
        {
            _logger.LogInformation("Noise Generation Preview:");
            _logger.LogInformation("  Would generate white noise files at various levels");
            _logger.LogInformation("  Would generate pink noise files");
            _logger.LogInformation("  Would generate brown noise files");
        }

        private async Task GenerateWhiteNoise(string outputPath)
        {
            var levels = new[] { 0.1, 0.3, 0.5 }; // Different noise levels
            var durations = new[] { 1.0, 3.0, 5.0 }; // Different durations

            foreach (var level in levels)
            {
                foreach (var duration in durations)
                {
                    var fileName = $"white_noise_{level:F1}_{duration}s.wav";
                    var filePath = Path.Combine(outputPath, fileName);
                    
                    var audioData = GenerateWhiteNoise(TimeSpan.FromSeconds(duration), level);
                    var wavData = CreateWavFile(audioData);
                    
                    await File.WriteAllBytesAsync(filePath, wavData);
                    _logger.LogDebug($"Generated: {filePath}");
                }
            }
        }

        private async Task GeneratePinkNoise(string outputPath)
        {
            var fileName = "pink_noise_3s.wav";
            var filePath = Path.Combine(outputPath, fileName);
            
            var audioData = GeneratePinkNoise(TimeSpan.FromSeconds(3), 0.3);
            var wavData = CreateWavFile(audioData);
            
            await File.WriteAllBytesAsync(filePath, wavData);
            _logger.LogDebug($"Generated: {filePath}");
        }

        private async Task GenerateBrownNoise(string outputPath)
        {
            var fileName = "brown_noise_3s.wav";
            var filePath = Path.Combine(outputPath, fileName);
            
            var audioData = GenerateBrownNoise(TimeSpan.FromSeconds(3), 0.3);
            var wavData = CreateWavFile(audioData);
            
            await File.WriteAllBytesAsync(filePath, wavData);
            _logger.LogDebug($"Generated: {filePath}");
        }

        private byte[] GenerateWhiteNoise(TimeSpan duration, double amplitude = 0.1, int sampleRate = 24000)
        {
            int samples = (int)(duration.TotalSeconds * sampleRate);
            var buffer = new byte[samples * 2];

            for (int i = 0; i < samples; i++)
            {
                // Random value between -1 and 1
                double noise = (_random.NextDouble() * 2 - 1) * amplitude;
                short value = (short)(noise * short.MaxValue);

                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
        }

        private byte[] GeneratePinkNoise(TimeSpan duration, double amplitude = 0.1, int sampleRate = 24000)
        {
            int samples = (int)(duration.TotalSeconds * sampleRate);
            var buffer = new byte[samples * 2];

            // Pink noise generator state
            double[] state = new double[7];

            for (int i = 0; i < samples; i++)
            {
                double white = _random.NextDouble() * 2 - 1;
                
                // Simple pink noise filter approximation
                state[0] = 0.99886 * state[0] + white * 0.0555179;
                state[1] = 0.99332 * state[1] + white * 0.0750759;
                state[2] = 0.96900 * state[2] + white * 0.1538520;
                state[3] = 0.86650 * state[3] + white * 0.3104856;
                state[4] = 0.55000 * state[4] + white * 0.5329522;
                state[5] = -0.7616 * state[5] - white * 0.0168980;
                
                double pink = (state[0] + state[1] + state[2] + state[3] + state[4] + state[5] + state[6] + white * 0.5362) * amplitude;
                state[6] = white * 0.115926;
                
                short value = (short)(Math.Max(-1, Math.Min(1, pink)) * short.MaxValue);

                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
        }

        private byte[] GenerateBrownNoise(TimeSpan duration, double amplitude = 0.1, int sampleRate = 24000)
        {
            int samples = (int)(duration.TotalSeconds * sampleRate);
            var buffer = new byte[samples * 2];

            double lastOutput = 0;

            for (int i = 0; i < samples; i++)
            {
                double white = (_random.NextDouble() * 2 - 1) * amplitude;
                double brown = (lastOutput + (0.02 * white)) / 1.02;
                lastOutput = brown;
                
                short value = (short)(brown * short.MaxValue);

                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
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
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
    /// Converts existing audio files to different formats for testing format compatibility.
    /// </summary>
    public class FormatConverter : ITestDataGenerator
    {
        private readonly ILogger _logger;

        public TestDataCategory Category => TestDataCategory.Formats;

        public FormatConverter(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task GenerateAsync(string outputPath, TestPhrases phrases)
        {
            var formatsPath = Path.Combine(outputPath, "Formats");
            Directory.CreateDirectory(formatsPath);

            // Find a basic audio file to convert
            var basicPath = Path.Combine(outputPath, "Basic");
            if (Directory.Exists(basicPath))
            {
                var sourceFiles = Directory.GetFiles(basicPath, "*.wav");
                if (sourceFiles.Length > 0)
                {
                    var sourceFile = sourceFiles[0];
                    await ConvertToFormats(sourceFile, formatsPath);
                }
                else
                {
                    _logger.LogWarning("No source audio files found for format conversion");
                    await GenerateFormatSamples(formatsPath);
                }
            }
            else
            {
                await GenerateFormatSamples(formatsPath);
            }

            _logger.LogInformation("Generated format test files");
        }

        public void PreviewGeneration(string outputPath, TestPhrases phrases)
        {
            _logger.LogInformation("Format Conversion Preview:");
            _logger.LogInformation("  Would generate files in multiple sample rates: 8kHz, 16kHz, 24kHz, 48kHz");
            _logger.LogInformation("  Would generate G.711 µ-law and A-law samples");
            _logger.LogInformation("  Would generate mono and stereo variants");
        }

        private async Task ConvertToFormats(string sourceFile, string outputPath)
        {
            _logger.LogInformation($"Converting {sourceFile} to multiple formats");

            var sourceData = await File.ReadAllBytesAsync(sourceFile);
            var sourceName = Path.GetFileNameWithoutExtension(sourceFile);

            // Extract PCM data from WAV file (skip header)
            var pcmData = ExtractPcmFromWav(sourceData);

            // Convert to different sample rates
            var sampleRates = new[] { 8000, 16000, 24000, 48000 };
            foreach (var sampleRate in sampleRates)
            {
                var fileName = $"{sourceName}_pcm16_{sampleRate}hz.wav";
                var filePath = Path.Combine(outputPath, fileName);

                var resampledData = ResampleAudio(pcmData, 24000, sampleRate);
                var wavData = CreateWavFile(resampledData, sampleRate, 1);

                await File.WriteAllBytesAsync(filePath, wavData);
                _logger.LogDebug($"Generated: {filePath}");
            }

            // Convert to G.711 formats (8kHz only)
            var pcm8k = ResampleAudio(pcmData, 24000, 8000);

            var ulawData = ConvertToULaw(pcm8k);
            var ulawFile = Path.Combine(outputPath, $"{sourceName}_g711_ulaw.wav");
            await File.WriteAllBytesAsync(ulawFile, CreateG711WavFile(ulawData, 8000, false));

            var alawData = ConvertToALaw(pcm8k);
            var alawFile = Path.Combine(outputPath, $"{sourceName}_g711_alaw.wav");
            await File.WriteAllBytesAsync(alawFile, CreateG711WavFile(alawData, 8000, true));
        }

        private async Task GenerateFormatSamples(string outputPath)
        {
            // Generate a simple tone for format testing
            var toneData = GenerateTone(440, TimeSpan.FromSeconds(2));

            var sampleRates = new[] { 8000, 16000, 24000, 48000 };
            foreach (var sampleRate in sampleRates)
            {
                var fileName = $"test_tone_pcm16_{sampleRate}hz.wav";
                var filePath = Path.Combine(outputPath, fileName);

                var resampledData = ResampleAudio(toneData, 24000, sampleRate);
                var wavData = CreateWavFile(resampledData, sampleRate, 1);

                await File.WriteAllBytesAsync(filePath, wavData);
                _logger.LogDebug($"Generated: {filePath}");
            }
        }

        private byte[] ExtractPcmFromWav(byte[] wavData)
        {
            // Simple WAV header parser - assumes standard 44-byte header
            if (wavData.Length < 44)
                return Array.Empty<byte>();

            var dataChunkSize = BitConverter.ToInt32(wavData, 40);
            var pcmData = new byte[dataChunkSize];
            Array.Copy(wavData, 44, pcmData, 0, Math.Min(dataChunkSize, wavData.Length - 44));

            return pcmData;
        }

        private byte[] ResampleAudio(byte[] pcm16, int fromSampleRate, int toSampleRate)
        {
            if (fromSampleRate == toSampleRate)
                return pcm16;

            double ratio = (double)toSampleRate / fromSampleRate;
            int inputSamples = pcm16.Length / 2;
            int outputSamples = (int)(inputSamples * ratio);
            var output = new byte[outputSamples * 2];

            for (int i = 0; i < outputSamples; i++)
            {
                double sourceIndex = i / ratio;
                int sourceIndexInt = (int)sourceIndex;

                if (sourceIndexInt < inputSamples - 1)
                {
                    // Linear interpolation
                    short sample1 = (short)(pcm16[sourceIndexInt * 2] | (pcm16[sourceIndexInt * 2 + 1] << 8));
                    short sample2 = (short)(pcm16[(sourceIndexInt + 1) * 2] | (pcm16[(sourceIndexInt + 1) * 2 + 1] << 8));

                    double fraction = sourceIndex - sourceIndexInt;
                    short interpolated = (short)(sample1 + (sample2 - sample1) * fraction);

                    output[i * 2] = (byte)(interpolated & 0xFF);
                    output[i * 2 + 1] = (byte)((interpolated >> 8) & 0xFF);
                }
                else if (sourceIndexInt < inputSamples)
                {
                    output[i * 2] = pcm16[sourceIndexInt * 2];
                    output[i * 2 + 1] = pcm16[sourceIndexInt * 2 + 1];
                }
            }

            return output;
        }

        private byte[] ConvertToULaw(byte[] pcm16)
        {
            var output = new byte[pcm16.Length / 2];

            for (int i = 0; i < pcm16.Length; i += 2)
            {
                short sample = (short)(pcm16[i] | (pcm16[i + 1] << 8));
                output[i / 2] = LinearToMuLawSample(sample);
            }

            return output;
        }

        private byte[] ConvertToALaw(byte[] pcm16)
        {
            var output = new byte[pcm16.Length / 2];

            for (int i = 0; i < pcm16.Length; i += 2)
            {
                short sample = (short)(pcm16[i] | (pcm16[i + 1] << 8));
                output[i / 2] = LinearToALawSample(sample);
            }

            return output;
        }

        private byte[] GenerateTone(double frequencyHz, TimeSpan duration, int sampleRate = 24000)
        {
            int samples = (int)(duration.TotalSeconds * sampleRate);
            var buffer = new byte[samples * 2];

            for (int i = 0; i < samples; i++)
            {
                double angle = 2 * Math.PI * frequencyHz * i / sampleRate;
                short value = (short)(Math.Sin(angle) * short.MaxValue * 0.5);

                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
        }

        private byte[] CreateWavFile(byte[] pcmData, int sampleRate = 24000, int channels = 1)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);

            writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(36 + pcmData.Length);
            writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));
            writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));
            writer.Write(16);
            writer.Write((short)1);
            writer.Write((short)channels);
            writer.Write(sampleRate);
            writer.Write(sampleRate * channels * 2);
            writer.Write((short)(channels * 2));
            writer.Write((short)16);
            writer.Write(System.Text.Encoding.ASCII.GetBytes("data"));
            writer.Write(pcmData.Length);
            writer.Write(pcmData);

            return ms.ToArray();
        }

        private byte[] CreateG711WavFile(byte[] g711Data, int sampleRate, bool isALaw)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);

            writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(50 + g711Data.Length);
            writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));
            writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));
            writer.Write(20); // Extended format chunk
            writer.Write((short)(isALaw ? 6 : 7)); // A-law = 6, µ-law = 7
            writer.Write((short)1); // channels
            writer.Write(sampleRate);
            writer.Write(sampleRate); // byte rate for G.711
            writer.Write((short)1); // block align
            writer.Write((short)8); // bits per sample
            writer.Write((short)0); // extension size
            writer.Write(System.Text.Encoding.ASCII.GetBytes("fact"));
            writer.Write(4);
            writer.Write(g711Data.Length); // sample count
            writer.Write(System.Text.Encoding.ASCII.GetBytes("data"));
            writer.Write(g711Data.Length);
            writer.Write(g711Data);

            return ms.ToArray();
        }

        // G.711 µ-law encoding
        private byte LinearToMuLawSample(short sample)
        {
            const int BIAS = 0x84;
            const int CLIP = 8159;

            int sign = (sample >> 8) & 0x80;
            if (sign != 0)
                sample = (short)-sample;
            if (sample > CLIP)
                sample = CLIP;

            sample = (short)(sample + BIAS);
            int exponent = 7;
            for (int expMask = 0x4000; (sample & expMask) == 0 && exponent > 0; exponent--, expMask >>= 1)
            { }

            int mantissa = (sample >> (exponent + 3)) & 0x0F;
            int ulawValue = ~(sign | (exponent << 4) | mantissa);

            return (byte)(ulawValue & 0xFF);
        }

        // G.711 A-law encoding  
        private byte LinearToALawSample(short sample)
        {
            const int ALAW_MAX = 0xFFF;
            int sign = ((~sample) >> 8) & 0x80;
            if (sign == 0)
                sample = (short)-sample;
            if (sample > ALAW_MAX)
                sample = ALAW_MAX;

            int exponent = 7;
            for (int expMask = 0x4000; (sample & expMask) == 0 && exponent > 0; exponent--, expMask >>= 1)
            { }

            int mantissa = (sample >> (exponent + 3)) & 0x0F;
            int alawValue = (exponent << 4) | mantissa;

            return (byte)((alawValue ^ 0x55) | sign);
        }
    }
}

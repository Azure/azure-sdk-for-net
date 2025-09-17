// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Utilities for generating test audio programmatically.
    /// </summary>
    public static class TestAudioGenerator
    {
        /// <summary>
        /// Generate silence of specified duration.
        /// </summary>
        public static byte[] GenerateSilence(
            TimeSpan duration,
            int sampleRate = 24000,
            int channels = 1)
        {
            int totalSamples = (int)(duration.TotalSeconds * sampleRate * channels);
            return new byte[totalSamples * 2]; // 16-bit PCM = 2 bytes per sample
        }

        /// <summary>
        /// Generate a pure tone for testing.
        /// </summary>
        public static byte[] GenerateTone(
            double frequencyHz,
            TimeSpan duration,
            int sampleRate = 24000,
            double amplitude = 0.5)
        {
            if (amplitude < 0 || amplitude > 1)
                throw new ArgumentException("Amplitude must be between 0 and 1");

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

        /// <summary>
        /// Generate white noise for testing noise suppression.
        /// </summary>
        public static byte[] GenerateWhiteNoise(
            TimeSpan duration,
            int sampleRate = 24000,
            double amplitude = 0.1)
        {
            var random = new Random();
            int samples = (int)(duration.TotalSeconds * sampleRate);
            var buffer = new byte[samples * 2];

            for (int i = 0; i < samples; i++)
            {
                // Random value between -1 and 1
                double noise = (random.NextDouble() * 2 - 1) * amplitude;
                short value = (short)(noise * short.MaxValue);

                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
        }

        /// <summary>
        /// Mix audio with background noise.
        /// </summary>
        public static byte[] AddBackgroundNoise(
            byte[] cleanAudio,
            double noiseLevel = 0.1)
        {
            var noise = GenerateWhiteNoise(
                TimeSpan.FromMilliseconds(cleanAudio.Length / 2 / 24.0), // Assuming 24kHz mono
                24000,
                noiseLevel);

            var mixed = new byte[cleanAudio.Length];

            for (int i = 0; i < cleanAudio.Length; i += 2)
            {
                // Convert bytes to short
                short cleanSample = (short)(cleanAudio[i] | (cleanAudio[i + 1] << 8));
                short noiseSample = 0;

                if (i < noise.Length)
                {
                    noiseSample = (short)(noise[i] | (noise[i + 1] << 8));
                }

                // Mix samples
                int mixedSample = cleanSample + noiseSample;

                // Clamp to short range
                if (mixedSample > short.MaxValue)
                    mixedSample = short.MaxValue;
                if (mixedSample < short.MinValue)
                    mixedSample = short.MinValue;

                // Convert back to bytes
                mixed[i] = (byte)(mixedSample & 0xFF);
                mixed[i + 1] = (byte)((mixedSample >> 8) & 0xFF);
            }

            return mixed;
        }

        /// <summary>
        /// Creates a wave file header for PCM16 data.
        /// </summary>
        private static byte[] CreateWaveHeader(int dataSize, int sampleRate, int channels)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);

            // RIFF header
            writer.Write(new char[] { 'R', 'I', 'F', 'F' });
            writer.Write(36 + dataSize); // 36 + subchunk2size
            writer.Write(new char[] { 'W', 'A', 'V', 'E' });

            // Format subchunk
            writer.Write(new char[] { 'f', 'm', 't', ' ' });
            writer.Write(16); // Subchunk1Size (16 for PCM)
            writer.Write((short)1); // AudioFormat (1 for PCM)
            writer.Write((short)channels); // NumChannels
            writer.Write(sampleRate); // SampleRate
            writer.Write(sampleRate * channels * 2); // ByteRate
            writer.Write((short)(channels * 2)); // BlockAlign
            writer.Write((short)16); // BitsPerSample

            // Data subchunk
            writer.Write(new char[] { 'd', 'a', 't', 'a' });
            writer.Write(dataSize);

            return ms.ToArray();
        }

        /// <summary>
        /// Wraps PCM16 data with WAV header.
        /// </summary>
        public static byte[] WrapInWavHeader(byte[] pcmData, int sampleRate = 24000, int channels = 1)
        {
            var header = CreateWaveHeader(pcmData.Length, sampleRate, channels);
            var result = new byte[header.Length + pcmData.Length];

            Array.Copy(header, 0, result, 0, header.Length);
            Array.Copy(pcmData, 0, result, header.Length, pcmData.Length);

            return result;
        }

        /// <summary>
        /// Saves PCM16 data as a WAV file.
        /// </summary>
        public static void SaveAsWav(byte[] pcmData, string filePath, int sampleRate = 24000, int channels = 1)
        {
            var wavData = WrapInWavHeader(pcmData, sampleRate, channels);
            File.WriteAllBytes(filePath, wavData);
        }

        /// <summary>
        /// Converts between audio formats (simplified implementation).
        /// </summary>
        public static byte[] ConvertAudioFormat(
            byte[] pcm16Audio,
            string targetFormat,
            int sampleRate = 8000)
        {
            switch (targetFormat.ToLower())
            {
                case "g711_ulaw":
                case "ulaw":
                    return ConvertToULaw(pcm16Audio);

                case "g711_alaw":
                case "alaw":
                    return ConvertToALaw(pcm16Audio);

                case "pcm16":
                    return pcm16Audio;

                default:
                    throw new NotSupportedException($"Format {targetFormat} not supported");
            }
        }

        // Simple implementation of µ-law encoding
        private static byte[] ConvertToULaw(byte[] pcm16)
        {
            var output = new byte[pcm16.Length / 2];

            for (int i = 0; i < pcm16.Length; i += 2)
            {
                short sample = (short)(pcm16[i] | (pcm16[i + 1] << 8));
                output[i / 2] = LinearToMuLaw(sample);
            }

            return output;
        }

        // Simple implementation of A-law encoding
        private static byte[] ConvertToALaw(byte[] pcm16)
        {
            var output = new byte[pcm16.Length / 2];

            for (int i = 0; i < pcm16.Length; i += 2)
            {
                short sample = (short)(pcm16[i] | (pcm16[i + 1] << 8));
                output[i / 2] = LinearToALaw(sample);
            }

            return output;
        }

        // Basic µ-law conversion (simplified)
        private static byte LinearToMuLaw(short pcm)
        {
            int sign = (pcm < 0) ? 0x80 : 0x00;
            if (pcm < 0)
                pcm = (short)-pcm;

            pcm += 132;

            byte exponent = 0;
            for (int i = 14; i >= 6; i--)
            {
                if ((pcm & (1 << i)) != 0)
                {
                    exponent = (byte)(i - 6);
                    break;
                }
            }

            byte mantissa = (byte)((pcm >> (exponent + 3)) & 0x0F);
            byte mulaw = (byte)(~(sign | (exponent << 4) | mantissa));

            return mulaw;
        }

        // Basic A-law conversion (simplified)
        private static byte LinearToALaw(short pcm)
        {
            int sign = (pcm < 0) ? 0x80 : 0x00;
            if (pcm < 0)
                pcm = (short)-pcm;

            int exponent = 0;
            for (int i = 11; i >= 5; i--)
            {
                if ((pcm & (1 << i)) != 0)
                {
                    exponent = i - 4;
                    break;
                }
            }

            int mantissa = (pcm >> (exponent + 1)) & 0x0F;
            byte alaw = (byte)(sign | (exponent << 4) | mantissa);

            return (byte)~alaw;
        }
    }
}

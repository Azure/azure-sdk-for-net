// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Logging;
using Azure.AI.VoiceLive.TestDataGenerator.Models;

namespace Azure.AI.VoiceLive.TestDataGenerator.Generators
{
    /// <summary>
    /// Generates speech audio files using Azure Cognitive Services Speech SDK.
    /// </summary>
    public class SpeechAudioGenerator : ITestDataGenerator
    {
        private readonly AzureSpeechConfig _config;
        private readonly ILogger _logger;

        public TestDataCategory Category => TestDataCategory.Speech;

        public SpeechAudioGenerator(AzureSpeechConfig config, ILogger logger)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task GenerateAsync(string outputPath, TestPhrases phrases)
        {
            if (string.IsNullOrEmpty(_config.SubscriptionKey) || string.IsNullOrEmpty(_config.Region))
            {
                _logger.LogWarning("Azure Speech configuration missing. Skipping speech generation.");
                return;
            }

            var speechConfig = SpeechConfig.FromSubscription(_config.SubscriptionKey, _config.Region);
            speechConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Riff24Khz16BitMonoPcm);

            // Generate basic phrases
            await GenerateCategoryAsync(speechConfig, outputPath, "Basic", phrases.GetCategory("Basic"));

            // Generate questions
            await GenerateCategoryAsync(speechConfig, outputPath, "Questions", phrases.GetCategory("Questions"));

            // Generate commands
            await GenerateCategoryAsync(speechConfig, outputPath, "Commands", phrases.GetCategory("Commands"));

            // Generate multi-language samples
            await GenerateMultiLanguageAsync(speechConfig, outputPath, phrases.GetCategory("MultiLanguage"));
        }

        public void PreviewGeneration(string outputPath, TestPhrases phrases)
        {
            _logger.LogInformation("Speech Audio Generation Preview:");

            foreach (var category in new[] { "Basic", "Questions", "Commands", "MultiLanguage" })
            {
                var categoryPhrases = phrases.GetCategory(category);
                foreach (var phrase in categoryPhrases)
                {
                    var fileName = $"{phrase.Id}.wav";
                    var filePath = Path.Combine(outputPath, category, fileName);
                    _logger.LogInformation($"  Would generate: {filePath}");
                }
            }
        }

        private async Task GenerateCategoryAsync(SpeechConfig speechConfig, string outputPath, string category, IEnumerable<TestPhrase> phrases)
        {
            var categoryPath = Path.Combine(outputPath, category);
            Directory.CreateDirectory(categoryPath);

            foreach (var phrase in phrases)
            {
                try
                {
                    await GenerateSpeechAsync(speechConfig, categoryPath, phrase);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to generate speech for phrase: {phrase.Id}");
                }
            }
        }

        private async Task GenerateMultiLanguageAsync(SpeechConfig speechConfig, string outputPath, IEnumerable<TestPhrase> phrases)
        {
            var languagesPath = Path.Combine(outputPath, "Languages");
            Directory.CreateDirectory(languagesPath);

            foreach (var phrase in phrases)
            {
                if (phrase.Languages != null)
                {
                    foreach (var language in phrase.Languages)
                    {
                        try
                        {
                            var voice = GetVoiceForLanguage(language);
                            if (!string.IsNullOrEmpty(voice))
                            {
                                speechConfig.SpeechSynthesisVoiceName = voice;
                                var fileName = $"{phrase.Id}_{language.Replace("-", "_")}.wav";
                                var filePath = Path.Combine(languagesPath, fileName);

                                await GenerateSpeechFileAsync(speechConfig, phrase.Text, filePath);
                                _logger.LogDebug($"Generated: {filePath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"Failed to generate speech for phrase: {phrase.Id}, language: {language}");
                        }
                    }
                }
            }
        }

        private async Task GenerateSpeechAsync(SpeechConfig speechConfig, string outputPath, TestPhrase phrase)
        {
            var fileName = $"{phrase.Id}.wav";
            var filePath = Path.Combine(outputPath, fileName);

            // Use default voice or first configured voice
            if (_config.Voices.Count > 0)
            {
                speechConfig.SpeechSynthesisVoiceName = _config.Voices[0];
            }

            await GenerateSpeechFileAsync(speechConfig, phrase.Text, filePath);
            _logger.LogDebug($"Generated: {filePath}");
        }

        private async Task GenerateSpeechFileAsync(SpeechConfig speechConfig, string text, string outputFile)
        {
            using var audioConfig = AudioConfig.FromWavFileOutput(outputFile);
            using var synthesizer = new SpeechSynthesizer(speechConfig, audioConfig);

            var result = await synthesizer.SpeakTextAsync(text);

            if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                throw new InvalidOperationException($"Speech synthesis canceled: {cancellation.Reason}, {cancellation.ErrorDetails}");
            }
        }

        private string GetVoiceForLanguage(string language)
        {
            // Map common language codes to voices
            return language.ToLower() switch
            {
                "en-us" => "en-US-AriaNeural",
                "en-gb" => "en-GB-SoniaNeural",
                "es-es" => "es-ES-ElviraNeural",
                "fr-fr" => "fr-FR-DeniseNeural",
                "de-de" => "de-DE-KatjaNeural",
                "ja-jp" => "ja-JP-NanamiNeural",
                "zh-cn" => "zh-CN-XiaoxiaoNeural",
                _ => "en-US-AriaNeural" // Default fallback
            };
        }
    }
}

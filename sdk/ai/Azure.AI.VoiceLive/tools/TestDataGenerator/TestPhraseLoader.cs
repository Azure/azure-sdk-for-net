// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.AI.VoiceLive.TestDataGenerator.Models;

namespace Azure.AI.VoiceLive.TestDataGenerator
{
    /// <summary>
    /// Utility for loading test phrases from JSON configuration.
    /// </summary>
    public static class TestPhraseLoader
    {
        public static TestPhrases LoadPhrases(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Test phrases file not found: {filePath}");
            }

            var json = File.ReadAllText(filePath);
            var phrases = JsonSerializer.Deserialize<TestPhrases>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return phrases ?? new TestPhrases();
        }

        public static TestPhrases CreateDefaultPhrases()
        {
            return new TestPhrases
            {
                Categories = new()
                {
                    ["Basic"] = new()
                    {
                        new TestPhrase { Id = "hello", Text = "Hello", Description = "Simple greeting" },
                        new TestPhrase { Id = "hello_how_are_you", Text = "Hello, how are you?", Description = "Greeting with question" },
                        new TestPhrase { Id = "goodbye", Text = "Goodbye", Description = "Simple farewell" },
                        new TestPhrase { Id = "yes", Text = "Yes", Description = "Affirmative response" },
                        new TestPhrase { Id = "no", Text = "No", Description = "Negative response" },
                        new TestPhrase { Id = "stop", Text = "Stop", Description = "Stop command" },
                        new TestPhrase { Id = "please", Text = "Please", Description = "Polite request" },
                        new TestPhrase { Id = "thank_you", Text = "Thank you", Description = "Gratitude expression" }
                    },
                    ["Questions"] = new()
                    {
                        new TestPhrase { Id = "whats_weather_seattle", Text = "What's the weather in Seattle?", Description = "Weather inquiry" },
                        new TestPhrase { Id = "whats_largest_lake", Text = "What's the largest lake in the world?", Description = "Geography question" },
                        new TestPhrase { Id = "tell_me_story", Text = "Tell me a story about space exploration", Description = "Open-ended request" },
                        new TestPhrase { Id = "explain_quantum", Text = "Explain quantum computing", Description = "Technical explanation request" },
                        new TestPhrase { Id = "calculate_math", Text = "What's 25 times 4?", Description = "Math calculation" },
                        new TestPhrase { Id = "what_time_is_it", Text = "What time is it?", Description = "Time inquiry" }
                    },
                    ["Commands"] = new()
                    {
                        new TestPhrase { Id = "set_timer", Text = "Set a timer for 5 minutes", Description = "Timer command" },
                        new TestPhrase { Id = "play_music", Text = "Play some music", Description = "Music command" },
                        new TestPhrase { Id = "call_john", Text = "Call John", Description = "Phone command" },
                        new TestPhrase { Id = "send_message", Text = "Send a message to Sarah", Description = "Messaging command" },
                        new TestPhrase { Id = "navigate_home", Text = "Navigate to home", Description = "Navigation command" },
                        new TestPhrase { Id = "turn_off_lights", Text = "Turn off the lights", Description = "Smart home command" }
                    },
                    ["MultiLanguage"] = new()
                    {
                        new TestPhrase
                        {
                            Id = "hello_multilang",
                            Text = "Hello",
                            Description = "Greeting in multiple languages",
                            Languages = new() { "en-US", "en-GB", "es-ES", "fr-FR", "de-DE", "ja-JP", "zh-CN" }
                        },
                        new TestPhrase
                        {
                            Id = "thank_you_multilang",
                            Text = "Thank you",
                            Description = "Gratitude in multiple languages",
                            Languages = new() { "en-US", "es-ES", "fr-FR", "de-DE", "ja-JP" }
                        },
                        new TestPhrase
                        {
                            Id = "goodbye_multilang",
                            Text = "Goodbye",
                            Description = "Farewell in multiple languages",
                            Languages = new() { "en-US", "es-ES", "fr-FR", "de-DE" }
                        }
                    }
                }
            };
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.VoiceLive;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.VoiceLive.Samples.Snippets
{
    /// <summary>
    /// Code snippets demonstrating basic usage patterns for the VoiceLive API.
    /// </summary>
    public partial class BasicUsageSnippets
    {
        /// <summary>
        /// Demonstrates creating a basic voice assistant with the VoiceLive API.
        /// </summary>
        public async Task BasicVoiceAssistantExample()
        {
            #region Snippet:BasicVoiceAssistantExample
            // Create the VoiceLive client
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);

            // Start a new session
            VoiceLiveSession session = await client.StartSessionAsync().ConfigureAwait(false);

            // Configure session for voice conversation
            ConversationSessionOptions sessionOptions = new ConversationSessionOptions()
            {
                Model = "gpt-4o-mini-realtime-preview",
                Instructions = "You are a helpful AI assistant. Respond naturally and conversationally.",
                Voice = new AzureStandardVoice("en-US-AvaNeural", AzureStandardVoiceType.AzureStandard),
                TurnDetection = new ServerVad()
                {
                    Threshold = 0.5f,
                    PrefixPaddingMs = 300,
                    SilenceDurationMs = 500
                },
                InputAudioFormat = AudioFormat.Pcm16,
                OutputAudioFormat = AudioFormat.Pcm16
            };

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InputModality.Text);
            sessionOptions.Modalities.Add(InputModality.Audio);

            await session.ConfigureConversationSessionAsync(sessionOptions).ConfigureAwait(false);

            // Process events from the session
            await foreach (ServerEvent serverEvent in session.GetUpdatesAsync().ConfigureAwait(false))
            {
                if (serverEvent is ServerEventResponseAudioDelta audioDelta)
                {
                    // Play audio response
                    byte[] audioData = audioDelta.Delta.ToArray();
                    // ... audio playback logic
                }
                else if (serverEvent is ServerEventResponseTextDelta textDelta)
                {
                    // Display text response
                    Console.Write(textDelta.Delta);
                }
            }
            #endregion
        }

        /// <summary>
        /// Demonstrates advanced voice configuration with custom voices and enhanced features.
        /// </summary>
        public async Task AdvancedVoiceConfiguration()
        {
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
            VoiceLiveSession session = await client.StartSessionAsync().ConfigureAwait(false);

            #region Snippet:AdvancedVoiceConfiguration
            ConversationSessionOptions sessionOptions = new ConversationSessionOptions()
            {
                Model = "gpt-4o-realtime-preview",
                Instructions = "You are a customer service representative. Be helpful and professional.",
                Voice = new AzureCustomVoice("your-custom-voice-name", "your-custom-voice-endpoint-id", AzureCustomVoiceType.AzureCustom)
                {
                    Temperature = 0.8f
                },
                TurnDetection = new AzureSemanticVad()
                {
                    NegThreshold = 0.3f,
                    WindowSize = 300,
                    RemoveFillerWords = true
                },
                InputAudioFormat = AudioFormat.Pcm16,
                OutputAudioFormat = AudioFormat.Pcm16
            };

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InputModality.Text);
            sessionOptions.Modalities.Add(InputModality.Audio);

            await session.ConfigureConversationSessionAsync(sessionOptions).ConfigureAwait(false);
            #endregion
        }

        /// <summary>
        /// Demonstrates function calling capabilities.
        /// </summary>
        public async Task FunctionCallingExample()
        {
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
            VoiceLiveSession session = await client.StartSessionAsync().ConfigureAwait(false);

            #region Snippet:FunctionCallingExample
            // Define a function for the assistant to call
            var getCurrentWeatherFunction = new FunctionTool("get_current_weather")
            {
                Description = "Get the current weather for a given location",
                Parameters = BinaryData.FromString("""
                    {
                        "type": "object",
                        "properties": {
                            "location": {
                                "type": "string",
                                "description": "The city and state or country"
                            }
                        },
                        "required": ["location"]
                    }
                    """)
            };

            ConversationSessionOptions sessionOptions = new ConversationSessionOptions()
            {
                Model = "gpt-4o-mini-realtime-preview",
                Instructions = "You are a weather assistant. Use the get_current_weather function to help users with weather information.",
                Voice = new AzureStandardVoice("en-US-AvaNeural", AzureStandardVoiceType.AzureStandard),
                InputAudioFormat = AudioFormat.Pcm16,
                OutputAudioFormat = AudioFormat.Pcm16
            };

            // Add the function tool
            sessionOptions.Tools.Add(getCurrentWeatherFunction);

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InputModality.Text);
            sessionOptions.Modalities.Add(InputModality.Audio);

            await session.ConfigureConversationSessionAsync(sessionOptions).ConfigureAwait(false);
            #endregion
        }
    }
}

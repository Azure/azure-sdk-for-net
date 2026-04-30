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

            var model = "gpt-4o-mini-realtime-preview"; // Specify the model to use
            // Start a new session
            VoiceLiveSession session = await client.StartSessionAsync(model).ConfigureAwait(false);

            // Configure session for voice conversation
            VoiceLiveSessionOptions sessionOptions = new()
            {
                Model = model,
                Instructions = "You are a helpful AI assistant. Respond naturally and conversationally.",
                Voice = new AzureStandardVoice("en-US-AvaNeural"),
                TurnDetection = new AzureSemanticVadTurnDetection()
                {
                    Threshold = 0.5f,
                    PrefixPadding = TimeSpan.FromMilliseconds(300),
                    SilenceDuration = TimeSpan.FromMilliseconds(500)
                },
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16
            };

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InteractionModality.Text);
            sessionOptions.Modalities.Add(InteractionModality.Audio);

            await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);

            // Process events from the session
            await foreach (SessionUpdate serverEvent in session.GetUpdatesAsync().ConfigureAwait(false))
            {
                if (serverEvent is SessionUpdateResponseAudioDelta audioDelta)
                {
                    // Play audio response
                    byte[] audioData = audioDelta.Delta.ToArray();
                    // ... audio playback logic
                }
                else if (serverEvent is SessionUpdateResponseTextDelta textDelta)
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

            var model = "gpt-4o-realtime-preview"; // Specify the model to use

            VoiceLiveSession session = await client.StartSessionAsync(model).ConfigureAwait(false);

            #region Snippet:AdvancedVoiceConfiguration
            VoiceLiveSessionOptions sessionOptions = new()
            {
                Model = model,
                Instructions = "You are a customer service representative. Be helpful and professional.",
                Voice = new AzureCustomVoice("your-custom-voice-name", "your-custom-voice-endpoint-id")
                {
                    Temperature = 0.8f
                },
                TurnDetection = new AzureSemanticVadTurnDetection()
                {
                    RemoveFillerWords = true
                },
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16
            };

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InteractionModality.Text);
            sessionOptions.Modalities.Add(InteractionModality.Audio);

            await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);
            #endregion
        }

        public async Task FunctionCallResponseExample()
        {
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();

            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
            var model = "gpt-4o-mini-realtime-preview"; // Specify the model to use

            VoiceLiveSession session = await client.StartSessionAsync(model).ConfigureAwait(false);

            #region Snippet:FunctionCallingExample
            // Define a function for the assistant to call
            var getCurrentWeatherFunction = new VoiceLiveFunctionDefinition("get_current_weather")
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
            VoiceLiveSessionOptions sessionOptions = new()
            {
                Model = model,
                Instructions = "You are a weather assistant. Use the get_current_weather function to help users with weather information.",
                Voice = new AzureStandardVoice("en-US-AvaNeural"),
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16
            };

            // Add the function tool
            sessionOptions.Tools.Add(getCurrentWeatherFunction);

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InteractionModality.Text);
            sessionOptions.Modalities.Add(InteractionModality.Audio);

            await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);
            #endregion

            #region Snippet:FunctionCallResponseExample

            // Process events from the session
            await foreach (SessionUpdate serverEvent in session.GetUpdatesAsync().ConfigureAwait(false))
            {
                if (serverEvent is SessionUpdateResponseFunctionCallArgumentsDone functionCall)
                {
                    if (functionCall.Name == "get_current_weather")
                    {
                        // Extract parameters from the function call
                        var parametersString = functionCall.Arguments;
                        var parameters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(parametersString);

                        string location = parameters != null ? parameters["location"] : string.Empty;

                        // Call your external weather service here and get the result
                        string weatherInfo = $"The current weather in {location} is sunny with a temperature of 75°F.";

                        // Send the function response back to the session
                        await session.AddItemAsync(new FunctionCallOutputItem(functionCall.CallId, weatherInfo)).ConfigureAwait(false);

                        // Start the next response.
                        await session.StartResponseAsync().ConfigureAwait(false);
                    }
                }
            }
            #endregion
        }

        public async Task AddUserMessageExample()
        {
            Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
            var model = "gpt-4o-mini-realtime-preview"; // Specify the model to use
            VoiceLiveSession session = await client.StartSessionAsync(model).ConfigureAwait(false);

            VoiceLiveSessionOptions sessionOptions = new()
            {
                Model = model,
                Instructions = "You are a helpful AI assistant. Respond naturally and conversationally.",
                Voice = new AzureStandardVoice("en-US-AvaNeural"),
                TurnDetection = new AzureSemanticVadTurnDetection()
                {
                    Threshold = 0.5f,
                    PrefixPadding = TimeSpan.FromMilliseconds(300),
                    SilenceDuration = TimeSpan.FromMilliseconds(500)
                },
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16
            };
            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InteractionModality.Text);
            sessionOptions.Modalities.Add(InteractionModality.Audio);
            await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);

            #region Snippet:AddUserMessageExample

            // Add a user message to the session
            await session.AddItemAsync(new UserMessageItem("Hello, can you help me with my account?")).ConfigureAwait(false);
            // Start the response from the assistant
            await session.StartResponseAsync().ConfigureAwait(false);

            #endregion
        }
    }
}

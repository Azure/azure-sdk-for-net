// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Generates mock responses for testing with the fake WebSocket.
    /// </summary>
    public static class MockResponseGenerator
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates a mock weather response for a location.
        /// </summary>
        public static string GenerateWeatherResponse(string location)
        {
            return JsonSerializer.Serialize(new
            {
                location = location,
                temperature = _random.Next(60, 85),
                condition = new[] { "Sunny", "Cloudy", "Rainy", "Partly cloudy" }[_random.Next(4)],
                humidity = _random.Next(40, 80),
                wind_speed = _random.Next(5, 20),
                unit = "fahrenheit"
            });
        }

        /// <summary>
        /// Generates a mock time response for a timezone.
        /// </summary>
        public static string GenerateTimeResponse(string timezone)
        {
            var now = TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(timezone));

            return JsonSerializer.Serialize(new
            {
                timezone = timezone,
                time = now.ToString("h:mm tt"),
                date = now.ToString("yyyy-MM-dd"),
                dayOfWeek = now.DayOfWeek.ToString()
            });
        }

        /// <summary>
        /// Generates a mock calculation response.
        /// </summary>
        public static string GenerateCalculationResponse(string expression)
        {
            // This is a simplified mock that just returns a random result
            return JsonSerializer.Serialize(new
            {
                expression = expression,
                result = _random.Next(1, 1000),
                calculation_type = "basic_arithmetic"
            });
        }

        /// <summary>
        /// Generates mock audio data that simulates a response.
        /// </summary>
        public static byte[] GenerateMockAudioResponse(int durationMs = 2000)
        {
            // Generate a simple tone pattern that sounds like speech rhythm
            var sampleRate = 24000;
            var samples = sampleRate * durationMs / 1000;
            var buffer = new byte[samples * 2];

            // Create envelope for more natural sound
            for (int i = 0; i < samples; i++)
            {
                double t = (double)i / sampleRate;

                // Varying frequency to simulate speech patterns
                double frequency = 200 + 100 * Math.Sin(2 * Math.PI * 2 * t);

                // Amplitude envelope
                double envelope = Math.Sin(Math.PI * i / samples);

                // Generate sample
                double sample = Math.Sin(2 * Math.PI * frequency * t) * envelope * 0.3;
                short value = (short)(sample * short.MaxValue);

                buffer[i * 2] = (byte)(value & 0xFF);
                buffer[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
            }

            return buffer;
        }

        /// <summary>
        /// Generates a mock WebSocket message for a response audio delta event.
        /// </summary>
        public static string GenerateResponseAudioDeltaMessage(byte[] audioData, string responseId = "resp_123", string itemId = "item_123")
        {
            var base64Audio = Convert.ToBase64String(audioData);

            return JsonSerializer.Serialize(new
            {
                type = "response.audio.delta",
                event_id = Guid.NewGuid().ToString(),
                response_id = responseId,
                item_id = itemId,
                content_index = 0,
                output_index = 0,
                delta = base64Audio
            });
        }

        /// <summary>
        /// Generates a mock WebSocket message for a response text delta event.
        /// </summary>
        public static string GenerateResponseTextDeltaMessage(string textDelta, string responseId = "resp_123", string itemId = "item_123")
        {
            return JsonSerializer.Serialize(new
            {
                type = "response.text_content.delta",
                event_id = Guid.NewGuid().ToString(),
                response_id = responseId,
                item_id = itemId,
                content_index = 0,
                delta = textDelta
            });
        }

        /// <summary>
        /// Generates a mock WebSocket message for a response done event.
        /// </summary>
        public static string GenerateResponseDoneMessage(string responseId = "resp_123")
        {
            return JsonSerializer.Serialize(new
            {
                type = "response.done",
                event_id = Guid.NewGuid().ToString(),
                response_id = responseId,
                usage = new
                {
                    input_tokens = 10,
                    output_tokens = 20,
                    total_tokens = 30
                }
            });
        }

        /// <summary>
        /// Generates a mock WebSocket message for a function call event.
        /// </summary>
        public static string GenerateFunctionCallMessage(string functionName, string arguments, string callId = "call_123", string responseId = "resp_123")
        {
            return JsonSerializer.Serialize(new
            {
                type = "response.function_call.arguments.done",
                event_id = Guid.NewGuid().ToString(),
                response_id = responseId,
                name = functionName,
                call_id = callId,
                arguments = arguments
            });
        }

        /// <summary>
        /// Generates a tool definition for the specified tool name.
        /// </summary>
        public static VoiceLiveFunctionDefinition GenerateToolDefinition(string toolName)
        {
            switch (toolName.ToLower())
            {
                case "get_weather":
                    return new VoiceLiveFunctionDefinition("get_weather")
                    {
                        Description = "Get current weather for a location",
                        Parameters = BinaryData.FromString(JsonSerializer.Serialize(new
                        {
                            type = "object",
                            properties = new
                            {
                                location = new
                                {
                                    type = "string",
                                    description = "The city and state/country (e.g. 'Seattle, WA')"
                                }
                            },
                            required = new[] { "location" }
                        }))
                    };

                case "get_time":
                    return new VoiceLiveFunctionDefinition("get_time")
                    {
                        Description = "Get current time for a timezone",
                        Parameters = BinaryData.FromString(JsonSerializer.Serialize(new
                        {
                            type = "object",
                            properties = new
                            {
                                timezone = new
                                {
                                    type = "string",
                                    description = "The timezone ID (e.g. 'America/Los_Angeles')"
                                }
                            },
                            required = new[] { "timezone" }
                        }))
                    };

                case "calculate":
                    return new VoiceLiveFunctionDefinition("calculate")
                    {
                        Description = "Perform mathematical calculations",
                        Parameters = BinaryData.FromString(JsonSerializer.Serialize(new
                        {
                            type = "object",
                            properties = new
                            {
                                expression = new
                                {
                                    type = "string",
                                    description = "The mathematical expression to evaluate"
                                }
                            },
                            required = new[] { "expression" }
                        }))
                    };

                default:
                    return new VoiceLiveFunctionDefinition(toolName)
                    {
                        Description = $"Generic {toolName} function",
                        Parameters = BinaryData.FromString(JsonSerializer.Serialize(new
                        {
                            type = "object",
                            properties = new { },
                            required = new string[] { }
                        }))
                    };
            }
        }
    }
}

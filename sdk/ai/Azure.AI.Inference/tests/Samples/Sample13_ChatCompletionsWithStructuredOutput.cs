// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample13_ChatCompletionsWithStructuredOutput : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void SampleStructuredOutput()
        {
            #region Snippet:Azure_AI_Inference_SampleStructuredOutput
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
#else
            var endpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.AoaiKey);

            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            OverrideApiVersionPolicy overrideApiVersionPolicy = new OverrideApiVersionPolicy("2024-08-01-preview");
            clientOptions.AddPolicy(overrideApiVersionPolicy, HttpPipelinePosition.PerCall);
            var client = new ChatCompletionsClient(endpoint, credential, clientOptions);
#endif

            var messages = new List<ChatRequestMessage>()
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("Please give me directions and ingredients to bake a chocolate cake."),
            };

            var requestOptions = new ChatCompletionsOptions(messages);

            Dictionary<string, BinaryData> jsonSchema = new Dictionary<string, BinaryData>
            {
                { "type", BinaryData.FromString("\"object\"") },
                { "properties", BinaryData.FromString("""
                    {
                        "ingredients": {
                            "type": "array",
                            "items": {
                                "type": "string"
                            }
                        },
                        "steps": {
                            "type": "array",
                            "items": {
                                "type": "object",
                                "properties": {
                                    "ingredients": {
                                        "type": "array",
                                        "items": {
                                            "type": "string"
                                        }
                                    },
                                    "directions": {
                                        "type": "string"
                                    }
                                }
                            }
                        },
                        "prep_time": {
                            "type": "string"
                        },
                        "bake_time": {
                            "type": "string"
                        }
                    }
                    """) },
                { "required", BinaryData.FromString("[\"ingredients\", \"steps\", \"bake_time\"]") },
                { "additionalProperties", BinaryData.FromString("false") }
            };

            requestOptions.ResponseFormat = ChatCompletionsResponseFormat.CreateJsonFormat("cakeBakingDirections", jsonSchema);

            Response<ChatCompletions> response = client.Complete(requestOptions);
            #endregion

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);

            #region Snippet:Azure_AI_Inference_SampleStructuredOutputParseJson
            using JsonDocument structuredJson = JsonDocument.Parse(result.Content);
            structuredJson.RootElement.TryGetProperty("ingredients", out var ingredients);
            structuredJson.RootElement.TryGetProperty("steps", out var steps);
            structuredJson.RootElement.TryGetProperty("bake_time", out var bakeTime);
            #endregion

            Assert.AreEqual(ingredients.ValueKind, JsonValueKind.Array);
            Assert.AreEqual(steps.ValueKind, JsonValueKind.Array);
            foreach (JsonElement stepElement in steps.EnumerateArray())
            {
                stepElement.TryGetProperty("ingredients", out var stepIngredients);
                stepElement.TryGetProperty("directions", out var stepDirections);
                Assert.AreEqual(stepIngredients.ValueKind, JsonValueKind.Array);
                Assert.AreEqual(stepDirections.ValueKind, JsonValueKind.String);
            }
            Assert.AreEqual(bakeTime.ValueKind, JsonValueKind.String);

            #region Snippet:Azure_AI_Inference_SampleStructuredOutputPrintOutput
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine($"Ingredients: {System.Text.Json.JsonSerializer.Serialize(ingredients, options)}");
            Console.WriteLine($"Steps: {System.Text.Json.JsonSerializer.Serialize(steps, options)}");
            Console.WriteLine($"Bake time: {System.Text.Json.JsonSerializer.Serialize(bakeTime, options)}");
            #endregion
        }

        private class OverrideApiVersionPolicy : HttpPipelinePolicy
        {
            private string ApiVersion { get; }

            public OverrideApiVersionPolicy(string apiVersion)
            {
                ApiVersion = apiVersion;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.Query = $"?api-version={ApiVersion}";
                var task = ProcessNextAsync(message, pipeline);

                return task;
            }
        }
    }
}

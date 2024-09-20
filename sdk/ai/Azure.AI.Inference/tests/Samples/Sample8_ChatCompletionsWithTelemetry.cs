// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_AI_Inference_TelemetrySyncScenario_import
//Azure imports
using Azure;
using Azure.AI.Inference;
// Open telemetry imports
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
#endregion
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Azure.AI.Inference.Telemetry;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample8_ChatCompletionsWithTelemetry : SamplesBase<InferenceClientTestEnvironment>
    {
        [SetUp]
        public void Setup() {
            // Switch on open telemetry
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableSwitchName, "1");
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents, "1");
        }

        [Test]
        [SyncOnly]
        public void TelemetrySyncScenario()
        {
            #region Snippet:Azure_AI_Inference_TelemetrySyncScenario_variables
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("GITHUB_TOKEN"));
            var model = System.Environment.GetEnvironmentVariable("MODEL_NAME");
            var appInsightsConn = System.Environment.GetEnvironmentVariable("APP_INSIGHTS_CONNECTION_STR");
#else
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.GithubToken);
            var model = "gpt-4o";
            var appInsightsConn = TestEnvironment.TestApplicationInsights;
#endif
            #endregion
            #region Snippet:Azure_AI_Inference_TelemetrySyncScenario_providers
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(OpenTelemetryConstants.ClientName)
                .ConfigureResource(r => r.AddService("MyServiceName"))
                .AddConsoleExporter()
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(OpenTelemetryConstants.ClientName)
                .AddConsoleExporter()
                .AddAzureMonitorMetricExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();
            #endregion
            // Set up the parameters.
            #region Snippet:Azure_AI_Inference_TelemetrySyncScenario_inference
            var client = new ChatCompletionsClient(
                endpoint,
                credential,
                new ChatCompletionsClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = model,
                Temperature = 1,
                MaxTokens = 1000
            };
            // Call the enpoint and output the response.
            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);
            #endregion
#if !SNIPPET
            CheckResponse(response);
#endif
        }

        [Test]
        [AsyncOnly]
        public async Task TelemetrySyncStreamScenario()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("GITHUB_TOKEN"));
            var model = System.Environment.GetEnvironmentVariable("MODEL_NAME");
            var appInsightsConn = System.Environment.GetEnvironmentVariable("APP_INSIGHTS_CONNECTION_STR");
#else
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.GithubToken);
            var model = "mistral-small";
            var appInsightsConn = TestEnvironment.TestApplicationInsights;
#endif
            const string ACTIVITY = "Azure.AI.Inference.ChatCompletionsClient";
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ACTIVITY)
                .ConfigureResource(r => r.AddService("MyServiceName"))
                .AddConsoleExporter()
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(ACTIVITY)
                .AddConsoleExporter()
                .AddAzureMonitorMetricExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            // Set up the parameters.
            var client = new ChatCompletionsClient(
                endpoint,
                credential,
                new ChatCompletionsClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = model
            };

            // Call the enpoint and output the response.
            StreamingResponse<StreamingChatCompletionsUpdate> response = client.CompleteStreaming(requestOptions);
            Assert.That(response, Is.Not.Null);

#if !SNIPPET
            await checkStreamingResponse(response);
#else
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                    {
                        System.Console.Write(chatUpdate.ContentUpdate);
                    }
            }
#endif
            System.Console.WriteLine("");
        }

        [Test]
        [AsyncOnly]
        public async Task TelemetryAsyncScenario()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("GITHUB_TOKEN"));
            var model = System.Environment.GetEnvironmentVariable("MODEL_NAME");
            var appInsightsConn = System.Environment.GetEnvironmentVariable("APP_INSIGHTS_CONNECTION_STR");
#else
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.GithubToken);
            var model = "gpt-4o";
            var appInsightsConn = TestEnvironment.TestApplicationInsights;
#endif
            const string ACTIVITY = "Azure.AI.Inference.ChatCompletionsClient";
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ACTIVITY)
                .ConfigureResource(r => r.AddService("MyServiceName"))
                .AddConsoleExporter()
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(ACTIVITY)
                .AddConsoleExporter()
                .AddAzureMonitorMetricExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            // Set up the parameters.
            var client = new ChatCompletionsClient(
                endpoint,
                credential,
                new ChatCompletionsClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = model,
                Temperature = 1,
                MaxTokens = 1000
            };
            // Call the enpoint and output the response.
            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);
#if !SNIPPET
            CheckResponse(response);
#endif
        }

        [Test]
        [AsyncOnly]
        public async Task TelemetryAsyncStreamScenario()
        {
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("GITHUB_TOKEN"));
            var model = System.Environment.GetEnvironmentVariable("MODEL_NAME");
            var appInsightsConn = System.Environment.GetEnvironmentVariable("APP_INSIGHTS_CONNECTION_STR");
#else
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.GithubToken);
            var model = "mistral-small";
            var appInsightsConn = TestEnvironment.TestApplicationInsights;
#endif
            const string ACTIVITY = "Azure.AI.Inference.ChatCompletionsClient";
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ACTIVITY)
                .ConfigureResource(r => r.AddService("MyServiceName"))
                .AddConsoleExporter()
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(ACTIVITY)
                .AddConsoleExporter()
                .AddAzureMonitorMetricExporter(options =>
                {
                    options.ConnectionString = appInsightsConn;
                })
                .Build();

            // Set up the parameters.
            var client = new ChatCompletionsClient(
                endpoint,
                credential,
                new ChatCompletionsClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = model,
                Temperature = 1,
                MaxTokens = 1000
            };

            // Call the enpoint and output the response.
            StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);
            Assert.That(response, Is.Not.Null);

#if !SNIPPET
            await checkStreamingResponse(response);
#else
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                    {
                        System.Console.Write(chatUpdate.ContentUpdate);
                    }
            }
#endif
            System.Console.WriteLine("");
        }

        #region Helpers
        private async Task checkStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response)
        {
            string id = null;
            string ret_model = null;
            bool gotRole = false;
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                Assert.That(chatUpdate, Is.Not.Null);

                Assert.That(chatUpdate.Id, Is.Not.Null.Or.Empty);
                Assert.That(chatUpdate.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
                Assert.That(chatUpdate.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));
                if (!string.IsNullOrEmpty(chatUpdate.Id))
                {
                    Assert.That((id is null) || (id == chatUpdate.Id));
                    id = chatUpdate.Id;
                }
                if (!string.IsNullOrEmpty(chatUpdate.Model))
                {
                    Assert.That((ret_model is null) || (ret_model == chatUpdate.Model));
                    ret_model = chatUpdate.Model;
                }
                if (chatUpdate.Role.HasValue)
                {
                    Assert.IsFalse(gotRole);
                    Assert.That(chatUpdate.Role.Value, Is.EqualTo(ChatRole.Assistant));
                    gotRole = true;
                }

                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    System.Console.Write(chatUpdate.ContentUpdate);
                }
            }
        }

        private void CheckResponse(Response<ChatCompletions> response)
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(choice.Index, Is.EqualTo(0));
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
        }
        #endregion
    }
}

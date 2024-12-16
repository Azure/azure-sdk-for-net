// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_AI_Inference_EnableOpenTelemetry_import
//Azure imports
// Open telemetry imports
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
#endregion
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample8_ChatCompletionsWithOpenTelemetry : SamplesBase<InferenceClientTestEnvironment>
    {
        [SetUp]
        public void Setup()
        {
            AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);
            AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", true);
        }

        [TearDown]
        public void CleanUp()
        {
            AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", false);
            AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", false);
        }

        [Test]
        [SyncOnly]
        public void EnableOpenTelemetry()
        {
            #region Snippet:Azure_AI_Inference_EnableOpenTelemetry_variables
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("MODEL_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("GITHUB_TOKEN"));
            var model = System.Environment.GetEnvironmentVariable("MODEL_NAME");
#else

            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.GithubToken);
            var model = "gpt-4o";
#endif
            #endregion
            #region Snippet:Azure_AI_Inference_EnableOpenTelemetry

            // Enables experimental Azure SDK observability
            AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

            // By default instrumentation captures chat messages without content
            // since content can be very verbose and have sensitive information.
            // The following AppContext switch enables content recording.
            AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", true);

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddHttpClientInstrumentation()
                .AddSource("Azure.AI.Inference.*")
                .ConfigureResource(r => r.AddService("sample"))
                .AddConsoleExporter()
                .AddOtlpExporter()
                .Build();

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddHttpClientInstrumentation()
                .AddMeter("Azure.AI.Inference.*")
                .ConfigureResource(r => r.AddService("sample"))
                .AddConsoleExporter()
                .AddOtlpExporter()
                .Build();
            #endregion
            // Set up the parameters.
            #region Snippet:Azure_AI_Inference_EnableOpenTelemetry_inference
            var client = new ChatCompletionsClient(
                endpoint,
                credential,
                new AzureAIInferenceClientOptions());

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
            // Call the endpoint and output the response.
            Response<ChatCompletions> response = client.Complete(requestOptions);
            Console.WriteLine(response.Value.Choices[0].Message.Content);
            #endregion
#if !SNIPPET
            CheckResponse(response);
#endif
        }

        #region Helpers
        private async Task checkStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response)
        {
            string id = null;
            string ret_model = null;
            bool gotRole = false;
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                if (string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    continue;
                }
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

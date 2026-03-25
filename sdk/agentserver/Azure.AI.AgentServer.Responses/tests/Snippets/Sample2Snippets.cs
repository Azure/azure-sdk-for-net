// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample2_FunctionCalling.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample2Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample2_StartServer

#if SNIPPET
            AgentHost.Run<WeatherHandler>(args);
#else
            AgentHost.Run<WeatherHandler>(args: null);
#endif

            #endregion
        }

        [Test]
        public void Implement_WeatherHandler()
        {
            var handler = new WeatherHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample2_WeatherHandler

        public class WeatherHandler : IResponseHandler
        {
            public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                IResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                var stream = new ResponseEventStream(context, request);

                // Check if the input contains a function call output (turn 2)
                var inputItems = request.GetInputExpanded();
                var toolOutput = inputItems.OfType<FunctionCallOutputItemParam>().FirstOrDefault();

                if (toolOutput is not null)
                {
                    // Turn 2: function output received — return the weather as a text message
                    var weatherJson = toolOutput.Output is not null
                        ? JsonSerializer.Deserialize<string>(toolOutput.Output) ?? "{}"
                        : "{}";

                    yield return stream.EmitCreated();
                    yield return stream.EmitInProgress();

                    var message = stream.AddOutputItemMessage();
                    yield return message.EmitAdded();

                    var text = message.AddTextContent();
                    yield return text.EmitAdded();

                    var reply = $"The weather is: {weatherJson}";
                    yield return text.EmitDelta(reply);
                    yield return text.EmitDone(reply);

                    yield return message.EmitContentDone(text);
                    yield return message.EmitDone();

                    yield return stream.EmitCompleted();
                }
                else
                {
                    // Turn 1: emit a function call for "get_weather"
                    yield return stream.EmitCreated();
                    yield return stream.EmitInProgress();

                    var funcCall = stream.AddOutputItemFunctionCall(
                        "get_weather", "call_weather_1");
                    yield return funcCall.EmitAdded();

                    var arguments = JsonSerializer.Serialize(
                        new { location = "Seattle", unit = "fahrenheit" });
                    yield return funcCall.EmitArgumentsDelta(arguments);
                    yield return funcCall.EmitArgumentsDone(arguments);

                    yield return funcCall.EmitDone();

                    yield return stream.EmitCompleted();
                }
            }
        }

        #endregion
    }
}

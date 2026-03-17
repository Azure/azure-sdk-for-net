using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

namespace FunctionCalling;

/// <summary>
/// A two-turn function calling handler.
/// Turn 1: emits a get_weather function call for the model to invoke.
/// Turn 2: receives the function call output via input and returns
///         a text message with the weather information.
/// Turns are tied together using a conversation_id supplied by the client.
/// </summary>
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

            var funcCall = stream.AddOutputItemFunctionCall("get_weather", "call_weather_1");
            yield return funcCall.EmitAdded();

            var arguments = JsonSerializer.Serialize(new { location = "Seattle", unit = "fahrenheit" });
            yield return funcCall.EmitArgumentsDelta(arguments);
            yield return funcCall.EmitArgumentsDone(arguments);

            yield return funcCall.EmitDone();

            yield return stream.EmitCompleted();
        }
    }
}

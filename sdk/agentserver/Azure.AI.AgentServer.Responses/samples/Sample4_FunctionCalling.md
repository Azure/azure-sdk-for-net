# Sample 4: Function Calling — Two-Turn Weather Handler

This sample shows the two-turn function calling pattern where the server emits a function call on the first turn, receives the function output on the second turn, and returns a final text message. The handler is shown first using convenience generators, then with full builder control.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use `OutputItemFunctionCall()` and `OutputItemMessage()` to emit complete output items in one call each. The convenience generators handle all inner events automatically:

```C# Snippet:Responses_Sample4_WeatherHandlerConvenience
public class WeatherHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        // Check if the input contains a function call output (turn 2)
        var inputItems = await context.GetInputItemsAsync(cancellationToken: cancellationToken);
        var toolOutput = inputItems.OfType<FunctionCallOutputItemParam>().FirstOrDefault();

        if (toolOutput is not null)
        {
            // Turn 2: function output received — return the weather as a text message
            var weatherJson = toolOutput.Output is not null
                ? JsonSerializer.Deserialize<string>(toolOutput.Output) ?? "{}"
                : "{}";

            yield return stream.EmitCreated();
            yield return stream.EmitInProgress();

            foreach (var evt in stream.OutputItemMessage($"The weather is: {weatherJson}"))
                yield return evt;

            yield return stream.EmitCompleted();
        }
        else
        {
            // Turn 1: emit a function call for "get_weather"
            yield return stream.EmitCreated();
            yield return stream.EmitInProgress();

            var arguments = JsonSerializer.Serialize(
                new { location = "Seattle", unit = "fahrenheit" });
            foreach (var evt in stream.OutputItemFunctionCall("get_weather", "call_weather_1", arguments))
                yield return evt;

            yield return stream.EmitCompleted();
        }
    }
}
```

## With full event control

When you need to set custom properties on the function call item before `EmitAdded()`, or interleave non-event work between builder calls, use the builder API:

```C# Snippet:Responses_Sample4_WeatherHandler
public class WeatherHandlerFullControl : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        // Check if the input contains a function call output (turn 2)
        var inputItems = await context.GetInputItemsAsync(cancellationToken: cancellationToken);
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
```

## Start the server

```C# Snippet:Responses_Sample4_StartServer
ResponsesServer.Run<WeatherHandler>();
```

## Test the endpoint

### Turn 1 — request triggers a function call

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "test",
    "conversation": "conv_demo_001",
    "input": "What is the weather in Seattle?"
  }' --no-buffer
```

The response will contain a `function_call` output item with `call_id` and arguments `{"location":"Seattle","unit":"fahrenheit"}`. Extract the `call_id` from the response for the next turn.

### Turn 2 — submit function output, receive text

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "test",
    "conversation": "conv_demo_001",
    "input": [{
      "type": "function_call_output",
      "call_id": "call_weather_1",
      "output": "{\"temperature\": 72, \"condition\": \"sunny\"}"
    }]
  }' --no-buffer
```

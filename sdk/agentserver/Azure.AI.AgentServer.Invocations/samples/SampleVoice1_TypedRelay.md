# Sample Voice 1: Typed Voice relay

This sample implements the Voice Live Bridge Protocol 1.0 as a typed event relay over the existing `/invocations_ws` endpoint. The handler explicitly acknowledges startup, creates every response and output ID, and owns cancellation for its response tasks.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Declare Voice support

Deploy with the declarations in [`voice-agent.manifest.yaml`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/voice-agent.manifest.yaml):

```yaml
name: contoso-voice-support
protocols:
  - invocations_ws
voiceLiveCompatible: "true"
bridgeProtocolVersion: "1.0"
```

`bridgeProtocolVersion` selects the exact typed contract. Public Preview supports `1.0`; omitting it preserves the pre-Bridge Voice integration.

## Implement the handler

```C# Snippet:Invocations_SampleVoice1_Handler
public class VoiceSupportHandler : VoiceHandler
{
    private readonly ConcurrentDictionary<string, Generation> _generations = new();
    private readonly ConcurrentDictionary<string, string> _inputGenerations = new();
    private readonly ILogger<VoiceSupportHandler> _logger;

    public VoiceSupportHandler(ILogger<VoiceSupportHandler> logger) => _logger = logger;

    protected override Task OnSessionStartAsync(
        VoiceSession session,
        VoiceSessionStartEvent start,
        CancellationToken cancellationToken)
    {
        if (!string.Equals(start.ProtocolVersion, "1.0", StringComparison.Ordinal))
        {
            return session.SendAsync(
                new VoiceSessionRejectedMessage("protocol_mismatch", retriable: false),
                cancellationToken);
        }

        return session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
    }

    protected override async Task OnUserMessageAsync(
        VoiceSession session,
        VoiceUserMessageEvent message,
        CancellationToken cancellationToken)
    {
        var responseId = VoiceIds.CreateResponseId();
        var generationCancellation =
            CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var generation = new Generation(message.ItemId, generationCancellation);
        if (!_generations.TryAdd(responseId, generation) ||
            !_inputGenerations.TryAdd(message.ItemId, responseId))
        {
            _generations.TryRemove(responseId, out _);
            generationCancellation.Dispose();
            throw new InvalidOperationException("Could not register the Voice response.");
        }

        var input = string.Concat(message.Content.Select(part => part.Text));
        try
        {
            await session.SendAsync(
                new VoiceResponseCreatedMessage(responseId, new[] { message.ItemId }),
                generationCancellation.Token);
        }
        catch
        {
            RemoveGeneration(responseId);
            throw;
        }

        _ = SendResponseAsync(
            session,
            responseId,
            input,
            generation);
    }

    protected override Task OnBargeInAsync(
        VoiceSession session,
        VoiceBargeInEvent bargeIn,
        CancellationToken cancellationToken)
    {
        CancelGeneration(bargeIn.ResponseId);
        return Task.CompletedTask;
    }

    protected override Task OnResponseCancelledAsync(
        VoiceSession session,
        VoiceResponseCancelledEvent cancelled,
        CancellationToken cancellationToken)
    {
        CancelGeneration(cancelled.ResponseId);
        return Task.CompletedTask;
    }

    protected override Task OnResponseTimeoutAsync(
        VoiceSession session,
        VoiceResponseTimeoutEvent timeout,
        CancellationToken cancellationToken)
    {
        if (timeout.ResponseId is not null)
        {
            CancelGeneration(timeout.ResponseId);
        }
        else if (timeout.ItemIds is not null)
        {
            foreach (var inputItemId in timeout.ItemIds)
            {
                if (_inputGenerations.TryGetValue(inputItemId, out var responseId))
                {
                    CancelGeneration(responseId);
                }
            }
        }
        return Task.CompletedTask;
    }

    protected override Task OnSessionEndAsync(
        VoiceSession session,
        VoiceSessionEndEvent end,
        CancellationToken cancellationToken)
    {
        CancelAllGenerations();
        return Task.CompletedTask;
    }

    protected override void OnConnectionTerminating(VoiceSession session) =>
        CancelAllGenerations();

    protected virtual Task<string> GenerateAnswerAsync(
        string input,
        CancellationToken cancellationToken) =>
        Task.FromResult($"You said: {input}");

    private async Task SendResponseAsync(
        VoiceSession session,
        string responseId,
        string input,
        Generation generation)
    {
        var cancellationToken = generation.Cancellation.Token;
        var itemId = VoiceIds.CreateItemId();
        try
        {
            var answer = await GenerateAnswerAsync(input, cancellationToken);
            await session.SendAsync(
                new VoiceResponseOutputTextDoneMessage(responseId, itemId, answer),
                cancellationToken);
            await session.SendAsync(
                new VoiceResponseDoneMessage(responseId),
                cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // The Bridge reports the winning barge-in, timeout, or cancellation outcome.
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Voice response {ResponseId} failed", responseId);
            try
            {
                await session.SendAsync(
                    new VoiceErrorMessage(
                        "generation_failed",
                        "Response generation failed.",
                        responseId),
                    CancellationToken.None);
            }
            catch (Exception sendException)
            {
                _logger.LogDebug(
                    sendException,
                    "Could not report failure for Voice response {ResponseId}",
                    responseId);
            }
        }
        finally
        {
            RemoveGeneration(responseId);
        }
    }

    private void CancelGeneration(string responseId)
    {
        if (_generations.TryRemove(responseId, out var generation))
        {
            _inputGenerations.TryRemove(generation.InputItemId, out _);
            _ = CancelAndDisposeAsync(generation.Cancellation);
        }
    }

    private void RemoveGeneration(string responseId)
    {
        if (_generations.TryRemove(responseId, out var generation))
        {
            _inputGenerations.TryRemove(generation.InputItemId, out _);
            generation.Cancellation.Dispose();
        }
    }

    private void CancelAllGenerations()
    {
        foreach (var responseId in _generations.Keys)
        {
            CancelGeneration(responseId);
        }
    }

    private async Task CancelAndDisposeAsync(CancellationTokenSource cancellation)
    {
        try
        {
            await cancellation.CancelAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Voice response cancellation failed");
        }
        finally
        {
            cancellation.Dispose();
        }
    }

    private sealed record Generation(
        string InputItemId,
        CancellationTokenSource Cancellation);
}
```

The response task is application-owned. `OnUserMessageAsync` registers it and returns immediately so the relay can dispatch later interruption and timeout events. `OnConnectionTerminating` only starts cancellation; it does not send or block transport close.

## Start the server

```C# Snippet:Invocations_SampleVoice1_StartServer
VoiceServer.Run<VoiceSupportHandler>();
```

The host reuses the existing `/invocations_ws` route, WebSocket upgrade, Ping/Pong, identity propagation, close, and structured close telemetry.
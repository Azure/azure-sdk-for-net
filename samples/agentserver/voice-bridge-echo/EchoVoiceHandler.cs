// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.Extensions.Logging;

namespace VoiceBridgeEcho;

/// <summary>A model-free hosted agent that demonstrates Voice Bridge Protocol 1.0.</summary>
public sealed class EchoVoiceHandler : VoiceHandler
{
    private const string HelpText =
        "Commands: /stream text, /done text, /voice text, /none, /proactive text, " +
        "/cancel text, /error, /session-error, /end, /end-now, and /help.";

    private readonly ConcurrentDictionary<string, Generation> _generations = new();
    private readonly ConcurrentDictionary<string, string> _inputResponses = new();
    private readonly ConcurrentDictionary<string, string> _proactiveResponses = new();
    private readonly ILogger<EchoVoiceHandler> _logger;

    /// <summary>Initializes the echo handler.</summary>
    public EchoVoiceHandler(ILogger<EchoVoiceHandler> logger) => _logger = logger;

    protected override Task OnSessionStartAsync(
        VoiceSession session,
        VoiceSessionStartEvent start,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Voice session {SessionId} started; protocol={ProtocolVersion}, reconnect={Reconnect}, greeting={HasGreeting}",
            session.InvocationContext.SessionId,
            start.ProtocolVersion,
            start.Reconnect,
            start.Greeting is not null);

        if (!string.Equals(start.ProtocolVersion, "1.0", StringComparison.Ordinal))
        {
            return session.SendAsync(
                new VoiceSessionRejectedMessage("protocol_mismatch", retriable: false),
                cancellationToken);
        }

        if (bool.TryParse(Environment.GetEnvironmentVariable("VOICE_SAMPLE_REJECT_START"), out var reject) && reject)
        {
            return session.SendAsync(
                new VoiceSessionRejectedMessage(
                    "startup_failed",
                    retriable: true,
                    "VOICE_SAMPLE_REJECT_START is enabled."),
                cancellationToken);
        }

        return session.SendAsync(new VoiceSessionReadyMessage(), cancellationToken);
    }

    protected override async Task OnUserMessageAsync(
        VoiceSession session,
        VoiceUserMessageEvent message,
        CancellationToken cancellationToken)
    {
        var input = string.Concat(message.Content.Select(part => part.Text)).Trim();
        var (command, argument) = ParseCommand(input);

        switch (command)
        {
            case "/none":
                await session.SendAsync(
                    new VoiceResponseNoneMessage(new[] { message.ItemId }, "no_reply_needed"),
                    cancellationToken);
                return;
            case "/proactive":
                await session.SendAsync(
                    new VoiceResponseNoneMessage(new[] { message.ItemId }, "proactive_requested"),
                    cancellationToken);
                await RequestProactiveResponseAsync(
                    session,
                    string.IsNullOrWhiteSpace(argument) ? "This is a proactive echo." : argument,
                    cancellationToken);
                return;
            case "/error":
                await SendSampleErrorAsync(session, message.ItemId, cancellationToken);
                return;
            case "/session-error":
                await session.SendAsync(
                    new VoiceErrorMessage(
                        "sample_session_error",
                        "The echo sample emitted the requested session error."),
                    cancellationToken);
                return;
            case "/end":
            case "/end-now":
                await session.SendAsync(
                    new VoiceEndCallMessage(
                        "sample_completed",
                        command == "/end-now" ? VoiceEndCallMode.Immediate : VoiceEndCallMode.Drain),
                    cancellationToken);
                return;
            case "/cancel":
                StartSelfCancellingResponse(
                    session,
                    message.ItemId,
                    string.IsNullOrWhiteSpace(argument) ? "This echo cancels itself." : argument,
                    cancellationToken);
                return;
            case "/done":
                StartEchoResponse(
                    session,
                    message.ItemId,
                    EchoText(argument),
                    streaming: false,
                    voice: null,
                    connectionCancellation: cancellationToken);
                return;
            case "/voice":
                StartEchoResponse(
                    session,
                    message.ItemId,
                    EchoText(argument),
                    streaming: false,
                    voice: BinaryData.FromString("""{"rate":"+10%"}"""),
                    connectionCancellation: cancellationToken);
                return;
            case "/help":
                StartEchoResponse(
                    session,
                    message.ItemId,
                    HelpText,
                    streaming: false,
                    voice: null,
                    connectionCancellation: cancellationToken);
                return;
            case "/stream":
                input = argument;
                break;
        }

        StartEchoResponse(
            session,
            message.ItemId,
            EchoText(input),
            streaming: true,
            voice: null,
            connectionCancellation: cancellationToken);
    }

    protected override Task OnUserNoInputAsync(
        VoiceSession session,
        VoiceUserNoInputEvent noInput,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("No input received; count={Count}", noInput.Count);
        if (noInput.Count >= 3)
        {
            return session.SendAsync(
                new VoiceEndCallMessage("repeated_no_input", VoiceEndCallMode.Drain),
                cancellationToken);
        }

        StartEchoResponse(
            session,
            noInput.ItemId,
            noInput.Count == 1 ? "Are you still there?" : "I still cannot hear you.",
            streaming: false,
            voice: null,
            connectionCancellation: cancellationToken);
        return Task.CompletedTask;
    }

    protected override Task OnUserSpeechStartedAsync(
        VoiceSession session,
        VoiceUserSpeechStartedEvent speechStarted,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Caller speech started while the agent was idle");
        return Task.CompletedTask;
    }

    protected override Task OnBargeInAsync(
        VoiceSession session,
        VoiceBargeInEvent bargeIn,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Response {ResponseId} was interrupted after {CharacterCount} characters",
            bargeIn.ResponseId,
            bargeIn.HeardText.Length);
        CancelGeneration(bargeIn.ResponseId);
        return Task.CompletedTask;
    }

    protected override Task OnResponseAcceptedAsync(
        VoiceSession session,
        VoiceResponseAcceptedEvent accepted,
        CancellationToken cancellationToken)
    {
        if (_proactiveResponses.TryRemove(accepted.ResponseId, out var text))
        {
            StartAcceptedProactiveResponse(session, accepted.ResponseId, text, cancellationToken);
        }
        return Task.CompletedTask;
    }

    protected override Task OnResponseDroppedAsync(
        VoiceSession session,
        VoiceResponseDroppedEvent dropped,
        CancellationToken cancellationToken)
    {
        _proactiveResponses.TryRemove(dropped.ResponseId, out _);
        _logger.LogInformation(
            "Proactive response {ResponseId} was dropped: {Reason}",
            dropped.ResponseId,
            dropped.Reason);
        return Task.CompletedTask;
    }

    protected override Task OnResponseCancelledAsync(
        VoiceSession session,
        VoiceResponseCancelledEvent cancelled,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Self-cancel completed for {ResponseId}; heard={CharacterCount} characters",
            cancelled.ResponseId,
            cancelled.HeardText.Length);
        CancelGeneration(cancelled.ResponseId);
        return Task.CompletedTask;
    }

    protected override Task OnResponseTimeoutAsync(
        VoiceSession session,
        VoiceResponseTimeoutEvent timeout,
        CancellationToken cancellationToken)
    {
        _logger.LogWarning("Voice response timed out at stage {Stage}", timeout.Stage);
        if (timeout.ResponseId is not null)
        {
            _proactiveResponses.TryRemove(timeout.ResponseId, out _);
            CancelGeneration(timeout.ResponseId);
        }
        else if (timeout.ItemIds is not null)
        {
            foreach (var itemId in timeout.ItemIds)
            {
                if (_inputResponses.TryGetValue(itemId, out var responseId))
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
        _logger.LogInformation("Voice session ended: {Reason}", end.Reason);
        CancelAllGenerations();
        return Task.CompletedTask;
    }

    protected override void OnConnectionTerminating(VoiceSession session)
    {
        _logger.LogInformation("Voice transport is terminating");
        CancelAllGenerations();
    }

    private void StartEchoResponse(
        VoiceSession session,
        string inputItemId,
        string text,
        bool streaming,
        BinaryData? voice,
        CancellationToken connectionCancellation)
    {
        var responseId = VoiceIds.CreateResponseId();
        if (!TryRegisterGeneration(responseId, inputItemId, connectionCancellation, out var generation))
        {
            throw new InvalidOperationException("Could not register the Voice echo response.");
        }

        _ = RunEchoResponseAsync(
            session,
            responseId,
            inputItemId,
            text,
            streaming,
            voice,
            generation);
    }

    private async Task RunEchoResponseAsync(
        VoiceSession session,
        string responseId,
        string inputItemId,
        string text,
        bool streaming,
        BinaryData? voice,
        Generation generation)
    {
        var cancellationToken = generation.Cancellation.Token;
        var opened = false;
        try
        {
            await session.SendAsync(
                new VoiceResponseCreatedMessage(responseId, new[] { inputItemId }),
                cancellationToken);
            opened = true;
            await SendEchoOutputAsync(session, responseId, text, streaming, voice, cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception exception)
        {
            await ReportGenerationFailureAsync(session, responseId, opened, exception);
        }
        finally
        {
            RemoveGeneration(responseId);
        }
    }

    private async Task RequestProactiveResponseAsync(
        VoiceSession session,
        string text,
        CancellationToken cancellationToken)
    {
        var responseId = VoiceIds.CreateResponseId();
        if (!_proactiveResponses.TryAdd(responseId, text))
        {
            throw new InvalidOperationException("Could not register the proactive request.");
        }

        try
        {
            await session.SendAsync(
                new VoiceResponseCreatedMessage(
                    responseId,
                    admissionTimeoutMs: 5000,
                    supersedeKey: "voice-echo-sample"),
                cancellationToken);
        }
        catch
        {
            _proactiveResponses.TryRemove(responseId, out _);
            throw;
        }
    }

    private void StartAcceptedProactiveResponse(
        VoiceSession session,
        string responseId,
        string text,
        CancellationToken connectionCancellation)
    {
        if (!TryRegisterGeneration(responseId, inputItemId: null, connectionCancellation, out var generation))
        {
            throw new InvalidOperationException("Could not register the proactive Voice response.");
        }

        _ = RunAcceptedProactiveResponseAsync(session, responseId, text, generation);
    }

    private async Task RunAcceptedProactiveResponseAsync(
        VoiceSession session,
        string responseId,
        string text,
        Generation generation)
    {
        var cancellationToken = generation.Cancellation.Token;
        try
        {
            await SendEchoOutputAsync(
                session,
                responseId,
                $"Proactive echo: {text}",
                streaming: false,
                voice: null,
                cancellationToken: cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception exception)
        {
            await ReportGenerationFailureAsync(session, responseId, responseOpened: true, exception);
        }
        finally
        {
            RemoveGeneration(responseId);
        }
    }

    private static async Task SendEchoOutputAsync(
        VoiceSession session,
        string responseId,
        string text,
        bool streaming,
        BinaryData? voice,
        CancellationToken cancellationToken)
    {
        var itemId = VoiceIds.CreateItemId();
        if (streaming)
        {
            var first = true;
            foreach (var chunk in Chunk(text, 12))
            {
                await session.SendAsync(
                    new VoiceResponseOutputTextDeltaMessage(
                        responseId,
                        itemId,
                        chunk,
                        first ? voice : null),
                    cancellationToken);
                first = false;
                await Task.Delay(TimeSpan.FromMilliseconds(125), cancellationToken);
            }
        }

        await session.SendAsync(
            new VoiceResponseOutputTextDoneMessage(responseId, itemId, text, voice),
            cancellationToken);
        await session.SendAsync(new VoiceResponseDoneMessage(responseId), cancellationToken);
    }

    private void StartSelfCancellingResponse(
        VoiceSession session,
        string inputItemId,
        string text,
        CancellationToken connectionCancellation)
    {
        var responseId = VoiceIds.CreateResponseId();
        if (!TryRegisterGeneration(responseId, inputItemId, connectionCancellation, out var generation))
        {
            throw new InvalidOperationException("Could not register the self-cancelling Voice response.");
        }

        _ = RunSelfCancellingResponseAsync(session, responseId, inputItemId, text, generation);
    }

    private async Task RunSelfCancellingResponseAsync(
        VoiceSession session,
        string responseId,
        string inputItemId,
        string text,
        Generation generation)
    {
        var cancellationToken = generation.Cancellation.Token;
        try
        {
            var itemId = VoiceIds.CreateItemId();
            await session.SendAsync(
                new VoiceResponseCreatedMessage(responseId, new[] { inputItemId }),
                cancellationToken);
            await session.SendAsync(
                new VoiceResponseOutputTextDeltaMessage(responseId, itemId, text),
                cancellationToken);
            await Task.Delay(TimeSpan.FromMilliseconds(300), cancellationToken);
            await session.SendAsync(
                new VoiceResponseCancelMessage(responseId, "sample_self_correction"),
                cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            RemoveGeneration(responseId);
        }
        catch (Exception exception)
        {
            RemoveGeneration(responseId);
            await ReportGenerationFailureAsync(session, responseId, responseOpened: true, exception);
        }
        // A successful response.cancel stays registered until its terminal callback arrives.
    }

    private static async Task SendSampleErrorAsync(
        VoiceSession session,
        string inputItemId,
        CancellationToken cancellationToken)
    {
        var responseId = VoiceIds.CreateResponseId();
        await session.SendAsync(
            new VoiceResponseCreatedMessage(responseId, new[] { inputItemId }),
            cancellationToken);
        await session.SendAsync(
            new VoiceErrorMessage(
                "sample_error",
                "The echo sample emitted the requested error.",
                responseId),
            cancellationToken);
    }

    private async Task ReportGenerationFailureAsync(
        VoiceSession session,
        string responseId,
        bool responseOpened,
        Exception exception)
    {
        _logger.LogError(exception, "Voice echo response {ResponseId} failed", responseId);
        try
        {
            await session.SendAsync(
                new VoiceErrorMessage(
                    "echo_failed",
                    "The echo response failed.",
                    responseOpened ? responseId : null),
                CancellationToken.None);
        }
        catch (Exception sendException)
        {
            _logger.LogDebug(sendException, "Could not report Voice echo failure");
        }
    }

    private bool TryRegisterGeneration(
        string responseId,
        string? inputItemId,
        CancellationToken connectionCancellation,
        out Generation generation)
    {
        generation = new Generation(
            inputItemId,
            CancellationTokenSource.CreateLinkedTokenSource(connectionCancellation));
        if (!_generations.TryAdd(responseId, generation))
        {
            generation.Cancellation.Dispose();
            return false;
        }

        if (inputItemId is not null && !_inputResponses.TryAdd(inputItemId, responseId))
        {
            _generations.TryRemove(responseId, out _);
            generation.Cancellation.Dispose();
            return false;
        }

        return true;
    }

    private void CancelGeneration(string responseId)
    {
        if (_generations.TryRemove(responseId, out var generation))
        {
            if (generation.InputItemId is not null)
            {
                _inputResponses.TryRemove(generation.InputItemId, out _);
            }
            _ = CancelAndDisposeAsync(generation.Cancellation);
        }
    }

    private void CancelAllGenerations()
    {
        _proactiveResponses.Clear();
        foreach (var responseId in _generations.Keys)
        {
            CancelGeneration(responseId);
        }
    }

    private void RemoveGeneration(string responseId)
    {
        if (_generations.TryRemove(responseId, out var generation))
        {
            if (generation.InputItemId is not null)
            {
                _inputResponses.TryRemove(generation.InputItemId, out _);
            }
            generation.Cancellation.Dispose();
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
            _logger.LogError(exception, "Cancelling a Voice echo response failed");
        }
        finally
        {
            cancellation.Dispose();
        }
    }

    private static IEnumerable<string> Chunk(string value, int size)
    {
        for (var offset = 0; offset < value.Length; offset += size)
        {
            yield return value.Substring(offset, Math.Min(size, value.Length - offset));
        }
    }

    private static string EchoText(string value) =>
        string.IsNullOrWhiteSpace(value) ? "Echo: (empty input)" : $"Echo: {value}";

    private static (string Command, string Argument) ParseCommand(string input)
    {
        if (!input.StartsWith("/", StringComparison.Ordinal))
        {
            return (string.Empty, input);
        }

        var separator = input.IndexOf(' ');
        return separator < 0
            ? (input.ToLowerInvariant(), string.Empty)
            : (input[..separator].ToLowerInvariant(), input[(separator + 1)..].Trim());
    }

    private sealed record Generation(
        string? InputItemId,
        CancellationTokenSource Cancellation);
}

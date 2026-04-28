// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// Voice assistant that uses MCP (Model Context Protocol) servers to give the model
/// access to external tools and data sources via the VoiceLive MCP API.
/// Requires API version 2026-01-01-preview.
/// </summary>
public class MCPVoiceAssistant : IDisposable
{
    private readonly VoiceLiveClient _client;
    private readonly string _model;
    private readonly string _voice;
    private readonly string _instructions;
    private readonly ILogger<MCPVoiceAssistant> _logger;
    private readonly ILoggerFactory _loggerFactory;

    private VoiceLiveSession? _session;
    private AudioProcessor? _audioProcessor;
    private bool _disposed;

    public MCPVoiceAssistant(
        VoiceLiveClient client,
        string model,
        string voice,
        string instructions,
        ILoggerFactory loggerFactory)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _model = model ?? throw new ArgumentNullException(nameof(model));
        _voice = voice ?? throw new ArgumentNullException(nameof(voice));
        _instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        _logger = loggerFactory.CreateLogger<MCPVoiceAssistant>();
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Connecting to VoiceLive with MCP tools, model: {Model}", _model);

            _session = await _client.StartSessionAsync(_model, cancellationToken).ConfigureAwait(false);
            _audioProcessor = new AudioProcessor(_session, _loggerFactory.CreateLogger<AudioProcessor>());

            await SetupSessionAsync(cancellationToken).ConfigureAwait(false);

            await _audioProcessor.StartPlaybackAsync().ConfigureAwait(false);
            await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);

            Console.WriteLine();
            Console.WriteLine("=" + new string('=', 59));
            Console.WriteLine("MCP VOICE ASSISTANT READY");
            Console.WriteLine("MCP tools: deepwiki, azure_doc");
            Console.WriteLine("Start speaking to begin conversation");
            Console.WriteLine("Press Ctrl+C to exit");
            Console.WriteLine("=" + new string('=', 59));
            Console.WriteLine();

            await ProcessEventsAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Shutting down...");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Connection error");
            throw;
        }
        finally
        {
            if (_audioProcessor != null)
                await _audioProcessor.CleanupAsync().ConfigureAwait(false);
        }
    }

    private async Task SetupSessionAsync(CancellationToken cancellationToken)
    {
        var sessionOptions = new VoiceLiveSessionOptions
        {
            Model = _model,
            Instructions = _instructions,
            Voice = new AzureStandardVoice(_voice),
            InputAudioFormat = InputAudioFormat.Pcm16,
            OutputAudioFormat = OutputAudioFormat.Pcm16,
            InputAudioEchoCancellation = new AudioEchoCancellation(),
            InputAudioNoiseReduction = new AudioNoiseReduction(),
            TurnDetection = new ServerVadTurnDetection
            {
                Threshold = 0.5f,
                PrefixPadding = TimeSpan.FromMilliseconds(300),
                SilenceDuration = TimeSpan.FromMilliseconds(500)
            },
            InputAudioTranscription = new AudioInputTranscriptionOptions()
        };

        sessionOptions.Modalities.Clear();
        sessionOptions.Modalities.Add(InteractionModality.Text);
        sessionOptions.Modalities.Add(InteractionModality.Audio);

        // Register MCP servers — both set to never require approval since
        // MCPApprovalResponseRequestItem is not available for sending approvals from client code.
        sessionOptions.Tools.Add(new VoiceLiveMcpServerDefinition("deepwiki", "https://mcp.deepwiki.com/mcp")
        {
            RequireApproval = BinaryData.FromObjectAsJson(MCPApprovalType.Never),
            AllowedTools = { "read_wiki_structure", "ask_question" }
        });

        sessionOptions.Tools.Add(new VoiceLiveMcpServerDefinition("azure_doc", "https://learn.microsoft.com/api/mcp")
        {
            RequireApproval = BinaryData.FromObjectAsJson(MCPApprovalType.Never)
        });

        await _session!.ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);
        _logger.LogInformation("Session configured with {ToolCount} MCP server(s)", sessionOptions.Tools.Count);
    }

    private async Task ProcessEventsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (SessionUpdate update in _session!.GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                await HandleUpdateAsync(update, cancellationToken).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Event processing cancelled");
        }
    }

    private async Task HandleUpdateAsync(SessionUpdate update, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Received event: {EventType}", update.GetType().Name);

        switch (update)
        {
            case SessionUpdateSessionCreated sessionCreated:
                _logger.LogInformation("Session ready: {SessionId}", sessionCreated.Session?.Id);
                break;

            case SessionUpdateSessionUpdated:
                _logger.LogInformation("Session updated");
                break;

            // MCP tool discovery events
            case SessionUpdateMcpListToolsInProgress inProgress:
                _logger.LogInformation("Discovering MCP tools (item: {ItemId})", inProgress.ItemId);
                Console.WriteLine("[MCP] Discovering tools from MCP server...");
                break;

            case SessionUpdateMcpListToolsCompleted completed:
                _logger.LogInformation("MCP tools loaded (item: {ItemId})", completed.ItemId);
                Console.WriteLine("[MCP] MCP tools ready");
                break;

            case SessionUpdateMcpListToolsFailed failed:
                _logger.LogWarning("Failed to load MCP tools (item: {ItemId})", failed.ItemId);
                Console.WriteLine("[MCP] Failed to load MCP tools");
                break;

            // MCP tool call events
            case SessionUpdateResponseMcpCallInProgress callInProgress:
                _logger.LogInformation("MCP call in progress (item: {ItemId})", callInProgress.ItemId);
                Console.WriteLine("[MCP] Calling MCP tool...");
                break;

            case SessionUpdateResponseMcpCallCompleted callCompleted:
                _logger.LogInformation("MCP call completed (item: {ItemId})", callCompleted.ItemId);
                Console.WriteLine("[MCP] Tool call completed");
                break;

            case SessionUpdateResponseMcpCallFailed callFailed:
                _logger.LogWarning("MCP call failed (item: {ItemId})", callFailed.ItemId);
                Console.WriteLine("[MCP] Tool call failed");
                break;

            case SessionUpdateConversationItemInputAudioTranscriptionCompleted transcription:
                Console.WriteLine($"[User]: {transcription.Transcript}");
                _logger.LogInformation("User: {Transcript}", transcription.Transcript);
                break;

            case SessionUpdateInputAudioBufferSpeechStarted:
                Console.WriteLine("Listening...");
                if (_audioProcessor != null)
                    await _audioProcessor.StopPlaybackAsync().ConfigureAwait(false);

                try { await _session!.CancelResponseAsync(cancellationToken).ConfigureAwait(false); }
                catch (Exception ex) { _logger.LogDebug(ex, "No response to cancel"); }
                break;

            case SessionUpdateInputAudioBufferSpeechStopped:
                Console.WriteLine("Processing...");
                if (_audioProcessor != null)
                    await _audioProcessor.StartPlaybackAsync().ConfigureAwait(false);
                break;

            case SessionUpdateResponseCreated:
                _logger.LogInformation("Response started");
                break;

            case SessionUpdateResponseAudioTranscriptDone transcriptDone:
                if (!string.IsNullOrEmpty(transcriptDone.Transcript))
                {
                    Console.WriteLine($"[Assistant]: {transcriptDone.Transcript}");
                    _logger.LogInformation("Assistant: {Transcript}", transcriptDone.Transcript);
                }
                break;

            case SessionUpdateResponseAudioDelta audioDelta:
                if (audioDelta.Delta != null && _audioProcessor != null)
                    await _audioProcessor.QueueAudioAsync(audioDelta.Delta.ToArray()).ConfigureAwait(false);
                break;

            case SessionUpdateResponseAudioDone:
                _logger.LogInformation("Assistant finished speaking");
                Console.WriteLine("Ready...");
                break;

            case SessionUpdateResponseDone:
                _logger.LogInformation("Response complete");
                break;

            case SessionUpdateError errorEvent:
                _logger.LogError("Error: {ErrorMessage}", errorEvent.Error?.Message);
                Console.WriteLine($"Error: {errorEvent.Error?.Message}");
                break;
        }
    }

    public void Dispose()
    {
        if (_disposed) return;
        _audioProcessor?.Dispose();
        _session?.Dispose();
        _disposed = true;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.VoiceLive;

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// Basic voice assistant implementing the VoiceLive SDK patterns.
///</summary>
/// <remarks>
/// This sample now demonstrates some of the new convenience methods added to the VoiceLive SDK:
/// - ClearStreamingAudioAsync() - Clears all input audio currently being streamed
/// - CancelResponseAsync() - Cancels the current response generation (existing method)
/// - ConfigureSessionAsync() - Configures session options (existing method)
///
/// Additional convenience methods available but not shown in this sample:
/// - StartAudioTurnAsync() / EndAudioTurnAsync() / CancelAudioTurnAsync() - Audio turn management
/// - AppendAudioToTurnAsync() - Append audio data to an ongoing turn
/// - ConnectAvatarAsync() - Connect avatar with SDP for media negotiation
///
/// These methods provide a more developer-friendly API similar to the OpenAI SDK,
/// eliminating the need to manually construct and populate ClientEvent classes.
/// </remarks>
public class BasicVoiceAssistant : IDisposable
{
    private readonly VoiceLiveClient _client;
    private readonly string _model;
    private readonly string _voice;
    private readonly string _instructions;
    private readonly ILogger<BasicVoiceAssistant> _logger;
    private readonly ILoggerFactory _loggerFactory;

    private VoiceLiveSession? _session;
    private AudioProcessor? _audioProcessor;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the BasicVoiceAssistant class.
    /// </summary>
    /// <param name="client">The VoiceLive client.</param>
    /// <param name="model">The model to use.</param>
    /// <param name="voice">The voice to use.</param>
    /// <param name="instructions">The system instructions.</param>
    /// <param name="loggerFactory">Logger factory for creating loggers.</param>
    public BasicVoiceAssistant(
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
        _logger = loggerFactory.CreateLogger<BasicVoiceAssistant>();
    }

    /// <summary>
    /// Start the voice assistant session.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token for stopping the session.</param>
    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Connecting to VoiceLive API with model {Model}", _model);

            // Start VoiceLive session
            _session = await _client.StartSessionAsync(_model, cancellationToken).ConfigureAwait(false);

            // Initialize audio processor
            _audioProcessor = new AudioProcessor(_session, _loggerFactory.CreateLogger<AudioProcessor>());

            // Configure session for voice conversation
            await SetupSessionAsync(cancellationToken).ConfigureAwait(false);

            // Start audio systems
            await _audioProcessor.StartPlaybackAsync().ConfigureAwait(false);
            await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);

            _logger.LogInformation("Voice assistant ready! Start speaking...");
            Console.WriteLine();
            Console.WriteLine("=" + new string('=', 59));
            Console.WriteLine("🎤 VOICE ASSISTANT READY");
            Console.WriteLine("Start speaking to begin conversation");
            Console.WriteLine("Press Ctrl+C to exit");
            Console.WriteLine("=" + new string('=', 59));
            Console.WriteLine();

            // Process events
            await ProcessEventsAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Received cancellation signal, shutting down...");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Connection error");
            throw;
        }
        finally
        {
            // Cleanup
            if (_audioProcessor != null)
            {
                await _audioProcessor.CleanupAsync().ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Configure the VoiceLive session for audio conversation.
    /// </summary>
    private async Task SetupSessionAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Setting up voice conversation session...");

        // Azure voice
        var azureVoice = new AzureStandardVoice(_voice);

        // Create strongly typed turn detection configuration
        var turnDetectionConfig = new ServerVad
        {
            Threshold = 0.5f,
            PrefixPadding = TimeSpan.FromMilliseconds(300),
            SilenceDuration = TimeSpan.FromMilliseconds(500)
        };

        // Create conversation session options
        var sessionOptions = new VoiceLiveSessionOptions
        {
            InputAudioEchoCancellation = new AudioEchoCancellation(),
            Model = _model,
            Instructions = _instructions,
            Voice = azureVoice,
            InputAudioFormat = AudioFormat.Pcm16,
            OutputAudioFormat = AudioFormat.Pcm16,
            TurnDetection = turnDetectionConfig
        };

        // Ensure modalities include audio
        sessionOptions.Modalities.Clear();
        sessionOptions.Modalities.Add(InputModality.Text);
        sessionOptions.Modalities.Add(InputModality.Audio);

        await _session!.ConfigureSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);

        _logger.LogInformation("Session configuration sent");
    }

    /// <summary>
    /// Process events from the VoiceLive session.
    /// </summary>
    private async Task ProcessEventsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (SessionUpdate serverEvent in _session!.GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                await HandleSessionUpdateAsync(serverEvent, cancellationToken).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Event processing cancelled");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing events");
            throw;
        }
    }

    /// <summary>
    /// Handle different types of server events from VoiceLive.
    /// </summary>
    private async Task HandleSessionUpdateAsync(SessionUpdate serverEvent, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Received event: {EventType}", serverEvent.GetType().Name);

        switch (serverEvent)
        {
            case SessionUpdateSessionCreated sessionCreated:
                await HandleSessionCreatedAsync(sessionCreated, cancellationToken).ConfigureAwait(false);
                break;

            case SessionUpdateSessionUpdated sessionUpdated:
                _logger.LogInformation("Session updated successfully");

                // Start audio capture once session is ready
                if (_audioProcessor != null)
                {
                    await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);
                }
                break;

            case SessionUpdateInputAudioBufferSpeechStarted speechStarted:
                _logger.LogInformation("🎤 User started speaking - stopping playback");
                Console.WriteLine("🎤 Listening...");

                // Stop current assistant audio playback (interruption handling)
                if (_audioProcessor != null)
                {
                    await _audioProcessor.StopPlaybackAsync().ConfigureAwait(false);
                }

                // Cancel any ongoing response
                try
                {
                    await _session!.CancelResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "No response to cancel");
                }

                // Demonstrate the new ClearStreamingAudio convenience method
                try
                {
                    await _session!.ClearStreamingAudioAsync(cancellationToken).ConfigureAwait(false);
                    _logger.LogInformation("✨ Used ClearStreamingAudioAsync convenience method");
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "ClearStreamingAudio call failed (may not be supported in all scenarios)");
                }
                break;

            case SessionUpdateInputAudioBufferSpeechStopped speechStopped:
                _logger.LogInformation("🎤 User stopped speaking");
                Console.WriteLine("🤔 Processing...");

                // Restart playback system for response
                if (_audioProcessor != null)
                {
                    await _audioProcessor.StartPlaybackAsync().ConfigureAwait(false);
                }
                break;

            case SessionUpdateResponseCreated responseCreated:
                _logger.LogInformation("🤖 Assistant response created");
                break;

            case SessionUpdateResponseAudioDelta audioDelta:
                // Stream audio response to speakers
                _logger.LogDebug("Received audio delta");

                if (audioDelta.Delta != null && _audioProcessor != null)
                {
                    byte[] audioData = audioDelta.Delta.ToArray();
                    await _audioProcessor.QueueAudioAsync(audioData).ConfigureAwait(false);
                }
                break;

            case SessionUpdateResponseAudioDone audioDone:
                _logger.LogInformation("🤖 Assistant finished speaking");
                Console.WriteLine("🎤 Ready for next input...");
                break;

            case SessionUpdateResponseDone responseDone:
                _logger.LogInformation("✅ Response complete");
                break;

            case SessionUpdateError errorEvent:
                _logger.LogError("❌ VoiceLive error: {ErrorMessage}", errorEvent.Error?.Message);
                Console.WriteLine($"Error: {errorEvent.Error?.Message}");
                break;

            default:
                _logger.LogDebug("Unhandled event type: {EventType}", serverEvent.GetType().Name);
                break;
        }
    }

    /// <summary>
    /// Handle session created event.
    /// </summary>
    private async Task HandleSessionCreatedAsync(SessionUpdateSessionCreated sessionCreated, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Session ready: {SessionId}", sessionCreated.Session?.Id);

        // Start audio capture once session is ready
        if (_audioProcessor != null)
        {
            await _audioProcessor.StartCaptureAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Dispose of resources.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
            return;

        _audioProcessor?.Dispose();
        _session?.Dispose();
        _disposed = true;
    }
}

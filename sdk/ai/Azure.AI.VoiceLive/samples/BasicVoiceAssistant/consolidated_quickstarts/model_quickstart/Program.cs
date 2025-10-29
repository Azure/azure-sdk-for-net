// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CommandLine;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Channels;
using System.Collections.Generic;
using Azure.AI.VoiceLive;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NAudio.Wave;

namespace Azure.AI.VoiceLive.Samples
{
    /// <summary>
    /// FILE: Program.cs (Consolidated)
    /// </summary>
    /// <remarks>
    /// DESCRIPTION:
    ///     This consolidated sample demonstrates the fundamental capabilities of the VoiceLive SDK by creating
    ///     a basic voice assistant that can engage in natural conversation with proper interruption
    ///     handling. This serves as the foundational example that showcases the core value
    ///     proposition of unified speech-to-speech interaction.
    ///     
    ///     All necessary code has been consolidated into this single file for easy distribution and execution.
    ///
    /// USAGE:
    ///     dotnet run
    ///
    ///     Set the environment variables with your own values before running the sample:
    ///     1) AZURE_VOICELIVE_API_KEY - The Azure VoiceLive API key
    ///     2) AZURE_VOICELIVE_ENDPOINT - The Azure VoiceLive endpoint
    ///
    ///     Or update appsettings.json with your values.
    ///
    /// REQUIREMENTS:
    ///     - Azure.AI.VoiceLive
    ///     - Azure.Identity
    ///     - NAudio (for audio capture and playback)
    ///     - Microsoft.Extensions.Configuration
    ///     - System.CommandLine
    ///     - System.Threading.Channels
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// Main entry point for the Voice Assistant sample.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<int> Main(string[] args)
        {
            // Create command line interface
            var rootCommand = CreateRootCommand();
            return await rootCommand.InvokeAsync(args).ConfigureAwait(false);
        }

        private static RootCommand CreateRootCommand()
        {
            var rootCommand = new RootCommand("Basic Voice Assistant using Azure VoiceLive SDK");

            var apiKeyOption = new Option<string?>(
                "--api-key",
                "Azure VoiceLive API key. If not provided, will use AZURE_VOICELIVE_API_KEY environment variable.");

            var endpointOption = new Option<string>(
                "--endpoint",
                () => "wss://api.voicelive.com/v1",
                "Azure VoiceLive endpoint");

            var modelOption = new Option<string>(
                "--model",
                () => "gpt-4o",
                "VoiceLive model to use");

            var voiceOption = new Option<string>(
                "--voice",
                () => "en-US-AvaNeural",
                "Voice to use for the assistant");

            var instructionsOption = new Option<string>(
                "--instructions",
                () => "You are a helpful AI assistant. Respond naturally and conversationally. Keep your responses concise but engaging.",
                "System instructions for the AI assistant");

            var useTokenCredentialOption = new Option<bool>(
                "--use-token-credential",
                "Use Azure token credential instead of API key");

            var verboseOption = new Option<bool>(
                "--verbose",
                "Enable verbose logging");

            rootCommand.AddOption(apiKeyOption);
            rootCommand.AddOption(endpointOption);
            rootCommand.AddOption(modelOption);
            rootCommand.AddOption(voiceOption);
            rootCommand.AddOption(instructionsOption);
            rootCommand.AddOption(useTokenCredentialOption);
            rootCommand.AddOption(verboseOption);

            rootCommand.SetHandler(async (
                string? apiKey,
                string endpoint,
                string model,
                string voice,
                string instructions,
                bool useTokenCredential,
                bool verbose) =>
            {
                await RunVoiceAssistantAsync(apiKey, endpoint, model, voice, instructions, useTokenCredential, verbose).ConfigureAwait(false);
            },
            apiKeyOption,
            endpointOption,
            modelOption,
            voiceOption,
            instructionsOption,
            useTokenCredentialOption,
            verboseOption);

            return rootCommand;
        }

        private static async Task RunVoiceAssistantAsync(
            string? apiKey,
            string endpoint,
            string model,
            string voice,
            string instructions,
            bool useTokenCredential,
            bool verbose)
        {
            // Setup configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Override with command line values if provided
            apiKey ??= configuration["VoiceLive:ApiKey"] ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_API_KEY");
            endpoint = configuration["VoiceLive:Endpoint"] ?? endpoint;
            model = configuration["VoiceLive:Model"] ?? model;
            voice = configuration["VoiceLive:Voice"] ?? voice;
            instructions = configuration["VoiceLive:Instructions"] ?? instructions;

            // Setup logging
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                if (verbose)
                {
                    builder.SetMinimumLevel(LogLevel.Debug);
                }
                else
                {
                    builder.SetMinimumLevel(LogLevel.Information);
                }
            });

            var logger = loggerFactory.CreateLogger<Program>();

            // Validate credentials
            if (string.IsNullOrEmpty(apiKey) && !useTokenCredential)
            {
                Console.WriteLine("❌ Error: No authentication provided");
                Console.WriteLine("Please provide an API key using --api-key or set AZURE_VOICELIVE_API_KEY environment variable,");
                Console.WriteLine("or use --use-token-credential for Azure authentication.");
                return;
            }

            // Check audio system before starting
            if (!CheckAudioSystem(logger))
            {
                return;
            }

            try
            {
                // Create client with appropriate credential
                VoiceLiveClient client;
                if (useTokenCredential)
                {
                    var tokenCredential = new DefaultAzureCredential();
                    client = new VoiceLiveClient(new Uri(endpoint), tokenCredential, new VoiceLiveClientOptions());
                    logger.LogInformation("Using Azure token credential");
                }
                else
                {
                    var keyCredential = new Azure.AzureKeyCredential(apiKey!);
                    client = new VoiceLiveClient(new Uri(endpoint), keyCredential, new VoiceLiveClientOptions());
                    logger.LogInformation("Using API key credential");
                }

                // Create and start voice assistant
                using var assistant = new BasicVoiceAssistant(
                    client,
                    model,
                    voice,
                    instructions,
                    loggerFactory);

                // Setup cancellation token for graceful shutdown
                using var cancellationTokenSource = new CancellationTokenSource();
                Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    logger.LogInformation("Received shutdown signal");
                    cancellationTokenSource.Cancel();
                };

                // Start the assistant
                await assistant.StartAsync(cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n👋 Voice assistant shut down. Goodbye!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Fatal error");
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        private static bool CheckAudioSystem(ILogger logger)
        {
            try
            {
                // Try input (default device)
                using (var waveIn = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(24000, 16, 1),
                    BufferMilliseconds = 50
                })
                {
                    // Start/Stop to force initialization and surface any device errors
                    waveIn.DataAvailable += (_, __) => { };
                    waveIn.StartRecording();
                    waveIn.StopRecording();
                }

                // Try output (default device)
                var buffer = new BufferedWaveProvider(new WaveFormat(24000, 16, 1))
                {
                    BufferDuration = TimeSpan.FromMilliseconds(200)
                };

                using (var waveOut = new WaveOutEvent { DesiredLatency = 100 })
                {
                    waveOut.Init(buffer);
                    // Playing isn't strictly required to validate a device, but it's safe
                    waveOut.Play();
                    waveOut.Stop();
                }

                logger.LogInformation("Audio system check passed (default input/output initialized).");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Audio system check failed: {ex.Message}");
                return false;
            }
        }
    }

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
            var turnDetectionConfig = new ServerVadTurnDetection
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
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16,
                TurnDetection = turnDetectionConfig
            };

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InteractionModality.Text);
            sessionOptions.Modalities.Add(InteractionModality.Audio);

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

    /// <summary>
    /// Handles real-time audio capture and playback for the voice assistant.
    ///
    /// This processor demonstrates some of the new VoiceLive SDK convenience methods:
    /// - Uses existing SendInputAudioAsync() method for audio streaming
    /// - Shows how convenience methods simplify audio operations
    ///
    /// Additional convenience methods available in the SDK:
    /// - StartAudioTurnAsync() / AppendAudioToTurnAsync() / EndAudioTurnAsync() - Audio turn management
    /// - ClearStreamingAudioAsync() - Clear all streaming audio
    /// - ConnectAvatarAsync() - Avatar connection with SDP
    ///
    /// Threading Architecture:
    /// - Main thread: Event loop and UI
    /// - Capture thread: NAudio input stream reading
    /// - Send thread: Async audio data transmission to VoiceLive
    /// - Playback thread: NAudio output stream writing
    /// </summary>
    public class AudioProcessor : IDisposable
    {
        private readonly VoiceLiveSession _session;
        private readonly ILogger<AudioProcessor> _logger;

        // Audio configuration - PCM16, 24kHz, mono as specified
        private const int SampleRate = 24000;
        private const int Channels = 1;
        private const int BitsPerSample = 16;

        // NAudio components
        private WaveInEvent? _waveIn;
        private WaveOutEvent? _waveOut;
        private BufferedWaveProvider? _playbackBuffer;

        // Audio capture and playback state
        private bool _isCapturing;
        private bool _isPlaying;

        // Audio streaming channels
        private readonly Channel<byte[]> _audioSendChannel;
        private readonly Channel<byte[]> _audioPlaybackChannel;
        private readonly ChannelWriter<byte[]> _audioSendWriter;
        private readonly ChannelReader<byte[]> _audioSendReader;
        private readonly ChannelWriter<byte[]> _audioPlaybackWriter;
        private readonly ChannelReader<byte[]> _audioPlaybackReader;

        // Background tasks
        private Task? _audioSendTask;
        private Task? _audioPlaybackTask;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private CancellationTokenSource _playbackCancellationTokenSource;

        /// <summary>
        /// Initializes a new instance of the AudioProcessor class.
        /// </summary>
        /// <param name="session">The VoiceLive session for audio communication.</param>
        /// <param name="logger">Logger for diagnostic information.</param>
        public AudioProcessor(VoiceLiveSession session, ILogger<AudioProcessor> logger)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // Create unbounded channels for audio data
            _audioSendChannel = Channel.CreateUnbounded<byte[]>();
            _audioSendWriter = _audioSendChannel.Writer;
            _audioSendReader = _audioSendChannel.Reader;

            _audioPlaybackChannel = Channel.CreateUnbounded<byte[]>();
            _audioPlaybackWriter = _audioPlaybackChannel.Writer;
            _audioPlaybackReader = _audioPlaybackChannel.Reader;

            _cancellationTokenSource = new CancellationTokenSource();
            _playbackCancellationTokenSource = new CancellationTokenSource();

            _logger.LogInformation("AudioProcessor initialized with {SampleRate}Hz PCM16 mono audio", SampleRate);
        }

        /// <summary>
        /// Start capturing audio from microphone.
        /// </summary>
        public Task StartCaptureAsync()
        {
            if (_isCapturing)
                return Task.CompletedTask;

            _isCapturing = true;

            try
            {
                _waveIn = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(SampleRate, BitsPerSample, Channels),
                    BufferMilliseconds = 50 // 50ms buffer for low latency
                };

                _waveIn.DataAvailable += OnAudioDataAvailable;
                _waveIn.RecordingStopped += OnRecordingStopped;

                _waveIn.DeviceNumber = 0;

                _waveIn.StartRecording();

                // Start audio send task
                _audioSendTask = ProcessAudioSendAsync(_cancellationTokenSource.Token);

                _logger.LogInformation("Started audio capture");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start audio capture");
                _isCapturing = false;
                throw;
            }
        }

        /// <summary>
        /// Stop capturing audio.
        /// </summary>
        public async Task StopCaptureAsync()
        {
            if (!_isCapturing)
                return;

            _isCapturing = false;

            if (_waveIn != null)
            {
                _waveIn.StopRecording();
                _waveIn.DataAvailable -= OnAudioDataAvailable;
                _waveIn.RecordingStopped -= OnRecordingStopped;
                _waveIn.Dispose();
                _waveIn = null;
            }

            // Complete the send channel and wait for the send task
            _audioSendWriter.TryComplete();
            if (_audioSendTask != null)
            {
                await _audioSendTask.ConfigureAwait(false);
                _audioSendTask = null;
            }

            _logger.LogInformation("Stopped audio capture");
        }

        /// <summary>
        /// Initialize audio playback system.
        /// </summary>
        public Task StartPlaybackAsync()
        {
            if (_isPlaying)
                return Task.CompletedTask;

            _isPlaying = true;

            try
            {
                _waveOut = new WaveOutEvent
                {
                    DesiredLatency = 100 // 100ms latency
                };

                _playbackBuffer = new BufferedWaveProvider(new WaveFormat(SampleRate, BitsPerSample, Channels))
                {
                    BufferDuration = TimeSpan.FromMinutes(5), // 5 second buffer
                    DiscardOnBufferOverflow = true
                };

                _waveOut.Init(_playbackBuffer);
                _waveOut.Play();

                _playbackCancellationTokenSource = new CancellationTokenSource();

                // Start audio playback task
                _audioPlaybackTask = ProcessAudioPlaybackAsync();

                _logger.LogInformation("Audio playback system ready");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize audio playback");
                _isPlaying = false;
                throw;
            }
        }

        /// <summary>
        /// Stop audio playback and clear buffer.
        /// </summary>
        public async Task StopPlaybackAsync()
        {
            if (!_isPlaying)
                return;

            _isPlaying = false;

            // Clear the playback channel
            while (_audioPlaybackReader.TryRead(out _))
            { }

            if (_playbackBuffer != null)
            {
                _playbackBuffer.ClearBuffer();
            }

            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
                _waveOut = null;
            }

            _playbackBuffer = null;

            // Complete the playback channel and wait for the playback task
            _playbackCancellationTokenSource.Cancel();

            if (_audioPlaybackTask != null)
            {
                await _audioPlaybackTask.ConfigureAwait(false);
                _audioPlaybackTask = null;
            }

            _logger.LogInformation("Stopped audio playback");
        }

        /// <summary>
        /// Queue audio data for playback.
        /// </summary>
        /// <param name="audioData">The audio data to queue.</param>
        public async Task QueueAudioAsync(byte[] audioData)
        {
            if (_isPlaying && audioData.Length > 0)
            {
                await _audioPlaybackWriter.WriteAsync(audioData).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Event handler for audio data available from microphone.
        /// </summary>
        private void OnAudioDataAvailable(object? sender, WaveInEventArgs e)
        {
            if (_isCapturing && e.BytesRecorded > 0)
            {
                byte[] audioData = new byte[e.BytesRecorded];
                Array.Copy(e.Buffer, 0, audioData, 0, e.BytesRecorded);

                // Queue audio data for sending (non-blocking)
                if (!_audioSendWriter.TryWrite(audioData))
                {
                    _logger.LogWarning("Failed to queue audio data for sending - channel may be full");
                }
            }
        }

        /// <summary>
        /// Event handler for recording stopped.
        /// </summary>
        private void OnRecordingStopped(object? sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                _logger.LogError(e.Exception, "Audio recording stopped due to error");
            }
        }

        /// <summary>
        /// Background task to process audio data and send to VoiceLive service.
        /// </summary>
        private async Task ProcessAudioSendAsync(CancellationToken cancellationToken)
        {
            try
            {
                await foreach (byte[] audioData in _audioSendReader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    try
                    {
                        // Send audio data directly to the session using the convenience method
                        // This demonstrates the existing SendInputAudioAsync convenience method
                        // Other available methods: StartAudioTurnAsync, AppendAudioToTurnAsync, EndAudioTurnAsync
                        await _session.SendInputAudioAsync(audioData, cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error sending audio data to VoiceLive");
                        // Continue processing other audio data
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when cancellation is requested
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in audio send processing");
            }
        }

        /// <summary>
        /// Background task to process audio playback.
        /// </summary>
        private async Task ProcessAudioPlaybackAsync()
        {
            try
            {
                CancellationTokenSource combinedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_playbackCancellationTokenSource.Token, _cancellationTokenSource.Token);
                var cancellationToken = combinedTokenSource.Token;

                await foreach (byte[] audioData in _audioPlaybackReader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    try
                    {
                        if (_playbackBuffer != null && _isPlaying)
                        {
                            _playbackBuffer.AddSamples(audioData, 0, audioData.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error in audio playback");
                        // Continue processing other audio data
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when cancellation is requested
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in audio playback processing");
            }
        }

        /// <summary>
        /// Clean up audio resources.
        /// </summary>
        public async Task CleanupAsync()
        {
            await StopCaptureAsync().ConfigureAwait(false);
            await StopPlaybackAsync().ConfigureAwait(false);

            _cancellationTokenSource.Cancel();

            // Wait for background tasks to complete
            var tasks = new List<Task>();
            if (_audioSendTask != null)
                tasks.Add(_audioSendTask);
            if (_audioPlaybackTask != null)
                tasks.Add(_audioPlaybackTask);

            if (tasks.Count > 0)
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }

            _logger.LogInformation("Audio processor cleaned up");
        }

        /// <summary>
        /// Dispose of resources.
        /// </summary>
        public void Dispose()
        {
            CleanupAsync().Wait();
            _cancellationTokenSource.Dispose();
        }
    }
}
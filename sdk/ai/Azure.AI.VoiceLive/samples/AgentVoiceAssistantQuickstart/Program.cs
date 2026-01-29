// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading;
using System.Web;
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
    /// FILE: Program.cs (Agent Quickstart - Consolidated)
    /// </summary>
    /// <remarks>
    /// DESCRIPTION:
    ///     This consolidated sample demonstrates connecting to an Azure AI Foundry agent via the VoiceLive SDK,
    ///     creating a voice assistant that can engage in natural conversation with proper interruption
    ///     handling. Instead of using a direct model, this connects to a deployed agent in Azure AI Foundry.
    ///     
    ///     All necessary code has been consolidated into this single file for easy distribution and execution.
    ///
    /// USAGE:
    ///     dotnet run --agent-id <agent-id> --agent-project-name <project-name>
    ///
    ///     Set the environment variables with your own values before running the sample:
    ///     1) AZURE_AGENT_ID - The Azure AI Foundry agent ID
    ///     2) AZURE_AGENT_PROJECT_NAME - The Azure AI Foundry agent project name  
    ///     3) AZURE_VOICELIVE_API_KEY - The Azure VoiceLive API key (still needed for VoiceLive service)
    ///     4) AZURE_VOICELIVE_ENDPOINT - The Azure VoiceLive endpoint
    ///
    ///     Note: Agent access token is generated automatically using DefaultAzureCredential.
    ///     Ensure you are authenticated with Azure CLI or have appropriate credentials configured.
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
            var rootCommand = new RootCommand("Voice Assistant connecting to Azure AI Foundry Agent via VoiceLive SDK");

            var apiKeyOption = new Option<string?>(
                "--api-key",
                "Azure VoiceLive API key. If not provided, will use AZURE_VOICELIVE_API_KEY environment variable.");

            var endpointOption = new Option<string>(
                "--endpoint",
                () => "wss://api.voicelive.com/v1",
                "Azure VoiceLive endpoint");

            var agentIdOption = new Option<string>(
                "--agent-id",
                "Azure AI Foundry agent ID");

            var agentProjectNameOption = new Option<string>(
                "--agent-project-name", 
                "Azure AI Foundry agent project name");

            var voiceOption = new Option<string>(
                "--voice",
                () => "en-US-AvaNeural",
                "Voice to use for the assistant");

            var useTokenCredentialOption = new Option<bool>(
                "--use-token-credential",
                "Use Azure token credential instead of API key");

            var verboseOption = new Option<bool>(
                "--verbose",
                "Enable verbose logging");

            rootCommand.AddOption(apiKeyOption);
            rootCommand.AddOption(endpointOption);
            rootCommand.AddOption(agentIdOption);
            rootCommand.AddOption(agentProjectNameOption);
            rootCommand.AddOption(voiceOption);
            rootCommand.AddOption(useTokenCredentialOption);
            rootCommand.AddOption(verboseOption);

            rootCommand.SetHandler(async (
                string? apiKey,
                string endpoint,
                string? agentId,
                string? agentProjectName,
                string voice,
                bool useTokenCredential,
                bool verbose) =>
            {
                await RunVoiceAssistantAsync(apiKey, endpoint, agentId, agentProjectName, voice, useTokenCredential, verbose).ConfigureAwait(false);
            },
            apiKeyOption,
            endpointOption,
            agentIdOption,
            agentProjectNameOption,
            voiceOption,
            useTokenCredentialOption,
            verboseOption);

            return rootCommand;
        }

        private static async Task RunVoiceAssistantAsync(
            string? apiKey,
            string endpoint,
            string? agentId,
            string? agentProjectName,
            string voice,
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
            agentId ??= configuration["Agent:Id"] ?? Environment.GetEnvironmentVariable("AZURE_AGENT_ID");
            agentProjectName ??= configuration["Agent:ProjectName"] ?? Environment.GetEnvironmentVariable("AZURE_AGENT_PROJECT_NAME");
            voice = configuration["VoiceLive:Voice"] ?? voice;

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

            // Validate agent credentials
            if (string.IsNullOrEmpty(agentId) || string.IsNullOrEmpty(agentProjectName))
            {
                Console.WriteLine("❌ Error: Agent parameters missing");
                Console.WriteLine("Please provide agent parameters:");
                Console.WriteLine("  --agent-id (or AZURE_AGENT_ID environment variable)");
                Console.WriteLine("  --agent-project-name (or AZURE_AGENT_PROJECT_NAME environment variable)");
                Console.WriteLine("Note: Agent access token will be generated automatically using Azure credentials");
                return;
            }

            // Validate VoiceLive credentials (still needed for the VoiceLive service)
            if (string.IsNullOrEmpty(apiKey) && !useTokenCredential)
            {
                Console.WriteLine("❌ Error: No VoiceLive authentication provided");
                Console.WriteLine("Please provide an API key using --api-key or set AZURE_VOICELIVE_API_KEY environment variable,");
                Console.WriteLine("or use --use-token-credential for Azure authentication.");
                return;
            }

            // Generate agent access token using Azure credentials
            string agentAccessToken;
            try
            {
                logger.LogInformation("Generating agent access token using DefaultAzureCredential...");
                var credential = new DefaultAzureCredential();
                var tokenRequestContext = new TokenRequestContext(new[] { "https://ai.azure.com/.default" });
                var accessToken = await credential.GetTokenAsync(tokenRequestContext, default).ConfigureAwait(false);
                agentAccessToken = accessToken.Token;
                logger.LogInformation("Obtained agent access token successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error generating agent access token: {ex.Message}");
                Console.WriteLine("Please ensure you are authenticated with Azure CLI or have appropriate Azure credentials configured.");
                return;
            }

            // Check audio system before starting
            if (!CheckAudioSystem(logger))
            {
                return;
            }

            try
            {
                // Append agent parameters to the endpoint URL
                var uriBuilder = new UriBuilder(endpoint);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["agent-id"] = agentId!;
                query["agent-project-name"] = agentProjectName!;
                query["agent-access-token"] = agentAccessToken;
                uriBuilder.Query = query.ToString();
                endpoint = uriBuilder.ToString();
                logger.LogInformation("Agent parameters added as query parameters: agent-id={AgentId}, agent-project-name={ProjectName}", agentId, agentProjectName);
                
                VoiceLiveClient client;
                var endpointUri = new Uri(endpoint);
                if (useTokenCredential)
                {
                    var tokenCredential = new DefaultAzureCredential();
                    client = new VoiceLiveClient(endpointUri, tokenCredential, new VoiceLiveClientOptions());
                    logger.LogInformation("Using Azure token credential with agent headers");
                }
                else
                {
                    var keyCredential = new Azure.AzureKeyCredential(apiKey!);
                    client = new VoiceLiveClient(endpointUri, keyCredential, new VoiceLiveClientOptions());
                    logger.LogInformation("Using API key credential with agent headers");
                }

                // Create and start voice assistant
                using var assistant = new BasicVoiceAssistant(
                    client,
                    agentId!,
                    agentProjectName!,
                    agentAccessToken,
                    voice,
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
        private readonly string _agentId;
        private readonly string _agentProjectName;
        private readonly string _agentAccessToken;
        private readonly string _voice;
        private readonly ILogger<BasicVoiceAssistant> _logger;
        private readonly ILoggerFactory _loggerFactory;

        private VoiceLiveSession? _session;
        private AudioProcessor? _audioProcessor;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the BasicVoiceAssistant class.
        /// </summary>
        /// <param name="client">The VoiceLive client.</param>
        /// <param name="agentId">The Azure AI Foundry agent ID.</param>
        /// <param name="agentProjectName">The Azure AI Foundry agent project name.</param>
        /// <param name="agentAccessToken">The Azure AI Foundry agent access token.</param>
        /// <param name="voice">The voice to use.</param>
        /// <param name="loggerFactory">Logger factory for creating loggers.</param>
        public BasicVoiceAssistant(
            VoiceLiveClient client,
            string agentId,
            string agentProjectName,
            string agentAccessToken,
            string voice,
            ILoggerFactory loggerFactory)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _agentId = agentId ?? throw new ArgumentNullException(nameof(agentId));
            _agentProjectName = agentProjectName ?? throw new ArgumentNullException(nameof(agentProjectName));
            _agentAccessToken = agentAccessToken ?? throw new ArgumentNullException(nameof(agentAccessToken));
            _voice = voice ?? throw new ArgumentNullException(nameof(voice));
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
                _logger.LogInformation("Connecting to VoiceLive API with agent {AgentId} from project {ProjectName}", _agentId, _agentProjectName);

                // Create session options for agent connection (no model or instructions specified)
                var sessionOptions = await CreateSessionOptionsAsync(cancellationToken).ConfigureAwait(false);
                
                // Start VoiceLive session with agent parameters passed via headers in client
                _session = await _client.StartSessionAsync(sessionOptions, cancellationToken).ConfigureAwait(false);

                // Initialize audio processor
                _audioProcessor = new AudioProcessor(_session, _loggerFactory.CreateLogger<AudioProcessor>());

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
        /// Create session options for agent-based voice conversation.
        /// </summary>
        private Task<VoiceLiveSessionOptions> CreateSessionOptionsAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating voice conversation session options for agent...");

            // Azure voice
            var azureVoice = new AzureStandardVoice(_voice);

            // Create strongly typed turn detection configuration
            var turnDetectionConfig = new ServerVadTurnDetection
            {
                Threshold = 0.5f,
                PrefixPadding = TimeSpan.FromMilliseconds(300),
                SilenceDuration = TimeSpan.FromMilliseconds(500)
            };

            // Create conversation session options for agent - no Model or Instructions specified
            // Agent parameters are passed via URI query parameters during WebSocket connection:
            // - agent-id: Agent identifier
            // - agent-project-name: Project containing the agent  
            // - agent-access-token: Generated access token for agent authentication
            var sessionOptions = new VoiceLiveSessionOptions
            {
                InputAudioEchoCancellation = new AudioEchoCancellation(),
                Voice = azureVoice,
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16,
                TurnDetection = turnDetectionConfig
            };

            // Ensure modalities include audio
            sessionOptions.Modalities.Clear();
            sessionOptions.Modalities.Add(InteractionModality.Text);
            sessionOptions.Modalities.Add(InteractionModality.Audio);

            _logger.LogInformation("Session options created for agent connection");
            return Task.FromResult(sessionOptions);
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
                    BufferDuration = TimeSpan.FromSeconds(5), // 5 second buffer
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
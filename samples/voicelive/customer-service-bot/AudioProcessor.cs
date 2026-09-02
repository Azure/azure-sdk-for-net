// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Channels;
using NAudio.Wave;

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// Handles real-time audio capture and playback for the voice assistant.
/// </summary>
/// <remarks>
/// Threading Architecture:
/// - Main thread: Event loop and UI
/// - Capture thread: NAudio input stream reading
/// - Send thread: Async audio data transmission to VoiceLive
/// - Playback thread: NAudio output stream writing
/// </remarks>
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

            /*
            _logger.LogInformation($"There are {WaveIn.DeviceCount} devices available.");
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var deviceInfo = WaveIn.GetCapabilities(i);

                _logger.LogInformation($"{i}: {deviceInfo.ProductName}");
            }
            */
            _waveIn.DeviceNumber = 0; // Default to first device

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
                    // Send audio data directly to the session
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

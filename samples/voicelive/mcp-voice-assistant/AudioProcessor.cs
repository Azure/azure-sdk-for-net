// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Channels;
using NAudio.Wave;

namespace Azure.AI.VoiceLive.Samples;

public class AudioProcessor : IDisposable
{
    private readonly VoiceLiveSession _session;
    private readonly ILogger<AudioProcessor> _logger;

    private const int SampleRate = 24000;
    private const int Channels = 1;
    private const int BitsPerSample = 16;

    private WaveInEvent? _waveIn;
    private WaveOutEvent? _waveOut;
    private BufferedWaveProvider? _playbackBuffer;

    private bool _isCapturing;
    private bool _isPlaying;

    private readonly Channel<byte[]> _audioSendChannel;
    private readonly Channel<byte[]> _audioPlaybackChannel;
    private readonly ChannelWriter<byte[]> _audioSendWriter;
    private readonly ChannelReader<byte[]> _audioSendReader;
    private readonly ChannelWriter<byte[]> _audioPlaybackWriter;
    private readonly ChannelReader<byte[]> _audioPlaybackReader;

    private Task? _audioSendTask;
    private Task? _audioPlaybackTask;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private CancellationTokenSource _playbackCancellationTokenSource;

    public AudioProcessor(VoiceLiveSession session, ILogger<AudioProcessor> logger)
    {
        _session = session ?? throw new ArgumentNullException(nameof(session));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _audioSendChannel = Channel.CreateUnbounded<byte[]>();
        _audioSendWriter = _audioSendChannel.Writer;
        _audioSendReader = _audioSendChannel.Reader;

        _audioPlaybackChannel = Channel.CreateUnbounded<byte[]>();
        _audioPlaybackWriter = _audioPlaybackChannel.Writer;
        _audioPlaybackReader = _audioPlaybackChannel.Reader;

        _cancellationTokenSource = new CancellationTokenSource();
        _playbackCancellationTokenSource = new CancellationTokenSource();
    }

    public Task StartCaptureAsync()
    {
        if (_isCapturing)
            return Task.CompletedTask;

        _isCapturing = true;

        _waveIn = new WaveInEvent
        {
            WaveFormat = new WaveFormat(SampleRate, BitsPerSample, Channels),
            BufferMilliseconds = 50
        };

        _waveIn.DataAvailable += OnAudioDataAvailable;
        _waveIn.RecordingStopped += OnRecordingStopped;
        _waveIn.DeviceNumber = 0;
        _waveIn.StartRecording();

        _audioSendTask = ProcessAudioSendAsync(_cancellationTokenSource.Token);

        _logger.LogInformation("Started audio capture");
        return Task.CompletedTask;
    }

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

        _audioSendWriter.TryComplete();
        if (_audioSendTask != null)
        {
            await _audioSendTask.ConfigureAwait(false);
            _audioSendTask = null;
        }
    }

    public Task StartPlaybackAsync()
    {
        if (_isPlaying)
            return Task.CompletedTask;

        _isPlaying = true;

        _waveOut = new WaveOutEvent { DesiredLatency = 100 };
        _playbackBuffer = new BufferedWaveProvider(new WaveFormat(SampleRate, BitsPerSample, Channels))
        {
            BufferDuration = TimeSpan.FromMinutes(5),
            DiscardOnBufferOverflow = true
        };

        _waveOut.Init(_playbackBuffer);
        _waveOut.Play();

        _playbackCancellationTokenSource = new CancellationTokenSource();
        _audioPlaybackTask = ProcessAudioPlaybackAsync();

        return Task.CompletedTask;
    }

    public async Task StopPlaybackAsync()
    {
        if (!_isPlaying)
            return;

        _isPlaying = false;

        while (_audioPlaybackReader.TryRead(out _)) { }

        _playbackBuffer?.ClearBuffer();

        if (_waveOut != null)
        {
            _waveOut.Stop();
            _waveOut.Dispose();
            _waveOut = null;
        }

        _playbackBuffer = null;
        _playbackCancellationTokenSource.Cancel();

        if (_audioPlaybackTask != null)
        {
            await _audioPlaybackTask.ConfigureAwait(false);
            _audioPlaybackTask = null;
        }
    }

    public async Task QueueAudioAsync(byte[] audioData)
    {
        if (_isPlaying && audioData.Length > 0)
        {
            await _audioPlaybackWriter.WriteAsync(audioData).ConfigureAwait(false);
        }
    }

    private void OnAudioDataAvailable(object? sender, WaveInEventArgs e)
    {
        if (_isCapturing && e.BytesRecorded > 0)
        {
            byte[] audioData = new byte[e.BytesRecorded];
            Array.Copy(e.Buffer, 0, audioData, 0, e.BytesRecorded);

            if (!_audioSendWriter.TryWrite(audioData))
            {
                _logger.LogWarning("Failed to queue audio data for sending");
            }
        }
    }

    private void OnRecordingStopped(object? sender, StoppedEventArgs e)
    {
        if (e.Exception != null)
        {
            _logger.LogError(e.Exception, "Audio recording stopped due to error");
        }
    }

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
                    await _session.SendInputAudioAsync(audioData, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending audio data");
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in audio send processing");
        }
    }

    private async Task ProcessAudioPlaybackAsync()
    {
        try
        {
            var combined = CancellationTokenSource.CreateLinkedTokenSource(
                _playbackCancellationTokenSource.Token, _cancellationTokenSource.Token);

            await foreach (byte[] audioData in _audioPlaybackReader.ReadAllAsync(combined.Token).ConfigureAwait(false))
            {
                if (combined.Token.IsCancellationRequested)
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
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in audio playback processing");
        }
    }

    public async Task CleanupAsync()
    {
        await StopCaptureAsync().ConfigureAwait(false);
        await StopPlaybackAsync().ConfigureAwait(false);

        _cancellationTokenSource.Cancel();

        var tasks = new List<Task>();
        if (_audioSendTask != null) tasks.Add(_audioSendTask);
        if (_audioPlaybackTask != null) tasks.Add(_audioPlaybackTask);

        if (tasks.Count > 0)
            await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    public void Dispose()
    {
        CleanupAsync().Wait();
        _cancellationTokenSource.Dispose();
    }
}

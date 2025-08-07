// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Security.Cryptography;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// Represents a test recording session. This is used to record or playback requests and responses. It also provides
/// a random generator that is consistent between recording and playback sessions.
/// </summary>
public class TestRecording : IAsyncDisposable
{
    /// <summary>
    /// The key to use to store the random seed in the recording.
    /// </summary>
    public const string RandomSeedVariableKey = "RandomSeed";

    private SortedDictionary<string, string> _variables;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="id">The unique identifier for the recording.</param>
    /// <param name="mode">The current recording mode.</param>
    /// <param name="proxy">The test proxy service instance to use for the recording.</param>
    /// <param name="variables">(Optional) Any variables populate this recording this. This is normally used in
    /// playback mode to pass in any variables saved as part of the recording.</param>
    /// <exception cref="ArgumentNullException">Any of the required parameters are null.</exception>
    /// <exception cref="InvalidOperationException">Some expected values were missing or null.</exception>
    /// <exception cref="NotSupportedException">The current recording mode is not supported.</exception>
    public TestRecording(string id, RecordedTestMode mode, ProxyService proxy, IDictionary<string, string>? variables = null)
    {
        ID = id ?? throw new ArgumentNullException(nameof(id));
        Mode = mode;
        Proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        _variables = variables == null
            ? new()
            : new(variables);

        if (Proxy.Client == null)
        {
            throw new InvalidOperationException("Recording test proxy did not have a client defined");
        }

        int seed;
        switch (Mode)
        {
            case RecordedTestMode.Live:
                Random = new TestRandom(Mode, GetRandomSeed());
                break;

            case RecordedTestMode.Record:
                seed = GetRandomSeed();
                _variables[RandomSeedVariableKey] = seed.ToString(CultureInfo.InvariantCulture);
                Random = new TestRandom(Mode, seed);
                break;

            case RecordedTestMode.Playback:
                if (Variables.TryGetValue(RandomSeedVariableKey, out string? seedString)
                    && int.TryParse(seedString, NumberStyles.Integer, CultureInfo.InvariantCulture, out seed))
                {
                    Random = new TestRandom(Mode, seed);
                }
                else
                {
                    // To maximise backwards compatibility with the recordings from the previous test framework, we'll just use a random
                    // seed if one wasn't set instead of failing here. Worst case, we'll get recording mismatches if this is not configured
                    // correctly.
                    Random = new TestRandom(Mode, GetRandomSeed());
                }
                break;

            default:
                throw new NotSupportedException("Unsupported recording mode: " + Mode);
        }
    }

    /// <summary>
    /// Gets the unique identifier for this recording.
    /// </summary>
    public string ID { get; }

    /// <summary>
    /// Gets the current recording mode.
    /// </summary>
    public RecordedTestMode Mode { get; }

    /// <summary>
    /// Gets the random generator to use for this recording. Using this ensures consistent random values generated during
    /// recording, as well as during playback.
    /// </summary>
    public TestRandom Random { get; }

    /// <summary>
    /// Gets the proxy service associated with the recording.
    /// </summary>
    protected internal ProxyService Proxy { get; }

    /// <summary>
    /// Gets any variables associated with the recording.
    /// </summary>
    protected IReadOnlyDictionary<string, string> Variables => _variables;

    /// <summary>
    /// Disposes of the recording session. If you were recording, this will try to save your captured requests and
    /// responses. If you were playing back, this will stop the playback session.
    /// </summary>
    /// <returns>Asynchronous task</returns>
    public virtual ValueTask DisposeAsync() => FinishAsync(true);

    /// <summary>
    /// Finishes the recording session. This will stop recording or playback. If you were recording, you can use
    /// <paramref name="save"/> to determine whether or not captured requests and responses will be saved.
    /// </summary>
    /// <param name="save">True to save any captured requests and responses to the file specified in your
    /// <see cref="Proxy.Service.RecordingStartInformation"/>. False to not save. This is only used if
    /// you were recording.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>Asynchronous task</returns>
    /// <exception cref="NotSupportedException">If the recording mode is not supported.</exception>
    public async virtual ValueTask FinishAsync(bool save, CancellationToken token = default)
    {
        switch (Mode)
        {
            case RecordedTestMode.Live:
                // nothing to see here, move along
                break;
            case RecordedTestMode.Playback:
                await Proxy.Client.StopPlaybackAsync(ID, token).ConfigureAwait(false);
                break;
            case RecordedTestMode.Record:
                await Proxy.Client.StopRecordingAsync(ID, _variables, !save, token).ConfigureAwait(false);
                break;
            default:
                throw new NotSupportedException("The following mode is not supported: " + Mode);
        }

        Proxy.ThrowOnErrors();
    }

    /// <summary>
    /// Gets a recorded variable.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <returns>The variable value, or null if the variable was not set.</returns>
    public virtual string? GetVariable(string name)
    {
        return _variables.GetValueOrDefault(name);
    }

    /// <summary>
    /// Sets a recorded variable to a value.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <param name="value">The value to set.</param>
    public virtual void SetVariable(string name, string value)
    {
        _variables[name] = value;
    }

    /// <summary>
    /// Gets a recorded variable, or if it was not set, creates and adds a new variable.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <param name="valueFactory">The factory used to create a value if none was previously set.</param>
    /// <returns>The already existing value, or the newly added value.</returns>
    public virtual string GetOrAddVariable(string name, Func<string> valueFactory)
    {
        string? value;
        if (!_variables.TryGetValue(name, out value) || value == null)
        {
            value = valueFactory();
            SetVariable(name, value);
        }

        return value;
    }

    /// <summary>
    /// Gets the options to use as the options for creating transport to pass to clients. This will allow the clients to
    /// forward requests to the test proxy.
    /// </summary>
    /// <returns>The options to use.</returns>
    public virtual ProxyTransportOptions GetProxyTransportOptions()
    {
        return new()
        {
            HttpEndpoint = Proxy.HttpEndpoint,
            HttpsEndpoint = Proxy.HttpsEndpoint,
            Mode = Mode,
            RecordingId = ID,
            RequestId = Random.NewGuid().ToString()
        };
    }

    /// <summary>
    /// Applies recording options to the current recording.
    /// </summary>
    /// <param name="options">The recording options to apply for this recording/playback session.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>Asynchronous task</returns>
    public virtual async Task ApplyOptions(TestRecordingOptions options, CancellationToken token)
    {
        if (options.Sanitizers.Any())
        {
            await Proxy.Client.AddSanitizersAsync(options.Sanitizers, ID, token).ConfigureAwait(false);
        }

        if (options.SanitizersToRemove.Any())
        {
            await Proxy.Client.RemoveSanitizersAsync(options.SanitizersToRemove, ID, token).ConfigureAwait(false);
        }

        if (Mode == RecordedTestMode.Playback)
        {
            BaseMatcher matcher = options.Matcher ?? new CustomMatcher()
            {
                CompareBodies = options.CompareBodies,
                ExcludedHeaders = options.ExcludedHeaders.JoinOrNull(","),
                IgnoredHeaders = options.IgnoredHeaders.JoinOrNull(","),
                IgnoredQueryParameters = options.IgnoredQueryParameters.JoinOrNull(","),
            };

            await Proxy.Client.SetMatcherAsync(matcher, ID, token).ConfigureAwait(false);

            foreach (var transform in options.Transforms)
            {
                await Proxy.Client.AddTransformAsync(transform, ID, token).ConfigureAwait(false);
            }
        }
    }

    private static int GetRandomSeed()
    {
#if NET6_0_OR_GREATER
        return RandomNumberGenerator.GetInt32(int.MaxValue);
#else
        byte[] bytes = new byte[4];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);
#endif
    }
}

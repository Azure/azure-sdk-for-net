// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Security.Cryptography;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording;

public class TestRecording : IAsyncDisposable
{
    public const string RandomSeedVariableKey = "RandomSeed";

    private SortedDictionary<string, string> _variables;

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
                Variables[RandomSeedVariableKey] = seed.ToString(CultureInfo.InvariantCulture);
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
                    throw new InvalidOperationException("No random seed was set during recording");
                }
                break;

            default:
                throw new NotSupportedException("Unsupported recording mode: " + Mode);
        }
    }

    public string ID { get; }

    public RecordedTestMode Mode { get; }

    public TestRandom Random { get; }

    protected internal ProxyService Proxy { get; }

    protected IDictionary<string, string> Variables => _variables;

    public TestRecordingMismatchException? MismatchException { get; protected internal set; }

    public virtual ValueTask DisposeAsync() => FinishAsync(true);

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
                await Proxy.Client.StopRecordingAsync(ID, Variables, !save, token).ConfigureAwait(false);
                break;
            default:
                throw new NotSupportedException("The following mode is not supported: " + Mode);
        }

        Proxy.ThrowOnErrors();
    }

    public virtual string? GetVariable(string name)
    {
        return Variables.GetValueOrDefault(name);
    }

    public virtual void SetVariable(string name, string value)
    {
        Variables[name] = value;
    }

    public virtual string GetOrAddVariable(string name, Func<string> valueFactory)
    {
        string? value;
        if (!Variables.TryGetValue(name, out value) || value == null)
        {
            value = valueFactory();
            SetVariable(name, value);
        }

        return value;
    }

    public virtual ProxyTransportOptions GetProxyTransportOptions()
    {
        return new()
        {
            HttpEndpoint = Proxy.HttpEndpoint,
            HttpsEndpoint = Proxy.HttpsEndpoint,
            Mode = Mode,
            RecordingId = ID,
            RequestId = Random.GetGuid().ToString()
        };
    }

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

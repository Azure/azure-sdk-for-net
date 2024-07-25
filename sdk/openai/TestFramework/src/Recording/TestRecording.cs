// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Globalization;
using System.Security.Cryptography;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.RecordingProxy;

namespace OpenAI.TestFramework.Recording;

public class TestRecording : IAsyncDisposable
{
    public const string RandomSeedVariableKey = "RandomSeed";

    private SortedDictionary<string, string> _variables;
    private TestRandom? _random;

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
    }

    public string ID { get; }

    public RecordedTestMode Mode { get; }

    public TestRandom Random
    {
        get
        {
            if (_random != null)
            {
                return _random;
            }

            int seed;
            switch (Mode)
            {
                case RecordedTestMode.Live:
                    _random = new TestRandom(Mode, GetRandomSeed());
                    break;

                case RecordedTestMode.Record:
                    seed = GetRandomSeed();
                    Variables[RandomSeedVariableKey] = seed.ToString(CultureInfo.InvariantCulture);
                    _random = new TestRandom(Mode, seed);
                    break;

                case RecordedTestMode.Playback:
                    ValidateWeHaveVariables();
                    if (Variables.TryGetValue(RandomSeedVariableKey, out string? seedString)
                        && int.TryParse(seedString, NumberStyles.Integer, CultureInfo.InvariantCulture, out seed))
                    {
                        _random = new TestRandom(Mode, seed);
                    }

                    throw new InvalidOperationException("No random seed was set during recording");

                default:
                    throw new NotSupportedException("Unsupported recording mode: " + Mode);
            }

            return _random;
        }
    }

    protected internal ProxyService Proxy { get; }

    public IDictionary<string, string> Variables => _variables;

    public TestRecordingMismatchException? MismatchException { get; protected internal set; }

    public ValueTask DisposeAsync() => FinishAsync(true);

    public async ValueTask FinishAsync(bool save, CancellationToken token = default)
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

    public string? GetVariable(string name, string? defaultValue)
    {
        switch (Mode)
        {
            case RecordedTestMode.Live:
                return defaultValue;
            case RecordedTestMode.Playback:
                ValidateWeHaveVariables();
                return Variables.TryGetValue(name, out string? value) ? value : defaultValue;
            case RecordedTestMode.Record:
                if (defaultValue != null)
                {
                    Variables[name] = defaultValue;
                }
                return defaultValue;
            default:
                throw new NotSupportedException("The following mode is not supported: " + Mode);
        }
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

    protected virtual void ValidateWeHaveVariables()
    {
        if (Variables.Count == 0)
        {
            throw new TestRecordingMismatchException(
                "The record session does not exist or is missing the Variables section. If the test is " +
                "attributed with 'RecordedTest', it will be recorded automatically. Otherwise, set the " +
                "RecordedTestMode to 'Record' and attempt to record the test.");
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

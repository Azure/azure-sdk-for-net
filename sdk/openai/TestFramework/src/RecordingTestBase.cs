// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using NUnit.Framework;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Recording.Common;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.RecordingProxy.Models;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework;

[NonParallelizable]
public abstract class RecordingTestBase : SyncAsyncTestBase
{
    private static readonly object s_lock = new();
    private static Proxy? s_proxy;

    // Using Windows version as it is the most restrictive of all platforms:
    // https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/IO/Path.Windows.cs
    protected static readonly ISet<char> s_invalidChars = new HashSet<char>()
    {
        '\"', '<', '>', '|', '\0',
        (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8, (char)9, (char)10,
        (char)11, (char)12, (char)13, (char)14, (char)15, (char)16, (char)17, (char)18, (char)19, (char)20,
        (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, (char)30,
        (char)31, ':', '*', '?', '\\', '/'
    };

    private DateTimeOffset _testStartTime;
    private TestRecordingOptions _options;

    public RecordingTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync)
    {
        _options = new TestRecordingOptions();
        Mode = mode ?? RecordedTestMode.Playback;
    }

    public override DateTimeOffset TestStartTime => _testStartTime;

    public RecordedTestMode Mode { get; set; }

    public TestRecordingOptions RecordingOptions
    {
        get => _options;
        set => _options = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TestRecording? Recording { get; protected internal set; }

    public virtual TimeSpan TestProxyWaitTime => Default.TestProxyWaitTime;

    public virtual string AssetsJsonFile => Default.AssetsJson;

    public string? GetOptionalRecordedValue(string name)
    {
        if (Recording == null)
        {
            throw new InvalidOperationException("Recorded value should not be retrieved outside the test method invocation");
        }

        return Recording.GetVariable(name, null);
    }

    [SetUp]
    public virtual async Task StartTestRecordingAsync()
    {
        _testStartTime = DateTimeOffset.UtcNow;

        // TODO FIXME: Add logic to ignore certain tests here by throwing IgnoreException()?

        using CancellationTokenSource cts = new(TestProxyWaitTime);
        Proxy proxy = await StartTestProxyAsync(cts.Token).ConfigureAwait(false);
        Recording = await StartAndConfigureRecordingSessionAsync(proxy, cts.Token).ConfigureAwait(false);

        // don't include test proxy overhead as part of the test time
        _testStartTime = DateTimeOffset.UtcNow;
    }

    [TearDown]
    public virtual async Task StopTestRecordingAsync()
    {
        bool testsPassed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
        using CancellationTokenSource cts = new(TestProxyWaitTime);

        if (Recording != null)
        {
            await Recording.FinishAsync(testsPassed).ConfigureAwait(false);
        }
    }

    public virtual TClientOptions InstrumentClientOptions<TClientOptions>(TClientOptions options)
        where TClientOptions : ClientPipelineOptions
    {
        // If we are in playback, or record mode we should set the transport to the test proxy transport, except
        // in the case where we've explicitly specified the transport ourselves in case we are doing some custom
        // work.
        if (options.Transport != null)
        {
            return options;
        }

        switch (Mode)
        {
            case RecordedTestMode.Live:
                return options;

            case RecordedTestMode.Record:
                // continue
                break;

            case RecordedTestMode.Playback:
                // continue
                // TODO FIXME: set reduced timeouts here and retry modes?
                break;

            default:
                throw new NotSupportedException("The following mode is not supported: " + Mode);
        }

        if (Recording == null)
        {
            throw new InvalidOperationException("Please call this from within a test method invocation");
        }

        ProxyTransportOptions transportOptions = Recording.GetProxyTransportOptions();
        // TODO FIXME set the UseFiddler property as well
        if (_options.RequestOverride != null)
        {
            transportOptions.ShouldRecordRequest = _options.RequestOverride;
        }

        options.Transport = new ProxyTransport(transportOptions);
        return options;
    }

    protected virtual ProxyOptions CreateProxyOptions()
    {
        RecordedTestEnvironment env = new();
        return new ProxyOptions(/* auto detect dotnet and test proxy dll */)
        {
            StorageLocationDir = env.RepositoryRoot.FullName,
            DevCertFile = env.DevCertPath.FullName,
            DevCertPassword = env.DevCertPassword,
        };
    }

    protected virtual Task<Proxy> StartTestProxyAsync(CancellationToken token)
    {
        // For now, we want to treat the proxy like a singleton and only create one instance for all tests
        if (s_proxy != null)
        {
            return Task.FromResult(s_proxy);
        }

        Task<Proxy> returnTask;

        lock (s_lock)
        {
            if (s_proxy != null)
            {
                returnTask = Task.FromResult(s_proxy);
            }
            else
            {
                ProxyOptions options = CreateProxyOptions();
                returnTask = Create(options, token);
            }
        }

        return returnTask;

        static async Task<Proxy> Create(ProxyOptions options, CancellationToken token)
        {
            s_proxy = await Proxy.CreateNewAsync(options, token).ConfigureAwait(false);
            return s_proxy;
        }
    }

    protected virtual StringBuilder GetRecordedTestName()
    {
        const string c_asyncSuffix = "Async";
        TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

        StringBuilder builder = new(testAdapter.Name.Length + c_asyncSuffix.Length);
        foreach (char c in testAdapter.Name)
        {
            builder.Append(s_invalidChars.Contains(c) ? '%' : c);
        }

        if (IsAsync)
        {
            builder.Append(c_asyncSuffix);
        }

        return builder;
    }

    protected abstract FileInfo GetAssetsJson();

    protected abstract string GetRecordingFileRelativePath();

    protected virtual async Task<TestRecording> StartAndConfigureRecordingSessionAsync(Proxy proxy, CancellationToken token)
    {
        var client = proxy.Client ?? throw new InvalidOperationException("Test proxy client was null");
        IDictionary<string, string>? variables = null;

        ProxyClientResult result;
        StartInformation startInfo = new()
        {
            AssetsFile = GetAssetsJson().FullName,
            RecordingFile = GetRecordingFileRelativePath(),
        };

        switch (Mode)
        {
            case RecordedTestMode.Live:
                // nothing to see here
                return new TestRecording(string.Empty, RecordedTestMode.Live, proxy);

            case RecordedTestMode.Playback:
                var playbackResult = await client.StartPlaybackAsync(startInfo, token).ConfigureAwait(false);
                variables = playbackResult.Value;
                result = playbackResult;
                break;

            case RecordedTestMode.Record:
                result = await client.StartRecordingAsync(startInfo, token).ConfigureAwait(false);
                break;

            default:
                throw new NotSupportedException("Don't know how to handle recording mode: " + Mode);
        }

        string? recordingId = result.RecordingId;
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new InvalidOperationException("Recording test proxy did not return a recording ID");
        }

        await client.AddSanitizersAsync(_options.Sanitizers, recordingId, token).ConfigureAwait(false);
        if (Mode == RecordedTestMode.Playback)
        {
            BaseMatcher matcher = _options.Matcher ?? new CustomMatcher()
            {
                CompareBodies = _options.CompareBodies,
                ExcludedHeaders = _options.ExcludedHeaders.JoinOrNull(","),
                IgnoredHeaders = _options.IgnoredHeaders.JoinOrNull(","),
                IgnoredQueryParameters = _options.IgnoredQueryParameters.JoinOrNull(","),
            };

            await client.SetMatcherAsync(matcher, recordingId, token).ConfigureAwait(false);

            foreach (var transform in _options.Transforms)
            {
                await client.AddTransformAsync(transform, recordingId, token).ConfigureAwait(false);
            }
        }

        return new TestRecording(recordingId!, Mode, proxy, variables);
    }
}

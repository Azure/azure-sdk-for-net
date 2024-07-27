// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Net;
using System.Text;
using NUnit.Framework;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Recording.Common;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework;

/// <summary>
/// Base class for client test cases that supports recording and playback of HTTP/HTTPS REST requests. This recording
/// support is provided by use of the Test Proxy <see href="https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md" />.
/// This provides the basic framework to start the Test Proxy, create a recording for a test or playback a recording
/// for a test. It also provides support for automatic testing of async and sync versions of methods (see
/// <see cref="SyncAsyncTestBase"/> for more details).
/// </summary>
[NonParallelizable]
public abstract class RecordingTestBase : SyncAsyncTestBase
{
    /// <summary>
    /// Invalid characters that will be removed from test names when creating recordings.
    /// </summary>
    /// <remarks>
    /// Using Windows version as it is the most restrictive of all platforms:
    /// <see href="https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/IO/Path.Windows.cs"/>
    /// </remarks>
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

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="isAsync">True to run the async version of a test, false to run the sync version of a test.</param>
    /// <param name="mode">(Optional) The recorded test mode to use. If unset, the default recorded test mode will be used.</param>
    public RecordingTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync)
    {
        _options = new TestRecordingOptions();
        Mode = mode ?? GetDefaultRecordedTestMode();
    }

    /// <inheritdoc />
    public override DateTimeOffset TestStartTime => _testStartTime;

    /// <summary>
    /// Gets the test proxy instance to use for the current test case.
    /// </summary>
    public ProxyService? Proxy { get; protected internal set; }

    /// <summary>
    /// Gets or sets the current recording mode for the test.
    /// </summary>
    public RecordedTestMode Mode { get; set; }

    /// <summary>
    /// Gets or sets the recording options to use for the current test. This will be pre-populated with a sensible configuration.
    /// </summary>
    public TestRecordingOptions RecordingOptions
    {
        get => _options;
        set => _options = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets the recording for the current test.
    /// </summary>
    public TestRecording? Recording { get; protected internal set; }

    /// <summary>
    /// Gets the maximum amount of time to wait for starting/tearing down the test proxy, as well as the maximum amount of time
    /// to wait for configuring a recording session, and then saving it or closing it.
    /// </summary>
    public virtual TimeSpan TestProxyWaitTime => Default.TestProxyWaitTime;

    /// <summary>
    /// Determines whether or not to use Fiddler. If this is true, then the recording transport will be updated to use Fiddler
    /// as the intermediary when talking to the test proxy, as well as accept the Fiddler root certificate.
    /// </summary>
    public virtual bool UseFiddler
    {
        get
        {
            // Check to see if Fiddler is already running and capturing traffic by checking to see if a proxy is configured for
            // 127.0.0.1:8888 with no credentials
            try
            {
                Uri dummyUri = new("https://not.a.real.uri.com");

                IWebProxy webProxy = WebRequest.GetSystemWebProxy();
                Uri? proxyUri = webProxy?.GetProxy(dummyUri);
                if (proxyUri == null || proxyUri == dummyUri)
                {
                    return false;
                }

                // assume default of 127.0.0.1:8888 with no credentials
                var cred = webProxy?.Credentials?.GetCredential(dummyUri, string.Empty);
                return proxyUri.Host == "127.0.0.1"
                    && proxyUri.Port == 8888
                    && string.IsNullOrWhiteSpace(cred?.UserName)
                    && string.IsNullOrWhiteSpace(cred?.Password);
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Checks if the recording has a recorded value for <paramref name="name"/>. If there is none, the <paramref name="valueToAdd"/>
    /// will be added and return. Otherwise the existing value will be returned.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="valueToAdd">The value to add.</param>
    /// <returns>The existing value, or the newly added value.</returns>
    /// <exception cref="InvalidOperationException">If you called this function outside of a test run.</exception>
    public string? GetOrAddRecordedValue(string name, string valueToAdd)
        => GetOrAddRecordedValue(name, () => valueToAdd);

    /// <summary>
    /// Checks if the recording has a recorded value for <paramref name="name"/>. If there is none, a value will be created, added
    /// and returned. Otherwise the existing value will be returned.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="valueFactory">The factory used to create the value.</param>
    /// <returns>The existing value, or the newly added value.</returns>
    /// <exception cref="InvalidOperationException">If you called this function outside of a test run.</exception>
    public virtual string GetOrAddRecordedValue(string name, Func<string> valueFactory)
    {
        if (Recording == null)
        {
            throw new InvalidOperationException("Recorded value should not be retrieved outside the test method invocation");
        }

        return Recording.GetOrAddVariable(name, valueFactory);
    }

    /// <summary>
    /// Starts the test proxy for the current test. This will be called once at the start of the test fixture.
    /// </summary>
    /// <returns>Asynchronous task.</returns>
    [OneTimeSetUp]
    public virtual async Task StartTestProxyAsync()
    {
        using CancellationTokenSource cts = new(TestProxyWaitTime);

        ProxyServiceOptions options = CreateProxyServiceOptions();
        Proxy = await ProxyService.CreateNewAsync(options, cts.Token).ConfigureAwait(false);
    }

    [OneTimeTearDown]
    public virtual Task StopTestProxyAsync()
    {
        Proxy?.Dispose();
        Proxy = null;

        //TODO FIXME: Do we need to do any cleanup here?
        return Task.CompletedTask;
    }

    /// <summary>
    /// Starts the test proxy (if it has not already been started), and then configures the recording session for the current
    /// test. This should also set the <see cref="Recording"/> property to the new recording session.
    /// </summary>
    /// <returns>Asynchronous task.</returns>
    [SetUp]
    public virtual async Task StartTestRecordingAsync()
    {
        if (Proxy == null)
        {
            throw new InvalidOperationException("The proxy service was not set and/or started");
        }

        _testStartTime = DateTimeOffset.UtcNow;

        // TODO FIXME: Add logic to ignore certain tests here by throwing IgnoreException()?

        using CancellationTokenSource cts = new(TestProxyWaitTime);
        Recording = await StartAndConfigureRecordingSessionAsync(Proxy, cts.Token).ConfigureAwait(false);

        // don't include test proxy overhead as part of the test time
        _testStartTime = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Stops a recording session for the current test. If the test passed and we are in recording mode, the recording will be saved,
    /// otherwise it will be discarded.
    /// </summary>
    /// <returns>Asynchronous task.</returns>
    [TearDown]
    public virtual async Task StopTestRecordingAsync()
    {
        bool testsPassed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
        using CancellationTokenSource cts = new(TestProxyWaitTime);

        if (Recording != null)
        {
            await Recording.FinishAsync(testsPassed, cts.Token).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Configures the client options for a System.ClientModel based service client. This will be used to configure the transport
    /// such that all requests are routed to the test proxy during recording (for capture), and playback (for replyaing captured
    /// requests).
    /// </summary>
    /// <typeparam name="TClientOptions">The type of the client options.</typeparam>
    /// <param name="options">The options to configure.</param>
    /// <returns>The configured client options.</returns>
    /// <exception cref="NotSupportedException">The current recording mode is not supported.</exception>
    /// <exception cref="InvalidOperationException">There was no test recording configured for this test.</exception>
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
        transportOptions.UseFiddler = UseFiddler;
        if (_options.RequestOverride != null)
        {
            transportOptions.ShouldRecordRequest = _options.RequestOverride;
        }

        options.Transport = new ProxyTransport(transportOptions);
        return options;
    }

    /// <summary>
    /// Gets the default recorded test mode to use.
    /// </summary>
    /// <returns>The test mode to use.</returns>
    protected virtual RecordedTestMode GetDefaultRecordedTestMode() => RecordedTestMode.Playback;

    /// <summary>
    /// Determines the name of the test to use in the recording. This will automatically sanitize test names,
    /// and append "Async" when running the asynchronous versions of tests.
    /// </summary>
    /// <returns>The name of the test to use.</returns>
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

    /// <summary>
    /// Configures a recording/playback session for the current test on the test proxy. This is called at the start of every test.
    /// It is responsible for configuring all the necessary sanitizers, matchers, and transforms for the test proxy.
    /// </summary>
    /// <param name="proxy">The test proxy service to configure the recording session for.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The configured test recording session.</returns>
    /// <exception cref="InvalidOperationException">The test proxy service instance did not have a valid client configured.</exception>
    /// <exception cref="NotSupportedException">The recording mode is not supported.</exception>
    protected virtual async Task<TestRecording> StartAndConfigureRecordingSessionAsync(ProxyService proxy, CancellationToken token)
    {
        var client = proxy.Client ?? throw new ArgumentNullException("Test proxy client was null");
        IDictionary<string, string>? variables = null;

        ProxyClientResult result;
        switch (Mode)
        {
            case RecordedTestMode.Live:
                // nothing to see here
                return new TestRecording(string.Empty, RecordedTestMode.Live, proxy);

            case RecordedTestMode.Playback:
                var playbackResult = await client.StartPlaybackAsync(CreateRecordingSessionStartInfo(), token).ConfigureAwait(false);
                variables = playbackResult.Value;
                result = playbackResult;
                break;

            case RecordedTestMode.Record:
                result = await client.StartRecordingAsync(CreateRecordingSessionStartInfo(), token).ConfigureAwait(false);
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

    /// <summary>
    /// Creates the options used when starting a new instance of the test proxy service.
    /// </summary>
    /// <returns>The options to use.</returns>
    protected abstract ProxyServiceOptions CreateProxyServiceOptions();

    /// <summary>
    /// Creates the information used to configured a recording/playback session for the current test on the test proxy.
    /// </summary>
    /// <returns>The information to use.</returns>
    protected abstract StartInformation CreateRecordingSessionStartInfo();
}

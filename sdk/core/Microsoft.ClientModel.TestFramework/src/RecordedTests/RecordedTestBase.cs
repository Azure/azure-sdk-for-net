// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework.TestProxy;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Base class for recorded tests that provides functionality for recording, replaying, and managing HTTP interactions.
/// This class handles test proxy integration, session recording, and client instrumentation for consistent testing
/// across different modes (Live, Record, Playback).
/// </summary>
/// <remarks>
/// Recorded tests allow you to:
/// - Record HTTP interactions during live testing
/// - Replay recorded interactions for fast, deterministic tests
/// - Sanitize sensitive data in recordings
/// - Instrument client options for test scenarios
///
/// The class automatically manages test proxy lifecycle and recording sessions based on the test mode.
/// </remarks>
[NonParallelizable]
public abstract class RecordedTestBase : ClientTestBase
{
    // copied the Windows version https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/IO/Path.Windows.cs
    // as it is the most restrictive of all platforms
    private static readonly HashSet<char> s_invalidChars = new HashSet<char>(new char[]
    {
            '\"', '<', '>', '|', '\0',
            (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8, (char)9, (char)10,
            (char)11, (char)12, (char)13, (char)14, (char)15, (char)16, (char)17, (char)18, (char)19, (char)20,
            (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, (char)30,
            (char)31, ':', '*', '?', '\\', '/'
    });
    private static string EmptyGuid = Guid.Empty.ToString();
    private static readonly object s_syncLock = new();
    private static bool s_ranTestProxyValidation;
    private TestProxyProcess? _proxy;
    private DateTime _testStartTime;

    /// <summary>
    /// A constant value used for sanitizing sensitive data in recordings.
    /// This value replaces actual sensitive information like secrets, keys, and tokens.
    /// </summary>
    public const string SanitizeValue = "Sanitized";

    /// <summary>
    /// The filename for the assets configuration file that contains external test asset definitions.
    /// This file is used to manage test assets that are shared across multiple tests or repositories.
    /// </summary>
    public const string AssetsJson = "assets.json";

    /// <summary>
    /// Gets the path to the assets.json file if it exists in the test directory hierarchy.
    /// This file contains configuration for external test assets and dependencies.
    /// </summary>
    /// <value>
    /// The full path to the assets.json file, or null if no assets file is found.
    /// The search traverses up the directory tree until it finds an assets.json file or reaches the git root.
    /// </value>
    public virtual string? AssetsJsonPath { get; }

    /// <summary>
    /// Gets the current test recording instance that manages HTTP request/response capture and replay.
    /// This property is automatically set during test setup and provides access to recording functionality.
    /// </summary>
    /// <value>
    /// The active TestRecording instance, or null if no recording is currently active.
    /// </value>
    public virtual TestRecording? Recording { get; private set; }

    /// <summary>
    /// Gets or sets the recording mode for the current test execution.
    /// This determines whether the test runs against live services, records interactions, or replays recorded data.
    /// </summary>
    /// <value>
    /// The current <see cref="RecordedTestMode"/> which can be Live, Record, or Playback.
    /// </value>
    public RecordedTestMode Mode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether client instrumentation validation should be performed.
    /// When enabled, the test framework verifies that all clients used during testing are properly instrumented.
    /// </summary>
    /// <value>
    /// true if client instrumentation should be validated; otherwise, false.
    /// This is automatically set based on whether the recording has captured any requests.
    /// </value>
    protected bool ValidateClientInstrumentation { get; set; }

    /// <summary>
    /// Gets the timestamp when the current test started execution.
    /// This excludes test proxy setup overhead and provides accurate test timing measurements.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> representing when the test logic began executing.
    /// </value>
    protected override DateTime TestStartTime => _testStartTime;

    /// <summary>
    /// The list of JSON path sanitizers to use when sanitizing a JSON request or response body.
    /// </summary>
    public virtual List<string> JsonPathSanitizers { get; } = new();

    /// <summary>
    /// The list of <see cref="BodyKeySanitizer"/> to use while sanitizing request and response bodies. This is similar to
    /// <see cref="JsonPathSanitizers"/>, but provides additional features such as regex matching, and customizing the sanitization replacement.
    /// </summary>
    public virtual List<BodyKeySanitizer> BodyKeySanitizers { get; } = new();

    /// <summary>
    /// The list of <see cref="BodyRegexSanitizer"/> to use while sanitizing request and response bodies. This allows you to specify a
    /// regex for matching on specific content in the body.
    /// </summary>
    public virtual List<BodyRegexSanitizer> BodyRegexSanitizers { get; } = new();

    /// <summary>
    /// The list of <see cref="UriRegexSanitizer"/> to use while sanitizing request and response URIs. This allows you to specify
    /// a regex for matching on the URI. <seealso cref="SanitizedQueryParameters"/> is a convenience property that allows you to sanitize
    /// query parameters without constructing the <see cref="UriRegexSanitizer"/> yourself.
    /// </summary>
    public virtual List<UriRegexSanitizer> UriRegexSanitizers { get; } = new()
        {
            UriRegexSanitizer.CreateWithQueryParameter("skoid", EmptyGuid),
            UriRegexSanitizer.CreateWithQueryParameter("sktid", EmptyGuid),
        };

    /// <summary>
    /// The list of <see cref="HeaderRegexSanitizer"/> to apply to the request and response headers. This allows you to specify
    /// a regex for matching on the header values. For simple use cases where you need to sanitize based solely on header key, use
    /// <see cref="SanitizedHeaders"/> instead. <seealso cref="SanitizedQueryParametersInHeaders"/> is a convenience property that allows
    /// you to sanitize query parameters out of specific headers without constructing the <see cref="HeaderRegexSanitizer"/> yourself.
    /// </summary>
    public virtual List<HeaderRegexSanitizer> HeaderRegexSanitizers { get; } = new();

    /// <summary>
    /// The list of headers that will be sanitized on the request and response. By default, the "Authorization" header is included.
    /// </summary>
    public virtual List<string> SanitizedHeaders { get; } = new();

    /// <summary>
    /// The list of query parameters that will be sanitized on the request and response URIs.
    /// </summary>
    public virtual List<string> SanitizedQueryParameters { get; } = new()
        {
            "sig",
            "sip",
            "client_id",
            "client_secret"
        };

    /// <summary>
    /// The list of header keys and query parameter tuples where the associated query parameter that should be sanitized from the corresponding
    /// request and response headers.
    /// </summary>
    public virtual List<(string Header, string QueryParameter)> SanitizedQueryParametersInHeaders { get; } = new();

    /// <summary>
    /// The list of sanitizers to remove. Sanitizer IDs can be found in Test Proxy docs.
    /// https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md
    /// </summary>
    public virtual List<string> SanitizersToRemove { get; } = new()
        {
            "AZSDK2003", // Location header
            "AZSDK2006", // x-ms-rename-source
            "AZSDK2007", // x-ms-file-rename-source
            "AZSDK2008", // x-ms-copy-source
            "AZSDK2020", // x-ms-request-id
            "AZSDK2030", // Operation-location header
            "AZSDK3420", // $..targetResourceId
            "AZSDK3423", // $..source
            "AZSDK3424", // $..to
            "AZSDK3425", // $..from
            "AZSDK3430", // $..id
            "AZSDK3433", // $..userId
            "AZSDK3447", // $.key - app config key - not a secret
            "AZSDK3448", // $.value[*].key - search key - not a secret
            "AZSDK3451", // $..storageContainerUri - used for mixed reality - no sas token
            "AZSDK3478", // $..accountName
            "AZSDK3488", // $..targetResourceRegion
            "AZSDK3490", // $..etag
            "AZSDK3491", // $..functionUri
            "AZSDK3493", // $..name
            "AZSDK3494", // $..friendlyName
            "AZSDK3495", // $..targetModelLocation
            "AZSDK3496", // $..resourceLocation
            "AZSDK4001", // host name regex
        };

    /// <summary>
    /// Gets or sets a value indicating whether to save debug recordings when tests fail.
    /// This is useful for debugging test failures by preserving the recorded interactions.
    /// </summary>
    /// <value>
    /// true to save recordings on test failure; otherwise, false.
    /// This flag is typically used during development and debugging scenarios.
    /// </value>
    public bool SaveDebugRecordingsOnFailure { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to compare request bodies during playback.
    /// When enabled, the test framework validates that request bodies match between recorded and replayed requests.
    /// </summary>
    /// <value>
    /// true to compare request bodies during playback; otherwise, false. The default is true.
    /// </value>
    public bool CompareBodies { get; set; } = true;

    /// <summary>
    /// Gets a collection of request headers whose values can change between recording and playback
    /// without causing request matching to fail. The presence or absence of the header itself is still respected.
    /// </summary>
    /// <value>
    /// A <see cref="HashSet{String}"/> containing header names to ignore during request matching.
    /// Common headers like Date, User-Agent, and request tracking headers are included by default.
    /// </value>
    public HashSet<string> IgnoredHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Date",
            "x-ms-date",
            "x-ms-client-request-id",
            "User-Agent",
            "Request-Id",
            "traceparent"
        };

    /// <summary>
    /// Gets a collection of query parameters whose values can change between recording and playback
    /// without causing URI matching to fail. The presence or absence of the parameter itself is still respected.
    /// </summary>
    /// <value>
    /// A <see cref="HashSet{String}"/> containing query parameter names to ignore during URI matching.
    /// By default, this collection is empty, but can be populated with parameters that vary between runs.
    /// </value>
    public HashSet<string> IgnoredQueryParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
    };

    /// <summary>
    /// Gets or sets a value indicating whether to use a local debug proxy for testing.
    /// When enabled, the proxy connects on ports 5000 and 5001 for local debugging scenarios.
    /// </summary>
    /// <value>
    /// true to use the local debug proxy; otherwise, false.
    /// This is useful when running the proxy locally for debugging recorded test issues.
    /// </value>
    protected bool UseLocalDebugProxy { get; set; }

    /// <summary>
    /// Gets or sets the test proxy process for testing purposes.
    /// This property is internal to allow injection of mock proxy instances during unit testing.
    /// </summary>
    /// <value>
    /// The TestProxyProcess instance used for recording and playback operations.
    /// </value>
    internal TestProxyProcess? TestProxy
    {
        get => _proxy;
        set => _proxy = value;
    }

    // For mocking
    internal RecordedTestBase() : base(default)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RecordedTestBase"/> class.
    /// </summary>
    /// <param name="isAsync">
    /// true if this instance is testing the async API variants; false for synchronous API variants.
    /// </param>
    /// <param name="mode">
    /// The recording mode for this test instance. If null, uses the global test mode from the environment.
    /// </param>
    /// <remarks>
    /// The constructor automatically determines the assets.json path by searching up the directory hierarchy
    /// from the test location. The recording mode defaults to the global test mode if not explicitly specified.
    /// </remarks>
    protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync)
    {
        Mode = mode ?? TestEnvironment.GlobalTestMode;
        AssetsJsonPath = GetAssetsJson();
    }

    /// <summary>
    /// Creates a new test recording instance for capturing or replaying HTTP interactions.
    /// </summary>
    /// <param name="mode">The recording mode (Live, Record, or Playback) for this recording session.</param>
    /// <param name="sessionFile">The path to the session file where recordings are stored or read from.</param>
    /// <returns>A task that represents the asynchronous operation and contains the created TestRecording instance.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the test proxy has not been started and is required for recording operations.
    /// </exception>
    /// <remarks>
    /// This method requires that the test proxy is running when creating recordings in Record or Playback modes.
    /// The session file path should be relative to the repository root for consistency across environments.
    /// </remarks>
    protected async Task<TestRecording> CreateTestRecordingAsync(RecordedTestMode mode, string sessionFile)
    {
        if (_proxy is null && Mode != RecordedTestMode.Live)
        {
            throw new InvalidOperationException("A test recording cannot be created because the test proxy has not been started.");
        }
        return await TestRecording.CreateAsync(mode, sessionFile, _proxy, this).ConfigureAwait(false);
    }

    /// <summary>
    /// Instruments client options to work properly with the test recording infrastructure.
    /// This method configures the client pipeline to use the test proxy transport and applies test-specific settings.
    /// </summary>
    /// <typeparam name="T">The type of client options, which must inherit from <see cref="ClientPipelineOptions"/>.</typeparam>
    /// <param name="clientOptions">The client options instance to instrument.</param>
    /// <param name="recording">
    /// The test recording to associate with the client options. If null, uses the current Recording property.
    /// </param>
    /// <returns>The instrumented client options instance.</returns>
    /// <remarks>
    /// In Playback mode, this method configures optimized settings for faster test execution.
    /// In Record mode, it sets up the transport to capture HTTP interactions through the test proxy.
    /// In Live mode, the original transport is preserved for direct service communication.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown when clientOptions.Transport is null in Record or Playback modes.
    /// </exception>
    public T InstrumentClientOptions<T>(T clientOptions, TestRecording? recording = default) where T : ClientPipelineOptions
    {
        recording ??= Recording;

        if (Mode == RecordedTestMode.Playback)
        {
            // TODO - clientOptions.RetryPolicy = new PlaybackRetryPolicy(TimeSpan.FromMilliseconds(10));
        }
        // No need to set the transport if we are in Live mode
        if (Mode != RecordedTestMode.Live)
        {
            clientOptions.Transport = recording?.CreateTransport(clientOptions.Transport);
        }

        return clientOptions;
    }

    /// <summary>
    /// Gets the file path for the current test's recording session.
    /// The path is constructed based on the test name, async mode, and class hierarchy.
    /// </summary>
    /// <returns>
    /// A string representing the relative path to the session file for the current test.
    /// The path is relative to the repository root and includes the test class and method names.
    /// </returns>
    /// <remarks>
    /// The session file path follows the pattern: SessionRecords/{ClassName}/{TestName}[Async].json
    /// Invalid filename characters are replaced with '%' to ensure valid file paths.
    /// When an assets.json file is present, the path is made relative to the repository root.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown when TestEnvironment.RepositoryRoot is null and cannot determine the repository root.
    /// </exception>
    protected internal string GetSessionFilePath()
    {
        TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

        string name = new string(testAdapter.Name.Select(c => s_invalidChars.Contains(c) ? '%' : c).ToArray());

        string async = IsAsync ? "Async" : string.Empty;

        string fileName = $"{name}{async}.json";

        var repoRoot = TestEnvironment.RepositoryRoot ?? throw new InvalidOperationException("TestEnvironment.RepositoryRoot cannot be null");

        // this needs to be updated to purely relative to repo root
        var result = Path.Combine(
            GetSessionFileDirectory(),
            fileName);

        if (!string.IsNullOrWhiteSpace(AssetsJsonPath))
        {
            return Regex.Replace(result.Replace(repoRoot, String.Empty), @"^[\\/]*", string.Empty);
        }
        else
        {
            return result;
        }
    }

    private string? GetAssetsJson()
    {
        string? path = GetSessionFileDirectory();

        while (true)
        {
            var assetsJsonPresent = File.Exists(Path.Combine(path ?? string.Empty, "assets.json"));

            // Check for root .git directory or, less commonly, a .git file for git worktrees.
            string gitRootPath = Path.Combine(path ?? string.Empty, ".git");
            var isGitRoot = Directory.Exists(gitRootPath) || File.Exists(gitRootPath);

            if (assetsJsonPresent)
            {
                return Path.Combine(path ?? string.Empty, AssetsJson);
            }
            else if (isGitRoot)
            {
                return null;
            }

            path = Path.GetDirectoryName(path);
        }
    }

    private string GetSessionFileDirectory()
    {
        // Use the current class name instead of the name of the class that declared a test.
        // This can be used in inherited tests that, for example, use a different endpoint for the same tests.
        string className = GetType().Name;

        TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

        string? additionalParameterName = testAdapter.Properties.ContainsKey(ClientTestFixtureAttribute.RecordingDirectorySuffixKey) ?
            testAdapter.Properties.Get(ClientTestFixtureAttribute.RecordingDirectorySuffixKey)?.ToString() :
            null;
        return Path.Combine(
            TestEnvironment.GetSourcePath(GetType().Assembly),
            "SessionRecords",
            additionalParameterName == null ? className : $"{className}({additionalParameterName})");
    }

    /// <summary>
    /// Applies global timeout enforcement only for playback mode tests.
    /// Live and record mode tests are not subject to timeout enforcement to allow for varying service response times.
    /// </summary>
    /// <remarks>
    /// This override ensures that only playback tests, which should execute quickly and deterministically,
    /// are subject to timeout constraints. Live tests may legitimately take longer due to network latency
    /// and service processing times.
    /// </remarks>
    public override void GlobalTimeoutTearDown()
    {
        // Only enforce the timeout on playback.
        if (Mode == RecordedTestMode.Playback)
        {
            base.GlobalTimeoutTearDown();
        }
    }

    // TODO - add diagnostics stuff
    ///// <summary>
    ///// Add a static <see cref="Diagnostics.AzureEventSourceListener"/> which will redirect SDK logging
    ///// to Console.Out for easy debugging.
    ///// </summary>
    //private static TestLogger Logger { get; set; }

    /// <summary>
    /// Initializes the recorded test class by setting up logging and starting the test proxy if needed.
    /// This method runs once before any tests in the class are executed.
    /// </summary>
    /// <remarks>
    /// The initialization process:
    /// - Sets up console logging in Live mode or when debugging
    /// - Starts the test proxy for Record and Playback modes
    /// - Configures the proxy to use local debug ports if UseLocalDebugProxy is enabled
    ///
    /// The test proxy is not started in Live mode since direct service communication is used.
    /// </remarks>
    [OneTimeSetUp]
    public void InitializeRecordedTestClass()
    {
        //if (Mode == RecordedTestMode.Live || Debugger.IsAttached)
        //{
        //    Logger = new TestLogger();
        //}

        if (Mode != RecordedTestMode.Live)
        {
            _proxy = TestProxyProcess.Start(UseLocalDebugProxy);
        }
    }

    /// <summary>
    /// Performs cleanup operations after all tests in the class have completed.
    /// This method runs once after all test methods have finished execution.
    /// </summary>
    /// <remarks>
    /// The cleanup process includes:
    /// - Disposing of logging resources
    /// - Cleaning up unused test recording files in Record mode
    /// - Removing session files for tests that no longer exist
    ///
    /// File cleanup helps maintain a clean test directory by removing recordings for deleted or renamed tests.
    /// Only files that don't match any known test method names are removed to prevent accidental deletion.
    /// </remarks>
    [OneTimeTearDown]
    public void TearDownRecordedTestClass()
    {
        //Logger?.Dispose();
        //Logger = null;

        // Clean up unused test files
        if (Mode == RecordedTestMode.Record)
        {
            var testClassDirectory = new DirectoryInfo(GetSessionFileDirectory());
            if (!testClassDirectory.Exists)
            {
                return;
            }

            var knownMethods = new HashSet<string>();

            // Management tests record in ctor
            knownMethods.Add(GetType().Name);

            // Collect all method names
            foreach (var method in GetType()
                         .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
            {
                // TestCase attribute allows specifying a test name
                foreach (var attribute in method.GetCustomAttributes(true))
                {
                    if (attribute is ITestData { TestName: { } name })
                    {
                        knownMethods.Add(name);
                    }
                }

                knownMethods.Add(method.Name);
            }

            foreach (var fileInfo in testClassDirectory.EnumerateFiles())
            {
                bool used = knownMethods.Any(knownMethod => fileInfo.Name.StartsWith(knownMethod, StringComparison.CurrentCulture));

                if (!used)
                {
                    try
                    {
                        fileInfo.Delete();
                    }
                    catch
                    {
                        // Ignore
                    }
                }
            }
        }
    }

    /// <summary>
    /// Sets proxy-specific options for the test recording session.
    /// This method allows customization of how the test proxy handles requests and responses during recording.
    /// </summary>
    /// <param name="options">
    /// The proxy options to apply to the current recording session.
    /// These options control proxy behavior such as request matching, response handling, and transport settings.
    /// </param>
    /// <returns>A task that represents the asynchronous operation of setting proxy options.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the test proxy has not been started or when not in Record mode.
    /// </exception>
    /// <remarks>
    /// This method only applies options during Record mode. Options are ignored in Live and Playback modes.
    /// The proxy must be running and a recording session must be active before calling this method.
    /// </remarks>
    protected async Task SetProxyOptionsAsync(RecordingOptions options)
    {
        if (Mode == RecordedTestMode.Record && options != null)
        {
            if (_proxy?.AdminClient is null)
            {
                throw new InvalidOperationException("Proxy options cannot be set because the test proxy has not been started.");
            }
            await _proxy.AdminClient.SetRecordingOptionsAsync(options, Recording?.RecordingId).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Starts a new test recording session for the current test method.
    /// This method initializes the recording infrastructure and prepares for HTTP interaction capture or replay.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation of starting the test recording.</returns>
    /// <exception cref="IgnoreException">
    /// Thrown when the test should be skipped based on recording skip conditions or live test skip conditions.
    /// </exception>
    /// <remarks>
    /// This method is automatically called by the NUnit framework before each test method execution.
    /// It performs the following operations:
    /// - Checks for test skip conditions based on recording settings
    /// - Creates a new test recording session for the current test
    /// - Initializes client instrumentation validation
    /// - Records the actual test start time (excluding proxy setup overhead)
    ///
    /// The recording session file path is automatically determined based on the test class and method names.
    /// Tests may be skipped if they have skip attributes for specific recording modes.
    /// </remarks>
    [SetUp]
    public virtual async Task StartTestRecordingAsync()
    {
        // initialize test start time in case test is skipped
        _testStartTime = DateTime.UtcNow;

        // Only create test recordings for the latest version of the service
        TestContext.TestAdapter test = TestContext.CurrentContext.Test;
        if (Mode != RecordedTestMode.Live &&
            test.Properties.ContainsKey("_SkipRecordings"))
        {
            throw new IgnoreException((string?)test.Properties.Get("_SkipRecordings") ?? string.Empty);
        }

        if (Mode == RecordedTestMode.Live &&
            test.Properties.ContainsKey("_SkipLive"))
        {
            throw new IgnoreException((string?)test.Properties.Get("_SkipLive") ?? string.Empty);
        }

        Recording = await CreateTestRecordingAsync(Mode, GetSessionFilePath()).ConfigureAwait(false);
        ValidateClientInstrumentation = Recording.HasRequests;

        // don't include test proxy overhead as part of test time
        _testStartTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Stops the current test recording session and performs cleanup operations.
    /// This method finalizes the recording session and validates test execution requirements.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation of stopping the test recording.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when client instrumentation validation fails, indicating that the test had recordings
    /// but didn't properly instrument any clients using the InstrumentClient method.
    /// </exception>
    /// <remarks>
    /// This method is automatically called by the NUnit framework after each test method execution.
    /// It performs the following operations:
    /// - Validates that clients were properly instrumented if recordings were made
    /// - Saves or discards the recording based on test outcome and debug settings
    /// - Ensures the test proxy tool is installed when recordings are saved
    /// - Checks for any proxy output or errors during test execution
    ///
    /// Recordings are saved when tests pass, or in debug builds when SaveDebugRecordingsOnFailure is enabled.
    /// Client instrumentation validation ensures proper test setup and helps catch configuration issues.
    /// </remarks>
    [TearDown]
    public virtual async Task StopTestRecordingAsync()
    {
        bool testPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
        if (ValidateClientInstrumentation && testPassed)
        {
            throw new InvalidOperationException("The test didn't instrument any clients but had recordings. Please call InstrumentClient for the client being recorded.");
        }

        bool save = testPassed;
#if DEBUG
        save |= SaveDebugRecordingsOnFailure;
#endif
        if (Recording != null)
        {
            await Recording.DisposeAsync(save).ConfigureAwait(false);

            if (Mode == RecordedTestMode.Record && save)
            {
                AssertTestProxyToolIsInstalled();
            }
        }

        if (_proxy != null)
        {
            await _proxy.CheckProxyOutputAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Instruments a client instance to work with the test recording infrastructure.
    /// This method applies interceptors and configuration needed for proper test recording and playback.
    /// </summary>
    /// <param name="clientType">The type of the client being instrumented.</param>
    /// <param name="client">The client instance to instrument with test recording capabilities.</param>
    /// <param name="preInterceptors">
    /// Optional collection of interceptors to apply before the standard test recording interceptors.
    /// These interceptors are applied in the order specified before test framework interceptors.
    /// </param>
    /// <returns>
    /// An instrumented proxy instance of the client that captures HTTP interactions for recording
    /// or replays recorded interactions during playback.
    /// </returns>
    /// <remarks>
    /// This method is typically called automatically by the test framework when clients are created
    /// through InstrumentClientOptions. It disables client instrumentation validation since a client
    /// has been properly configured for test recording.
    ///
    /// The instrumented client maintains the same API surface as the original client but routes
    /// HTTP requests through the test recording infrastructure for capture and replay.
    /// </remarks>
    protected internal override object CreateProxyFromClient(Type clientType, object client, IEnumerable<IInterceptor>? preInterceptors)
    {
        ValidateClientInstrumentation = false;
        return base.CreateProxyFromClient(clientType, client, preInterceptors);
    }

    /// <summary>
    /// Provides convenient access to mode-aware delay functionality for the current test instance.
    /// This method automatically uses the current test's recording mode to determine appropriate delay behavior.
    /// </summary>
    /// <param name="milliseconds">The number of milliseconds to wait in Live and Record modes. Default is 1000ms.</param>
    /// <param name="playbackDelayMilliseconds">
    /// An optional number of milliseconds to wait in Playback mode. If null, no delay occurs in Playback mode.
    /// This is useful for allowing client-side events to process during playback.
    /// </param>
    /// <returns>
    /// A task that represents the delay operation. The task completes immediately in Playback mode
    /// (unless playbackDelayMilliseconds is specified), or after the specified delay in other modes.
    /// </returns>
    /// <remarks>
    /// This method is a convenience wrapper that calls the static Delay method with the current test's Mode.
    /// Use this method when you need to wait for service operations to complete but want fast playback execution.
    /// </remarks>
    public Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = null) =>
        Delay(Mode, milliseconds, playbackDelayMilliseconds);

    /// <summary>
    /// Provides mode-aware delay functionality that adapts behavior based on the specified recording mode.
    /// This static method allows delay behavior to be controlled independently of a test instance.
    /// </summary>
    /// <param name="mode">The recording mode that determines delay behavior.</param>
    /// <param name="milliseconds">The number of milliseconds to wait in Live and Record modes. Default is 1000ms.</param>
    /// <param name="playbackDelayMilliseconds">
    /// An optional number of milliseconds to wait in Playback mode. If null, no delay occurs in Playback mode.
    /// This parameter allows fine-tuning of playback timing when some delay is necessary for proper test execution.
    /// </param>
    /// <returns>
    /// A task that represents the delay operation:
    /// - In Live and Record modes: delays for the specified milliseconds
    /// - In Playback mode: completes immediately (unless playbackDelayMilliseconds is specified)
    /// </returns>
    /// <remarks>
    /// This method enables tests to include realistic delays during live execution and recording
    /// while maintaining fast execution during playback. Use this for operations that require
    /// waiting for service-side processing to complete.
    /// </remarks>
    public static Task Delay(RecordedTestMode mode, int milliseconds = 1000, int? playbackDelayMilliseconds = null)
    {
        if (mode != RecordedTestMode.Playback)
        {
            return Task.Delay(milliseconds);
        }
        else if (playbackDelayMilliseconds != null)
        {
            return Task.Delay(playbackDelayMilliseconds.Value);
        }
        return Task.CompletedTask;
    }

    private void AssertTestProxyToolIsInstalled()
    {
        if (s_ranTestProxyValidation ||
            !TestEnvironment.IsWindows ||
            AssetsJsonPath == null)
        {
            return;
        }

        lock (s_syncLock)
        {
            if (s_ranTestProxyValidation)
            {
                return;
            }

            s_ranTestProxyValidation = true;

            try
            {
                if (IsTestProxyToolInstalled())
                {
                    return;
                }

                string path = Path.Combine(
                    TestEnvironment.RepositoryRoot ?? throw new InvalidOperationException("TestEnvironment.RepositoryRoot is null"),
                    "eng",
                    "scripts",
                    "Install-TestProxyTool.ps1");

                var processInfo = new ProcessStartInfo("pwsh.exe", path)
                {
                    UseShellExecute = true
                };

                var process = Process.Start(processInfo);

                if (process != null)
                {
                    process.WaitForExit();
                }
            }
            catch (Exception)
            {
                // Ignore
            }
        }
    }

    private bool IsTestProxyToolInstalled()
    {
        var processInfo = new ProcessStartInfo("dotnet.exe", "tool list --global")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false
        };

        var process = Process.Start(processInfo);
        var output = process?.StandardOutput.ReadToEnd();

        process?.WaitForExit();

        return output != null && output.Contains("azure.sdk.tools.testproxy");
    }

    /// <summary>
    /// Provides a helper for implementing retry logic in tests that accounts for the current recording mode.
    /// The retry behavior adapts based on whether the test is running in Live, Record, or Playback mode.
    /// </summary>
    /// <value>
    /// A <see cref="TestRetryHelper"/> instance configured for the current test mode.
    /// In Playback mode, retries execute immediately for faster test execution.
    /// In Live and Record modes, retries include appropriate delays for real service interactions.
    /// </value>
    /// <remarks>
    /// This property provides mode-aware retry functionality that ensures tests run efficiently
    /// in playback while maintaining realistic retry behavior during live execution and recording.
    /// Use this helper instead of implementing custom retry logic to ensure consistency across test modes.
    /// </remarks>
    protected TestRetryHelper TestRetryHelper => new TestRetryHelper(Mode == RecordedTestMode.Playback);
}

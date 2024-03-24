// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core.TestFramework.Models;
using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Core.TestFramework
{
    [NonParallelizable]
    public abstract class RecordedTestBase : ClientTestBase
    {
        public TestRecording Recording { get; private set; }

        public RecordedTestMode Mode { get; set; }

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

        private static readonly object s_syncLock = new();

        private static bool s_ranTestProxyValidation;

        private TestProxy _proxy;

        private DateTime _testStartTime;

        protected bool ValidateClientInstrumentation { get; set; }

        protected override DateTime TestStartTime => _testStartTime;

        public const string SanitizeValue = "Sanitized";
        public const string AssetsJson = "assets.json";
        public virtual string AssetsJsonPath { get; }

        /// <summary>
        /// The list of JSON path sanitizers to use when sanitizing a JSON request or response body.
        /// </summary>
        public List<string> JsonPathSanitizers { get; } =
            new() { "$..primaryKey", "$..secondaryKey", "$..primaryConnectionString", "$..secondaryConnectionString", "$..connectionString" };

        /// <summary>
        /// The list of <see cref="BodyKeySanitizer"/> to use while sanitizing request and response bodies. This is similar to
        /// <see cref="JsonPathSanitizers"/>, but provides additional features such as regex matching, and customizing the sanitization replacement.
        /// </summary>
        public List<BodyKeySanitizer> BodyKeySanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="BodyRegexSanitizer"/> to use while sanitizing request and response bodies. This allows you to specify a
        /// regex for matching on specific content in the body.
        /// </summary>
        public List<BodyRegexSanitizer> BodyRegexSanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="UriRegexSanitizer"/> to use while sanitizing request and response URIs. This allows you to specify
        /// a regex for matching on the URI. <seealso cref="SanitizedQueryParameters"/> is a convenience property that allows you to sanitize
        /// query parameters without constructing the <see cref="UriRegexSanitizer"/> yourself.
        /// </summary>
        public List<UriRegexSanitizer> UriRegexSanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="HeaderTransform"/> to apply in Playback mode to the response headers.
        /// </summary>
        public List<HeaderTransform> HeaderTransforms = new();

        /// <summary>
        /// The list of <see cref="HeaderRegexSanitizer"/> to apply to the request and response headers. This allows you to specify
        /// a regex for matching on the header values. For simple use cases where you need to sanitize based solely on header key, use
        /// <see cref="SanitizedHeaders"/> instead. <seealso cref="SanitizedQueryParametersInHeaders"/> is a convenience property that allows
        /// you to sanitize query parameters out of specific headers without constructing the <see cref="HeaderRegexSanitizer"/> yourself.
        /// </summary>
        public List<HeaderRegexSanitizer> HeaderRegexSanitizers { get; } = new();

        /// <summary>
        /// The list of headers that will be sanitized on the request and response. By default, the "Authorization" header is included.
        /// </summary>
        public List<string> SanitizedHeaders { get; } = new() { "Authorization" };

        /// <summary>
        /// The list of query parameters that will be sanitized on the request and response URIs.
        /// </summary>
        public List<string> SanitizedQueryParameters { get; } = new();

        /// <summary>
        /// The list of header keys and query parameter tuples where the associated query parameter that should be sanitized from the corresponding
        /// request and response headers.
        /// </summary>
        public List<(string Header, string QueryParameter)> SanitizedQueryParametersInHeaders { get; } = new();

        /// <summary>
        /// Flag you can (temporarily) enable to save failed test recordings
        /// and debug/re-run at the point of failure without re-running
        /// potentially lengthy live tests.  This should never be checked in
        /// and will throw an exception from CI builds to help make that easier
        /// to spot.
        /// </summary>
        public bool SaveDebugRecordingsOnFailure
        {
            get => _saveDebugRecordingsOnFailure;
            set
            {
                if (value && TestEnvironment.GlobalIsRunningInCI)
                {
                    throw new AssertionException($"Setting {nameof(SaveDebugRecordingsOnFailure)} must not be merged");
                }
                _saveDebugRecordingsOnFailure = value;
            }
        }
        private bool _saveDebugRecordingsOnFailure;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ReplacementHost
        {
            get => _replacementHost;
            set
            {
                _replacementHost = value;
                UriRegexSanitizers.Add(
                    new UriRegexSanitizer(@"https://(?<host>[^/]+)/", _replacementHost)
                    {
                        GroupForReplace = "host"
                    });
            }
        }

        private string _replacementHost;

        /// <summary>
        /// Whether or not to compare bodies from the request and the recorded request during playback.
        /// The default value is <value>true</value>.
        /// </summary>
        public bool CompareBodies { get; set; } = true;

        /// <summary>
        /// Determines if the ClientRequestId that is sent as part of a request while in Record mode
        /// should use the default Guid format. The default Guid format contains hyphens.
        /// The default value is <value>false</value>.
        /// </summary>
        public bool UseDefaultGuidFormatForClientRequestId { get; set; } = false;

        /// <summary>
        /// Request headers whose values can change between recording and playback without causing request matching
        /// to fail. The presence or absence of the header itself is still respected in matching.
        /// </summary>
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
        /// Legacy header exclusion set that will disregard any headers listed here when matching. Headers listed here are not matched for value,
        /// or for presence or absence of the header key. For that reason, IgnoredHeaders should be used instead as this will ensure that the header's
        /// presence or absence from the request is considered when matching.
        /// This property is only included only for backwards compat.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HashSet<string> LegacyExcludedHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Request-Id",
            "traceparent"
        };

        /// <summary>
        /// Query parameters whose values can change between recording and playback without causing URI matching
        /// to fail. The presence or absence of the query parameter itself is still respected in matching.
        /// </summary>
        public HashSet<string> IgnoredQueryParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
        };

        private bool _useLocalDebugProxy;

        /// <summary>
        /// If set to true, the proxy will be configured to connect on ports 5000 and 5001. This is useful when running the proxy locally for debugging recorded test issues.
        /// </summary>
        protected bool UseLocalDebugProxy
        {
            get => _useLocalDebugProxy;

            set
            {
                if (value && TestEnvironment.GlobalIsRunningInCI)
                {
                    throw new AssertionException($"Setting {nameof(UseLocalDebugProxy)} must not be merged");
                }
                _useLocalDebugProxy = value;
            }
        }

        /// <summary>
        /// Creats a new instance of <see cref="RecordedTestBase"/>.
        /// </summary>
        /// <param name="isAsync">True if this instance is testing the async API variants false otherwise.</param>
        /// <param name="mode">Indicates which <see cref="RecordedTestMode" /> this instance should run under.</param>
        protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync)
        {
            Mode = mode ?? TestEnvironment.GlobalTestMode;
            AssetsJsonPath = GetAssetsJson();
        }

        protected async Task<TestRecording> CreateTestRecordingAsync(RecordedTestMode mode, string sessionFile) =>
            await TestRecording.CreateAsync(mode, sessionFile, _proxy, this);

        public T InstrumentClientOptions<T>(T clientOptions, TestRecording recording = default) where T : ClientOptions
        {
            recording ??= Recording;

            if (Mode == RecordedTestMode.Playback)
            {
                // Not making the timeout zero so retry code still goes async
                clientOptions.Retry.Delay = TimeSpan.FromMilliseconds(10);
                clientOptions.Retry.Mode = RetryMode.Fixed;
            }
            // No need to set the transport if we are in Live mode
            if (Mode != RecordedTestMode.Live)
            {
                clientOptions.Transport = recording.CreateTransport(clientOptions.Transport);
            }

            return clientOptions;
        }

        protected internal string GetSessionFilePath()
        {
            TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

            string name = new string(testAdapter.Name.Select(c => s_invalidChars.Contains(c) ? '%' : c).ToArray());

            string versionQualifier = testAdapter.Properties.Get(ClientTestFixtureAttribute.VersionQualifierProperty) as string;

            string async = IsAsync ? "Async" : string.Empty;
            string version = versionQualifier is null ? string.Empty : $"[{versionQualifier}]";

            string fileName = $"{name}{version}{async}.json";

            var repoRoot = TestEnvironment.RepositoryRoot;

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

        private string GetAssetsJson()
        {
            var path = GetSessionFileDirectory();

            while (true)
            {
                var assetsJsonPresent = File.Exists(Path.Combine(path, "assets.json"));

                // Check for root .git directory or, less commonly, a .git file for git worktrees.
                string gitRootPath = Path.Combine(path, ".git");
                var isGitRoot = Directory.Exists(gitRootPath) || File.Exists(gitRootPath);

                if (assetsJsonPresent)
                {
                    return Path.Combine(path, AssetsJson);
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

            string additionalParameterName = testAdapter.Properties.ContainsKey(ClientTestFixtureAttribute.RecordingDirectorySuffixKey) ?
                testAdapter.Properties.Get(ClientTestFixtureAttribute.RecordingDirectorySuffixKey).ToString() :
                null;
            return Path.Combine(
                TestEnvironment.GetSourcePath(GetType().Assembly),
                "SessionRecords",
                additionalParameterName == null ? className : $"{className}({additionalParameterName})");
        }

        public override void GlobalTimeoutTearDown()
        {
            // Only enforce the timeout on playback.
            if (Mode == RecordedTestMode.Playback)
            {
                base.GlobalTimeoutTearDown();
            }
        }

        /// <summary>
        /// Add a static <see cref="Diagnostics.AzureEventSourceListener"/> which will redirect SDK logging
        /// to Console.Out for easy debugging.
        /// </summary>
        private static TestLogger Logger { get; set; }

        /// <summary>
        /// Start logging events to the console if debugging or in Live mode.
        /// This will run once before any tests.
        /// </summary>
        [OneTimeSetUp]
        public void InitializeRecordedTestClass()
        {
            if (Mode == RecordedTestMode.Live || Debugger.IsAttached)
            {
                Logger = new TestLogger();
            }

            if (Mode != RecordedTestMode.Live)
            {
                _proxy = TestProxy.Start(UseLocalDebugProxy);
            }
        }

        /// <summary>
        /// Do necessary cleanup.
        /// This will run once after all tests have finished.
        /// </summary>
        [OneTimeTearDown]
        public void TearDownRecordedTestClass()
        {
            Logger?.Dispose();
            Logger = null;

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

        protected async Task SetProxyOptionsAsync(ProxyOptions options)
        {
            if (Mode == RecordedTestMode.Record && options != null)
            {
                await _proxy.Client.SetRecordingTransportOptionsAsync(Recording.RecordingId, options).ConfigureAwait(false);
            }
        }

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
                throw new IgnoreException((string)test.Properties.Get("_SkipRecordings"));
            }

            if (Mode == RecordedTestMode.Live &&
                test.Properties.ContainsKey("_SkipLive"))
            {
                throw new IgnoreException((string)test.Properties.Get("_SkipLive"));
            }

            Recording = await CreateTestRecordingAsync(Mode, GetSessionFilePath());
            ValidateClientInstrumentation = Recording.HasRequests;

            // don't include test proxy overhead as part of test time
            _testStartTime = DateTime.UtcNow;
        }

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
                await Recording.DisposeAsync(save);

                if (Mode == RecordedTestMode.Record && save)
                {
                    AssertTestProxyToolIsInstalled();
                }
            }

            if (_proxy != null)
            {
                await _proxy.CheckProxyOutputAsync();
            }
        }

        protected internal override object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
        {
            ValidateClientInstrumentation = false;
            return base.InstrumentClient(clientType, client, preInterceptors);
        }

        protected internal override object InstrumentOperation(Type operationType, object operation)
        {
            var interceptors = AdditionalInterceptors ?? Array.Empty<IInterceptor>();
            var interceptorArray = interceptors.Concat(new IInterceptor[] { new GetOriginalInterceptor(operation), new OperationInterceptor(Mode) }).ToArray();
            return ProxyGenerator.CreateClassProxyWithTarget(
                operationType,
                new[] { typeof(IInstrumented) },
                operation,
                interceptorArray);
        }

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = null) =>
            Delay(Mode, milliseconds, playbackDelayMilliseconds);

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
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
                TestEnvironment.GlobalIsRunningInCI ||
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
                        TestEnvironment.RepositoryRoot,
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
            var output = process.StandardOutput.ReadToEnd();

            if (process != null)
            {
                process.WaitForExit();
            }

            return output != null && output.Contains("azure.sdk.tools.testproxy");
        }

        protected TestRetryHelper TestRetryHelper => new TestRetryHelper(Mode == RecordedTestMode.Playback);
    }
}

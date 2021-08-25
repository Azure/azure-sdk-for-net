// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run.
    /// </summary>
    public abstract class TestEnvironment
    {
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public static string RepositoryRoot { get; }

        private static readonly Dictionary<Type, Task> s_environmentStateCache = new Dictionary<Type, Task>();

        private readonly string _prefix;

        private TokenCredential _credential;
        private TestRecording _recording;

        private readonly Dictionary<string, string> _environmentFile = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        protected TestEnvironment()
        {
            if (RepositoryRoot == null)
            {
                throw new InvalidOperationException("Unexpected error, repository root not found");
            }

            var testProject = GetSourcePath(GetType().Assembly);
            var sdkDirectory = Path.GetFullPath(Path.Combine(RepositoryRoot, "sdk"));
            var serviceName = Path.GetFullPath(testProject)
                .Substring(sdkDirectory.Length)
                .Trim(Path.DirectorySeparatorChar)
                .Split(Path.DirectorySeparatorChar).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                throw new InvalidOperationException($"Unable to determine the service name from test project path {testProject}");
            }

            var serviceSdkDirectory = Path.Combine(sdkDirectory, serviceName);
            if (!Directory.Exists(sdkDirectory))
            {
                throw new InvalidOperationException($"SDK directory {serviceSdkDirectory} not found");
            }

            _prefix = serviceName.ToUpperInvariant() + "_";

            var testEnvironmentFile = Path.Combine(serviceSdkDirectory, "test-resources.json.env");
            if (File.Exists(testEnvironmentFile))
            {
                var json = JsonDocument.Parse(
                    ProtectedData.Unprotect(File.ReadAllBytes(testEnvironmentFile), null, DataProtectionScope.CurrentUser)
                );

                foreach (var property in json.RootElement.EnumerateObject())
                {
                    _environmentFile[property.Name] = property.Value.GetString();
                }
            }
        }

        static TestEnvironment()
        {
            // Traverse parent directories until we find an "artifacts" directory
            // parent of that would become a repo root for test environment resolution purposes
            var directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);

            while (directoryInfo.Name != "artifacts")
            {
                if (directoryInfo.Parent == null)
                {
                    return;
                }

                directoryInfo = directoryInfo.Parent;
            }

            RepositoryRoot = directoryInfo?.Parent?.FullName;
        }

        public RecordedTestMode? Mode { get; set; }

        /// <summary>
        ///   The name of the Azure subscription containing the resource group to be used for Live tests. Recorded.
        /// </summary>
        public string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");

        /// <summary>
        ///   The name of the Azure resource group to be used for Live tests. Recorded.
        /// </summary>
        public string ResourceGroup => GetRecordedVariable("RESOURCE_GROUP");

        /// <summary>
        ///   The location of the Azure resource group to be used for Live tests (e.g. westus2). Recorded.
        /// </summary>
        public string Location => GetRecordedVariable("LOCATION");

        /// <summary>
        ///   The environment of the Azure resource group to be used for Live tests (e.g. AzureCloud). Recorded.
        /// </summary>
        public string AzureEnvironment => GetRecordedVariable("ENVIRONMENT");

        /// <summary>
        ///   The name of the Azure Active Directory tenant that holds the service principal to use during Live tests. Recorded.
        /// </summary>
        public string TenantId => GetRecordedVariable("TENANT_ID");

        /// <summary>
        ///   The URL of the Azure Resource Manager to be used for management plane operations. Recorded.
        /// </summary>
        public string ResourceManagerUrl => GetRecordedOptionalVariable("RESOURCE_MANAGER_URL");

        /// <summary>
        ///   The URL of the Azure Service Management endpoint to be used for management plane authentication. Recorded.
        /// </summary>
        public string ServiceManagementUrl => GetRecordedOptionalVariable("SERVICE_MANAGEMENT_URL");

        /// <summary>
        ///   The URL of the Azure Authority host to be used for authentication. Recorded.
        /// </summary>
        public string AuthorityHostUrl => GetRecordedOptionalVariable("AZURE_AUTHORITY_HOST") ?? AzureAuthorityHosts.AzurePublicCloud.ToString();

        /// <summary>
        ///   The suffix for Azure Storage accounts for the active cloud environment, such as "core.windows.net".  Recorded.
        /// </summary>
        public string StorageEndpointSuffix => GetRecordedOptionalVariable("STORAGE_ENDPOINT_SUFFIX");

        /// <summary>
        ///   The client id of the Azure Active Directory service principal to use during Live tests. Recorded.
        /// </summary>
        public string ClientId => GetRecordedVariable("CLIENT_ID");

        /// <summary>
        ///   The client secret of the Azure Active Directory service principal to use during Live tests. Not recorded.
        /// </summary>
        public string ClientSecret => GetVariable("CLIENT_SECRET");

        public virtual TokenCredential Credential
        {
            get
            {
                if (_credential != null)
                {
                    return _credential;
                }

                if (Mode == RecordedTestMode.Playback)
                {
                    _credential = new MockCredential();
                }
                else
                {
                    _credential = new ClientSecretCredential(
                        GetVariable("TENANT_ID"),
                        GetVariable("CLIENT_ID"),
                        GetVariable("CLIENT_SECRET"),
                        new ClientSecretCredentialOptions()
                        {
                             AuthorityHost = new Uri(GetVariable("AZURE_AUTHORITY_HOST"))
                        }
                    );
                }

                return _credential;
            }
        }

        /// <summary>
        /// Returns whether environment is ready to use. Should be overridden to provide service specific sampling scenario.
        /// The test framework will wait until this returns true before starting tests.
        /// Use this place to hook up logic that polls if eventual consistency has happened.
        ///
        /// Return true if environment is ready to use.
        /// Return false if environment is not ready to use and framework should wait.
        /// Throw if you want to fail the run fast.
        /// </summary>
        /// <returns>Whether environment is ready to use.</returns>
        protected virtual ValueTask<bool> IsEnvironmentReadyAsync()
        {
            return new ValueTask<bool>(true);
        }

        /// <summary>
        /// Waits until environment becomes ready to use. See <see cref="IsEnvironmentReadyAsync"/> to define sampling scenario.
        /// </summary>
        /// <returns>A task.</returns>
        public async ValueTask WaitForEnvironmentAsync()
        {
            if (GlobalIsRunningInCI && Mode == RecordedTestMode.Live)
            {
                Task task;
                lock (s_environmentStateCache)
                {
                    if (!s_environmentStateCache.TryGetValue(GetType(), out task))
                    {
                        task = WaitForEnvironmentInternalAsync();
                        s_environmentStateCache[GetType()] = task;
                    }
                }
                await task;
            }
        }

        private async Task WaitForEnvironmentInternalAsync()
        {
            int numberOfTries = 60;
            TimeSpan delay = TimeSpan.FromSeconds(10);
            for (int i = 0; i < numberOfTries; i++)
            {
                var isReady = await IsEnvironmentReadyAsync();
                if (isReady)
                {
                    return;
                }
                await Task.Delay(delay);
            }

            throw new InvalidOperationException("The environment has not become ready, check your TestEnvironment.IsEnvironmentReady scenario.");
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// </summary>
        protected string GetRecordedOptionalVariable(string name)
        {
            return GetRecordedOptionalVariable(name, _ => { });
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// </summary>
        protected string GetRecordedOptionalVariable(string name, Action<RecordedVariableOptions> options)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return GetRecordedValue(name);
            }

            string value = GetOptionalVariable(name);

            if (!Mode.HasValue)
            {
                return value;
            }

            if (_recording == null)
            {
                throw new InvalidOperationException("Recorded value should not be set outside the test method invocation");
            }

            // If the value was populated, sanitize before recording it.

            string sanitizedValue = value;

            if (!string.IsNullOrEmpty(value))
            {
                var optionsInstance = new RecordedVariableOptions();
                options?.Invoke(optionsInstance);
                sanitizedValue = optionsInstance.Apply(sanitizedValue);
            }

            _recording?.SetVariable(name, sanitizedValue);
            return value;
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetRecordedVariable(string name)
        {
            return GetRecordedVariable(name, null);
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetRecordedVariable(string name, Action<RecordedVariableOptions> options)
        {
            var value = GetRecordedOptionalVariable(name, options);
            EnsureValue(name, value);
            return value;
        }

        /// <summary>
        /// Returns an environment variable value or null when variable is not found.
        /// </summary>
        protected string GetOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            // Prefixed name overrides non-prefixed
            var value = Environment.GetEnvironmentVariable(prefixedName);

            if (value == null)
            {
                _environmentFile.TryGetValue(prefixedName, out value);
            }

            if (value == null)
            {
                value = Environment.GetEnvironmentVariable(name);
            }

            if (value == null)
            {
                value = Environment.GetEnvironmentVariable($"AZURE_{name}");
            }

            if (value == null)
            {
                _environmentFile.TryGetValue(name, out value);
            }

            return value;
        }

        /// <summary>
        /// Returns an environment variable value.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetVariable(string name)
        {
            var value = GetOptionalVariable(name);
            EnsureValue(name, value);
            return value;
        }

        private void EnsureValue(string name, string value)
        {
            if (value == null)
            {
                var prefixedName = _prefix + name;
                throw new InvalidOperationException(
                    $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                    "Make sure the test environment was initialized using eng/common/TestResources/New-TestResources.ps1 script.");
            }
        }

        public void SetRecording(TestRecording recording)
        {
            _credential = null;
            _recording = recording;
        }

        private string GetRecordedValue(string name)
        {
            if (_recording == null)
            {
                throw new InvalidOperationException("Recorded value should not be retrieved outside the test method invocation");
            }

            return _recording.GetVariable(name, null);
        }

        internal static string GetSourcePath(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            var testProject = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().Single(a => a.Key == "SourcePath").Value;
            if (string.IsNullOrEmpty(testProject))
            {
                throw new InvalidOperationException($"Unable to determine the test directory for {assembly}");
            }
            return testProject;
        }

        /// <summary>
        /// Determines if the current environment is Azure DevOps.
        /// </summary>
        public static bool GlobalIsRunningInCI => Environment.GetEnvironmentVariable("TF_BUILD") != null;

        /// <summary>
        /// Determines if the current global test mode.
        /// </summary>
        internal static RecordedTestMode GlobalTestMode
        {
            get
            {
                string modeString = TestContext.Parameters["TestMode"] ?? Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

                RecordedTestMode mode = RecordedTestMode.Playback;
                if (!string.IsNullOrEmpty(modeString))
                {
                    mode = (RecordedTestMode)Enum.Parse(typeof(RecordedTestMode), modeString, true);
                }

                return mode;
            }
        }

        /// <summary>
        /// Determines if tests that use <see cref="ClientTestFixtureAttribute"/> should only test the latest version.
        /// </summary>
        internal static bool GlobalTestOnlyLatestVersion
        {
            get
            {
                string switchString = TestContext.Parameters["OnlyLiveTestLatestServiceVersion"] ?? Environment.GetEnvironmentVariable("AZURE_ONLY_TEST_LATEST_SERVICE_VERSION");

                bool.TryParse(switchString, out bool onlyTestLatestServiceVersion);

                return onlyTestLatestServiceVersion;
            }
        }

        /// <summary>
        /// Determines service versions that would be tested in tests that use <see cref="ClientTestFixtureAttribute"/>.
        /// NOTE: this variable only narrows the set of versions defined in the attribute
        /// </summary>
        internal static string[] GlobalTestServiceVersions
        {
            get
            {
                string switchString = TestContext.Parameters["LiveTestServiceVersions"] ?? Environment.GetEnvironmentVariable("AZURE_LIVE_TEST_SERVICE_VERSIONS") ?? string.Empty;

                return switchString.Split(new char[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// Determines if tests that use <see cref="RecordedTestAttribute"/> should try to re-record on failure.
        /// </summary>
        internal static bool GlobalDisableAutoRecording
        {
            get
            {
                string switchString = TestContext.Parameters["DisableAutoRecording"] ?? Environment.GetEnvironmentVariable("AZURE_DISABLE_AUTO_RECORDING");

                bool.TryParse(switchString, out bool disableAutoRecording);

                return disableAutoRecording || GlobalIsRunningInCI;
            }
        }
    }
}

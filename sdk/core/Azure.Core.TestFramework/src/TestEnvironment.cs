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
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Azure.Core.Pipeline;
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

        public static string DevCertPath { get; }

        public const string DevCertPassword = "password";

        private static readonly Dictionary<Type, Task> s_environmentStateCache = new();

        private readonly string _prefix;

        private TokenCredential _credential;
        private TestRecording _recording;
        private readonly string _serviceName;

        private Dictionary<string, string> _environmentFile;
        private readonly string _serviceSdkDirectory;

        private static readonly HashSet<Type> s_bootstrappingAttemptedTypes = new();
        private static readonly object s_syncLock = new();
        private Exception _bootstrappingException;
        private readonly Type _type;
        private readonly ClientDiagnostics _clientDiagnostics;

        protected TestEnvironment()
        {
            if (RepositoryRoot == null)
            {
                throw new InvalidOperationException("Unexpected error, repository root not found");
            }

            var testProject = GetSourcePath(GetType().Assembly);
            var sdkDirectory = Path.GetFullPath(Path.Combine(RepositoryRoot, "sdk"));
            _serviceName = Path.GetFullPath(testProject)
                .Substring(sdkDirectory.Length)
                .Trim(Path.DirectorySeparatorChar)
                .Split(Path.DirectorySeparatorChar).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(_serviceName))
            {
                throw new InvalidOperationException($"Unable to determine the service name from test project path {testProject}");
            }

            _serviceSdkDirectory = Path.Combine(sdkDirectory, _serviceName);
            if (!Directory.Exists(sdkDirectory))
            {
                throw new InvalidOperationException($"SDK directory {_serviceSdkDirectory} not found");
            }

            _prefix = _serviceName.ToUpperInvariant() + "_";
            _type = GetType();
            _clientDiagnostics = new ClientDiagnostics(ClientOptions.Default);

            ParseEnvironmentFile();
        }

        private void ParseEnvironmentFile()
        {
            _environmentFile = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var testEnvironmentFiles = new[]
            {
                Path.Combine(_serviceSdkDirectory, "test-resources.bicep.env"),
                Path.Combine(_serviceSdkDirectory, "test-resources.json.env")
            };

            foreach (var testEnvironmentFile in testEnvironmentFiles)
            {
                if (File.Exists(testEnvironmentFile))
                {
                    var json = JsonDocument.Parse(
                        ProtectedData.Unprotect(File.ReadAllBytes(testEnvironmentFile), null, DataProtectionScope.CurrentUser)
                    );

                    foreach (var property in json.RootElement.EnumerateObject())
                    {
                        _environmentFile[property.Name] = property.Value.GetString();
                    }

                    break;
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

            DevCertPath = Path.Combine(
                RepositoryRoot,
                "eng",
                "common",
                "testproxy",
                "dotnet-devcert.pfx");
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
        public string ClientId => GetRecordedOptionalVariable("CLIENT_ID");

        /// <summary>
        ///   The client secret of the Azure Active Directory service principal to use during Live tests. Not recorded.
        /// </summary>
        public string ClientSecret => GetOptionalVariable("CLIENT_SECRET");

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
                    var clientSecret = ClientSecret;
                    if (string.IsNullOrWhiteSpace(clientSecret))
                    {
                        _credential = new DefaultAzureCredential(
                            new DefaultAzureCredentialOptions { ExcludeManagedIdentityCredential = true });
                    }
                    else
                    {
                        // If the recording is null but we are in Record Mode this means the Credential is being used
                        // outside of a test (for example, in ExtendResourceGroupExpirationAsync method). Attempt to use the env
                        // vars, but don't cache the credential so that subsequent usages of this property that are within a
                        // test will store the variables in the recording. For example, in the ExtendResourceGroupExpirationAsync method.
                        if (_recording == null)
                        {
                            return new ClientSecretCredential(
                                GetVariable("TENANT_ID"),
                                GetVariable("CLIENT_ID"),
                                clientSecret,
                                new ClientSecretCredentialOptions { AuthorityHost = new Uri(GetVariable("AZURE_AUTHORITY_HOST")) });
                        }

                        _credential = new ClientSecretCredential(
                            TenantId,
                            ClientId,
                            clientSecret,
                            new ClientSecretCredentialOptions { AuthorityHost = new Uri(AuthorityHostUrl) });
                    }
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
            Task task;
            lock (s_environmentStateCache)
            {
                if (!s_environmentStateCache.TryGetValue(_type, out task))
                {
                    task = WaitForEnvironmentInternalAsync();
                    s_environmentStateCache[_type] = task;
                }
            }
            await task;
        }

        private async Task WaitForEnvironmentInternalAsync()
        {
            if (GlobalIsRunningInCI)
            {
                if (Mode == RecordedTestMode.Live)
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

                    throw new InvalidOperationException(
                        "The environment has not become ready, check your TestEnvironment.IsEnvironmentReady scenario.");
                }
            }
            else
            {
                await ExtendResourceGroupExpirationAsync();
            }
        }

        private async Task ExtendResourceGroupExpirationAsync()
        {
            string resourceGroup = GetOptionalVariable("RESOURCE_GROUP");

            if (Mode is not (RecordedTestMode.Live or RecordedTestMode.Record) || DisableBootstrapping || string.IsNullOrEmpty(resourceGroup))
            {
                return;
            }

            string subscription = GetVariable("SUBSCRIPTION_ID");

            HttpPipeline pipeline = HttpPipelineBuilder.Build(ClientOptions.Default, new BearerTokenAuthenticationPolicy(Credential, "https://management.azure.com/.default"));

            // create the GET request for the resource group information
            Request request = pipeline.CreateRequest();
            Uri uri = new Uri($"{GetVariable("RESOURCE_MANAGER_URL")}/subscriptions/{subscription}/resourcegroups/{resourceGroup}?api-version=2021-04-01");
            request.Uri.Reset(uri);
            request.Method = RequestMethod.Get;

            // send the GET request
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            // resource group not valid - prompt to create new resources
            if (response.Status is 403 or 404)
            {
                BootStrapTestResources();
                return;
            }

            // unexpected response => throw an exception
            if (response.Status != 200)
            {
                throw new RequestFailedException(response);
            }

            // parse the response
            JsonElement json = JsonDocument.Parse(response.Content).RootElement;
            if (json.TryGetProperty("tags", out JsonElement tags) && tags.TryGetProperty("DeleteAfter", out JsonElement deleteAfter))
            {
                DateTimeOffset deleteDto = DateTimeOffset.Parse(deleteAfter.GetString());
                if (deleteDto.Subtract(DateTimeOffset.Now) < TimeSpan.FromDays(5))
                {
                    // construct the JSON to send for PATCH request
                    using var stream = new MemoryStream();
                    var writer = new Utf8JsonWriter(stream);
                    writer.WriteStartObject();
                    writer.WritePropertyName("tags");
                    writer.WriteStartObject();

                    // even though this is a PATCH operation, we still need to include all other tags
                    // otherwise they will be deleted.
                    foreach (JsonProperty property in tags.EnumerateObject())
                    {
                        if (property.NameEquals("DeleteAfter"))
                        {
                            DateTimeOffset newTime = deleteDto.AddDays(5);
                            writer.WriteString("DeleteAfter", newTime);
                        }
                        else
                        {
                            property.WriteTo(writer);
                        }
                    }

                    writer.WriteEndObject();
                    writer.WriteEndObject();
                    writer.Flush();

                    // create the PATCH request
                    request = pipeline.CreateRequest();
                    request.Uri.Reset(uri);
                    request.Method = RequestMethod.Patch;
                    request.Headers.SetValue("Content-Type", "application/json");
                    stream.Position = 0;
                    request.Content = RequestContent.Create(stream);

                    // send the PATCH request
                    response = await pipeline.SendRequestAsync(request, CancellationToken.None);
                    if (response.Status != 200)
                    {
                        throw new RequestFailedException(response);
                    }
                }
            }
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

            if (Mode is null or RecordedTestMode.Live)
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
            if (value == null)
            {
                BootStrapTestResources();
                value = GetRecordedOptionalVariable(name, options);
            }
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
            if (value == null)
            {
                BootStrapTestResources();
                value = GetOptionalVariable(name);
            }
            EnsureValue(name, value);
            return value;
        }

        private void EnsureValue(string name, string value)
        {
            if (value == null)
            {
                string prefixedName = _prefix + name;
                string message = $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                                 "Make sure the test environment was initialized using the eng/common/TestResources/New-TestResources.ps1 script.";
                if (_bootstrappingException != null)
                {
                    message += Environment.NewLine + "Resource creation failed during the test run. Make sure PowerShell version 6 or higher is installed.";
                    throw new InvalidOperationException(
                        message,
                        _bootstrappingException);
                }

                throw new InvalidOperationException(message);
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

        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

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

        /// <summary>
        /// Determines if the bootstrapping prompt and automatic resource group expiration extension should be disabled.
        /// </summary>
        internal static bool DisableBootstrapping
        {
            get
            {
                string switchString = TestContext.Parameters["DisableBootstrapping"] ?? Environment.GetEnvironmentVariable("AZURE_DISABLE_BOOTSTRAPPING");

                bool.TryParse(switchString, out bool disableBootstrapping);

                return disableBootstrapping;
            }
        }

        /// <summary>
        /// Determines whether to enable the test framework to proxy traffic through fiddler.
        /// </summary>
        internal static bool EnableFiddler
        {
            get
            {
                string switchString = TestContext.Parameters["EnableFiddler"] ??
                                      Environment.GetEnvironmentVariable("AZURE_ENABLE_FIDDLER");

                bool.TryParse(switchString, out bool enableFiddler);

                return enableFiddler;
            }
        }

        /// <summary>
        /// Determines whether to enable debug level proxy logging. Errors are logged by default.
        /// </summary>
        internal static bool EnableTestProxyDebugLogs
        {
            get
            {
                string switchString = TestContext.Parameters[nameof(EnableTestProxyDebugLogs)] ??
                                      Environment.GetEnvironmentVariable("AZURE_ENABLE_TEST_PROXY_DEBUG_LOGS");

                bool.TryParse(switchString, out bool enableProxyLogging);

                return enableProxyLogging;
            }
        }

        private void BootStrapTestResources()
        {
            lock (s_syncLock)
            {
                if (DisableBootstrapping)
                {
                    return;
                }
                try
                {
                    if (!IsWindows ||
                        s_bootstrappingAttemptedTypes.Contains(_type) ||
                        Mode == RecordedTestMode.Playback ||
                        GlobalIsRunningInCI)
                    {
                        return;
                    }

                    string path = Path.Combine(
                        RepositoryRoot,
                        "eng",
                        "scripts",
                        $"New-TestResources-Bootstrapper.ps1 {_serviceName}");

                        var processInfo = new ProcessStartInfo(
                        @"pwsh.exe",
                        path)
                    {
                        UseShellExecute = true
                    };
                    Process process = null;
                    try
                    {
                        process = Process.Start(processInfo);
                    }
                    catch (Exception ex)
                    {
                        _bootstrappingException = ex;
                    }

                    if (process != null)
                    {
                        process.WaitForExit();
                        ParseEnvironmentFile();
                    }
                }
                finally
                {
                    s_bootstrappingAttemptedTypes.Add(_type);
                }
            }
        }
    }
}

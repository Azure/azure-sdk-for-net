// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Core.TestFramework
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run.
    /// </summary>
    public abstract class TestEnvironment
    {
        private static readonly string RepositoryRoot;
        private readonly string _prefix;

        private TokenCredential _credential;
        private TestRecording _recording;

        private readonly Dictionary<string, string> _environmentFile = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        protected TestEnvironment(string serviceName)
        {
            _prefix = serviceName.ToUpperInvariant() + "_";
            if (RepositoryRoot == null)
            {
                throw new InvalidOperationException("Unexpected error, repository root not found");
            }

            var sdkDirectory = Path.Combine(RepositoryRoot, "sdk", serviceName);
            if (!Directory.Exists(sdkDirectory))
            {
                throw new InvalidOperationException($"SDK directory {sdkDirectory} not found");
            }

            var testEnvironmentFile = Path.Combine(RepositoryRoot, "sdk", serviceName, "test-resources.json.env");
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

        internal RecordedTestMode? Mode { get; set; }

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
        public string AuthorityHostUrl => GetRecordedOptionalVariable("AZURE_AUTHORITY_HOST");

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

        public TokenCredential Credential
        {
            get
            {
                if (_credential != null)
                {
                    return _credential;
                }

                if (Mode == RecordedTestMode.Playback)
                {
                    _credential = new TestCredential();
                }
                else
                {
                    _credential = new ClientSecretCredential(
                        GetVariable("TENANT_ID"),
                        GetVariable("CLIENT_ID"),
                        GetVariable("CLIENT_SECRET")
                    );
                }

                return _credential;
            }
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// </summary>
        protected string GetRecordedOptionalVariable(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return GetRecordedValue(name);
            }

            string value = GetOptionalVariable(name);

            SetRecordedValue(name, value);

            return value;
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetRecordedVariable(string name)
        {
            var value = GetRecordedOptionalVariable(name);
            EnsureValue(name, value);
            return value;
        }

        /// <summary>
        /// Returns an environment variable value or null when variable is not found.
        /// </summary>
        protected string GetOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            // Environment variables override the environment file
            var value = Environment.GetEnvironmentVariable(prefixedName) ??
                        Environment.GetEnvironmentVariable(name);

            if (value == null)
            {
                _environmentFile.TryGetValue(prefixedName, out value);
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

        private void SetRecordedValue(string name, string value)
        {
            if (!Mode.HasValue)
            {
                return;
            }

            if (_recording == null)
            {
                throw new InvalidOperationException("Recorded value should not be set outside the test method invocation");
            }

            _recording?.SetVariable(name, value);
        }

        private class TestCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Tests.Shared
{
    /// <summary>
    /// Restores the automatic test-resource bootstrapping that Azure.Core.TestFramework performed in
    /// its base class but which the unbranded Microsoft.ClientModel.TestFramework leaves for each
    /// <see cref="TestEnvironment"/> to wire up: reading the DPAPI-protected .env written by
    /// New-TestResources.ps1 -OutFile, and pointing at the bootstrapper script that provisions
    /// resources when a required variable is missing.
    /// </summary>
    internal static class AiTestEnvironmentBootstrap
    {
        // The sdk/<service> directory that owns test-resources.json (and its generated .env).
        private const string ServiceDirectory = "ai";

        // Environment switch honored by Microsoft.ClientModel.TestFramework.TestEnvironment to skip
        // launching the resource bootstrapping script when a required variable is missing. Setting it
        // is version-robust: older package versions expose TestEnvironment.DisableBootstrapping as
        // internal, so this switch is the only cross-version way to opt out of bootstrapping.
        private const string DisableBootstrappingSwitch = "CLIENTMODEL_DISABLE_BOOTSTRAPPING";

        public static TokenCredential CreateCredential()
        {
            string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
            if (string.Equals(Environment.GetEnvironmentVariable("TF_BUILD"), "true", StringComparison.OrdinalIgnoreCase))
            {
                string pipelineTenantId = GetRequiredPipelineVariable("AZURESUBSCRIPTION_TENANT_ID");
                if (!string.IsNullOrWhiteSpace(tenantId) &&
                    !string.Equals(tenantId, pipelineTenantId, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("The Azure Pipelines service connection tenant does not match AZURE_TENANT_ID.");
                }

                // DefaultAzureCredential can select the agent's managed identity instead of the service connection.
                return new AzurePipelinesCredential(
                    pipelineTenantId,
                    GetRequiredPipelineVariable("AZURESUBSCRIPTION_CLIENT_ID"),
                    GetRequiredPipelineVariable("AZURESUBSCRIPTION_SERVICE_CONNECTION_ID"),
                    GetRequiredPipelineVariable("SYSTEM_ACCESSTOKEN"));
            }

            return string.IsNullOrWhiteSpace(tenantId)
                ? new DefaultAzureCredential()
                : new DefaultAzureCredential(new DefaultAzureCredentialOptions { TenantId = tenantId });
        }

        private static string GetRequiredPipelineVariable(string name)
        {
            string value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"Azure Pipelines live tests require {name} from an authorized AzureCLI or AzurePowerShell task.");
            }

            return value;
        }

        /// <summary>
        /// Disables the automatic resource bootstrapping script so that a missing variable causes the
        /// test to fail with a clear "missing environment variable" error instead of launching resource
        /// creation. Intended for use when a test environment has already been provisioned (an env file
        /// was found), where the numerous settings the suites require exceed what the deployment
        /// template/scripts pre-create.
        /// </summary>
        public static void DisableResourceBootstrapping()
        {
            Environment.SetEnvironmentVariable(DisableBootstrappingSwitch, "true");
        }

        /// <summary>
        /// Value for <see cref="TestEnvironment.PathToTestResourceBootstrappingScript"/> so that a
        /// missing variable launches eng/scripts/New-TestResources-Bootstrapper.ps1, mirroring the
        /// legacy Azure.Core.TestFramework behavior. Null when the repository root cannot be located
        /// (for example when tests run from an installed package rather than the repository).
        /// </summary>
        public static string BootstrappingScriptPath
        {
            get
            {
                var root = TestEnvironment.RepositoryRoot;
                if (string.IsNullOrEmpty(root))
                {
                    return null;
                }

                // The script path and its service argument are passed together as the single pwsh
                // argument string (see TestEnvironment.BootStrapTestResources), matching the legacy
                // Azure.Core.TestFramework construction.
                var scriptPath = Path.Combine(root, "eng", "scripts", "New-TestResources-Bootstrapper.ps1");
                return $"\"{scriptPath}\" {ServiceDirectory}";
            }
        }

        /// <summary>
        /// Returns the values persisted by New-TestResources.ps1 -OutFile in the DPAPI-protected
        /// sdk/ai/test-resources.json.env (or test-resources.bicep.env), layered over the supplied
        /// seed entries. When the file is absent, only the seed entries are returned so that tests
        /// still fall back to live process environment variables.
        /// </summary>
        /// <param name="seed">Seed values to layer the environment file on top of.</param>
        /// <param name="environmentFileFound">
        /// Set to <see langword="true"/> when a DPAPI-protected environment file was located and
        /// parsed, indicating a test environment has already been provisioned. Callers can use this
        /// to decide whether a missing setting should trigger resource bootstrapping.
        /// </param>
        public static Dictionary<string, string> ReadEnvironmentFile(IDictionary<string, string> seed, out bool environmentFileFound)
        {
            environmentFileFound = false;
            var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (seed != null)
            {
                foreach (var entry in seed)
                {
                    values[entry.Key] = entry.Value;
                }
            }

            var root = TestEnvironment.RepositoryRoot;
            if (string.IsNullOrEmpty(root) || !TestEnvironment.IsWindows)
            {
                return values;
            }

            var serviceDirectory = Path.Combine(root, "sdk", ServiceDirectory);
            var candidates = new[]
            {
                Path.Combine(serviceDirectory, "test-resources.bicep.env"),
                Path.Combine(serviceDirectory, "test-resources.json.env"),
            };

            foreach (var candidate in candidates)
            {
                if (!File.Exists(candidate))
                {
                    continue;
                }

#pragma warning disable CA1416 // DPAPI env files are only produced/consumed on Windows.
                var decrypted = ProtectedData.Unprotect(File.ReadAllBytes(candidate), null, DataProtectionScope.CurrentUser);
#pragma warning restore CA1416
                using var document = JsonDocument.Parse(decrypted);
                foreach (var property in document.RootElement.EnumerateObject())
                {
                    values[property.Name] = property.Value.GetString();
                }

                environmentFileFound = true;
                break;
            }

            return values;
        }
    }
}

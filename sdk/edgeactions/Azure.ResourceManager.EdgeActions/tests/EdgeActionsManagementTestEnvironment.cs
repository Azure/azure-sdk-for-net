// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionsManagementTestEnvironment : TestEnvironment
    {
        private static readonly object s_setupLock = new object();
        private static bool s_accountInitialized;
        private static Task s_localSetup;

        private bool UseAzureCli => ShouldUseAzureCli(Mode, GetOptionalVariable("USE_AZURE_CLI"),
            GlobalIsRunningInCI, GetOptionalVariable("CLIENT_SECRET"), GetOptionalVariable("SYSTEM_ACCESSTOKEN"));

        protected override TokenCredential CreateDeveloperCredential()
        {
            if (!UseAzureCli)
            {
                return base.CreateDeveloperCredential();
            }
            InitializeAzureCliAccount();
            return new AzureCliCredential(new AzureCliCredentialOptions
            {
                TenantId = GetOptionalVariable("TENANT_ID"),
                Subscription = GetOptionalVariable("SUBSCRIPTION_ID")
            });
        }

        internal Task InitializeLocalAzureCliAsync(ArmEnvironment environment)
        {
            if (!UseAzureCli)
            {
                return Task.CompletedTask;
            }
            lock (s_setupLock)
            {
                return s_localSetup ??= InitializeLocalAzureCliCoreAsync(environment);
            }
        }

        internal static bool ShouldUseAzureCli(RecordedTestMode? mode, string enabled, bool isCI, string clientSecret, string pipelineToken)
        {
            return mode is RecordedTestMode.Record or RecordedTestMode.Live
                && (string.IsNullOrWhiteSpace(enabled) || string.Equals(enabled, "true", StringComparison.OrdinalIgnoreCase))
                && !isCI
                && string.IsNullOrWhiteSpace(clientSecret)
                && string.IsNullOrWhiteSpace(pipelineToken);
        }

        private void InitializeAzureCliAccount()
        {
            lock (s_setupLock)
            {
                if (s_accountInitialized)
                {
                    return;
                }
                string subscription = GetOptionalVariable("SUBSCRIPTION_ID");
                string tenant = GetOptionalVariable("TENANT_ID");
                var account = ResolveCliAccount(ReadAzureCliAccount(subscription), subscription, tenant);
                if (string.IsNullOrWhiteSpace(subscription))
                {
                    Environment.SetEnvironmentVariable("EDGEACTIONS_SUBSCRIPTION_ID", account.SubscriptionId);
                }
                if (string.IsNullOrWhiteSpace(tenant))
                {
                    Environment.SetEnvironmentVariable("EDGEACTIONS_TENANT_ID", account.TenantId);
                }
                s_accountInitialized = true;
            }
        }

        private async Task InitializeLocalAzureCliCoreAsync(ArmEnvironment environment)
        {
            TokenCredential credential = Credential;
            string subscription = GetOptionalVariable("SUBSCRIPTION_ID");
            // Subscription setup is deliberately outside Test Proxy recordings and never runs in playback.
            var client = new ArmClient(credential, subscription, new ArmClientOptions { Environment = environment });
            using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(10));
            try
            {
                await EnsureCdnRegisteredAsync(client, subscription, timeout.Token);
            }
            catch (OperationCanceledException exception) when (timeout.IsCancellationRequested)
            {
                throw new TimeoutException("Microsoft.Cdn registration did not complete within 10 minutes.", exception);
            }
        }

        internal static (string SubscriptionId, string TenantId) ResolveCliAccount(string json, string subscription, string tenant)
        {
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement account = document.RootElement;
            if (!account.TryGetProperty("id", out JsonElement id) || id.ValueKind != JsonValueKind.String
                || !Guid.TryParse(id.GetString(), out Guid subscriptionId)
                || !account.TryGetProperty("tenantId", out JsonElement tenantValue) || tenantValue.ValueKind != JsonValueKind.String
                || !Guid.TryParse(tenantValue.GetString(), out Guid tenantId))
            {
                throw new InvalidOperationException("Azure CLI did not return valid subscription and tenant IDs. Run az login and select a subscription with az account set.");
            }
            if (!string.IsNullOrWhiteSpace(subscription) && Guid.Parse(subscription) != subscriptionId)
            {
                throw new InvalidOperationException("The Azure CLI account does not match the configured test subscription.");
            }
            if (!string.IsNullOrWhiteSpace(tenant) && Guid.Parse(tenant) != tenantId)
            {
                throw new InvalidOperationException("The configured test tenant does not match the Azure CLI subscription's tenant.");
            }
            return (subscriptionId.ToString(), tenantId.ToString());
        }

        internal static async Task EnsureCdnRegisteredAsync(ArmClient client, string subscription, CancellationToken cancellationToken)
        {
            ResourceProviderResource provider = (await client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscription))
                .GetResourceProviders().GetAsync("Microsoft.Cdn", cancellationToken: cancellationToken)).Value;
            if (string.Equals(provider.Data.RegistrationState, "Registered", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            TestContext.Progress.WriteLine("Waiting for Microsoft.Cdn registration for local EdgeActions tests.");
            if (!string.Equals(provider.Data.RegistrationState, "Registering", StringComparison.OrdinalIgnoreCase))
            {
                provider = (await provider.RegisterAsync(cancellationToken: cancellationToken)).Value;
            }
            while (!string.Equals(provider.Data.RegistrationState, "Registered", StringComparison.OrdinalIgnoreCase))
            {
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                provider = (await provider.GetAsync(cancellationToken: cancellationToken)).Value;
            }
        }

        private static string ReadAzureCliAccount(string subscription)
        {
            string arguments = "account show --output json --only-show-errors";
            if (!string.IsNullOrWhiteSpace(subscription))
            {
                arguments += $" --subscription {Guid.Parse(subscription):D}";
            }
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var startInfo = new ProcessStartInfo
            {
                FileName = isWindows ? Path.Combine(Environment.SystemDirectory, "cmd.exe") : "az",
                Arguments = isWindows ? $"/d /c az {arguments}" : arguments,
                WorkingDirectory = isWindows ? Environment.SystemDirectory : Path.GetTempPath(),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true
            };
            using var process = new Process { StartInfo = startInfo };
            var output = new StringBuilder();
            var error = new StringBuilder();
            process.OutputDataReceived += (_, args) =>
            {
                if (args.Data != null)
                {
                    output.AppendLine(args.Data);
                }
            };
            process.ErrorDataReceived += (_, args) =>
            {
                if (args.Data != null)
                {
                    error.AppendLine(args.Data);
                }
            };
            try
            {
                process.Start();
            }
            catch (Win32Exception exception)
            {
                throw new InvalidOperationException("Unable to start Azure CLI. Install it and run az login before recording EdgeActions tests.", exception);
            }
            process.StandardInput.Close();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            if (!process.WaitForExit(60_000))
            {
#if NETFRAMEWORK
                using var terminate = Process.Start(new ProcessStartInfo(
                    Path.Combine(Environment.SystemDirectory, "taskkill.exe"), $"/PID {process.Id} /T /F")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
                if (!terminate.WaitForExit(10_000) || terminate.ExitCode != 0)
                {
                    throw new TimeoutException("Azure CLI account lookup timed out and its process tree could not be terminated.");
                }
#else
                process.Kill(entireProcessTree: true);
#endif
                throw new TimeoutException("Azure CLI account lookup exceeded 60 seconds.");
            }
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException($"Azure CLI account lookup failed. Check az login and the selected subscription. {error}");
            }
            return output.ToString();
        }
    }
}

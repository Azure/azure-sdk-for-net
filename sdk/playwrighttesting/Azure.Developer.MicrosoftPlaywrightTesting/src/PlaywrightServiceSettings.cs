// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using Azure.Core;
using Azure.Identity;

namespace Azure.Developer.MicrosoftPlaywrightTesting;

/// <summary>
/// Settings for the Playwright service.
/// </summary>
public class PlaywrightServiceSettings
{
    internal OSPlatform? Os { get; set; }
    internal string? RunId { get; set; }
    internal string? ExposeNetwork { get; set; }
    internal string DefaultAuth { get; set; }
    internal bool UseCloudHostedBrowsers { get; set; }
    internal TokenCredential AzureTokenCredential { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceSettings"/> class.
    /// </summary>
    /// <param name="os">The operating system.</param>
    /// <param name="runId">The run ID.</param>
    /// <param name="exposeNetwork">The network exposure.</param>
    /// <param name="defaultAuth">The default authentication mechanism.</param>
    /// <param name="useCloudHostedBrowsers">Whether to use cloud-hosted browsers.</param>
    /// <param name="azureTokenCredentialType">The Azure token credential type.</param>
    /// <param name="managedIdentityClientId">The managed identity client ID.</param>
    public PlaywrightServiceSettings(OSPlatform? os = null, string? runId = null, string? exposeNetwork = null, string? defaultAuth = null, string? useCloudHostedBrowsers = null, string? azureTokenCredentialType = null, string? managedIdentityClientId = null)
    {
        Os = os;
        RunId = runId;
        ExposeNetwork = exposeNetwork;
        DefaultAuth = defaultAuth ?? ServiceAuth.Entra;
        UseCloudHostedBrowsers = string.IsNullOrEmpty(useCloudHostedBrowsers) || bool.Parse(useCloudHostedBrowsers!);
        AzureTokenCredential = GetTokenCredential(azureTokenCredentialType, managedIdentityClientId);
        Validate();
    }

    private void Validate()
    {
        if (Os != null && Os != OSPlatform.Linux && Os != OSPlatform.Windows)
        {
            throw new System.Exception($"Invalid value for {nameof(Os)}: {Os}. Supported values are {ServiceOs.Linux} and {ServiceOs.Windows}");
        }
        if (!string.IsNullOrEmpty(DefaultAuth) && DefaultAuth != ServiceAuth.Entra && DefaultAuth != ServiceAuth.Token)
        {
            throw new System.Exception($"Invalid value for {nameof(DefaultAuth)}: {DefaultAuth}. Supported values are {ServiceAuth.Entra} and {ServiceAuth.Token}");
        }
    }

    private static TokenCredential GetTokenCredential(string? azureTokenCredentialType, string? managedIdentityClientId)
    {
        if (string.IsNullOrEmpty(azureTokenCredentialType) && string.IsNullOrEmpty(managedIdentityClientId))
            return new DefaultAzureCredential();
        if (azureTokenCredentialType == AzureTokenCredentialType.ManagedIdentityCredential)
        {
            return new ManagedIdentityCredential(managedIdentityClientId);
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.WorkloadIdentityCredential)
        {
            return new WorkloadIdentityCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.EnvironmentCredential)
        {
            return new EnvironmentCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.AzureCliCredential)
        {
            return new AzureCliCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.AzurePowerShellCredential)
        {
            return new AzurePowerShellCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.AzureDeveloperCliCredential)
        {
            return new AzureDeveloperCliCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.SharedTokenCacheCredential)
        {
            return new SharedTokenCacheCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.VisualStudioCredential)
        {
            return new VisualStudioCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.VisualStudioCodeCredential)
        {
            return new VisualStudioCodeCredential();
        }
        else if (azureTokenCredentialType == AzureTokenCredentialType.InteractiveBrowserCredential)
        {
            return new InteractiveBrowserCredential();
        }
        else
        {
            return new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                ManagedIdentityClientId = managedIdentityClientId
            });
        }
    }
}

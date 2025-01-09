// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Identity;
using Microsoft.Extensions.Logging;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger;

/// <summary>
/// Options for the Playwright service.
/// </summary>
public class PlaywrightServiceOptions
{
    private OSPlatform? _os;
    /// <summary>
    /// Gets or sets the operating system for Playwright service.
    /// </summary>
    public OSPlatform? OS
    {
        get => _os;
        set
        {
            if (value != null && value != OSPlatform.Linux && value != OSPlatform.Windows)
            {
                throw new ArgumentException($"Invalid value for OS. Supported values are {OSPlatform.Linux}, {OSPlatform.Windows}");
            }
            _os = value;
        }
    }

    private string? _runId;
    /// <summary>
    /// Gets or sets the run ID.
    /// </summary>
    public string? RunId
    {
        get => _runId;
        set => _runId = value;
    }

    private string? _exposeNetwork;
    /// <summary>
    /// Gets or sets the expose network field for remote browsers.
    /// </summary>
    public string? ExposeNetwork
    {
        get => _exposeNetwork;
        set => _exposeNetwork = value;
    }

    private ServiceAuthType _serviceAuth = ServiceAuthType.EntraId;
    /// <summary>
    /// Gets or sets the default authentication mechanism.
    /// </summary>
    public ServiceAuthType ServiceAuth
    {
        get => _serviceAuth;
        set
        {
            if (value != ServiceAuthType.EntraId && value != ServiceAuthType.AccessToken)
            {
                throw new ArgumentException($"Invalid value for ServiceAuth. Supported values are {ServiceAuthType.EntraId}, {ServiceAuthType.AccessToken}");
            }
            _serviceAuth = value;
        }
    }

    private bool _useCloudHostedBrowsers = true;
    /// <summary>
    /// Gets or sets a flag indicating whether to use cloud-hosted browsers.
    /// </summary>
    public bool UseCloudHostedBrowsers
    {
        get => _useCloudHostedBrowsers;
        set => _useCloudHostedBrowsers = value;
    }

    internal TokenCredential AzureTokenCredential
    {
        get => GetTokenCredential(TokenCredentialType, ManagedIdentityClientId);
    }

    private string? _tokenCredentialType;
    /// <summary>
    /// Gets or sets the Azure token credential type.
    /// </summary>
    public string? TokenCredentialType
    {
        get => _tokenCredentialType;
        set => _tokenCredentialType = value;
    }

    private string? _managedIdentityClientId;
    /// <summary>
    /// Gets or sets the managed identity client ID.
    /// </summary>
    public string? ManagedIdentityClientId
    {
        get => _managedIdentityClientId;
        set => _managedIdentityClientId = value;
    }

    private ILogger? _logger;
    /// <summary>
    /// Gets or sets the logger.
    /// </summary>
    public ILogger? Logger
    {
        get => _logger;
        set => _logger = value;
    }

    /// <summary>
    /// Gets the service endpoint for Playwright service.
    /// </summary>
#pragma warning disable CA1822 // Mark members as static
    public string? ServiceEndpoint
#pragma warning restore CA1822 // Mark members as static
    {
        get => Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString());
        set => Environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), value);
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace Azure.Provisioning;

/// <summary>
/// ProvisioningDeploymentOptions defines common options that can be used for
/// deploying Azure resources.
/// </summary>
public class ProvisioningDeploymentOptions
{
    /// <summary>
    /// Gets or sets an optional <see cref="ResourceManager.ArmClient"/> to use
    /// for deploying resources.
    /// </summary>
    /// <remarks>
    /// If not provided, we'll create an a new <see cref="ResourceManager.ArmClient"/>
    /// using <see cref="DefaultArmCredential"/> and optionally
    /// <see cref="DefaultSubscriptionId"/>.
    /// </remarks>
    public ArmClient ArmClient
    {
        get
        {
            if (_armClient is null)
            {
                // TODO: Hook into IConfig story for constructing ArmClient too
                ArmClientOptions options = new();
#if EXPERIMENTAL_PROVISIONING
                ConfigureClientOptionsCallback?.Invoke(options);
#endif
                _armClient = new ArmClient(DefaultArmCredential, DefaultSubscriptionId, options);
            }
            return _armClient;
        }
        set => _armClient = value;
    }
    private ArmClient? _armClient;

    /// <summary>
    /// Gets the default subscription ID to use when creating for deploying
    /// resources.
    /// </summary>
    /// <remarks>
    /// This defaults to the standard <c>AZURE_SUBSCRIPTION_ID</c> environment
    /// variable <see href="https://azure.github.io/azure-sdk/general_azurecore.html#environment-variables">
    /// used across the Azure SDK</see>.
    /// </remarks>
    public string? DefaultSubscriptionId { get; set; } =
        Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");

    /// <summary>
    /// Gets or sets a factory function to create new instances of
    /// <see cref="TokenCredential"/> to use when <see cref="DefaultArmCredential"/>
    /// or <see cref="DefaultClientCredential"/> are not provided.  It defaults
    /// to returning new <see cref="DefaultAzureCredential"/> instances.
    /// </summary>
    /// <remarks>
    /// Check out <see cref="DefaultAzureCredential"/> and the
    /// <see cref="Azure.Identity"/> library for more information on getting
    /// started with <see cref="TokenCredential"/>.
    /// </remarks>
    public Func<TokenCredential> DefaultCredentialProvider { get; set; } =
        () => new DefaultAzureCredential();

    /// <summary>
    /// Gets or set a <see cref="TokenCredential"/> to use for creating
    /// <see cref="ResourceManager.ArmClient"/> or data-plane client instances.
    /// This value is used as the default for both <see cref="DefaultArmCredential"/>
    /// and <see cref="DefaultClientCredential"/> if they are not provided.
    /// </summary>
    /// <remarks>
    /// Check out <see cref="DefaultAzureCredential"/> and the
    /// <see cref="Azure.Identity"/> library for more information on getting
    /// started with <see cref="TokenCredential"/>.
    /// </remarks>
    public TokenCredential? DefaultCredential { get; set; }

    /// <summary>
    /// Gets or sets a <see cref="TokenCredential"/> to use for creating
    /// <see cref="ResourceManager.ArmClient"/> instances.  If no value is
    /// provided, it will be defaulted to a fresh value using
    /// <see cref="DefaultCredentialProvider"/> the first time it's
    /// accessed.
    /// </summary>
    /// <remarks>
    /// Check out <see cref="DefaultAzureCredential"/> and the
    /// <see cref="Azure.Identity"/> library for more information on getting
    /// started with <see cref="TokenCredential"/>.
    /// </remarks>
    public TokenCredential DefaultArmCredential
    {
        get
        {
            TokenCredential? credential = _defaultArmCredential ?? DefaultCredential;
            if (credential is null)
            {
                _defaultArmCredential = credential = DefaultCredentialProvider();
            }
            return credential;
        }
        set => _defaultArmCredential = value;
    }
    private TokenCredential? _defaultArmCredential;

    /// <summary>
    /// Gets or sets a <see cref="TokenCredential"/> to use for creating
    /// <see cref="ResourceManager.ArmClient"/> instances.  If no value is
    /// provided, it will be defaulted to a fresh value using
    /// <see cref="DefaultCredentialProvider"/> the first time it's
    /// accessed.
    /// </summary>
    /// <remarks>
    /// Check out <see cref="DefaultAzureCredential"/> and the
    /// <see cref="Azure.Identity"/> library for more information on getting
    /// started with <see cref="TokenCredential"/>.
    /// </remarks>
    public TokenCredential DefaultClientCredential
    {
        get
        {
            TokenCredential? credential = _defaultClientCredential ?? DefaultCredential;
            if (credential is null)
            {
                _defaultClientCredential = credential = DefaultCredentialProvider();
            }
            return credential;
        }
        set => _defaultClientCredential = value;
    }
    private TokenCredential? _defaultClientCredential;

#if EXPERIMENTAL_PROVISIONING
    /// <summary>
    /// Optional callback used to configure any <see cref="ClientOptions"/>
    /// instance used for creating <see cref="ArmClient"/> or
    /// <see cref="ProvisioningDeployment.CreateClient"/>
    /// instances.  This can be used to turn on logging, adjust retry timeouts,
    /// add pipeline policies, or anything else you'd like to set up with any
    /// Azure client.
    /// </summary>
    public Action<ClientOptions>? ConfigureClientOptionsCallback { get; set; }
#endif

    // TODO: Default CancellationToken to link to all async operations?
}

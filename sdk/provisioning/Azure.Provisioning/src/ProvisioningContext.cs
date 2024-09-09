// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;
using Azure.Provisioning.Primitives;
using Azure.ResourceManager;

namespace Azure.Provisioning;

/// <summary>
/// ProvisioningContext collects common values, settings, and functionality
/// that are used for composing, building, and deploying resources with
/// Azure.Provisioning libraries.
/// </summary>
public class ProvisioningContext
{
    /// <summary>
    /// Gets or sets the <see cref="Primitives.ProvisioningContextProvider"/> used
    /// implicitly when a <see cref="ProvisioningContext"/> is not provided.
    /// </summary>
    /// <remarks>
    /// This defaults to a <see cref="LocalProvisioningContextProvider"/>
    /// which shares the same <see cref="ProvisioningContext"/> across all
    /// operations on the same thread.
    /// </remarks>
    public static ProvisioningContextProvider Provider { get; set; }
        = new LocalProvisioningContextProvider();

    /// <summary>
    /// Gets or sets the default <see cref="Infrastructure"/> to automatically
    /// add resources to when they aren't explicitly grouped.  This will be
    /// called <c>main</c> by default and result in a <c>main.bicep</c> file
    /// being written from a <see cref="ProvisioningPlan"/>.  Adding a resource
    /// to other infrastructure will break this relationship.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This instance will be automatically refreshed whenever infrastructure
    /// is composed with <see cref="Infrastructure.Build"/> or
    /// <see cref="Resource.Build"/>.
    /// </para>
    /// <para>
    /// Adding a resource to an <see cref="Infrastructure"/> instance will
    /// break the association with any existing infrastructure, so you can also
    /// explicitly group resources with <see cref="Infrastructure.Add"/> on
    /// your own instances when preferable.
    /// </para>
    /// </remarks>
    public Infrastructure DefaultInfrastructure
    {
        get
        {
            _defaultInfrastructure ??= DefaultInfrastructureProvider();
            return _defaultInfrastructure;
        }
        set => _defaultInfrastructure = value;
    }
    private Infrastructure? _defaultInfrastructure;

    /// <summary>
    /// Gets or sets a factory to provide new values of the
    /// <see cref="DefaultInfrastructure"/> property. It gets refreshed
    /// automatically whenever infrastructure is composed with
    /// <see cref="Infrastructure.Build"/> or <see cref="Resource.Build"/>.
    /// </summary>
    public Func<Infrastructure> DefaultInfrastructureProvider { get; set; } =
        () => new Infrastructure("main");

    /// <summary>
    /// Gets or sets the collection of <see cref="PropertyResolver"/>s to apply
    /// to all resources being composed.
    /// </summary>
    public IList<PropertyResolver> PropertyResolvers { get; set; } =
    [
        new DynamicResourceNameResolver(),
        new LocationPropertyResolver(),
    ];
    // TODO: Do we want to make this less mutable like AddPipelinePolicy to
    // maintain more control over how people are able to modify these?

    #region Creating Clients
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
                ConfigureClientOptionsCallback?.Invoke(options);
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

    /// <summary>
    /// Optional callback used to configure any <see cref="ClientOptions"/>
    /// instance used for creating <see cref="ArmClient"/> or
    /// <see cref="ProvisioningDeployment.CreateClient"/>
    /// instances.  This can be used to turn on logging, adjust retry timeouts,
    /// add pipeline policies, or anything else you'd like to set up with any
    /// Azure client.
    /// </summary>
    public Action<ClientOptions>? ConfigureClientOptionsCallback { get; set; }
    #endregion Creating Clients

    /// <summary>
    /// Gets or sets a random generator.  It defaults to a new
    /// <see cref="Random"/>.
    /// </summary>
    /// <remarks>
    /// This can be helpful to set with a known seed if you want reproducible
    /// randomness for testing or debugging.
    /// </remarks>
    public Random Random { get; set; } = new Random();

    // TODO: Add a DefaultScope to allow globally scoping all resources
    // TODO: Resource resolvers
    // TODO: IConfig PropertyProvider
    // TODO: Default CancellationToken to link to all async operations
}

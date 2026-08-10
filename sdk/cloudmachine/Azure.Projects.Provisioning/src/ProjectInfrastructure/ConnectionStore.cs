// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Projects.Core;

/// <summary>
/// Base class for stores that persist feature connection information during provisioning.
/// </summary>
public abstract class ConnectionStore
{
    /// <summary>
    /// Attempts to get the feature that backs this connection store.
    /// </summary>
    /// <param name="feature">When this method returns, contains the backing feature, or <see langword="null"/> if none exists.</param>
    /// <returns><see langword="true"/> if a backing feature was found; otherwise, <see langword="false"/>.</returns>
    public virtual bool TryGetFeature(out AzureProjectFeature? feature)
    {
        feature = null;
        return false;
    }

    /// <summary>
    /// Emits a connection entry into the project infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit the connection into.</param>
    /// <param name="connectionId">The identifier for the connection.</param>
    /// <param name="endpoint">The endpoint URI for the connection.</param>
    public abstract void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint);
}

/// <summary>
/// A connection store that persists connection information as App Configuration key-value settings.
/// </summary>
public class AppConfigConnectionStore : ConnectionStore
{
    private readonly AppConfigurationFeature _appConfig;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppConfigConnectionStore"/> class with the free SKU.
    /// </summary>
    public AppConfigConnectionStore() : this(AppConfigurationFeature.SkuName.Free)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppConfigConnectionStore"/> class with the specified SKU.
    /// </summary>
    /// <param name="sku">The App Configuration SKU to use.</param>
    public AppConfigConnectionStore(AppConfigurationFeature.SkuName sku)
        : this(new AppConfigurationFeature { Sku = sku })
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="AppConfigConnectionStore"/> class with the specified App Configuration feature.
    /// </summary>
    /// <param name="appConfig">The App Configuration feature to use as the backing store.</param>
    public AppConfigConnectionStore(AppConfigurationFeature appConfig)
    {
        _appConfig = appConfig;
    }

    /// <inheritdoc/>
    public override bool TryGetFeature(out AzureProjectFeature? feature)
    {
        feature = _appConfig;
        return true;
    }

    /// <inheritdoc/>
    public override void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint, "projectConnection");
        infrastructure.AddFeature(connection);
    }
}

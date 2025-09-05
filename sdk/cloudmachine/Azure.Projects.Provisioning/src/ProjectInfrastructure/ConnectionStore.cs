// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Projects.Core;

public abstract class ConnectionStore
{
    public virtual bool TryGetFeature(out AzureProjectFeature? feature)
    {
        feature = null;
        return false;
    }

    public abstract void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint);
}

public class AppConfigConnectionStore : ConnectionStore
{
    private readonly AppConfigurationFeature _appConfig;

    public AppConfigConnectionStore() : this(AppConfigurationFeature.SkuName.Free)
    {
    }

    public AppConfigConnectionStore(AppConfigurationFeature.SkuName sku)
        : this(new AppConfigurationFeature { Sku = sku })
    {
    }
    public AppConfigConnectionStore(AppConfigurationFeature appConfig)
    {
        _appConfig = appConfig;
    }

    public override bool TryGetFeature(out AzureProjectFeature? feature)
    {
        feature = _appConfig;
        return true;
    }

    public override void EmitConnection(ProjectInfrastructure infrastructure, string connectionId, string endpoint)
    {
        AppConfigurationSettingFeature connection = new(connectionId, endpoint, "projectConnection");
        infrastructure.AddFeature(connection);
    }
}

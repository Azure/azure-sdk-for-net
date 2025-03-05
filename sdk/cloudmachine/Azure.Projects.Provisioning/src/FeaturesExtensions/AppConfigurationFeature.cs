// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using Azure.Projects.Core;
using Azure.Provisioning.AppConfiguration;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.AppConfiguration;

public class AppConfigurationFeature : AzureProjectFeature
{
    public AppConfigurationFeature()
    {
    }

    protected internal override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
    {
        ClientConnection connection = new(
            "Azure.Data.AppConfiguration.ConfigurationClient",
            $"https://{cmId}.azconfig.io",
            ClientAuthenticationMethod.Credential
        );

        connections.Add(connection);
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore appConfigResource = new("cm_app_config")
        {
            Name = infrastructure.ProjectId,
            SkuName = "Free",
        };
        infrastructure.AddResource(appConfigResource);

        FeatureRole appConfigAdmin = new(AppConfigurationBuiltInRole.GetBuiltInRoleName(AppConfigurationBuiltInRole.AppConfigurationDataOwner), AppConfigurationBuiltInRole.AppConfigurationDataOwner.ToString());
        RequiredSystemRoles.Add(appConfigResource, [appConfigAdmin]);

        return appConfigResource;
    }
}

public class AppConfigurationSettingFeature : AzureProjectFeature
{
    private static int _index = 0;

    public AppConfigurationSettingFeature(AppConfigurationFeature parent, string key, string value)
    {
        Key = key;
        Value = value;
        Parent = parent;
    }
    public string Key { get; }
    public string Value { get; }
    public AppConfigurationFeature Parent { get; }
    protected override ProvisionableResource EmitResources(ProjectInfrastructure cm)
    {
        int index = Interlocked.Increment(ref _index);
        AppConfigurationKeyValue kvp = new($"cm_config_kv{index}")
        {
            Name = this.Key,
            Value = this.Value,
            Parent = (AppConfigurationStore)this.Parent.Resource
        };
        cm.AddResource(kvp);
        return kvp;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Projects.Core;
using Azure.Provisioning.AppConfiguration;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.AppConfiguration;

internal class AppConfigurationFeature : AzureProjectFeature
{
    public AppConfigurationFeature()
    {}

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

        //ClientConnection connection = new(
        //    "Azure.Data.AppConfiguration.ConfigurationClient",
        //    $"https://{cmId}.azconfig.io",
        //    ClientAuthenticationMethod.Credential
        //);

        return appConfigResource;
    }
}

public class AppConfigurationSettingFeature : AzureProjectFeature
{
    public AppConfigurationSettingFeature(string key, string value)
    {
        Key = key;
        Value = value;
        BicepIdentifier = "cm_config_setting";
    }
    public string Key { get; }
    public string Value { get; }

    internal string BicepIdentifier { get; set; }
    internal AppConfigurationFeature? Parent { get; set; }

    protected internal override void EmitImplicitFeatures(FeatureCollection features, string projectId)
    {
        AppConfigurationFeature? account = features.FindAll<AppConfigurationFeature>().FirstOrDefault();
        if (account == default)
        {
            account = new();
            features.Add(account);
        }
        Parent = account;
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        if (Parent == null)
        {
            throw new InvalidOperationException("Parent AppConfigurationFeature is not set.");
        }

        string bicepIdentifier = infrastructure.CreateUniqueBicepIdentifier(BicepIdentifier);
        AppConfigurationKeyValue kvp = new(bicepIdentifier)
        {
            Name = this.Key,
            Value = this.Value,
            Parent = (AppConfigurationStore)Parent.Resource
        };
        infrastructure.AddResource(kvp);
        return kvp;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.AppConfiguration;

namespace Azure.Projects.AppConfiguration;

internal class AppConfigurationFeature : AzureProjectFeature
{
    public AppConfigurationFeature()
    {}

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        string bicepIdentifier = infrastructure.CreateUniqueBicepIdentifier("appConfiguration");
        AppConfigurationStore appConfigResource = new(bicepIdentifier)
        {
            Name = infrastructure.ProjectId,
            SkuName = "Free",
        };
        infrastructure.AddConstruct(Id, appConfigResource);

        infrastructure.AddSystemRole(
            appConfigResource,
            AppConfigurationBuiltInRole.GetBuiltInRoleName(AppConfigurationBuiltInRole.AppConfigurationDataOwner),
            AppConfigurationBuiltInRole.AppConfigurationDataOwner.ToString()
        );
    }
}

public class AppConfigurationSettingFeature : AzureProjectFeature
{
    public AppConfigurationSettingFeature(string key, string value)
        : base($"{typeof(AppConfigurationSettingFeature).Name}_{key}")
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }
    public string Value { get; }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        AppConfigurationFeature appConfiguration = infrastructure.AppConfiguration;
        AppConfigurationStore store = infrastructure.GetConstruct<AppConfigurationStore>(appConfiguration.Id);
        string bicepIdentifier = infrastructure.CreateUniqueBicepIdentifier("app_config_setting");
        AppConfigurationKeyValue kvp = new(bicepIdentifier)
        {
            Name = Key,
            Value = Value,
            Parent = store
        };
        infrastructure.AddConstruct(Id, kvp);
    }
}

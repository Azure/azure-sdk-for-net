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

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore appConfigResource = new("cm_app_config")
        {
            Name = infrastructure.ProjectId,
            SkuName = "Free",
        };
        infrastructure.AddConstruct(this.Id, appConfigResource);

        infrastructure.AddSystemRole(
            appConfigResource,
            AppConfigurationBuiltInRole.GetBuiltInRoleName(AppConfigurationBuiltInRole.AppConfigurationDataOwner),
            AppConfigurationBuiltInRole.AppConfigurationDataOwner.ToString()
        );
    }
}

public class AppConfigurationSettingFeature : AzureProjectFeature
{
    public AppConfigurationSettingFeature(string key, string value, string bicepIdentifier = "cm_config_setting")
    {
        Key = key;
        Value = value;
        BicepIdentifier = bicepIdentifier;
    }

    public string Key { get; }
    public string Value { get; }
    private string BicepIdentifier { get; }

    internal AppConfigurationFeature? Store { get; set; }

    protected internal override void EmitFeatures(FeatureCollection features, string projectId)
    {
        AppConfigurationFeature? account = features.FindAll<AppConfigurationFeature>().FirstOrDefault();
        if (account == default)
        {
            account = new();
            features.Append(account);
        }
        Store = account;
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        if (Store == null)
        {
            throw new InvalidOperationException("AppConfigurationFeature must be added to the project before AppConfigurationSettingFeature.");
        }
        AppConfigurationStore store = infrastructure.GetConstruct<AppConfigurationStore>(Store.Id);

        string bicepIdentifier = infrastructure.CreateUniqueBicepIdentifier(BicepIdentifier);
        AppConfigurationKeyValue kvp = new(bicepIdentifier)
        {
            Name = this.Key,
            Value = this.Value,
            Parent = store
        };
        infrastructure.AddConstruct(Id, kvp);
    }
}

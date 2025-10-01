// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.AppConfiguration;
using Azure.Storage.Blobs.Models;

namespace Azure.Projects;

public class AppConfigurationFeature : AzureProjectFeature
{
    public AppConfigurationFeature()
    { }

    public SkuName Sku { get; set; } = SkuName.Free;

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore appConfigResource = new("appConfiguration", AppConfigurationStore.ResourceVersions.V2024_05_01)
        {
            Name = infrastructure.ProjectId,
            SkuName = Sku.ToString(),
        };
        infrastructure.AddConstruct(Id, appConfigResource);

        infrastructure.AddSystemRole(
            appConfigResource,
            AppConfigurationBuiltInRole.GetBuiltInRoleName(AppConfigurationBuiltInRole.AppConfigurationDataOwner),
            AppConfigurationBuiltInRole.AppConfigurationDataOwner.ToString()
        );

        var endpoint = $"https://{infrastructure.ProjectId}.azconfig.io";
        EmitConnection(infrastructure, "Azure.Data.AppConfiguration.ConfigurationClient", endpoint);
    }

    public enum SkuName {
        Free,
        Developer,
        Standard,
        Premium
    }
}

public class AppConfigurationSettingFeature : AzureProjectFeature
{
    private string? _bicepIdentifier;

    public AppConfigurationSettingFeature(string key, string value)
        : base($"{typeof(AppConfigurationSettingFeature).FullName}_{key}")
    {
        Key = key;
        Value = value;
        _bicepIdentifier = null;
    }

    internal AppConfigurationSettingFeature(string key, string value, string bicepIdentifier)
    : base($"{typeof(AppConfigurationSettingFeature).FullName}_{key}")
    {
        Key = key;
        Value = value;
        _bicepIdentifier = bicepIdentifier;
    }

    public string Key { get; }
    public string Value { get; }

    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;
        if (!features.TryGet(out AppConfigurationFeature? appConfiguration))
        {
            features.Append(new AppConfigurationFeature());
        }
        features.Append(this);
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore store = infrastructure.GetConstruct<AppConfigurationStore>(typeof(AppConfigurationFeature).FullName!);
        if (_bicepIdentifier == null) _bicepIdentifier = store.BicepIdentifier + "_setting";

        string bicepIdentifier = infrastructure.Features.CreateUniqueBicepIdentifier(_bicepIdentifier);
        AppConfigurationKeyValue kvp = new(bicepIdentifier, AppConfigurationKeyValue.ResourceVersions.V2024_05_01)
        {
            Name = Key,
            Value = Value,
            Parent = store
        };
        infrastructure.AddConstruct(Id, kvp);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Projects.Core;
using Azure.Provisioning.AppConfiguration;

namespace Azure.Projects.AppConfiguration;

public class AppConfigurationFeature : AzureProjectFeature
{
    public AppConfigurationFeature()
    {}

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore appConfigResource = new("appConfiguration")
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

        var endpoint = $"https://{infrastructure.ProjectId}.azconfig.io";
        EmitConnection(infrastructure, "Azure.Data.AppConfiguration.ConfigurationClient", endpoint);
    }
}

public class AppConfigurationSettingFeature : AzureProjectFeature
{
    private string? _bicepIdentifier;

    public AppConfigurationSettingFeature(string key, string value)
        : base($"{typeof(AppConfigurationSettingFeature).Name}_{key}")
    {
        Key = key;
        Value = value;
        _bicepIdentifier = null;
    }

    internal AppConfigurationSettingFeature(string key, string value, string bicepIdentifier)
    : base($"{typeof(AppConfigurationSettingFeature).Name}_{key}")
    {
        Key = key;
        Value = value;
        _bicepIdentifier = bicepIdentifier;
    }

    public string Key { get; }
    public string Value { get; }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;
        if (!features.TryGet(out AppConfigurationFeature? appConfiguration))
        {
            throw new InvalidOperationException($"The {nameof(AppConfigurationFeature)} must be added to the infrastructure before adding {nameof(AppConfigurationSettingFeature)}.");
        }
        AppConfigurationStore store = infrastructure.GetConstruct<AppConfigurationStore>(appConfiguration!.Id);
        if (_bicepIdentifier == null) _bicepIdentifier = store.BicepIdentifier + "_setting";

        string bicepIdentifier = CreateUniqueBicepIdentifier(_bicepIdentifier);
        AppConfigurationKeyValue kvp = new(bicepIdentifier)
        {
            Name = Key,
            Value = Value,
            Parent = store
        };
        infrastructure.AddConstruct(Id, kvp);
    }

    private static int _index = 0;
    internal string CreateUniqueBicepIdentifier(string baseIdentifier)
    {
        int index = Interlocked.Increment(ref _index);
        if (index == 1)
            return baseIdentifier;
        return $"{baseIdentifier}{index}";
    }
}

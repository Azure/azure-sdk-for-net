// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.AppConfiguration;
using Azure.Storage.Blobs.Models;

namespace Azure.Projects;

/// <summary>
/// Represents a provisioning feature that emits an Azure App Configuration resource.
/// </summary>
public class AppConfigurationFeature : AzureProjectFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppConfigurationFeature"/> class with default settings.
    /// </summary>
    public AppConfigurationFeature()
    { }

    /// <summary>
    /// Gets or sets the SKU for the App Configuration resource.
    /// </summary>
    public SkuName Sku { get; set; } = SkuName.Free;

    /// <summary>
    /// Emits the provisioning constructs for the App Configuration resource into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit constructs into.</param>
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

    /// <summary>
    /// Defines the available SKU names for App Configuration.
    /// </summary>
    public enum SkuName
    {
        /// <summary>
        /// The free tier SKU.
        /// </summary>
        Free,
        /// <summary>
        /// The developer tier SKU.
        /// </summary>
        Developer,
        /// <summary>
        /// The standard tier SKU.
        /// </summary>
        Standard,
        /// <summary>
        /// The premium tier SKU.
        /// </summary>
        Premium
    }
}

/// <summary>
/// Represents a provisioning feature that emits an App Configuration key-value setting.
/// </summary>
public class AppConfigurationSettingFeature : AzureProjectFeature
{
    private string? _bicepIdentifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppConfigurationSettingFeature"/> class.
    /// </summary>
    /// <param name="key">The configuration key.</param>
    /// <param name="value">The configuration value.</param>
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

    /// <summary>
    /// Gets the configuration key.
    /// </summary>
    public string Key { get; }
    /// <summary>
    /// Gets the configuration value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Emits the required features for this App Configuration setting into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit features into.</param>
    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;
        if (!features.TryGet(out AppConfigurationFeature? appConfiguration))
        {
            features.Append(new AppConfigurationFeature());
        }
        features.Append(this);
    }

    /// <summary>
    /// Emits the provisioning constructs for this App Configuration setting into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit constructs into.</param>
    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        AppConfigurationStore store = infrastructure.GetConstruct<AppConfigurationStore>(typeof(AppConfigurationFeature).FullName!);
        if (_bicepIdentifier == null)
            _bicepIdentifier = store.BicepIdentifier + "_setting";

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

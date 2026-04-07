// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Provisioning.Generator.Specifications;

// NOTE: To correctly regenerate Azure.Provisioning.SecurityCenter, the mgmt
// library (Azure.ResourceManager.SecurityCenter) must first be regenerated
// with `enable-bicep-serialization: true` in its autorest.md to produce
// WirePath attributes. Then switch the PackageReference in Generator.csproj to
// a ProjectReference pointing to the local mgmt project before running this
// generator. After generation, restore the PackageReference and revert the
// mgmt changes.
public class SecurityCenterSpecification() :
    Specification("SecurityCenter", typeof(SecurityCenterExtensions), ignorePropertiesWithoutPath: true, serviceDirectory: "securitycenter")
{
    protected override void Customize()
    {
        // SecuritySetting is polymorphic with a 'kind' discriminator.
        // Register derived data types as constructible resources.
        CustomizeResource<DataExportSettings>(r =>
        {
            r.BaseType = GetModel<SecuritySettingResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "DataExportSettings";
        });
        CustomizeResource<SecurityAlertSyncSettings>(r =>
        {
            r.BaseType = GetModel<SecuritySettingResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "AlertSyncSettings";
        });
        RemoveProperties<DataExportSettings>("Id", "Name", "SystemData");
        RemoveProperties<SecurityAlertSyncSettings>("Id", "Name", "SystemData");

        // ServerVulnerabilityAssessmentsSetting is polymorphic with a 'kind' discriminator.
        // Commented out: AzureServersSetting and ServerVulnerabilityAssessmentsSettingResource
        // were removed from the latest Azure.ResourceManager.SecurityCenter package.
        // CustomizeResource<AzureServersSetting>(r =>
        // {
        //     r.BaseType = GetModel<ServerVulnerabilityAssessmentsSettingResource>() as TypeModel;
        //     r.DiscriminatorName = "kind";
        //     r.DiscriminatorValue = "AzureServersSetting";
        // });
        // RemoveProperties<AzureServersSetting>("Id", "Name", "SystemData");
    }

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        var result = base.FindConstructibleResources();

        // Register polymorphic data types as constructible resources
        // so the generator creates proper Resource classes for them.
        result.Add(typeof(DataExportSettings),
            typeof(SecurityCenterSpecification).GetMethod(nameof(CreateDataExportSettings), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(SecurityAlertSyncSettings),
            typeof(SecurityCenterSpecification).GetMethod(nameof(CreateSecurityAlertSyncSettings), BindingFlags.NonPublic | BindingFlags.Static)!);
        // result.Add(typeof(AzureServersSetting),
        //     typeof(SecurityCenterSpecification).GetMethod(nameof(CreateAzureServersSetting), BindingFlags.NonPublic | BindingFlags.Static)!);

        return result;
    }

    // Dummy methods for the reflection-based generator to discover constructible data types.
    private static ArmOperation<SecuritySettingResource> CreateDataExportSettings(DataExportSettings content) => null!;
    private static ArmOperation<SecuritySettingResource> CreateSecurityAlertSyncSettings(SecurityAlertSyncSettings content) => null!;
    // private static ArmOperation<ServerVulnerabilityAssessmentsSettingResource> CreateAzureServersSetting(AzureServersSetting content) => null!;
}

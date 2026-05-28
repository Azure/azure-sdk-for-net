// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Generator.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Provisioning.Generator.Specifications;

public class ResourcesSpecification : Specification
{
    public ResourcesSpecification() :
        base("Resources", typeof(ResourcesExtensions))
    {
        SkipCleaning = true;
    }

    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<ArmApplicationDefinitionResource>("DeploymentMode");
        RemoveProperty<ArmApplicationDefinitionResource>("LockingAllowedActions");
        RemoveProperty<ArmDeploymentResource>("Content");
        RemoveProperty<TemplateSpecVersionResource>("TemplateSpecVersion");
        RemoveProperty<ArmDeploymentPropertiesExtended>("DebugSettingDetailLevel");

        // Patch models
        CustomizeProperty<TenantDataBoundaryResource>("Name", p => p.Path = ["name"]);
        CustomizeResource<ArmDeploymentResource>(r => r.FromExpression = true);
        CustomizeEnum<ResourceTypeAliasPatternType>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizeEnum<ResourceTypeAliasType>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizePropertyIsoDuration<JitSchedulingPolicy>("Duration");
        CustomizePropertyIsoDuration<ArmApplicationJitAccessPolicy>("MaximumJitAccessDuration");
        CustomizePropertyIsoDuration<ArmDeploymentPropertiesExtended>("Duration");
        CustomizePropertyIsoDuration<DeploymentStackResource>("Duration");
        // Not generated today:
        // CustomizePropertyIsoDuration<ArmDeploymentOperationProperties>("Duration");

        CustomizeResource<AzureCliScript>(r =>
        {
            r.BaseType = GetModel<ArmDeploymentScriptResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "AzureCLI";
        });
        CustomizeResource<AzurePowerShellScript>(r =>
        {
            r.BaseType = GetModel<ArmDeploymentScriptResource>() as TypeModel;
            r.DiscriminatorName = "kind";
            r.DiscriminatorValue = "AzurePowerShell";
        });
        CustomizePropertyIsoDuration<AzureCliScript>("RetentionInterval");
        CustomizePropertyIsoDuration<AzureCliScript>("Timeout");
        CustomizePropertyIsoDuration<AzurePowerShellScript>("RetentionInterval");
        CustomizePropertyIsoDuration<AzurePowerShellScript>("Timeout");
        // remove the properties that inherited from the base type ArmDeploymentScript
        RemoveProperties<AzureCliScript>("Id", "Name", "Location", "Identity", "SystemData", "Tags");
        RemoveProperties<AzurePowerShellScript>("Id", "Name", "Location", "Identity", "SystemData", "Tags");

        // Backward compatibility
        CustomizeProperty<ArmDeploymentPropertiesExtended>("OutputResources", p =>
        {
            p.HideLevel = PropertyHideLevel.HideProperty;
        });
        CustomizeProperty<ArmDeploymentPropertiesExtended>("ValidatedResources", p =>
        {
            p.HideLevel = PropertyHideLevel.HideProperty;
        });

        // Naming requirements
        AddNameRequirements<ArmDeploymentResource>(min: 1, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<TemplateSpecResource>(min: 1, max: 90, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
    }

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        var result = base.FindConstructibleResources();

        result.Add(typeof(AzureCliScript), typeof(ResourcesSpecification).GetMethod(nameof(CreateOrUpdateAzureCliScript), BindingFlags.NonPublic | BindingFlags.Static)!);
        result.Add(typeof(AzurePowerShellScript), typeof(ResourcesSpecification).GetMethod(nameof(CreateOrUpdateAzurePowerShellScript), BindingFlags.NonPublic | BindingFlags.Static)!);
        return result;
    }

    // These methods are here as a workaround to generate correct properties for the above two discriminated child resources.
    private static ArmOperation<ArmDeploymentScriptResource> CreateOrUpdateAzureCliScript(AzureCliScript content) { return null!; }
    private static ArmOperation<ArmDeploymentScriptResource> CreateOrUpdateAzurePowerShellScript(AzurePowerShellScript content) { return null!; }
}

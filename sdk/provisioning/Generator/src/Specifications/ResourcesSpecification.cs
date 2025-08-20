// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

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
        CustomizeResource<ArmDeploymentResource>(r => r.FromExpression = true);
        CustomizeEnum<ResourceTypeAliasPatternType>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizeEnum<ResourceTypeAliasType>(e => { foreach (EnumValue member in e.Values) { member.Value = member.Name; } });
        CustomizePropertyIsoDuration<JitSchedulingPolicy>("Duration");
        CustomizePropertyIsoDuration<ArmApplicationJitAccessPolicy>("MaximumJitAccessDuration");
        CustomizePropertyIsoDuration<ArmDeploymentPropertiesExtended>("Duration");
        // Not generated today:
        // CustomizePropertyIsoDuration<AzureCliScript>("RetentionInterval");
        // CustomizePropertyIsoDuration<AzureCliScript>("Timeout");
        // CustomizePropertyIsoDuration<AzurePowerShellScript>("RetentionInterval");
        // CustomizePropertyIsoDuration<AzurePowerShellScript>("Timeout");
        // CustomizePropertyIsoDuration<ArmDeploymentOperationProperties>("Duration");

        // Naming requirements
        AddNameRequirements<ArmDeploymentResource>(min: 1, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
        AddNameRequirements<TemplateSpecResource>(min: 1, max: 90, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: true);
    }
}

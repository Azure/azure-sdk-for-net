// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Suppress the generated factory for the abstract ResourceDetails discriminator base type.
    // The generated method attempts to instantiate the abstract base instead of a concrete discriminator subtype.
    [CodeGenSuppress("ResourceDetails", typeof(Source?), typeof(string), typeof(string))]
    [CodeGenSuppress("SecurityAlertsSuppressionRuleData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(RuleState?), typeof(string), typeof(IEnumerable<SuppressionAlertsScopeElement>))]
    [CodeGenSuppress("ComplianceResultData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(ResourceStatus?))]
    [CodeGenSuppress("GovernanceAssignmentData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(DateTimeOffset?), typeof(RemediationEta), typeof(bool?), typeof(GovernanceEmailNotification), typeof(GovernanceAssignmentAdditionalData))]
    [CodeGenSuppress("AutoProvisioningSettingData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(AutoProvision?))]
    [CodeGenSuppress("SecurityCenterPricingData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(PricingTier?), typeof(string), typeof(TimeSpan?), typeof(DateTimeOffset?), typeof(Enforce?), typeof(Inherited?), typeof(string), typeof(ResourcesCoverageStatus?), typeof(IEnumerable<Extension>), typeof(bool?), typeof(IEnumerable<string>))]
    [CodeGenSuppress("SecurityConnectorData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(AzureLocation), typeof(string), typeof(DateTimeOffset?), typeof(CloudName?), typeof(IEnumerable<SecurityCenterCloudOffering>), typeof(EnvironmentData), typeof(IDictionary<string, string>), typeof(string), typeof(ETag?))]
    [CodeGenSuppress("IotSecuritySolutionData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(AzureLocation), typeof(string), typeof(string), typeof(SecuritySolutionStatus?), typeof(IEnumerable<ExportData>), typeof(IEnumerable<DataSource>), typeof(IEnumerable<string>), typeof(UserDefinedResourcesProperties), typeof(IEnumerable<string>), typeof(IEnumerable<RecommendationConfigurationProperties>), typeof(UnmaskedIpLoggingStatus?), typeof(IEnumerable<AdditionalWorkspacesProperties>), typeof(IDictionary<string, string>))]
    [CodeGenSuppress("IotSecurityAggregatedAlertData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(string), typeof(ReportedSeverity?), typeof(string), typeof(string), typeof(long?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<IoTSecurityAggregatedAlertPropertiesTopDevicesListItem>), typeof(IDictionary<string, string>))]
    [CodeGenSuppress("SecureScoreControlDefinitionItem", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(string), typeof(int?), typeof(IEnumerable<AzureResourceLink>), typeof(ControlType?))]
    [CodeGenSuppress("CefExternalSecuritySolution", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(BinaryData), typeof(string), typeof(CefSolutionProperties))]
    [CodeGenSuppress("AtaExternalSecuritySolution", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(BinaryData), typeof(string), typeof(AtaSolutionProperties))]
    [CodeGenSuppress("AadExternalSecuritySolution", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(BinaryData), typeof(string), typeof(AadSolutionProperties))]
    public static partial class ArmSecurityCenterModelFactory
    {
    }
}

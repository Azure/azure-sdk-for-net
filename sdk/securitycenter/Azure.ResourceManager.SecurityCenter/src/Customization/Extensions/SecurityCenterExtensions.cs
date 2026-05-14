// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    // Suppress duplicate generated extension factories for resource types that appear through multiple Security APIs.
    [CodeGenSuppress("GetAlertResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetSqlVulnerabilityAssessmentScanResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class SecurityCenterExtensions
    {
    }
}

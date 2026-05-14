// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    // Suppress duplicate generated factory helpers for resource types that appear through multiple Security APIs.
    [CodeGenSuppress("GetAlertResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetSqlVulnerabilityAssessmentScanResource", typeof(ResourceIdentifier))]
    public partial class MockableSecurityCenterArmClient
    {
    }
}

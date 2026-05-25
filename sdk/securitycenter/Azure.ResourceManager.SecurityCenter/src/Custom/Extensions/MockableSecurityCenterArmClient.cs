// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    [CodeGenSuppress("GetSqlVulnerabilityAssessmentScanResource", typeof(ResourceIdentifier))]
    public partial class MockableSecurityCenterArmClient
    {
    }
}

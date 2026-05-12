// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security.Mocking
{
    // Suppress duplicate generated factory helpers for resource types that appear through multiple Security APIs.
    [CodeGenSuppress("GetAlertResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ResourceIdentifier))]
    public partial class MockableSecurityArmClient
    {
    }
}

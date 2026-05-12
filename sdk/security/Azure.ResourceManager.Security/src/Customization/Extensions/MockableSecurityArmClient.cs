// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security.Mocking
{
    [CodeGenSuppress("GetAlertResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ResourceIdentifier))]
    public partial class MockableSecurityArmClient
    {
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Security.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security
{
    [CodeGenSuppress("GetAlertResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetAssessmentsMetadatumResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    [CodeGenSuppress("GetTaskResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class SecurityExtensions
    {
    }
}

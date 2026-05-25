// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // TODO: Remove after https://github.com/Azure/azure-sdk-for-net/issues/59425.
    // Suppress generated operation-result helpers that use reflection-based deserialization,
    // which fails the AOT/trimming analyzer checks.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    public partial class DevOpsConfigurationResource
    {
    }
}

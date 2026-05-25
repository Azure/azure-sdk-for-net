// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // TODO: Remove after https://github.com/Azure/azure-sdk-for-net/issues/59425.
    // Suppress generated operation-status helpers that use reflection-based deserialization,
    // which fails the AOT/trimming analyzer checks.
    /// <summary> A class representing the SecurityCenterLocation resource and its operations. </summary>
    [CodeGenSuppress("GetOperationStatusAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationStatus", typeof(string), typeof(CancellationToken))]
    public partial class SecurityCenterLocationResource
    {
    }
}

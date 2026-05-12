// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security
{
    // Suppress generated operation-status helpers that use reflection-based deserialization,
    // which fails the AOT/trimming analyzer checks.
    [CodeGenSuppress("GetOperationStatusAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationStatus", typeof(string), typeof(CancellationToken))]
    public partial class AscLocationResource
    {
    }
}

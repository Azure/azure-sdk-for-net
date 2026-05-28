// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    // The generator emits a `Response GetEntityTag(CT)` overload bound to a singleton
    // sub-resource (e.g. Wiki). Suppress it so the resource itself does not expose a
    // non-Response<bool> GetEntityTag. Will take effect on next regeneration.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetEntityTag", typeof(System.Threading.CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetEntityTagAsync", typeof(System.Threading.CancellationToken))]
    public partial class ApiResource
    {
    }
}

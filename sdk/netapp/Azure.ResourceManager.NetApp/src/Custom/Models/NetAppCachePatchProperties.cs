// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: the v1.15.0 SDK exposed this type as `NetAppCachePatchProperties`;
    // the TypeSpec generator emits it as `CacheUpdateProperties`. [CodeGenType] aliases the
    // generated type back to the old public name. Equivalent `@@clientName(... , "csharp")`
    // is preferred long-term but currently blocked on the same generator bug as
    // NetAppActiveDirectoryConfigPatchProperties (microsoft/typespec#10397).
    [CodeGenType("CacheUpdateProperties")]
    public partial class NetAppCachePatchProperties
    {
    }
}

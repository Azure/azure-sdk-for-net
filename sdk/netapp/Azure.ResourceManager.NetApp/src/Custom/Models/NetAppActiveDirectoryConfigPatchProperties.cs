// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: the v1.15.0 SDK exposed this type as
    // `NetAppActiveDirectoryConfigPatchProperties`; the TypeSpec generator emits it
    // as `ActiveDirectoryConfigUpdateProperties`. We use [CodeGenType] to alias the
    // generated type back to the old public name so existing user code continues to
    // compile. (Equivalent `@@clientName(... , "NetAppActiveDirectoryConfigPatchProperties", "csharp")`
    // is preferred long-term but currently blocked on a generator bug for nested
    // patch property models — see microsoft/typespec#10397.)
    [CodeGenType("ActiveDirectoryConfigUpdateProperties")]
    public partial class NetAppActiveDirectoryConfigPatchProperties
    {
    }
}

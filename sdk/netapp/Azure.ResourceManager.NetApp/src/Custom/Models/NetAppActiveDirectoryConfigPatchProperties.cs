// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    // ActiveDirectoryConfigUpdateProperties is generated from the instantiated
    // Azure.ResourceManager.Foundations.ResourceUpdateModel used by the PATCH operation,
    // not from an addressable service model in the NetApp TypeSpec files. Because there is
    // no TypeSpec declaration to target with @@clientName, use CodeGenType to keep the
    // shorter v1.15-compatible SDK name.
    [CodeGenType("ActiveDirectoryConfigUpdateProperties")]
    public partial class NetAppActiveDirectoryConfigPatchProperties { }
}

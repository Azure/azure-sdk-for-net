// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: the v1.15.0 SDK exposed this type as `NetAppManagedServiceIdentityPatch`;
    // the TypeSpec generator emits the inlined Azure ARM common-type as
    // `AzureResourceManagerCommonTypesManagedServiceIdentityUpdate`. [CodeGenType] aliases
    // the generated type back to the old public name. `@@clientName` is not used because the
    // type is sourced from Azure.Core common types (renaming via clientName on shared common
    // types would affect other SDKs).
    [CodeGenType("AzureResourceManagerCommonTypesManagedServiceIdentityUpdate")]
    public partial class NetAppManagedServiceIdentityPatch
    {
    }
}

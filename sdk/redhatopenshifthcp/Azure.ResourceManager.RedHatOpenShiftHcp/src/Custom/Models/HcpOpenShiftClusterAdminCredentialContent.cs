// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RedHatOpenShiftHcp.Models
{
    // Renamed from the generated 'HcpOpenShiftClusterAdminCredentialRequest' to satisfy AZC0030:
    // request-body model names must not end with 'Request'.
    [CodeGenType("HcpOpenShiftClusterAdminCredentialRequest")]
    public partial class HcpOpenShiftClusterAdminCredentialContent
    {
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.NeonPostgres.Models
{
    // this customization code is here to rename a generated model. We cannot do it by `@@clientName` in its typespec because a template generates this type.
    [CodeGenType("OrganizationResourceUpdateProperties")]
    public partial class NeonOrganizationPatchProperties { }
}

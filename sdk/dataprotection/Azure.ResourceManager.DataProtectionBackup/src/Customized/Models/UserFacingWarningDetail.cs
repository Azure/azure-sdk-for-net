// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("Warning")]
    public partial class UserFacingWarningDetail
    {
        /// <summary> Error details for the warning. </summary>
        public Azure.ResponseError Warning { get; set; }
    }
}

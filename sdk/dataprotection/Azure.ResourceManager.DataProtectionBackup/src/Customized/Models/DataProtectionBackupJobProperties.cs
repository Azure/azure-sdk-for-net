// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("ErrorDetails")]
    public partial class DataProtectionBackupJobProperties
    {
        /// <summary> A List, detailing the errors related to the job. </summary>
        public IReadOnlyList<Azure.ResponseError> ErrorDetails { get; }
    }
}

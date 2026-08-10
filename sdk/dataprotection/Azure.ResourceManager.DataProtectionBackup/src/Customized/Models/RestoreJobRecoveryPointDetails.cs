// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSuppress("RestoreJobRecoveryPointDetails")]
    [CodeGenSuppress("RecoveryPointId")]
    [CodeGenSuppress("RecoverOn")]
    public partial class RestoreJobRecoveryPointDetails
    {
        /// <summary> Initializes a new instance of <see cref="RestoreJobRecoveryPointDetails"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestoreJobRecoveryPointDetails()
        {
        }

        /// <summary> Gets or sets the RecoveryPointId. </summary>
        public string RecoveryPointId { get; set; }

        /// <summary> Gets or sets the RecoverOn. </summary>
        public DateTimeOffset? RecoverOn { get; set; }
    }
}

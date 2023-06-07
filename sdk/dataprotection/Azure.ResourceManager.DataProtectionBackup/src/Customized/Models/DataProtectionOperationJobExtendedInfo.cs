// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionOperationJobExtendedInfo
    {
        /// <summary> Arm Id of the job created for this operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? JobId { get; }
    }
}

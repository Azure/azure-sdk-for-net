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
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? JobId { get; }

        /// <summary> Arm Id of the job created for this operation. </summary>
        public ResourceIdentifier JobResourceId { get => ResourceIdentifier.TryParse(JobIdentifier, out ResourceIdentifier _jobResourceId) ? _jobResourceId : null; }

        /// <summary> Name of the job created for this operation. </summary>
        public string JobName { get => JobResourceId != null ? JobResourceId.Name : JobIdentifier; }
    }
}

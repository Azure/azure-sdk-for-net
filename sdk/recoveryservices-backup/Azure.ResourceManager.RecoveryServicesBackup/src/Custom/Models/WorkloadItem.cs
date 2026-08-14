// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public abstract partial class WorkloadItem
    {
        /// <summary> Initializes a new instance of <see cref="WorkloadItem"/> for deserialization. </summary>
        protected WorkloadItem()
        {
        }
    }
}

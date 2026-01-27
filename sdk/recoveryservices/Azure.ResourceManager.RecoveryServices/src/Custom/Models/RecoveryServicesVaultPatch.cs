// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    /// <summary> Patch Resource information, as returned by the resource provider. </summary>
    public partial class RecoveryServicesVaultPatch
    {
        /// <summary> Optional ETag. </summary>
        public ETag? ETag { get; set; }
    }
}

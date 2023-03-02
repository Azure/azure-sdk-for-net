// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ComputeWriteableSubResourceData
    {
        /// <summary> Resource Id. </summary>
        [CodeGenMember("Id")]
        public virtual ResourceIdentifier Id { get; set; }
    }
}

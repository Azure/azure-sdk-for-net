// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Options for when calling <see cref="StorageResource.ConsumableStream"/>
    /// </summary>
    public class ConsumeReadableStreamOptions
    {
        /// <summary>
        /// Optionally limit requests to resources with an active lease
        /// matching this Id.
        ///
        /// Only valid for Stage Block operations
        /// </summary>
        public string LeaseId { get; set; }
    }
}

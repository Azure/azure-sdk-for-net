// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Storage Transfer Job Details
    /// </summary>
    public class StorageTransferJobDetails
    {
        /// <summary>
        /// Job Id. Guid.
        /// </summary>
        public string JobId { get; internal set; }
    }
}

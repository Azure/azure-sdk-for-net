// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    public partial class BatchIPRule
    {
        /// <summary> Action when client IP address is matched. </summary>
        public BatchIPRuleAction Action { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}

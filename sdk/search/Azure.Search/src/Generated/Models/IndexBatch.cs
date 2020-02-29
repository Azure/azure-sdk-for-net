// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Search.Models
{
    /// <summary> Contains a batch of document write actions to send to the index. </summary>
    public partial class IndexBatch
    {
        /// <summary> The actions in the batch. </summary>
        public ICollection<IndexAction> Actions { get; set; } = new System.Collections.Generic.List<Azure.Search.Models.IndexAction>();
    }
}

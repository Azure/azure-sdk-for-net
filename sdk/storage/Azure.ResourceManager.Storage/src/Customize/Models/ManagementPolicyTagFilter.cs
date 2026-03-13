// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden Operator alias for renamed Op property.
// Could use @@clientName in spec but would lose the improved name.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ManagementPolicyTagFilter
    {
        /// <summary> Backward-compatible alias for Op. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("op")]
        public string Operator
        {
            get => Op;
            set => Op = value;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ManagementPolicyTagFilter
    {
        /// <summary> Backward-compatible alias for Op. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Operator
        {
            get => Op;
            set => Op = value;
        }
    }
}

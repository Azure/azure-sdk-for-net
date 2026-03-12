// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicySchema
    {
        /// <summary> Backward-compatible alias for Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }

        /// <summary> Backward-compatible alias for Type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlobInventoryRuleType RuleType
        {
            get => Type;
            set => Type = value;
        }
    }
}

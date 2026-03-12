// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ManagementPolicyRule
    {
        /// <summary> Backward-compatible alias for Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("enabled")]
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }

        /// <summary> Backward-compatible alias for Type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public ManagementPolicyRuleType RuleType
        {
            get => Type;
            set => Type = value;
        }
    }
}

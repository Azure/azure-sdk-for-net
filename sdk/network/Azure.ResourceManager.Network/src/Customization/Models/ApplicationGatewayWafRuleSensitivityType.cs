// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct ApplicationGatewayWafRuleSensitivityType
    {
        // Shipped in 1.15.0, but not a value in the current service schema.
        /// <summary> None. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility value is not defined by the current service schema.")]
        public static ApplicationGatewayWafRuleSensitivityType None { get; } = new ApplicationGatewayWafRuleSensitivityType("None");
    }
}

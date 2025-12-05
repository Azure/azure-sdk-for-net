// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The string representation of the web application firewall rule sensitivity. </summary>
    public readonly partial struct ApplicationGatewayWafRuleSensitivityType : IEquatable<ApplicationGatewayWafRuleSensitivityType>
    {
        private const string NoneValue = "None";

        /// <summary> None. </summary>
        public static ApplicationGatewayWafRuleSensitivityType None { get; } = new ApplicationGatewayWafRuleSensitivityType(NoneValue);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Defines the sensitivity for the rule. </summary>
    public readonly partial struct ManagedRuleSensitivityType : IEquatable<ManagedRuleSensitivityType>
    {
        private const string NoneValue = "None";

        /// <summary> None. </summary>
        public static ManagedRuleSensitivityType None { get; } = new ManagedRuleSensitivityType(NoneValue);
    }
}

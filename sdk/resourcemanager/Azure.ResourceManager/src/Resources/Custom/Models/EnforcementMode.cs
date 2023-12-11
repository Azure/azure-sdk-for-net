// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </summary>
    public readonly partial struct EnforcementMode : IEquatable<EnforcementMode>
    {
        private const string EnforcedValue = "Default";

        /// <summary> The policy effect is enforced during resource creation or update. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EnforcementMode Enforced { get; } = new EnforcementMode(EnforcedValue);
    }
}

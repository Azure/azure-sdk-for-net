// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Chaos.Models
{
    // Match the case-sensitive wire discriminator so an unknown reason is not treated as a known one.
    [CodeGenSuppress("Equals", typeof(WorkspaceDiscoveryWarningReason))]
    [CodeGenSuppress("GetHashCode")]
    public readonly partial struct WorkspaceDiscoveryWarningReason
    {
        /// <inheritdoc/>
        public bool Equals(WorkspaceDiscoveryWarningReason other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.Ordinal.GetHashCode(_value) : 0;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Chaos.Models
{
    // TODO: Remove these customizations when the generator emits a compatible public
    // discriminator and type with matching equality: https://github.com/microsoft/typespec/issues/12524
    public abstract partial class WorkspaceDiscoveryWarning
    {
        /// <summary> The confirmed guidance reason, not a system-verification failure. </summary>
        [CodeGenMember("Reason")]
        public WorkspaceDiscoveryWarningReason Reason { get; internal set; }
    }

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

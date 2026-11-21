// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
}

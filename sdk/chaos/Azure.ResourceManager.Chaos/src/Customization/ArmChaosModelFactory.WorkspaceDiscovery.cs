// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Chaos.Models
{
    // TODO: Remove these factory customizations when the discriminator customization is no
    // longer needed and generated factories preserve the subtype values:
    // https://github.com/microsoft/typespec/issues/12524
    [CodeGenSuppress("WorkspaceDiscoveryPermissionWarning", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(PermissionError))]
    [CodeGenSuppress("WorkspaceDiscoveryResourceWarning", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(ResourceIdentifier))]
    [CodeGenSuppress("WorkspaceDiscoveryAccessWarning", typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(ResourceIdentifier))]
    public static partial class ArmChaosModelFactory
    {
        /// <summary> Confirmed read-authorization guidance. Permission details are required composition, not an optional shell reused for other causes. </summary>
        /// <param name="scopeId"> The normalized expanded source scope where the affected obligation was encountered. </param>
        /// <param name="scopeKind"> The source scope kind, such as Subscription, ResourceGroup, ServiceGroup, or Resource. </param>
        /// <param name="message"> Human-readable guidance with attribution appropriate to the reason. </param>
        /// <param name="permission"> The affected resource, required permissions, recommended roles, and optional identity details. </param>
        /// <returns> A new <see cref="Models.WorkspaceDiscoveryPermissionWarning"/> instance for mocking. </returns>
        public static WorkspaceDiscoveryPermissionWarning WorkspaceDiscoveryPermissionWarning(ResourceIdentifier scopeId = default, string scopeKind = default, string message = default, PermissionError permission = default)
            => new WorkspaceDiscoveryPermissionWarning(scopeId, scopeKind, WorkspaceDiscoveryWarningReason.RbacValidationFailed, message, default, permission);

        /// <summary> Guidance for a resource or membership confirmed missing. </summary>
        /// <param name="scopeId"> The normalized expanded source scope where the affected obligation was encountered. </param>
        /// <param name="scopeKind"> The source scope kind, such as Subscription, ResourceGroup, ServiceGroup, or Resource. </param>
        /// <param name="message"> Human-readable guidance with attribution appropriate to the reason. </param>
        /// <param name="resourceId"> The affected resource or member identity. </param>
        /// <returns> A new <see cref="Models.WorkspaceDiscoveryResourceWarning"/> instance for mocking. </returns>
        public static WorkspaceDiscoveryResourceWarning WorkspaceDiscoveryResourceWarning(ResourceIdentifier scopeId = default, string scopeKind = default, string message = default, ResourceIdentifier resourceId = default)
            => new WorkspaceDiscoveryResourceWarning(scopeId, scopeKind, WorkspaceDiscoveryWarningReason.TargetNotFound, message, default, resourceId);

        /// <summary> Neutral guidance when access versus absence could not be established. </summary>
        /// <param name="scopeId"> The normalized expanded source scope where the affected obligation was encountered. </param>
        /// <param name="scopeKind"> The source scope kind, such as Subscription, ResourceGroup, ServiceGroup, or Resource. </param>
        /// <param name="message"> Human-readable guidance with attribution appropriate to the reason. </param>
        /// <param name="resourceId"> The affected resource or member identity. </param>
        /// <returns> A new <see cref="Models.WorkspaceDiscoveryAccessWarning"/> instance for mocking. </returns>
        public static WorkspaceDiscoveryAccessWarning WorkspaceDiscoveryAccessWarning(ResourceIdentifier scopeId = default, string scopeKind = default, string message = default, ResourceIdentifier resourceId = default)
            => new WorkspaceDiscoveryAccessWarning(scopeId, scopeKind, WorkspaceDiscoveryWarningReason.AccessIndeterminate, message, default, resourceId);
    }
}

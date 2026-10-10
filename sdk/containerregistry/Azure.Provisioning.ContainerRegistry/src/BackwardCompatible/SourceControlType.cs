// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The type of source control service.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceControlType from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum SourceControlType
{
    /// <summary>
    /// Github.
    /// </summary>
    Github,

    /// <summary>
    /// VisualStudioTeamService.
    /// </summary>
    VisualStudioTeamService,
}

#pragma warning restore CS0618

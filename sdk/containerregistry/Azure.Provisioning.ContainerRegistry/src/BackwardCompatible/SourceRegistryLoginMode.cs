// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The authentication mode which determines the source registry login scope.
/// The credentials for the source registry             will be generated
/// using the given scope. These credentials will be used to login to
/// the source registry during the run.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceRegistryLoginMode from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum SourceRegistryLoginMode
{
    /// <summary>
    /// None.
    /// </summary>
    None,

    /// <summary>
    /// Default.
    /// </summary>
    Default,
}

#pragma warning restore CS0618

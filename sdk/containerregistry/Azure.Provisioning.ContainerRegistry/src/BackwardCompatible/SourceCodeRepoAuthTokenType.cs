// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

#pragma warning disable CS0618 // compatibility types intentionally reference each other

namespace Azure.Provisioning.ContainerRegistry;

/// <summary>
/// The type of Auth token.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and will be removed in a future version. Use Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTokenType from the Azure.Provisioning.ContainerRegistry.Tasks package instead.")]
public enum SourceCodeRepoAuthTokenType
{
    /// <summary>
    /// PAT.
    /// </summary>
    [DataMember(Name = "PAT")]
    Pat,

    /// <summary>
    /// OAuth.
    /// </summary>
    OAuth,
}

#pragma warning restore CS0618

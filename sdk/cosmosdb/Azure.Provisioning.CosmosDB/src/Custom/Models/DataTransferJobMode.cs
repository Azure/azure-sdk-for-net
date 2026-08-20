// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// Mode of job execution.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum DataTransferJobMode
{
    /// <summary>
    /// Offline.
    /// </summary>
    Offline,
    /// <summary>
    /// Online.
    /// </summary>
    Online,
}

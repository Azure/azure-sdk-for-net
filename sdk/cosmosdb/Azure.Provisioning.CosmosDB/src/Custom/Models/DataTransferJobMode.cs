// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

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

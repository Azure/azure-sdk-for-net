// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// The properties of a DataTransfer Job.
/// </summary>
public partial class DataTransferJobGetResult
{
    /// <summary>
    /// Error response for Faulted job.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)] // Renamed
    public ErrorResponse? Error
    {
        get => ErrorResult is not null ? new ErrorResponse(ErrorResult) : null;
    }
}

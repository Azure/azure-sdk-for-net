// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models;

/// <summary>
/// Specifies dataset(s) to be returned when listing blobs with the
/// <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, System.Threading.CancellationToken)"/> and
/// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync(GetBlobsByHierarchyOptions, System.Threading.CancellationToken)"/>
/// operations.
/// </summary>
[Flags]
public enum BlobDatasets
{
    /// <summary>
    /// Only soft-deleted blobs are included.
    /// </summary>
    Deleted = 0,

    /// <summary>
    /// Only files are included.
    /// </summary>
    Files = 1,

    /// <summary>
    /// Only directories are included.
    /// </summary>
    Directories = 2,
}

internal static class BlobDatasetsExtensions
{
    public static string ToQueryParameter(this BlobDatasets datasets)
    {
        List<string> values = [];
        switch (datasets)
        {
            case BlobDatasets.Deleted:
                values.Add("deleted");
                break;
            case BlobDatasets.Files:
                values.Add("files");
                break;
            case BlobDatasets.Directories:
                values.Add("directories");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(datasets), datasets, null);
        }

        return string.Join(",", values);
    }
}

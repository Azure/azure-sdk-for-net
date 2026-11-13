// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Tests;

internal static class ClientExtensions
{
    public static List<string> GetBlobVersions(this BlobBaseClient client)
        => GetBlobVersionsInternal(client, false).EnsureCompleted();

    public static Task<List<string>> GetBlobVersionsAsync(this BlobBaseClient client, CancellationToken cancellationToken = default)
        => GetBlobVersionsInternal(client, true, cancellationToken);

    public static async Task<List<string>> GetBlobVersionsInternal(
        this BlobBaseClient client,
        bool async,
        CancellationToken cancellationToken = default)
    {
        BlobUriBuilder uri = new BlobUriBuilder(client.Uri, true);
        string blobName = uri.BlobName;

        uri.BlobName = null;
        uri.Snapshot = null;
        uri.VersionId = null;

        BlobContainerClient container = client.GetParentBlobContainerClient();
        List<string> result = new();

        GetBlobsOptions options = new GetBlobsOptions
        {
            States = BlobStates.Version,
            Prefix = blobName,
        };

        if (async)
        {
            await foreach (BlobItem item in container.GetBlobsAsync(options, cancellationToken: cancellationToken))
            {
                result.Add(item.VersionId.ToString());
            }
        }
        else
        {
            foreach (BlobItem item in container.GetBlobs(options, cancellationToken: cancellationToken))
            {
                result.Add(item.VersionId.ToString());
            }
        }
        return result;
    }
}

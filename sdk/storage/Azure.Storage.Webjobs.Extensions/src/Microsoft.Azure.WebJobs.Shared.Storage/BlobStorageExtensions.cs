// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Shared.Protocol;

internal static class BlobStorageExtensions
{
    public static Task SetServicePropertiesAsync(this CloudBlobClient sdk, ServiceProperties properties, CancellationToken cancellationToken)
    {
        return sdk.SetServicePropertiesAsync(properties, requestOptions: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task<ServiceProperties> GetServicePropertiesAsync(this CloudBlobClient sdk, CancellationToken cancellationToken)
    {
        return sdk.GetServicePropertiesAsync(cancellationToken);
    }

    public static Task<CloudBlobStream> OpenWriteAsync(this CloudBlockBlob sdk, CancellationToken cancellationToken)
    {
        return sdk.OpenWriteAsync(accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task<string> DownloadTextAsync(this CloudBlockBlob sdk, CancellationToken cancellationToken)
    {
        return sdk.DownloadTextAsync(encoding: null, accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task UploadTextAsync(this CloudBlockBlob sdk, string content, Encoding encoding = null, AccessCondition accessCondition = null,
        BlobRequestOptions options = null, OperationContext operationContext = null,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        return sdk.UploadTextAsync(content, encoding, accessCondition, options, operationContext,
         cancellationToken);
    }

    public static Task DeleteAsync(this CloudBlockBlob sdk, CancellationToken cancellationToken)
    {
        return sdk.DeleteAsync(DeleteSnapshotsOption.None, accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task CreateIfNotExistsAsync(this CloudBlobContainer sdk, CancellationToken cancellationToken)
    {
        return sdk.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Off, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task<Stream> OpenReadAsync(this ICloudBlob sdk, CancellationToken cancellationToken)
    {
        return sdk.OpenReadAsync(accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task<string> AcquireLeaseAsync(this CloudBlockBlob sdk, TimeSpan? leaseTime, string proposedLeaseId,
        CancellationToken cancellationToken)
    {
        return sdk.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task FetchAttributesAsync(this ICloudBlob sdk, CancellationToken cancellationToken)
    {
        return sdk.FetchAttributesAsync(accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }

    public static Task<ICloudBlob> GetBlobReferenceFromServerAsync(this CloudBlobContainer sdk, string blobName, CancellationToken cancellationToken)
    {
        return sdk.GetBlobReferenceFromServerAsync(blobName, accessCondition: null, options: null, operationContext: null, cancellationToken: cancellationToken);
    }
}
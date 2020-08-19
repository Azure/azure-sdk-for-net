// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

/// <summary>
///
/// </summary>
public class BlobData
{
    internal BlobDownloadInfo _blobDownloadInfo;

    /// <summary>
    /// The blob's type.
    /// </summary>
    public BlobType BlobType => _blobDownloadInfo.BlobType;

    /// <summary>
    /// The number of bytes present in the response body.
    /// </summary>
    public long ContentLength => _blobDownloadInfo.ContentLength;

    /// <summary>
    /// Content
    /// </summary>
    public BinaryData Data { get; internal set; }

    /// <summary>
    /// The media type of the body of the response. For Download Blob this is 'application/octet-stream'
    /// </summary>
    public string ContentType => _blobDownloadInfo.ContentType;

    /// <summary>
    /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
    /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] ContentHash => _blobDownloadInfo.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

    /// <summary>
    /// Details returned when downloading a Blob
    /// </summary>
    public BlobDownloadDetails Details => _blobDownloadInfo.Details;

    /// <summary>
    /// Creates a new DownloadInfo backed by FlattenedDownloadProperties
    /// </summary>
    /// <param name="downloadInfo">The FlattenedDownloadProperties returned with the request</param>
    internal BlobData(BlobDownloadInfo downloadInfo)
    {
        _blobDownloadInfo = downloadInfo;
    }
}

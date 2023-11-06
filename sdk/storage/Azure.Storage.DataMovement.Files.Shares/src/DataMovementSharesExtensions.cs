// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal static partial class DataMovementSharesExtensions
    {
        internal static ShareFileUploadOptions ToShareFileUploadOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
                TransferValidation = options?.UploadTransferValidationOptions,
            };

        internal static ShareFileUploadRangeOptions ToShareFileUploadRangeOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
                TransferValidation = options?.UploadTransferValidationOptions,
            };

        internal static ShareFileUploadRangeFromUriOptions ToShareFileUploadRangeFromUriOptions(
            this ShareFileStorageResourceOptions options,
            HttpAuthorization sourceAuthorization)
            => new()
            {
                Conditions = options?.DestinationConditions,
                SourceAuthentication = sourceAuthorization
            };

        internal static StorageResourceProperties ToStorageResourceProperties(
            this ShareFileProperties properties)
            => new(
                lastModified: properties.LastModified,
                createdOn: properties?.SmbProperties?.FileCreatedOn ?? default,
                metadata: properties?.Metadata,
                copyCompletedOn: properties.CopyCompletedOn,
                copyStatusDescription: properties?.CopyStatusDescription,
                copyId: properties?.CopyId,
                copyProgress: properties?.CopyProgress,
                copySource: properties?.CopySource != null ? new Uri(properties?.CopySource) : null,
                contentLength: properties.ContentLength,
                contentType: properties?.ContentType,
                eTag: properties.ETag,
                contentHash: properties?.ContentHash,
                blobSequenceNumber: default,
                blobCommittedBlockCount: default,
                isServerEncrypted: properties.IsServerEncrypted,
                encryptionKeySha256: default,
                encryptionScope: default,
                versionId: default,
                isLatestVersion: default,
                expiresOn: default,
                lastAccessed: default);

        internal static ShareFileDownloadOptions ToShareFileDownloadOptions(
            this ShareFileStorageResourceOptions options,
            HttpRange range)
            => new()
            {
                Range = range,
                Conditions = options?.SourceConditions,
                TransferValidation = options?.DownloadTransferValidationOptions,
            };

        internal static StorageResourceReadStreamResult ToStorageResourceReadStreamResult(
            this ShareFileDownloadInfo info)
            => new(
                content: info?.Content,
                contentRange: info?.Details.ContentRange,
                acceptRanges: info?.Details.AcceptRanges,
                rangeContentHash: info?.Details.FileContentHash,
                properties: info?.Details.ToStorageResourceProperties());

        private static StorageResourceProperties ToStorageResourceProperties(
            this ShareFileDownloadDetails details)
            => new(
                lastModified: details.LastModified,
                createdOn: details.SmbProperties.FileCreatedOn ?? default,
                metadata: details.Metadata,
                copyCompletedOn: details.CopyCompletedOn,
                copyStatusDescription: details.CopyStatusDescription,
                copyId: details.CopyId,
                copyProgress: details.CopyProgress,
                copySource: details.CopySource,
                contentLength: details.ContentRange?.Length ?? default,
                contentType: default,
                eTag: details.ETag,
                contentHash: default,
                blobSequenceNumber: default,
                blobCommittedBlockCount: default,
                isServerEncrypted: details.IsServerEncrypted,
                encryptionKeySha256: default,
                encryptionScope: default,
                versionId: default,
                isLatestVersion: default,
                expiresOn: default,
                lastAccessed: default);
    }
}

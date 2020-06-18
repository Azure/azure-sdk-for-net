// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Quick Query extensions.
    /// </summary>
    internal static class QuickQueryExtensions
    {
        internal static QuerySerialization ToQuickQuerySerialization(
            this BlobQueryTextConfiguration textConfiguration)
        {
            if (textConfiguration == default)
            {
                return default;
            }

            QuerySerialization serialization = new QuerySerialization
            {
                Format = new QueryFormat()
            };

            serialization.Format.DelimitedTextConfiguration = default;
            serialization.Format.JsonTextConfiguration = default;

            if (textConfiguration.GetType() == typeof(BlobQueryCsvTextConfiguration))
            {
                BlobQueryCsvTextConfiguration cvsTextConfiguration = textConfiguration as BlobQueryCsvTextConfiguration;
                serialization.Format.Type = QueryFormatType.Delimited;
                serialization.Format.DelimitedTextConfiguration = new DelimitedTextConfigurationInternal
                {
                    ColumnSeparator = cvsTextConfiguration.ColumnSeparator?.ToString(CultureInfo.InvariantCulture),
                    FieldQuote = cvsTextConfiguration.QuotationCharacter?.ToString(CultureInfo.InvariantCulture),
                    RecordSeparator = cvsTextConfiguration.RecordSeparator?.ToString(CultureInfo.InvariantCulture),
                    EscapeChar = cvsTextConfiguration.EscapeCharacter?.ToString(CultureInfo.InvariantCulture),
                    HeadersPresent = cvsTextConfiguration.HasHeaders
                };
            }
            else if (textConfiguration.GetType() == typeof(BlobQueryJsonTextConfiguration))
            {
                BlobQueryJsonTextConfiguration jsonTextConfiguration = textConfiguration as BlobQueryJsonTextConfiguration;
                serialization.Format.Type = QueryFormatType.Json;
                serialization.Format.JsonTextConfiguration = new JsonTextConfigurationInternal
                {
                    RecordSeparator = jsonTextConfiguration.RecordSeparator?.ToString(CultureInfo.InvariantCulture)
                };
            }
            else
            {
                throw new ArgumentException(Constants.QuickQuery.Errors.InvalidTextConfigurationType);
            }

            return serialization;
        }

        internal static BlobDownloadInfo ToBlobDownloadInfo(this BlobQueryResult quickQueryResult)
            => BlobsModelFactory.BlobDownloadInfo(
                lastModified: quickQueryResult.LastModified,
                blobSequenceNumber: quickQueryResult.BlobSequenceNumber,
                blobType: (Blobs.Models.BlobType)quickQueryResult.BlobType,
                contentCrc64: quickQueryResult.ContentCrc64,
                contentLanguage: quickQueryResult.ContentLanguage,
                copyStatusDescription: quickQueryResult.CopyStatusDescription,
                copyId: quickQueryResult.CopyId,
                copyProgress: quickQueryResult.CopyProgress,
                copySource: quickQueryResult.CopySource != default ? new Uri(quickQueryResult.CopySource) : default,
                copyStatus: (Blobs.Models.CopyStatus)quickQueryResult.CopyStatus,
                contentDisposition: quickQueryResult.ContentDisposition,
                leaseDuration: (Blobs.Models.LeaseDurationType)quickQueryResult.LeaseDuration,
                cacheControl: quickQueryResult.CacheControl,
                leaseState: (Blobs.Models.LeaseState)quickQueryResult.LeaseState,
                contentEncoding: quickQueryResult.ContentEncoding,
                leaseStatus: (Blobs.Models.LeaseStatus)quickQueryResult.LeaseStatus,
                //TODO this might be wrong
                contentHash: quickQueryResult.ContentHash,
                acceptRanges: quickQueryResult.AcceptRanges,
                eTag: quickQueryResult.ETag,
                blobCommittedBlockCount: quickQueryResult.BlobCommittedBlockCount,
                contentRange: quickQueryResult.ContentRange,
                isServerEncrypted: quickQueryResult.IsServerEncrypted,
                contentType: quickQueryResult.ContentType,
                encryptionKeySha256: quickQueryResult.EncryptionKeySha256,
                encryptionScope: quickQueryResult.EncryptionScope,
                contentLength: quickQueryResult.ContentLength,
                //TODO this one might be wrong
                blobContentHash: quickQueryResult.BlobContentMD5,
                metadata: quickQueryResult.Metadata,
                content: quickQueryResult.Body,
                copyCompletionTime: quickQueryResult.CopyCompletionTime);
    }
}

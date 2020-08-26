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
            this BlobQueryTextOptions textConfiguration)
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

            if (textConfiguration.GetType() == typeof(BlobQueryCsvTextOptions))
            {
                BlobQueryCsvTextOptions cvsTextConfiguration = textConfiguration as BlobQueryCsvTextOptions;
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
            else if (textConfiguration.GetType() == typeof(BlobQueryJsonTextOptions))
            {
                BlobQueryJsonTextOptions jsonTextConfiguration = textConfiguration as BlobQueryJsonTextOptions;
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
                blobType: quickQueryResult.BlobType,
                contentCrc64: quickQueryResult.ContentCrc64,
                contentLanguage: quickQueryResult.ContentLanguage,
                copyStatusDescription: quickQueryResult.CopyStatusDescription,
                copyId: quickQueryResult.CopyId,
                copyProgress: quickQueryResult.CopyProgress,
                copySource: quickQueryResult.CopySource != default ? new Uri(quickQueryResult.CopySource) : default,
                copyStatus: quickQueryResult.CopyStatus,
                contentDisposition: quickQueryResult.ContentDisposition,
                leaseDuration: quickQueryResult.LeaseDuration,
                cacheControl: quickQueryResult.CacheControl,
                leaseState: quickQueryResult.LeaseState,
                contentEncoding: quickQueryResult.ContentEncoding,
                leaseStatus: quickQueryResult.LeaseStatus,
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
                blobContentHash: quickQueryResult.BlobContentMD5,
                metadata: quickQueryResult.Metadata,
                content: quickQueryResult.Body,
                copyCompletionTime: quickQueryResult.CopyCompletionTime);
    }
}

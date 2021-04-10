// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            this BlobQueryTextOptions textConfiguration,
            bool isInput)
        {
            if (textConfiguration == default)
            {
                return default;
            }

            QuerySerialization serialization = new QuerySerialization(new QueryFormat());

            serialization.Format.DelimitedTextConfiguration = default;
            serialization.Format.JsonTextConfiguration = default;
            serialization.Format.ArrowConfiguration = default;

            if (textConfiguration is BlobQueryCsvTextOptions cvsTextConfiguration)
            {
                serialization.Format.Type = QueryFormatType.Delimited;
                serialization.Format.DelimitedTextConfiguration = new DelimitedTextConfigurationInternal(
                    columnSeparator: cvsTextConfiguration.ColumnSeparator?.ToString(CultureInfo.InvariantCulture),
                    fieldQuote: cvsTextConfiguration.QuotationCharacter?.ToString(CultureInfo.InvariantCulture),
                    recordSeparator: cvsTextConfiguration.RecordSeparator?.ToString(CultureInfo.InvariantCulture),
                    escapeChar: cvsTextConfiguration.EscapeCharacter?.ToString(CultureInfo.InvariantCulture),
                    headersPresent: cvsTextConfiguration.HasHeaders);
            }
            else if (textConfiguration is BlobQueryJsonTextOptions jsonTextConfiguration)
            {
                serialization.Format.Type = QueryFormatType.Json;
                serialization.Format.JsonTextConfiguration = new JsonTextConfigurationInternal(
                    jsonTextConfiguration.RecordSeparator?.ToString(CultureInfo.InvariantCulture));
            }
            else if (textConfiguration is BlobQueryArrowOptions arrowConfiguration)
            {
                if (isInput)
                {
                    throw new ArgumentException($"{nameof(BlobQueryArrowOptions)} can only be used for output serialization.");
                }

                serialization.Format.Type = QueryFormatType.Arrow;
                serialization.Format.ArrowConfiguration = new ArrowTextConfigurationInternal(
                    arrowConfiguration.Schema?.Select(ToArrowFieldInternal).ToList());
            }
            else if (textConfiguration is BlobQueryParquetTextOptions parquetTextConfiguration)
            {
                if (!isInput)
                {
                    throw new ArgumentException($"{nameof(BlobQueryParquetTextOptions)} can only be used for input serialization.");
                }

                serialization.Format.Type = QueryFormatType.Parquet;
            }
            else
            {
                throw new ArgumentException($"Invalid options type.  Valid options are {nameof(BlobQueryCsvTextOptions)}, {nameof(BlobQueryJsonTextOptions)}, {nameof(BlobQueryArrowOptions)}, and {nameof(BlobQueryParquetTextOptions)}");
            }

            return serialization;
        }

        internal static ArrowFieldInternal ToArrowFieldInternal(this BlobQueryArrowField blobQueryArrowField)
        {
            if (blobQueryArrowField == null)
            {
                return null;
            }

            return new ArrowFieldInternal(blobQueryArrowField.Type.ToArrowFiledInternalType())
            {
                Name = blobQueryArrowField.Name,
                Precision = blobQueryArrowField.Precision,
                Scale = blobQueryArrowField.Scale
            };
        }

        internal static string ToArrowFiledInternalType(this BlobQueryArrowFieldType blobQueryArrowFieldType)
            => blobQueryArrowFieldType switch
            {
                BlobQueryArrowFieldType.Bool => Constants.QuickQuery.ArrowFieldTypeBool,
                BlobQueryArrowFieldType.Decimal => Constants.QuickQuery.ArrowFieldTypeDecimal,
                BlobQueryArrowFieldType.Double => Constants.QuickQuery.ArrowFieldTypeDouble,
                BlobQueryArrowFieldType.Int64 => Constants.QuickQuery.ArrowFieldTypeInt64,
                BlobQueryArrowFieldType.String => Constants.QuickQuery.ArrowFieldTypeString,
                BlobQueryArrowFieldType.Timestamp => Constants.QuickQuery.ArrowFieldTypeTimestamp,
                _ => throw new ArgumentException($"Unknown {nameof(BlobQueryArrowFieldType)}: {blobQueryArrowFieldType}"),
            };
    }
}

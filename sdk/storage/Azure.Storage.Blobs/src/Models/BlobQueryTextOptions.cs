// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob Query Text Configuration.
    /// See <see cref="BlobQueryCsvTextOptions"/> and <see cref="BlobQueryJsonTextOptions"/>.
    /// </summary>
    public abstract class BlobQueryTextOptions
    {
        /// <summary>
        /// Record Separator.
        /// </summary>
        public string RecordSeparator { get; set; }

        /// <summary>
        /// Builds a <see cref="BlobQueryCsvTextOptions"/>.
        /// </summary>
        /// <param name="recordSeparator">
        /// Record Separator.
        /// </param>
        /// <param name="columnSeparator">
        /// Column separator.
        /// </param>
        /// <param name="quotationCharacter">
        /// Field quote.
        /// </param>
        /// <param name="escapeCharacter">
        /// Escape character.
        /// </param>
        /// <param name="hasHeaders">
        /// Has headers.
        /// </param>
        public static BlobQueryCsvTextOptions BlobQueryCsvTextOptions(
            string recordSeparator,
            string columnSeparator,
            char? quotationCharacter,
            char? escapeCharacter,
            bool hasHeaders)
            => new BlobQueryCsvTextOptions
            {
                RecordSeparator = recordSeparator,
                ColumnSeparator = columnSeparator,
                QuotationCharacter = quotationCharacter,
                EscapeCharacter = escapeCharacter,
                HasHeaders = hasHeaders
            };

        /// <summary>
        /// Builds a <see cref="BlobQueryJsonTextOptions"/>.
        /// </summary>
        /// <param name="recordSeparator">
        /// Record Separator.
        /// </param>
        public static BlobQueryJsonTextOptions BlobQueryJsonTextOptions(
            string recordSeparator)
            => new BlobQueryJsonTextOptions
            {
                RecordSeparator = recordSeparator
            };
    }
}

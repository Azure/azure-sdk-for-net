// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Data Lake Query Text Configuration.
    /// See <see cref="DataLakeQueryCsvTextOptions"/> and <see cref="DataLakeQueryJsonTextOptions"/>.
    /// </summary>
    public abstract class DataLakeQueryTextOptions
    {
        /// <summary>
        /// Record Separator.
        /// </summary>
        public string RecordSeparator { get; set; }

        /// <summary>
        /// Builds a <see cref="DataLakeQueryCsvTextOptions"/>.
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
        public static DataLakeQueryCsvTextOptions DataLakeQueryCsvTextOptions(
            string recordSeparator,
            string columnSeparator,
            char? quotationCharacter,
            char? escapeCharacter,
            bool hasHeaders)
            => new DataLakeQueryCsvTextOptions
            {
                RecordSeparator = recordSeparator,
                ColumnSeparator = columnSeparator,
                QuotationCharacter = quotationCharacter,
                EscapeCharacter = escapeCharacter,
                HasHeaders = hasHeaders
            };

        /// <summary>
        /// Builds a <see cref="DataLakeQueryJsonTextOptions"/>.
        /// </summary>
        /// <param name="recordSeparator">
        /// Record Separator.
        /// </param>
        public static DataLakeQueryJsonTextOptions DataLakeQueryJsonTextOptions(
            string recordSeparator)
            => new DataLakeQueryJsonTextOptions
            {
                RecordSeparator = recordSeparator
            };
    }
}

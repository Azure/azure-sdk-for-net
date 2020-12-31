﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// CSV text configuration.
    /// </summary>
    public class DataLakeQueryCsvTextOptions : DataLakeQueryTextOptions
    {
        /// <summary>
        /// Record Separator.
        /// </summary>
        public string RecordSeparator { get; set; }

        /// <summary>
        /// Column separator.
        /// </summary>
        public string ColumnSeparator { get; set; }

        /// <summary>
        /// Field quote.
        /// </summary>
        public char? QuotationCharacter { get; set; }

        /// <summary>
        /// Escape character.
        /// </summary>
        public char? EscapeCharacter { get; set; }

        /// <summary>
        /// Has headers.
        /// </summary>
        public bool HasHeaders { get; set; }
    }
}

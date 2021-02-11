// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The type of a <see cref="DataLakeQueryArrowField"/>.
    /// </summary>
    public enum DataLakeQueryArrowFieldType
    {
#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>
        /// Int64.
        /// </summary>
        Int64,

        /// <summary>
        /// Bool.
        /// </summary>
        Bool,

        /// <summary>
        /// Timestamp in milliseconds.
        /// </summary>
        Timestamp,

        /// <summary>
        /// String.
        /// </summary>
        String,

        /// <summary>
        /// Double.
        /// </summary>
        Double,

        /// <summary>
        /// Decimal.
        /// </summary>
        Decimal
#pragma warning restore CA1720 // Identifier contains type name
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Describe a field in <see cref="DataLakeQueryArrowOptions"/>.
    /// </summary>
    public class DataLakeQueryArrowField
    {
        /// <summary>
        /// The type of the field. Required.
        /// </summary>
        public DataLakeQueryArrowFieldType Type { get; set; }

        /// <summary>
        /// The name of the field.  Optional.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The precision of the field.  Required if Type is <see cref="DataLakeQueryArrowFieldType.Decimal"/>.
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// The scale of the field.  Required if Type is <see cref="DataLakeQueryArrowFieldType.Decimal"/>.
        /// </summary>
        public int Scale { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Arrow configuration.  Only valid for <see cref="DataLakeQueryOptions.OutputTextConfiguration"/>.
    /// </summary>
    public class DataLakeQueryArrowOptions : DataLakeQueryTextOptions
    {
        /// <summary>
        /// List of <see cref="DataLakeQueryArrowField"/> describing the schema of the data.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<DataLakeQueryArrowField> Schema { get; set; } = new List<DataLakeQueryArrowField>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}

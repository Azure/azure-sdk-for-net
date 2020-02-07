// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for creating a table. </summary>
    public partial class TableProperties
    {
        /// <summary> The name of the table to create. </summary>
        public string TableName { get; set; }
    }
}

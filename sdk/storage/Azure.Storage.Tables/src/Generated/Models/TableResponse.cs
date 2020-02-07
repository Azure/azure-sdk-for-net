// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> The response for a single table. </summary>
    public partial class TableResponse : TableResponseProperties
    {
        /// <summary> The metadata response of the table. </summary>
        public string OdataMetadata { get; set; }
    }
}

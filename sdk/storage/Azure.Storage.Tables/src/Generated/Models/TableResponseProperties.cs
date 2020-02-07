// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for the table response. </summary>
    public partial class TableResponseProperties
    {
        /// <summary> The name of the table. </summary>
        public string TableName { get; set; }
        /// <summary> The odata type of the table. </summary>
        public string OdataType { get; set; }
        /// <summary> The id of the table. </summary>
        public string OdataId { get; set; }
        /// <summary> The edit link of the table. </summary>
        public string OdataEditLink { get; set; }
    }
}

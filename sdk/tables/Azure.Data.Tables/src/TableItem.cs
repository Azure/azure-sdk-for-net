// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    [CodeGenModel("TableResponseProperties")]
    public partial class TableItem
    {
        internal string OdataType { get; }
        /// <summary> The id of the table. </summary>
        internal string OdataId { get; }
        /// <summary> The edit link of the table. </summary>
        internal string OdataEditLink { get; }
    }
}

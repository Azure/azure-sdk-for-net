// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.Tables.Models
{
    [CodeGenModel("TableResponseProperties")]
    public partial class TableItem
    {
        /// <summary>
        /// The OdataType.
        /// </summary>
        internal string OdataType { get; }

        /// <summary> The id of the table. </summary>
        internal string OdataId { get; }

        /// <summary> The edit link of the table. </summary>
        internal string OdataEditLink { get; }

        /// <summary> The name of the table. </summary>
        [CodeGenMember("TableName")]
        public string Name { get; }

        /// <summary> Initializes a new instance of TableItem. </summary>
        public TableItem(string name) { Name = name; }
    }
}

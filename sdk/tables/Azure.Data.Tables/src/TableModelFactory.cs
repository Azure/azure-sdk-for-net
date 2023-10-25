// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.Tables.Models
{
    [CodeGenModel("DataTablesModelFactory")]
    public static partial class TableModelFactory
    {
        /// <summary> Initializes new instance of TableItem class. </summary>
        /// <param name="name"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <returns> A new <see cref="Models.TableItem"/> instance for mocking. </returns>
        public static TableItem TableItem(string name = default, string odataType = default, string odataId = default, string odataEditLink = default)
        {
            return new TableItem(name, odataType, odataId, odataEditLink);
        }
    }
}

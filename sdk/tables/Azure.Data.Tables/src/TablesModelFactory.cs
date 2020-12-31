// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    /// <summary>
    /// A factory class which constructs model classes for mocking purposes.
    /// </summary>
    public static class TablesModelFactory
    {
        /// <summary> Initializes a new instance of TableItem. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        public static TableItem TableItem(string tableName, string odataType, string odataId, string odataEditLink) =>
            new TableItem(tableName, odataType, odataId, odataEditLink);
    }
}

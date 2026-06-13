// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenSuppress(nameof(GeneratedKeyName), typeof(string))] // Work around for generator generating two GeneratedKeyName properties due to tsp definition.
    public partial class KnowledgeStoreTableProjectionSelector
    {
        /// <summary> Initializes a new instance of <see cref="KnowledgeStoreTableProjectionSelector"/>. </summary>
        /// <param name="tableName"> Name of the Azure table to store projected data in. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tableName"/> is null. </exception>
        public KnowledgeStoreTableProjectionSelector(string tableName)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));

            TableName = tableName;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: expose Columns and Rows as IReadOnlyList.
    public partial class QueryResult
    {
        /// <summary> Array of columns. </summary>
        public IReadOnlyList<QueryColumn> Columns => (IReadOnlyList<QueryColumn>)Properties?.Columns;

        /// <summary> Array of rows. </summary>
        public IReadOnlyList<IList<BinaryData>> Rows => (IReadOnlyList<IList<BinaryData>>)Properties?.Rows;
    }
}

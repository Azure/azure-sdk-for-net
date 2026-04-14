// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.CostManagement.Models
{
    /// <summary> Backward-compat: expose Columns and Rows as IReadOnlyList. </summary>
    public partial class ForecastResult
    {
        /// <summary> Array of columns. </summary>
        public IReadOnlyList<ForecastColumn> Columns => (IReadOnlyList<ForecastColumn>)Properties?.Columns;

        /// <summary> Array of rows. </summary>
        public IReadOnlyList<IList<BinaryData>> Rows => (IReadOnlyList<IList<BinaryData>>)Properties?.Rows;
    }
}

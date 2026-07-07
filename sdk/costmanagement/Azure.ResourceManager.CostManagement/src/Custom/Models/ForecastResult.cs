// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: expose Columns and Rows as IReadOnlyList.
    public partial class ForecastResult
    {
        /// <summary> Array of columns. </summary>
        public IReadOnlyList<ForecastColumn> Columns => Properties?.Columns as IReadOnlyList<ForecastColumn>;

        /// <summary> Array of rows. </summary>
        public IReadOnlyList<IList<BinaryData>> Rows => Properties?.Rows as IReadOnlyList<IList<BinaryData>>;
    }
}

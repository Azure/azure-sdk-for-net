// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.CostManagement.Models
{
    /// <summary> Backward-compat: restore Columns property (now on Configuration). </summary>
    public partial class ExportDataset
    {
        /// <summary> Array of column names to be included in the export. </summary>
        public IList<string> Columns => Configuration?.Columns;
    }
}

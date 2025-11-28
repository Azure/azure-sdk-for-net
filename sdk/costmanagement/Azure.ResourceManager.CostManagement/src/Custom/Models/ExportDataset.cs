// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.CostManagement.Models
{
    public partial class ExportDataset
    {
        /// <summary> Array of column names to be included in the export. If not provided then the export will include all available columns. The available columns can vary by customer channel (see examples). </summary>
        public IList<string> Columns
        {
            get
            {
                if (Configuration is null)
                    Configuration = new ExportDatasetConfiguration();
                return Configuration.Columns;
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: baseline exposed IReadOnlyList<string> Data on CostManagementDimension.
    public partial class CostManagementDimension
    {
        /// <summary> Dimension data. </summary>
        public IReadOnlyList<string> Data => Properties?.Data as IReadOnlyList<string>;
    }
}

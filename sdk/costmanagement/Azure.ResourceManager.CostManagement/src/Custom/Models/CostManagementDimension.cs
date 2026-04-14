// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.CostManagement.Models
{
    /// <summary> Backward-compat: expose Data as IReadOnlyList. </summary>
    public partial class CostManagementDimension
    {
        /// <summary> Dimension data. </summary>
        public IReadOnlyList<string> Data => (IReadOnlyList<string>)Properties?.Data;
    }
}

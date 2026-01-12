// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Solutions metrics based chart. </summary>
    public partial class MetricsBasedChart
    {
        /// <summary> List of filters. </summary>
        public IReadOnlyList<SelfHelpFilter> Filter
        {
            get => FilterGroup?.Filter;
        }
    }
}

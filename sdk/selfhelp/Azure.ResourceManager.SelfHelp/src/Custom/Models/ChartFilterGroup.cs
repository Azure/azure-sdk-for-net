// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Filter group. </summary>
    internal partial class ChartFilterGroup
    {
        /// <summary> List of filters. </summary>
        public IReadOnlyList<SelfHelpFilter> Filter { get; }
    }
}

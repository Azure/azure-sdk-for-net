// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Solution replacement maps. </summary>
    public partial class SolutionReplacementMaps
    {
        /// <summary> Solution AzureKB results. </summary>
        public IReadOnlyList<KBWebResult> WebResults { get; }

        /// <summary> Solution diagnostics results. </summary>
        public IReadOnlyList<SolutionsDiagnostic> Diagnostics { get; }

        /// <summary> Solutions Troubleshooters. </summary>
        public IReadOnlyList<SolutionsTroubleshooters> Troubleshooters { get; }

        /// <summary> Solution metrics based charts. </summary>
        public IReadOnlyList<MetricsBasedChart> MetricsBasedCharts { get; }

        /// <summary> Video solutions, which have the power to engage the customer by stimulating their senses. </summary>
        public IReadOnlyList<SelfHelpVideo> Videos { get; }

        /// <summary> Group of Videos. </summary>
        public IReadOnlyList<VideoGroupDetail> VideoGroups { get; }
    }
}

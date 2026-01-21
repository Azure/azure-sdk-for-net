// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> Solution replacement maps. </summary>
    public partial class ReplacementMapsResult
    {
        /// <summary> Solution AzureKB results. </summary>
        public IReadOnlyList<KBWebResult> WebResults { get; }

        /// <summary> Video solutions, which have the power to engage the customer by stimulating their senses. </summary>
        public IReadOnlyList<SelfHelpVideo> Videos { get; }

        /// <summary> Group of Videos. </summary>
        public IReadOnlyList<VideoGroupDetail> VideoGroups { get; }
    }
}

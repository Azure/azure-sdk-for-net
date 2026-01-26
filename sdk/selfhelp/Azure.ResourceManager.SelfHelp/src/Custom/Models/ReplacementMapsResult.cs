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
        /// This is required to change the type of WebResults from IList to IReadOnlyList. The other two properties in the class are changed similarly.
        public IReadOnlyList<KBWebResult> WebResults { get; }

        /// <summary> Video solutions, which have the power to engage the customer by stimulating their senses. </summary>
        public IReadOnlyList<SelfHelpVideo> Videos { get; }

        /// <summary> Group of Videos. </summary>
        public IReadOnlyList<VideoGroupDetail> VideoGroups { get; }
    }
}

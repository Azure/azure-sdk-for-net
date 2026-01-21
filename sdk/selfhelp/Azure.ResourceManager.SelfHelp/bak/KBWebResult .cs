// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp;

namespace Azure.ResourceManager.SelfHelp.Models
{
    /// <summary> AzureKB web result. </summary>
    public partial class KBWebResult
    {
        /// <summary> AzureKB search results. </summary>
        public IReadOnlyList<KBSearchResult> SearchResults { get; }
    }
}

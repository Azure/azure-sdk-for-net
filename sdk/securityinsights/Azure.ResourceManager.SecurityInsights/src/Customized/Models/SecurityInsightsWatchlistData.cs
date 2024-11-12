// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    // Add this class due to the api compat check with property breaking chang to string type in 2024-01-01-preview version
    public partial class SecurityInsightsWatchlistData
    {
        /// <summary> The source of the watchlist. </summary>
        public Source? Source { get; set; }
    }
}

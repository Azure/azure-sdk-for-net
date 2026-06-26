// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights
{
    // The collection is constructed with the parent watchlist resource id, so DEBUG validation must accept the parent resource type.
    [CodeGenSuppress("ValidateResourceId", typeof(ResourceIdentifier))]
    public partial class SecurityInsightsWatchlistItemCollection
    {
        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SecurityInsightsWatchlistResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, SecurityInsightsWatchlistResource.ResourceType), nameof(id));
            }
        }
    }
}
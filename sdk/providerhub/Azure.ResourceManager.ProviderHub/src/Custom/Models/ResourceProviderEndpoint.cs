// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> The ResourceProviderEndpoint. </summary>
    public partial class ResourceProviderEndpoint
    {
        /// <summary> The api versions. </summary>
        public IReadOnlyList<string> ApiVersions { get; }
        /// <summary> The locations. </summary>
        public IReadOnlyList<AzureLocation> Locations { get; }
        /// <summary> The required features. </summary>
        public IReadOnlyList<string> RequiredFeatures { get; }
    }
}

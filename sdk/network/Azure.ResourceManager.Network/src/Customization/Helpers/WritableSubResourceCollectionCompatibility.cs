// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    internal static class WritableSubResourceCollectionCompatibility
    {
        // Adapt remaining NetworkSubResource-backed getters to the released read-only WritableSubResource contract.
        /// <summary> Invokes the ReadOnlyNetworkSubResourceList compatibility operation. </summary>
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<NetworkSubResource> source) => source is null ? default : new ReadOnlyNetworkSubResourceList(source);
        // Project reference IDs to the released WritableSubResource type for the remaining list adapters.
        internal static WritableSubResource ToWritable(NetworkSubResource value) => value is null ? default : new WritableSubResource { Id = value.Id };
    }
}

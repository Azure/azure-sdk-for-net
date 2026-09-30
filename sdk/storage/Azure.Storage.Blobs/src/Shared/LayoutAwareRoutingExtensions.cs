// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    internal static class LayoutAwareRoutingExtensions
    {
        public static LayoutAwareRouting ResolveAuto(this LayoutAwareRouting layoutAwareRouting)
        {
            // Auto maps to Enabled today, may change in the future.
            if (layoutAwareRouting == LayoutAwareRouting.Auto)
            {
                return LayoutAwareRouting.Enabled;
            }
            return layoutAwareRouting;
        }
    }
}

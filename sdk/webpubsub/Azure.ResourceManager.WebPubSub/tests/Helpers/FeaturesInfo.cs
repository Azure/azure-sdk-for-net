// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static class FeaturesInfo
    {
        public static HashSet<string> DefaultLocations = new HashSet<string>(new[] { "East US", "West US", "Central US", "West Europe" }, StringComparer.OrdinalIgnoreCase);

        public static HashSet<string> Ipv6SupportedLocations = new HashSet<string>(new[] { "East US", "West US", "Central US", "West Europe" }, StringComparer.OrdinalIgnoreCase);

        public static HashSet<string> AllFeaturesSupportedLocations = new HashSet<string>(new[] { "West US", "West Europe" }, StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// for every new feature added to sdk, you can create list of regions where it is enabled in the Hashset in utilities.
        /// and add the feature here to be able to run tests in that region
        /// </summary>
        public enum Type
        {
            Default,

            Ipv6,

            MultiCA,

            All
        }
    }
}

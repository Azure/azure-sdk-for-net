// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Tests.Helpers
{
    public static class FeaturesInfo
    {
       public static HashSet<string> defaultLocations = new HashSet<string>(new[] { "East US", "West US", "Central US", "West Europe" }, StringComparer.OrdinalIgnoreCase);

        public static HashSet<string> ipv6SupportedLocations = new HashSet<string>(new[] { "East US", "West US", "Central US", "West Europe" }, StringComparer.OrdinalIgnoreCase);        

        public static HashSet<string> allFeaturesSupportedLocations = new HashSet<string>(new[] { "West US", "West Europe" }, StringComparer.OrdinalIgnoreCase);
        
        /// <summary>
        /// for every new feature added to sdk, you can create list of regions where it is enabled in the Hashset in utilities 
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

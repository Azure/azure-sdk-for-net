// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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

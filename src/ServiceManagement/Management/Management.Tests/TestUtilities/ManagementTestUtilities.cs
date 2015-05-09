// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management;

namespace Microsoft.WindowsAzure.Testing
{
    public static class ManagementTestUtilities
    {
        /// <summary>
        /// Create a management client from the connection string stored in an environment variable
        /// </summary>
        /// <returns></returns>
        public static ManagementClient GetManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<ManagementClient>();
        }
        
        /// <summary>
        /// Returns a location meeting the specified constraints
        /// </summary>
        /// <param name="client">Management client to use to determine valid locations</param>
        /// <param name="requiredServices">The services required in the location</param>
        /// <returns>A location that contains the specified services</returns>
        public static string GetDefaultLocation(this ManagementClient client, params string[] requiredServices)
        {
            return client.Locations.List().Locations.First(
                l => (null == requiredServices || requiredServices.Length < 1) ||
                requiredServices.All(s => l.AvailableServices.Contains(s))
            ).Name;
        }
    }
}

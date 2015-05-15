// 
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
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Globalization;

namespace Microsoft.WindowsAzure.Management.Monitoring.Utilities
{
    /// <summary>
    /// Use this class to build resource id instances of various Azure resources for autoscale.
    /// </summary>
    public static class AutoscaleResourceIdBuilder
    {
        /// <summary>
        /// Builds the resource id of the web site resource to use in Autoscale API.
        /// </summary>
        /// <param name="webspaceName">The web space name.</param>
        /// <param name="serverFarmName">The server farm name.</param>
        /// <returns>The resource id.</returns>
        public static string BuildWebSiteResourceId(string webspaceName, string serverFarmName)
        {
            if (string.IsNullOrWhiteSpace(webspaceName))
            {
                throw new ArgumentException("webspaceName");
            }

            if (string.IsNullOrWhiteSpace(serverFarmName))
            {
                throw new ArgumentException("serverFarmName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/webspaces/{0}/serverfarms/{1}", webspaceName, serverFarmName);
        }

        /// <summary>
        /// Build the resource id of the mobile service resource to use in Autoscale API.
        /// </summary>
        /// <param name="mobileServiceName">The mobile service name.</param>
        /// <returns>The resource id</returns>
        public static string BuildMobileServiceResourceId(string mobileServiceName)
        {
            if (string.IsNullOrWhiteSpace(mobileServiceName))
            {
                throw new ArgumentException("mobileServiceName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/mobileservices/{0}", mobileServiceName);
        }

        /// <summary>
        /// Builds the resource id of the virtual machine resource.
        /// </summary>
        /// <param name="cloudServiceName">The cloud service name.</param>
        /// <param name="availabilitySetName">The availability set name.</param>
        /// <returns>The resource id.</returns>
        public static string BuildVirtualMachineResourceId(string cloudServiceName, string availabilitySetName)
        {
            if (string.IsNullOrWhiteSpace(cloudServiceName))
            {
                throw new ArgumentException("cloudServiceName");
            }

            if (string.IsNullOrWhiteSpace(availabilitySetName))
            {
                throw new ArgumentException("availabilitySetName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/virtualmachines/{0}/availabilitysets/{1}", cloudServiceName, availabilitySetName);
        }

        /// <summary>
        /// Build the resource id of the cloud service resource to use in Autoscale API.
        /// </summary>
        /// <param name="cloudServiceName">The cloud service name.</param>
        /// <param name="roleName">The role name.</param>
        /// <param name="isProductionSlot">A value indicating whether the
        /// deployment slot is a production slot.</param>
        /// <returns>The resource id.</returns>
        public static string BuildCloudServiceResourceId(string cloudServiceName, string roleName, bool isProductionSlot)
        {
            if (string.IsNullOrWhiteSpace(cloudServiceName))
            {
                throw new ArgumentException("cloudServiceName");
            }

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("roleName");
            }

            return string.Format(
                CultureInfo.InvariantCulture, 
                "/hostedservices/{0}/deploymentslots/{1}/roles/{2}",
                cloudServiceName,
                isProductionSlot ? "Production" : "Staging",
                roleName);
        }
    }
}

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
    /// Use this class to build the metric source for autoscale metric trigger.
    /// </summary>
    public static class AutoscaleMetricSourceBuilder
    {
        /// <summary>
        /// Build the metric source of a cloud service role.
        /// </summary>
        /// <param name="cloudServiceName">The cloud service name.</param>
        /// <param name="roleName">The role name</param>
        /// <param name="isProductionSlot">A flag that determines whether deployment is in production or staging slot.</param>
        /// <returns>The autoscale metric source.</returns>
        public static string BuildCloudServiceMetricSource(string cloudServiceName, string roleName, bool isProductionSlot)
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
                "/CloudService/{0}/{1}/{2}",
                cloudServiceName,
                isProductionSlot ? "Production" : "Staging",
                roleName);
        }

        /// <summary>
        /// Build the metric source of a cloud service role instance.
        /// </summary>
        /// <param name="cloudServiceName">The cloud service name.</param>
        /// <param name="roleName">The role name</param>
        /// <param name="roleInstanceName">The role instance name</param>
        /// <param name="isProductionSlot">A flag that determines whether deployment is in production or staging slot.</param>
        /// <returns>The autoscale metric source.</returns>
        public static string BuildCloudServiceMetricSource(string cloudServiceName, string roleName, string roleInstanceName, bool isProductionSlot)
        {
            if (string.IsNullOrWhiteSpace(cloudServiceName))
            {
                throw new ArgumentException("cloudServiceName");
            }

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("roleName");
            }

            if (string.IsNullOrWhiteSpace(roleInstanceName))
            {
                throw new ArgumentException("roleInstanceName");
            }

            return string.Format(
                CultureInfo.InvariantCulture, 
                "{0}/{1}", 
                BuildCloudServiceMetricSource(cloudServiceName, roleName, isProductionSlot), 
                roleInstanceName);
        }

        /// <summary>
        /// Build the metric source of a virtual machine resource.
        /// </summary>
        /// <param name="cloudServiceName">Name of the cloud service.</param>
        /// <param name="availabilitySetName">The availability set name.</param>
        public static string BuildVirtualMachineMetricSource(string cloudServiceName, string availabilitySetName)
        {
            if (string.IsNullOrWhiteSpace(cloudServiceName))
            {
                throw new ArgumentException("cloudServiceName");
            }

            if (string.IsNullOrWhiteSpace(availabilitySetName))
            {
                throw new ArgumentException("availabilitySetName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/VirtualMachinesAvailabilitySet/{0}/{1}", cloudServiceName, availabilitySetName);
        }

        /// <summary>
        /// Build the metric source of a storage queue resource.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="queueName">The queue name.</param>
        /// <returns>The metric source.</returns>
        public static string BuildStorageQueueMetricSource(string storageAccountName, string queueName)
        {
            if (string.IsNullOrWhiteSpace(storageAccountName))
            {
                throw new ArgumentException("storageAccountName");
            }

            if (string.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentException("queueName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/Storage/{0}/Queue/{1}", storageAccountName, queueName);
        }

        /// <summary>
        /// Build the metric source of a storage resource.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <returns>The metric source.</returns>
        public static string BuildStorageServiceMetricSource(string storageAccountName, string resourceType)
        {
            if (string.IsNullOrWhiteSpace(storageAccountName))
            {
                throw new ArgumentException("storageAccountName");
            }

            if (string.IsNullOrWhiteSpace(resourceType))
            {
                throw new ArgumentException("resourceType");
            }

            return string.Format(CultureInfo.InvariantCulture, "/Storage/ServiceMetric/{0}/{1}", storageAccountName, resourceType);
        }

        /// <summary>
        /// Build the metric source of a storage resource.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="apiName">The API name.</param>
        /// <returns>The metric source.</returns>
        public static string BuildStorageApiMetricSource(string storageAccountName, string resourceType, string apiName)
        {
            if (string.IsNullOrWhiteSpace(storageAccountName))
            {
                throw new ArgumentException("storageAccountName");
            }

            if (string.IsNullOrWhiteSpace(resourceType))
            {
                throw new ArgumentException("resourceType");
            }

            if (string.IsNullOrWhiteSpace(apiName))
            {
                throw new ArgumentException("apiName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/Storage/APIMetric/{0}/{1}/{2}", storageAccountName, resourceType, apiName);
        }

        /// <summary>
        /// Build the metric source of a mobile service resource.
        /// </summary>
        /// <param name="mobileServiceName">The mobile service name.</param>
        /// <returns>The metric source.</returns>
        public static string BuildMobileServiceMetricSource(string mobileServiceName)
        {
            if (string.IsNullOrWhiteSpace(mobileServiceName))
            {
                throw new ArgumentException("mobileServiceName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/MobileService/{0}", mobileServiceName);
        }

        /// <summary>
        /// Build the metric source of a website resource.
        /// </summary>
        /// <param name="webspaceName">The web space name.</param>
        /// <returns>The metric source.</returns>
        public static string BuildWebSiteMetricSource(string webspaceName)
        {
            if (string.IsNullOrWhiteSpace(webspaceName))
            {
                throw new ArgumentException("webspaceName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/WebsiteDedicated/{0}/DefaultServerFarm", webspaceName);
        }

        /// <summary>
        /// Build the metric source of a website resource.
        /// </summary>
        /// <param name="webspaceName">The web space name.</param>
        /// <param name="websiteName">The website name.</param>
        /// <returns>The metric source.</returns>
        public static string BuildWebSiteMetricSource(string webspaceName, string websiteName)
        {
            if (string.IsNullOrWhiteSpace(webspaceName))
            {
                throw new ArgumentException("webspaceName");
            }

            if (string.IsNullOrWhiteSpace(websiteName))
            {
                throw new ArgumentException("websiteName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/Website/{0}/{1}", webspaceName, websiteName);
        }

        /// <summary>
        /// Build the metric source of a servicebus resource.
        /// </summary>
        /// <param name="servicebusNamespace">The service bus namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The metric source.</returns>
        public static string BuildServiceBusMetricSource(string servicebusNamespace, string resourceType, string resourceName)
        {
            if (string.IsNullOrWhiteSpace(servicebusNamespace))
            {
                throw new ArgumentException("servicebusNamespace");
            }

            if (string.IsNullOrWhiteSpace(resourceType))
            {
                throw new ArgumentException("resourceType");
            }

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentException("resourceName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/ServiceBus/{0}/{1}/{2}", servicebusNamespace, resourceType, resourceName);
        }
    }
}

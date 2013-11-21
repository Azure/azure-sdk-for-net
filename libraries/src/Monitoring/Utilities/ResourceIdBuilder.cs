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
using System.Text;

namespace Microsoft.WindowsAzure.Management.Monitoring.Utilities
{
    /// <summary>
    /// Use this class to build resource id instances of various Azure resources.
    /// </summary>
    public static class ResourceIdBuilder
    {
        /// <summary>
        /// Build the resource id of the compute resource.
        /// </summary>
        /// <param name="cloudServiceName">The cloud service name.</param>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="roleName">The role name.</param>
        /// <param name="roleInstanceId">The role instance id</param>
        /// <returns>The resource id.</returns>
        public static string BuildCloudServiceResourceId(
            string cloudServiceName,
            string deploymentName,
            string roleName = null,
            string roleInstanceId = null)
        {
            if (string.IsNullOrWhiteSpace(cloudServiceName))
            {
                throw new ArgumentException("cloudServiceName");
            }

            if (string.IsNullOrWhiteSpace(deploymentName))
            {
                throw new ArgumentException("deploymentName");
            }

            var sb = new StringBuilder();
            sb.Append(string.Format(CultureInfo.InvariantCulture, "/hostedservices/{0}", cloudServiceName));

            if (string.IsNullOrWhiteSpace(deploymentName))
            {
                return sb.ToString();
            }

            sb.Append(string.Format(CultureInfo.InvariantCulture, "/deployments/{0}", deploymentName));

            if (string.IsNullOrWhiteSpace(roleName))
            {
                return sb.ToString();
            }

            sb.Append(string.Format(CultureInfo.InvariantCulture, "/roles/{0}", roleName));

            if (!string.IsNullOrWhiteSpace(roleInstanceId))
            {
                sb.Append(string.Format(CultureInfo.InvariantCulture, "/roleinstances/{0}", roleInstanceId));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Builds the resource id of the virtual machine resource.
        /// </summary>
        /// <param name="cloudServiceName">The cloud service name.</param>
        /// <param name="deploymentName">The deployment name.</param>
        /// <param name="roleName">The role name.</param>
        /// <param name="roleInstanceId">The role instance id.</param>
        /// <returns>The resource id.</returns>
        public static string BuildVirtualMachineResourceId(
            string cloudServiceName,
            string deploymentName,
            string roleName = null,
            string roleInstanceId = null)
        {
            if (string.IsNullOrWhiteSpace(cloudServiceName))
            {
                throw new ArgumentException("cloudServiceName");
            }

            if (string.IsNullOrWhiteSpace(deploymentName))
            {
                throw new ArgumentException("deploymentName");
            }

            return BuildCloudServiceResourceId(cloudServiceName, deploymentName, roleName, roleInstanceId);
        }

        /// <summary>
        /// Builds the resource id of the storage resource.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="service">The storage service name. Blob, Table and Queue are the supported service names.</param>
        /// <returns>The resource id.</returns>
        public static string BuildStorageResourceId(
            string storageAccountName,
            string service = null)
        {
            if (string.IsNullOrWhiteSpace(storageAccountName))
            {
                throw new ArgumentException("storageAccountName");
            }

            var sb = new StringBuilder();
            sb.Append(string.Format(CultureInfo.InvariantCulture, "/storageservices/{0}", storageAccountName));

            if (!string.IsNullOrWhiteSpace(service))
            {
                sb.Append(string.Format(CultureInfo.InvariantCulture, "/{0}", service));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Build the resource id of the mobile service resource.
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
        /// Builds the resource id of the web site resource.
        /// </summary>
        /// <param name="webspaceName">The web space name.</param>
        /// <param name="websiteName">The web site name.</param>
        /// <returns>The resource id.</returns>
        public static string BuildWebSiteResourceId(
            string webspaceName,
            string websiteName)
        {
            if (string.IsNullOrWhiteSpace(webspaceName))
            {
                throw new ArgumentException("webspaceName");
            }

            if (string.IsNullOrWhiteSpace(websiteName))
            {
                throw new ArgumentException("websiteName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/webspaces/{0}/sites/{1}", webspaceName, websiteName);
        }

        /// <summary>
        /// Builds the resource id of the HD Insight resource.
        /// </summary>
        /// <param name="regionName">The resion name.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <returns>The resource id.</returns>
        public static string BuildHdInsightResourceId(
            string regionName,
            string resourceName)
        {
            if (string.IsNullOrWhiteSpace(regionName))
            {
                throw new ArgumentException("regionName");
            }

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentException("resourceName");
            }

            return string.Format(CultureInfo.InvariantCulture, "/hdinsight/{0}/resources/containers/{1}", regionName, resourceName);
        }

        /// <summary>
        /// Builds the resource id of the service bus resource.
        /// </summary>
        /// <param name="servicebusNamespace">The service bus namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The resource id.</returns>
        public static string BuildServiceBusResourceId(
            string servicebusNamespace,
            string resourceType,
            string resourceName)
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

            var sb = new StringBuilder();

            sb.Append(string.Format(CultureInfo.InvariantCulture, "/servicebus/namespaces/{0}", servicebusNamespace));
            sb.Append(string.Format(CultureInfo.InvariantCulture, "/{0}", resourceType));
            sb.Append(string.Format(CultureInfo.InvariantCulture, "/{0}", resourceName));

            return sb.ToString();
        }

        /// <summary>
        /// Builds the resource id of the service bus topic subscription.
        /// </summary>
        /// <param name="servicebusNamespace">The service bus namespace.</param>
        /// <param name="topicName">The topic name.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <returns>The resource id.</returns>
        public static string BuildServiceBusTopicSubscriptionResourceId(
            string servicebusNamespace,
            string topicName,
            string subscriptionName)
        {
            if (string.IsNullOrWhiteSpace(servicebusNamespace))
            {
                throw new ArgumentException("servicebusNamespace");
            }

            if (string.IsNullOrWhiteSpace(topicName))
            {
                throw new ArgumentException("topicName");
            }

            if (string.IsNullOrWhiteSpace(subscriptionName))
            {
                throw new ArgumentException("subscriptionName");
            }

            string topicResourceId = ResourceIdBuilder.BuildServiceBusResourceId(servicebusNamespace, Constants.ServiceBusResourceType.Topics, topicName);

            var sb = new StringBuilder(topicResourceId);
            sb.Append(string.Format(CultureInfo.InvariantCulture, "/subscriptions/{0}", subscriptionName));

            return sb.ToString();
        }
    }
}
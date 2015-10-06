// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System;
    using System.Globalization;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal class HDInsightManagementRdfeUriBuilder : IHDInsightManagementRestUriBuilder
    {
        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly ICloudServiceNameResolver resolver;

        public HDInsightManagementRdfeUriBuilder(IHDInsightSubscriptionCredentials credentials)
        {
            this.credentials = credentials;
            this.resolver = ServiceLocator.Instance.Locate<ICloudServiceNameResolver>();
        }

        /// <inheritdoc />
        public Uri GetListCloudServicesUri()
        {
            string relativeUri = string.Format(CultureInfo.InvariantCulture, "{0}/cloudservices", this.credentials.SubscriptionId);
            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }

        /// <inheritdoc />
        public Uri GetGetClusterResourceDetailUri(string resourceId, string resourceType, string location)
        {
            string regionCloudServicename = this.resolver.GetCloudServiceName(this.credentials.SubscriptionId,
                                                                              this.credentials.DeploymentNamespace,
                                                                              location);
            string relativeUri = string.Format(CultureInfo.InvariantCulture,
                                        "{0}/cloudservices/{1}/resources/{2}/~/{3}/{4}",
                                        this.credentials.SubscriptionId,
                                        regionCloudServicename,
                                        this.credentials.DeploymentNamespace,
                                        resourceType,
                                        resourceId);

            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }

        /// <inheritdoc />
        public Uri GetCreateResourceUri(string resourceId, string resourceType, string location)
        {
            string regionCloudServicename = this.resolver.GetCloudServiceName(this.credentials.SubscriptionId,
                                                                              this.credentials.DeploymentNamespace,
                                                                              location);
            string relativeUri = string.Format(CultureInfo.InvariantCulture,
                                                    "{0}/cloudservices/{1}/resources/{2}/{3}/{4}",
                                                    this.credentials.SubscriptionId,
                                                    regionCloudServicename,
                                                    this.credentials.DeploymentNamespace,
                                                    resourceType,
                                                    resourceId);

            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }

        /// <inheritdoc />
        public Uri GetDeleteContainerUri(string dnsName, string location)
        {
            Guid subscriptionId = this.credentials.SubscriptionId;
            string cloudServiceName = this.credentials.DeploymentNamespace;
            string regionCloudServicename = this.resolver.GetCloudServiceName(subscriptionId,
                                                                                 cloudServiceName,
                                                                                 location);
            string relativeUri = string.Format(CultureInfo.InvariantCulture,
                                                "{0}/cloudservices/{1}/resources/{2}/{3}/{4}",
                                                subscriptionId,
                                                regionCloudServicename,
                                                this.credentials.DeploymentNamespace,
                                                "containers",
                                                dnsName);
            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }

        /// <inheritdoc />
        public Uri GetEnableDisableHttpUri(string dnsName, string location)
        {
            string regionCloudServicename = this.resolver.GetCloudServiceName(
                    this.credentials.SubscriptionId, this.credentials.DeploymentNamespace, location);

            string relativeUri = string.Format(CultureInfo.InvariantCulture,
                "/{0}/cloudservices/{1}/resources/{2}/~/containers/{3}/users/http",
                this.credentials.SubscriptionId,
                regionCloudServicename,
                this.credentials.DeploymentNamespace,
                dnsName);

            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }

        public Uri GetEnableDisableRdpUri(string dnsName, string location)
        {
            dnsName.ArgumentNotNullOrEmpty("dnsName");
            location.ArgumentNotNullOrEmpty("location");
            string regionCloudServicename = this.resolver.GetCloudServiceName(
                    this.credentials.SubscriptionId, this.credentials.DeploymentNamespace, location);

            string relativeUri = string.Format(CultureInfo.InvariantCulture,
                "/{0}/cloudservices/{1}/resources/{2}/~/containers/{3}/users/rdp",
                this.credentials.SubscriptionId,
                regionCloudServicename,
                this.credentials.DeploymentNamespace,
                dnsName);

            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }

        /// <inheritdoc />
        public Uri GetOperationStatusUri(string dnsName, string resourceType, string location, Guid operationId)
        {
            string regionCloudServicename = this.resolver.GetCloudServiceName(
                    this.credentials.SubscriptionId, this.credentials.DeploymentNamespace, location);

            // "/{0}/cloudservices/{1}/resources/{2}/~/containers/{3}/users/operations/{4}",
            string relativeUri = string.Format(CultureInfo.InvariantCulture,
                                               "/{0}/cloudservices/{1}/resources/{2}/~/containers/{3}/users/operations/{4}",
                                               this.credentials.SubscriptionId,
                                               regionCloudServicename,
                                               this.credentials.DeploymentNamespace,
                                               dnsName,
                                               operationId);

            return new Uri(this.credentials.Endpoint, new Uri(relativeUri, UriKind.Relative));
        }
    }
}

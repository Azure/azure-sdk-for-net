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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class HDInsightManagementPocoClient : DisposableObject, IHDInsightManagementPocoClient
    {
        internal const string ClusterCrudCapabilitityName = "CAPABILITY_FEATURE_CUSTOM_ACTIONS_V2";
        internal const string HighAvailabilityCapabilitityName = "CAPABILITY_FEATURE_HIGH_AVAILABILITY";

        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly bool ignoreSslErrors;

        public IAbstractionContext Context { get; private set; }

        internal HDInsightManagementPocoClient(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors)
        {
            this.Context = context;
            this.credentials = credentials;
            this.ignoreSslErrors = ignoreSslErrors;
            if (context.IsNotNull() && context.Logger.IsNotNull())
            {
                this.Logger = context.Logger;
            }
            else
            {
                this.Logger = new Logger();
            }
        }

        /// <inheritdoc />
        public event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;

        /// <inheritdoc />
        public void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e)
        {
            var handler = this.ClusterProvisioning;
            if (handler.IsNotNull())
            {
                handler(sender, e);
            }
        }

        public async Task<ICollection<ClusterDetails>> ListContainers()
        {
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.Context, this.ignoreSslErrors);
            var response = await client.ListCloudServices();
            return overrideHandlers.PayloadConverter.DeserializeListContainersResult(response.Content, this.credentials.DeploymentNamespace, this.credentials.SubscriptionId);
        }

        public async Task<ClusterDetails> ListContainer(string dnsName)
        {
            var clusters = await this.ListContainers();
            var result = clusters.FirstOrDefault(cluster => cluster.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public async Task<ClusterDetails> ListContainer(string dnsName, string location)
        {
            var clusters = await this.ListContainers();
            var result = clusters.FirstOrDefault(cluster => cluster.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase) && cluster.Location.Equals(location, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public async Task CreateContainer(ClusterCreateParametersV2 details)
        {
            this.LogMessage("Create Cluster Requested", Severity.Informational, Verbosity.Diagnostic);
            // Validates that the AzureStorage Configurations are valid and optionally append FQDN suffix to the storage account name
            AsvValidationHelper.ValidateAndResolveAsvAccountsAndPrep(details);

            // Validates that the config actions' Uris are downloadable.
            UriEndpointValidator.ValidateAndResolveConfigActionEndpointUris(details);

            var overrideHandlers =
                ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>()
                    .GetHandlers(this.credentials, this.Context, this.ignoreSslErrors);

            var rdfeCapabilitiesClient =
                ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>()
                    .Create(this.credentials, this.Context, this.ignoreSslErrors);
            var capabilities = await rdfeCapabilitiesClient.GetResourceProviderProperties();
            if (!this.HasClusterCreateCapability(capabilities))
            {
                throw new InvalidOperationException(string.Format(
                    "Your subscription cannot create clusters, please contact Support"));
            }

            // For container resource type, config actions should never be enabled
            if (details.ConfigActions != null && details.ConfigActions.Count > 0)
            {
                throw new InvalidOperationException(string.Format(
                    "Your subscription cannot create customized clusters, please contact Support"));
            }

            if (!new[] {"ExtraLarge", "Large"}.Contains(details.HeadNodeSize, StringComparer.OrdinalIgnoreCase)
                || !string.Equals(details.DataNodeSize, "Large", StringComparison.OrdinalIgnoreCase)
                || details.ZookeeperNodeSize.IsNotNullOrEmpty())
            {
                throw new InvalidOperationException(string.Format(
                    "Illegal node size specification for container resource. Headnode: [{0}], Datanode: [{1}], Zookeeper: [{2}]",
                    details.HeadNodeSize, details.DataNodeSize, details.ZookeeperNodeSize));
            }

            // Validates the region for the cluster creation
            var locationClient = ServiceLocator.Instance.Locate<ILocationFinderClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            var availableLocations = locationClient.ListAvailableLocations(capabilities);
            if (!availableLocations.Contains(details.Location, StringComparer.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(string.Format(
                        "Cannot create a cluster in '{0}'. Available Locations for your subscription are: {1}",
                        details.Location,
                        string.Join(",", availableLocations)));
            }

            // Validates whether the subscription\location needs to be initialized
            var registrationClient = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            await registrationClient.RegisterSubscription();
            if (!await registrationClient.ValidateSubscriptionLocation(details.Location))
            {
                await registrationClient.RegisterSubscriptionLocation(details.Location);
            }

            // Creates the cluster
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            if (details.ClusterType == ClusterType.HBase || details.ClusterType == ClusterType.Storm || details.ClusterType == ClusterType.Spark)
            {
                string payload = overrideHandlers.PayloadConverter.SerializeClusterCreateRequestV3(details);
                await client.CreateContainer(details.Name, details.Location, payload, 3);
            }
            else
            {
                if (!details.VirtualNetworkId.IsNullOrEmpty() || !details.SubnetName.IsNullOrEmpty())
                {
                    throw new InvalidOperationException("Create Hadoop clusters within a virtual network is not permitted.");
                }
                string payload = overrideHandlers.PayloadConverter.SerializeClusterCreateRequest(details);
                await client.CreateContainer(details.Name, details.Location, payload);
            }
        }

        public async Task DeleteContainer(string dnsName)
        {
            var task = this.ListContainer(dnsName);
            await task;
            var cluster = task.Result;

            if (cluster == null)
            {
                throw new HDInsightClusterDoesNotExistException(string.Format("The cluster '{0}' doesn't exist.", dnsName));
            }
            await this.DeleteContainer(cluster.Name, cluster.Location);
        }

        public async Task DeleteContainer(string dnsName, string location)
        {
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            await client.DeleteContainer(dnsName, location);
        }

        public Task<Guid> ChangeClusterSize(string dnsName, string location, int newSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> EnableDisableProtocol(UserChangeRequestUserType requestType, UserChangeRequestOperationType operation, string dnsName, string location, string userName, string password, DateTimeOffset expiration)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.Context, this.ignoreSslErrors);
            var manager = ServiceLocator.Instance.Locate<IUserChangeRequestManager>();
            var handler = manager.LocateUserChangeRequestHandler(this.credentials.GetType(), requestType);
            var payload = handler.Item2(operation, userName, password, expiration);
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            var response = await client.EnableDisableUserChangeRequest(dnsName, location, requestType, payload);
            var resultId = overrideHandlers.PayloadConverter.DeserializeConnectivityResponse(response.Content);
            var pocoHelper = new HDInsightManagementPocoHelper();
            pocoHelper.ValidateResponse(resultId);
            return resultId.Data;
        }

        public async Task<Guid> EnableHttp(string dnsName, string location, string httpUserName, string httpPassword)
        {
            return await this.EnableDisableProtocol(UserChangeRequestUserType.Http,
                                                    UserChangeRequestOperationType.Enable,
                                                    dnsName,
                                                    location,
                                                    httpUserName,
                                                    httpPassword,
                                                    DateTimeOffset.MinValue);
        }

        public async Task<Guid> DisableHttp(string dnsName, string location)
        {
            return await this.EnableDisableProtocol(UserChangeRequestUserType.Http,
                                                    UserChangeRequestOperationType.Disable,
                                                    dnsName,
                                                    location,
                                                    string.Empty,
                                                    string.Empty,
                                                    DateTimeOffset.MinValue);
        }

        public async Task<Guid> EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry)
        {
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>()
                .Create(this.credentials, this.Context, false);
            var operationId = await client.EnableDisableProtocol(UserChangeRequestUserType.Rdp,
                UserChangeRequestOperationType.Enable, dnsName, location, rdpUserName, rdpPassword, expiry);
            return operationId;
        }

        public async Task<Guid> DisableRdp(string dnsName, string location)
        {
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>()
                .Create(this.credentials, this.Context, false);
            var operationId =  await client.EnableDisableProtocol(UserChangeRequestUserType.Rdp,
                UserChangeRequestOperationType.Disable, dnsName, location, string.Empty, string.Empty, DateTime.MinValue);
            return operationId;
        }

        public async Task<bool> IsComplete(string dnsName, string location, Guid operationId)
        {
            var status = await this.GetStatus(dnsName, location, operationId);
            return status.State != UserChangeRequestOperationStatus.Pending;
        }

        public async Task<UserChangeRequestStatus> GetStatus(string dnsName, string location, Guid operationId)
        {
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.Context, this.ignoreSslErrors);
            var response = await client.GetOperationStatus(dnsName, location, operationId);
            var responseObject = overrideHandlers.PayloadConverter.DeserializeConnectivityStatus(response.Content);
            return responseObject.Data;
        }

        /// <inheritdoc />
        public Task<Data.Rdfe.Operation> GetRdfeOperationStatus(Guid operationId)
        {
            throw new NotImplementedException();
        }


        private bool HasClusterCreateCapability(IEnumerable<KeyValuePair<string, string>> capabilities)
        {
            return capabilities.Any(capability => capability.Key == ClusterCrudCapabilitityName);
        }

        public ILogger Logger { get; private set; }
    }
}
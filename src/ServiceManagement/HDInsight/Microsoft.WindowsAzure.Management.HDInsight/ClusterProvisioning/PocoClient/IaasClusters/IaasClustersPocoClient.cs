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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.IaasClusters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.IaasClusters;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class IaasClustersPocoClient : IHDInsightManagementPocoClient
    {
        private readonly IRdfeIaasClustersRestClient rdfeRestClient;
        private readonly IHDInsightSubscriptionCredentials credentials;
        internal const string ClustersResourceType = "IAASCLUSTERS";
        private readonly bool ignoreSslErrors;
        private const string ResourceAlreadyExists = "The condition specified by the ETag is not satisfied.";
        private const string ClustersContractCapabilityPattern = @"CAPABILITY_FEATURE_CLUSTERS_CONTRACT_(\d+)_SDK";
        private const string ClusterConfigActionCapabilitityName = "CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK";
        private static readonly Regex ClustersContractCapabilityRegex = new Regex(ClustersContractCapabilityPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly string UnSupportedOperationMessage = "This operation is not supported for clusters with OS Type " + OSType.Linux;

        /// <inheritdoc />
        public event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;

        private List<string> capabilities;

        public IAbstractionContext Context
        {
            get;
            private set;
        }

        public void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e)
        {
            this.OnClusterProvisioning(e);
        }

        internal IaasClustersPocoClient(IHDInsightSubscriptionCredentials credentials, bool ignoreSslErrors, IAbstractionContext context, List<string> capabilities)
            : this(credentials, ignoreSslErrors, context, capabilities, ServiceLocator.Instance.Locate<IRdfeIaasClustersRestClientFactory>().Create(credentials, context, ignoreSslErrors))
        {
        }

        internal IaasClustersPocoClient(
            IHDInsightSubscriptionCredentials credentials,
            bool ignoreSslErrors,
            IAbstractionContext context,
            List<string> capabilities,
            IRdfeIaasClustersRestClient rdfeRestClient)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (capabilities == null)
            {
                throw new ArgumentNullException("capabilities");
            }

            if (rdfeRestClient == null)
            {
                throw new ArgumentNullException("rdfeRestClient");
            }

            this.credentials = credentials;
            this.Context = context;
            this.Logger = context.Logger;
            this.ignoreSslErrors = ignoreSslErrors;
            this.rdfeRestClient = rdfeRestClient;
            this.capabilities = capabilities;
        }

        protected virtual void OnClusterProvisioning(ClusterProvisioningStatusEventArgs e)
        {
            var handler = this.ClusterProvisioning;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal static bool HasClusterConfigActionCapability(IEnumerable<string> capabilities)
        {
            return capabilities.Contains(ClusterConfigActionCapabilitityName, StringComparer.OrdinalIgnoreCase);
        }

        internal static bool HasCorrectSchemaVersionForConfigAction(IEnumerable<string> capabilities)
        {
            return capabilities.Contains(HDInsightClient.ClustersContractCapabilityVersion2, StringComparer.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public async Task CreateContainer(HDInsight.ClusterCreateParametersV2 clusterCreateParameters)
        {
            if (clusterCreateParameters == null)
            {
                throw new ArgumentNullException("clusterCreateParameters");
            }

            if (string.IsNullOrEmpty(clusterCreateParameters.Name))
            {
                throw new ArgumentException("ClusterCreateParameters.Name cannot be null or empty", "clusterCreateParameters");
            }

            if (string.IsNullOrEmpty(clusterCreateParameters.Location))
            {
                throw new ArgumentException("ClusterCreateParameters.Location cannot be null or empty", "clusterCreateParameters");
            }

            if (clusterCreateParameters.ClusterSizeInNodes < 1)
            {
                throw new ArgumentException("clusterCreateParameters.ClusterSizeInNodes must be > 0");
            }
            try
            {
                await this.RegisterSubscriptionIfExistsAsync();
                await this.CreateCloudServiceAsyncIfNotExists(clusterCreateParameters.Location);

                // TODO: fix hard-coded schema version
                string schemaVersion = "1.0";
                var iaasCluster = PayloadConverterIaasClusters.ConvertToIaasCluster(clusterCreateParameters, this.credentials.SubscriptionId.ToString());
                var rdfeResource = PayloadConverterIaasClusters.CreateRdfeResource(iaasCluster, schemaVersion);

                var resp = await
                    this.rdfeRestClient.CreateCluster(
                        this.credentials.SubscriptionId.ToString(),
                        this.GetCloudServiceName(clusterCreateParameters.Location),
                        this.credentials.DeploymentNamespace,
                        clusterCreateParameters.Name,
                        rdfeResource,
                        this.Context.CancellationToken);

                IEnumerable<String> requestIds;
                if (resp.Headers.TryGetValues("x-ms-request-id", out requestIds))
                {
                    Guid operationId;
                    if (!Guid.TryParse(requestIds.First(), out operationId))
                    {
                        throw new InvalidOperationException("Could not retrieve a valid operation id for the PUT (cluster create) operation.");
                    }

                    // Wait for the operation specified by the request id to complete (succeed or fail).
                    TimeSpan interval = TimeSpan.FromSeconds(1);
                    TimeSpan timeout = TimeSpan.FromMinutes(5);
                    await this.WaitForRdfeOperationToComplete(operationId, interval, timeout, Context.CancellationToken);
                }
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task<ICollection<ClusterDetails>> ListContainers()
        {
            try
            {
                var cloudServices =
                    await
                    this.rdfeRestClient.ListCloudServicesAsync(
                        this.credentials.SubscriptionId.ToString(), this.Context.CancellationToken);

                var listOfClusters = new List<GetIaasClusterResult>();
                foreach (CloudService service in cloudServices)
                {
                    foreach (
                        var clusterResource in service.Resources.Where(r => r.Type.Equals(ClustersResourceType, StringComparison.OrdinalIgnoreCase)))
                    {
                        listOfClusters.Add(await this.GetIaasClusterFromCloudServiceResource(service, clusterResource));
                    }
                }

                return listOfClusters.Select(r => r.ClusterDetails).ToList();

            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task<ClusterDetails> ListContainer(string dnsName)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentNullException("dnsName");
            }
            try
            {
                var result = await this.GetCluster(dnsName);
                return result == null ? null : result.ClusterDetails;
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                var content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task<ClusterDetails> ListContainer(string dnsName, string location)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentNullException("dnsName");
            }
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location");
            }
            try
            {
                var result = await this.GetCluster(dnsName, location);
                return result == null ? null : result.ClusterDetails;
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                var content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task DeleteContainer(string dnsName)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentNullException("dnsName");
            }

            try
            {
                var cloudServices = await this.ListCloudServices();

                var servicesHoldingTheService =
                    cloudServices.Where(
                        c =>
                        c.Resources.Any(
                            r =>
                            r.Type.Equals(ClustersResourceType, StringComparison.OrdinalIgnoreCase) &&
                            r.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase))).ToList();

                if (servicesHoldingTheService == null || servicesHoldingTheService.Count == 0)
                {
                    throw new HDInsightClusterDoesNotExistException(dnsName);
                }

                if (servicesHoldingTheService.Count > 1)
                {
                    throw new InvalidOperationException(string.Format("Multiple clusters found with dnsname '{0}'. Please specify dnsname and location", dnsName));
                }

                foreach (var service in servicesHoldingTheService)
                {
                    await
                        this.rdfeRestClient.DeleteCluster(
                            this.credentials.SubscriptionId.ToString(),
                            this.GetCloudServiceName(service.GeoRegion),
                            this.credentials.DeploymentNamespace,
                            dnsName,
                            this.Context.CancellationToken);
                }
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task DeleteContainer(string dnsName, string location)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentNullException("dnsName");
            }

            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location");
            }
            try
            {
                await
                    this.rdfeRestClient.DeleteCluster(
                        this.credentials.SubscriptionId.ToString(),
                        this.GetCloudServiceName(location),
                        this.credentials.DeploymentNamespace,
                        dnsName,
                        this.Context.CancellationToken);
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task<Operation> GetRdfeOperationStatus(Guid operationId)
        {
            return await this.rdfeRestClient.GetRdfeOperationStatus(
                    this.credentials.SubscriptionId.ToString(),
                    operationId.ToString(),
                    this.Context.CancellationToken);
        }

        public void Dispose()
        {
            //nothing to dispose here.
            return;
        }

        public ILogger Logger { get; private set; }

        #region Not Supported Operations

        /// <inheritdoc />
        public Task<Guid> ChangeClusterSize(string dnsName, string location, int newSize)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        /// <inheritdoc />
        public Task<Guid> EnableDisableProtocol(UserChangeRequestUserType protocol, UserChangeRequestOperationType operation, string dnsName, string location, string userName, string password, DateTimeOffset expiration)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        /// <inheritdoc />
        public Task<Guid> EnableHttp(string dnsName, string location, string httpUserName, string httpPassword)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        /// <inheritdoc />
        public Task<Guid> DisableHttp(string dnsName, string location)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        public Task<Guid> EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        public Task<Guid> DisableRdp(string dnsName, string location)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        /// <inheritdoc />
        public Task<UserChangeRequestStatus> GetStatus(string dnsName, string location, Guid operationId)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        /// <inheritdoc />
        public Task<bool> IsComplete(string dnsName, string location, Guid operationId)
        {
            throw new NotSupportedException(UnSupportedOperationMessage);
        }

        #endregion

        #region Private methods

        private string GetCloudServiceName(string location)
        {
            return ServiceLocator.Instance.Locate<ICloudServiceNameResolver>()
                                 .GetCloudServiceName(
                                     this.credentials.SubscriptionId,
                                     this.credentials.DeploymentNamespace,
                                     location);
        }

        private async Task<CloudServiceList> ListCloudServices()
        {
            var cloudServices =
                await
                 this.rdfeRestClient.ListCloudServicesAsync(
                     this.credentials.SubscriptionId.ToString(), this.Context.CancellationToken);
            return cloudServices;
        }

        private async Task RegisterSubscriptionIfExistsAsync()
        {
            try
            {
                await
                    this.rdfeRestClient.RegisterSubscriptionIfNotExists(
                        this.credentials.SubscriptionId.ToString(), this.credentials.DeploymentNamespace + "." + ClustersResourceType.ToLowerInvariant(), this.Context.CancellationToken);
            }
            catch (InvalidExpectedStatusCodeException invalidExpectedStatusCodeException)
            {
                if (invalidExpectedStatusCodeException.ReceivedStatusCode == HttpStatusCode.Conflict)
                {
                    return;
                }
                throw;
            }
        }

        private async Task CreateCloudServiceAsyncIfNotExists(string regionName)
        {
            var resolvedCloudServiceName = ServiceLocator.Instance.Locate<ICloudServiceNameResolver>()
                                                         .GetCloudServiceName(
                                                             this.credentials.SubscriptionId,
                                                             this.credentials.DeploymentNamespace,
                                                             regionName);
            try
            {
                var cloudServices = await
                    this.rdfeRestClient.ListCloudServicesAsync(
                        this.credentials.SubscriptionId.ToString(),
                        this.Context.CancellationToken);

                if (!cloudServices.Any(c => c.Name.Equals(resolvedCloudServiceName, StringComparison.OrdinalIgnoreCase)))
                {
                    await
                        this.rdfeRestClient.PutCloudServiceAsync(
                            this.credentials.SubscriptionId.ToString(),
                            resolvedCloudServiceName,
                            new CloudService
                            {
                                Description = "HDInsight cloud service for provisioning clusters.",
                                GeoRegion = regionName,
                                Label = "HdInsightCloudService",
                                Name = resolvedCloudServiceName,
                            },
                            this.Context.CancellationToken);
                }
            }
            catch (InvalidExpectedStatusCodeException invalidExpectedStatusCodeException)
            {
                if (invalidExpectedStatusCodeException.ReceivedStatusCode == HttpStatusCode.Conflict)
                {
                    return;
                }

                if (invalidExpectedStatusCodeException.ReceivedStatusCode == HttpStatusCode.BadRequest)
                {
                    var str = invalidExpectedStatusCodeException.Response.Content != null
                        ? invalidExpectedStatusCodeException.Response.Content.ReadAsStringAsync().Result : string.Empty;

                    if (str.IndexOf(ResourceAlreadyExists, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        return;
                    }
                }

                throw;
            }
        }

        private async Task<GetIaasClusterResult> GetCluster(string dnsName)
        {
            var cloudServices = await this.ListCloudServices();
            Resource clusterResource = null;
            CloudService cloudServiceForResource = null;
            foreach (CloudService service in cloudServices)
            {
                clusterResource =
                    service.Resources.FirstOrDefault(
                        r =>
                        r.Type.Equals(ClustersResourceType, StringComparison.OrdinalIgnoreCase) &&
                        r.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase));
                if (clusterResource != null)
                {
                    cloudServiceForResource = service;
                    break;
                }
            }

            if (clusterResource == null)
            {
                return null;
            }

            var result = await this.GetIaasClusterFromCloudServiceResource(cloudServiceForResource, clusterResource);
            return result;
        }

        private async Task<GetIaasClusterResult> GetCluster(string dnsName, string location)
        {
            var cloudServices = await this.ListCloudServices();
            Resource clusterResource = null;
            CloudService cloudServiceForResource = null;
            foreach (CloudService service in cloudServices)
            {
                clusterResource =
                    service.Resources.FirstOrDefault(
                        r =>
                        r.Type.Equals(ClustersResourceType, StringComparison.OrdinalIgnoreCase) &&
                        r.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase) &&
                        service.GeoRegion.Equals(location, StringComparison.OrdinalIgnoreCase));
                if (clusterResource != null)
                {
                    cloudServiceForResource = service;
                    break;
                }
            }

            if (clusterResource == null)
            {
                return null;
            }

            var result = await this.GetIaasClusterFromCloudServiceResource(cloudServiceForResource, clusterResource);
            return result;
        }

        private async Task<GetIaasClusterResult> GetIaasClusterFromCloudServiceResource(CloudService cloudService, Resource clusterResource)
        {
            var clusterDetails = PayloadConverterIaasClusters.CreateClusterDetailsFromRdfeResourceOutput(cloudService.GeoRegion, clusterResource);

            HDInsight.ClusterState clusterState = clusterDetails.State;

            IaasCluster clusterFromGetClusterCall = null;
            if (clusterState != HDInsight.ClusterState.Deleting &&
                clusterState != HDInsight.ClusterState.DeletePending)
            {
                //we want to poll if we are either in error or unknown state. 
                //this is so that we can get the extended error information. 
                try
                {
                    PassthroughResponse response = await
                            this.rdfeRestClient.GetCluster(
                                this.credentials.SubscriptionId.ToString(),
                                this.GetCloudServiceName(cloudService.GeoRegion),
                                this.credentials.DeploymentNamespace,
                                clusterResource.Name,
                                this.Context.CancellationToken);

                    clusterFromGetClusterCall = this.SafeGetDataFromPassthroughResponse<IaasCluster>(response);

                    clusterDetails = PayloadConverterIaasClusters.CreateClusterDetailsFromGetClustersResult(clusterFromGetClusterCall);
                }
                catch (Exception)
                {
                    // Ignore all exceptions. We don't want ListContainers to fail on customers for whatever reason.
                    // If there is an issue with obtaining details about the cluster, mark the cluster in Error state with a generic error message

                    clusterDetails.State = HDInsight.ClusterState.Error;
                    if (clusterDetails.Error != null && string.IsNullOrEmpty(clusterDetails.Error.Message))
                    {
                        clusterDetails.Error.Message = "Unexpected error occurred. Could not retrieve details about the cluster.";
                    }
                }
            }

            clusterDetails.SubscriptionId = this.credentials.SubscriptionId;

            return new GetIaasClusterResult(clusterDetails, clusterFromGetClusterCall);
        }

        private T SafeGetDataFromPassthroughResponse<T>(PassthroughResponse response)
        {
            if (response.Error != null)
            {
                throw new HttpLayerException(response.Error.StatusCode, response.Error.ErrorMessage);
            }
            return (T)response.Data;
        }

        #endregion

        #region Private classes

        private class GetIaasClusterResult
        {
            private readonly ClusterDetails clusterDetails;
            private readonly IaasCluster resultOfGetClusterCall;

            internal GetIaasClusterResult(ClusterDetails clusterDetails, IaasCluster resultOfGetClusterCall)
            {
                if (clusterDetails == null)
                {
                    throw new ArgumentNullException("clusterDetails");
                }
                this.clusterDetails = clusterDetails;
                this.resultOfGetClusterCall = resultOfGetClusterCall;
            }

            public ClusterDetails ClusterDetails
            {
                get { return this.clusterDetails; }
            }

            public IaasCluster ResultOfGetClusterCall
            {
                get { return this.resultOfGetClusterCall; }
            }
        }

        #endregion
    }
}

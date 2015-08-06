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

using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.PaasClusters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class PaasClustersPocoClient : IHDInsightManagementPocoClient
    {
        private readonly IRdfeClustersResourceRestClient rdfeClustersRestClient;
        private readonly IHDInsightSubscriptionCredentials credentials;
        internal const string ClustersResourceType = "CLUSTERS";
        private readonly bool ignoreSslErrors;
        private const string ResourceAlreadyExists = "The condition specified by the ETag is not satisfied.";
        internal const string ResizeCapabilityEnabled = "ResizeEnabled";
        public const string ClusterConfigActionCapabilitityName = "CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK";
        private const string ResizeRoleAction = "Resize";
        private const string EnableRdpAction = "EnableRdp";

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

        internal PaasClustersPocoClient(IHDInsightSubscriptionCredentials credentials, bool ignoreSslErrors, IAbstractionContext context, List<string> capabilities)
            : this(credentials, ignoreSslErrors, context, capabilities, ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>().Create(credentials, context, ignoreSslErrors, SchemaVersionUtils.GetSchemaVersion(capabilities)))
        {
        }

        internal PaasClustersPocoClient(
            IHDInsightSubscriptionCredentials credentials,
            bool ignoreSslErrors,
            IAbstractionContext context,
            List<string> capabilities,
            IRdfeClustersResourceRestClient clustersResourceRestClient)
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

            if (clustersResourceRestClient == null)
            {
                throw new ArgumentNullException("clustersResourceRestClient");
            }

            this.credentials = credentials;
            this.Context = context;
            this.Logger = context.Logger;
            this.ignoreSslErrors = ignoreSslErrors;
            this.rdfeClustersRestClient = clustersResourceRestClient;
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

        private async Task RegisterSubscriptionIfExistsAsync()
        {
            try
            {
                await
                    this.rdfeClustersRestClient.RegisterSubscriptionIfNotExists(
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
                    this.rdfeClustersRestClient.ListCloudServicesAsync(
                        this.credentials.SubscriptionId.ToString(),
                        this.Context.CancellationToken);

                if (!cloudServices.Any(c => c.Name.Equals(resolvedCloudServiceName, StringComparison.OrdinalIgnoreCase)))
                {
                    await
                        this.rdfeClustersRestClient.PutCloudServiceAsync(
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

        internal static bool HasClusterConfigActionCapability(IEnumerable<string> capabilities)
        {
            return capabilities.Contains(ClusterConfigActionCapabilitityName, StringComparer.OrdinalIgnoreCase);

        }

        internal static bool HasCorrectSchemaVersionForConfigAction(IEnumerable<string> capabilities)
        {
            string resizeCapability;
            SchemaVersionUtils.SupportedSchemaVersions.TryGetValue(2, out resizeCapability);
            if (resizeCapability == null)
            {
                return false;
            }
            return capabilities.Contains(resizeCapability, StringComparer.OrdinalIgnoreCase);
        }

        internal static bool HasCorrectSchemaVersionForNewVMSizes(IEnumerable<string> capabilities)
        {
            string vmSizesCapability;
            SchemaVersionUtils.SupportedSchemaVersions.TryGetValue(3, out vmSizesCapability);
            if (vmSizesCapability == null)
            {
                return false;
            }
            return capabilities.Contains(vmSizesCapability, StringComparer.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <param name="clusterCreateParameters">The cluster create parameters.</param>
        /// <returns>A task.</returns>
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

            //allow zookeeper to be specified only for Hbase and Storm clusters
            if (clusterCreateParameters.ZookeeperNodeSize != null)
            {
                if (clusterCreateParameters.ClusterType != ClusterType.HBase &&
                    clusterCreateParameters.ClusterType != ClusterType.Storm)
                {
                    throw new ArgumentException(
                        string.Format("clusterCreateParameters.ZookeeperNodeSize must be null for {0} clusters.",
                        clusterCreateParameters.ClusterType));
                }
            }

            try
            {
                //Validate 
                AsvValidationHelper.ValidateAndResolveAsvAccountsAndPrep(clusterCreateParameters);

                // Validates config action component.
                if (clusterCreateParameters.ConfigActions != null && clusterCreateParameters.ConfigActions.Count > 0)
                {
                    this.LogMessage("Validating parameters for config actions.", Severity.Informational, Verbosity.Detailed);

                    if (!HasClusterConfigActionCapability(this.capabilities) ||
                        !HasCorrectSchemaVersionForConfigAction(this.capabilities))
                    {
                        throw new NotSupportedException("Your subscription does not support config actions.");
                    }

                    this.LogMessage("Validating URIs for config actions.", Severity.Informational, Verbosity.Detailed);

                    // Validates that the config actions' Uris are downloadable.
                    UriEndpointValidator.ValidateAndResolveConfigActionEndpointUris(clusterCreateParameters);
                }

                //Validate Rdp settings in case any of the RdpUsername or RdpPassword or RdpAccessExpiry is specified.
                if (!string.IsNullOrEmpty(clusterCreateParameters.RdpUsername) ||
                    !string.IsNullOrEmpty(clusterCreateParameters.RdpPassword) ||
                    clusterCreateParameters.RdpAccessExpiry.IsNotNull())
                {
                    if(string.IsNullOrEmpty(clusterCreateParameters.RdpUsername))
                    {
                        throw new ArgumentException(
                            "clusterCreateParameters.RdpUsername cannot be null or empty in case either RdpPassword or RdpAccessExpiry is specified",
                            "clusterCreateParameters");
                    }
                    if (string.IsNullOrEmpty(clusterCreateParameters.RdpPassword))
                    {
                        throw new ArgumentException(
                            "clusterCreateParameters.RdpPassword cannot be null or empty in case either RdpUsername or RdpAccessExpiry is specified",
                            "clusterCreateParameters");
                    }
                    if (clusterCreateParameters.RdpAccessExpiry.IsNull())
                    {
                        throw new ArgumentException(
                            "clusterCreateParameters.RdpAccessExpiry cannot be null or empty in case either RdpUsername or RdpPassword is specified",
                            "clusterCreateParameters");
                    }
                    if (clusterCreateParameters.RdpAccessExpiry < DateTime.UtcNow)
                    {
                        throw new ArgumentException(
                            "clusterCreateParameters.RdpAccessExpiry should be a time in future.",
                            "clusterCreateParameters");
                    }
                }

                //Validate if new vm sizes are used and if the schema is on.
                if (CreateHasNewVMSizesSpecified(clusterCreateParameters) &&
                    !HasCorrectSchemaVersionForNewVMSizes(this.capabilities))
                {
                    throw new NotSupportedException("Your subscription does not support new VM sizes.");
                }

                var rdfeCapabilitiesClient =
                  ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
                var capabilities = await rdfeCapabilitiesClient.GetResourceProviderProperties();

                // Validates the region for the cluster creation
                var locationClient = ServiceLocator.Instance.Locate<ILocationFinderClientFactory>().Create(this.credentials, this.Context, this.ignoreSslErrors);
                var availableLocations = locationClient.ListAvailableLocations(capabilities);
                if (!availableLocations.Contains(clusterCreateParameters.Location, StringComparer.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(string.Format(
                            "Cannot create a cluster in '{0}'. Available Locations for your subscription are: {1}",
                            clusterCreateParameters.Location,
                            string.Join(",", availableLocations)));
                }

                await this.RegisterSubscriptionIfExistsAsync();
                await this.CreateCloudServiceAsyncIfNotExists(clusterCreateParameters.Location);

                var wireCreateParameters = PayloadConverterClusters.CreateWireClusterCreateParametersFromUserType(clusterCreateParameters);
                var rdfeResourceInputFromWireInput = PayloadConverterClusters.CreateRdfeResourceInputFromWireInput(wireCreateParameters, SchemaVersionUtils.GetSchemaVersion(this.capabilities));

                var resp = await
                    this.rdfeClustersRestClient.CreateCluster(
                        this.credentials.SubscriptionId.ToString(),
                        this.GetCloudServiceName(clusterCreateParameters.Location),
                        this.credentials.DeploymentNamespace,
                        clusterCreateParameters.Name,
                        rdfeResourceInputFromWireInput,
                        this.Context.CancellationToken);

                // Retrieve the request id (or operation id) from the PUT Response. The request id will be used to poll on operation status.
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

        private static bool CreateHasNewVMSizesSpecified(ClusterCreateParametersV2 clusterCreateParameters)
        {
            return new[]
            {
                clusterCreateParameters.HeadNodeSize, 
                clusterCreateParameters.DataNodeSize, 
                clusterCreateParameters.ZookeeperNodeSize
            }
            .Except(
                new[]
                {
                    "ExtraLarge", 
                    "Large", 
                    "Medium", 
                    "Small", 
                    "ExtraSmall"
                }, StringComparer.OrdinalIgnoreCase).Any(ns => ns.IsNotNullOrEmpty());
        }

        /// <summary>
        /// Lists the HDInsight containers for a subscription.
        /// </summary>
        /// <returns>
        /// A task that can be used to retrieve a collection of HDInsight containers (clusters).
        /// </returns>
        public async Task<ICollection<ClusterDetails>> ListContainers()
        {
            try
            {
                var cloudServices =
                    await
                    this.rdfeClustersRestClient.ListCloudServicesAsync(
                        this.credentials.SubscriptionId.ToString(), this.Context.CancellationToken);

                var listOfClusters = new List<GetClusterResult>();
                foreach (CloudService service in cloudServices)
                {
                    foreach (
                        var clusterResource in service.Resources.Where(r => r.Type.Equals(ClustersResourceType, StringComparison.OrdinalIgnoreCase)))
                    {
                        listOfClusters.Add(await this.GetClusterFromCloudServiceResource(service, clusterResource));
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

        /// <summary>
        /// Deletes an HDInsight container (cluster). If there are multiple clusters with same
        /// name in different regions then all of them will be deleted.
        /// </summary>
        /// <param name="dnsName">The name of the cluster to delete.</param>
        /// <returns>
        /// A task that can be used to wait for the delete request to complete.
        /// </returns>
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
                        this.rdfeClustersRestClient.DeleteCluster(
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

        /// <summary>
        /// Deletes an HDInsight container (cluster).
        /// </summary>
        /// <param name="dnsName">The name of the cluster to delete.</param>
        /// <param name="location">The location of the cluster to delete.</param>
        /// <returns>
        /// A task that can be used to wait for the delete request to complete.
        /// </returns>
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
                    this.rdfeClustersRestClient.DeleteCluster(
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
        public async Task<Guid> ChangeClusterSize(string dnsName, string location, int newSize)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentNullException("dnsName", "The dns name cannot be null or empty.");
            }

            if (newSize < 1)
            {
                throw new ArgumentOutOfRangeException("newSize", "The new node count must be at least 1.");
            }

            try
            {
                var clusterResult = string.IsNullOrEmpty(location) ? await this.GetCluster(dnsName) : await this.GetCluster(dnsName, location);
                var cloudServiceName = this.GetCloudServiceName(clusterResult.ClusterDetails.Location);

                var cluster = clusterResult.ResultOfGetClusterCall;

                SchemaVersionUtils.EnsureSchemaVersionSupportsResize(this.capabilities);

                if (cluster.ClusterCapabilities == null ||
                    !cluster.ClusterCapabilities.Contains(ResizeCapabilityEnabled, StringComparer.OrdinalIgnoreCase))
                {
                    throw new NotSupportedException(
                        "This cluster does not support a change cluster size operation. Please drop and recreate the cluster to enable this operation.");
                }

                var clusterRoleCollection = cluster.ClusterRoleCollection;
                var workerRole = clusterRoleCollection.SingleOrDefault(role => role.FriendlyName.Equals("WorkerNodeRole"));
                if (workerRole == null)
                {
                    throw new NullReferenceException("The cluster does not contain a worker node role.");
                }

                if (workerRole.InstanceCount == newSize)
                {
                    return Guid.Empty;
                }
                workerRole.InstanceCount = newSize;

                this.LogMessage("Sending passthrough request to RDFE", Severity.Informational, Verbosity.Detailed);

                var resp = this.SafeGetDataFromPassthroughResponse<Contracts.May2014.Operation>(
                    await this.rdfeClustersRestClient.ChangeClusterSize(
                    this.credentials.SubscriptionId.ToString(),
                    cloudServiceName,
                    this.credentials.DeploymentNamespace,
                    dnsName,
                    ResizeRoleAction,
                    clusterRoleCollection,
                    this.Context.CancellationToken));
                var operationId = Guid.Parse(resp.OperationId);
                if (resp.Status.Equals(Contracts.May2014.OperationStatus.Failed))
                {
                    var message = string.Format("ChangeClusterSize operation with operation ID {0} failed with the following response:\n{1}", operationId, resp.ErrorDetails.ErrorMessage);
                    this.LogMessage(message, Severity.Error, Verbosity.Detailed);
                    throw new InvalidOperationException(message);
                }
                return operationId;
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                this.LogException(iEx);
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }


        public Task<Guid> EnableDisableProtocol(
            UserChangeRequestUserType protocol,
            UserChangeRequestOperationType operation,
            string dnsName,
            string location,
            string userName,
            string password,
            DateTimeOffset expiration)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enables Http Connectivity on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="httpUserName">The user name to use when enabling Http Connectivity.</param>
        /// <param name="httpPassword">The password to use when enabling Http Connectivity.</param>
        /// <returns>
        /// A task that can be used to wait for the request to complete.
        /// </returns>
        public Task<Guid> EnableHttp(string dnsName, string location, string httpUserName, string httpPassword)
        {
            return this.EnableDisableHttp(dnsName, httpUserName, httpPassword, true);
        }

        /// <summary>
        /// Disables Http Connectivity on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <returns>
        /// A task that can be used to wait for the request to complete.
        /// </returns>
        public Task<Guid> DisableHttp(string dnsName, string location)
        {
            return this.EnableDisableHttp(dnsName, null, null, false);
        }

        /// <summary>
        /// Enables Rdp user on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <param name="rdpUserName">The username of the rdp user on the cluster</param>
        /// <param name="rdpPassword">The password of the rdo user on the cluster</param>
        /// <param name="expiry">The time when the rdp access will expire on the cluster</param>
        /// <returns>A task that can be used to wait for the request to complete</returns>
        public async Task<Guid> EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry)
        {
            try
            {
                var clusterResult = string.IsNullOrEmpty(location) ? await this.GetCluster(dnsName) : await this.GetCluster(dnsName, location);
                var cloudServiceName = this.GetCloudServiceName(clusterResult.ClusterDetails.Location);
                var cluster = clusterResult.ResultOfGetClusterCall;
                var clusterRoleCollection = cluster.ClusterRoleCollection;

                var remoteDesktopSettings = new RemoteDesktopSettings
                {
                    AuthenticationCredential = new UsernamePasswordCredential
                    {
                        Username = rdpUserName,
                        Password = rdpPassword,
                    },
                    IsEnabled = true,
                    RemoteAccessExpiry = expiry,
                };

                foreach (var role in clusterRoleCollection)
                {
                    role.RemoteDesktopSettings = remoteDesktopSettings;
                }

                this.LogMessage("Sending passthrough request to RDFE", Severity.Informational, Verbosity.Detailed);

                var resp = this.SafeGetDataFromPassthroughResponse<Contracts.May2014.Operation>(
                    await this.rdfeClustersRestClient.EnableDisableRdp(
                        this.credentials.SubscriptionId.ToString(),
                        cloudServiceName,
                        credentials.DeploymentNamespace,
                        dnsName,
                        EnableRdpAction,
                        clusterRoleCollection, this.Context.CancellationToken));
                var operationId = Guid.Parse(resp.OperationId);
                if (resp.Status.Equals(Contracts.May2014.OperationStatus.Failed))
                {
                    var message = string.Format("EnableRdp operation with operation ID {0} failed with the following response:\n{1}", operationId, resp.ErrorDetails.ErrorMessage);
                    this.LogMessage(message, Severity.Error, Verbosity.Detailed);
                    throw new InvalidOperationException(message);
                }
                return operationId;
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                this.LogException(iEx);
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <summary>
        /// Disables the Rdp user on the HDInsight cluster.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster</param>
        /// <param name="location">The location of the cluster</param>
        /// <returns>A task that can be used to wait for the request to complete</returns>
        public async Task<Guid> DisableRdp(string dnsName, string location)
        {
            try
            {
                var clusterResult = string.IsNullOrEmpty(location) ? await this.GetCluster(dnsName) : await this.GetCluster(dnsName, location);
                var cloudServiceName = this.GetCloudServiceName(clusterResult.ClusterDetails.Location);
                var cluster = clusterResult.ResultOfGetClusterCall;
                var clusterRoleCollection = cluster.ClusterRoleCollection;

                var remoteDesktopSettings = new RemoteDesktopSettings
                {
                    IsEnabled = false, 
                };

                foreach (var role in clusterRoleCollection)
                {
                    role.RemoteDesktopSettings = remoteDesktopSettings;
                }

                this.LogMessage("Sending passthrough request to RDFE", Severity.Informational, Verbosity.Detailed);

                var resp = this.SafeGetDataFromPassthroughResponse<Contracts.May2014.Operation>(
                    await this.rdfeClustersRestClient.EnableDisableRdp(
                    this.credentials.SubscriptionId.ToString(),
                    cloudServiceName,
                    credentials.DeploymentNamespace,
                    dnsName,
                    EnableRdpAction,
                    clusterRoleCollection, this.Context.CancellationToken));
                var operationId = Guid.Parse(resp.OperationId);
                if (resp.Status.Equals(Contracts.May2014.OperationStatus.Failed))
                {
                    var message = string.Format("EnableRdp operation with operation ID {0} failed with the following response:\n{1}", operationId, resp.ErrorDetails.ErrorMessage);
                    this.LogMessage(message, Severity.Error, Verbosity.Detailed);
                    throw new InvalidOperationException(message);
                }
                return operationId;
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                this.LogException(iEx);
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <summary>
        /// Queries an operation status to check whether it is complete.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="operationId">The Id of the operation to wait for.</param>
        /// <returns>
        /// Returns true, if the the operation is complete.
        /// </returns>
        public async Task<bool> IsComplete(string dnsName, string location, Guid operationId)
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
                var status = await this.GetStatus(dnsName, location, operationId);
                return status.State != UserChangeRequestOperationStatus.Pending;
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <summary>
        /// Queries an operation status.
        /// </summary>
        /// <param name="dnsName">The DNS name of the cluster.</param>
        /// <param name="location">The location of the cluster.</param>
        /// <param name="operationId">The Id of the operation to wait for.</param>
        /// <returns>
        /// A status object for the operation.
        /// </returns>
        public async Task<UserChangeRequestStatus> GetStatus(string dnsName, string location, Guid operationId)
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
                var response =
                    await
                    this.rdfeClustersRestClient.CheckOperation(
                        this.credentials.SubscriptionId.ToString(),
                        this.GetCloudServiceName(location),
                        this.credentials.DeploymentNamespace,
                        dnsName,
                        operationId.ToString(),
                        this.Context.CancellationToken);

                var operationStatus = (Contracts.May2014.Operation)response.Data;

                PayloadErrorDetails payloadErrorDetails = null;
                if (response.Error != null)
                {
                    payloadErrorDetails = new PayloadErrorDetails
                    {
                        ErrorId = response.Error.ErrorId,
                        ErrorMessage = response.Error.ErrorMessage,
                        StatusCode = response.Error.StatusCode
                    };
                }

                return new UserChangeRequestStatus
                {
                    ErrorDetails = payloadErrorDetails,
                    UserType = UserChangeRequestUserType.Http,
                    State = ConvertOperationStatusToUserChangeOperationState(operationStatus.Status)
                };
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        /// <inheritdoc />
        public async Task<Data.Rdfe.Operation> GetRdfeOperationStatus(Guid operationId)
        {
            return await this.rdfeClustersRestClient.GetRdfeOperationStatus(
                    this.credentials.SubscriptionId.ToString(),
                    operationId.ToString(),
                    this.Context.CancellationToken);
        }

        private static UserChangeRequestOperationStatus ConvertOperationStatusToUserChangeOperationState(string operationStatus)
        {
            switch (operationStatus.ToUpperInvariant())
            {
                case "FAILED":
                    return UserChangeRequestOperationStatus.Error;
                case "SUCCEEDED":
                    return UserChangeRequestOperationStatus.Completed;
                case "INPROGRESS":
                    return UserChangeRequestOperationStatus.Pending;
            }
            return UserChangeRequestOperationStatus.Error;
        }

        private async Task<GetClusterResult> GetClusterFromCloudServiceResource(CloudService cloudService, Resource clusterResource)
        {
            var clusterDetails = PayloadConverterClusters.CreateClusterDetailsFromRdfeResourceOutput(
                   cloudService.GeoRegion,
                   clusterResource);

            HDInsight.ClusterState clusterState = clusterDetails.State;

            Cluster clusterFromGetClusterCall = null;
            if (clusterState != HDInsight.ClusterState.Deleting &&
                clusterState != HDInsight.ClusterState.DeletePending)
            {
                //we want to poll if we are either in error or unknown state. 
                //this is so that we can get the extended error information. 
                try
                {
                    clusterFromGetClusterCall =
                        this.SafeGetDataFromPassthroughResponse<Cluster>(
                            await
                            this.rdfeClustersRestClient.GetCluster(
                                this.credentials.SubscriptionId.ToString(),
                                this.GetCloudServiceName(cloudService.GeoRegion),
                                this.credentials.DeploymentNamespace,
                                clusterResource.Name,
                                this.Context.CancellationToken));

                    clusterDetails = PayloadConverterClusters.CreateClusterDetailsFromGetClustersResult(clusterFromGetClusterCall);
                }
                catch (InvalidExpectedStatusCodeException ie)
                {
                    //if we got a not found back that we means the RP has no record of this cluster. 
                    //It would happen if one of the basic validations fail, cluster dns name uniqueness
                    if (ie.ReceivedStatusCode == HttpStatusCode.NotFound)
                    {
                        //We may sometimes have a record of the cluster on the server, 
                        //which means we can populate extended error information
                    }
                }
            }

            clusterDetails.SubscriptionId = this.credentials.SubscriptionId;

            return new GetClusterResult(clusterDetails, clusterFromGetClusterCall);
        }

        private async Task<GetClusterResult> GetCluster(string dnsName)
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

            var result = await this.GetClusterFromCloudServiceResource(cloudServiceForResource, clusterResource);
            return result;
        }

        private async Task<GetClusterResult> GetCluster(string dnsName, string location)
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

            var result = await this.GetClusterFromCloudServiceResource(cloudServiceForResource, clusterResource);
            return result;
        }

        /// <summary>
        /// Lists a single HDInsight container by name.
        /// </summary>
        /// <param name="dnsName">The name of the HDInsight container.</param>
        /// <returns>
        /// A task that can be used to retrieve the requested HDInsight container.
        /// </returns>
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

        /// <summary>
        /// Lists a single HDInsight container by name and region.
        /// </summary>
        /// <param name="dnsName">The name of the HDInsight container.</param>
        /// <param name="location">The location of the HDInsight container.</param>
        /// <returns>
        /// A task that can be used to retrieve the requested HDInsight container.
        /// </returns>
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

        private async Task<CloudServiceList> ListCloudServices()
        {
            var cloudServices =
                await
                 this.rdfeClustersRestClient.ListCloudServicesAsync(
                     this.credentials.SubscriptionId.ToString(), this.Context.CancellationToken);
            return cloudServices;
        }

        /// <summary>
        /// Enables the disable HTTP.
        /// </summary>
        /// <param name="dnsName">Name of the DNS.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="enable">If set to <c>true</c> enable http user.</param>
        /// <returns>Operation id associated with this operation.</returns>
        /// <exception cref="System.ArgumentException">
        /// DnsName cannot be null or empty.;dnsName
        /// or
        /// Http username cannot be null or empty.
        /// or
        /// Http password cannot be null or empty.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// Http user is already enabled for the cluster. Please call Disable() first.
        /// or
        /// Http user is already disable for the cluster. Please call Enable() first.
        /// </exception>
        public async Task<Guid> EnableDisableHttp(string dnsName, string username, string password, bool enable)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentException("dnsName cannot be null or empty.", "dnsName");
            }

            try
            {
                var cloudServices = await this.ListCloudServices();

                Resource clusterResource = null;
                CloudService cloudServiceForResource = null;
                foreach (CloudService service in cloudServices)
                {
                    clusterResource = service.Resources.SingleOrDefault(r => r.Type.Equals(ClustersResourceType, StringComparison.OrdinalIgnoreCase)
                        && r.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase));
                    if (clusterResource != null)
                    {
                        cloudServiceForResource = service;
                        break;
                    }
                }

                if (clusterResource == null)
                {
                    throw new HDInsightClusterDoesNotExistException(dnsName);
                }

                var clusterResult = await this.GetClusterFromCloudServiceResource(cloudServiceForResource, clusterResource);

                var gw = clusterResult.ResultOfGetClusterCall.Components.OfType<GatewayComponent>().SingleOrDefault();
                if (enable)
                {
                    if (string.IsNullOrEmpty(username))
                    {
                        throw new ArgumentException("Http username cannot be null or empty.", username);
                    }

                    if (string.IsNullOrEmpty(password))
                    {
                        throw new ArgumentException("Http password cannot be null or empty.", username);
                    }
                    gw.IsEnabled = true;
                    gw.RestAuthCredential = new UsernamePasswordCredential { Username = username, Password = password };
                }
                else
                {
                    gw.IsEnabled = false;
                    gw.RestAuthCredential = null;
                }

                var cloudServiceName = this.GetCloudServiceName(clusterResult.ClusterDetails.Location);

                var resp = this.SafeGetDataFromPassthroughResponse<Contracts.May2014.Operation>(
                    await this.rdfeClustersRestClient.UpdateComponent(
                    this.credentials.SubscriptionId.ToString(),
                    cloudServiceName,
                    this.credentials.DeploymentNamespace,
                    dnsName,
                    "GatewayComponent",
                    gw,
                    this.Context.CancellationToken));

                return Guid.Parse(resp.OperationId);
            }
            catch (InvalidExpectedStatusCodeException iEx)
            {
                string content = iEx.Response.Content != null ? iEx.Response.Content.ReadAsStringAsync().Result : string.Empty;
                throw new HttpLayerException(iEx.ReceivedStatusCode, content);
            }
        }

        private string GetCloudServiceName(string location)
        {
            return ServiceLocator.Instance.Locate<ICloudServiceNameResolver>()
                                 .GetCloudServiceName(
                                     this.credentials.SubscriptionId,
                                     this.credentials.DeploymentNamespace,
                                     location);
        }

        private T SafeGetDataFromPassthroughResponse<T>(PassthroughResponse response)
        {
            if (response.Error != null)
            {
                throw new HttpLayerException(response.Error.StatusCode, response.Error.ErrorMessage);
            }
            return (T)response.Data;
        }

        private class GetClusterResult
        {
            private readonly ClusterDetails clusterDetails;
            private readonly Cluster resultOfGetClusterCall;

            internal GetClusterResult(ClusterDetails clusterDetails, Cluster resultOfGetClusterCall)
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

            public Cluster ResultOfGetClusterCall
            {
                get { return this.resultOfGetClusterCall; }
            }
        }

        public void Dispose()
        {
            //nothing to dispose here.
            return;
        }

        public ILogger Logger { get; private set; }
    }
}

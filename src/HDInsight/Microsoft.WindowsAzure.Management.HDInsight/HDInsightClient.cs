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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ResourceTypeFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <inheritdoc />
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
        Justification =
            "DisposableObject implements IDisposable correctly, the implementation of IDisposable in the interfaces is necessary for the design.")]
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "This complexity is needed to handle all the operations.")]
    public sealed class HDInsightClient : ClientBase, IHDInsightClient
    {
        private readonly Lazy<bool> canUseClustersContract;
        private Lazy<List<string>> capabilities;

        /// <summary>
        ///     Default HDInsight version.
        /// </summary>
        internal const string DEFAULTHDINSIGHTVERSION = "default";
        internal const string ClustersContractCapabilityVersion1 = "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK";
        internal static string ClustersContractCapabilityVersion2 = "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK";
        internal const string ClusterAlreadyExistsError = "The condition specified by the ETag is not satisfied.";

        private IHDInsightSubscriptionCredentials credentials;
        private ClusterDetails currentDetails;
        private const string DefaultSchemaVersion = "1.0";
        private TimeSpan defaultResizeTimeout = TimeSpan.FromHours(1);

        /// <summary>
        /// Gets the connection credential.
        /// </summary>
        public IHDInsightSubscriptionCredentials Credentials
        {
            get { return this.credentials; }
        }

        /// <inheritdoc />
        public TimeSpan PollingInterval { get; set; }

        /// <inheritdoc />
        internal static TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(15);

        /// <summary>
        /// Initializes a new instance of the HDInsightClient class.
        /// </summary>
        /// <param name="credentials">The credential to use when operating against the service.</param>
        /// <param name="httpOperationTimeout">The HTTP operation timeout.</param>
        /// <param name="policy">The retry policy.</param>
        /// <exception cref="System.InvalidOperationException">Unable to connect to the HDInsight subscription with the supplied type of credential.</exception>
        internal HDInsightClient(IHDInsightSubscriptionCredentials credentials, TimeSpan? httpOperationTimeout = null, IRetryPolicy policy = null)
            : base(httpOperationTimeout, policy)
        {
            var asCertificateCredentials = credentials;
            if (asCertificateCredentials.IsNull())
            {
                throw new InvalidOperationException("Unable to connect to the HDInsight subscription with the supplied type of credential");
            }
            this.credentials = ServiceLocator.Instance.Locate<IHDInsightSubscriptionCredentialsFactory>().Create(asCertificateCredentials);
            this.capabilities = new Lazy<List<string>>(this.GetCapabilities);
            this.canUseClustersContract = new Lazy<bool>(this.CanUseClustersContract);
            this.PollingInterval = DefaultPollingInterval;
        }

        /// <summary>
        /// Connects to an HDInsight subscription.
        /// </summary>
        /// <param name="credentials">
        /// The credential used to connect to the subscription.
        /// </param>
        /// <returns>
        /// A new HDInsight client.
        /// </returns>
        public static IHDInsightClient Connect(IHDInsightSubscriptionCredentials credentials)
        {
            return ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(credentials);
        }

        /// <summary>
        /// Connects the specified credentials.
        /// </summary>
        /// <param name="credentials">The credential used to connect to the subscription.</param>
        /// <param name="httpOperationTimeout">The HTTP operation timeout.</param>
        /// <param name="policy">The retry policy to use for operations on this client.</param>
        /// <returns>
        /// A new HDInsight client.
        /// </returns>
        public static IHDInsightClient Connect(IHDInsightSubscriptionCredentials credentials, TimeSpan httpOperationTimeout, IRetryPolicy policy)
        {
            return ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(credentials, httpOperationTimeout, policy);
        }

        /// <inheritdoc />
        public event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;

        /// <inheritdoc />
        public async Task<Collection<string>> ListAvailableLocationsAsync()
        {
            var client = ServiceLocator.Instance.Locate<ILocationFinderClientFactory>().Create(this.credentials, this.Context, this.IgnoreSslErrors);
            return await client.ListAvailableLocations();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<KeyValuePair<string, string>>> ListResourceProviderPropertiesAsync()
        {
            var client = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(this.credentials, this.Context, this.IgnoreSslErrors);
            return await client.GetResourceProviderProperties();
        }

        /// <inheritdoc />
        public async Task<Collection<HDInsightVersion>> ListAvailableVersionsAsync()
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.Context, this.IgnoreSslErrors);
            return await overrideHandlers.VersionFinder.ListAvailableVersions();
        }

        /// <inheritdoc />
        public async Task<ICollection<ClusterDetails>> ListClustersAsync()
        {
            ICollection<ClusterDetails> clustersFromContainersResourceType;

            using (var client = this.CreateContainersPocoClient())
            {
                clustersFromContainersResourceType = await client.ListContainers();
            }

            if (this.canUseClustersContract.Value)
            {
                using (var client = this.CreateClustersPocoClient(this.capabilities.Value))
                {
                    var clustersFromClustersResourceType = await client.ListContainers();
                    return clustersFromClustersResourceType.Concat(clustersFromContainersResourceType).ToList();
                }
            }

            return clustersFromContainersResourceType;
        }

        /// <inheritdoc />
        public async Task<ClusterDetails> GetClusterAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            try
            {
                using (var client = this.CreatePocoClientForDnsName(name))
                {
                    return await client.ListContainer(name);
                }
            }
            catch (HDInsightClusterDoesNotExistException)
            {
                //The semantics of this method is that if a cluster doesn't exist we return null
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<ClusterDetails> GetClusterAsync(string name, string location)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            try
            {
                using (var client = this.CreatePocoClientForDnsName(name))
                {
                    return await client.ListContainer(name, location);
                }
            }
            catch (HDInsightClusterDoesNotExistException)
            {
                //The semantics of this method is that if a cluster doesn't exist we return null
                return null;
            }
        }
        
        /// <inheritdoc />
        public async Task<ClusterDetails> CreateClusterAsync(ClusterCreateParameters clusterCreateParameters)
        {
            if (clusterCreateParameters == null)
            {
                throw new ArgumentNullException("clusterCreateParameters");
            }
            IHDInsightManagementPocoClient client = null;

            if (!this.canUseClustersContract.Value)
            {
                client = this.CreateContainersPocoClient();
            }
            else
            {
                client = this.CreateClustersPocoClient(this.capabilities.Value);
            }

            this.LogMessage("Validating Cluster Versions", Severity.Informational, Verbosity.Detailed);

            await this.ValidateClusterVersion(clusterCreateParameters);

            // listen to cluster provisioning events on the POCO client.
            client.ClusterProvisioning += this.RaiseClusterProvisioningEvent;
            Exception requestException = null;

            // Creates a cluster and waits for it to complete
            try
            {
                this.LogMessage("Sending Cluster Create Request", Severity.Informational, Verbosity.Detailed);
                await client.CreateContainer(clusterCreateParameters);
            }
            catch (Exception ex)
            {
                ex = ex.GetFirstException();
                var hlex = ex as HttpLayerException;
                var httpEx = ex as HttpRequestException;
                var webex = ex as WebException;
                if (hlex.IsNotNull() || httpEx.IsNotNull() || webex.IsNotNull())
                {
                    requestException = ex;
                    if (hlex.IsNotNull())
                    {
                        HandleCreateHttpLayerException(clusterCreateParameters, hlex);
                    }
                }
                else
                {
                    throw;
                }
            }
            await client.WaitForClusterInConditionOrError(this.HandleClusterWaitNotifyEvent,
                                                          clusterCreateParameters.Name,
                                                          clusterCreateParameters.Location,
                                                          clusterCreateParameters.CreateTimeout,
                                                          this.PollingInterval,
                                                          this.Context,
                                                          ClusterState.Operational,
                                                          ClusterState.Running);

            // Validates that cluster didn't get on error state
            var result = this.currentDetails;
            if (result == null)
            {
                if (requestException != null)
                {
                    throw requestException;
                }
                throw new HDInsightClusterCreateException("Attempting to return the newly created cluster returned no cluster.  The cluster could not be found.");
            }
            if (result.Error != null)
            {
                throw new HDInsightClusterCreateException(result);
            }

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "They are not",
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.LogProviderExtensions.LogMessage(Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogProvider,System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)")]
        private bool CanUseClustersContract()
        {
            bool retval = this.capabilities.Value.Contains(ClustersContractCapabilityVersion1);
            this.LogMessage(string.Format(CultureInfo.InvariantCulture, "Clusters resource type is enabled '{0}'", retval), Severity.Critical, Verbosity.Detailed);
            
            return retval;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "They are not",
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.LogProviderExtensions.LogMessage(Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogProvider,System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)")]
        private List<string> GetCapabilities()
        {
            this.LogMessage(string.Format(CultureInfo.InvariantCulture,
                "Fetching resource provider properties for subscription '{0}'.",
                this.credentials.SubscriptionId),
                Severity.Critical,
                Verbosity.Detailed);
            List<KeyValuePair<string, string>> props = this.ListResourceProviderProperties().ToList();
            return props.Select(p => p.Key).ToList();
        }

        private IHDInsightManagementPocoClient CreateClustersPocoClient(List<string> capabilities)
        {
            return new ClustersPocoClient(this.credentials, this.IgnoreSslErrors, this.Context, capabilities);
        }

        private IHDInsightManagementPocoClient CreateContainersPocoClient()
        {
            return ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(this.credentials, this.Context, this.IgnoreSslErrors);
        }

        private IHDInsightManagementPocoClient CreatePocoClientForDnsName(string dnsName)
        {
            if (this.canUseClustersContract.Value)
            {
                var rdfeResourceTypeFinder = ServiceLocator.Instance.Locate<IRdfeResourceTypeFinderFactory>()
                                                           .Create(this.credentials, this.Context, this.IgnoreSslErrors, DefaultSchemaVersion);
                var rdfeResourceType = rdfeResourceTypeFinder.GetResourceTypeForCluster(dnsName).Result;
                switch (rdfeResourceType)
                {
                    case RdfeResourceType.Clusters:
                        return this.CreateClustersPocoClient(this.capabilities.Value);
                    case RdfeResourceType.Containers:
                        return this.CreateContainersPocoClient();
                    default:
                        throw new HDInsightClusterDoesNotExistException(dnsName);
                }
            }
            return this.CreateContainersPocoClient();
        }

        private static void HandleCreateHttpLayerException(ClusterCreateParameters clusterCreateParameters, HttpLayerException e)
        {
            if (e.RequestContent.Contains(ClusterAlreadyExistsError) && e.RequestStatusCode == HttpStatusCode.BadRequest)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cluster {0} already exists.", clusterCreateParameters.Name));
            }
        }

        /// <summary>
        /// Raises the cluster provisioning event.
        /// </summary>
        /// <param name="sender">The IHDInsightManagementPocoClient instance.</param>
        /// <param name="e">EventArgs for the event.</param>
        public void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e)
        {
            var handler = this.ClusterProvisioning;
            if (handler.IsNotNull())
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Used to handle the notification events during waiting.
        /// </summary>
        /// <param name="cluster">
        /// The cluster in its current state.
        /// </param>
        public void HandleClusterWaitNotifyEvent(ClusterDetails cluster)
        {
            if (cluster.IsNotNull())
            {
                this.currentDetails = cluster;
                this.RaiseClusterProvisioningEvent(this, new ClusterProvisioningStatusEventArgs(cluster, cluster.State));
            }
        }

        /// <inheritdoc />
        public async Task DeleteClusterAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            var client = this.CreatePocoClientForDnsName(name);
            await client.DeleteContainer(name);
            await client.WaitForClusterNull(name, TimeSpan.FromMinutes(30), this.PollingInterval, this.Context.CancellationToken);
        }

        /// <inheritdoc />
        public async Task DeleteClusterAsync(string name, string location)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            var client = this.CreatePocoClientForDnsName(name);
            await client.DeleteContainer(name, location);
            await client.WaitForClusterNull(name, location, TimeSpan.FromMinutes(30), this.Context.CancellationToken);
        }

        /// <inheritdoc />
        public async Task EnableHttpAsync(string dnsName, string location, string httpUserName, string httpPassword)
        {
            dnsName.ArgumentNotNullOrEmpty("dnsName");
            location.ArgumentNotNullOrEmpty("location");
            httpUserName.ArgumentNotNullOrEmpty("httpUserName");
            httpPassword.ArgumentNotNullOrEmpty("httpPassword");

            using (var client = this.CreatePocoClientForDnsName(dnsName))
            {
                await this.AssertClusterVersionSupported(dnsName);
                var operationId = await client.EnableHttp(dnsName, location, httpUserName, httpPassword);
                await client.WaitForOperationCompleteOrError(dnsName, location, operationId, TimeSpan.FromHours(1), this.Context.CancellationToken);
            }
        }

        /// <inheritdoc />
        public void DisableHttp(string dnsName, string location)
        {
            this.DisableHttpAsync(dnsName, location).WaitForResult();
        }

        /// <inheritdoc />
        public void EnableHttp(string dnsName, string location, string httpUserName, string httpPassword)
        {
            this.EnableHttpAsync(dnsName, location, httpUserName, httpPassword).WaitForResult();
        }

        /// <inheritdoc />
        public async Task DisableHttpAsync(string dnsName, string location)
        {
            dnsName.ArgumentNotNullOrEmpty("dnsName");
            location.ArgumentNotNullOrEmpty("location");

            using (var client = this.CreatePocoClientForDnsName(dnsName))
            {
                await this.AssertClusterVersionSupported(dnsName);
                var operationId = await client.DisableHttp(dnsName, location);
                await client.WaitForOperationCompleteOrError(dnsName, location, operationId, TimeSpan.FromHours(1), this.Context.CancellationToken);
            }
        }

        /// <inheritdoc />
        public Collection<string> ListAvailableLocations()
        {
            return this.ListAvailableLocationsAsync().WaitForResult();
        }

        /// <inheritdoc />
        public IEnumerable<KeyValuePair<string, string>> ListResourceProviderProperties()
        {
            var client = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(this.credentials, this.Context, this.IgnoreSslErrors);
            return client.GetResourceProviderProperties().WaitForResult();
        }

        /// <inheritdoc />
        public Collection<HDInsightVersion> ListAvailableVersions()
        {
            return this.ListAvailableVersionsAsync().WaitForResult();
        }

        /// <inheritdoc />
        public ICollection<ClusterDetails> ListClusters()
        {
            return this.ListClustersAsync().WaitForResult();
        }

        /// <inheritdoc />
        public ClusterDetails GetCluster(string dnsName)
        {
            return this.GetClusterAsync(dnsName).WaitForResult();
        }

        /// <inheritdoc />
        public ClusterDetails GetCluster(string dnsName, string location)
        {
            return this.GetClusterAsync(dnsName, location).WaitForResult();
        }

        /// <inheritdoc />
        public ClusterDetails CreateCluster(ClusterCreateParameters cluster)
        {
            return this.CreateClusterAsync(cluster).WaitForResult();
        }

        /// <inheritdoc />
        public ClusterDetails CreateCluster(ClusterCreateParameters cluster, TimeSpan timeout)
        {
            return this.CreateClusterAsync(cluster).WaitForResult(timeout);
        }

        /// <inheritdoc />
        public ClusterDetails ChangeClusterSize(string dnsName, string location, int newSize)
        {
            return this.ChangeClusterSizeAsync(dnsName, location, newSize).WaitForResult();
        }

        /// <inheritdoc />
        public ClusterDetails ChangeClusterSize(string dnsName, string location, int newSize, TimeSpan timeout)
        {
            return this.ChangeClusterSizeAsync(dnsName, location, newSize, timeout).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<ClusterDetails> ChangeClusterSizeAsync(string dnsName, string location, int newSize)
        {
            return await ChangeClusterSizeAsync(dnsName, location, newSize, this.defaultResizeTimeout);
        }

        /// <inheritdoc />
        public async Task<ClusterDetails> ChangeClusterSizeAsync(string dnsName, string location, int newSize, TimeSpan timeout)
        {
            dnsName.ArgumentNotNullOrEmpty("dnsName");
            newSize.ArgumentNotNull("newSize");
            location.ArgumentNotNull("location");

            if (!this.canUseClustersContract.Value)
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.CurrentCulture, "This subscription is missing the capability {0} and therefore does not support a change cluster size operation.", ClustersContractCapabilityVersion1));
            }

            if (!this.capabilities.Value.Contains(ClustersContractCapabilityVersion2))
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.CurrentCulture, "This subscription is missing the capability {0} and therefore does not support a change cluster size operation.", ClustersContractCapabilityVersion2));
            }

            var client = this.CreateClustersPocoClient(this.capabilities.Value);

            var operationId = Guid.Empty;
            try
            {
                this.LogMessage("Sending Change Cluster Size request.", Severity.Informational, Verbosity.Detailed);
                operationId = await client.ChangeClusterSize(dnsName, location, newSize);
            }
            catch (Exception ex)
            {
                this.LogMessage(ex.GetFirstException().Message, Severity.Error, Verbosity.Detailed);
                throw ex.GetFirstException();
            }

            if (operationId == Guid.Empty)
            {
                return await client.ListContainer(dnsName);
            }

            await client.WaitForOperationCompleteOrError(dnsName, location, operationId, timeout, this.Context.CancellationToken);
            await client.WaitForClusterInConditionOrError(this.HandleClusterWaitNotifyEvent,
                                                          dnsName,
                                                          location,
                                                          timeout,
                                                          this.PollingInterval,
                                                          this.Context,
                                                          ClusterState.Operational,
                                                          ClusterState.Running);

            this.LogMessage("Validating that the cluster didn't go into an error state.", Severity.Informational, Verbosity.Detailed);
            var result = await client.ListContainer(dnsName);
            if (result == null)
            {
                throw new Exception(string.Format("Cluster {0} could not be found.", dnsName));
            }
            if (result.Error != null)
            {
                this.LogMessage(result.Error.Message, Severity.Informational, Verbosity.Detailed);
                throw new Exception(result.Error.Message);
            }

            return result;
        }

        /// <inheritdoc />
        public void DeleteCluster(string dnsName)
        {
            this.DeleteClusterAsync(dnsName).WaitForResult();
        }

        /// <inheritdoc />
        public void DeleteCluster(string dnsName, TimeSpan timeout)
        {
            this.DeleteClusterAsync(dnsName).WaitForResult(timeout);
        }

        /// <inheritdoc />
        public void DeleteCluster(string dnsName, string location)
        {
            this.DeleteClusterAsync(dnsName, location).WaitForResult();
        }

        /// <inheritdoc />
        public void DeleteCluster(string dnsName, string location, TimeSpan timeout)
        {
            this.DeleteClusterAsync(dnsName, location).WaitForResult(timeout);
        }

        /// <summary>
        /// Encrypt payload string into a base 64-encoded string using the certificate. 
        /// This is suitable for encrypting storage account keys for later use as a job argument.
        /// </summary>
        /// <param name="cert">
        /// Certificate used to encrypt the payload.
        /// </param>
        /// <param name="payload">
        /// Value to encrypt.
        /// </param>
        /// <returns>
        /// Encrypted payload.
        /// </returns>
        public static string EncryptAsBase64String(X509Certificate2 cert, string payload)
        {
            var ci = new ContentInfo(Encoding.UTF8.GetBytes(payload));
            var env = new EnvelopedCms(ci);
            env.Encrypt(new CmsRecipient(cert));
            return Convert.ToBase64String(env.Encode());
        }

        // This method is used by the NonPublic SDK.  Be aware of breaking changes to that project when you alter it.
        private async Task AssertClusterVersionSupported(string dnsName)
        {
            var cluster = await this.GetClusterAsync(dnsName);
            if (cluster == null)
            {
                throw new HDInsightClusterDoesNotExistException(dnsName);
            }

            if (cluster.State == ClusterState.Error)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cluster '{0}' is an error state. Performing operations other than delete are not possible.", dnsName));
            }

            this.AssertSupportedVersion(cluster.VersionNumber);
        }

        private async Task ValidateClusterVersion(ClusterCreateParameters cluster)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.Context, this.IgnoreSslErrors);

            // Validates the version for cluster creation
            if (!string.IsNullOrEmpty(cluster.Version) && !string.Equals(cluster.Version, DEFAULTHDINSIGHTVERSION, StringComparison.OrdinalIgnoreCase))
            {
                this.AssertSupportedVersion(overrideHandlers.PayloadConverter.ConvertStringToVersion(cluster.Version));
                var availableVersions = await overrideHandlers.VersionFinder.ListAvailableVersions();
                if (availableVersions.All(hdinsightVersion => hdinsightVersion.Version != cluster.Version))
                {
                    throw new InvalidOperationException(
                        string.Format(
                            "Cannot create a cluster with version '{0}'. Available Versions for your subscription are: {1}",
                            cluster.Version,
                            string.Join(",", availableVersions)));
                }

                // HBase cluster only supported after version 3.0
                var version = new Version(cluster.Version);
                if (version.CompareTo(new Version("3.0")) < 0 && cluster.ClusterType == ClusterType.HBase)
                {
                    throw new InvalidOperationException(
                        string.Format("Cannot create a HBase cluster with version '{0}'. HBase cluster only supported after version 3.0", cluster.Version));
                }

                // Cluster customization only supported after version 3.0
                if (version.CompareTo(new Version("3.0")) < 0 && cluster.ConfigActions != null && cluster.ConfigActions.Count > 0)
                {
                    throw new InvalidOperationException(
                        string.Format("Cannot create a customized cluster with version '{0}'. Customized clusters only supported after version 3.0", cluster.Version));
                }
            }
            else
            {
                cluster.Version = DEFAULTHDINSIGHTVERSION;
            }
        }

        private void AssertSupportedVersion(Version hdinsightClusterVersion)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.Context, this.IgnoreSslErrors);
            switch (overrideHandlers.VersionFinder.GetVersionStatus(hdinsightClusterVersion))
            {
                case VersionStatus.Obsolete:
                    throw new NotSupportedException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            HDInsightConstants.ClusterVersionTooLowForClusterOperations,
                            hdinsightClusterVersion.ToString(),
                            HDInsightSDKSupportedVersions.MinVersion,
                            HDInsightSDKSupportedVersions.MaxVersion));

                case VersionStatus.ToolsUpgradeRequired:
                    throw new NotSupportedException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            HDInsightConstants.ClusterVersionTooHighForClusterOperations,
                            hdinsightClusterVersion.ToString(),
                            HDInsightSDKSupportedVersions.MinVersion,
                            HDInsightSDKSupportedVersions.MaxVersion));
            }
        }
    }
}

namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.PaasClusters.Extensions;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.YarnApplications;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Networking;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class PayloadConverterClusters
    {
        /// <summary>
        /// Creates the cluster details from rdfe resource output.
        /// </summary>
        /// <param name="cloudServiceRegion">The cloud service region.</param>
        /// <param name="resouceOutput">The resouce output.</param>
        /// <returns>
        /// An instance of ClusterDetails.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown if resourceOutput is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown if cloudService region is null or empty.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.ClusterErrorStatus.#ctor(System.Int32,System.String,System.String)", Justification = "SDK is not localized.")]
        public static ClusterDetails CreateClusterDetailsFromRdfeResourceOutput(string cloudServiceRegion, Resource resouceOutput)
        {
            if (resouceOutput == null)
            {
                throw new ArgumentNullException("resouceOutput");
            }

            if (string.IsNullOrEmpty(cloudServiceRegion))
            {
                throw new ArgumentException("CloudService region cannot be null or empty.");
            }

            string version = SafeGetValueFromOutputItem(resouceOutput.OutputItems, "Version");
            string components = SafeGetValueFromOutputItem(resouceOutput.OutputItems, "ClusterComponents");
            ClusterType clusterType = !string.IsNullOrEmpty(components) ? GetClusterTypeFromComponentList(components) : ClusterType.Unknown;
            
            var clusterDetails = new ClusterDetails
            {
                Name = resouceOutput.Name,
                Version = version,
                StateString = resouceOutput.SubState,
                Location = cloudServiceRegion,
                ClusterType = clusterType,
            };

            if (!string.IsNullOrEmpty(version))
            {
                clusterDetails.VersionStatus = VersionFinderClient.GetVersionStatus(version);
                clusterDetails.VersionNumber = new PayloadConverter().ConvertStringToVersion(version);
            }
            else
            {
                clusterDetails.VersionNumber = new Version(0, 0);
            }

            //Operation status is populated with failed, then let us mark the state as error
            if (resouceOutput.OperationStatus != null && resouceOutput.OperationStatus.Result.Equals("Failed", StringComparison.OrdinalIgnoreCase))
            {
                clusterDetails.State = HDInsight.ClusterState.Error;
                string errorType = resouceOutput.OperationStatus.Type ?? string.Empty;
                clusterDetails.StateString = HDInsight.ClusterState.Error.ToString();
                if (resouceOutput.OperationStatus.Error != null)
                {
                    int httpCode = resouceOutput.OperationStatus.Error.HttpCode;
                    string errorMessage = resouceOutput.OperationStatus.Error.Message ?? string.Empty;
                  
                    clusterDetails.Error = new ClusterErrorStatus(httpCode,
                        errorMessage,
                        errorType);
                }
                else
                {
                    clusterDetails.Error = new ClusterErrorStatus(0, "Unknown error occurred", errorType);
                }
            }
            else
            {
                HDInsight.ClusterState clusterState;
                if (!Enum.TryParse(resouceOutput.SubState, true, out clusterState))
                {
                    clusterState = HDInsight.ClusterState.Unknown;
                }
                clusterDetails.State = clusterState;
            }

            return clusterDetails;
        }

        /// <summary>
        /// Creates the cluster details from get clusters result.
        /// </summary>
        /// <param name="clusterDetailsFromServer">The cluster details from server.</param>
        /// <returns>An instance of ClusterDetails from Cluster.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Complexity is fine.")]
        public static ClusterDetails CreateClusterDetailsFromGetClustersResult(Cluster clusterDetailsFromServer)
        {
            if (clusterDetailsFromServer == null)
            {
                throw new ArgumentNullException("clusterDetailsFromServer");
            }

            ClusterDetails clusterDetails = new ClusterDetails();
            clusterDetails.CreatedDate = clusterDetailsFromServer.CreatedTime;
            clusterDetails.Location = clusterDetailsFromServer.Location;
            clusterDetails.Name = clusterDetailsFromServer.DnsName;
            clusterDetails.Version = clusterDetailsFromServer.Version;
            clusterDetails.StateString = clusterDetailsFromServer.State.ToString();
            clusterDetails.DeploymentId = clusterDetailsFromServer.DeploymentId ?? string.Empty;

            if (!string.IsNullOrEmpty(clusterDetails.Version))
            {
                clusterDetails.VersionNumber = new PayloadConverter().ConvertStringToVersion(clusterDetails.Version);
                clusterDetails.VersionStatus = VersionFinderClient.GetVersionStatus(clusterDetails.Version);
            }
            else
            {
                clusterDetails.VersionNumber = new Version(0, 0);
            }

            string componentListCommaSeperated = clusterDetailsFromServer.Components != null
                                                     ? string.Join(",", clusterDetailsFromServer.Components.Select(c => c.GetType().Name))
                                                     : string.Empty;

            clusterDetails.ClusterType = !string.IsNullOrEmpty(componentListCommaSeperated) 
                                        ? GetClusterTypeFromComponentList(componentListCommaSeperated) 
                                        : ClusterType.Unknown;

            // This code will only execute for PaaS clusters which only support Windows
            clusterDetails.OSType = OSType.Windows;

            if (clusterDetailsFromServer.Error != null)
            {
                //Populate error details with the most recent one. These occur if the deployment workflow errors out
                clusterDetails.Error = new ClusterErrorStatus(
                    (int)clusterDetailsFromServer.Error.StatusCode, clusterDetailsFromServer.Error.ErrorMessage ?? string.Empty, string.Empty);
            }

            //Populate Uri and HttpCreds from the gateway. This should not throw
            //even if the gateway component is null
            PopulateClusterUriAndHttpCredsFromGateway(clusterDetails, clusterDetailsFromServer.Components.OfType<GatewayComponent>().SingleOrDefault());

            //Look for Yarn for 3X clusters
            var yarn = clusterDetailsFromServer.Components.OfType<YarnComponent>().SingleOrDefault();
            //Look for MR for 2X clusters
            var mr = clusterDetailsFromServer.Components.OfType<MapReduceComponent>().SingleOrDefault();

            if (yarn != null)
            {
                clusterDetails.ClusterSizeInNodes = yarn.NodeManagerRole.InstanceCount;
                var mapReduceApplication = yarn.Applications.OfType<MapReduceApplication>().SingleOrDefault();
                if (mapReduceApplication != null)
                {
                    //ToWasbConfiguration returns null if DefaultStorageAccountAndContainer is null
                    clusterDetails.DefaultStorageAccount = mapReduceApplication.DefaultStorageAccountAndContainer.ToWabStorageAccountConfiguration();
                    if (mapReduceApplication.AdditionalStorageContainers != null)
                    {
                        clusterDetails.AdditionalStorageAccounts =
                            mapReduceApplication.AdditionalStorageContainers.Select(s => s.ToWabStorageAccountConfiguration()).ToList();
                    }
                }
            }
            else if (mr != null)
            {
                clusterDetails.ClusterSizeInNodes = mr.WorkerNodeRole.InstanceCount;
                clusterDetails.DefaultStorageAccount = mr.DefaultStorageAccountAndContainer.ToWabStorageAccountConfiguration();
                if (mr.AdditionalStorageAccounts != null)
                {
                    clusterDetails.AdditionalStorageAccounts = mr.AdditionalStorageAccounts.Select(s => s.ToWabStorageAccountConfiguration()).ToList();
                }
            }

            //populate RDP user name. All roles will have the same RDP properties so we pick the first one
            if (clusterDetailsFromServer.ClusterRoleCollection != null &&
                clusterDetailsFromServer.ClusterRoleCollection.Any() &&
                clusterDetailsFromServer.ClusterRoleCollection.First().RemoteDesktopSettings.IsEnabled)
            {
                clusterDetails.RdpUserName =
                    clusterDetailsFromServer.ClusterRoleCollection.First().RemoteDesktopSettings.AuthenticationCredential.Username;
            }

            //populate virtual network info
            VirtualNetworkConfiguration vnetConfigFromServer = clusterDetailsFromServer.VirtualNetworkConfiguration;
            if (vnetConfigFromServer != null && !string.IsNullOrEmpty(vnetConfigFromServer.VirtualNetworkSite))
            {
                clusterDetails.VirtualNetworkId = vnetConfigFromServer.VirtualNetworkSite;
                //Populate the subnet name
                if (vnetConfigFromServer.AddressAssignments != null 
                    && vnetConfigFromServer.AddressAssignments.Any()
                    && vnetConfigFromServer.AddressAssignments.First().Subnets != null
                    && vnetConfigFromServer.AddressAssignments.First().Subnets.First() != null)
                {
                    if (vnetConfigFromServer.AddressAssignments.Any())
                    {
                        clusterDetails.SubnetName = vnetConfigFromServer.AddressAssignments.First().Subnets.First().Name;
                    }
                }
            }
           
            return clusterDetails;
        }

        /// <summary>
        /// Creates the rdfe resource input from wire input.
        /// This method wraps the what is need for the RP within RDFE resource input.
        /// </summary>
        /// <param name="wireCreateParameters">The wire create parameters.</param>
        /// <returns>An RDFE Resource input from wire create parameters.</returns>
        /// <param name="schemaVersion">The schema version for the RDFE resource.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if wireCreateParameters is null.</exception>
        public static RDFEResource CreateRdfeResourceInputFromWireInput(ClusterCreateParameters wireCreateParameters, string schemaVersion)
        {
            if (wireCreateParameters == null)
            {
                throw new ArgumentNullException("wireCreateParameters");
            }

            if (schemaVersion == null)
            {
                throw new ArgumentNullException("schemaVersion");
            }

            var ccpAsXmlString = wireCreateParameters.SerializeAndOptionallyWriteToStream();

            var doc = new XmlDocument();
            using (var stringReader = new StringReader(ccpAsXmlString))
            {
                using (var reader = XmlReader.Create(stringReader))
                {
                    doc.Load(reader);
                }
            }

            var retval = new RDFEResource { SchemaVersion = schemaVersion, IntrinsicSettings = new XmlNode[] { doc.DocumentElement } };
            return retval;
        }

        /// <summary>
        /// Creates the wire contract request from user's cluster create parameters.
        /// </summary>
        /// <param name="cluster">The cluster.</param>
        /// <returns>An Instance of cluster create parameters.</returns>
        public static ClusterCreateParameters CreateWireClusterCreateParametersFromUserType(ClusterCreateParametersV2 cluster)
        {
            if (cluster == null)
            {
                throw new ArgumentNullException("cluster");
            }

            ClusterCreateParameters ccp = null;
            if (cluster.Version.Equals("default", StringComparison.OrdinalIgnoreCase) || new Version(ClusterVersionUtils.TryGetVersionNumber(cluster.Version)).Major >= 3)
            {
                switch (cluster.ClusterType)
                {
                    case ClusterType.HBase:
                        ccp = HDInsightClusterRequestGenerator.Create3XClusterForMapReduceAndHBaseTemplate(cluster);
                        break;
                    case ClusterType.Storm:
                        ccp = HDInsightClusterRequestGenerator.Create3XClusterForMapReduceAndStormTemplate(cluster);
                        break;
                    case ClusterType.Hadoop:
                        ccp = HDInsightClusterRequestGenerator.Create3XClusterFromMapReduceTemplate(cluster);
                        break;
                    case ClusterType.Spark:
                        ccp = HDInsightClusterRequestGenerator.Create3XClusterForMapReduceAndSparkTemplate(cluster);
                        break;
                    default:
                        throw new InvalidDataException(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "Invalid cluster type '{0}' specified for cluster '{1}'",
                                cluster.ClusterType,
                                cluster.Name));
                }
            }
            else
            {
                if (cluster.ClusterType != ClusterType.Hadoop)
                {
                    throw new InvalidDataException(string.Format(CultureInfo.InvariantCulture, "Invalid cluster type '{0}' specified for cluster '{1}'", cluster.ClusterType, cluster.Name));
                }

                ccp = new Version(cluster.Version).Major > 1 ? HDInsightClusterRequestGenerator.Create2XClusterForMapReduceTemplate(cluster)
                                                             : HDInsightClusterRequestGenerator.Create1XClusterForMapReduceTemplate(cluster);
            }

            return ccp;
        }

        private static void PopulateClusterUriAndHttpCredsFromGateway(ClusterDetails clusterDetails, GatewayComponent gateway)
        {
            if (clusterDetails == null)
            {
                throw new ArgumentNullException("clusterDetails");
            }

            if (gateway == null)
            {
                return;
            }

            clusterDetails.ConnectionUrl = gateway.RestUri;
            if (gateway.IsEnabled)
            {
                clusterDetails.HttpUserName = gateway.RestAuthCredential.Username;
                clusterDetails.HttpPassword = gateway.RestAuthCredential.Password;
            }
            else
            {
                clusterDetails.HttpUserName = clusterDetails.HttpPassword = string.Empty;
            }
        }

        private static string SafeGetValueFromOutputItem(IEnumerable<OutputItem> itemlist, string itemKey)
        {
            if (itemlist == null)
            {
                return string.Empty;
            }
            var item = itemlist.SingleOrDefault(o => o.Key.Equals(itemKey, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                return string.Empty;
            }
            return item.Value;
        }

        private static ClusterType GetClusterTypeFromComponentList(string componentList)
        {
            string[] components = componentList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (components.Any(c => c.Equals(typeof(HBaseComponent).Name, StringComparison.OrdinalIgnoreCase)))
            {
                return ClusterType.HBase;
            }
            if (components.Any(c => c.Equals(typeof(StormComponent).Name, StringComparison.OrdinalIgnoreCase)))
            {
                return ClusterType.Storm;
            }
            if (components.Any(c => c.Equals(typeof(SparkComponent).Name, StringComparison.OrdinalIgnoreCase)))
            {
                return ClusterType.Spark;
            }
            return ClusterType.Hadoop;
        }

    }
}

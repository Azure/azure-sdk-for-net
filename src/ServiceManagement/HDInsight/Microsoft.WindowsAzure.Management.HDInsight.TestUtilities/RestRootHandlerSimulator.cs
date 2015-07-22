

namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.PaasClusters;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;

    public class RootHandlerSimulatorController : ApiController
    {
        //Mapping between subscription id and Cluster
        internal static readonly IDictionary<string, List<Cluster>> _clustersAvailable = new Dictionary<string, List<Cluster>>();
        
        [System.Web.Http.Route("~/{subscriptionId}/cloudservices")]
        [HttpGet]
        public HttpResponseMessage ListCloudServicesAsync(string subscriptionId)
        {
            var requestMessage = this.Request;
            var detailLevel = requestMessage.RequestUri.ParseQueryString()["detailLevel"];
            
            List<Cluster> clusters;
            bool subExists = _clustersAvailable.TryGetValue(subscriptionId, out clusters);
            if (!subExists)
            {
                return this.Request.CreateResponse(HttpStatusCode.Accepted, new CloudServiceList());
            }

            var clustersByLocation = clusters.GroupBy(c => c.Location);

            var cloudServiceList = new CloudServiceList();

            foreach (var locationcluster in clustersByLocation)
            {
                var cloudService = new CloudService();
                cloudService.Description = "test description";
                cloudService.GeoRegion = locationcluster.Key;
                cloudService.Label = "test label";
                cloudService.Resources = new ResourceList();
                foreach (Cluster cluster in locationcluster)
                {
                    var resource = new Resource();
                    resource.Name = cluster.DnsName;
                    resource.Type = PaasClustersPocoClient.ClustersResourceType;
                    resource.State = cluster.State.ToString();
                    resource.OutputItems = this.GetOutputItems(cluster);
                    cloudService.Resources.Add(resource);
                }
                cloudServiceList.Add(cloudService);
            }

            return this.Request.CreateResponse(HttpStatusCode.Accepted, cloudServiceList);
        }

        [System.Web.Http.Route("~/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/clusters/{dnsName}")]
        [HttpDelete]
        public HttpResponseMessage DeleteCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName)
        {
            var requestMessage = this.Request;

            List<Cluster> clusters;
            bool subExists = _clustersAvailable.TryGetValue(subscriptionId, out clusters);
            if (!subExists)
            {
                return null;
            }

            var cluster = clusters.SingleOrDefault(c => c.DnsName.Equals(dnsName) && cloudServiceName.Contains(c.Location.Replace(" ", "-")));
            if (cluster != null)
            {
                clusters.Remove(cluster);
                _clustersAvailable[subscriptionId] = clusters;
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [Route("~/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}")]
        [HttpGet]
        public PassthroughResponse GetCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName)
        {
            return new PassthroughResponse { Data = this.GetCluster(dnsName, cloudServiceName, subscriptionId) };
        }

        [Route("~/{subscriptionId}/services")]
        [HttpPut]
        public HttpResponseMessage RegisterSubscriptionIfNotExists(string subscriptionId)
        {
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("~/{subscriptionId}/cloudservices/{cloudServiceName}")]
        [HttpPut]
        public async Task<HttpResponseMessage> PutCloudServiceAsync(string subscriptionId, string cloudServiceName)
        {
            var cloudServiceFromRequest = await this.Request.Content.ReadAsAsync<CloudService>();
            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        [Route("~/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/clusters/{dnsName}")]
        [HttpPut]
        public async Task<HttpResponseMessage> CreateCluster(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName)
        {
            var requestMessage = this.Request;
            var rdfeResource = await requestMessage.Content.ReadAsAsync<RDFEResource>();
            XmlNode node = rdfeResource.IntrinsicSettings[0];

            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();
            stm.Position = 0;
            DataContractSerializer ser = new DataContractSerializer(typeof(ClusterCreateParameters));
            ClusterCreateParameters clusterCreateParams = (ClusterCreateParameters)ser.ReadObject(stm);

            // Spark cluster creation in introduced after schema version 3.0
            if (clusterCreateParams.Components.Any(c => c.GetType() == typeof(SparkComponent)))
            {
                if (!requestMessage.Headers.GetValues("SchemaVersion").Any(v => v.Equals("3.0")))
                {
                    throw new NotSupportedException(ClustersTestConstants.NotSupportedBySubscriptionException);
                }
            }

            var testCluster = new Cluster
            {
                ClusterRoleCollection = clusterCreateParams.ClusterRoleCollection,
                CreatedTime = DateTime.UtcNow,
                Error = null,
                FullyQualifiedDnsName = clusterCreateParams.DnsName,
                State = ClusterState.Running,
                UpdatedTime = DateTime.UtcNow,
                DnsName = clusterCreateParams.DnsName,
                Components = clusterCreateParams.Components,
                ExtensionData = clusterCreateParams.ExtensionData,
                Location = clusterCreateParams.Location,
                Version = ClusterVersionUtils.TryGetVersionNumber(clusterCreateParams.Version),
                VirtualNetworkConfiguration = clusterCreateParams.VirtualNetworkConfiguration
            };

            List<Cluster> clusters;
            bool subExists = _clustersAvailable.TryGetValue(subscriptionId, out clusters);
            if (subExists)
            {
                clusters.Add(testCluster);
                _clustersAvailable[subscriptionId] = clusters;
            }
            else
            {
                _clustersAvailable.Add(
                    new KeyValuePair<string, List<Cluster>>(subscriptionId, new List<Cluster> { testCluster }));
            }

            return this.Request.CreateResponse(HttpStatusCode.Created);
        }


        [Route("~/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}/roles")]
        [HttpPost]
        public async Task<PassthroughResponse> UpdateRole(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName)
        {
            var requestMessage = this.Request;
            if (requestMessage.Headers.GetValues("SchemaVersion").Any(v => v.Equals("1.0")))
            {
                throw new NotSupportedException(ClustersTestConstants.NotSupportedBySubscriptionException);
            }
            ClusterRoleCollection roleCollection = await requestMessage.Content.ReadAsAsync<ClusterRoleCollection>();
            var actionValue = requestMessage.RequestUri.ParseQueryString()["action"];
            PassthroughResponse response;
            //If no action is specified then RP defaults to Enable Rdp action.
            if (string.IsNullOrEmpty(actionValue))
            {
                this.EnableRdp(roleCollection, subscriptionId, cloudServiceName, dnsName);
            }

            switch (actionValue.ToLowerInvariant())
            {
                case "resize":
                    response = this.ResizeCluster(roleCollection, subscriptionId, cloudServiceName, dnsName);
                    break;
                case "enablerdp":
                    response = this.EnableDisableRdp(roleCollection, subscriptionId, cloudServiceName, dnsName);
                    break;
                default:
                    throw new NotSupportedException(string.Format(ClustersTestConstants.NotSupportedAction,
                        actionValue));
            }
            return response;
        }

        private PassthroughResponse EnableDisableRdp(ClusterRoleCollection roleCollection, string subscriptionId,
            string cloudServiceName, string dnsName)
        {
            Assert.IsNotNull(roleCollection);
            Assert.IsTrue(roleCollection.Count > 0);
            var firstRole = roleCollection.FirstOrDefault();
            Assert.IsNotNull(firstRole);
            Assert.IsNotNull(firstRole.RemoteDesktopSettings);
            if (firstRole.RemoteDesktopSettings.IsEnabled)
            {
                return this.EnableRdp(roleCollection, subscriptionId, cloudServiceName, dnsName);
            }
            else
            {
                return this.DisableRdp(roleCollection, subscriptionId, cloudServiceName, dnsName);
            }
        }

        private PassthroughResponse ResizeCluster(ClusterRoleCollection roleCollection, string subscriptionId,
            string cloudServiceName, string dnsName)
        {
            var workerNode = roleCollection.SingleOrDefault(role => role.FriendlyName.Equals("WorkerNodeRole"));
            if (workerNode == null)
            {
                throw new NullReferenceException(ClustersTestConstants.NoDataNodeException);
            }

            int instanceCount = workerNode.InstanceCount;
            var cluster = this.GetCluster(dnsName, cloudServiceName, subscriptionId);
            if (cluster == null)
            {
                throw new ArgumentNullException(string.Format(ClustersTestConstants.ClusterDoesNotExistException, dnsName, subscriptionId));
            }

            var clusterWorkerRole = cluster.ClusterRoleCollection.SingleOrDefault(role => role.FriendlyName.Equals("WorkerNodeRole"));
            if (clusterWorkerRole == null)
            {
                throw new NullReferenceException(ClustersTestConstants.NoDataNodeException);
            }
            clusterWorkerRole.InstanceCount = instanceCount;

            return new PassthroughResponse { Data = new Contracts.May2014.Operation { OperationId = Guid.NewGuid().ToString(), Status = Contracts.May2014.OperationStatus.InProgress, } };
        }

        private PassthroughResponse EnableRdp(ClusterRoleCollection roleCollection, string subscriptionId,
            string cloudServiceName, string dnsName)
        {
            Assert.IsNotNull(roleCollection, "Role collection is null");
            Assert.IsTrue(roleCollection.Count > 0, "There are no roles in the role collection");
            var cluster = this.GetCluster(dnsName, cloudServiceName, subscriptionId);
            if (cluster == null)
            {
                throw new ArgumentNullException(string.Format(ClustersTestConstants.ClusterDoesNotExistException, dnsName, subscriptionId));
            }
            ClusterRole previousRole = null;
            foreach (var role in roleCollection)
            {
                Assert.IsNotNull(role,"The role is null");
                Assert.IsTrue(role.RemoteDesktopSettings.IsEnabled);
                if (previousRole != null)
                {
                    Assert.IsTrue(
                        previousRole.RemoteDesktopSettings.AuthenticationCredential.Username ==
                        role.RemoteDesktopSettings.AuthenticationCredential.Username,
                        "rdpUsername between roles doesn't match");
                    Assert.IsTrue(
                        previousRole.RemoteDesktopSettings.AuthenticationCredential.Password ==
                        role.RemoteDesktopSettings.AuthenticationCredential.Password,
                        "rdpPassword between roles doesn't match");
                    Assert.IsTrue(previousRole.RemoteDesktopSettings.RemoteAccessExpiry ==
                                  role.RemoteDesktopSettings.RemoteAccessExpiry,
                        "RemoteAccessExpory between roles doesn't match");
                }
                else
                {
                    Assert.IsNotNull(role.RemoteDesktopSettings.AuthenticationCredential.Username,
                        "rdpUsername is null");
                    Assert.IsNotNull(role.RemoteDesktopSettings.AuthenticationCredential.Password,
                        "rdpPassword is null");
                    Assert.IsNotNull(role.RemoteDesktopSettings.RemoteAccessExpiry,
                        "RemoteAccessExpory is numm");
                }
                previousRole = role;
            }

            cluster.ClusterRoleCollection = roleCollection;
            return new PassthroughResponse { Data = new Contracts.May2014.Operation { OperationId = Guid.NewGuid().ToString(), Status = Contracts.May2014.OperationStatus.InProgress, } };
        }

        private PassthroughResponse DisableRdp(ClusterRoleCollection roleCollection, string subscriptionId,
            string cloudServiceName, string dnsName)
        {
            var cluster = this.GetCluster(dnsName, cloudServiceName, subscriptionId);
            if (cluster == null)
            {
                throw new ArgumentNullException(string.Format(ClustersTestConstants.ClusterDoesNotExistException, dnsName, subscriptionId));
            }
            cluster.ClusterRoleCollection = roleCollection;
            return new PassthroughResponse { Data = new Contracts.May2014.Operation { OperationId = Guid.NewGuid().ToString(), Status = Contracts.May2014.OperationStatus.InProgress, } };
        }

        private Cluster GetCluster(string dnsName, string cloudserviceName, string subscriptionId)
        {
            List<Cluster> clusters;
            bool subExists = _clustersAvailable.TryGetValue(subscriptionId, out clusters);
            if (!subExists)
            {
                return null;
            }

            var cluster = clusters.SingleOrDefault(c => c.DnsName.Equals(dnsName) && cloudserviceName.Contains(c.Location.Replace(" ", "-")));
            if (cluster == null)
            {
                return null;
            }

            return cluster;
        }

        private OutputItemList GetOutputItems(Cluster cluster)
        {
            var oi = new OutputItemList();

            var version = new OutputItem();
            version.Key = "Version";
            version.Value = cluster.Version;
            oi.Add(version);

            var components = new OutputItem();
            components.Key = "ClusterComponents";
            components.Value = this.GetClusterComponents(cluster);
            oi.Add(components);

            return oi;
        }

        private string GetClusterComponents(Cluster cluster)
        {
            return string.Join(",", cluster.Components.Select(c => c.GetType().Name));
        }
    }
}

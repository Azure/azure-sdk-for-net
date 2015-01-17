namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;

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
                    resource.Type = ClustersPocoClient.ClustersResourceType;
                    resource.State = cluster.State.ToString();
                    resource.OutputItems = this.GetOutputItems(cluster);
                    cloudService.Resources.Add(resource);
                }
                cloudServiceList.Add(cloudService);
            }

            return this.Request.CreateResponse(HttpStatusCode.Accepted, cloudServiceList);;
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

        [Route("~/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceNamespace}/~/clusters/{dnsName}/roles")]
        [HttpPost]
        public async Task<PassthroughResponse> ChangeClusterSize(string subscriptionId, string cloudServiceName, string resourceNamespace, string dnsName)
        {
            var requestMessage = this.Request;
            var actionValue = requestMessage.RequestUri.ParseQueryString()["action"];
            if (!requestMessage.Headers.GetValues("SchemaVersion").Any(v => v.Equals("2.0")))
            {
                throw new NotSupportedException(ClustersTestConstants.NotSupportedBySubscriptionException);
            }
            ClusterRoleCollection roleCollection = await requestMessage.Content.ReadAsAsync<ClusterRoleCollection>();

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

            return new PassthroughResponse { Data = new Operation { OperationId = Guid.NewGuid().ToString(), Status = OperationStatus.InProgress, } };
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

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClustersTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.PaasClusters;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test class. Disposing in the tear off method.")]
    [DeploymentItem(@"creds\creds.xml", @"creds\")]
    [DeploymentItem(@"creds\certs\invalid.cer", @"creds\certs")]
    [DeploymentItem(@"creds\certs\emrcert.cer", @"creds\certs")]
    [DeploymentItem(@"creds\certs\sdkcli.cer", @"creds\certs")]
    public class ClustersTestsBase
    {
        internal static string TestSubscription =
            new IntegrationTestManager().GetCredentials("default").SubscriptionId.ToString(); 
        internal HttpServer DefaultHandler;
        internal HDInsightCertificateCredential HdInsightCertCred;
        internal readonly X509Certificate2 Certificate = new X509Certificate2(@"creds\certs\sdkcli.cer");
        internal HDInsightSubscriptionAbstractionContext Context;
        internal static List<string> Capabilities = new List<string>();
    
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Test class.")]
        public virtual void TestInitialize()
        {
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK");

            this.DefaultHandler = this.GetDefaultHandler();
            this.HdInsightCertCred = new HDInsightCertificateCredential(Guid.Parse(TestSubscription), Certificate);
            this.Context = new HDInsightSubscriptionAbstractionContext(this.HdInsightCertCred, new CancellationTokenSource().Token);
        }

        public virtual void TestCleanup()
        {
            RootHandlerSimulatorController._clustersAvailable.Clear();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Test class.")]
        private HttpServer GetDefaultHandler()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            return new HttpServer(config);
        }

        internal void CreateCluster(string dnsName, string location)
        {
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = dnsName,
                DefaultStorageAccountKey = "storageaccountkey",
                DefaultStorageAccountName = "teststorage",
                ClusterSizeInNodes = 2,
                Location = location,
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.1"
            };

            var testCluster = CreateClusterFromCreateParameters(clusterCreateParameters);
            testCluster.ClusterCapabilities = new List<string> { PaasClustersPocoClient.ResizeCapabilityEnabled };

            List<Cluster> clusters;
            bool subExists = RootHandlerSimulatorController._clustersAvailable.TryGetValue(TestSubscription, out clusters);
            if (subExists)
            {
                clusters.Add(testCluster);
                RootHandlerSimulatorController._clustersAvailable[TestSubscription] = clusters;
            }
            else
            {
                RootHandlerSimulatorController._clustersAvailable.Add(
                    new KeyValuePair<string, List<Cluster>>(TestSubscription, new List<Cluster> { testCluster }));
            }
        }

        internal void CreateClusterWithoutCapability(string dnsName, string location)
        {
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = dnsName,
                DefaultStorageAccountKey = "storageaccountkey",
                DefaultStorageAccountName = "teststorage",
                ClusterSizeInNodes = 2,
                Location = location,
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.1"
            };
            var testCluster = CreateClusterFromCreateParameters(clusterCreateParameters);

            List<Cluster> clusters;
            bool subExists = RootHandlerSimulatorController._clustersAvailable.TryGetValue(TestSubscription, out clusters);
            if (subExists)
            {
                clusters.Add(testCluster);
                RootHandlerSimulatorController._clustersAvailable[TestSubscription] = clusters;
            }
            else
            {
                RootHandlerSimulatorController._clustersAvailable.Add(
                    new KeyValuePair<string, List<Cluster>>(TestSubscription, new List<Cluster> { testCluster }));
            }
        }

        private static Cluster CreateClusterFromCreateParameters(HDInsight.ClusterCreateParametersV2 clusterCreateParameters)
        {
            var clusterCreateParams = HDInsightClusterRequestGenerator.Create3XClusterFromMapReduceTemplate(clusterCreateParameters);
            var cluster = new Cluster
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
                Version = clusterCreateParams.Version,
                VirtualNetworkConfiguration = clusterCreateParams.VirtualNetworkConfiguration
            };
            return cluster;
        }
    }
}

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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.YarnApplications;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;
    using Microsoft.WindowsAzure.Management.Configuration.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;

    /// <summary>
    /// Provides a simulator for HDInsight REST calls. This allows efficient local testing of
    /// the SDK using the simulator instead of talking to an actual running service.
    /// Testing against the actual service is reserved for more expensive and less frequent
    /// scenario tests.
    /// </summary>
    internal class HDInsightManagementRestSimulatorClient : IHDInsightManagementRestClient
    {
        public static int OperationTimeToCompletionInMilliseconds = 0;
        private const string defaultVersion = "default";
        private readonly HDInsight.IAbstractionContext context;
        
        private static List<string> nonOverridableConfigurationProperties = new List<string>()
        {
            "fs.default.name",
            "topology.script.file.name",
            "dfs.namenode.rpc-address",
            "fs.checkpoint.dir",
            "fs.checkpoint.edits.dir",
            "dfs.name.dir",
            "dfs.data.dir",
            "dfs.http.address",
            "dfs.datanode.address",
            "dfs.datanode.http.address",
            "dfs.datanode.ipc.address",
            "dfs.secondary.http.address",
            "dfs.secondary.https.port",
            "mapred.jobDetails.tracker",
            "mapred.local.dir",
            "mapred.jobDetails.tracker.http.address",
            "mapreduce.history.server.http.address",
            "mapreduce.jobtracker.staging.root.dir",
            "hive.querylog.location",
            "hive.metastore.uris",
            "hive.hwi.listen.host",
            "hive.hwi.listen.port",
            "hive.exec.scratchdir",
            "hive.server2.thrift.port",
            "oozie.service.JPAService.validate.db.connection",
            "oozie.service.JPAService.create.db.schema" 
        };

        internal class SimulatorClusterContainer
        {
            private IDictionary<string, JobDetails> jobQueue;

            private IDictionary<string, DateTime> markedForDeletionJobs;

            public ClusterDetails Cluster { get; set; }
            public PendingOp HttpPendingOp { get; set; }
            public PendingOp RdpPendingOp { get; set; }


            public IDictionary<string, DateTime> JobDeletionQueue
            {
                get { return this.markedForDeletionJobs; }
            }

            public IDictionary<string, JobDetails> JobQueue
            {
                get
                {
                    if (!string.IsNullOrEmpty(this.Cluster.HttpUserName))
                    {
                        return this.jobQueue;
                    }

                    throw new UnauthorizedAccessException();
                }
            }

            public AzureHDInsightClusterConfiguration Configuration { get; internal set; }

            public SimulatorClusterContainer()
            {
                this.jobQueue = new Dictionary<string, JobDetails>();
                this.markedForDeletionJobs = new Dictionary<string, DateTime>();
            }
        }

        private static readonly Dictionary<Guid, PendingOp> ProcessingOps = new Dictionary<Guid, PendingOp>();

        internal class PendingOp
        {
            public PendingOp(UserChangeOperationStatusResponse response)
            {
                this.Response = response;
                this.Id = Guid.NewGuid();
            }

            public Guid Id { get; private set; }
            public UserChangeOperationStatusResponse Response { get; private set; }
        }

        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly IDictionary<string, X509Certificate2> certificates = new Dictionary<string, X509Certificate2>();
        private readonly List<Guid> subscriptions = new List<Guid>();

        private readonly IList<string> SupportedConnectivityClusterVersions = new List<string> { "1.6.0.0.LargeSKU-amd64-134231", "1.6", "2.0", "2.1", "3.0", "3.1", "default" };

        // List of Clusters stored.
        // Includes the expected 'tsthdx00hdxcibld02' cluster
        private static readonly Collection<SimulatorClusterContainer> Clusters = new Collection<SimulatorClusterContainer>()
        { 
            new SimulatorClusterContainer()
            {
                Cluster =
                    new ClusterDetails("VersionLowerThanSupported", HDInsight.ClusterState.Running.ToString())
                {
                ConnectionUrl = @"https://VersionLowerThanSupported.azurehdinsight.net",
                CreatedDate = DateTime.UtcNow,
                Location = "East US 2",
                Error = null,
                        Version =
                            new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1).ToString(),
                        VersionNumber =
                            new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1),
                    HttpUserName = "sa-po-svc",
                ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)  
            }
            },
            new SimulatorClusterContainer()
            {
                Cluster =
                    new ClusterDetails("VersionHigherThanSupported", HDInsight.ClusterState.Running.ToString())
                {
                ConnectionUrl = @"https://VersionHigherThanSupported.azurehdinsight.net",
                CreatedDate = DateTime.UtcNow,
                Location = "East US 2",
                Error = null,
                        Version =
                            new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor + 1).ToString(),
                        VersionNumber =
                            new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor + 1),
                HttpUserName = "sa-po-svc",
                ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)  
            }
            },
            new SimulatorClusterContainer()
            {
                Cluster =
                    new ClusterDetails(
                        IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName, HDInsight.ClusterState.Running.ToString())
                {
                ConnectionUrl = @"https://" + IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName + ".azurehdinsight.net",
                CreatedDate = DateTime.UtcNow,
                Location = "East US 2",
                Error = null,
                Version = IntegrationTestBase.TestCredentials.WellKnownCluster.Version,
                VersionNumber = new PayloadConverter().ConvertStringToVersion(IntegrationTestBase.TestCredentials.WellKnownCluster.Version),
                    HttpUserName =IntegrationTestBase.TestCredentials.AzureUserName,
                    HttpPassword = IntegrationTestBase.TestCredentials.AzurePassword,
                ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)  
            },
            Configuration = GetWellknownClusterConfiguration()
            }
        };

        private static AzureHDInsightClusterConfiguration GetWellknownClusterConfiguration()
        {
            var config = new AzureHDInsightClusterConfiguration();
            config.Core.AddRange(
                new List<KeyValuePair<string, string>>()
            {
                    new KeyValuePair<string, string>("fs.default.name", Hadoop.Client.Constants.WabsProtocolSchemeName + "apitestclusterrdfe19-laureny@hdicurrenteastus.blob.core.windows.net"),
                    new KeyValuePair<string, string>("hadoop.tmp.dir", "/hdfs/tmp"),
                    new KeyValuePair<string, string>("fs.trash.interval", "60"),
                    new KeyValuePair<string, string>("fs.checkpoint.dir", "c:\\hdfs\\2nn"),
                    new KeyValuePair<string, string>("fs.checkpoint.edits.dir", "c:\\hdfs\\2nn"),
                    new KeyValuePair<string, string>("fs.checkpoint.period", "1800"),
                    new KeyValuePair<string, string>("fs.checkpoint.size", "67108864"),
                    new KeyValuePair<string, string>("fs.azure.selfthrottling.write.factor", "1.000000"),
                    new KeyValuePair<string, string>("fs.azure.buffer.dir", "/tmp"),
                    new KeyValuePair<string, string>("topology.script.file.name", "E:\\approot\\bin\\AzureTopology.exe"),
                    new KeyValuePair<string, string>("io.file.buffer.size", "131072"),
                    new KeyValuePair<string, string>("hadoop.proxyuser.hdp.groups", "oozieusers"),
                    new KeyValuePair<string, string>("dfs.namenode.rpc-address", "hdfs://namenodehost:9000"),
                    new KeyValuePair<string, string>("slave.host.name", ""),
                    new KeyValuePair<string, string>("hadoop.proxyuser.hdp.hosts", "headnodehost"),
                    new KeyValuePair<string, string>("fs.azure.selfthrottling.read.factor", "1.000000"),
                    new KeyValuePair<string, string>(
                    "fs.azure.account.key.hdicurrenteastus.blob.core.windows.net",
                    "jKe7cqoU0a9OmDFlwi3DHZLf7JoKwGOU2pV1iZdBKifxwQuDOKwZFyXMJrPSLtGgDV9b7pVKSGz6lbBWcfX2lA==")
                });

            config.Hive.AddRange(
                new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("hive.metastore.uris", "thrift://headnodehost:9083"),
                    new KeyValuePair<string, string>("hive.metastore.connect.retries", "5"),
                    new KeyValuePair<string, string>("hive.metastore.ds.retry.attempts", "0"),
                    new KeyValuePair<string, string>("hive.metastore.ds.retry.interval", "1000"),
                    new KeyValuePair<string, string>("hive.hmshandler.retry.attempts", "5"),
                    new KeyValuePair<string, string>("hive.hmshandler.retry.interval", "1000"),
                    new KeyValuePair<string, string>(
                    "javax.jdo.option.ConnectionURL",
                    "jdbc:sqlserver://e87d4x221e.database.windows.net:1433;database=v0200cde0587f58a84e86acfd0a0fd8527bf0hivemetastore;encrypt=true;trustServerCertificate=true;create=false"),
                    new KeyValuePair<string, string>("javax.jdo.option.ConnectionDriverName", "com.microsoft.sqlserver.jdbc.SQLServerDriver"),
                    new KeyValuePair<string, string>("hive.metastore.warehouse.dir", "/hive/warehouse"),
                    new KeyValuePair<string, string>("hive.hwi.listen.host", "0.0.0.0"),
                    new KeyValuePair<string, string>("hive.hwi.listen.port", "9999"),
                    new KeyValuePair<string, string>("hive.hwi.war.file", "lib\\hive-hwi-0.11.0.1.3.0.1-0285.war"),
                    new KeyValuePair<string, string>("hive.server2.servermode", "http"),
                    new KeyValuePair<string, string>("hive.server2.thrift.port", "10001"),
                    new KeyValuePair<string, string>("hive.server2.http.port", "10001"),
                    new KeyValuePair<string, string>("hive.server2.http.min.worker.threads", "5"),
                    new KeyValuePair<string, string>("hive.server2.http.max.worker.threads", "100"),
                    new KeyValuePair<string, string>("hive.server2.enable.doAs", "false"),
                    new KeyValuePair<string, string>("hive.querylog.location", "c:\\apps\\dist\\hive-0.11.0.1.3.0.1-0285\\logs"),
                    new KeyValuePair<string, string>("hive.log.dir", "c:\\apps\\dist\\hive-0.11.0.1.3.0.1-0285\\logs"),
                    new KeyValuePair<string, string>("hive.metastore.local", "false"),
                    new KeyValuePair<string, string>(
                    "javax.jdo.option.ConnectionPassword",
                    "XVpH9dekDCOC6GkQ3Fvf1KL3SwuUo7XRPV5Xd230LQ1PPQYXWuMBrnDoLKxWeOAqhR2TFKQrXSL6ERch73iU1wTBonbqAVyYKGbZs55w45uqq1"),
                    new KeyValuePair<string, string>("hive.stats.autogather", "false"),
                    new KeyValuePair<string, string>("hive.metastore.client.socket.timeout", "60"),
                    new KeyValuePair<string, string>("hive.exec.scratchdir", "hdfs://namenodehost:9000/hive/scratch"),
                    new KeyValuePair<string, string>(
                    "javax.jdo.option.ConnectionUserName", "v0200cde0587f58a84e86acfd0a0fd8527bf0hivemetastoreLogin@e87d4x221e")
                });

            config.MapReduce.AddRange(
                (new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("mapred.system.dir", "hdfs://namenodehost:9000/mapred/system"),
                    new KeyValuePair<string, string>("mapred.jobDetails.tracker", "jobtrackerhost:9010"),
                    new KeyValuePair<string, string>("mapred.jobtracker.taskScheduler", "org.apache.hadoop.mapred.CapacityTaskScheduler"),
                    new KeyValuePair<string, string>("mapred.jobDetails.tracker.http.address", "jobtrackerhost:50030"),
                    new KeyValuePair<string, string>("mapreduce.fileoutputcommitter.marksuccessfuljobs", "false"),
                    new KeyValuePair<string, string>("mapreduce.jobtracker.staging.root.dir", "hdfs://namenodehost:9000/mapred/staging"),
                    new KeyValuePair<string, string>("mapred.jobDetails.tracker.history.completed.location", "/mapred/history/done"),
                    new KeyValuePair<string, string>("mapreduce.history.server.embedded", "true"),
                    new KeyValuePair<string, string>("mapreduce.history.server.http.address", "0.0.0.0:51111"),
                    new KeyValuePair<string, string>("mapred.queue.names", "default,joblauncher"),
                    new KeyValuePair<string, string>("mapred.child.java.opts", "-Xms512m -Xmx1024m"),
                    new KeyValuePair<string, string>("mapred.reduce.child.java.opts", "-Xms512m -Xmx2048m"),
                    new KeyValuePair<string, string>("mapred.tasktracker.reduce.tasks.maximum", "2"),
                    new KeyValuePair<string, string>("hadoop.jobDetails.history.user.location", "hdfs://namenodehost:9000/mapred/userhistory"),
                    new KeyValuePair<string, string>("mapreduce.reduce.shuffle.read.timeout", "600000"),
                    new KeyValuePair<string, string>("mapreduce.reduce.shuffle.connect.timeout", "600000"),
                    new KeyValuePair<string, string>("mapred.map.child.java.opts", "-Xms512m -Xmx1024m"),
                    new KeyValuePair<string, string>("mapred.reduce.max.attempts", "8"),
                    new KeyValuePair<string, string>("mapreduce.client.accessible.remote.schemes", Hadoop.Client.Constants.WabsProtocol),
                    new KeyValuePair<string, string>("mapred.max.split.size", "536870912"),
                    new KeyValuePair<string, string>("mapred.map.max.attempts", "8"),
                    new KeyValuePair<string, string>("mapred.task.timeout", "600000"),
                    new KeyValuePair<string, string>("mapred.tasktracker.map.tasks.maximum", "4"),
                    new KeyValuePair<string, string>("mapreduce.input.fileinputformat.split.maxsize", "536870912"),
                    new KeyValuePair<string, string>("mapreduce.client.tasklog.timeout", "600000"),
                    new KeyValuePair<string, string>("mapred.max.tracker.failures", "8"),
                    new KeyValuePair<string, string>("mapred.local.dir", "c:\\hdfs\\mapred\\local")
                }));

            config.Oozie.AddRange(
                new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>(
                    "oozie.service.ActionService.executor.ext.classes",
                    "\n            org.apache.oozie.action.email.EmailActionExecutor,\n            org.apache.oozie.action.hadoop.HiveActionExecutor,\n            org.apache.oozie.action.hadoop.ShellActionExecutor,\n            org.apache.oozie.action.hadoop.Sqoop_ActionExecutor,\n            org.apache.oozie.action.hadoop.DistcpActionExecutor\n        "),
                    new KeyValuePair<string, string>(
                    "oozie.service.SchemaService.wf.ext.schemas",
                    "shell-action-0.1.xsd,shell-action-0.2.xsd,email-action-0.1.xsd,hive-action-0.2.xsd,hive-action-0.3.xsd,Sqoop_-action-0.2.xsd,Sqoop_-action-0.3.xsd,ssh-action-0.1.xsd,distcp-action-0.1.xsd"),
                    new KeyValuePair<string, string>("oozie.system.id", "oozie-${user.name}"),
                    new KeyValuePair<string, string>("oozie.systemmode", "NORMAL"),
                    new KeyValuePair<string, string>("oozie.service.AuthorizationService.security.enabled", "true"),
                    new KeyValuePair<string, string>("oozie.service.PurgeService.older.than", "30"),
                    new KeyValuePair<string, string>("oozie.service.PurgeService.purge.interval", "3600"),
                    new KeyValuePair<string, string>("oozie.service.CallableQueueService.queue.size", "10000"),
                    new KeyValuePair<string, string>("oozie.service.CallableQueueService.threads", "10"),
                    new KeyValuePair<string, string>("oozie.service.CallableQueueService.callable.concurrency", "3"),
                    new KeyValuePair<string, string>("oozie.service.coord.normal.default.timeout\n\t\t", "120"),
                    new KeyValuePair<string, string>("oozie.db.schema.name", "oozie"),
                    new KeyValuePair<string, string>("oozie.service.JPAService.create.db.schema", "false"),
                    new KeyValuePair<string, string>("oozie.service.JPAService.jdbc.driver", "com.microsoft.sqlserver.jdbc.SQLServerDriver"),
                    new KeyValuePair<string, string>(
                    "oozie.service.JPAService.jdbc.url",
                    "jdbc:sqlserver://e87d4x221e.database.windows.net:1433;database=v0200cde0587f58a84e86acfd0a0fd8527bf0ooziemetastore;sendStringParametersAsUnicode=false;prepareSQL=0"),
                    new KeyValuePair<string, string>(
                    "oozie.service.JPAService.jdbc.username", "v0200cde0587f58a84e86acfd0a0fd8527bf0ooziemetastoreLogin@e87d4x221e"),
                    new KeyValuePair<string, string>(
                    "oozie.service.JPAService.jdbc.password",
                    "EX5M8nGYh9Vho8dL3ul2UMhcyFH8kcB9o6YJ6CsqvoBujch5yGF1qCeNvYYXEgn4RK5aCfrKwPNtR6bBAWHCowgahkU4wYfV2pKhrtJVQpOCeZ"),
                    new KeyValuePair<string, string>("oozie.service.JPAService.pool.max.active.conn", "10"),
                    new KeyValuePair<string, string>("oozie.service.HadoopAccessorService.kerberos.enabled", "false"),
                    new KeyValuePair<string, string>("local.realm", "LOCALHOST"),
                    new KeyValuePair<string, string>("oozie.service.HadoopAccessorService.keytab.file", "${user.home}/oozie.keytab"),
                    new KeyValuePair<string, string>(
                    "oozie.service.HadoopAccessorService.kerberos.principal", "${user.name}/localhost@${local.realm}"),
                    new KeyValuePair<string, string>("oozie.service.HadoopAccessorService.jobTracker.whitelist", ""),
                    new KeyValuePair<string, string>("oozie.service.HadoopAccessorService.nameNode.whitelist", ""),
                    new KeyValuePair<string, string>("oozie.service.HadoopAccessorService.hadoop.configurations", "*=hadoop-conf"),
                    new KeyValuePair<string, string>("oozie.service.WorkflowAppService.system.libpath", "/user/${user.name}/share/lib"),
                    new KeyValuePair<string, string>("use.system.libpath.for.mapreduce.and.pig.jobs", "false"),
                    new KeyValuePair<string, string>("oozie.authentication.changeType", "simple"),
                    new KeyValuePair<string, string>("oozie.authentication.token.validity", "36000"),
                    new KeyValuePair<string, string>("oozie.authentication.signature.secret", "oozie"),
                    new KeyValuePair<string, string>("oozie.authentication.cookie.domain", ""),
                    new KeyValuePair<string, string>("oozie.authentication.simple.anonymous.allowed", "true"),
                    new KeyValuePair<string, string>("oozie.authentication.kerberos.principal", "HTTP/localhost@${local.realm}"),
                    new KeyValuePair<string, string>("oozie.authentication.kerberos.keytab", "${oozie.service.HadoopAccessorService.keytab.file}"),
                    new KeyValuePair<string, string>("oozie.authentication.kerberos.name.rules", "DEFAULT"),
                    new KeyValuePair<string, string>("oozie.service.JPAService.validate.db.connection.eviction.interval", "45000"),
                    new KeyValuePair<string, string>("oozie.service.JPAService.validate.db.connection", "true"),
                    new KeyValuePair<string, string>("oozie.service.JPAService.validate.db.connection.eviction.num", "10")
                });

            return config;
        }

        internal static void ResetConnectivityDefaultsAllClusters()
        {
            lock (Clusters)
            {
                foreach (var cluster in Clusters)
                {
                    // if http connectivity is disabled, enable it
                    if (String.IsNullOrEmpty(cluster.Cluster.HttpUserName))
                    {
                        cluster.Cluster.HttpUserName = IntegrationTestBase.TestCredentials.AzureUserName;
                        cluster.Cluster.HttpPassword = IntegrationTestBase.TestCredentials.AzurePassword;
                    }

                    // if rdp connectivity is enabled, disable it
                    if (!String.IsNullOrEmpty(cluster.Cluster.RdpUserName))
                    {
                        cluster.Cluster.RdpUserName = string.Empty;
                    }

                    cluster.HttpPendingOp = null;
                    cluster.RdpPendingOp = null;

                }
                OperationTimeToCompletionInMilliseconds = 0;
            }
        }

        public HDInsightManagementRestSimulatorClient(IHDInsightSubscriptionCredentials credentials, HDInsight.IAbstractionContext context)
        {
            this.context = context;
            var cert = new X509Certificate2(IntegrationTestBase.TestCredentials.Certificate);
            this.certificates.Add(cert.Thumbprint, cert);
            this.subscriptions.Add(IntegrationTestBase.TestCredentials.SubscriptionId);
            this.credentials = credentials;
            this.Logger = new Logger();
        }

        internal static SimulatorClusterContainer GetCloudServiceInternal(string name)
        {
            return ListCloudServicesInternal().FirstOrDefault(c => c.Cluster.Name.Equals(name, StringComparison.Ordinal));
        }

        private static ICollection<SimulatorClusterContainer> ListCloudServicesInternal()
        {
            lock (Clusters)
            {
                // Advances the state of the clusters. Uses tempList to mark clusters for deletion
                var tempList = new Collection<SimulatorClusterContainer>();
                foreach (var cluster in Clusters)
                {
                    switch (cluster.Cluster.State)
                    {
                        case HDInsight.ClusterState.ReadyForDeployment:
                            cluster.Cluster.CreatedDate = DateTime.UtcNow;
                            cluster.Cluster.ChangeState(
                                cluster.Cluster.Error == null
                                                ? HDInsight.ClusterState.Accepted
                                                : HDInsight.ClusterState.Unknown);
                            break;
                        case HDInsight.ClusterState.Accepted:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.ClusterStorageProvisioned);
                            break;
                        case HDInsight.ClusterState.ClusterStorageProvisioned:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.AzureVMConfiguration);
                            break;
                        case HDInsight.ClusterState.AzureVMConfiguration:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.HDInsightConfiguration);
                            break;
                        case HDInsight.ClusterState.HDInsightConfiguration:
                            if (cluster.Cluster.Name == "unknownclustername")
                            {
                                cluster.Cluster.ChangeState(HDInsight.ClusterState.Unknown);
                            }
                            else
                            {
                                cluster.Cluster.ChangeState(HDInsight.ClusterState.Operational);
                            }
                            break;
                        case HDInsight.ClusterState.PatchQueued:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.PatchQueued);
                            break;
                        case HDInsight.ClusterState.Operational:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.Running);

                            break;
                        case HDInsight.ClusterState.DeletePending:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.Deleting);
                            break;
                        case HDInsight.ClusterState.CertRolloverQueued:
                            cluster.Cluster.ChangeState(HDInsight.ClusterState.CertRolloverQueued);
                            break;
                        case HDInsight.ClusterState.Deleting:
                            tempList.Add(cluster);
                            break;
                        case HDInsight.ClusterState.Error:
                        case HDInsight.ClusterState.Running:
                        case HDInsight.ClusterState.Unknown:
                            // NO-OP
                            break;
                    }
                }
                foreach (var cluster in tempList)
                {
                    Clusters.Remove(cluster);
                }
                var resultClusters =
                    (from c in Clusters where c.Cluster.State != HDInsight.ClusterState.ReadyForDeployment select c).ToList();
                return resultClusters;
            }
        }

        public async Task<IHttpResponseMessageAbstraction> ListCloudServices()
        {
            this.ValidateConnection();
            this.LogMessage("Getting hdinsight clusters for subscriptionid : {0}", this.credentials.SubscriptionId.ToString());
            var resultClusters = ListCloudServicesInternal().Select(c => c.Cluster).ToList();
            var value = ServerSerializer.SerializeListContainersResult(resultClusters, this.credentials.DeploymentNamespace, true, false);
            return await Task.FromResult(new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, null, value));
        }

        private ClusterErrorStatus ValidateClusterCreation(HDInsight.ClusterCreateParametersV2 cluster)
        {
            if (!this.ValidateClusterCreationMetadata(cluster.HiveMetastore, cluster.OozieMetastore))
                return new ClusterErrorStatus(400, "Invalid metastores", "create");
            return null;
        }

        private ClusterErrorStatus ValidateHBaseClusterCreation(Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters cluster)
        {
            HiveComponent hive = cluster.Components.OfType<HiveComponent>().Single();
            OozieComponent oozie = cluster.Components.OfType<OozieComponent>().Single();
            Metastore hiveMetastore = null;
            Metastore oozieMetastore = null;
            if (!hive.Metastore.ShouldProvisionNew)
            {
                var metaStore = (SqlAzureDatabaseCredentialBackedResource)hive.Metastore;
                hiveMetastore = new Metastore(
                    metaStore.SqlServerName, metaStore.DatabaseName, metaStore.Credentials.Username, metaStore.Credentials.Password);
            }
            if (!oozie.Metastore.ShouldProvisionNew)
            {
                var metaStore = (SqlAzureDatabaseCredentialBackedResource)oozie.Metastore;
                oozieMetastore = new Metastore(
                    metaStore.SqlServerName, metaStore.DatabaseName, metaStore.Credentials.Username, metaStore.Credentials.Password);
            }
            if (!this.ValidateClusterCreationMetadata(hiveMetastore, oozieMetastore))
            {
                return new ClusterErrorStatus(400, "Invalid metastores", "create");
            }
            return null;
        }

        private bool ValidateClusterCreationMetadata(Metastore hive, Metastore oozie)
        {
            return this.ValidateMetastoreConnection(hive) && this.ValidateMetastoreConnection(oozie);
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Linq. [TGS]")]
        private bool ValidateMetastoreConnection(Metastore metastore)
        {
            var creds = IntegrationTestBase.GetAllCredentials();
            var hiveStores = (from tc in creds
                              where tc.IsNotNull() && tc.Environments.IsNotNull()
                              from e in tc.Environments
                              where e.IsNotNull() && e.HiveStores.IsNotNull()
                              from h in e.HiveStores
                              where h.IsNotNull()
                              select new { Server = h.SqlServer, h.Database, UserName = tc.AzureUserName, Password = tc.AzurePassword }).ToList();
            var ozzieStores = (from tc in creds
                               where tc.IsNotNull() && tc.Environments.IsNotNull()
                               from e in tc.Environments
                               where e.IsNotNull() && e.OozieStores.IsNotNull()
                               from h in e.OozieStores
                               where h.IsNotNull()
                               select new { Server = h.SqlServer, h.Database, UserName = tc.AzureUserName, Password = tc.AzurePassword }).ToList();

            var stores = hiveStores.Union(ozzieStores).ToList();

            if (metastore == null)
            {
                return true;
            }

            return (from s in stores
                    where
                        s.Server == metastore.Server && s.Database == metastore.Database && s.UserName == metastore.User &&
                        s.Password == metastore.Password
                    select s).Any();
        }

        public async Task<IHttpResponseMessageAbstraction> CreateContainer(string dnsName, string location, string clusterPayload, int schemaVersion = 2)
        {
            this.LogMessage("Creating cluster '{0}' in location {1}", dnsName, location);
            this.ValidateConnection();

            var registrationClient = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(this.credentials, this.context, false);
            if (!await registrationClient.ValidateSubscriptionLocation(location))
            {
                var resolver = ServiceLocator.Instance.Locate<ICloudServiceNameResolver>();
                string regionCloudServicename = resolver.GetCloudServiceName(
                    this.credentials.SubscriptionId, this.credentials.DeploymentNamespace, location);

                throw new HttpLayerException(
                    HttpStatusCode.NotFound, string.Format("The cloud service with name {0} was not found.", regionCloudServicename));
            }

            lock (Clusters)
            {
                var existingCluster = Clusters.FirstOrDefault(c => c.Cluster.Name == dnsName && c.Cluster.Location == location);
                if (existingCluster != null)
                    throw new HttpLayerException(HttpStatusCode.BadRequest, "<!DOCTYPE html><html>" + HDInsightClient.ClusterAlreadyExistsError + "</html>");

                HDInsight.ClusterCreateParametersV2 cluster = null;
                AzureHDInsightClusterConfiguration azureClusterConfig = null;
                ClusterDetails createCluster = null;
                if (schemaVersion == 2)
                {
                    var resource = ServerSerializer.DeserializeClusterCreateRequestIntoResource(clusterPayload);
                    if (resource.SchemaVersion != "2.0")
                    {
                        throw new HttpLayerException(HttpStatusCode.BadRequest, "SchemaVersion needs to be at 2.0");
                    }
                    cluster = ServerSerializer.DeserializeClusterCreateRequest(clusterPayload);
                    var storageAccounts = GetStorageAccounts(cluster).ToList();
                    createCluster = new ClusterDetails(cluster.Name, HDInsight.ClusterState.ReadyForDeployment.ToString())
                    {
                        ConnectionUrl = string.Format(@"https://{0}.azurehdinsight.net", cluster.Name),
                        Location = cluster.Location,
                        Error = this.ValidateClusterCreation(cluster),
                        HttpUserName = cluster.UserName,
                        HttpPassword = cluster.Password,
                        Version = this.GetVersion(cluster.Version),
                        ClusterSizeInNodes = cluster.ClusterSizeInNodes,
                        DefaultStorageAccount = storageAccounts.FirstOrDefault(),
                        AdditionalStorageAccounts = storageAccounts.Skip(1),
                        ClusterType = cluster.ClusterType
                    };
                    var clusterCreateDetails = ServerSerializer.DeserializeClusterCreateRequestToInternal(clusterPayload);
                    azureClusterConfig = GetAzureHDInsightClusterConfiguration(createCluster, clusterCreateDetails);
                }
                else if (schemaVersion == 3)
                {
                    var resource = ServerSerializer.DeserializeClusterCreateRequestIntoResource(clusterPayload);
                    if (resource.SchemaVersion != "3.0")
                    {
                        throw new HttpLayerException(HttpStatusCode.BadRequest, "SchemaVersion needs to be at 3.0");
                    }

                    cluster = ServerSerializer.DeserializeClusterCreateRequestV3(clusterPayload);
                    var storageAccounts = GetStorageAccounts(cluster).ToList();
                    createCluster = new ClusterDetails(cluster.Name, HDInsight.ClusterState.ReadyForDeployment.ToString())
                    {
                        ConnectionUrl = string.Format(@"https://{0}.azurehdinsight.net", cluster.Name),
                        Location = cluster.Location,
                        Error = this.ValidateClusterCreation(cluster),
                        HttpUserName = cluster.UserName,
                        HttpPassword = cluster.Password,
                        Version = this.GetVersion(cluster.Version),
                        ClusterSizeInNodes = cluster.ClusterSizeInNodes,
                        DefaultStorageAccount = storageAccounts.FirstOrDefault(),
                        AdditionalStorageAccounts = storageAccounts.Skip(1),
                        ClusterType = cluster.ClusterType
                    };
                    var clusterCreateDetails = ServerSerializer.DeserializeClusterCreateRequestToInternalV3(clusterPayload);
                    azureClusterConfig = GetAzureHDInsightClusterConfigurationV3(createCluster, clusterCreateDetails);
                }
                else
                {
                    throw new HttpLayerException(HttpStatusCode.BadRequest, "Invalid SchemaVersion");
                }

                var simCluster = new SimulatorClusterContainer() { Cluster = createCluster, Configuration = azureClusterConfig };
                Clusters.Add(simCluster);
                if (createCluster.Name.Contains("NetworkExceptionButCreateSucceeds"))
                {
                    throw new HttpRequestException("An error occurred while sending the request.");
                }
                if (createCluster.Name.Contains("HttpErrorButCreateSucceeds"))
                {
                    return new HttpResponseMessageAbstraction(HttpStatusCode.BadGateway, null, "BadGateway");
                }
            }
            return new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, null, string.Empty);
        }

        private static AzureHDInsightClusterConfiguration GetAzureHDInsightClusterConfigurationV3(
            ClusterDetails cluster, Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.ClusterCreateParameters clusterCreateDetails)
        {
            var azureClusterConfig = new AzureHDInsightClusterConfiguration();
            var yarn = clusterCreateDetails.Components.OfType<YarnComponent>().Single();
            var mapreduce = yarn.Applications.OfType<MapReduceApplication>().Single();
            var hive = clusterCreateDetails.Components.OfType<HiveComponent>().Single();
            var oozie = clusterCreateDetails.Components.OfType<OozieComponent>().Single();
            var hdfs = clusterCreateDetails.Components.OfType<HdfsComponent>().Single();
            var hadoopCore = clusterCreateDetails.Components.OfType<HadoopCoreComponent>().Single();

            if (hadoopCore.CoreSiteXmlProperties.Any())
            {
                AssertConfigOptionsAllowedMay2014(cluster, hadoopCore.CoreSiteXmlProperties, "Core");
                azureClusterConfig.Core.AddRange(
                    hadoopCore.CoreSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (hive.HiveSiteXmlProperties.Any())
            {
                AssertConfigOptionsAllowedMay2014(cluster, hive.HiveSiteXmlProperties, "Hive");
                azureClusterConfig.Hive.AddRange(hive.HiveSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (hdfs.HdfsSiteXmlProperties.Any())
            {
                AssertConfigOptionsAllowedMay2014(cluster, hdfs.HdfsSiteXmlProperties, "Hdfs");
                azureClusterConfig.Hdfs.AddRange(hdfs.HdfsSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (mapreduce.MapRedSiteXmlProperties.Any())
            {
                AssertConfigOptionsAllowedMay2014(cluster, mapreduce.MapRedSiteXmlProperties, "MapReduce");
                azureClusterConfig.MapReduce.AddRange(
                    mapreduce.MapRedSiteXmlProperties.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (oozie.Configuration.Any())
            {
                AssertConfigOptionsAllowedMay2014(cluster, oozie.Configuration, "Oozie");
                azureClusterConfig.Oozie.AddRange(oozie.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (yarn.Configuration.Any())
            {
                AssertConfigOptionsAllowedMay2014(cluster, yarn.Configuration, "Yarn");
                azureClusterConfig.Yarn.AddRange(oozie.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            return azureClusterConfig;
        }

        private static void AssertConfigOptionsAllowedMay2014(
            ClusterDetails cluster, IEnumerable<Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Property> propertyList, string settingsName)
        {
            var nonOverridableProperty = propertyList.FirstOrDefault(prop => nonOverridableConfigurationProperties.Contains(prop.Name));
            if (nonOverridableProperty != null)
            {
                // 'Specified Custom Settings are not valid. Error report: The following properties cannot be overridden for component: Core
                //  fs.default.name
                cluster.Error = new ClusterErrorStatus(
                    (int)HttpStatusCode.BadRequest,
                    string.Format(
                        CultureInfo.InvariantCulture,
                    "Specified Custom Settings are not valid. Error report: The following properties cannot be overridden for component: {0} {1} {2}",
                    settingsName,
                    Environment.NewLine,
                    nonOverridableProperty.Name),
                    "Create");
            }
        }

        private static AzureHDInsightClusterConfiguration GetAzureHDInsightClusterConfiguration(
            ClusterDetails cluster, ClusterContainer clusterCreateDetails)
        {
            var azureClusterConfig = new AzureHDInsightClusterConfiguration();

            if (clusterCreateDetails.Settings.Core != null && clusterCreateDetails.Settings.Core.Configuration != null)
            {
                AssertConfigOptionsAllowed(cluster, clusterCreateDetails.Settings.Core.Configuration, "Core");
                azureClusterConfig.Core.AddRange(
                        clusterCreateDetails.Settings.Core.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (clusterCreateDetails.Settings.Hive != null && clusterCreateDetails.Settings.Hive.Configuration != null)
            {
                AssertConfigOptionsAllowed(cluster, clusterCreateDetails.Settings.Hive.Configuration, "Hive");
                azureClusterConfig.Hive.AddRange(
                        clusterCreateDetails.Settings.Hive.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (clusterCreateDetails.Settings.Hdfs != null && clusterCreateDetails.Settings.Hdfs.Configuration != null)
            {
                AssertConfigOptionsAllowed(cluster, clusterCreateDetails.Settings.Hdfs.Configuration, "Hdfs");
                azureClusterConfig.Hdfs.AddRange(
                        clusterCreateDetails.Settings.Hdfs.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (clusterCreateDetails.Settings.MapReduce != null && clusterCreateDetails.Settings.MapReduce.Configuration != null)
            {
                AssertConfigOptionsAllowed(cluster, clusterCreateDetails.Settings.MapReduce.Configuration, "MapReduce");
                azureClusterConfig.MapReduce.AddRange(
                        clusterCreateDetails.Settings.MapReduce.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            if (clusterCreateDetails.Settings.Oozie != null && clusterCreateDetails.Settings.Oozie.Configuration != null)
            {
                AssertConfigOptionsAllowed(cluster, clusterCreateDetails.Settings.Oozie.Configuration, "Oozie");
                azureClusterConfig.Oozie.AddRange(
                        clusterCreateDetails.Settings.Oozie.Configuration.Select(prop => new KeyValuePair<string, string>(prop.Name, prop.Value)));
            }

            return azureClusterConfig;
        }

        private static void AssertConfigOptionsAllowed(ClusterDetails cluster, IEnumerable<Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013.Property> propertyList, string settingsName)
        {
            var nonOverridableProperty = propertyList.FirstOrDefault(prop => nonOverridableConfigurationProperties.Contains(prop.Name));
            if (nonOverridableProperty != null)
            {
                // 'Specified Custom Settings are not valid. Error report: The following properties cannot be overridden for component: Core
                //  fs.default.name
                cluster.Error = new ClusterErrorStatus(
                    (int)HttpStatusCode.BadRequest,
                    string.Format(
                        CultureInfo.InvariantCulture,
                    "Specified Custom Settings are not valid. Error report: The following properties cannot be overridden for component: {0} {1} {2}",
                    settingsName,
                    Environment.NewLine,
                    nonOverridableProperty.Name),
                    "Create");
            }
        }

        private static IEnumerable<WabStorageAccountConfiguration> GetStorageAccounts(HDInsight.ClusterCreateParametersV2 cluster)
        {
            var storageAccounts = new List<WabStorageAccountConfiguration>();
            storageAccounts.Add(
                new WabStorageAccountConfiguration(cluster.DefaultStorageAccountName, cluster.DefaultStorageAccountKey, cluster.DefaultStorageContainer));

            storageAccounts.AddRange(cluster.AdditionalStorageAccounts);
            return storageAccounts;
        }

        private string GetVersion(string version)
        {
            var overrideHandlers = ServiceLocator.Instance.Locate<IHDInsightClusterOverrideManager>().GetHandlers(this.credentials, this.context, false);
            var versionFinder = overrideHandlers.VersionFinder;
            var supportedVersions = versionFinder.ListAvailableVersions().WaitForResult();
            if (string.Equals(version, defaultVersion, StringComparison.OrdinalIgnoreCase))
            {
                return supportedVersions.Last().Version;
            }
            else
            {
                if (!supportedVersions.Any(supportedVersion => string.Equals(version, supportedVersion.Version, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new HttpLayerException(HttpStatusCode.BadRequest, "Unsupported version specified");
                }
            }

            return version;
        }

        public async Task<IHttpResponseMessageAbstraction> DeleteContainer(string dnsName, string location)
        {
            this.ValidateConnection();
            this.LogMessage("Deleting cluster '{0}' in location {1}", dnsName, location);
            lock (Clusters)
            {
                var cluster = Clusters.FirstOrDefault(c => c.Cluster.Name == dnsName && c.Cluster.Location == location);
                if (cluster == null)
                    throw new HttpLayerException(HttpStatusCode.NotFound, "Cluster Not Found");
                if (dnsName == IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName)
                {
                    throw new InvalidOperationException("The well known DNS name can not be deleted.");
                }
                cluster.Cluster.ChangeState(HDInsight.ClusterState.DeletePending);
            }
            return await Task.FromResult(new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, null, string.Empty));
        }

        public Task<IHttpResponseMessageAbstraction> ReturnResponse(PassthroughResponse passthroughResponse)
        {
            string responsePayload;
            var converter = new ClusterProvisioningServerPayloadConverter();
            responsePayload = converter.SerailizeChangeRequestResponse(passthroughResponse);
            var response = new HttpResponseMessageAbstraction(HttpStatusCode.Accepted, new HttpResponseHeadersAbstraction(), responsePayload);
            return Task.FromResult((IHttpResponseMessageAbstraction)response);
        }

        public Task<IHttpResponseMessageAbstraction> GetOperationStatus(string dnsName, string location, Guid operationId)
        {
            lock (Clusters)
            {
                var passThroughResponse = new PassthroughResponse();
                PendingOp op;
                if (ProcessingOps.TryGetValue(operationId, out op))
                {
                    passThroughResponse.Data = op.Response;
                    // Operation was in error.
                    if (op.Response.State == UserChangeOperationState.Error)
                    {
                        return this.ReturnResponse(passThroughResponse);
                    }
                    // Operation has completed.
                    if (op.Response.RequestIssueDate.AddMilliseconds(OperationTimeToCompletionInMilliseconds) < DateTime.UtcNow)
                    {
                        op.Response.State = UserChangeOperationState.Completed;
                        return this.ReturnResponse(passThroughResponse);
                    }
                    // We are still pending.
                    return this.ReturnResponse(passThroughResponse);
                }
                passThroughResponse.Error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorId = "Not Found",
                    ErrorMessage = "The requested status operation could not be found."
                };
                return this.ReturnResponse(passThroughResponse);
            }
        }

        public Task<IHttpResponseMessageAbstraction> EnableDisableUserChangeRequest(string dnsName, string location, UserChangeRequestUserType requestType, string payload)
        {
            if (requestType == UserChangeRequestUserType.Http)
            {
                return this.EnableDisableUserChangeRequest(dnsName, location, payload);
            }
            if (requestType == UserChangeRequestUserType.Rdp)
            {
                return this.EnableDisableRdp(dnsName, location, payload);
            }
            throw new NotSupportedException("The change operation is not supported.");
        }

        public static void SetHttpUserNameAndPassword(string dnsName, string userName, string password)
        {
            var cluster = GetCloudServiceInternal(dnsName);
            cluster.Cluster.HttpUserName = userName;
            cluster.Cluster.HttpPassword = password;
        }

        public Task<IHttpResponseMessageAbstraction> EnableDisableUserChangeRequest(string dnsName, string location, string payload)
        {
            lock (Clusters)
            {
                var converter = new ClusterProvisioningServerPayloadConverter();
                var request = converter.DeserializeChangeRequest<HttpUserChangeRequest>(payload);
                var passThroughResponse = new PassthroughResponse();
                var statusResponse = new UserChangeOperationStatusResponse();
                var pendingOp = new PendingOp(statusResponse);
                passThroughResponse.Data = pendingOp.Id;
                statusResponse.OperationType = request.Operation;
                statusResponse.UserType = UserType.Http;
                statusResponse.RequestIssueDate = DateTime.UtcNow;
                statusResponse.State = UserChangeOperationState.Pending;
                Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails error;

                var cluster = GetCloudServiceInternal(dnsName);
                // If the Cluster is not Found.
                if (cluster.IsNull())
                {
                    error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorId = "NOT FOUND",
                        ErrorMessage = "The requested cluster does not exist.",
                    };
                    passThroughResponse.Error = error;
                    passThroughResponse.Data = null;
                    return this.ReturnResponse(passThroughResponse);
                }
                if (!this.SupportedConnectivityClusterVersions.Contains(cluster.Cluster.Version))
                {
                    error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorId = "UNSUPPORTED",
                        ErrorMessage =
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "Cluster connectivity changes are not supported for this cluster version '{0}'.",
                                cluster.Cluster.Version)
                    };
                    passThroughResponse.Error = error;
                    passThroughResponse.Data = null;
                    return this.ReturnResponse(passThroughResponse);
                }
                // If the cluster has a pending operation (for the simulator pending operations always take <OperationTimeToCompletionInSeconds> seconds)
                if (cluster.HttpPendingOp.IsNotNull())
                {
                    if (cluster.HttpPendingOp.Response.RequestIssueDate.AddMilliseconds(OperationTimeToCompletionInMilliseconds) > DateTime.UtcNow)
                    {
                        error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                        {
                            StatusCode = HttpStatusCode.Conflict,
                            ErrorId = "CONFLICT",
                            ErrorMessage = "Another attempt to update the server is in progress."
                        };
                        passThroughResponse.Error = error;
                        passThroughResponse.Data = null;
                        return this.ReturnResponse(passThroughResponse);
                    }
                }
                if (request.Operation == UserChangeOperationType.Enable)
                {
                    // If the cluster already has a User and we are trying to enable again.
                    if (cluster.Cluster.HttpUserName.IsNotNullOrEmpty())
                    {
                        error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            ErrorId = "Bad Request",
                            ErrorMessage =
                                "Attempt to enable a user when a user has already been enabled.  Please disable the user first and try again."
                        };
                        passThroughResponse.Error = error;
                        passThroughResponse.Data = null;
                        return this.ReturnResponse(passThroughResponse);
                    }
                    // check that the user is not trying to update the http user with the same user name as rdp
                    if (!String.IsNullOrEmpty(cluster.Cluster.RdpUserName))
                    {
                        if (cluster.Cluster.RdpUserName.Equals(request.Username))
                        {
                            error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                ErrorId = "USERCHANGE_INVALIDNAME",
                                ErrorMessage = "Http username is not allowed to be same as RDP user name"
                            };
                            passThroughResponse.Error = error;
                            passThroughResponse.Data = null;
                            return this.ReturnResponse(passThroughResponse);
                        }
                    }
                    // Otherwise this is a good request, set the pending op.
                    if (request.Username == "fail")
                    {
                        statusResponse.State = UserChangeOperationState.Error;
                        statusResponse.Error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            ErrorId = "Bad Request",
                            ErrorMessage = "The request failed."
                        };
                    }
                    cluster.HttpPendingOp = pendingOp;
                    ProcessingOps.Add(pendingOp.Id, pendingOp);
                    cluster.Cluster.HttpUserName = request.Username;
                    cluster.Cluster.HttpPassword = request.Password;
                    return this.ReturnResponse(passThroughResponse);
                }
                // It's a disable, that's always an op (or a duplicate op).
                cluster.HttpPendingOp = pendingOp;
                ProcessingOps.Add(pendingOp.Id, pendingOp);
                cluster.Cluster.HttpUserName = string.Empty;
                cluster.Cluster.HttpPassword = string.Empty;
                return this.ReturnResponse(passThroughResponse);
            }
        }

        public Task<IHttpResponseMessageAbstraction> EnableDisableRdp(string dnsName, string location, string payload)
        {
            lock (Clusters)
            {
                var converter = new ClusterProvisioningServerPayloadConverter();
                var request = converter.DeserializeChangeRequest<RdpUserChangeRequest>(payload);
                var passThroughResponse = new PassthroughResponse();
                var statusResponse = new UserChangeOperationStatusResponse();
                var pendingOp = new PendingOp(statusResponse);
                passThroughResponse.Data = pendingOp.Id;
                statusResponse.OperationType = request.Operation;
                statusResponse.UserType = UserType.Rdp;
                statusResponse.RequestIssueDate = DateTime.UtcNow;
                statusResponse.State = UserChangeOperationState.Pending;
                Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails error;

                var cluster = GetCloudServiceInternal(dnsName);
                // If the Cluster is not Found.
                if (cluster.IsNull())
                {
                    error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorId = "NOT FOUND",
                        ErrorMessage = "The requested cluster does not exist.",
                    };
                    passThroughResponse.Error = error;
                    passThroughResponse.Data = null;
                    return this.ReturnResponse(passThroughResponse);
                }
                // If the cluster has a pending operation (for the simulator pending operations always take <OperationTimeToCompletionInSeconds> seconds)
                if (!this.SupportedConnectivityClusterVersions.Contains(cluster.Cluster.Version))
                {
                    error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorId = "UNSUPPORTED",
                        ErrorMessage = "Cluster connectivity changes are not supported for this cluster version."
                    };
                    passThroughResponse.Error = error;
                    passThroughResponse.Data = Guid.Empty;
                    return this.ReturnResponse(passThroughResponse);
                }
                // If the cluster has a pending operation (for the simulator pending operations always take 10 seconds)
                if (cluster.RdpPendingOp.IsNotNull())
                {
                    if (cluster.RdpPendingOp.Response.RequestIssueDate.AddMilliseconds(OperationTimeToCompletionInMilliseconds) > DateTime.UtcNow)
                    {
                        error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                        {
                            StatusCode = HttpStatusCode.Conflict,
                            ErrorId = "CONFLICT",
                            ErrorMessage = "Another attempt to update the server is in progress."
                        };
                        passThroughResponse.Error = error;
                        passThroughResponse.Data = null;
                        return this.ReturnResponse(passThroughResponse);
                    }
                }
                if (request.Operation == UserChangeOperationType.Enable)
                {
                    // If the cluster already has a User and we are trying to enable again.
                    if (cluster.Cluster.RdpUserName.IsNotNullOrEmpty())
                    {
                        error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            ErrorId = "Bad Request",
                            ErrorMessage =
                                "Attempt to enable a user when a user has already been enabled.  Please disable the user first and try again."
                        };
                        passThroughResponse.Error = error;
                        passThroughResponse.Data = null;
                        return this.ReturnResponse(passThroughResponse);
                    }
                    // check that the user is not trying to update the rdp user with the same user name as http
                    if (!String.IsNullOrEmpty(cluster.Cluster.HttpUserName))
                    {
                        if (cluster.Cluster.HttpUserName.Equals(request.Username))
                        {
                            error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                ErrorId = "USERCHANGE_INVALIDNAME",
                                ErrorMessage = "RDP username is not allowed to be same as http user name"
                            };
                            passThroughResponse.Error = error;
                            passThroughResponse.Data = null;
                            return this.ReturnResponse(passThroughResponse);
                        }
                    }
                    // Otherwise this is a good request, set the pending op.
                    if (request.Username == "fail")
                    {
                        statusResponse.State = UserChangeOperationState.Error;
                        statusResponse.Error = new Microsoft.WindowsAzure.Management.HDInsight.Contracts.ErrorDetails()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            ErrorId = "Bad Request",
                            ErrorMessage = "The request failed."
                        };
                    }
                    cluster.RdpPendingOp = pendingOp;
                    ProcessingOps.Add(pendingOp.Id, pendingOp);
                    cluster.Cluster.RdpUserName = request.Username;
                    return this.ReturnResponse(passThroughResponse);
                }
                // It's a disable, that's always an op (or a duplicate op).
                cluster.RdpPendingOp = pendingOp;
                ProcessingOps.Add(pendingOp.Id, pendingOp);
                cluster.Cluster.RdpUserName = string.Empty;
                return this.ReturnResponse(passThroughResponse);
            }
        }

        private void ValidateConnection()
        {
            var asCertificateCreds = this.credentials as IHDInsightCertificateCredential;
            var asTokenCreds = this.credentials as IHDInsightAccessTokenCredential;
            if (asCertificateCreds.IsNotNull() && (!this.certificates.ContainsKey(asCertificateCreds.Certificate.Thumbprint) || !this.subscriptions.Contains(asCertificateCreds.SubscriptionId)))
            {
                throw new HttpLayerException(HttpStatusCode.Forbidden, string.Empty);
            }

            if (asTokenCreds.IsNotNull() && string.IsNullOrEmpty(asTokenCreds.AccessToken))
            {
                throw new HttpLayerException(HttpStatusCode.Forbidden, string.Empty);
            }
        }

        private void LogMessage(string content, params string[] args)
        {
            string message = content;
            if (args.Any())
            {
                message = string.Format(CultureInfo.InvariantCulture, content, args);
            }

            ServiceLocator.Instance.Locate<ILogger>().LogMessage(message);
            if (this.context.Logger != null)
            {
                this.context.Logger.LogMessage(message, Severity.Informational, Verbosity.Diagnostic);
            }
        }

        public ILogger Logger { get; private set; }
    }
}
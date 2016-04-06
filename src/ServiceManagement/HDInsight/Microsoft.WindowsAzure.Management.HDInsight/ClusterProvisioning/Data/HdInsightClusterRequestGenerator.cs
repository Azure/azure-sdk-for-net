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

namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.ComponentModel;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.YarnApplications;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Networking;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.CustomActions;

    /// <summary>
    /// Generate payload object for different cluster flavor.
    /// </summary>
    internal static class HDInsightClusterRequestGenerator
    {
        /// <summary>
        /// Generate ClusterCreateParameters object for 1.X cluster with only Hadoop.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        /// <returns>An instance of the cluster create parameters.</returns>
        internal static ClusterCreateParameters Create1XClusterForMapReduceTemplate(HDInsight.ClusterCreateParametersV2 inputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException("inputs");
            }

            if (inputs.HeadNodeSize.Equals(VmSize.Large.ToString()))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Version 1.X('{0}') clusters can only contain ExtraLarge headnodes.", inputs.Version));
            }

            var createParameters = Create2XClusterForMapReduceTemplate(inputs);
            var headNodeRole = createParameters.ClusterRoleCollection
                .Find(role => role.FriendlyName.Equals("HeadNodeRole", StringComparison.OrdinalIgnoreCase));
            //We do not support HA clusters for 1.X so we need to set the instance count to 1
            headNodeRole.InstanceCount = 1;
            headNodeRole.VMSize = VmSize.ExtraLarge;
            return createParameters;
        }

        /// <summary>
        /// Generate ClusterCreateParameters object for 2.X cluster with only Hadoop.
        /// </summary>
        /// <param name="inputs">Cluster creation parameter inputs.</param>
        /// <returns>The corresponding ClusterCreateParameter object.</returns>
        internal static ClusterCreateParameters Create2XClusterForMapReduceTemplate(HDInsight.ClusterCreateParametersV2 inputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException("inputs");
            }

            var cluster = new ClusterCreateParameters { DnsName = inputs.Name, Version = inputs.Version };
            var remoteDesktopSettings = (string.IsNullOrEmpty(inputs.RdpUsername))
                ? new RemoteDesktopSettings()
                {
                    IsEnabled = false
                }
                : new RemoteDesktopSettings()
                {
                    IsEnabled = true,
                    AuthenticationCredential = new UsernamePasswordCredential()
                    {
                        Username = inputs.RdpUsername,
                        Password = inputs.RdpPassword
                    },
                    RemoteAccessExpiry = (DateTime) inputs.RdpAccessExpiry
                };
            var headnodeRole = new ClusterRole
            {
                FriendlyName = "HeadNodeRole",
                InstanceCount = 2,
                VMSizeAsString = inputs.HeadNodeSize,
                RemoteDesktopSettings = remoteDesktopSettings
            };
            var workernodeRole = new ClusterRole
            {
                InstanceCount = inputs.ClusterSizeInNodes,
                FriendlyName = "WorkerNodeRole",
                VMSizeAsString = inputs.DataNodeSize,
                RemoteDesktopSettings = remoteDesktopSettings
            };
            var zookeeperRole = new ClusterRole
            {
                InstanceCount = 3,
                FriendlyName = "ZKRole",
                VMSizeAsString = VmSize.Small.ToString(),
                RemoteDesktopSettings = remoteDesktopSettings
            };

            cluster.ClusterRoleCollection.Add(headnodeRole);
            cluster.ClusterRoleCollection.Add(workernodeRole);
            cluster.ClusterRoleCollection.Add(zookeeperRole);

            var gateway = new GatewayComponent
            {
                IsEnabled = true,
                RestAuthCredential = new UsernamePasswordCredential { Username = inputs.UserName, Password = inputs.Password }
            };
            cluster.Components.Add(gateway);
            cluster.Location = inputs.Location;

            // Adding MapReduce component
            MapReduceComponent mapReduce = new MapReduceComponent { HeadNodeRole = headnodeRole, WorkerNodeRole = workernodeRole };
            ConfigMapReduceComponent(mapReduce, inputs);
            cluster.Components.Add(mapReduce);

            // Adding Hive component
            HiveComponent hive = new HiveComponent { HeadNodeRole = headnodeRole };
            ConfigHiveComponent(hive, inputs);
            cluster.Components.Add(hive);

            // Adding config action component if needed
            if (inputs.ConfigActions != null && inputs.ConfigActions.Count > 0)
            {
                CustomActionComponent configAction = new CustomActionComponent { HeadNodeRole = headnodeRole, WorkerNodeRole = workernodeRole };
                AddConfigActionComponent(configAction, inputs, headnodeRole, workernodeRole, zookeeperRole);
                cluster.Components.Add(configAction);
            }

            // Adding Oozie component
            OozieComponent oozie = new OozieComponent { HeadNodeRole = headnodeRole };
            ConfigOozieComponent(oozie, inputs);
            cluster.Components.Add(oozie);

            // Adding Hdfs component
            HdfsComponent hdfs = new HdfsComponent { HeadNodeRole = headnodeRole, WorkerNodeRole = workernodeRole };
            ConfigHdfsComponent(hdfs, inputs);
            cluster.Components.Add(hdfs);

            // Adding HadoopCore component
            HadoopCoreComponent hadoopCore = new HadoopCoreComponent();
            ConfigHadoopCoreComponent(hadoopCore, inputs);
            cluster.Components.Add(hadoopCore);

            ConfigVirtualNetwork(cluster, inputs);

            return cluster;
        }

        /// <summary>
        /// Generate ClusterCreateParameters object for 3.X cluster with only Hadoop.
        /// </summary>
        /// <param name="inputs">Cluster creation parameter inputs.</param>
        /// <returns>The corresponding ClusterCreateParameter object.</returns>
        internal static ClusterCreateParameters Create3XClusterFromMapReduceTemplate(HDInsight.ClusterCreateParametersV2 inputs)
        {
            if (inputs == null) 
            {
                throw new ArgumentNullException("inputs");
            }

            var remoteDesktopSettings = (string.IsNullOrEmpty(inputs.RdpUsername))
                ? new RemoteDesktopSettings()
                {
                    IsEnabled = false
                }
                : new RemoteDesktopSettings()
                {
                    IsEnabled = true,
                    AuthenticationCredential = new UsernamePasswordCredential()
                    {
                        Username = inputs.RdpUsername,
                        Password = inputs.RdpPassword
                    },
                    RemoteAccessExpiry = (DateTime)inputs.RdpAccessExpiry
                };

            var cluster = new ClusterCreateParameters
            {
                DnsName = inputs.Name,
                Version = inputs.Version,
            };
            var headnodeRole = new ClusterRole
            {
                FriendlyName = "HeadNodeRole",
                InstanceCount = 2,
                VMSizeAsString = inputs.HeadNodeSize,
                RemoteDesktopSettings = remoteDesktopSettings
            };
            var workernodeRole = new ClusterRole
            {
                InstanceCount = inputs.ClusterSizeInNodes,
                FriendlyName = "WorkerNodeRole",
                VMSizeAsString = inputs.DataNodeSize,
                RemoteDesktopSettings = remoteDesktopSettings
            };
            var zookeeperRole = new ClusterRole
            {
                InstanceCount = 3,
                FriendlyName = "ZKRole",
                VMSizeAsString = inputs.ZookeeperNodeSize ?? VmSize.Small.ToString(),
                RemoteDesktopSettings = remoteDesktopSettings
            };
            cluster.ClusterRoleCollection.Add(headnodeRole);
            cluster.ClusterRoleCollection.Add(workernodeRole);
            cluster.ClusterRoleCollection.Add(zookeeperRole);
            
            var gateway = new GatewayComponent
                {
                    IsEnabled = true,
                    RestAuthCredential = new UsernamePasswordCredential { Username = inputs.UserName, Password = inputs.Password }
               };
            cluster.Components.Add(gateway);
            cluster.Location = inputs.Location;

            //Add yarn component
            YarnComponent yarn = new YarnComponent { ResourceManagerRole = headnodeRole, NodeManagerRole = workernodeRole, };
            ConfigYarnComponent(yarn, inputs);
            MapReduceApplication mapreduceApp = new MapReduceApplication();
            ConfigMapReduceApplication(mapreduceApp, inputs);
            yarn.Applications.Add(mapreduceApp);
            cluster.Components.Add(yarn);

            // Adding Hive component
            HiveComponent hive = new HiveComponent { HeadNodeRole = headnodeRole };
            ConfigHiveComponent(hive, inputs);
            cluster.Components.Add(hive);

            // Adding config action component if needed
            if (inputs.ConfigActions != null && inputs.ConfigActions.Count > 0)
            {
                CustomActionComponent configAction = new CustomActionComponent { HeadNodeRole = headnodeRole, WorkerNodeRole = workernodeRole };
                AddConfigActionComponent(configAction, inputs, headnodeRole, workernodeRole, zookeeperRole);
                cluster.Components.Add(configAction);
            }

            // Adding Oozie component
            OozieComponent oozie = new OozieComponent { HeadNodeRole = headnodeRole };
            ConfigOozieComponent(oozie, inputs);
            cluster.Components.Add(oozie);

            // Adding Hdfs component
            HdfsComponent hdfs = new HdfsComponent { HeadNodeRole = headnodeRole, WorkerNodeRole = workernodeRole };
            ConfigHdfsComponent(hdfs, inputs);
            cluster.Components.Add(hdfs);

            // Adding HadoopCore component
            HadoopCoreComponent hadoopCore = new HadoopCoreComponent();
            ConfigHadoopCoreComponent(hadoopCore, inputs);
            cluster.Components.Add(hadoopCore);

            // Adding Zookeeper component
            cluster.Components.Add(new ZookeeperComponent { ZookeeperRole = zookeeperRole });

            ConfigVirtualNetwork(cluster, inputs);

            return cluster;
        }

        /// <summary>
        /// Generate ClusterCreateParameters object for 3.X cluster with Hadoop and HBase.
        /// </summary>
        /// <param name="inputs">Cluster creation parameter inputs.</param>
        /// <returns>The corresponding ClusterCreateParameter object.</returns>
        internal static ClusterCreateParameters Create3XClusterForMapReduceAndHBaseTemplate(HDInsight.ClusterCreateParametersV2 inputs)
         {
            if (inputs == null)
            {
                throw new ArgumentNullException("inputs");
            }

            var cluster = Create3XClusterFromMapReduceTemplate(inputs);

            var hbaseMasterRole = cluster.Components.OfType<ZookeeperComponent>().Single().ZookeeperRole;

            //in case no ZK node size is set for hbase, set medium.
            if (inputs.ZookeeperNodeSize == null)
            {
                hbaseMasterRole.VMSizeAsString = VmSize.Medium.ToString();   
            }

            //Add HBase component
            HBaseComponent hbase = new HBaseComponent
            {
                MasterServerRole = hbaseMasterRole,
                RegionServerRole = cluster.Components.OfType<HdfsComponent>().Single().WorkerNodeRole
            };
            ConfigHBaseComponent(hbase, inputs);
            cluster.Components.Add(hbase);

            return cluster;
         }

        /// <summary>
        /// Generate ClusterCreateParameters object for 3.X cluster with Hadoop and Storm.
        /// </summary>
        /// <param name="inputs">Cluster creation parameter inputs.</param>
        /// <returns>The corresponding ClusterCreateParameter object.</returns>
        internal static ClusterCreateParameters Create3XClusterForMapReduceAndStormTemplate(HDInsight.ClusterCreateParametersV2 inputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException("inputs");
            }

            var cluster = Create3XClusterFromMapReduceTemplate(inputs);

            var masterRole = cluster.Components.OfType<YarnComponent>().Single().ResourceManagerRole;
            var workerRole = cluster.Components.OfType<YarnComponent>().Single().NodeManagerRole;

            //Add Storm component
            StormComponent storm = new StormComponent
            {
                MasterRole = masterRole,
                WorkerRole = workerRole
            };
            ConfigStormComponent(storm, inputs);
            cluster.Components.Add(storm);

            return cluster;
        }

        /// <summary>
        /// Generate ClusterCreateParameters object for 3.X cluster with Hadoop and Spark.
        /// </summary>
        /// <param name="inputs">Cluster creation parameter inputs.</param>
        /// <returns>The corresponding ClusterCreateParameter object.</returns>
        internal static ClusterCreateParameters Create3XClusterForMapReduceAndSparkTemplate(HDInsight.ClusterCreateParametersV2 inputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException("inputs");
            }

            var cluster = Create3XClusterFromMapReduceTemplate(inputs);

            var masterRole = cluster.Components.OfType<YarnComponent>().Single().ResourceManagerRole;
            var workerRole = cluster.Components.OfType<YarnComponent>().Single().NodeManagerRole;

            //Add Spark component
            SparkComponent spark = new SparkComponent
            {
                MasterRole = masterRole,
                WorkerRole = workerRole
            };
            ConfigSparkComponent(spark, inputs);
            cluster.Components.Add(spark);

            return cluster;
        }


        private static void ConfigHiveComponent(HiveComponent hive, ClusterCreateParametersV2 inputs)
        {
            hive.HiveSiteXmlProperties.AddRange(
                inputs.HiveConfiguration.ConfigurationCollection.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));

            if (inputs.HiveConfiguration.AdditionalLibraries != null)
            {
                hive.AdditionalLibraries = new BlobContainerCredentialBackedResource()
                {
                    AccountDnsName = inputs.HiveConfiguration.AdditionalLibraries.Name,
                    BlobContainerName = inputs.HiveConfiguration.AdditionalLibraries.Container,
                    Key = inputs.HiveConfiguration.AdditionalLibraries.Key
                };
            }

            if (inputs.HiveMetastore != null)
            {
                hive.Metastore = new SqlAzureDatabaseCredentialBackedResource()
                {
                    SqlServerName = inputs.HiveMetastore.Server,
                    Credentials = new UsernamePasswordCredential() { Username = inputs.HiveMetastore.User, Password = inputs.HiveMetastore.Password },
                    DatabaseName = inputs.HiveMetastore.Database
                };
            }
        }

        private static void AddConfigActionComponent(CustomActionComponent configAction, HDInsight.ClusterCreateParametersV2 inputs, ClusterRole headnodeRole, ClusterRole workernodeRole, ClusterRole zookeperRole)
        {
            configAction.CustomActions = new CustomActionList();

            // Converts config action from PS/SDK to wire contract.
            foreach (ConfigAction ca in inputs.ConfigActions)
            {
                CustomAction newConfigAction;

                // Based on the config action type defined in SDK, convert them to config action defined in wire contract.
                ScriptAction sca = ca as ScriptAction;

                if (sca != null)
                {
                    newConfigAction = new ScriptCustomAction
                    {
                        Name = ca.Name,
                        Uri = sca.Uri,
                        Parameters = sca.Parameters
                    };
                }
                else
                {
                    throw new NotSupportedException("No such config action supported.");
                }

                newConfigAction.ClusterRoleCollection = new ClusterRoleCollection();

                // Add in cluster role collection for each config action.
                foreach (ClusterNodeType clusterRoleType in ca.ClusterRoleCollection)
                {
                    if (clusterRoleType == ClusterNodeType.HeadNode)
                    {
                        newConfigAction.ClusterRoleCollection.Add(headnodeRole);
                    }
                    else if (clusterRoleType == ClusterNodeType.DataNode)
                    {
                        newConfigAction.ClusterRoleCollection.Add(workernodeRole);
                    }
                    else if (clusterRoleType == ClusterNodeType.ZookeperNode)
                    {
                        if (inputs.ClusterType.Equals(ClusterType.HBase) || inputs.ClusterType.Equals(ClusterType.Storm))
                        {
                            newConfigAction.ClusterRoleCollection.Add(zookeperRole);
                        }
                        else
                        {
                            throw new NotSupportedException(string.Format("Customization of zookeper nodes only supported for cluster types {0} and {1}",
                                ClusterType.HBase.ToString(), ClusterType.Storm.ToString()));
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("No such node type supported.");
                    }
                }

                configAction.CustomActions.Add(newConfigAction);
            }
        }

        private static void ConfigOozieComponent(OozieComponent oozie, HDInsight.ClusterCreateParametersV2 inputs)
        {
            oozie.Configuration.AddRange(
                inputs.OozieConfiguration.ConfigurationCollection.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));

            if (inputs.OozieConfiguration.AdditionalSharedLibraries != null)
            {
                oozie.AdditionalSharedLibraries = new BlobContainerCredentialBackedResource()
                {
                    AccountDnsName = inputs.OozieConfiguration.AdditionalSharedLibraries.Name,
                    BlobContainerName = inputs.OozieConfiguration.AdditionalSharedLibraries.Container,
                    Key = inputs.OozieConfiguration.AdditionalSharedLibraries.Key
                };
            }

            if (inputs.OozieConfiguration.AdditionalActionExecutorLibraries != null)
            {
                oozie.AdditionalActionExecutorLibraries = new BlobContainerCredentialBackedResource()
                {
                    AccountDnsName = inputs.OozieConfiguration.AdditionalActionExecutorLibraries.Name,
                    BlobContainerName = inputs.OozieConfiguration.AdditionalActionExecutorLibraries.Container,
                    Key = inputs.OozieConfiguration.AdditionalActionExecutorLibraries.Key
                };
            }

            if (inputs.OozieMetastore != null)
            {
                oozie.Metastore = new SqlAzureDatabaseCredentialBackedResource()
                {
                    SqlServerName = inputs.OozieMetastore.Server,
                    Credentials =
                        new UsernamePasswordCredential() { Username = inputs.OozieMetastore.User, Password = inputs.OozieMetastore.Password },
                    DatabaseName = inputs.OozieMetastore.Database
                };
            }
        }

        private static void ConfigHdfsComponent(HdfsComponent hdfs, HDInsight.ClusterCreateParametersV2 inputs)
        {
            hdfs.HdfsSiteXmlProperties.AddRange(inputs.HdfsConfiguration.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));
        }

        private static void ConfigHadoopCoreComponent(HadoopCoreComponent hadoopCore, HDInsight.ClusterCreateParametersV2 inputs)
        {
            hadoopCore.CoreSiteXmlProperties.AddRange(inputs.CoreConfiguration.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));
        }

        private static void ConfigMapReduceComponent(MapReduceComponent mapReduce, HDInsight.ClusterCreateParametersV2 inputs)
        {
            mapReduce.MapRedConfXmlProperties.AddRange(
                inputs.MapReduceConfiguration.ConfigurationCollection.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));

            mapReduce.CapacitySchedulerConfXmlProperties.AddRange(
                inputs.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.Select(
                    prop => new Property { Name = prop.Key, Value = prop.Value }));

            mapReduce.DefaultStorageAccountAndContainer = new BlobContainerCredentialBackedResource()
            {
                AccountDnsName = inputs.DefaultStorageAccountName,
                BlobContainerName = inputs.DefaultStorageContainer,
                Key = inputs.DefaultStorageAccountKey
            };

            if (inputs.AdditionalStorageAccounts.Any())
            {
                mapReduce.AdditionalStorageAccounts.AddRange(
                    inputs.AdditionalStorageAccounts.Select(
                        storageAccount =>
                        new BlobContainerCredentialBackedResource()
                        {
                            AccountDnsName = storageAccount.Name,
                            BlobContainerName = storageAccount.Container,
                            Key = storageAccount.Key
                        }));
            }
        }

        private static void ConfigMapReduceApplication(MapReduceApplication mapReduceApp, HDInsight.ClusterCreateParametersV2 inputs)
        {
            mapReduceApp.MapRedSiteXmlProperties.AddRange(
                inputs.MapReduceConfiguration.ConfigurationCollection.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));

            mapReduceApp.CapacitySchedulerConfiguration.AddRange(
                inputs.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.Select(
                    prop => new Property { Name = prop.Key, Value = prop.Value }));

            mapReduceApp.DefaultStorageAccountAndContainer = new BlobContainerCredentialBackedResource()
            {
                AccountDnsName = inputs.DefaultStorageAccountName,
                BlobContainerName = inputs.DefaultStorageContainer,
                Key = inputs.DefaultStorageAccountKey
            };

            if (inputs.AdditionalStorageAccounts.Any())
            {
                mapReduceApp.AdditionalStorageContainers.AddRange(
                    inputs.AdditionalStorageAccounts.Select(
                        storageAccount =>
                        new BlobContainerCredentialBackedResource()
                        {
                            AccountDnsName = storageAccount.Name,
                            BlobContainerName = storageAccount.Container,
                            Key = storageAccount.Key
                        }));
            }
        }

        private static void ConfigYarnComponent(YarnComponent yarn, HDInsight.ClusterCreateParametersV2 inputs)
        {
            yarn.Configuration.AddRange(inputs.YarnConfiguration.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));
        }

        private static void ConfigHBaseComponent(HBaseComponent hbase, HDInsight.ClusterCreateParametersV2 inputs)
        {
            hbase.HBaseConfXmlProperties.AddRange(
                inputs.HBaseConfiguration.ConfigurationCollection.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));

            if (inputs.HBaseConfiguration.AdditionalLibraries != null)
            {
                hbase.AdditionalLibraries = new BlobContainerCredentialBackedResource()
                {
                    AccountDnsName = inputs.HBaseConfiguration.AdditionalLibraries.Name,
                    BlobContainerName = inputs.HBaseConfiguration.AdditionalLibraries.Container,
                    Key = inputs.HBaseConfiguration.AdditionalLibraries.Key
                };
            }
        }

        private static void ConfigStormComponent(StormComponent storm, HDInsight.ClusterCreateParametersV2 inputs)
        {
            storm.StormConfiguration.AddRange(inputs.StormConfiguration.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));
        }


        private static void ConfigSparkComponent(SparkComponent spark, HDInsight.ClusterCreateParametersV2 inputs)
        {
            spark.SparkConfiguration.AddRange(inputs.SparkConfiguration.Select(prop => new Property { Name = prop.Key, Value = prop.Value }));
        }

        private static void ConfigVirtualNetwork(ClusterCreateParameters cluster, HDInsight.ClusterCreateParametersV2 inputs)
        {
            // Check if the virtual network configuration is partially set
            if (string.IsNullOrEmpty(inputs.VirtualNetworkId) ^ string.IsNullOrEmpty(inputs.SubnetName))
            {
                if (inputs.VirtualNetworkId == null)
                {
                    throw new ArgumentException("Subnet name is set however virtual network GUID is not set.");
                }
                else
                {
                    throw new ArgumentException("Virtual newtork GUID is set however subnet name is not set.");
                }
            }

            // Set virtual network configuration if is provided in the input
            if (!string.IsNullOrEmpty(inputs.VirtualNetworkId) && !string.IsNullOrEmpty(inputs.SubnetName))
            {
                VirtualNetworkConfiguration virtualNetworkConf = new VirtualNetworkConfiguration();
                virtualNetworkConf.VirtualNetworkSite = inputs.VirtualNetworkId;
                foreach (var role in cluster.ClusterRoleCollection)
                {
                    AddressAssignment aa = new AddressAssignment();
                    Subnet subnet = new Subnet();
                    subnet.Name = inputs.SubnetName;
                    aa.Subnets.Add(subnet);
                    aa.Role = role;
                    virtualNetworkConf.AddressAssignments.Add(aa);
                }
                cluster.VirtualNetworkConfiguration = virtualNetworkConf;
            }
        }

    }
}

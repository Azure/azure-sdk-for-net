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

using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;

namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;

    /// <summary>
    /// Object that encapsulates all the properties of a List Request.
    /// </summary>
    public sealed class ClusterCreateParametersV2
    {
        /// <summary>
        /// Gets or sets the Name of the cluster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the datacenter location for the cluster.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the StorageName for the default Azure Storage Account.
        /// This account will be used for schemaless paths and the cluster will 
        /// leverage to store some cluster level files.
        /// </summary>
        public string DefaultStorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the StorageKey for the default Azure Storage Account.
        /// This account will be used for schemaless paths and the cluster will 
        /// leverage to store some cluster level files.
        /// </summary>
        public string DefaultStorageAccountKey { get; set; }

        /// <summary>
        /// Gets or sets the StorageContainer for the default Azure Storage Account.
        /// This account will be used for schemaless paths and the cluster will 
        /// leverage to store some cluster level files.
        /// </summary>
        public string DefaultStorageContainer { get; set; }

        /// <summary>
        /// Gets or sets the login for the cluster's user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for the cluster's user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the username for RDP access to the cluster.
        /// </summary>
        public string RdpUsername { get; set; }

        /// <summary>
        /// Gets or sets the password for RDP access to the cluster.
        /// </summary>
        public string RdpPassword { get; set; }

        /// <summary>
        /// Gets or sets the expirt DateTime for RDP access on the cluster.
        /// </summary>
        public DateTime? RdpAccessExpiry { get; set; }

        /// <summary>
        /// Gets or sets the number of workernodes for the cluster.
        /// </summary>
        public int ClusterSizeInNodes { get; set; }

        /// <summary>
        /// Gets or sets the version of the HDInsight cluster.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the size of the Head Node.
        /// </summary>
        /// <value>
        /// The size of the head node.
        /// </value>
        public string HeadNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Data Node.
        /// </summary>
        /// <value>
        /// The size of the data node.
        /// </value>
        public string DataNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Zookeeper Node.
        /// </summary>
        /// <value>
        /// The size of the zookeeper node.
        /// </value>
        public string ZookeeperNodeSize { get; set; }

        /// <summary>
        /// Gets additional Azure Storage Account that you want to enable access to.
        /// </summary>
        public Collection<WabStorageAccountConfiguration> AdditionalStorageAccounts { get; private set; }

        /// <summary>
        /// Gets config actions for the cluster.
        /// </summary>
        public Collection<ConfigAction> ConfigActions { get; private set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Oozie.
        /// </summary>
        public Metastore OozieMetastore { get; set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Hive.
        /// </summary>
        public Metastore HiveMetastore { get; set; }

        /// <summary>
        /// Gets the core configuration of this HDInsight cluster.
        /// </summary>
        public ConfigValuesCollection CoreConfiguration { get; private set; }

        /// <summary>
        /// Gets the hdfs configuration of this HDInsight cluster.
        /// </summary>
        public ConfigValuesCollection HdfsConfiguration { get; private set; }

        /// <summary>
        /// Gets the map-reduce configuration of this HDInsight cluster.
        /// </summary>
        public MapReduceConfiguration MapReduceConfiguration { get; internal set; }

        /// <summary>
        /// Gets the hive configuration of this HDInsight cluster.
        /// </summary>
        public HiveConfiguration HiveConfiguration { get; private set; }

        /// <summary>
        /// Gets the core configuration of this HDInsight cluster.
        /// </summary>
        public OozieConfiguration OozieConfiguration { get; private set; }

        /// <summary>
        /// Gets the Yarn service configuration of this HDInsight cluster.
        /// </summary>
        public ConfigValuesCollection YarnConfiguration { get; private set; }

        /// <summary>
        /// Gets the HBase service configuration of this HDInsight cluster.
        /// </summary>
        public HBaseConfiguration HBaseConfiguration { get; private set; }

        /// <summary>
        /// Gets the Storm service configuration of this HDInsight cluster.
        /// </summary>
        public ConfigValuesCollection StormConfiguration { get; private set; }

        /// <summary>
        /// Gets the Spark service configuration of this HDInsight cluster.
        /// </summary>
        public ConfigValuesCollection SparkConfiguration { get; private set; }

        /// <summary>
        /// Gets or sets the flavor for a cluster.
        /// </summary>
        public ClusterType ClusterType { get; set; }

        /// <summary>
        /// Gets or sets the timeout period for the SDK to wait when creating a cluster.
        /// </summary>
        public TimeSpan CreateTimeout { get; set; }

        /// <summary>
        /// Gets or sets the virtual network guid for this HDInsight cluster.
        /// </summary>
        public string VirtualNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the subnet name for this HDInsight cluster.
        /// </summary>
        public string SubnetName { get; set; }

        /// <summary>
        /// Gets or sets the type of operating system installed on cluster nodes.
        /// </summary>
        public OSType OSType { get; set; }

        /// <summary>
        /// Gets or sets SSH user name.
        /// </summary>
        public string SshUserName { get; set; }

        /// <summary>
        /// Gets or sets SSH password.
        /// </summary>
        public string SshPassword { get; set; }

        /// <summary>
        /// Gets or sets the public key to be used for SSH.
        /// </summary>
        public string SshPublicKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the ClusterCreateParameters class.
        /// </summary>
        public ClusterCreateParametersV2()
        {
            this.CreateTimeout = TimeSpan.FromHours(2);
            this.AdditionalStorageAccounts = new Collection<WabStorageAccountConfiguration>();
            this.ConfigActions = new Collection<ConfigAction>();
            this.CoreConfiguration = new ConfigValuesCollection();
            this.HiveConfiguration = new HiveConfiguration();
            this.MapReduceConfiguration = new MapReduceConfiguration();
            this.OozieConfiguration = new OozieConfiguration();
            this.HdfsConfiguration = new ConfigValuesCollection();
            this.YarnConfiguration = new ConfigValuesCollection();
            this.HBaseConfiguration = new HBaseConfiguration();
            this.StormConfiguration = new ConfigValuesCollection();
            this.SparkConfiguration = new ConfigValuesCollection();

            // By default create hadoop only cluster unless set otherwise
            this.ClusterType = ClusterType.Hadoop;
            this.HeadNodeSize = VmSize.Large.ToString();
            this.DataNodeSize = VmSize.Large.ToString();
            this.ZookeeperNodeSize = null;

            // By default create Windows clusters
            this.OSType = HDInsight.OSType.Windows;
        }

        public ClusterCreateParametersV2(ClusterCreateParameters versionOneParams) : this()
        {
            this.Name = versionOneParams.Name;
            this.Location = versionOneParams.Location;
            this.DefaultStorageAccountName = versionOneParams.DefaultStorageAccountName;
            this.DefaultStorageAccountKey = versionOneParams.DefaultStorageAccountKey;
            this.DefaultStorageContainer = versionOneParams.DefaultStorageContainer;
            this.UserName = versionOneParams.UserName;
            this.Password = versionOneParams.Password;
            this.ClusterSizeInNodes = versionOneParams.ClusterSizeInNodes;
            this.Version = versionOneParams.Version;
            
            //headnode can be default, setting real value in CCPV2
            this.HeadNodeSize = versionOneParams.HeadNodeSize != NodeVMSize.Default
                ? versionOneParams.HeadNodeSize.ToString()
                : NodeVMSize.Large.ToString(); 

            this.AdditionalStorageAccounts = versionOneParams.AdditionalStorageAccounts;
            this.ConfigActions = versionOneParams.ConfigActions;
            this.OozieMetastore = versionOneParams.OozieMetastore;
            this.HiveMetastore = versionOneParams.HiveMetastore;
            this.CoreConfiguration = versionOneParams.CoreConfiguration;
            this.HdfsConfiguration = versionOneParams.HdfsConfiguration;
            this.MapReduceConfiguration = versionOneParams.MapReduceConfiguration;
            this.HiveConfiguration = versionOneParams.HiveConfiguration;
            this.OozieConfiguration = versionOneParams.OozieConfiguration;
            this.YarnConfiguration = versionOneParams.YarnConfiguration;
            this.HBaseConfiguration = versionOneParams.HBaseConfiguration;
            this.StormConfiguration = versionOneParams.StormConfiguration;
            this.ClusterType = versionOneParams.ClusterType;
            this.CreateTimeout = versionOneParams.CreateTimeout;
            this.VirtualNetworkId = versionOneParams.VirtualNetworkId;
            this.SubnetName = versionOneParams.SubnetName;

            //new parameters in version 2 (default values)
            this.DataNodeSize = VmSize.Large.ToString();
            this.ZookeeperNodeSize = null;

            // By default create Windows clusters
            this.OSType = HDInsight.OSType.Windows;
        }

        /// <summary>
        /// Performs parameter validations
        /// </summary>
        internal void ValidateClusterCreateParameters()
        {
            // if OSType == Linux then Version must be specified
            if (this.OSType == HDInsight.OSType.Linux && string.IsNullOrEmpty(this.Version))
            {
                throw new InvalidOperationException("Cluster version was not supplied and must be specified.");
            }

            // if OSType == Linux then Username must be "admin"
            if (this.OSType == HDInsight.OSType.Linux && this.UserName != "admin")
            {
                throw new NotSupportedException(string.Format("For clusters with OSType {0}, cluster's connectivity username must be admin.", this.OSType));
            }

            // if OSType == Linux then ClusterType must be Hadoop
            if (this.OSType == HDInsight.OSType.Linux && this.ClusterType != ClusterType.Hadoop)
            {
                throw new NotSupportedException(string.Format("For clusters with OSType {0}, cluster type must be {1}.", this.OSType, ClusterType.Hadoop));
            }

            // if OSType == Linux then VirtualNetworkId must not be set/specified
            if (this.OSType == HDInsight.OSType.Linux && !String.IsNullOrEmpty(this.VirtualNetworkId))
            {
                throw new NotSupportedException(string.Format("For clusters with OSType {0}, setting virtual network Id is not supported.", this.OSType));
            }

            // if OSType == Linux then SubnetName must not be set/specified
            if (this.OSType == HDInsight.OSType.Linux && !String.IsNullOrEmpty(this.SubnetName))
            {
                throw new NotSupportedException(string.Format("For clusters with OSType {0}, setting subnet name is not supported.", this.OSType));
            }

            // if OSType == Windows then SSH credentials must not be specified
            if (this.OSType == HDInsight.OSType.Windows && !String.IsNullOrEmpty(this.SshUserName))
            {
                throw new NotSupportedException(string.Format("SSH is not supported for clusters with OSType {0}", this.OSType));
            }

            // If OSType == Linux then SSH credentials must be specified
            if (this.OSType == HDInsight.OSType.Linux && String.IsNullOrEmpty(this.SshUserName))
            {
                throw new InvalidOperationException(string.Format("SSH credentials must be specified for clusters with OSType {0}.", this.OSType));
            }

            // if SSH user name is specified then either SSH password or SSH public key must be specified
            if (!String.IsNullOrEmpty(this.SshUserName) && String.IsNullOrEmpty(this.SshPassword) && String.IsNullOrEmpty(this.SshPublicKey))
            {
                throw new InvalidOperationException("For SSH connectivity, either a password or a public key is required. If a password is specified, the public key will be ignored.");
            }

            // If OSType == Linux, Zookeeper node size must not be set
            if (this.OSType == HDInsight.OSType.Linux && !String.IsNullOrEmpty(ZookeeperNodeSize))
            {
                throw new InvalidOperationException(String.Format("Zookeeper node size is not configurable and must not be set for clusters with OS Type {0}.", this.OSType));
            }
        }
    }
}

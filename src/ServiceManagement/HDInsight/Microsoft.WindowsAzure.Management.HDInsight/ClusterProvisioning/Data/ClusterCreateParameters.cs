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
    using System.Collections.ObjectModel;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;

    /// <summary>
    /// Object that encapsulates all the properties of a List Request.
    /// </summary>
    public sealed class ClusterCreateParameters
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
        public NodeVMSize HeadNodeSize { get; set; }

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
        /// Initializes a new instance of the ClusterCreateParameters class.
        /// </summary>
        public ClusterCreateParameters()
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
            
            // By default create hadoop only cluster unless set otherwise
            this.ClusterType = ClusterType.Hadoop; 
            this.HeadNodeSize = NodeVMSize.Default;
        }
    }
}
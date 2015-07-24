// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Management.HDInsight.Models
{
    public partial class ClusterCreateParameters
    {
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
        /// Gets or sets the expiry DateTime for RDP access on the cluster.
        /// </summary>
        public DateTime RdpAccessExpiry { get; set; }

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
        public string WorkerNodeSize { get; set; }

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
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        /// <summary>
        /// Gets config actions for the cluster.
        /// </summary>
        public Dictionary<ClusterNodeType, List<ScriptAction>> ScriptActions { get; private set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Oozie.
        /// </summary>
        public Metastore OozieMetastore { get; set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Hive.
        /// </summary>
        public Metastore HiveMetastore { get; set; }

        /// <summary>
        /// Gets the configurations of this HDInsight cluster.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> Configurations { get; private set; }
        
        /// <summary>
        /// Gets or sets the flavor for a cluster.
        /// </summary>
        public HDInsightClusterType ClusterType { get; set; }
        
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
        /// Gets or sets the prinicipal to be used for getting OAuth2 token to access Azure DataLake (ADL)
        /// </summary>
        public Principal Principal { get; set; }

        /// <summary>
        /// Initializes a new instance of the ClusterCreateParameters class.
        /// </summary>
        public ClusterCreateParameters()
        {
            this.AdditionalStorageAccounts = new Dictionary<string, string>();
            this.Configurations = new Dictionary<string, Dictionary<string, string>>();
            this.ScriptActions =  new Dictionary<ClusterNodeType, List<ScriptAction>>();

            //set defaults
            this.Version = "default";
            this.OSType = OSType.Windows;
        }
    }
}

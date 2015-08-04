//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// The properties for the HDInsight linkedService.
    /// </summary>
    [AdfTypeName("HDInsightOnDemand")]
    public class HDInsightOnDemandLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Optional. Specify additional Azure storage accounts that need to be
        /// accessible from the cluster.
        /// </summary>
        public IList<string> AdditionalLinkedServiceNames { get; set; }

        /// <summary>
        /// Required. HDInsight cluster size.
        /// </summary>
        [AdfRequired]
        public int ClusterSize { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for core
        /// configuration.
        /// </summary>
        public IDictionary<string, string> CoreConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the flavor for the HDInsight cluster.
        /// </summary>
        public string ClusterType { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for HBase
        /// configuration.
        /// </summary>
        public IDictionary<string, string> HBaseConfiguration { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for HDFS configuration.
        /// </summary>
        public IDictionary<string, string> HdfsConfiguration { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for HIVE
        /// configuration.
        /// </summary>
        public IDictionary<string, string> HiveConfiguration { get; set; }

        /// <summary>
        /// Optional. The name of the blob container that contains custom jar
        /// files for HIVE consumption.
        /// </summary>
        public string HiveCustomLibrariesContainer { get; set; }

        /// <summary>
        /// Required. Storage service name.
        /// </summary>
        [AdfRequired]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for MapReduce configuration.
        /// </summary>
        public IDictionary<string, string> MapReduceConfiguration { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for Oozie configuration.
        /// </summary>
        public IDictionary<string, string> OozieConfiguration { get; set; }

        /// <summary>
        /// The Spark service configuration of this HDInsight cluster.
        /// </summary>
        public IDictionary<string, string> SparkConfiguration { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for Storm
        /// configuration.
        /// </summary>
        public IDictionary<string, string> StormConfiguration { get; set; }

        /// <summary>
        /// Required. Time to live.
        /// </summary>
        [AdfRequired]
        public TimeSpan TimeToLive { get; set; }

        /// <summary>
        /// Optional. HDInsight version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The name of Azure SQL linked service that point to the HCatalog database.
        /// </summary>
        public string HcatalogLinkedServiceName { get; set; }

        /// <summary>
        /// Define what options to use for generating/altering table for an input and output tables for an HDInsight activity
        /// </summary>
        public HDInsightSchemaGenerationProperties SchemaGeneration { get; set; }

        /// <summary>
        /// Gets or sets the size of the Data Node.
        /// </summary>
        public string DataNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Head Node.
        /// </summary>
        public string HeadNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Zookeeper Node.
        /// </summary>
        public string ZookeeperNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the type of operating system installed on cluster nodes.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets SSH password.
        /// </summary>
        public string SshPassword { get; set; }

        /// <summary>
        /// Gets or sets the public key to be used for SSH.
        /// </summary>
        public string SshPublicKey { get; set; }

        /// <summary>
        /// Gets or sets SSH user name.
        /// </summary>
        public string SshUserName { get; set; }

        /// <summary>
        /// Optional. Allows user to override default values for YARN
        /// configuration.
        /// </summary>
        public IDictionary<string, string> YarnConfiguration { get; set; }

        /// <summary>
        /// Initializes a new instance of the HDInsightOnDemandLinkedService
        /// class.
        /// </summary>
        public HDInsightOnDemandLinkedService()
        {
            this.AdditionalLinkedServiceNames = new List<string>();
            this.CoreConfiguration = new Dictionary<string, string>();
            this.HBaseConfiguration = new Dictionary<string, string>();
            this.HdfsConfiguration = new Dictionary<string, string>();
            this.HiveConfiguration = new Dictionary<string, string>();
            this.MapReduceConfiguration = new Dictionary<string, string>();
            this.OozieConfiguration = new Dictionary<string, string>();
            this.StormConfiguration = new Dictionary<string, string>();
            this.YarnConfiguration = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightOnDemandLinkedService
        /// class with required arguments.
        /// </summary>
        public HDInsightOnDemandLinkedService(int clusterSize, TimeSpan timeToLive, string linkedServiceName)
            : this()
        {
            Ensure.IsNotNullOrEmpty(linkedServiceName, "linkedServiceName");

            this.ClusterSize = clusterSize;
            this.TimeToLive = timeToLive;
            this.LinkedServiceName = linkedServiceName;
        }
    }
}

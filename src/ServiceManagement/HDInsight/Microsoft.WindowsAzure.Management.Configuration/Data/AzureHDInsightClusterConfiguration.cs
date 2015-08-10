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
namespace Microsoft.WindowsAzure.Management.Configuration.Data
{
    /// <summary>
    /// Structure to represent the configuration of an HDInsight cluster.
    /// </summary>
    public class AzureHDInsightClusterConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the AzureHDInsightClusterConfiguration class.
        /// </summary>
        public AzureHDInsightClusterConfiguration()
        {
            this.Core = new CoreSiteConfigurationCollection();
            this.Hive = new HiveSiteConfigurationCollection();
            this.Hdfs = new HdfsSiteConfigurationCollection();
            this.MapReduce = new MapReduceSiteConfigurationCollection();
            this.Oozie = new OozieSiteConfigurationCollection();
            this.Yarn = new YarnSiteConfigurationCollection();
        }

        /// <summary>
        /// Gets a structure to represent core-site.xml settings.
        /// </summary>
        public CoreSiteConfigurationCollection Core { get; private set; }

        /// <summary>
        /// Gets a structure to represent hdfs-site.xml settings.
        /// </summary>
        public HdfsSiteConfigurationCollection Hdfs { get; private set; }

        /// <summary>
        /// Gets a structure to represent mapred-site.xml settings.
        /// </summary>
        public MapReduceSiteConfigurationCollection MapReduce { get; private set; }

        /// <summary>
        /// Gets a structure to represent hive-site.xml settings.
        /// </summary>
        public HiveSiteConfigurationCollection Hive { get; private set; }

        /// <summary>
        /// Gets a structure to represent oozie-site.xml settings.
        /// </summary>
        public OozieSiteConfigurationCollection Oozie { get; private set; }

        /// <summary>
        /// Gets a structure to represent yarn-site.xml settings.
        /// </summary>
        public YarnSiteConfigurationCollection Yarn { get; private set; }

    }
}

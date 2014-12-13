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
namespace Microsoft.WindowsAzure.Management.Configuration
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.Configuration.Data;

    /// <summary>
    /// Contract to specify access to configuration options for core hadoop services on AzureHDInsight clusters.
    /// </summary>
    public interface IAzureHDInsightClusterConfigurationAccessor
    {
        /// <summary>
        /// Gets the configuration options for core hadoop services on AzureHDInsight clusters. 
        /// </summary>
        /// <returns>The configuration options for core hadoop services on AzureHDInsight clusters. </returns>
        Task<CoreSiteConfigurationCollection> GetCoreServiceConfiguration();

        /// <summary>
        /// Gets the configuration options for core hadoop services on AzureHDInsight clusters. 
        /// </summary>
        /// <returns>The configuration options for core hadoop services on AzureHDInsight clusters. </returns>
        Task<MapReduceSiteConfigurationCollection> GetMapReduceServiceConfiguration();

        /// <summary>
        /// Gets the configuration options for core hadoop services on AzureHDInsight clusters. 
        /// </summary>
        /// <returns>The configuration options for core hadoop services on AzureHDInsight clusters. </returns>
        Task<HdfsSiteConfigurationCollection> GetHdfsServiceConfiguration();

        /// <summary>
        /// Gets the configuration options for core hadoop services on AzureHDInsight clusters. 
        /// </summary>
        /// <returns>The configuration options for core hadoop services on AzureHDInsight clusters. </returns>
        Task<HiveSiteConfigurationCollection> GetHiveServiceConfiguration();

        /// <summary>
        /// Gets the configuration options for core hadoop services on AzureHDInsight clusters. 
        /// </summary>
        /// <returns>The configuration options for core hadoop services on AzureHDInsight clusters. </returns>
        Task<OozieSiteConfigurationCollection> GetOozieServiceConfiguration();
    }
}

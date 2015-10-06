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
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Configuration;
    using Microsoft.WindowsAzure.Management.Configuration.Data;

    internal class AzureHDInsightClusterConfigurationAccessorSimulator : IAzureHDInsightClusterConfigurationAccessor
    {
        private readonly BasicAuthCredential credentials;
        private const string PathToProcDetails = "";

        public AzureHDInsightClusterConfigurationAccessorSimulator(IJobSubmissionClientCredential credentials)
        {
            var remoteCreds = credentials as BasicAuthCredential;
            Assert.IsNotNull(remoteCreds);
            this.credentials = remoteCreds;
        }

        public Task<CoreSiteConfigurationCollection> GetCoreServiceConfiguration()
        {
            var simulatedContainer = HDInsightManagementRestSimulatorClient.GetCloudServiceInternal(this.credentials.Server.Host.Split('.').First());
            return Task.FromResult(simulatedContainer.Configuration.Core);
        }

        public Task<MapReduceSiteConfigurationCollection> GetMapReduceServiceConfiguration()
        {
            var simulatedContainer = HDInsightManagementRestSimulatorClient.GetCloudServiceInternal(this.credentials.Server.Host.Split('.').First());
            return Task.FromResult(simulatedContainer.Configuration.MapReduce);
        }

        public Task<HdfsSiteConfigurationCollection> GetHdfsServiceConfiguration()
        {
            var simulatedContainer = HDInsightManagementRestSimulatorClient.GetCloudServiceInternal(this.credentials.Server.Host.Split('.').First());
            return Task.FromResult(simulatedContainer.Configuration.Hdfs);
        }

        public Task<HiveSiteConfigurationCollection> GetHiveServiceConfiguration()
        {
            var simulatedContainer = HDInsightManagementRestSimulatorClient.GetCloudServiceInternal(this.credentials.Server.Host.Split('.').First());
            return Task.FromResult(simulatedContainer.Configuration.Hive);
        }

        public Task<OozieSiteConfigurationCollection> GetOozieServiceConfiguration()
        {
            var simulatedContainer = HDInsightManagementRestSimulatorClient.GetCloudServiceInternal(this.credentials.Server.Host.Split('.').First());
            return Task.FromResult(simulatedContainer.Configuration.Oozie);
        }
    }
}

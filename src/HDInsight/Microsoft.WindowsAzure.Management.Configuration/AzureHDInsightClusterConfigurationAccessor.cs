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
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.Configuration.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class AzureHDInsightClusterConfigurationAccessor : IAzureHDInsightClusterConfigurationAccessor
    {
        private BasicAuthCredential credentials;

        public AzureHDInsightClusterConfigurationAccessor(BasicAuthCredential connectionCredentials)
        {
            this.credentials = connectionCredentials;
        }

        public async Task<CoreSiteConfigurationCollection> GetCoreServiceConfiguration()
        {
            var componentAddress = await this.GetComponentSettingAddress();
            var restClient = ServiceLocator.Instance.Locate<IAzureHDInsightConfigurationRestClientFactory>().Create(this.credentials);
            var componentSettingResponse = await restClient.GetComponentSettings(componentAddress.Core);
            var converter = new PayloadConverter();
            return converter.DeserializeSettingsCollection<CoreSiteConfigurationCollection>(componentSettingResponse.Content);
        }

        public async Task<MapReduceSiteConfigurationCollection> GetMapReduceServiceConfiguration()
        {
            var componentAddress = await this.GetComponentSettingAddress();
            var restClient = ServiceLocator.Instance.Locate<IAzureHDInsightConfigurationRestClientFactory>().Create(this.credentials);
            var componentSettingResponse = await restClient.GetComponentSettings(componentAddress.Core);
            var converter = new PayloadConverter();
            return converter.DeserializeSettingsCollection<MapReduceSiteConfigurationCollection>(componentSettingResponse.Content);
        }

        public async Task<HdfsSiteConfigurationCollection> GetHdfsServiceConfiguration()
        {
            var componentAddress = await this.GetComponentSettingAddress();
            var restClient = ServiceLocator.Instance.Locate<IAzureHDInsightConfigurationRestClientFactory>().Create(this.credentials);
            var componentSettingResponse = await restClient.GetComponentSettings(componentAddress.Core);
            var converter = new PayloadConverter();
            return converter.DeserializeSettingsCollection<HdfsSiteConfigurationCollection>(componentSettingResponse.Content);
        }

        public async Task<HiveSiteConfigurationCollection> GetHiveServiceConfiguration()
        {
            var componentAddress = await this.GetComponentSettingAddress();
            var restClient = ServiceLocator.Instance.Locate<IAzureHDInsightConfigurationRestClientFactory>().Create(this.credentials);
            var componentSettingResponse = await restClient.GetComponentSettings(componentAddress.Core);
            var converter = new PayloadConverter();
            return converter.DeserializeSettingsCollection<HiveSiteConfigurationCollection>(componentSettingResponse.Content);
        }

        public async Task<OozieSiteConfigurationCollection> GetOozieServiceConfiguration()
        {
            var componentAddress = await this.GetComponentSettingAddress();
            var restClient = ServiceLocator.Instance.Locate<IAzureHDInsightConfigurationRestClientFactory>().Create(this.credentials);
            var componentSettingResponse = await restClient.GetComponentSettings(componentAddress.Core);
            var converter = new PayloadConverter();
            return converter.DeserializeSettingsCollection<OozieSiteConfigurationCollection>(componentSettingResponse.Content);
        }

        internal async Task<ComponentSettingAddress> GetComponentSettingAddress()
        {
            var restClient = ServiceLocator.Instance.Locate<IAzureHDInsightConfigurationRestClientFactory>().Create(this.credentials);
            var componentResponse = await restClient.GetComponentSettingsAddress();
            var converter = new PayloadConverter();
            return converter.DeSerializeComponentSettingAddresses(componentResponse.Content);
        }
    }
}

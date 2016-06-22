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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.Configuration
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Configuration;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class PayloadConverterTests : IntegrationTestBase
    {
        private string RootCallsPayload = "{" +
"	\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/\"," +
"	\"items\": [{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=core-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"core-site\", " +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}" +
"	}," +
"	{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=hdfs-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"hdfs-site\"," +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}" +
"	}," +
"	{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=mapred-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"mapred-site\"," +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}" +
"	}," +
"	{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=hive-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"hive-site\"," +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}" +
"	}," +
"	{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=oozie-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"oozie-site\"," +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}" +
"	}," +
"	{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=Sqoop_-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"Sqoop_-site\"," +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}" +
"	}]" +
"}";

        private string CoreSiteSettings = "{" +
"	\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=core-site&tag=default\"," +
"	\"items\": [{" +
"		\"href\": \"https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=core-site&tag=default\"," +
"		\"tag\": \"default\"," +
"		\"type\": \"core-site\"," +
"		\"Config\": {" +
"			\"cluster_name\": \"apitestclusterrdfe19-laureny\"" +
"		}," +
"		\"properties\": {" +
"			\"fs.default.name\": \"asv://apitestclusterrdfe19-laureny@storageaccount.blob.core.windows.net\"," +
"			\"hadoop.tmp.dir\": \"/hdfs/tmp\"," +
"			\"fs.trash.interval\": \"60\"," +
"			\"fs.checkpoint.dir\": \"c:\\hdfs\\2nn\"," +
"			\"fs.checkpoint.edits.dir\": \"c:\\hdfs\\2nn\"," +
"			\"fs.checkpoint.period\": \"1800\"," +
"			\"fs.checkpoint.size\": \"67108864\"," +
"			\"fs.azure.selfthrottling.write.factor\": \"1.000000\"," +
"			\"fs.azure.buffer.dir\": \"/tmp\"," +
"			\"topology.script.file.name\": \"E:\\approot\\bin\\AzureTopology.exe\"," +
"			\"io.file.buffer.size\": \"131072\"," +
"			\"hadoop.proxyuser.hdp.groups\": \"oozieusers\"," +
"			\"dfs.namenode.rpc-address\": \"hdfs://namenodehost:9000\"," +
"			\"slave.host.name\": \"\"," +
"			\"hadoop.proxyuser.hdp.hosts\": \"headnodehost\"," +
"			\"fs.azure.selfthrottling.read.factor\": \"1.000000\"," +
"			\"fs.azure.account.key.storageaccount.blob.core.windows.net\": \"fakekey\"" +
"		}" +
"	}]" +
"}";
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanDeserializeRootCall()
        {
            var converter = new PayloadConverter();
            var componentSettingsAddresses = converter.DeSerializeComponentSettingAddresses(RootCallsPayload);
            Assert.IsNotNull(componentSettingsAddresses);
            Assert.AreEqual(componentSettingsAddresses.Core.OriginalString, "https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=core-site&tag=default");
            Assert.AreEqual(componentSettingsAddresses.Hive.OriginalString, "https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=hive-site&tag=default");
            Assert.AreEqual(componentSettingsAddresses.Hdfs.OriginalString, "https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=hdfs-site&tag=default");
            Assert.AreEqual(componentSettingsAddresses.MapReduce.OriginalString, "https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=mapred-site&tag=default");
            Assert.AreEqual(componentSettingsAddresses.Oozie.OriginalString, "https://apitestclusterrdfe19-fake.hdinsight.azure.net:563/ambari/api/v1/clusters/apitestclusterrdfe19-laureny/configurations/?type=oozie-site&tag=default");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanDeserializeCoreSettings()
        {
            var converter = new PayloadConverter();
            var coreComponentSettings = converter.DeserializeCoreSettings(CoreSiteSettings);
            Assert.IsNotNull(coreComponentSettings);
            AssertSettingValue(coreComponentSettings, "hadoop.tmp.dir", "/hdfs/tmp");
            AssertSettingValue(coreComponentSettings, "fs.trash.interval", "60");
        }

        private void AssertSettingValue(IEnumerable<KeyValuePair<string, string>> configuration, string name, string value)
        {
            var config = configuration.FirstOrDefault(c => c.Key == name);
            Assert.IsNotNull(config, name);
        }
    }
}

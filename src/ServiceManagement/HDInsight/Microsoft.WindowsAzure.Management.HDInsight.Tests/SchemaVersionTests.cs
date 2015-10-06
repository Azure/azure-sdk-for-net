using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class SchemaVersionTests : IntegrationTestBase
    {
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
        public void GetSubscriptionSchemaVersionsTest()
        {
            var capabilities = new List<string>
            {
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK"
            };
            var schemaVersions = SchemaVersionUtils.GetSchemaVersionsForSubscription(capabilities);
            Assert.AreEqual(schemaVersions.Count, 3);

            capabilities = new List<string>
            {
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_4_SDK_blah",
                "fake"
            };
            schemaVersions = SchemaVersionUtils.GetSchemaVersionsForSubscription(capabilities);
            Assert.AreEqual(schemaVersions.Count, 3);
        }

        [TestMethod]
        public void GetSchemaVersionsTest()
        {
            var capabilities = new List<string>
            {
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK"
            };
            var schemaVersion = SchemaVersionUtils.GetSchemaVersion(capabilities);
            Assert.AreEqual(schemaVersion, "3.0");

            capabilities = new List<string>
            {
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK",
            };
            schemaVersion = SchemaVersionUtils.GetSchemaVersion(capabilities);
            Assert.AreEqual(schemaVersion, "2.0");

            capabilities = new List<string>
            {
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK",
                "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_4_SDK",
            };
            schemaVersion = SchemaVersionUtils.GetSchemaVersion(capabilities);
            Assert.AreEqual(schemaVersion, "1.0");
        }
    }
}

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
using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    

    [TestClass]
    public class VersionFinderClientTests : IntegrationTestBase
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
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void ICanPerformA_PositiveCase_VersionFinderXmlParsing()
        {
            var capabilities = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("CAPABILITY_VERSION_1.2","CAPABILITY_VERSION_1.2.0.0.LARGESKU-AMD64-134231"),
                    new KeyValuePair<string, string>("CAPABILITY_VERSION_1.0","CAPABILITY_VERSION_1.0"),
                    new KeyValuePair<string, string>("CAPABILITY_VERSION_1.3","CAPABILITY_VERSION_1.3.0.5.LARGESKU-AMD64-134231")
                };

            var versions = VersionFinderClient.ParseVersions(capabilities).Select(v => v.Version).ToList();
            Assert.AreEqual(3, versions.Count);
            Assert.AreEqual(1, versions.Count(version => version == "1.2"));
            Assert.AreEqual(1, versions.Count(version => version == "1.0"));
            Assert.AreEqual(1, versions.Count(version => version == "1.3"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void ICanPerformA_PositiveAdditionalProppertiesXmlParsing_VersionFinderXmlParsing()
        {
            var capabilities = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("CAPABILITY_VERSION_1.2.0.0.LARGESKU-AMD64-134231","CAPABILITY_VERSION_1.2.0.0.LARGESKU-AMD64-134231"),
                    new KeyValuePair<string, string>("MyProperty","MyProperty")
                };
            var versions = VersionFinderClient.ParseVersions(capabilities);
            Assert.AreEqual(1, versions.Count);
            Assert.AreEqual("1.2.0.0.LARGESKU-AMD64-134231", versions[0].Version);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void UserSuppliedVersionTooLow()
        {
            var userVersion = new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1, 0, 0);
            var client = new VersionFinderClient(IntegrationTestBase.GetValidCredentials(), GetAbstractionContext(), false);

            Assert.AreEqual(client.GetVersionStatus(userVersion), VersionStatus.Obsolete);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void UserSuppliedVersionTooHigh()
        {
            var userVersion = new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor + 1, 0, 0);
            var client = new VersionFinderClient(IntegrationTestBase.GetValidCredentials(), GetAbstractionContext(), false);

            Assert.AreEqual(client.GetVersionStatus(userVersion), VersionStatus.ToolsUpgradeRequired);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void UserSuppliedVersionValid()
        {
            var userVersion = new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor + 1, 0, 0);
            var client = new VersionFinderClient(IntegrationTestBase.GetValidCredentials(), GetAbstractionContext(), false);
            Assert.AreEqual(client.GetVersionStatus(userVersion), VersionStatus.Compatible);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void UserSuppliedVersionValid_LowLimit()
        {
            var userVersion = new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor, 0, 0);
            var client = new VersionFinderClient(IntegrationTestBase.GetValidCredentials(), GetAbstractionContext(), false);
            Assert.AreEqual(client.GetVersionStatus(userVersion), VersionStatus.Compatible);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("VersionFinderClient")]
        public void UserSuppliedVersionValid_HighLimit()
        {
            var userVersion = new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor, 0, 0);
            var client = new VersionFinderClient(IntegrationTestBase.GetValidCredentials(), GetAbstractionContext(), false);
            Assert.AreEqual(client.GetVersionStatus(userVersion), VersionStatus.Compatible);
        }
    }
}
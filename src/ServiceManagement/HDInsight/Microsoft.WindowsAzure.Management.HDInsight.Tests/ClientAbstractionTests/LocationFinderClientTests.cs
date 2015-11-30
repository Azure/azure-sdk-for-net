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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;


    [TestClass]
    public class LocationFinderClientTests : IntegrationTestBase
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
        [TestCategory("LocationFinderClient")]
        public void ICanPerformA_PositiveCase_LocationFinderDictionaryParsing()
        {
            var capabilities = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("CAPABILITY_REGION_EAST_US","East US"),
                    new KeyValuePair<string, string>("CAPABILITY_REGION_EAST_US_2","East US 2"),
                    new KeyValuePair<string, string>("CAPABILITY_REGION_NORTH_EUROPE","North Europe")
                };
            var locations = LocationFinderClient.ParseLocations(capabilities, "CAPABILITY_REGION_");
            Assert.AreEqual(3, locations.Count);
            Assert.AreEqual(1, locations.Count(location => location == "East US"));
            Assert.AreEqual(1, locations.Count(location => location == "East US 2"));
            Assert.AreEqual(1, locations.Count(location => location == "North Europe"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("LocationFinderClient")]
        public void ICanPerformA_PositiveAdditionalProppertiesXmlParsing_LocationFinderDictionaryParsing()
        {
            var capabilities = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("CAPABILITY_REGION_EAST_US","East US"),
                    new KeyValuePair<string, string>("P","P"),
                };
            var locations = LocationFinderClient.ParseLocations(capabilities, "CAPABILITY_REGION_");
            Assert.AreEqual(1, locations.Count);
            Assert.AreEqual("East US", locations[0]);
        }
    }
}
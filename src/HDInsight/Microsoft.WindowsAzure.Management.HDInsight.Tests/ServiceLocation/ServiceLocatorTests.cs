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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ServiceLocation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Internal;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Moq;

    [TestClass]
    public class ServiceLocatorTests : IntegrationTestBase
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

        public class EchoServiceForTestSimulation : IEchoServiceForTest
        {
            public string Echo(string input)
            {
                return new string(input.Reverse().ToArray());
            }
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void NewServiceLocatorCanRegisterAType()
        {
            var simManager = ServiceLocator.Locate<IServiceLocationSimulationManager>();
            simManager.MockingLevel = ServiceLocationMockingLevel.ApplyNoMocking;
            var result = ServiceLocator.Locate<IEchoServiceForTest>().Echo("abcde");
            Assert.AreEqual("abcde", result);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void NewServiceLocatorCanOverrideWithASimulation()
        {
            var simManager = ServiceLocator.Locate<IServiceLocationSimulationManager>();
            simManager.MockingLevel = ServiceLocationMockingLevel.ApplyNoMocking;
            simManager.RegisterType<IEchoServiceForTest, EchoServiceForTestSimulation>();
            var result = ServiceLocator.Locate<IEchoServiceForTest>().Echo("abcde");
            Assert.AreEqual("abcde", result);
            simManager.MockingLevel = ServiceLocationMockingLevel.ApplyTestRunMockingOnly;
            result = ServiceLocator.Locate<IEchoServiceForTest>().Echo("abcde");
            Assert.AreEqual("edcba", result);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void NewServiceLocatorCanOverrideWithAnIndividualTest()
        {
            var guid = Guid.NewGuid();
            var echoService = new Mock<IEchoServiceForTest>(MockBehavior.Loose);
            echoService.Setup(e => e.Echo(It.IsAny<string>())).Returns(guid.ToString());
            
            var simManager = ServiceLocator.Locate<IServiceLocationSimulationManager>();
            var testManager = ServiceLocator.Locate<IServiceLocationIndividualTestManager>();
            testManager.Override<IEchoServiceForTest>(echoService.Object);

            simManager.MockingLevel = ServiceLocationMockingLevel.ApplyNoMocking;
            simManager.RegisterType<IEchoServiceForTest, EchoServiceForTestSimulation>();
            var result = ServiceLocator.Locate<IEchoServiceForTest>().Echo("abcde");
            Assert.AreEqual("abcde", result);
            simManager.MockingLevel = ServiceLocationMockingLevel.ApplyTestRunMockingOnly;
            result = ServiceLocator.Locate<IEchoServiceForTest>().Echo("abcde");
            Assert.AreEqual("edcba", result);

            simManager.MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
            result = ServiceLocator.Locate<IEchoServiceForTest>().Echo("abcde");
            Assert.AreEqual(guid.ToString(), result);
        }

    }
}

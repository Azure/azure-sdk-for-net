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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests
{
    using System.Collections.Generic;
    using System.Reflection;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class NoDuplicateRegistrars : IntegrationTestBase
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
        [TestCategory(TestRunMode.CheckIn)]
        public void NoAssemblyHasDuplicateRegistrars()
        {
            var sweeper = new ServiceLocationAssemblySweep();
            var types = sweeper.GetRegistrarTypes();
            List<Assembly> found = new List<Assembly>();
            foreach (var type in types)
            {
                if (found.Contains(type.Key.Assembly))
                {
                    Assert.Fail("No assembly can contain more than one Ioc Registrar");
                }
                found.Add(type.Key.Assembly);
            }
        }
    }
}

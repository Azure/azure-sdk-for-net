// -----------------------------------------------------------------------------------------
// <copyright file="GeneralTestSample.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

#if RTMD
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Microsoft.WindowsAzure.Storage
{
    [TestClass]
    public class GeneralTestSample : TestBase
    {
        [TestMethod]
        /// [Description("A sample test to show how to skip cloud env.")]
        [TestCategory("SampleTest")]
        [TestCategory("SampleTest")]
        [TestCategory("NonSmoke")]
        public void SkipForCloudTestSample()
        {
            // This is also an example to show how the two test projects share the same unit test code. 
            TestHelper.ValidateIfTestSupportTargetTenant(TenantType.DevStore | TenantType.DevFabric);
        }
    }
}
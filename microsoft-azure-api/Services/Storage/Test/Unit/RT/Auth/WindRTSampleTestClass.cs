// -----------------------------------------------------------------------------------------
// <copyright file="WindRTSampleTestClass.cs" company="Microsoft">
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
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Reflection;

namespace Microsoft.WindowsAzure.Storage
{
    [TestClass]
    public partial class AuthTest : TestBase
    {
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }

        //Use TestCleanup to run code before each test runs
        [TestInitialize()]
        public void TestInitialize()
        {

        }


        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestCleanup()
        {

        }

        [TestMethod]
        /// [Description("A sample auth test.")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.Smoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsSampleTestMethod()
        {
            StorageCredentials creds = new StorageCredentials(TargetTenantConfig.AccountName,
                TargetTenantConfig.AccountKey);

            Assert.IsNotNull(creds.AccountName);
            Assert.IsFalse(creds.IsAnonymous);
            Assert.IsTrue(creds.IsSharedKey);
            Assert.IsFalse(creds.IsSAS);
        }
    }
}
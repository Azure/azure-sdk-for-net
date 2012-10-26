// -----------------------------------------------------------------------------------------
// <copyright file="ExceptionHResultTest.cs" company="Microsoft">
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Core.Util;
using System.IO;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class ExceptionHResultTest : TestBase
    {
        readonly CloudQueueClient DefalutQueueClient = new CloudQueueClient(new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint), TestBase.StorageCredentials);

        [TestMethod]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueCreateNegativeBadRequestAsync()
        {
            try
            {
                string name = "ABCD";
                CloudQueue queue = DefalutQueueClient.GetQueueReference(name);
                await queue.CreateAsync();
                Assert.Fail();
            }
            catch (Exception e) 
            {
                Assert.AreEqual(WindowsAzureErrorCode.HttpBadRequest, e.HResult);
            }
        }
    }
}

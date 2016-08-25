//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using Microsoft.Azure.Management.Intune.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Management.Intune.Tests.ScenarioTests
{
    [Collection("Intune Tests")]
    public class WipeScenarioTests:TestBase
    {
        /// <summary>
        /// Test class for Wipe operations.
        /// </summary>
        static WipeScenarioTests()
        {
            IntuneClientHelper.InitializeEnvironment();
        }

        /// <summary>
        /// Verifies that Wipe operation is triggered
        /// </summary>
        [Fact]
        public void ShouldWipeDevices()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.WipeScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                var userId = TestContextHelper.GetAdUserFromTestContext("AADUserId");
                var userDevices = client.GetMAMUserDevices(IntuneClientHelper.AsuHostName, userId).ToList();                
                var wipeResult = client.WipeMAMUserDeviceWithHttpMessagesAsync(IntuneClientHelper.AsuHostName, userId, userDevices.ElementAt(0).Name).GetAwaiter().GetResult();
                string wipeOperationResult = wipeResult.Body.Value;
                Assert.Equal(System.Net.HttpStatusCode.OK, wipeResult.Response.StatusCode);
                Assert.NotNull(wipeResult);
                
                var operationResult = client.GetOperationResults(IntuneClientHelper.AsuHostName).ToList();
                Assert.True(operationResult.Count > 0, "operationResult.Count is ZERO");                
            }
        }
    }
}

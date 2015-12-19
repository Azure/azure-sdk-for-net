//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests
{
    using System;
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Test;

    public class TestsFixture : TestBase
    {
        public TestsFixture()
        {
            // place any initialization like environment settings here
#if DEBUG
            //Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");

            //Environment.SetEnvironmentVariable(
            //    "TEST_CSM_ORGID_AUTHENTICATION",
            //    "SubscriptionId=;Environment=;AADTenant=");

            //Environment.SetEnvironmentVariable(
            //    "TEST_ORGID_AUTHENTICATION",
            //    "SubscriptionId=;Environment=");
#endif

            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();

                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient();
                resourceManagementClient.TryRegisterSubscriptionForResource();
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        public void Dispose()
        {
            Cleanup();
        }

        protected void Cleanup()
        {
            UndoContext.Current.UndoAll();
        }
    }
}
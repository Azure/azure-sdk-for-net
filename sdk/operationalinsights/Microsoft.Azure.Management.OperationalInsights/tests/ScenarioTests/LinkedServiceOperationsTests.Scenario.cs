// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using OperationalInsights.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Test.ScenarioTests
{
    public class LinkedServiceOperationsTests : TestBase
    {
        private const string resourceGroupName = "OIHyak7814";
        private const string automationAccountName = "sdkTestAccount";
        private const string automationAccountName2 = "testAcc";
        private const string workspaceName = "AzTest6856";

        [Fact]
        public void CanCreateUpdateDeleteLinkedService()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);
                var subId = client.SubscriptionId;
               
                var linkedServiceName = "Automation";
                var accountResourceIdFromat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Automation/automationAccounts/{2}";
                var accountResourceId = string.Format(accountResourceIdFromat, subId, resourceGroupName, automationAccountName);
                
                // Create a linked service
                var createParameters = new LinkedService
                {
                    ResourceId = accountResourceId
                };
                var createResponse = client.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, linkedServiceName, createParameters);
                TestHelper.ValidateLinkedService(createParameters, createResponse);

                // Get the linked service
                var getResponse = client.LinkedServices.Get(resourceGroupName, workspaceName, linkedServiceName);
                TestHelper.ValidateLinkedService(createParameters, getResponse);

                // List the linked services in the workspace
                var listResponse = client.LinkedServices.ListByWorkspace(resourceGroupName, workspaceName);
                Assert.Single(listResponse);
                Assert.Single(listResponse.Where(w => w.ResourceId.Equals(accountResourceId, StringComparison.OrdinalIgnoreCase)));

                var accountResourceId2 = string.Format(accountResourceIdFromat, subId, resourceGroupName, automationAccountName2);
                var updateParameters = new LinkedService
                {
                    ResourceId = accountResourceId2
                };

                // Perform an update on one of the linked service
                var updateResponse = client.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, linkedServiceName, updateParameters);
                TestHelper.ValidateLinkedService(updateParameters, updateResponse);

                // Delete a linked service
                client.LinkedServices.Delete(resourceGroupName, workspaceName, linkedServiceName);
            }
        }

        [Fact]
        public void LinkedServiceCreateFailsWithoutWorkspace()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = TestHelper.GetOperationalInsightsManagementClient(this, context);
                var subId = client.SubscriptionId;

                string linkedServiceName = "Automation";
                string workspaceName = TestUtilities.GenerateName("AzSDKTest");

                var accountResourceIdFromat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Automation/automationAccounts/{2}";
                var accountResourceId = string.Format(accountResourceIdFromat, subId, resourceGroupName, "testAccount");

                var createParameters = new LinkedService
                {
                    ResourceId = accountResourceId
                };

                // Create a linked service on a non-existent workspace
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, linkedServiceName, createParameters));
            }
        }
    }
}
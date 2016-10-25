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
using Microsoft.Azure.Test;
using OperationalInsights.Tests.Helpers;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace OperationalInsights.Tests.OperationTests
{
    public class LinkedServiceOperationsTest : TestBase
    {
        private const string resourceGroupName = "OIHyak7814";
        private const string automationAccountName = "sdkTestAccount";
        private const string automationAccountName2 = "testAcc";
        private const string workspaceName = "AzTest6856";

        [Fact]
        public void CanCreateUpdateDeleteLinkedService()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = TestHelper.GetOperationalInsightsManagementClient(handler);
                var subId = client.Credentials.SubscriptionId;
               
                var linkedServiceName = "Automation";
                var accountResourceIdFromat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Automation/automationAccounts/{2}";
                var accountResourceId = string.Format(accountResourceIdFromat, subId, resourceGroupName, automationAccountName);
                
                // Create a linked service
                var createParameters = new LinkedServiceCreateOrUpdateParameters
                {
                    Name = linkedServiceName,
                    Properties = new LinkedServiceProperties() { ResourceId = accountResourceId }
                };
                var createResponse = client.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, createParameters);
                Assert.True(HttpStatusCode.Created == createResponse.StatusCode || HttpStatusCode.OK == createResponse.StatusCode);
                TestHelper.ValidateLinkedService(createParameters, createResponse.LinkedService);

                // Get the linked service
                var getResponse = client.LinkedServices.Get(resourceGroupName, workspaceName, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                TestHelper.ValidateLinkedService(createParameters, getResponse.LinkedService);

                // List the linked services in the workspace
                var listResponse = client.LinkedServices.List(resourceGroupName, workspaceName);
                Assert.True(HttpStatusCode.OK == listResponse.StatusCode);
                Assert.Equal(1, listResponse.LinkedServices.Count);
                Assert.Null(listResponse.NextLink);
                Assert.Single(listResponse.LinkedServices.Where(w => w.Properties.ResourceId.Equals(accountResourceId, StringComparison.OrdinalIgnoreCase)));

                var accountResourceId2 = string.Format(accountResourceIdFromat, subId, resourceGroupName, automationAccountName2);
                var updateParameters = new LinkedServiceCreateOrUpdateParameters
                {
                    Name = linkedServiceName,
                    Properties = new LinkedServiceProperties() { ResourceId = accountResourceId2 }
                };

                // Perform an update on one of the linked service
                var updateResponse = client.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, updateParameters);
                Assert.True(HttpStatusCode.OK == updateResponse.StatusCode);
                TestHelper.ValidateLinkedService(updateParameters, updateResponse.LinkedService);

                // Delete a linked service
                var deleteResponse = client.LinkedServices.Delete(resourceGroupName, workspaceName, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Verify the linkedService source is gone
                getResponse = client.LinkedServices.Get(resourceGroupName, workspaceName, linkedServiceName);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.Null(getResponse.LinkedService);
            }
        }

        [Fact]
        public void LinkedServiceCreateFailsWithoutWorkspace()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var client = TestHelper.GetOperationalInsightsManagementClient(handler);
                var subId = client.Credentials.SubscriptionId;

                string linkedServiceName = "Automation";
                string workspaceName = TestUtilities.GenerateName("AzSDKTest");

                var accountResourceIdFromat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Automation/automationAccounts/{2}";
                var accountResourceId = string.Format(accountResourceIdFromat, subId, resourceGroupName, "testAccount");

                var createParameters = new LinkedServiceCreateOrUpdateParameters
                {
                    Name = linkedServiceName,
                    Properties = new LinkedServiceProperties() { ResourceId = accountResourceId }
                };

                // Create a linked service on a non-existent workspace
                TestHelper.VerifyCloudException(HttpStatusCode.NotFound, () => client.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, createParameters));
            }
        }
    }
}

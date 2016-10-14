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

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StreamAnalytics.Tests.OperationTests
{
    public class SubscriptionOperationsTest : TestBase
    {
        [Fact]
        public void Test_SubscriptionOperations_E2E()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("StreamAnalytics");
                string serviceLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetStreamAnalyticsManagementClient(handler);

                try
                {
                    ResourceGroup resourceGroup = new ResourceGroup() { Location = serviceLocation };
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                    SubscriptionQuotasGetResponse subscriptionQuotasGetResponse = client.Subscriptions.GetQuotas(serviceLocation);
                    Assert.Equal(HttpStatusCode.OK, subscriptionQuotasGetResponse.StatusCode);
                    Assert.Equal(1, subscriptionQuotasGetResponse.Value.FirstOrDefault().Properties.CurrentCount);
                    Assert.Equal(50, subscriptionQuotasGetResponse.Value.FirstOrDefault().Properties.MaxCount);
                }
                finally
                {
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}
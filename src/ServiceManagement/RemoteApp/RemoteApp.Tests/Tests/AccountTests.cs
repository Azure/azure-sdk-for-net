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
//

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp account related tests
    /// </summary>
    public class AccountTests : RemoteAppTestBase
    {
        /// <summary>
        /// Testing for querying the account
        /// </summary>
        [Fact]
        public void CanGetAccount()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();
                GetAccountResult accountResult = client.Account.Get();

                Assert.NotNull(accountResult);
                Assert.NotNull(accountResult.Details);
                Assert.False(string.IsNullOrWhiteSpace(accountResult.Details.ClientUrl), "The client URL is empty.");
                Assert.False(string.IsNullOrWhiteSpace(accountResult.Details.EndUserFeedName), "The Workspace name is empty.");
            }
        }

        /// <summary>
        /// Test for updating the account information
        /// </summary>
        [Fact]
        public void CanSetAccount()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();
                GetAccountResult accountResult = client.Account.Get();

                Assert.NotNull(accountResult);
                Assert.NotNull(accountResult.Details);
                
                string oldName = accountResult.Details.EndUserFeedName;
                string newName = "TestWorkspaceName";

                AccountDetailsParameter param = new AccountDetailsParameter();
                param.AccountInfo = new AccountUpdateDetails();//accountResult.Details;
                param.AccountInfo.EndUserFeedName = newName;

                OperationResultWithTrackingId result = client.Account.Set(param);
                Assert.NotNull(result);

                accountResult = client.Account.Get();
                Assert.Equal(newName, accountResult.Details.EndUserFeedName);

                param.AccountInfo.EndUserFeedName = oldName;
                result = client.Account.Set(param);
                Assert.NotNull(result);
            }
        }

        /// <summary>
        /// Testing for querying the account billing plans
        /// </summary>
        [Fact]
        public void CanGetBillingPlans()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();
                ListBillingPlansResult billingPlansResult = client.Account.ListBillingPlans();

                Assert.NotNull(billingPlansResult);
                Assert.NotEmpty(billingPlansResult.PlanList);
            }
        }

        /// <summary>
        /// Testing for querying the account level enabled features
        /// </summary>
        [Fact]
        public void CanGetEnabledFeatures()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();
                EnabledFeaturesResult enabledFeaturesResult = client.Account.GetEnabledFeatures();

                Assert.NotNull(enabledFeaturesResult);
                Assert.NotEmpty(enabledFeaturesResult.EnabledFeatures);
            }
        }
    }
}
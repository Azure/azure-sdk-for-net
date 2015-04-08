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

using Microsoft.Azure.Common.Authentication.Models;
using System;
using Xunit;
namespace Common.Authentication.Test
{
    public class AzureProfileTests
    {
        [Fact]
        public void GetsCorrectContext()
        {
            AzureProfile profile = new AzureProfile();
            string accountId = "accountId";
            Guid subscriptionId = Guid.NewGuid();
            profile.Accounts.Add(accountId, new AzureAccount { Id = accountId, Type = AzureAccount.AccountType.User });
            profile.Subscriptions.Add(subscriptionId, new AzureSubscription
            {
                Account = accountId,
                Environment = EnvironmentName.AzureChinaCloud,
                Name = "hello",
                Id = subscriptionId 
            });
            profile.DefaultSubscription = profile.Subscriptions[subscriptionId];
            AzureContext context = profile.Context;

            Assert.Equal(accountId, context.Account.Id);
            Assert.Equal(subscriptionId, context.Subscription.Id);
            Assert.Equal(EnvironmentName.AzureChinaCloud, context.Environment.Name);
        }
    }
}
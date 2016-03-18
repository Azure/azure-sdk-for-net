using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using RemoteApp.Tests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class AccountTests : RemoteAppTestBase
    {        
        [Fact (Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void GetAccountLocationsTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapperList account = null;
            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);
                raClient.ArmNamespace = "Microsoft.RemoteApp";

                account = raClient.Account.Get();

                Assert.NotNull(account);
                //Assert.NotNull(account.LocationList);
                //foreach (Location loc in account.LocationList)
                //{
                //    Assert.IsType(typeof(Location), loc);
                //}
            }
        }

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void GetAccountBillingPlansTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper account = null;
            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);
                raClient.ArmNamespace = "Microsoft.RemoteApp";
                account = raClient.Account.Get().Value.FirstOrDefault();

                Assert.NotNull(account);
                Assert.NotNull(account.BillingPlans);
                foreach (BillingPlan plan in account.BillingPlans)
                {
                    Assert.IsType(typeof(BillingPlan), plan);
                }
            }
        }

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void UpdateAccountTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper result = null;
            AccountDetailsWrapper update = new AccountDetailsWrapper();
            update.Tags = new Dictionary<string, string>();
            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);

                result = raClient.Account.Get().Value.FirstOrDefault();

                update.Location = "WestUs";
                update.AccountInfo.WorkspaceName = result.AccountInfo.WorkspaceName == 
                    "Test Workspace1" ? "Test Workspace2" : "Test Workspace1";
                update.AccountInfo.PrivacyUrl = null;

                Assert.NotNull(result);
                Assert.NotEqual(update.AccountInfo.WorkspaceName, result.AccountInfo.WorkspaceName);

                result = raClient.Account.Update(update).Value.FirstOrDefault();

                result = raClient.Account.Get().Value.FirstOrDefault();

                Assert.NotNull(result);
                Assert.Equal(update.AccountInfo.WorkspaceName, result.AccountInfo.WorkspaceName);
            }
        }

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void AccountActivateBillingTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper result = null;
            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);
                raClient.ArmNamespace = "Microsoft.RemoteApp";

                raClient.Account.ActivateBilling();

                result = raClient.Account.Get().Value.FirstOrDefault();

                Assert.NotNull(result);
                Assert.IsType(typeof(AccountDetailsWrapper), result);
            }
        }
    }
}

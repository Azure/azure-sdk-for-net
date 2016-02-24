using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class AccountTests : RemoteAppTestBase
    {        
        [Fact]
        public void GetAccountLocationsTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper account = null;

            //using (var undoContext = UndoContext.Current)
            {
                //undoContext.Start();

                raClient = GetClient();

                account = raClient.Account.GetAccountInfo().Value.FirstOrDefault();

                Assert.NotNull(account);
                Assert.NotNull(account.LocationList);
                foreach (Location loc in account.LocationList)
                {
                    Assert.IsType(typeof(Location), loc);
                }
            }
        }

        [Fact]
        public void GetAccountBillingPlansTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper account = null;

            //using (var undoContext = UndoContext.Current)
            {
                //undoContext.Start();

                raClient = GetClient();
                account = raClient.Account.GetAccountInfo().Value.FirstOrDefault();

                Assert.NotNull(account);
                Assert.NotNull(account.BillingPlans);
                foreach (BillingPlan plan in account.BillingPlans)
                {
                    Assert.IsType(typeof(BillingPlan), plan);
                }
            }
        }

        [Fact]
        public void UpdateAccountTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper result = null;
            AccountDetailsWrapper update = new AccountDetailsWrapper();
            update.Tags = new Dictionary<string, string>();

           // using (var undoContext = UndoContext.Current)
            {
                //undoContext.Start();

                raClient = GetClient();

                result = raClient.Account.GetAccountInfo().Value.FirstOrDefault();

                update.Location = "WestUs";
                update.AccountInfo.WorkspaceName = result.AccountInfo.WorkspaceName == 
                    "Test Workspace1" ? "Test Workspace2" : "Test Workspace1";
                update.AccountInfo.PrivacyUrl = null;

                Assert.NotNull(result);
                Assert.NotEqual(update.AccountInfo.WorkspaceName, result.AccountInfo.WorkspaceName);

                result = raClient.Account.UpdateAccount(update).Value.FirstOrDefault();

                result = raClient.Account.GetAccountInfo().Value.FirstOrDefault();

                Assert.NotNull(result);
                Assert.Equal(update.AccountInfo.WorkspaceName, result.AccountInfo.WorkspaceName);
            }
        }

        [Fact]
        public void AccountActivateBillingTest()
        {
            RemoteAppManagementClient raClient = null;
            AccountDetailsWrapper result = null;

            //using (var undoContext = UndoContext.Current)
            {
                //undoContext.Start();

                raClient = GetClient();

                raClient.Account.ActivateAccountBilling();

                result = raClient.Account.GetAccountInfo().Value.FirstOrDefault();

                Assert.NotNull(result);
                Assert.IsType(typeof(AccountDetailsWrapper), result);
            }
        }
    }
}

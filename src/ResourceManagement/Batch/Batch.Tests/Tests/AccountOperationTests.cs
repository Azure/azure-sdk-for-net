using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Test;
//using Microsoft.WindowsAzure.Testing;
using Xunit;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System.Threading;
using Microsoft.WindowsAzure.Management;

namespace Microsoft.Azure.Batch.Tests
{
    public class AccountOperationTests : TestBase
    {
        [Fact(Skip = "Can't get auth right for locations call")]
        public void CanGetLocationsForAzureBatch()
        {
            using (var undoContext = UndoContext.Current)
            {
                //undoContext.Start();

                //var mgmtClient = ManagementTestUtilities.GetManagementClient(this);
                ////var batchClient = TestBase.GetServiceClient<BatchManagementClient>(new CSMTestEnvironmentFactory());
                
                ////var resGrp = TestUtilities.GenerateName("resGrp");
                ////var acctName = TestUtilities.GenerateName("acctName");      // needs to be DNS compliant

                ////var region = "West US";

                //undoContext.Stop();
            }
        }

        [Fact(Skip = "Can't get auth right just yet")]
        public void CanCreateBatchAccountSuccessfully()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                //var mgmtClient = ManagementTestUtilities.GetManagementClient(this);
                var batchClient = GetServiceClient<BatchManagementClient>(new CSMTestEnvironmentFactory());

                var batchAccountName = TestUtilities.GenerateName("acctName");      // needs to be DNS prefix name compliant
                //var resourceGroupName = TestUtilities.GenerateName("resGrp");
                //var location = mgmtClient.GetDefaultLocation("batch");
                var resourceGroupName = "zfeng";
                var location = "westus";

                Assert.DoesNotThrow(() =>
                {
                    var createTags = new Dictionary<string, string>();
                    createTags.Add("abc", "123");

                    var createResult = batchClient.Accounts.Create(resourceGroupName, batchAccountName, new BatchAccountCreateParameters
                    {
                        Location = location,
                        Tags = createTags
                    });

                    Assert.Equal(createResult.Resource.Location, location);
                    Assert.NotEmpty(createResult.Resource.Properties.AccountEndpoint);    // TODO: pull prefix name from endpoint and compare to account name
                    Assert.Equal(createResult.Resource.Properties.ProvisioningState, AccountProvisioningState.Succeeded);

                    var updateTags = new Dictionary<string, string>();
                    updateTags.Add("newabc", "123");

                    var updateResult = batchClient.Accounts.Update(resourceGroupName, batchAccountName, new BatchAccountUpdateParameters
                    {
                        Tags = updateTags
                    });

                    // TODO: validate tags were added

                    var getResult = batchClient.Accounts.Get(resourceGroupName, batchAccountName);
                    Assert.Equal(getResult.Resource.Name, batchAccountName);
                    Assert.Equal(getResult.Resource.Location, location);

                    var listKeysResult = batchClient.Accounts.ListKeys(resourceGroupName, batchAccountName);
                    Assert.NotEmpty(listKeysResult.PrimaryKey);
                    Assert.NotEmpty(listKeysResult.SecondaryKey);

                    var oldPrimaryKey = listKeysResult.PrimaryKey;

                    var regenKeyResponse = batchClient.Accounts.RegenerateKey(resourceGroupName, batchAccountName, new BatchAccountRegenerateKeyParameters
                    {
                        KeyName = AccountKeyType.Primary
                    });

                    Assert.NotEqual(oldPrimaryKey, regenKeyResponse.PrimaryKey);

                    var listResponse = batchClient.Accounts.List(new AccountListParameters
                    {
                        ResourceGroupName = resourceGroupName
                    });

                    var matchingBatchAccount = listResponse.Accounts.First(m => string.Equals(m.Name, batchAccountName, StringComparison.Ordinal));
                    Assert.NotNull(matchingBatchAccount);

                    var listAllResult = batchClient.Accounts.List(null);
                    Assert.True(listAllResult.Accounts.Count > 0);
                });

                undoContext.Stop();
            }
        }
    }
}

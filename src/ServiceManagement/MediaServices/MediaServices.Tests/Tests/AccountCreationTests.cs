using System;
using System.Linq;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;
using Microsoft.WindowsAzure.Management.MediaServices;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System.Threading;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Testing;

namespace MediaServices.Tests.Tests
{
    public class AccountCreationTests : TestBase
    {
        public MediaServicesManagementClient GetMediaServicesManagementClient()
        {
            return TestBase.GetServiceClient<MediaServicesManagementClient>(new RDFETestEnvironmentFactory());
        }

        public ManagementClient GetManagementClient()
        {
            return TestBase.GetServiceClient<ManagementClient>(new RDFETestEnvironmentFactory());
        }

        public StorageManagementClient GetStorageManagementClient()
        {
            return TestBase.GetServiceClient<StorageManagementClient>(new RDFETestEnvironmentFactory());
        }

        [Fact]
        public void CanGetLocationsForMediaServices()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = GetManagementClient();
                Assert.DoesNotThrow(() =>
                {
                    string location = ManagementTestUtilities.GetDefaultLocation(client, "HighMemory");
                    Assert.NotNull(location);
                });
            }
        }

        [Fact(Skip = "Unable to re-record test. Server error - Request to a downlevel service failed.")]
        public void CanCreateMediaServicesAccountSuccessfully()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var mode = HttpMockServer.GetCurrentMode();

                var managementClient = GetManagementClient();
                var storageClient = GetStorageManagementClient();
                var mediaClient = GetMediaServicesManagementClient();
                var storageAccountName = TestUtilities.GenerateName();
                var mediaAccountName = TestUtilities.GenerateName();
                
                string location = ManagementTestUtilities.GetDefaultLocation(managementClient, "HighMemory");

                Assert.DoesNotThrow(() =>
                {
                    try
                    {
                        storageClient.StorageAccounts.Create(new StorageAccountCreateParameters
                        {
                            Name = storageAccountName,
                            AccountType = "Standard_LRS",
                            Location = location,
                        });
                        var storageResult = storageClient.StorageAccounts.Get(storageAccountName);
                        var blobEndpoint = storageResult.StorageAccount.Properties.Endpoints.First();

                        var keyResult = storageClient.StorageAccounts.GetKeys(storageAccountName);
                        StorageAccountGetResponse storageStatus = null;
                        int tries = 0;
                        do
                        {
                            TestUtilities.Wait(TimeSpan.FromSeconds(5));
                            storageStatus = storageClient.StorageAccounts.Get(storageAccountName);
                            ++tries;
                        } while (storageStatus.StorageAccount.Properties.Status != StorageAccountStatus.Created &&
                                 tries < 10);

                        mediaClient.Accounts.Create(new MediaServicesAccountCreateParameters
                        {
                            AccountName = mediaAccountName,
                            BlobStorageEndpointUri = blobEndpoint,
                            StorageAccountName = storageAccountName,
                            StorageAccountKey = keyResult.PrimaryKey,
                            Region = location
                        });

                        var mediaGetResult = mediaClient.Accounts.Get(mediaAccountName);
                        Assert.Equal(mediaGetResult.Account.AccountName, mediaAccountName);
                        Assert.Equal(mediaGetResult.Account.AccountRegion, location);
                        Assert.Equal(mediaGetResult.Account.StorageAccountName, storageAccountName);


                        mediaClient.Accounts.RegenerateKey(mediaAccountName, MediaServicesKeyType.Primary);

                        var mediaAccountList = mediaClient.Accounts.List();
                        var matchingMediaAccount =
                            mediaAccountList.First(
                                m => string.Equals(m.Name, mediaAccountName, StringComparison.Ordinal));
                        Assert.NotNull(matchingMediaAccount);
                    }
                    finally
                    {
                        TestUtilities.Wait(3000);
                        TestUtilities.IgnoreExceptions(() => mediaClient.Accounts.Delete(mediaAccountName));
                        TestUtilities.IgnoreExceptions(() => storageClient.StorageAccounts.Delete(storageAccountName));
                    }
                });
            }
        }
    }
}

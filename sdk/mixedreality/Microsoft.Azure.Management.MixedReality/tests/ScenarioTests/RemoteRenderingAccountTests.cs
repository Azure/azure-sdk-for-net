using Microsoft.Azure.Management.MixedReality;
using Microsoft.Azure.Management.MixedReality.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using System.Diagnostics;
using System.Net;
using Xunit;

namespace MixedReality.Tests
{
    public sealed class RemoteRenderingAccountTests : MixedRealityTests
    {
        public const string RemoteRenderingAccountName = "NetSdkTests";
        public const string Location = "EastUs2";

        [Fact]
        [Trait("Name", "TestRemoteRenderingAccountOperations")]
        public void TestRemoteRenderingAccountOperations()
        {
            var resourceGroup = new ResourceGroup
            {
                Name = "MixedRealityNetSdkTests",
                Location = Location
            };

            var account = new RemoteRenderingAccount
            {
                Location = Location,
            };

            using (var context = StartTest())
            {
                var operations = Client.RemoteRenderingAccounts;

                try
                {
                    resourceGroup = ArmClient.ResourceGroups.CreateOrUpdate(resourceGroup.Name, resourceGroup);

                    // Create
                    AssertRemoteRenderingAccountNotExist(operations, resourceGroup.Name, RemoteRenderingAccountName);

                    account = operations.Create(resourceGroup.Name, RemoteRenderingAccountName, account);

                    Assert.Equal(RemoteRenderingAccountName, account.Name);
                    Assert.Equal(Location, account.Location);

                    // Read
                    account = operations.Get(resourceGroup.Name, RemoteRenderingAccountName);

                    Assert.Equal(RemoteRenderingAccountName, account.Name);
                    Assert.Equal(Location, account.Location);

                    // Primary Key
                    var oldKey = operations.ListKeys(resourceGroup.Name, account.Name).PrimaryKey;
                    var newKey = operations.RegenerateKeys(resourceGroup.Name, account.Name, 1).PrimaryKey;
                    Assert.NotEqual(oldKey, newKey);

                    // Secondary Key
                    oldKey = operations.ListKeys(resourceGroup.Name, account.Name).SecondaryKey;
                    newKey = operations.RegenerateKeys(resourceGroup.Name, account.Name, 2).SecondaryKey;
                    Assert.NotEqual(oldKey, newKey);

                    // Delete
                    operations.Delete(resourceGroup.Name, account.Name);

                    AssertRemoteRenderingAccountNotExist(operations, resourceGroup.Name, RemoteRenderingAccountName);
                }
                catch (CloudException e)
                {
                    Debug.Print(e.ToString());
                }
                finally
                {
                    // Delete is idempotent
                    operations.Delete(resourceGroup.Name, RemoteRenderingAccountName);

                    ArmClient.ResourceGroups.Delete(resourceGroup.Name);
                }
            }
        }

        private static void AssertRemoteRenderingAccountNotExist(IRemoteRenderingAccountsOperations operations, string resourceGroupName, string remoteRenderingAccountName)
        {
            try
            {
                operations.Get(resourceGroupName, remoteRenderingAccountName);
            }
            catch (CloudException e)
            {
                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
            }
        }
    }
}


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
    public sealed class ObjectAnchorsAccountTests : MixedRealityTests
    {
        public const string ObjectAnchorsAccountName = "NetSdkTests";
        public const string Location = "EastUs2";

        [Fact]
        [Trait("Name", "TestObjectAnchorsAccountOperations")]
        public void TestObjectAnchorsAccountOperations()
        {
            var resourceGroup = new ResourceGroup
            {
                Name = "MixedRealityNetSdkTests",
                Location = Location
            };

            var account = new ObjectAnchorsAccount
            {
                Location = Location,
            };

            using (var context = StartTest())
            {
                var operations = Client.ObjectAnchorsAccounts;

                try
                {
                    resourceGroup = ArmClient.ResourceGroups.CreateOrUpdate(resourceGroup.Name, resourceGroup);

                    // Create
                    AssertObjectAnchorsAccountNotExist(operations, resourceGroup.Name, ObjectAnchorsAccountName);

                    account = operations.Create(resourceGroup.Name, ObjectAnchorsAccountName, account);

                    Assert.Equal(ObjectAnchorsAccountName, account.Name);
                    Assert.Equal(Location, account.Location);

                    // Read
                    account = operations.Get(resourceGroup.Name, ObjectAnchorsAccountName);

                    Assert.Equal(ObjectAnchorsAccountName, account.Name);
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

                    AssertObjectAnchorsAccountNotExist(operations, resourceGroup.Name, ObjectAnchorsAccountName);
                }
                catch (CloudException e)
                {
                    Debug.Print(e.ToString());
                }
                finally
                {
                    // Delete is idempotent
                    operations.Delete(resourceGroup.Name, ObjectAnchorsAccountName);

                    ArmClient.ResourceGroups.Delete(resourceGroup.Name);
                }
            }
        }

        private static void AssertObjectAnchorsAccountNotExist(IObjectAnchorsAccountsOperations operations, string resourceGroupName, string objectAnchorsAccountName)
        {
            try
            {
                operations.Get(resourceGroupName, objectAnchorsAccountName);
            }
            catch (CloudException e)
            {
                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
            }
        }
    }
}


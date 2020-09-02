using Microsoft.Azure.Management.MixedReality;
using Microsoft.Azure.Management.MixedReality.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using System.Net;
using Xunit;

namespace MixedReality.Tests
{
    public sealed class SpatialAnchorsAccountTests : MixedRealityTests
    {
        public const string SpatialAnchorsAccountName = "NetSdkTests";
        public const string Location = "EastUs2";

        [Fact]
        [Trait("Name", "TestSpatialAnchorsAccountOperations")]
        public void TestSpatialAnchorsAccountOperations()
        {
            var resourceGroup = new ResourceGroup
            {
                Name = "MixedRealityNetSdkTests",
                Location = Location
            };

            var account = new SpatialAnchorsAccount
            {
                Location = Location
            };

            using (var context = StartTest())
            {
                var operations = Client.SpatialAnchorsAccounts;

                try
                {
                    resourceGroup = ArmClient.ResourceGroups.CreateOrUpdate(resourceGroup.Name, resourceGroup);

                    // Create
                    AssertSpatialAnchorsAccountNotExist(operations, resourceGroup.Name, SpatialAnchorsAccountName);

                    account = operations.Create(resourceGroup.Name, SpatialAnchorsAccountName, account);

                    Assert.Equal(SpatialAnchorsAccountName, account.Name);
                    Assert.Equal(Location, account.Location);

                    // Read
                    account = operations.Get(resourceGroup.Name, SpatialAnchorsAccountName);

                    Assert.Equal(SpatialAnchorsAccountName, account.Name);
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

                    AssertSpatialAnchorsAccountNotExist(operations, resourceGroup.Name, SpatialAnchorsAccountName);
                }
                finally
                {
                    // Delete is idempotent
                    operations.Delete(resourceGroup.Name, SpatialAnchorsAccountName);

                    ArmClient.ResourceGroups.Delete(resourceGroup.Name);
                }
            }
        }

        private static void AssertSpatialAnchorsAccountNotExist(ISpatialAnchorsAccountsOperations operations, string resourceGroupName, string spatialAnchorsAccountName)
        {
            try
            {
                operations.Get(resourceGroupName, spatialAnchorsAccountName);
            }
            catch (CloudException e)
            {
                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
            }
        }
    }
}


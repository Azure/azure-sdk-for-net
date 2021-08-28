#region Snippet:Managing_Locks_Namespaces
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample5_ManagingLocks
    {
        private Subscription subscription;
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateLock()
        {
            #region Snippet:Managing_Locks_CreateLock
            ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject = (await lockContainer.CreateOrUpdateAsync("myLock", mgmtLockObjectData)).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateLockForVirtualNetwork()
        {
            string vnName = "myVnet";
            GenericResourceData vnData = new GenericResourceData(Location.WestUS2)
            {
                Properties = new JsonObject()
                {
                    {"addressSpace", new JsonObject()
                        {
                            {"addressPrefixes", new List<string>(){"10.0.0.0/16" } }
                        }
                    }
                }
            };
            ResourceIdentifier vnId = resourceGroup.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", vnName);
            GenericResource myVNet = await subscription.GetGenericResources().CreateOrUpdateAsync(vnId, vnData);
            #region Snippet:Managing_Locks_CreateLockForVirtualNetwork
            ManagementLockObjectContainer saLockContainer = myVNet.GetManagementLocks();
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject = (await saLockContainer.CreateOrUpdateAsync("myStorageAccountLock", mgmtLockObjectData)).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetAllLocks()
        {
            #region Snippet:Managing_Locks_ListLocks
            ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
            AsyncPageable<ManagementLockObject> locks = lockContainer.GetAllAsync();
            await foreach (var myLock in locks)
            {
                Console.WriteLine(myLock.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteLock()
        {
            #region Snippet:Managing_Locks_DeleteLock
            ManagementLockObjectContainer lockContainer = resourceGroup.GetManagementLocks();
            ManagementLockObject mgmtLockObject = (await lockContainer.GetAsync("myLock")).Value;
            await mgmtLockObject.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Managing_Locks_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #endregion
            this.subscription = subscription;

            #region Snippet:Managing_Locks_GetResourceGroupContainer
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}

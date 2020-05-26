using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public class ManagerOperationsTests : StorSimpleTestBase
    {
        public ManagerOperationsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestStorSimpleManagerOperations()
        {
            this.ManagerName = TestConstants.ManagerForManagerOperationTests;

            try
            {
                //create StorSimple Manager
                var manager = CreateManager(TestConstants.ManagerForManagerOperationTests);

                //Get Device Registration Key
                var registrationKey = GetDeviceRegistrationKey();

                //regenerate activation key
                var newActivationKey = RegenerateActivationKey();

                //update tag for Storsimple Manager
                var tagName = "TagName";
                var tagValue = "ForSDKTest";
                var updatedManager = UpdateManager(ManagerName, tagName, tagValue);

                //list all StorSimple managers in subscription
                var managersInSubscriptions = ListManagerBySubscription();

                //list all StorSimple managers in resourceGroup
                var managersInResourceGroup = ListManagerByResourceGroup();

                //get and update ExtendedInfo
                var updatedExtendedInfo = GetAndUpdateManagerExtendedInfo();

                //delete ExtendedInfo
                DeleteManagerExtendedInfo(this.ManagerName);

                //delete StorSimple Manager and validate deletion
                DeleteManagerAndValidate(this.ManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private Manager CreateManager(string managerName)
        {
            Manager resourceToCreate = new Manager()
            {
                Location = "westus",
                CisIntrinsicSettings = new ManagerIntrinsicSettings()
                {
                    Type = ManagerType.GardaV1
                }
            };

            Manager manager = this.Client.Managers.CreateOrUpdate(
                                    resourceToCreate,
                                    this.ResourceGroupName,
                                    managerName);

            return manager;
        }

        private string GetDeviceRegistrationKey()
        {
            return this.Client.Managers.GetDeviceRegistrationKey(this.ResourceGroupName, this.ManagerName);
        }

        private string RegenerateActivationKey()
        {
            return this.Client.Managers.RegenerateActivationKey(this.ResourceGroupName, this.ManagerName).ActivationKey;
        }

        private IEnumerable<Manager> ListManagerBySubscription()
        {
            return this.Client.Managers.List();
        }

        private IEnumerable<Manager> ListManagerByResourceGroup()
        {
            return this.Client.Managers.ListByResourceGroup(this.ResourceGroupName);
        }

        private ManagerExtendedInfo GetAndUpdateManagerExtendedInfo()
        {
            var extendedInfo = this.Client.Managers.GetExtendedInfo(this.ResourceGroupName, this.ManagerName);
            extendedInfo.Algorithm = "SHA256";
            string ifMatchETag = extendedInfo.Etag;

            return this.Client.Managers.UpdateExtendedInfo(
                extendedInfo,
                this.ResourceGroupName,
                this.ManagerName,
                ifMatchETag);
        }

        private Manager UpdateManager(string managerName, string tagName, string tagValue)
        {
            Dictionary<string, string> Tags = new Dictionary<string, string>();
            Tags.Add(tagName, tagValue);
            ManagerPatch managerPatch = new ManagerPatch(Tags);

            var manager = this.Client.Managers.Update(
                managerPatch,
                this.ResourceGroupName,
                managerName);

            return manager;
        }

        /// <summary>
        /// Deletes the manager-extendedInfo for the specified StorSimple Manager.
        /// </summary>
        private void DeleteManagerExtendedInfo(string managerName)
        {
            var extendedInfo = this.Client.Managers.GetExtendedInfo(
                this.ResourceGroupName,
                managerName);

            this.Client.Managers.DeleteExtendedInfo(
                this.ResourceGroupName,
                managerName);
        }

        /// <summary>
        /// Deletes the specified StorSimple Manager and validates deletion.
        /// </summary>
        private void DeleteManagerAndValidate(string managerName)
        {
            var managerToDelete = this.Client.Managers.Get(
                this.ResourceGroupName,
                managerName);

            this.Client.Managers.Delete(
               this.ResourceGroupName,
               managerToDelete.Name);

            var managers = this.Client.Managers.ListByResourceGroup(this.ResourceGroupName);

            var manager = managers.FirstOrDefault(m => m.Name.Equals(managerName));

            Assert.True(manager == null, "Manager deletion was not successful.");
        }
    }
}


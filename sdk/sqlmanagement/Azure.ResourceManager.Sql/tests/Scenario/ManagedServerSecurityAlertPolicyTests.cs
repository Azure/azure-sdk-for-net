// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedServerSecurityAlertPolicyTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedServerSecurityAlertPolicyTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task ManagedServerSecurityAlertPolicyApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            string securityAlertPoliciesName = "Default";
            var collection = managedInstance.GetManagedServerSecurityAlertPolicies();

            // 1.CreateOrUpdate
            ManagedServerSecurityAlertPolicyData data = new ManagedServerSecurityAlertPolicyData()
            {
                State = SecurityAlertsPolicyState.Enabled,
                DisabledAlerts = { },
                EmailAddresses = { },
                SendToEmailAccountAdmins = false,
                RetentionDays = 0,
            };
            var securityAlertPolicie = await collection.CreateOrUpdateAsync(WaitUntil.Completed, securityAlertPoliciesName, data);
            Assert.IsNotNull(securityAlertPolicie.Value.Data);
            Assert.AreEqual(securityAlertPoliciesName, securityAlertPolicie.Value.Data.Name);
            Assert.AreEqual("Enabled", securityAlertPolicie.Value.Data.State.ToString());

            // 2.CheckIfExist
            Assert.IsTrue(await collection.ExistsAsync(securityAlertPoliciesName));

            // 3.Get
            var getsecurityAlertPolicie = await collection.GetAsync(securityAlertPoliciesName);
            Assert.IsNotNull(getsecurityAlertPolicie.Value.Data);
            Assert.AreEqual(securityAlertPoliciesName, getsecurityAlertPolicie.Value.Data.Name);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(securityAlertPoliciesName, list.FirstOrDefault().Data.Name);
        }
    }
}

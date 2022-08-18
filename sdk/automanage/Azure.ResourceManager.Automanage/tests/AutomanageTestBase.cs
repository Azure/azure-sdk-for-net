﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests
{
    public class AutomanageTestBase : ManagementRecordedTestBase<AutomanageTestEnvironment>
    {
        public ArmClient ArmClient { get; private set; }
        public SubscriptionResource Subscription { get; set; }
        protected ResourceGroupCollection ResourceGroups { get; private set; }
        public static AzureLocation DefaultLocation => AzureLocation.EastUS;

        protected AutomanageTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected AutomanageTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            ArmClient = GetArmClient();
            //ResourceMgmtClient = new ResourceManagementClient(new DefaultAzureCredential());
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData data = new ResourceGroupData(location);
            var rg = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, data);
            return rg.Value;
        }

        protected async Task<ConfigurationProfileResource> CreateConfigurationProfile(ConfigurationProfileCollection collection, string profileName)
        {
            string configuration = "{" +
                "\"Antimalware/Enable\":true," +
                "\"Antimalware/EnableRealTimeProtection\":true," +
                "\"Antimalware/RunScheduledScan\":true," +
                "\"Backup/Enable\":true," +
                "\"WindowsAdminCenter/Enable\":false," +
                "\"VMInsights/Enable\":true," +
                "\"AzureSecurityCenter/Enable\":true," +
                "\"UpdateManagement/Enable\":true," +
                "\"ChangeTrackingAndInventory/Enable\":true," +
                "\"GuestConfiguration/Enable\":true," +
                "\"AutomationAccount/Enable\":true," +
                "\"LogAnalytics/Enable\":true," +
                "\"BootDiagnostics/Enable\":true" +
            "}";

            ConfigurationProfileData data = new ConfigurationProfileData(DefaultLocation)
            {
                Configuration = new BinaryData(configuration)
            };

            var newProfile = await collection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            return newProfile.Value;
        }
    }
}

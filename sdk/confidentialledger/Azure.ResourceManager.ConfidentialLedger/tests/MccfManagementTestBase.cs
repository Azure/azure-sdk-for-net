// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.ConfidentialLedger.Models;
using Azure.Core.Diagnostics;
using System;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public abstract class MccfManagementTestBase : ManagementRecordedTestBase<MccfManagementTestEnvironment>
    {
        protected SubscriptionResource Subscription;
        protected string mccfName;

        private readonly string _testResourceGroupPrefix = "sdk-rg-";
        private static readonly AzureLocation s_defaultTestLocation = AzureLocation.SouthCentralUS;
        private string _resourceGroupName;
        private readonly string _testFixtureName;
        private ResourceGroupResource _resourceGroup;

        protected MccfManagementTestBase(bool isAsync, RecordedTestMode mode, string testFixtureName) : base(isAsync, mode)
        {
            _testFixtureName = testFixtureName;
        }

        protected MccfManagementTestBase(bool isAsync, string testFixtureName) : base(isAsync)
        {
            _testFixtureName = testFixtureName;
        }

        [OneTimeSetUp]
        public async Task InitializeTestResources()
        {
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            _resourceGroupName = _testResourceGroupPrefix + _testFixtureName;
            await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed,
                _resourceGroupName, new ResourceGroupData(s_defaultTestLocation));

            await StopSessionRecordingAsync();
        }

        [SetUp]
        public void Setup()
        {
            ArmClient armClient = GetArmClient();
            Subscription = armClient.GetSubscriptionResource(
                new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}"));
            ResourceGroupCollection resourceGroups = Subscription.GetResourceGroups();
            _resourceGroup =  resourceGroups.GetAsync(_resourceGroupName).Result;
            mccfName = TestEnvironment.TestMccfNamePrefix + _testFixtureName;
        }

        /// <summary>
        /// Method fetches the ledger detail provided the ledger name
        /// It looks for the ledger in the resource group configured for the test fixture from where this method was invoked
        /// </summary>
        /// <param name="mccfName"></param>
        /// <returns></returns>
        protected async Task<ManagedCcfResource> GetMccfByName(string mccfName)
        {
            var resourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.ConfidentialLedger/ManagedCCFs/{mccfName}";
            return await _resourceGroup.GetManagedCcfs().GetAsync(new ResourceIdentifier(resourceId).Name);
        }

        /// <summary>
        /// Method takes the ledger name and starts a long running job for creating the confidential ledger
        /// By default it create the ledger in West Europe location
        /// </summary>
        /// <param name="mccfName"></param>
        protected async Task CreateMccf(string mccfName)
        {
            ManagedCcfData mccfData = new ManagedCcfData(new AzureLocation(s_defaultTestLocation))
            {
                Properties = new ManagedCcfProperties()
                {
                    MemberIdentityCertificates =
                    {
                        new ConfidentialLedgerMemberIdentityCertificate()
                        {
                            Certificate = "-----BEGIN CERTIFICATE-----\nMIIBvzCCAUSgAwIBAgIUUYG5m2lzI5X88E3XLxMaVwJqolMwCgYIKoZIzj0EAwMw\nFjEUMBIGA1UEAwwLcGV0ZXJ3YWxrZXIwHhcNMjMwNTAxMTk1NjU3WhcNMjQwNDMw\nMTk1NjU3WjAWMRQwEgYDVQQDDAtwZXRlcndhbGtlcjB2MBAGByqGSM49AgEGBSuB\nBAAiA2IABH0CJdl/ZvmaLLDlkNU6gX56kKVP2pQDIr4NUVRe31Aycqa9Q5md1sBl\nE+e3c9hd5bz+Rjfok4uOaYvOWsr9EKbofzU4ztGWD5r2a6yvdbnmw7sjjoy2NN/N\nIOd0yW4pIKNTMFEwHQYDVR0OBBYEFEdO7YFlqF76lPXDwGOukMf9EVDFMB8GA1Ud\nIwQYMBaAFEdO7YFlqF76lPXDwGOukMf9EVDFMA8GA1UdEwEB/wQFMAMBAf8wCgYI\nKoZIzj0EAwMDaQAwZgIxAIv8BymJGDm4vQW/H6UvjXHfa6AA8+BhBUWYjq6vnRbj\nPP1phtfbnXOh3+6ACXMSZgIxANzw0ofI6ZMe36URpjiaRrAd9ubf9aG1sLMN3Amx\nr/CZgiIZe7uZuvi0UYtf0ZoeNw==\n-----END CERTIFICATE-----",
                            Encryptionkey = ""
                        }
                    },
                    DeploymentType = new ConfidentialLedgerDeploymentType()
                    {
                        LanguageRuntime = ConfidentialLedgerLanguageRuntime.JS,
                        AppSourceUri = new Uri("https://myaccount.blob.core.windows.net/storage/mccfsource"),
                    }
                }
            };
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(System.Diagnostics.Tracing.EventLevel.Verbose);
            await _resourceGroup.GetManagedCcfs().CreateOrUpdateAsync(WaitUntil.Completed, mccfName, mccfData);
        }

        /// <summary>
        /// Method takes the ledger name and try to update the the ledger with the given ledger data
        /// </summary>
        /// <param name="mccfName"></param>
        /// <param name="mccfData"></param>
        protected async Task UpdateMccf(string mccfName, ManagedCcfData mccfData)
        {
            await _resourceGroup.GetManagedCcfs().CreateOrUpdateAsync(WaitUntil.Completed, mccfData.Name, mccfData);
        }
    }
}

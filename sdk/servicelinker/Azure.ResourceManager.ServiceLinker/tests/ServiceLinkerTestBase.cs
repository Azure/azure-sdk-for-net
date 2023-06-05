// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceLinker.Tests
{
    public class ServiceLinkerTestBase : ManagementRecordedTestBase<ServicelinkerManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }
        protected ResourceGroupCollection ResourceGroups { get; private set; }
        public ServiceLinkerTestBase(bool isAsync) : base(isAsync)
        {
            IgnoreKeyVaultDependencyVersions();
            SanitizedHeaders.Add(UserTokenPolicy.UserTokenHeader);
        }

        public ServiceLinkerTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            IgnoreKeyVaultDependencyVersions();
            SanitizedHeaders.Add(UserTokenPolicy.UserTokenHeader);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        protected async Task InitializeClients()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroups = Subscription.GetResourceGroups();
        }

        // The Service Linker provider need user token in a separated header in the following scenarios.
        //   * The target resource is Key Vault
        //   * SecretStore is used to store secret in Key Vault
        protected async Task InitializeUserTokenClients()
        {
            UserTokenPolicy userTokenPolicy = new UserTokenPolicy(TestEnvironment.Credential, TestEnvironment.ResourceManagerUrl + "/.default");
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(userTokenPolicy, HttpPipelinePosition.PerRetry);
            Client = GetArmClient(options);
            Subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroups = Subscription.GetResourceGroups();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppConfiguration.Tests
{
    public class AppConfigTests : ProvisioningTestBase
    {
        public AppConfigTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AppConfiguration()
        {
            var infra = new TestInfrastructure();
            var appConfig = new AppConfigurationStore(infra, "standard");
            appConfig.AssignRole(RoleDefinition.AppConfigurationDataOwner, Guid.Empty);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task ExistingAppConfigResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddParameter(new Parameter("existingAppConfig"));
            infra.AddResource(AppConfigurationStore.FromExisting(infra, "existingAppConfig", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}

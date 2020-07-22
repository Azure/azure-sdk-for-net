// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class LiveProviderTests : ResourceOperationsTestsBase
    {
        public LiveProviderTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        //IOTHub
        private const string ProviderName = "Microsoft.Scheduler";

        [Test]
        public async Task ProviderGetValidateMessage()
        {
            var reg = await ProvidersOperations.RegisterAsync(ProviderName);
            Assert.NotNull(reg);

            var result = (await ProvidersOperations.GetAsync(ProviderName)).Value;

            // Validate result
            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Id);
            Assert.AreEqual(ProviderName, result.Namespace);
            Assert.True("Registered" == result.RegistrationState ||
                "Registering" == result.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", result.RegistrationState));
            Assert.IsNotEmpty(result.ResourceTypes);
            Assert.IsNotEmpty(result.ResourceTypes[0].Locations);
        }

        [Test]
        public async Task ProviderListValidateMessage()
        {
            var reg = await ProvidersOperations.RegisterAsync(ProviderName);
            Assert.NotNull(reg);

            var result = await ProvidersOperations.ListAsync(null).ToEnumerableAsync();

            // Validate result
            Assert.True(result.Any());
            var websiteProvider =
                result.First(
                    p => p.Namespace.Equals(ProviderName, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(ProviderName, websiteProvider.Namespace);
            Assert.True("Registered" == websiteProvider.RegistrationState ||
                "Registering" == websiteProvider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", websiteProvider.RegistrationState));
            Assert.IsNotEmpty(websiteProvider.ResourceTypes);
            Assert.IsNotEmpty(websiteProvider.ResourceTypes[0].Locations);
        }

        [Test]
        public async Task GetProviderWithAliases()
        {
            var computeNamespace = "Microsoft.Compute";

            var reg = await ProvidersOperations.RegisterAsync(computeNamespace);
            Assert.NotNull(reg);

            var result = await ProvidersOperations.ListAsync(expand: "resourceTypes/aliases").ToEnumerableAsync();

            // Validate result
            Assert.True(result.Any());
            var computeProvider = result.First(
                provider => string.Equals(provider.Namespace, computeNamespace, StringComparison.OrdinalIgnoreCase));

            Assert.IsNotEmpty(computeProvider.ResourceTypes);
            var virtualMachinesType = computeProvider.ResourceTypes.First(
                resourceType => string.Equals(resourceType.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase));

            Assert.IsNotEmpty(virtualMachinesType.Aliases);
            Assert.AreEqual("Microsoft.Compute/licenseType", virtualMachinesType.Aliases[0].Name);
            Assert.AreEqual("properties.licenseType", virtualMachinesType.Aliases[0].Paths[0].Path);

            computeProvider = (await ProvidersOperations.GetAsync(resourceProviderNamespace: computeNamespace, expand: "resourceTypes/aliases")).Value;

            Assert.IsNotEmpty(computeProvider.ResourceTypes);
            virtualMachinesType = computeProvider.ResourceTypes.First(
                resourceType => string.Equals(resourceType.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase));

            Assert.IsNotEmpty(virtualMachinesType.Aliases);
            Assert.AreEqual("Microsoft.Compute/licenseType", virtualMachinesType.Aliases[0].Name);
            Assert.AreEqual("properties.licenseType", virtualMachinesType.Aliases[0].Paths[0].Path);
        }

        [Test]
        public async Task VerifyProviderRegister()
        {
            await ProvidersOperations.RegisterAsync(ProviderName);

            var provider = (await ProvidersOperations.GetAsync(ProviderName)).Value;
            Assert.True(provider.RegistrationState == "Registered" ||
                        provider.RegistrationState == "Registering");
        }

        [Test]
        public async Task VerifyProviderUnregister()
        {
            var registerResult = await ProvidersOperations.RegisterAsync(ProviderName);

            var provider = (await ProvidersOperations.GetAsync(ProviderName)).Value;
            Assert.True(provider.RegistrationState == "Registered" ||
                        provider.RegistrationState == "Registering");

            var unregisterResult = await ProvidersOperations.UnregisterAsync(ProviderName);

            provider = (await ProvidersOperations.GetAsync(ProviderName)).Value;
            Assert.True(provider.RegistrationState == "NotRegistered" ||
                        provider.RegistrationState == "Unregistering",
                        "RegistrationState is expected NotRegistered or Unregistering. Actual value " +
                        provider.RegistrationState);
        }
    }
}

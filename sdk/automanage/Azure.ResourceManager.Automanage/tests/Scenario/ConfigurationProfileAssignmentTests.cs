// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileAssignmentTests : AutomanageTestBase
    {
        public ConfigurationProfileAssignmentTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanCreateCustomProfileAssignment()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile and assignments collections
            var profileCollection = rg.GetConfigurationProfiles();
            var assignmentCollection = rg.GetConfigurationProfileAssignments();

            // create configuration profile
            await CreateConfigurationProfile(profileCollection, profileName);

            // create VM



            // create assignment between profile and VM
        }
    }
}

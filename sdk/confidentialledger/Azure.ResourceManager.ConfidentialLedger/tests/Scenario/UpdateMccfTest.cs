// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConfidentialLedger.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture("updateTest")]
    public class UpdateMccfTest : MccfManagementTestBase
    {
        private ManagedCcfResource _mccfResource;

        public UpdateMccfTest(string testFixtureName) : base(true, RecordedTestMode.Record, testFixtureName)
        {
        }

        [RecordedTest]
        public async Task TestAddUserToLedger()
        {
            // Create MCCF App
            await CreateMccf(mccfName);
            _mccfResource = await GetMccfByName(mccfName);
            var deploymentType = GetDeploymentType();

            // Add the AadBasedSecurityPrincipal
            _mccfResource.Data.Properties = UpdateDeploymentType(_mccfResource.Data.Properties, deploymentType);
            await UpdateMCcf(mccfName, _mccfResource.Data);

            // Get the updated ledger
            _mccfResource = await GetMccfByName(mccfName);

            Assert.AreEqual(_mccfResource.Data.Properties.DeploymentType, deploymentType);
        }

        /// <summary>
        /// Method create a copy of the input LedgerProperties and update the list of securityPrincipals while copying
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="securityPrincipals"></param>
        /// <returns></returns>
        private ManagedCcfProperties UpdateDeploymentType(ManagedCcfProperties properties,
            ConfidentialLedgerDeploymentType deploymentType)
        {
            return new ManagedCcfProperties(properties.AppName, properties.AppUri,
                properties.IdentityServiceUri , properties.MemberIdentityCertificates, deploymentType,
                properties.ProvisioningState, properties.NodeCount);
        }

        /// <summary>
        /// Method generate a test list with the TestUser (TestUser321@microsoft.com) with a Contributor test role
        /// </summary>
        /// <returns></returns>
        private ConfidentialLedgerDeploymentType GetDeploymentType()
        {
            return new ConfidentialLedgerDeploymentType(ConfidentialLedgerLanguageRuntime.JS, new Uri("TestUpdate"));
        }
    }
}

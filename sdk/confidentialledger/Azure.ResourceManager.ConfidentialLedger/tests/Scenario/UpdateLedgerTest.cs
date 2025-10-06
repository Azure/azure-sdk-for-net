// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConfidentialLedger.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests.Scenario
{
    [TestFixture("update")]
    public class UpdateLedgerTest : AclManagementTestBase
    {
        private ConfidentialLedgerResource _ledgerResource;

        public UpdateLedgerTest(string testFixtureName) : base(true, RecordedTestMode.Playback, testFixtureName)
        {
            SaveDebugRecordingsOnFailure = true;
        }

        [Test, Order(1)]
        [RecordedTest]
        [LiveOnly(Reason = "Test relies on PrincipalId format which currently is not a valid GUID. This will be fixed when the sanitization migrates to the Test Proxy.")]
        public async Task TestAddUserToLedger()
        {
            try
            {
                // Create Ledger
                await CreateLedger(LedgerName);
                _ledgerResource = await GetLedgerByName(LedgerName);

                // Add the AadBasedSecurityPrincipal
                _ledgerResource.Data.Properties = AddTestSecurityPrincipal(_ledgerResource.Data.Properties,
                    GenerateTestSecurityPrincipal());
                await UpdateLedger(LedgerName, _ledgerResource.Data);

                // Get the updated ledger
                _ledgerResource = await GetLedgerByName(LedgerName);

                Assert.True(_ledgerResource.Data.Properties.AadBasedSecurityPrincipals
                    .Any(testUser => TestEnvironment.TestUserObjectId.Equals(testUser.PrincipalId.ToString())));
            }
            catch (Exception)
            {
            }
        }

        [Test, Order(2)]
        [RecordedTest]
        [LiveOnly(Reason = "Test relies on PrincipalId format which currently is not a valid GUID. This will be fixed when the sanitization migrates to the Test Proxy.")]
        public async Task TestRemoveUserFromLedger()
        {
            // Create Ledger
            await CreateLedger(LedgerName);
            _ledgerResource = await GetLedgerByName(LedgerName);

            // Add the AadBasedSecurityPrincipal
            _ledgerResource.Data.Properties = AddTestSecurityPrincipal(_ledgerResource.Data.Properties,
                GenerateTestSecurityPrincipal());
            await UpdateLedger(LedgerName, _ledgerResource.Data);

            // Remove the AadBasedSecurityPrincipal
            _ledgerResource.Data.Properties.AadBasedSecurityPrincipals.RemoveAt(0);
            await UpdateLedger(LedgerName, _ledgerResource.Data);

            // Get the updated ledger
            _ledgerResource = await GetLedgerByName(LedgerName);

            Assert.False(_ledgerResource.Data.Properties.AadBasedSecurityPrincipals
                .Any(testUser => TestEnvironment.TestUserObjectId.Equals(testUser.PrincipalId.ToString())));
        }

        /// <summary>
        /// Method create a copy of the input LedgerProperties and update the list of securityPrincipals while copying
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="securityPrincipals"></param>
        /// <returns></returns>
        private ConfidentialLedgerProperties AddTestSecurityPrincipal(ConfidentialLedgerProperties properties,
            IList<AadBasedSecurityPrincipal> securityPrincipals)
        {
            return new ConfidentialLedgerProperties(properties.LedgerName, properties.LedgerUri,
                properties.IdentityServiceUri, properties.LedgerInternalNamespace, properties.RunningState, properties.LedgerType,
                properties.ProvisioningState, ConfidentialLedgerSku.Standard, securityPrincipals, properties.CertBasedSecurityPrincipals, properties.HostLevel,
                properties.MaxBodySizeInMb, properties.SubjectName, properties.NodeCount, properties.WriteLBAddressPrefix,
                properties.WorkerThreads, properties.EnclavePlatform, properties.ApplicationType, null);
        }

        /// <summary>
        /// Method generate a test list with the TestUser (TestUser321@microsoft.com) with a Contributor test role
        /// </summary>
        /// <returns></returns>
        private IList<AadBasedSecurityPrincipal> GenerateTestSecurityPrincipal()
        {
            IList<AadBasedSecurityPrincipal> securityPrincipals = new List<AadBasedSecurityPrincipal>();
            securityPrincipals.Add(new AadBasedSecurityPrincipal(new Guid(TestEnvironment.TestUserObjectId),
                new Guid(TestEnvironment.TenantId), new ConfidentialLedgerRoleName("Contributor"), null));
            return securityPrincipals;
        }
    }
}

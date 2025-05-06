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

        public UpdateLedgerTest(string testFixtureName) : base(true, testFixtureName)
        {
        }

        [RecordedTest]
        public async Task TestAddRemoveCertUserFromLedger()
        {
            IgnoreTestInLiveMode();

            TestContext.WriteLine($"Creating ledger {LedgerNameInFixture}");
            await CreateLedger(LedgerNameInFixture);
            _ledgerResource = await GetLedgerByName(LedgerNameInFixture);
            TestContext.WriteLine($"Ledger created with aad users {string.Join(",", _ledgerResource.Data.Properties.AadBasedSecurityPrincipals.Select(x => x.PrincipalId))}");
            TestContext.WriteLine($"Ledger created with cert users {string.Join(",", _ledgerResource.Data.Properties.CertBasedSecurityPrincipals.Select(x => x.LedgerRoleName))}");

            TestContext.WriteLine($"Update ledger {LedgerNameInFixture} with new cert users");
            _ledgerResource.Data.Properties = AddTestSecurityPrincipal(_ledgerResource.Data.Properties,
                GenerateTestSecurityPrincipal());
            await UpdateLedger(LedgerNameInFixture, _ledgerResource.Data);

            TestContext.WriteLine($"Remove 1st user from the list of cert users");
            _ledgerResource.Data.Properties.CertBasedSecurityPrincipals.RemoveAt(0);
            await UpdateLedger(LedgerNameInFixture, _ledgerResource.Data);

            _ledgerResource = await GetLedgerByName(LedgerNameInFixture);
            TestContext.WriteLine($"Ledger users after removal {string.Join(",", _ledgerResource.Data.Properties.CertBasedSecurityPrincipals.Select(x => x.LedgerRoleName))}");

            Assert.IsEmpty(_ledgerResource.Data.Properties.CertBasedSecurityPrincipals,
                $"Expected list to be empty, but it was not.");
        }

        /// <summary>
        /// Method create a copy of the input LedgerProperties and update the list of securityPrincipals while copying
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="securityPrincipals"></param>
        /// <returns></returns>
        private ConfidentialLedgerProperties AddTestSecurityPrincipal(ConfidentialLedgerProperties properties,
            IList<CertBasedSecurityPrincipal> securityPrincipals)
        {
            return new ConfidentialLedgerProperties(properties.LedgerName, properties.LedgerUri,
                properties.IdentityServiceUri, properties.LedgerInternalNamespace, properties.RunningState, properties.LedgerType,
                properties.ProvisioningState, null, properties.AadBasedSecurityPrincipals, securityPrincipals, null);
        }

        /// <summary>
        /// Method generate a test list with the cert based user and a Contributor test role
        /// AAD based users cannot be modified as the test framework invalidates user GUIDs
        /// </summary>
        /// <returns></returns>
        private IList<CertBasedSecurityPrincipal> GenerateTestSecurityPrincipal()
        {
            CertBasedSecurityPrincipal certUser = new CertBasedSecurityPrincipal
            {
                Cert = "-----BEGIN CERTIFICATE-----\nMIIDUjCCAjqgAwIBAgIQJ2IrDBawSkiAbkBYmiAopDANBgkqhkiG9w0BAQsFADAmMSQwIgYDVQQDExtTeW50aGV0aWNzIExlZGdlciBVc2VyIENlcnQwHhcNMjAwOTIzMjIxODQ2WhcNMjEwOTIzMjIyODQ2WjAmMSQwIgYDVQQDExtTeW50aGV0aWNzIExlZGdlciBVc2VyIENlcnQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCX2s/Eu4q/eQ63N+Ugeg5oAciZua/YCJr41c/696szvSY7Zg1SNJlW88/nbz70+QpO55OmqlEE3QCU+T0Vl/h0Gf//n1PYcoBbTGUnYEmV+fTTHict6rFiEwrGJ62tvcpYgwapInSLyEeUzjki0zhOLJ1OfRnYd1eGnFVMpE5aVjiS8Q5dmTEUyd51EIprGE8RYAW9aeWSwTH7gjHUsRlJnHKcdhaK/v5QKJnNu5bzPFUcpC0ZBcizoMPAtroLAD4B68Jl0z3op18MgZe6lRrVoWuxfqnk5GojuB/Vu8ohAZKoFhQ6NB6r+LL2AUs+Zr7Bt26IkEdR178n9JMEA4gHAgMBAAGjfDB6MA4GA1UdDwEB/wQEAwIFoDAJBgNVHRMEAjAAMB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjAfBgNVHSMEGDAWgBS/a7PU9iOfOKEyZCp11Oen5VSuuDAdBgNVHQ4EFgQUv2uz1PYjnzihMmQqddTnp+VUrrgwDQYJKoZIhvcNAQELBQADggEBAF5q2fDwnse8egXhfaJCqqM969E9gSacqFmASpoDJPRPEX7gqoO7v1ww7nqRtRDoRiBvo/yNk7jlSAkRN3nRRnZLZZ3MYQdmCr4FGyIqRg4Y94+nja+Du9pDD761rxRktMVPSOaAVM/E5DQvscDlPvlPYe9mkcrLCE4DXYpiMmLT8Tm55LJJq5m07dVDgzAIR1L/hmEcbK0pnLgzciMtMLxGO2udnyyW/UW9WxnjvrrD2JluTHH9mVbb+XQP1oFtlRBfH7aui1ZgWfKvxrdP4zdK9QoWSUvRux3TLsGmHRBjBMtqYDY3y5mB+aNjLelvWpeVb0m2aOSVXynrLwNCAVA=\n-----END CERTIFICATE-----",
                LedgerRoleName = ConfidentialLedgerRoleName.Contributor,
            };
            IList<CertBasedSecurityPrincipal> securityPrincipals = new List<CertBasedSecurityPrincipal>();
            securityPrincipals.Add(certUser);
            return securityPrincipals;
        }
    }
}

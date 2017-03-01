// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    /// <summary>
    /// Scenario tests for the integration accounts certificates.
    /// </summary>
    [Collection("IntegrationAccountCertificateScenarioTests")]
    public class IntegrationAccountCertificateScenarioTests : ScenarioTestsBase
    {
        /// <summary>
        /// Tests the create and delete operations of the integration account certificate.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountCertificate()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var certificate = client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName)
                    );

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.Certificates.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountCertificateName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and delete operations of the integration account certificate with public key.
        /// </summary>
        [Fact]
        public void CreateIntegrationAccountCertificateWithPublicKey()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);

                var cert = new X509Certificate2(@"TestData/IntegrationAccountCertificate.cer");

                var certificateInstance = new IntegrationAccountCertificate
                {
                    Location = "brazilsouth",
                    PublicCertificate = Convert.ToBase64String(cert.RawData)
                };

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var certificate = client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    certificateInstance
                    );

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.Certificates.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountCertificateName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and delete operations of the integration account certificate with private key.
        /// </summary>
        [Fact]
        public void CreateIntegrationAccountCertificateWithPrivateKey()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                
                var certInstance = CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                    integrationAccountName);
                certInstance.PublicCertificate = null;

                var certificate = client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    certInstance
                    );

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.Certificates.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountCertificateName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the delete operations of the integration account certificate on account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountCertificateOnAccountDeletion()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var certificate = client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.Certificates.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountCertificateName));
            }
        }

        /// <summary>
        /// Tests the create and Update operations of the integration account certificate.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountCertificate()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                var certificate2 = CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                    integrationAccountName);

                client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName, certificate2);

                var updatedCertificate = client.Certificates.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName);

                Assert.Equal(updatedCertificate.Name, integrationAccountCertificateName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account certificate.
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountCertificate()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var certificate = client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                var getCertificate = client.Certificates.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName);

                Assert.Equal(certificate.Name, getCertificate.Name);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and list operations of the integration account certificate.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountCertificates()
        {
            using (
                MockContext context = MockContext.Start(className: this.testClassName))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                client.Certificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                var certificates = client.Certificates.ListByIntegrationAccounts(Constants.DefaultResourceGroup,
                    integrationAccountName);

                Assert.True(certificates.Any());

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        #region Private

        /// <summary>
        /// Creates an Integration account certificate.
        /// </summary>
        /// <param name="integrationAccountCertificateName">Name of the certificate.</param>
        /// <param name="integrationAccountName">Integration account name.</param>        
        /// <returns>Integration account certificate instance</returns>
        private IntegrationAccountCertificate CreateIntegrationAccountCertificateInstance(
            string integrationAccountCertificateName, string integrationAccountName)
        {

            var cert = new X509Certificate2(@"TestData/IntegrationAccountCertificate.cer");

            var certificate = new IntegrationAccountCertificate
            {
                Location = "brazilsouth",
                Key = new KeyVaultKeyReference
                {
                    KeyName = "PRIVATEKEY",
                    KeyVault = new KeyVaultKeyReferenceKeyVault()
                    {
                        Id =
                            string.Format(CultureInfo.InvariantCulture,
                                "/subscriptions/{0}/resourcegroups/{1}/providers/microsoft.keyvault/vaults/AzureSdkTestKeyVault",
                                Constants.DefaultSubscription, Constants.DefaultResourceGroup)
                    },
                    KeyVersion = "87d9764197604449b9b8eb7bd8710868"
                },
                PublicCertificate = Convert.ToBase64String(cert.RawData)
            };
            return certificate;
        }

        #endregion Private
    }
}
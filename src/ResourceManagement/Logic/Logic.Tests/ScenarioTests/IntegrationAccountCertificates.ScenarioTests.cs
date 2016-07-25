// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Test.Azure.Management.Logic
{
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Scenario tests for the integration accounts certificates.
    /// </summary>
    [Collection("IntegrationAccountCertificateScenarioTests")]
    public class IntegrationAccountCertificateScenarioTests : BaseScenarioTests
    {

        /// <summary>
        /// Name of the test class
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountCertificateScenarioTests";

        /// <summary>
        /// Tests the create and delete operations of the integration account certificate.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountCertificate()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var certificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName)
                    );

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.IntegrationAccountCertificates.Delete(Constants.DefaultResourceGroup, integrationAccountName,
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
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);

                var cert = new X509Certificate2(@"TestData/IntegrationAccountCertificate.cer");

                var certificateInstance = new IntegrationAccountCertificate
                {
                    Name = integrationAccountCertificateName,
                    Location = "brazilsouth",                    
                    PublicCertificate = Convert.ToBase64String(cert.RawData)
                };

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var certificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    certificateInstance
                    );

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.IntegrationAccountCertificates.Delete(Constants.DefaultResourceGroup, integrationAccountName,
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
                MockContext context = MockContext.Start(TestClass))
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

                var certificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    certInstance
                    );

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.IntegrationAccountCertificates.Delete(Constants.DefaultResourceGroup, integrationAccountName,
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
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var certificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup, integrationAccountName,
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
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                var certificate2 = CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                    integrationAccountName);                

                client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName, certificate2);

                var updatedCertificate = client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup,
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
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var certificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                Assert.Equal(certificate.Name, integrationAccountCertificateName);

                var getCertificate = client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup,
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
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountCertificateName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup, integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountCertificateName,
                    CreateIntegrationAccountCertificateInstance(integrationAccountCertificateName,
                        integrationAccountName));

                var certificates = client.IntegrationAccountCertificates.List(Constants.DefaultResourceGroup,
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
                Name = integrationAccountCertificateName,
                Location = "brazilsouth",
                Key = new KeyVaultKeyReference
                {
                    KeyName = "PRIVATEKEY",
                    KeyVault = new KeyVaultKeyReferenceKeyVault()
                    {
                        Id =
                            string.Format(CultureInfo.InvariantCulture,
                                "/subscriptions/{0}/resourcegroups/{1}/providers/microsoft.keyvault/vaults/IntegrationAccountVault",
                                Constants.DefaultSubscription, Constants.DefaultResourceGroup)
                    },
                    KeyVersion = "a71cf67368fc473f8d2a40cd8804ac85"
                },
                PublicCertificate = Convert.ToBase64String(cert.RawData)
            };
            return certificate;
        }

        #endregion Private
    }
}
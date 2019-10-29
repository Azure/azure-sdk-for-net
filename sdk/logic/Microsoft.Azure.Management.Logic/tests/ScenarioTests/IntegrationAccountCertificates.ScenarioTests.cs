// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    [Collection("IntegrationAccountCertificateScenarioTests")]
    public class IntegrationAccountCertificateScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountCertificates_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                this.ValidateCertificate(certificate, createdCertificate);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_CreateWithPublicKey_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                certificate.Key = null;
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                this.ValidateCertificate(certificate, createdCertificate);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_CreateWithPrivateKey_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                certificate.PublicCertificate = null;
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                this.ValidateCertificate(certificate, createdCertificate);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                var retrievedCertificate = client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName);

                this.ValidateCertificate(certificate, retrievedCertificate);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName1 = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate1 = this.CreateIntegrationAccountCertificate(certificateName1);
                var createdCertificate1 = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName1,
                    certificate1);

                var certificateName2 = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate2 = this.CreateIntegrationAccountCertificate(certificateName2);
                var createdCertificate2 = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName2,
                    certificate2);

                var certificateName3 = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate3 = this.CreateIntegrationAccountCertificate(certificateName3);
                var createdCertificate3 = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName3,
                    certificate3);

                var certificates = client.IntegrationAccountCertificates.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, certificates.Count());
                this.ValidateCertificate(certificate1, certificates.Single(x => x.Name == certificate1.Name));
                this.ValidateCertificate(certificate2, certificates.Single(x => x.Name == certificate2.Name));
                this.ValidateCertificate(certificate3, certificates.Single(x => x.Name == certificate3.Name));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_Update_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                var newCertificate = this.CreateIntegrationAccountCertificate(certificateName);
                var updatedCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    newCertificate);

                this.ValidateCertificate(newCertificate, updatedCertificate);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                client.IntegrationAccountCertificates.Delete(Constants.DefaultResourceGroup, integrationAccountName, certificateName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup, integrationAccountName, certificateName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountCertificates_DeleteWhenDeleteIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
                var certificate = this.CreateIntegrationAccountCertificate(certificateName);
                var createdCertificate = client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    certificateName,
                    certificate);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup, integrationAccountName, certificateName));
            }
        }

        #region Private

        private void ValidateCertificate(IntegrationAccountCertificate expected, IntegrationAccountCertificate actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);

            if (!string.IsNullOrEmpty(expected.PublicCertificate))
            {
                Assert.Equal(expected.PublicCertificate, actual.PublicCertificate);
            }
            else
            {
                Assert.True(string.IsNullOrEmpty(actual.PublicCertificate));
            }

            if (expected.Key != null)
            {
                Assert.Equal(expected.Key.KeyName, actual.Key.KeyName);
                Assert.Equal(expected.Key.KeyVault.Id, actual.Key.KeyVault.Id);
                Assert.Equal(expected.Key.KeyVersion, actual.Key.KeyVersion);
            }
            else
            {
                Assert.Null(actual.Key);
            }
        }

        private IntegrationAccountCertificate CreateIntegrationAccountCertificate(string certificateName)
        {
            var cert = new X509Certificate2(@"TestData/IntegrationAccountCertificate.cer");
            var certificate = new IntegrationAccountCertificate(name: certificateName,
                location: Constants.DefaultLocation,
                key: new KeyVaultKeyReference
                {
                    KeyName = "PRIVATEKEY",
                    KeyVault = new KeyVaultKeyReferenceKeyVault
                    {
                        Id = $"/subscriptions/{Constants.DefaultSubscription}/resourcegroups/{Constants.DefaultResourceGroup}/providers/microsoft.keyvault/vaults/AzureSdkTestKeyVault"
                    },
                    KeyVersion = "87d9764197604449b9b8eb7bd8710868"
                },
                publicCertificate: Convert.ToBase64String(cert.RawData));

            return certificate;
        }

        #endregion Private
    }
}

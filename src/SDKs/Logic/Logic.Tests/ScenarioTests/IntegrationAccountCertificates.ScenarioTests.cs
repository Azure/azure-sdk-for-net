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
    public class IntegrationAccountCertificateScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly string certificateName;
        private readonly IntegrationAccount integrationAccount;

        public IntegrationAccountCertificateScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.certificateName = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountCertificates_Create_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            this.ValidateCertificate(certificate, createdCertificate);
        }

        [Fact]
        public void IntegrationAccountCertificates_CreateWithPublicKey_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            certificate.Key = null;
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            this.ValidateCertificate(certificate, createdCertificate);
        }

        [Fact]
        public void IntegrationAccountCertificates_CreateWithPrivateKey_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            certificate.PublicCertificate = null;
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            this.ValidateCertificate(certificate, createdCertificate);
        }

        [Fact]
        public void IntegrationAccountCertificates_Get_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            var retrievedCertificate = this.client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName);

            this.ValidateCertificate(certificate, retrievedCertificate);
        }

        [Fact]
        public void IntegrationAccountCertificates_List_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            var certificateName2 = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
            var certificate2 = this.CreateIntegrationAccountCertificate(certificateName2);
            var createdCertificate2 = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                certificateName2,
                certificate2);

            var certificateName3 = TestUtilities.GenerateName(Constants.IntegrationAccountCertificatePrefix);
            var certificate3 = this.CreateIntegrationAccountCertificate(certificateName3);
            var createdCertificate3 = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                certificateName3,
                certificate3);

            var certificates = this.client.IntegrationAccountCertificates.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, certificates.Count());
            this.ValidateCertificate(certificate, certificates.Single(x => x.Name == certificate.Name));
            this.ValidateCertificate(certificate2, certificates.Single(x => x.Name == certificate2.Name));
            this.ValidateCertificate(certificate3, certificates.Single(x => x.Name == certificate3.Name));
        }

        [Fact]
        public void IntegrationAccountCertificates_Update_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            var newCertificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var updatedCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                newCertificate);

            this.ValidateCertificate(newCertificate, updatedCertificate);
        }

        [Fact]
        public void IntegrationAccountCertificates_Delete_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            this.client.IntegrationAccountCertificates.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.certificateName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.certificateName));
        }

        [Fact]
        public void IntegrationAccountCertificates_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var certificate = this.CreateIntegrationAccountCertificate(this.certificateName);
            var createdCertificate = this.client.IntegrationAccountCertificates.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.certificateName,
                certificate);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountCertificates.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.certificateName));
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
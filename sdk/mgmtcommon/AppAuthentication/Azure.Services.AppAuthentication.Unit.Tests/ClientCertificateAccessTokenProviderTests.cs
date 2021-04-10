// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;
using CertificateIdentifierType = Microsoft.Azure.Services.AppAuthentication.ClientCertificateAzureServiceTokenProvider.CertificateIdentifierType;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Test cases for ClientCertificateAccessTokenProvider class. ClientCertificateAccessTokenProvider is an internal class. 
    /// </summary>
    public class ClientCertificateAccessTokenProviderTests : IDisposable
    {
        /// <summary>
        /// Make sure the test cert is deleted from the current user store. 
        /// </summary>
        public void Dispose()
        {
            // Delete the cert
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.DeleteCertificate(cert.Thumbprint);
        }

        [Fact]
        public async Task ThumbprintSuccessTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            // Create ClientCertificateAzureServiceTokenProvider instance
            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext);

            // Get the token. This will test that ClientCertificateAzureServiceTokenProvider could fetch the cert from CurrentUser store based on thumbprint in the connection string. 
            var authResult = await provider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            // Delete the cert, since testing is done. 
            CertUtil.DeleteCertificate(cert.Thumbprint);

            Validator.ValidateToken(authResult.AccessToken, provider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId, cert.Thumbprint, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// Getting token should throw an error if cert thumbprint failed  
        /// </summary>
        [Fact]
        public async Task ThumbprintFailTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth failed. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateFail);

            // Create ClientCertificateAzureServiceTokenProvider instance
            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext);

            // Ensure exception is thrown when getting the token
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => provider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId));

            Assert.Contains(AzureServiceTokenProviderException.GenericErrorMessage, exception.ToString());
            // Delete the cert, since testing is done. 
            CertUtil.DeleteCertificate(cert.Thumbprint);
        }

        /// <summary>
        /// If the ClientId is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void ClientIdNullOrEmptyTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            // Create ClientCertificateAzureServiceTokenProvider instance
            var exception = Assert.Throws<ArgumentNullException>(() => new ClientCertificateAzureServiceTokenProvider(null,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            exception = Assert.Throws<ArgumentNullException>(() => new ClientCertificateAzureServiceTokenProvider(string.Empty,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        /// <summary>
        /// If the storeLocation is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void StoreLocationNullOrEmptyTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            // Create ClientCertificateAzureServiceTokenProvider instance
            var exception = Assert.Throws<ArgumentNullException>(() => new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, null, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            exception = Assert.Throws<ArgumentNullException>(() => new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, string.Empty, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        /// <summary>
        /// If the certificateSubjectNameOrThumbprint is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void CertSubjectNameOrThumbprintNullOrEmptyTest()
        {
            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            // Create ClientCertificateAzureServiceTokenProvider instance
            var exception = Assert.Throws<ArgumentNullException>(() => new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                null, CertificateIdentifierType.Thumbprint, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            exception = Assert.Throws<ArgumentNullException>(() => new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                string.Empty, CertificateIdentifierType.Thumbprint, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        /// <summary>
        /// If the store location is invalid, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void InvalidStoreLocationTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            // Create ClientCertificateAzureServiceTokenProvider instance
            var exception = Assert.Throws<ArgumentException>(() => new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Thumbprint, CertificateIdentifierType.Thumbprint, Constants.InvalidString, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext));

            Assert.Contains(Constants.InvalidCertLocationError, exception.ToString());
        }

        [Fact]
        public async Task SubjectNameSuccessTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            // Create ClientCertificateAzureServiceTokenProvider instance with a subject name
            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Subject, CertificateIdentifierType.SubjectName, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext);

            // Get the token. This will test that ClientCertificateAzureServiceTokenProvider could fetch the cert from CurrentUser store based on subject name in the connection string. 
            var authResult = await provider.GetAuthResultAsync(Constants.KeyVaultResourceId, string.Empty).ConfigureAwait(false);

            // Delete the cert, since testing is done. 
            CertUtil.DeleteCertificate(cert.Thumbprint);

            Validator.ValidateToken(authResult.AccessToken, provider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId, cert.Thumbprint, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// Test that exception when token cannot be aquired through a cert. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void CannotAcquireTokenThroughCertTest()
        {
            // Import the test certificate. 
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);
            CertUtil.ImportCertificate(cert);

            // MockAuthenticationContext is being asked to act like client cert auth failed. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireInvalidTokenAsyncFail);

            // Create ClientCertificateAzureServiceTokenProvider instance with a subject name
            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                cert.Subject, CertificateIdentifierType.SubjectName, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext);

            // Get the token. This will test that ClientCertificateAzureServiceTokenProvider could fetch the cert from CurrentUser store based on subject name in the connection string. 
            var exception = Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => provider.GetAuthResultAsync(Constants.KeyVaultResourceId, string.Empty));

            // Delete the cert, since testing is done. 
            CertUtil.DeleteCertificate(cert.Thumbprint);

            Assert.Contains(Constants.TokenFormatExceptionMessage, exception.Result.Message);
            Assert.Contains(Constants.TokenNotInExpectedFormatError, exception.Result.Message);
        }

        /// <summary>
        /// Test that exception when cert is not found is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CertificateNotFoundTest()
        {
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                Guid.NewGuid().ToString(), CertificateIdentifierType.SubjectName, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => provider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);
            Assert.Contains(Constants.LocalCertificateNotFoundError, exception.Message);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task KeyVaultCertificateSecretIdentifierSuccessTest(bool includeTenantId)
        {
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(Constants.TestCert), string.Empty);

            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Create KeyVaultClient with MockKeyVault to mock successful calls to KeyVault
            MockKeyVault mockKeyVault = new MockKeyVault(MockKeyVault.KeyVaultClientTestType.CertificateSecretIdentifierSuccess);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient, azureCliAccessTokenProvider);

            // MockAuthenticationContext is being asked to act like client cert auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            string tenantIdParam = includeTenantId ? Constants.TenantId : null;

            // Create ClientCertificateAzureServiceTokenProvider instance with a subject name
            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                Constants.TestKeyVaultCertificateSecretIdentifier, CertificateIdentifierType.KeyVaultCertificateSecretIdentifier, null, Constants.AzureAdInstance, tenantIdParam, 0, authenticationContext: mockAuthenticationContext, keyVaultClient: keyVaultClient);

            // Get the token. This will test that ClientCertificateAzureServiceTokenProvider could fetch the cert from CurrentUser store based on subject name in the connection string. 
            var authResult = await provider.GetAuthResultAsync(Constants.ArmResourceId, string.Empty).ConfigureAwait(false);

            Validator.ValidateToken(authResult.AccessToken, provider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId, cert.Thumbprint, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// Test that exception when cert is not found is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task KeyVaultCertificateNotFoundTest()
        {
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess);

            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            MockKeyVault mockKeyVault = new MockKeyVault(MockKeyVault.KeyVaultClientTestType.SecretNotFound);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient, azureCliAccessTokenProvider);

            string SecretIdentifier = "https://testbedkeyvault.vault.azure.net/secrets/secret/";
            ClientCertificateAzureServiceTokenProvider provider = new ClientCertificateAzureServiceTokenProvider(Constants.TestAppId,
                SecretIdentifier, CertificateIdentifierType.KeyVaultCertificateSecretIdentifier, Constants.CurrentUserStore, Constants.AzureAdInstance, Constants.TenantId, 0, authenticationContext: mockAuthenticationContext, keyVaultClient: keyVaultClient);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => provider.GetAuthResultAsync(Constants.ArmResourceId, Constants.TenantId)));

            Assert.Contains(Constants.ArmResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);
            Assert.Contains(AzureServiceTokenProviderException.KeyVaultCertificateRetrievalError, exception.Message);
            Assert.Contains(KeyVaultClient.KeyVaultResponseError, exception.Message);
            Assert.Contains(MockKeyVault.SecretNotFoundErrorMessage, exception.Message);
        }
    }
}

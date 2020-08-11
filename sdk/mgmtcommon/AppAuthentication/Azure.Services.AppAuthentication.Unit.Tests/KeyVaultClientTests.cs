using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

using TestType = Microsoft.Azure.Services.AppAuthentication.Unit.Tests.MockKeyVault.KeyVaultClientTestType;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class KeyVaultClientTests
    {
        [Fact]
        public async Task KeyVaultUnavailable()
        {
            MockKeyVault mockKeyVault = new MockKeyVault(TestType.KeyVaultUnavailable);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(Constants.TestKeyVaultCertificateSecretIdentifier)));
            Assert.Contains(KeyVaultClient.EndpointNotAvailableError, exception.Message);
        }

        [Fact]
        public async Task SecretIdentifierInvalidUriTest()
        {
            KeyVaultClient keyVaultClient = new KeyVaultClient();

            string secretIdentifier = Constants.TestKeyVaultCertificateSecretIdentifier.Replace("https://", string.Empty);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(secretIdentifier)));
            Assert.Contains(KeyVaultClient.SecretIdentifierInvalidUriError, exception.Message);
        }

        [Fact]
        public async Task SecretIdentifierInvalidSchemeTest()
        {
            KeyVaultClient keyVaultClient = new KeyVaultClient();

            string secretIdentifier = Constants.TestKeyVaultCertificateSecretIdentifier.Replace("https://", "http://");

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(secretIdentifier)));
            Assert.Contains(KeyVaultClient.SecretIdentifierInvalidSchemeError, exception.Message);
        }

        [Fact]
        public async Task SecretIdentifierInvalidTypeTest()
        {
            KeyVaultClient keyVaultClient = new KeyVaultClient();

            string secretIdentifier = Constants.TestKeyVaultCertificateSecretIdentifier.Replace("/secrets/", "/keys/");

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(secretIdentifier)));
            Assert.Contains(KeyVaultClient.SecretIdentifierInvalidTypeError, exception.Message);
        }

        [Fact]
        public async Task HttpBearerChallengeMissingTest()
        {
            MockKeyVault mockKeyVault = new MockKeyVault(TestType.HttpBearerChallengMissing);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(Constants.TestKeyVaultCertificateSecretIdentifier)));
            Assert.Contains(KeyVaultClient.KeyVaultAccessTokenRetrievalError, exception.Message);
            Assert.Contains(KeyVaultClient.BearerChallengeMissingOrInvalidError, exception.Message);
        }

        [Fact]
        public async Task HttpBearerChallengeInvalidTest()
        {
            MockKeyVault mockKeyVault = new MockKeyVault(TestType.HttpBearerChallengeInvalid);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(Constants.TestKeyVaultCertificateSecretIdentifier)));
            Assert.Contains(KeyVaultClient.KeyVaultAccessTokenRetrievalError, exception.Message);
            Assert.Contains(KeyVaultClient.BearerChallengeMissingOrInvalidError, exception.Message);
        }

        [Fact]
        public async Task KeyVaultTokenProviderErrorTest()
        {
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Failure);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            MockKeyVault mockKeyVault = new MockKeyVault(TestType.CertificateSecretIdentifierSuccess);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient, azureCliAccessTokenProvider);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(Constants.TestKeyVaultCertificateSecretIdentifier)));
            Assert.Contains(AzureServiceTokenProviderException.GenericErrorMessage, exception.Message);
            Assert.Contains(KeyVaultClient.KeyVaultAccessTokenRetrievalError, exception.Message);
            Assert.Contains(string.Format(KeyVaultClient.TokenProviderErrorsFormat, 1), exception.Message);
            Assert.Contains(Constants.DeveloperToolError, exception.Message);
        }

        [Fact]
        public async Task InvalidKeyVaultSecretType()
        {
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // use a secret identifier, but return secret bundle for password/secret and not certificate
            MockKeyVault mockKeyVault = new MockKeyVault(TestType.PasswordSecretIdentifierSuccess);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient, azureCliAccessTokenProvider);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(Constants.TestKeyVaultCertificateSecretIdentifier)));
            Assert.Contains(KeyVaultClient.SecretBundleInvalidContentTypeError, exception.Message);
        }

        [Fact]
        public async Task SecretNotFoundTest()
        {
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            MockKeyVault mockKeyVault = new MockKeyVault(TestType.SecretNotFound);
            HttpClient httpClient = new HttpClient(mockKeyVault);
            KeyVaultClient keyVaultClient = new KeyVaultClient(httpClient, azureCliAccessTokenProvider);

            var exception = await Assert.ThrowsAnyAsync<Exception>(() => Task.Run(() => keyVaultClient.GetCertificateAsync(Constants.TestKeyVaultCertificateSecretIdentifier)));
            Assert.Contains(KeyVaultClient.KeyVaultResponseError, exception.Message);
            Assert.Contains(MockKeyVault.SecretNotFoundErrorMessage, exception.Message);
        }
    }
}

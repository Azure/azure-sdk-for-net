using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class VisualStudioAccessTokenProviderTests
    {
        private readonly VisualStudioTokenProviderFile _visualStudioTokenProviderFile;

        public VisualStudioAccessTokenProviderTests()
        {
            // Parse the Visual Studio token provider file.
            _visualStudioTokenProviderFile = VisualStudioTokenProviderFile.Load(Path.Combine(Constants.TestFilesPath, "VisualStudioSingleTokenProvider.json"));

            // This is set to a file that exists, since there is code that checks for file's existence. In reality, this would be an executable, but since
            // process manager is mocked, this will will not be run.
            _visualStudioTokenProviderFile.TokenProviders[0].Path = Path.GetFullPath(Path.Combine(Constants.TestFilesPath, "VisualStudioSingleTokenProvider.json"));
        }

        [Fact]
        public async Task GetTokenTest()
        {
            // Mock the progress manager. This emulates running an actual process to get token from Visual Studio key chain.
            var mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.VisualStudioSuccess);

            // VisualStudioAccessTokenProvider has in internal only constructor to allow for unit testing. 
            var visualStudioAccessTokenProvider = new VisualStudioAccessTokenProvider(mockProcessManager, _visualStudioTokenProviderFile);

            // Get token and validate it
            var authResult = await visualStudioAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            Validator.ValidateToken(authResult.AccessToken, visualStudioAccessTokenProvider.PrincipalUsed, Constants.UserType, Constants.TenantId, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// Test that if Visual Studio token provider file is missing, the right type of exception is thrown, and that the error response is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TokenProviderFileNotFoundTest()
        {
            var visualStudioAccessTokenProvider = new VisualStudioAccessTokenProvider(new ProcessManager());

            // This will ensure that the localappdata folder doesnt exist on the machine. Since VS token provider file path is added to this, the file will not exist either.
            string path = Guid.NewGuid().ToString();
            Environment.SetEnvironmentVariable(Constants.LocalAppDataEnv, path);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => visualStudioAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(path, exception.Message);
            Assert.Contains(AzureServiceTokenProviderException.GenericErrorMessage, exception.Message);
            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(VisualStudioAccessTokenProvider.TokenProviderFileNotFound, exception.Message);
        }

        /// <summary>
        /// Test that if all Visual Studio token providers are missing that are given in the Visual Studio token provider file, the right type of exception is thrown, and that the error response is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TokenProvidersNotFoundTest()
        {
            // set all token providers in the token provider object to non-existent paths
            _visualStudioTokenProviderFile.TokenProviders.ForEach(tp => tp.Path = $"C:\\{Guid.NewGuid()}\\Microsoft.Asal.TokenService.exe.json");
            var visualStudioAccessTokenProvider = new VisualStudioAccessTokenProvider(new ProcessManager(), _visualStudioTokenProviderFile);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => visualStudioAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(AzureServiceTokenProviderException.GenericErrorMessage, exception.Message);
            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(VisualStudioAccessTokenProvider.TokenProvidersNotFound, exception.Message);
        }

        /// <summary>
        /// Test that if Visual Studio failed to get token, the right type of exception is thrown, and that the error response is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task FailedToGetToken()
        {
            var mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Failure);

            // VisualStudioAccessTokenProvider has in internal only constructor to allow for unit testing. 
            var visualStudioAccessTokenProvider = new VisualStudioAccessTokenProvider(mockProcessManager, _visualStudioTokenProviderFile);
            
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => visualStudioAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(AzureServiceTokenProviderException.GenericErrorMessage, exception.Message);
            Assert.Contains(Constants.DeveloperToolError, exception.Message);
            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(VisualStudioAccessTokenProvider.TokenProviderGenericError, exception.Message);
        }

        /// <summary>
        /// This is a security test. The resource id should only have allowed characters. 
        /// Check that the right type of exception is thrown, and the error message is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ResourceInvalidCharsTest()
        {
            var mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);

            // VisualStudioAccessTokenProvider has in internal only constructor to allow for unit testing. 
            var visualStudioAccessTokenProvider = new VisualStudioAccessTokenProvider(mockProcessManager, _visualStudioTokenProviderFile);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => visualStudioAccessTokenProvider.GetAuthResultAsync("https://test^", Constants.TenantId)));

            Assert.Contains(Constants.NotInExpectedFormatError, exception.Message);
        }
    }
}

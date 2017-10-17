using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class VisualStudioAccessTokenProviderTests
    {
        [Fact]
        public async Task GetTokenTest()
        {
            // Mock the progress manager. This emulates running an actual process to get token from Visual Studio key chain.
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.VisualStudioSuccess);

            // Parse the Visual Studio token provider file.
            var visualStudioTokenProviderFile = VisualStudioTokenProviderFile.Parse(File.ReadAllText(Path.Combine(Constants.TestFilesPath, "VisualStudioSingleTokenProvider.json")));
            
            // This is set to a file that exists, since there is code that checks for file's existence. In reality, this would be an executable, but since
            // process manager is mocked, this will will not be run.
            visualStudioTokenProviderFile.TokenProviders[0].Path = Path.GetFullPath(Path.Combine(Constants.TestFilesPath, "VisualStudioSingleTokenProvider.json"));

            // VisualStudioAccessTokenProvider has in internal only constructor to allow for unit testing. 
            VisualStudioAccessTokenProvider visualStudioAccessTokenProvider = new VisualStudioAccessTokenProvider(visualStudioTokenProviderFile, mockProcessManager);

            // Get token and validate it
            var token = await visualStudioAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            Validator.ValidateToken(token, visualStudioAccessTokenProvider.PrincipalUsed, Constants.UserType, Constants.TenantId);
        }
    }
}

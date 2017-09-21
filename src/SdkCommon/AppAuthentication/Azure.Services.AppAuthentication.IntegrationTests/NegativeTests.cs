// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests
{
    public class NegativeTests
    {
        /// <summary>
        /// Check that response is as expected when one enters an invalid resource id. In this case, the resource id is not assumed to be in Azure AD. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task WrongResource()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.AzureCliConnectionString);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureServiceTokenProvider.GetAccessTokenAsync("https://wrong-resource/")));

            Assert.Contains(Constants.InvalidResource, exception.Message);
        }
        
    }
}

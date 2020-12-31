// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if net472
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using System;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class SqlAppAuthenticationProviderTests
    {
        [Fact]
        public async void InvalidAuthority()
        {
            // Provide authority parameter value that will not parse properly
            var parameters = new SqlAppAuthenticationParameters("http://badauthority", Constants.KeyVaultResourceId, default);

            // Ensure exception is thrown when getting the token
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => (new SqlAppAuthenticationProvider()).AcquireTokenAsync(parameters));

            Assert.Contains(Constants.SqlAppAuthProviderInvalidAuthority, exception.ToString());
        }

        [Fact]
        public async void MissingResource()
        {
            // Do not provide any resource parameter value
            var parameters = new SqlAppAuthenticationParameters($"{Constants.AzureAdInstance}{Constants.TenantId}", string.Empty, default);

            // Ensure exception is thrown when getting the token
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => (new SqlAppAuthenticationProvider()).AcquireTokenAsync(parameters));

            Assert.Contains(Constants.SqlAppAuthProviderInvalidResource, exception.ToString());
        }

        [Fact]
        public void InvalidUserId()
        {
            string returnValue = SqlAppAuthenticationProvider.GetConnectionStringByUserId("NotAGuid");

            Assert.Equal(default, returnValue);
        }

        [Fact]
        public void ValidUserId()
        {
            string returnValue = SqlAppAuthenticationProvider.GetConnectionStringByUserId(Constants.TestUserAssignedManagedIdentityId);

            Assert.Equal(Constants.ManagedUserAssignedIdentityConnectionString, returnValue);
        }
    }
}
#endif

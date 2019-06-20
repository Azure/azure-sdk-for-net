// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Az.Auth.Net452.Test
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest.Azure.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class Net452ExceptionsTests
    {
        [Fact]
        public void AuthExceptionWithInnerException()
        {
            AuthenticationException authExToBeThrown = null;
            string authError = "Error Occured";
            try
            {
                var token = ApplicationTokenProvider.LoginSilentAsync("SomeDomain", "clientId", "someText").GetAwaiter().GetResult();
            }
            catch(AdalException adalEx)
            {
                authExToBeThrown = new AuthenticationException(authError, adalEx);
            }

            Assert.NotNull(authExToBeThrown);
            Assert.Equal(authError, authExToBeThrown.Message);
        }

#if FullNetFx
        [Fact]
        public void AuthExceptionWithNullInnerException()
        {
            AuthenticationException authExToBeThrown = null;
            string authError = "Error Occured";
            try
            {
                ClientCredential cc = new ClientCredential("SomeClientId", "SomethingSomething");
                ActiveDirectoryServiceSettings adSvcSettings = new ActiveDirectoryServiceSettings()
                {
                    AuthenticationEndpoint = new Uri("https://randomEndPoint"),
                    TokenAudience = new Uri("https://SomeUri"),
                    ValidateAuthority = true
                };

                var token = ApplicationTokenProvider.LoginSilentAsync( "SomeDomain", cc, adSvcSettings).GetAwaiter().GetResult();
            }
            catch (AdalException adalEx)
            {
                authExToBeThrown = new AuthenticationException(authError);
            }

            Assert.NotNull(authExToBeThrown);
            Assert.Equal(authError, authExToBeThrown.Message);
        }
#endif

    }
}

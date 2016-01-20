using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit.Sdk;

namespace Helpers
{
    public class AuthenticationHelper
    {
        public static string GetTokenForSpn(string authority, string audience, string domain, string applicationId, string secret)
        {
            var context = new AuthenticationContext(EnsureTrailingSlash(authority) + domain, true, TokenCache.DefaultShared);
            var authResult =context.AcquireToken(audience, new ClientCredential(applicationId, secret));

            return authResult.AccessToken;
        }

        private static string EnsureTrailingSlash(string endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException("endpoint");
            }

            if (!endpoint.EndsWith("/"))
            {
                return endpoint + "/";
            }

            return endpoint;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.TestCommon
{
    public class Validator
    {
        /// <summary>
        /// Checks if the token fetched and principalUsed are as expected. 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="principalUsed"></param>
        /// <param name="type"></param>
        /// <param name="tenantId"></param>
        /// <param name="appId"></param>
        /// <param name="thumbprint"></param>
        public static void ValidateToken(string token, Principal principalUsed, string type,
            string tenantId, string appId = default(string), string thumbprint = default(string))
        {
            Assert.Equal("eyJ0eXAiOiJKV1Qi", token.Substring(0, "eyJ0eXAiOiJKV1Qi".Length));
            Assert.Contains(".", token);

            // These will always be present
            Assert.Equal(type, principalUsed.Type);
            Assert.Equal(true, principalUsed.IsAuthenticated);
            Assert.Equal(tenantId, principalUsed.TenantId);

            string thumbprintPart = string.Empty;
            string upnPart = string.Empty;
            string appIdPart = string.Empty;

            if (string.Equals(type, "App"))
            {
                Assert.Equal(appId, principalUsed.AppId);
                Assert.Equal(null, principalUsed.UserPrincipalName);
                appIdPart = $" AppId:{principalUsed.AppId}";

                if (!string.IsNullOrEmpty(thumbprint))
                {
                    Assert.Equal(thumbprint, principalUsed.CertificateThumbprint);
                    thumbprintPart = $" CertificateThumbprint:{thumbprint}";
                }
            }
            else
            {
                Assert.Equal(null, principalUsed.AppId);
                Assert.Contains("@", principalUsed.UserPrincipalName);
                upnPart = $" UserPrincipalName:{principalUsed.UserPrincipalName}";
            }

            Assert.Equal($"IsAuthenticated:True Type:{type}{appIdPart} TenantId:{principalUsed.TenantId}{thumbprintPart}{upnPart}",
                principalUsed.ToString());
        }
        
    }
}

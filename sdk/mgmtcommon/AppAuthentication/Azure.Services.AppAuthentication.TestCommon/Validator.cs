// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.TestCommon
{
    public class Validator
    {
        private const char Base64PadCharacter = '=';
        private const char Base64Character62 = '+';
        private const char Base64Character63 = '/';
        private const char Base64UrlCharacter62 = '-';
        private const char Base64UrlCharacter63 = '_';
        private static readonly string DoubleBase64PadCharacter = string.Format(CultureInfo.InvariantCulture, "{0}{0}", Base64PadCharacter);

        private static DateTimeOffset UnixTimeEpoch => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [DataContract]
        private class AccessToken
        {
            [DataMember(Name = "exp", IsRequired = true)]
            public long Expiration { get; private set; }
        }

        private static byte[] DecodeBytes(string arg)
        {
            string s = arg;
            s = s.Replace(Base64UrlCharacter62, Base64Character62);
            s = s.Replace(Base64UrlCharacter63, Base64Character63);

            switch (s.Length % 4)
            {
                // Pad 
                case 0:
                    break; // No pad chars in this case
                case 2:
                    s += DoubleBase64PadCharacter;
                    break; // Two pad chars
                case 3:
                    s += Base64PadCharacter;
                    break; // One pad char
                default:
                    throw new ArgumentException("Illegal base64url string!", nameof(arg));
            }

            return Convert.FromBase64String(s);
        }

        private static DateTimeOffset GetTokenExpiration(string accessTokenString)
        {
            string[] tokenParts = accessTokenString.Split('.');
            string tokenBody = tokenParts[1];
            byte[] tokenBodyBytes = DecodeBytes(tokenBody);

            AccessToken accessToken = null;
            using (MemoryStream memoryStream = new MemoryStream(tokenBodyBytes))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AccessToken));
                accessToken = (AccessToken)ser.ReadObject(memoryStream);
            }

            return UnixTimeEpoch.AddSeconds(accessToken.Expiration);
        }

        /// <summary>
        /// Checks if the token fetched and principalUsed are as expected. 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="principalUsed"></param>
        /// <param name="type"></param>
        /// <param name="tenantId"></param>
        /// <param name="appId"></param>
        /// <param name="thumbprint"></param>
        /// <param name="expiresOn"></param>
        public static void ValidateToken(string token, Principal principalUsed, string type, string tenantId,
            string appId = default, string thumbprint = default, DateTimeOffset expiresOn = default)
        {
            Assert.Equal("eyJ0eXAiOiJKV1Qi", token.Substring(0, "eyJ0eXAiOiJKV1Qi".Length));
            Assert.Contains(".", token);

            // These will always be present
            Assert.Equal(type, principalUsed.Type);
            Assert.True(principalUsed.IsAuthenticated);
            Assert.Equal(tenantId, principalUsed.TenantId);

            string thumbprintPart = string.Empty;
            string upnPart = string.Empty;
            string appIdPart = string.Empty;

            if (string.Equals(type, "App"))
            {
                Assert.Equal(appId, principalUsed.AppId);
                Assert.Null(principalUsed.UserPrincipalName);
                appIdPart = $" AppId:{principalUsed.AppId}";

                if (!string.IsNullOrEmpty(thumbprint))
                {
                    Assert.Equal(thumbprint, principalUsed.CertificateThumbprint);
                    thumbprintPart = $" CertificateThumbprint:{thumbprint}";
                }
            }
            else
            {
                Assert.Null(principalUsed.AppId);
                Assert.Contains("@", principalUsed.UserPrincipalName);
                upnPart = $" UserPrincipalName:{principalUsed.UserPrincipalName}";
            }

            if (expiresOn != default)
            {
                DateTimeOffset tokenExpiration = GetTokenExpiration(token);

                var delta = tokenExpiration.UtcDateTime - expiresOn.UtcDateTime;

                // the expirations can differ a fraction of a second for integration/E2E tests
                Assert.True(delta < TimeSpan.FromSeconds(1));
            }

            Assert.Equal($"IsAuthenticated:True Type:{type}{appIdPart} TenantId:{principalUsed.TenantId}{thumbprintPart}{upnPart}",
                principalUsed.ToString());
        }
        
    }
}

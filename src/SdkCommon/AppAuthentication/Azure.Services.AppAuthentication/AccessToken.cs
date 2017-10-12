// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Used to hold the deserialized access token. 
    /// </summary>
    [DataContract]
    internal class AccessToken
    {
        private const char Base64PadCharacter = '=';
        private const char Base64Character62 = '+';
        private const char Base64Character63 = '/';
        private const char Base64UrlCharacter62 = '-';
        private const char Base64UrlCharacter63 = '_';
        private static readonly string DoubleBase64PadCharacter = string.Format(CultureInfo.InvariantCulture, "{0}{0}", Base64PadCharacter);

        private string _accessToken;

        private const string TokenFormatExceptionMessage = "Access token is not in the expected format.";

        // These fields are assigned to by JSON deserialization
        [DataMember(Name = "upn", IsRequired = false)]
        public string Upn { get; private set; }

        [DataMember(Name = "tid", IsRequired = false)]
        public string TenantId { get; private set; }

        [DataMember(Name = "email", IsRequired = false)]
        public string Email { get; private set; }

        [DataMember(Name = "appid", IsRequired = false)]
        public string AppId { get; private set; }

        [DataMember(Name = "exp", IsRequired = true)]
        public long ExpiryTime { get; private set; }

        public static AccessToken Parse(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            try
            {
                // Access token as 3 parts. We are interested in the second part, which has claims. 
                string[] splitStrings = accessToken.Split('.');

                var token = JsonHelper.Deserialize<AccessToken>(DecodeBytes(splitStrings[1]));
                
                token._accessToken = accessToken;

                return token;
            }
            catch (Exception exp)
            {
                throw new FormatException($"{TokenFormatExceptionMessage} Exception: {exp.Message}");
            }
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

        /// <summary>
        /// Return the access token as-is
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _accessToken;
        }

        /// <summary>
        /// Check if the token is about to expire
        /// </summary>
        /// <returns></returns>
        public bool IsAboutToExpire()
        {
            // Current time represented in seconds since 1/1/1970
            double currentTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            
            // If the expiration time is greater than current time by more than 5 minutes, it is not about to expire
            if (ExpiryTime > currentTime + 5 * 60)
            {
                return false;
            }

            return true;
        }
    }
}

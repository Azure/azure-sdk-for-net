// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Used to hold the deserialized token response. 
    /// </summary>
    [DataContract]
    internal class TokenResponse
    {
        private const string TokenResponseFormatExceptionMessage = "Token response is not in the expected format.";


        // VS token service and MSI endpoint return access_token
        [DataMember(Name = "access_token", IsRequired = false)]
        public string AccessToken { get; private set; }

        // Azure CLI returns accessToken
        [DataMember(Name = "accessToken", IsRequired = false)]
        public string AccessToken2 { get; private set; }

        // VS token service and MSI endpoint return expires_on
        [DataMember(Name = "expires_on", IsRequired = false)]
        public string ExpiresOn { get; private set; }

        // Azure CLI returns expiresOn
        [DataMember(Name = "expiresOn", IsRequired = false)]
        public string ExpiresOn2 { get; private set; }

        // VS token service returns resource
        [DataMember(Name = "resource", IsRequired = false)]
        public string Resource { get; private set; }

        // VS token service and MSI endpoint return token_type
        [DataMember(Name = "token_type", IsRequired = false)]
        public string TokenType { get; private set; }

        // Azure CLI returns tokenType
        [DataMember(Name = "tokenType", IsRequired = false)]
        public string TokenType2 { get; private set; }

        /// <summary>
        /// Parse token response returned from OAuth provider.
        /// While more fields are returned, we only need the access token. 
        /// </summary>
        /// <param name="tokenResponse">This is the response received from OAuth endpoint that has the access token in it.</param>
        /// <returns></returns>
        public static TokenResponse Parse(string tokenResponse)
        {
            try
            {
                return JsonHelper.Deserialize<TokenResponse>(Encoding.UTF8.GetBytes(tokenResponse));
            }
            catch (Exception exp)
            {
                throw new FormatException($"{TokenResponseFormatExceptionMessage} Exception Message: {exp.Message}");
            }
        }

    }
}

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Contains access token and other results from a token request call
    /// </summary>
    public class AppAuthenticationResult
    {
        /// <summary>
        /// The access token returned from the token request
        /// </summary>
        [DataMember]
        public string AccessToken { get; private set; }

        /// <summary>
        /// The time when the access token expires
        /// </summary>
        [DataMember]
        public DateTimeOffset ExpiresOn { get; private set; }

        /// <summary>
        /// The Resource URI of the receiving web service
        /// </summary>
        [DataMember]
        public string Resource { get; private set; }

        /// <summary>
        /// Indicates the token type value
        /// </summary>
        [DataMember]
        public string TokenType { get; private set; }

        /// <summary>
        /// Return true when access token is near expiration
        /// </summary>
        /// <returns></returns>
        internal bool IsNearExpiry()
        {
            // If the expiration time is within the next 5 minutes, the token is about to expire
            return ExpiresOn < DateTimeOffset.UtcNow.AddMinutes(5);
        }

        internal static AppAuthenticationResult Create(TokenResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            string expiresOnString = response.ExpiresOn ?? response.ExpiresOn2;
            DateTimeOffset expiresOn = DateTimeOffset.MinValue;

            if (double.TryParse(expiresOnString, out double seconds))
            {
                expiresOn = AppAuthentication.AccessToken.UnixTimeEpoch.AddSeconds(seconds);
            }
            else if (!DateTimeOffset.TryParse(expiresOnString, out expiresOn))
            {
                throw new ArgumentException("ExpiresOn in token response could not be parsed");
            }

            var result = new AppAuthenticationResult()
            {
                AccessToken = response.AccessToken ?? response.AccessToken2,
                ExpiresOn = expiresOn,
                Resource = response.Resource,
                TokenType = response.TokenType ?? response.TokenType2
            };

            return result;
        }

        internal static AppAuthenticationResult Create(AuthenticationResult authResult)
        {
            if (authResult == null)
            {
                throw new ArgumentNullException(nameof(authResult));
            }

            var result = new AppAuthenticationResult()
            {
                AccessToken = authResult.AccessToken,
                ExpiresOn = authResult.ExpiresOn
            };

            return result;
        }

        // For unit testing
        internal static AppAuthenticationResult Create(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            var tokenObj = AppAuthentication.AccessToken.Parse(accessToken);

            var result = new AppAuthenticationResult
            {
                AccessToken = accessToken,
                ExpiresOn = AppAuthentication.AccessToken.UnixTimeEpoch.AddSeconds(tokenObj.ExpiryTime)
            };

            return result;
        }
    }
}

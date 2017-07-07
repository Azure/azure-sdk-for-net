// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

// SDK
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace TestCommon
{
    public class Authentification
    {

        /// <summary>
        /// Token for communication with Azure or Azure Stack
        /// </summary>
        public static string Token { get; private set; }

        /// <summary>
        /// Credentials for Azure or Azure Stack
        /// </summary>
        public static ServiceClientCredentials Credentials { get; private set; }

        /// <summary>
        ///     Returns a token using a username and password
        /// </summary>
        /// <param name="username">The full username used to login</param>
        /// <param name="password">The password associated with username</param>
        /// <param name="tenantId">tenantId associated with account</param>
        /// <param name="applicationId">application id associated with account</param>
        /// <param name="clientId">clientId associated with account</param>
        /// <returns>Access token for application</returns>
        public static string GetToken(string username, string password, string tenantId, string applicationId, string clientId)
        {
            if (Token == null) {
                var context = new AuthenticationContext("https://login.windows.net/" + tenantId, false);

                var userCredentials = new UserCredential(username, password);
                var authResult = context.AcquireTokenAsync(applicationId, clientId, userCredentials).Result;

                if (authResult == null) {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }

                Token = authResult.AccessToken;
            }
            return Token;
        }
        /// <summary>
        ///     Returns a token using a resource and secret
        /// </summary>
        /// <param name="resource">The resource we want to accesss</param>
        /// <param name="secret">The secret associated with the application</param>
        /// <param name="tenantId">tenantId associated with account</param>
        /// <param name="applicationId">application id associated with account</param>
        /// <returns>Access token for application</returns>
        public static string GetToken(string resource, string secret, string tenantId, string applicationId)
        {
            if (Token == null) {
                var context = new AuthenticationContext("https://login.windows.net/" + tenantId, false);
                var clientCredentials = new ClientCredential(applicationId, secret);
                var authResult = context.AcquireTokenAsync(resource, clientCredentials).Result;

                if (authResult == null) {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }

                Token = authResult.AccessToken;
            }
            return Token;
        }

        /// <summary>
        /// Generate credentials using the information provided.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="tenantId"></param>
        /// <param name="applicationId"></param>
        /// <param name="clientId"></param>
        /// <returns>Credentials requied to access Azure or Azure Stack resources</returns>
        public static ServiceClientCredentials GetCredentials(string username, string password, string tenantId, string applicationId, string clientId)
        {
            if (Credentials == null) {
                Credentials = new TokenCredentials(GetToken(username, password, tenantId, applicationId, clientId));
            }
            return Credentials;
        }
        /// <summary>
        /// Generate credentials using the information provided.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="secret"></param>
        /// <param name="tenantId"></param>
        /// <param name="applicationId"></param>
        /// <returns>Credentials requied to access Azure or Azure Stack resources</returns>
        public static ServiceClientCredentials GetCredentials(string resource, string secret, string tenantId, string applicationId)
        {
            if (Credentials == null) {
                Credentials = new TokenCredentials(GetToken(resource, secret, tenantId, applicationId));
            }
            return Credentials;
        }

        /// <summary>
        /// Get credentials using testing parameters
        /// </summary>
        /// <param name="parameters">Holds information needed to construct a credential.</param>
        /// <returns>Credentials</returns>
        public static ServiceClientCredentials GetCredentials(TestingParameters parameters)
        {
            if (Credentials == null) {
                if (!String.IsNullOrEmpty(parameters.Username) && !String.IsNullOrEmpty(parameters.Username)) {
                    Credentials = GetCredentials(parameters.Username, parameters.Password, parameters.TenantId, parameters.ApplicationId, parameters.ClientId);
                } else if (!String.IsNullOrEmpty(parameters.Resource) && !String.IsNullOrEmpty(parameters.Secret)) {
                Credentials = GetCredentials(parameters.Resource, parameters.Secret, parameters.TenantId, parameters.ApplicationId);
                } else {
                    throw new ArgumentException("Testing parameters must either support username/password or Resource/Secret authentification");
                }
            }
        return Credentials;
        }

    }
}

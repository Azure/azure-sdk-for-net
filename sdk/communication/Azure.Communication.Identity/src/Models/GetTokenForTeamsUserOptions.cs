// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// Options used to exchange an AAD access token of a Teams user for a new Communication Identity access token.
    /// </summary>
    public class GetTokenForTeamsUserOptions
    {
        /// <summary>
        /// Azure AD access token of a Teams user.
        /// </summary>
        public string TeamsUserAadToken { get; }

        /// <summary>
        /// Client ID of an Azure AD application to be verified against the appId claim in the Azure AD access token.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// Object ID of an Azure AD user (Teams User) to be verified against the OID claim in the Azure AD access token.
        /// </summary>
        public string UserObjectId { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GetTokenForTeamsUserOptions"/>.
        /// </summary>
        /// <param name="teamsUserAadToken">Azure AD access token of a Teams User.</param>
        /// <param name="clientId">Client ID of an Azure AD application to be verified against the appId claim in the Azure AD access token.</param>
        /// <param name="userObjectId">Object ID of an Azure AD user (Teams User) to be verified against the OID claim in the Azure AD access token.</param>
        public GetTokenForTeamsUserOptions(
            string teamsUserAadToken,
            string clientId,
            string userObjectId)
        {
            TeamsUserAadToken = teamsUserAadToken;
            ClientId = clientId;
            UserObjectId = userObjectId;
        }
    }
}

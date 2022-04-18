// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Identity.Tests.Infrastructure
{
    /// <summary> The TeamsUserParams. </summary>
    public partial class TeamsUserParams
    {
        /// <summary> Initializes a new instance of TeamsUserParams. </summary>
        /// <param name="token"> Azure AD access token of a Teams User to acquire a new Communication Identity access token. </param>
        /// <param name="appId"> Client ID of an Azure AD application to be verified against the appid claim in the Azure AD access token. </param>
        /// <param name="userId"> Object ID of an Azure AD user (Teams User) to be verified against the oid claim in the Azure AD access token. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/>, <paramref name="appId"/> or <paramref name="userId"/> is null. </exception>
        public TeamsUserParams(string token, string appId, string userId)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            if (appId == null)
            {
                throw new ArgumentNullException(nameof(appId));
            }
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            Token = token;
            AppId = appId;
            UserId = userId;
        }

        /// <summary> Azure AD access token of a Teams User to acquire a new Communication Identity access token. </summary>
        public string Token { get; set; }
        /// <summary> Client ID of an Azure AD application to be verified against the appid claim in the Azure AD access token. </summary>
        public string AppId { get; set; }
        /// <summary> Object ID of an Azure AD user (Teams User) to be verified against the oid claim in the Azure AD access token. </summary>
        public string UserId { get; set; }
    }
}

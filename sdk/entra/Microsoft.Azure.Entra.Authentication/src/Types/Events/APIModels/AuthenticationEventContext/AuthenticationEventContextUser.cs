// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// User represents a subset of the Microsoft Graph user properties of the user signIng in.
    /// For properties that are included, they are same as properties as in the Microsoft Graph user object.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AuthenticationEventContextUser
    {
        /// <summary>
        /// The organization name for the user.
        /// </summary>
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        /// <summary>Gets or sets the created on date time.</summary>
        /// <value>The created on date time.</value>
        [JsonProperty("createdDateTime")]
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// The display name for the user.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The given name for the user.
        /// </summary>
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        /// <summary>
        ///  The object ID of the user.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///  The email address of the user.
        /// </summary>
        [JsonProperty("mail")]
        public string Mail { get; set; }

        /// <summary>
        ///  The name of on premise Sam account.
        /// </summary>
        [JsonProperty("onPremisesSamAccountName")]
        public string OnPremisesSamAccountName { get; set; }

        /// <summary>
        ///  The identifier of on premise user principal.
        /// </summary>
        [JsonProperty("onPremisesSecurityIdentifier")]
        public string OnPremisesSecurityIdentifier { get; set; }

        /// <summary>
        /// The name of on premise user principal.
        /// </summary>
        [JsonProperty("onPremisesUserPrincipalName")]
        public string OnPremisesUserPrincipalName { get; set; }

        /// <summary>
        /// The preferred data location for the user.
        /// </summary>
        [JsonProperty("preferredDataLocation")]
        public string PreferredDataLocation { get; set; }

        /// <summary>
        /// The preferred language for the user.
        /// </summary>
        [JsonProperty("preferredLanguage")]
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// The surname of the user.
        /// </summary>
        [JsonProperty("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// The name address of the user principal.
        /// </summary>
        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        ///  The type of the user.
        /// </summary>
        [JsonProperty("userType")]
        public string UserType { get; set; }
    }
}

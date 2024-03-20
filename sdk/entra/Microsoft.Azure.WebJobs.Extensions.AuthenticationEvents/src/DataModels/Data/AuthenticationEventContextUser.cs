// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data
{
    /// <summary>Represents the User Data Model Object.</summary>
    public partial class AuthenticationEventContextUser
    {
        /// <summary>Gets the name of the company.</summary>
        /// <value>The name of the company.</value>
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        /// <summary>Gets or sets the created date and time.</summary>
        /// <value>The created date and time.</value>
        [JsonPropertyName("createdDateTime")]
        public string CreatedDateTime { get; set; }

        /// <summary>Gets the display name.</summary>
        /// <value>The display name.</value>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>Gets the first name.</summary>
        /// <value>The name of the given.</value>
        [JsonPropertyName("givenName")]
        public string GivenName { get; set; }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonPropertyName("id")]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets the mail address.</summary>
        /// <value>The mail.</value>
        [JsonPropertyName("mail")]
        public string Mail { get; set; }

        /// <summary>Gets the name of the on premises sam account.</summary>
        /// <value>The name of the on premises sam account.</value>
        [JsonPropertyName("onPremisesSamAccountName")]
        public string OnPremisesSamAccountName { get; set; }

        /// <summary>Gets the on premises security identifier.</summary>
        /// <value>The on premises security identifier.</value>
        [JsonPropertyName("onPremisesSecurityIdentifier")]
        public string OnPremisesSecurityIdentifier { get; set; }

        /// <summary>Gets the name of the on premise user principal.</summary>
        /// <value>The name of the on premise user principal.</value>
        [JsonPropertyName("onPremiseUserPrincipalName")]
        public string OnPremiseUserPrincipalName { get; set; }

        /// <summary>Gets the preferred data location.</summary>
        /// <value>The preferred data location.</value>
        [JsonPropertyName("preferredDataLocation")]
        public string PreferredDataLocation { get; set; }

        /// <summary>Gets the preferred language.</summary>
        /// <value>The preferred language.</value>
        [JsonPropertyName("preferredLanguage")]
        public string PreferredLanguage { get; set; }

        /// <summary>Gets the surname.</summary>
        /// <value>The surname.</value>
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        /// <summary>Gets the name of the user principal.</summary>
        /// <value>The name of the user principal.</value>
        [JsonPropertyName("userPrincipalName")]
        [Required]
        public string UserPrincipalName { get; set; }

        /// <summary>Gets the type of the user.</summary>
        /// <value>The type of the user.</value>
        [JsonPropertyName("userType")]
        public string UserType { get; set; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>Represents a Token Claim.</summary>
    public class WebjobsAuthenticationEventsTokenClaim
    {
        /// <summary>Initializes a new instance of the <see cref="WebjobsAuthenticationEventsTokenClaim" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="values">The values.</param>
        public WebjobsAuthenticationEventsTokenClaim(string id, params string[] values)
        {
            Id = id;
            Values = values;
        }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonPropertyName("id")]
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }

        /// <summary>Gets or sets the values.</summary>
        /// <value>The values.</value>
        [JsonPropertyName("values")]
        [RequireNonDefault]
        public string[] Values { get; set; }
    }
}

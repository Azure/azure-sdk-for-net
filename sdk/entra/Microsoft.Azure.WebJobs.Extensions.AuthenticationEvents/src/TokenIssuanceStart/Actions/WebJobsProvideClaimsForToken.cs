// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    /// <summary>A representation of the WebJobsProvideClaimsForToken action.</summary>
    public partial class WebJobsProvideClaimsForToken : WebJobsTokenIssuanceAction
    {
        /// <summary>Gets or sets the claims.</summary>
        /// <value>The claims.</value>
        [JsonPropertyName("claims")]
        [Required]
        public List<WebJobsAuthenticationEventsTokenClaim> Claims { get; } = new List<WebJobsAuthenticationEventsTokenClaim>();

        /// <summary>Gets the type of the action of WebJobsProvideClaimsForToken.</summary>
        /// <value>The type of the action.</value>
        [JsonPropertyName("actionType")]
        [OneOf("microsoft.graph.tokenIssuanceStart.provideClaimsForToken")]
        internal override string ActionType => "microsoft.graph.tokenIssuanceStart.provideClaimsForToken";

        /// <summary>Initializes a new instance of the <see cref="WebJobsProvideClaimsForToken" /> class.</summary>
        public WebJobsProvideClaimsForToken() { }
        /// <summary>Initializes a new instance of the <see cref="WebJobsProvideClaimsForToken" /> class.</summary>
        /// <param name="claim">A collection of claims to add.</param>
        public WebJobsProvideClaimsForToken(params WebJobsAuthenticationEventsTokenClaim[] claim)
        {
            if (claim != null)
            {
                Claims.AddRange(claim);
            }
            else
            {
                Claims = null;
            }
        }

        /// <summary>Adds a claim to the collection.</summary>
        /// <param name="Id">The claim identifier.</param>
        /// <param name="Values">The claim values.</param>
        public void AddClaim(string Id, params string[] Values)
        {
            Claims.Add(new WebJobsAuthenticationEventsTokenClaim(Id, Values));
        }

        /// <summary>Builds the action body.</summary>
        /// <returns>A JObject representing the claims in Json format.</returns>
        internal override AuthenticationEventJsonElement BuildActionBody()
        {
            AuthenticationEventJsonElement jsonClaims = new AuthenticationEventJsonElement();
            Claims.ForEach(c => jsonClaims.Properties.Add(c.Id,
                c.Values == null ?
                    null :
                    c.Values.Length == 1 ?
                        (object)c.Values[0] :
                        c.Values.Select(x => new AuthenticationEventJsonElement() { Value = x, NullAsEmptyObject = false }).ToList()));

            return new AuthenticationEventJsonElement(new Dictionary<string, object> { { "claims", jsonClaims } });
        }

        /// <summary>Create the WebJobsProvideClaimsForToken action
        /// from Json. </summary>
        /// <param name="actionBody">The action body.</param>
        internal override void FromJson(AuthenticationEventJsonElement actionBody)
        {
            AuthenticationEventJsonElement claims = actionBody.FindFirstElementNamed("claims");

            if (claims != null)
            {
                foreach (var key in claims.Properties.Keys)
                {
                    var val = claims.GetPropertyValue<object>(key);
                    if (val is string sValue)
                    {
                        AddClaim(key, sValue);
                    }
                    else if (val is AuthenticationEventJsonElement jValue)
                    {
                        AddClaim(key, jValue.Elements.Select(x => x.Value).ToArray());
                    }
                }
            }
        }
    }
}

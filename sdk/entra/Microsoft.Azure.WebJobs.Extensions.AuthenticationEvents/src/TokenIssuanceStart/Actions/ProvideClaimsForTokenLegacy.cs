// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions
{
    /// <summary>A representation of the ProvideClaimsForToken action for the legacy payload.</summary>
    /// TODO: This must be removed legacy support is dropped.
    internal partial class ProvideClaimsForTokenLegacy : ProvideClaimsForToken
    {
        /// <summary>Gets the type of the action of ProvideClaimsForToken.</summary>
        /// <value>The type of the action.</value>
        [JsonPropertyName("actionType")]
        [OneOf("ProvideClaimsForToken")]
        internal override string ActionType => "ProvideClaimsForToken";
        internal override string TypeProperty => "type";
        /// <summary>Initializes a new instance of the <see cref="ProvideClaimsForTokenLegacy" /> class.</summary>
        public ProvideClaimsForTokenLegacy() { }
        public ProvideClaimsForTokenLegacy(ProvideClaimsForToken provideClaimsForToken)
        {
            if (provideClaimsForToken != null)
            {
                Claims.AddRange(provideClaimsForToken.Claims);
            }
        }
        /// <summary>Initializes a new instance of the <see cref="ProvideClaimsForTokenLegacy" /> class.</summary>
        /// <param name="claim">A collection of claims to add.</param>
        public ProvideClaimsForTokenLegacy(params TokenClaim[] claim)
        {
            if (claim != null)
            {
                Claims.AddRange(claim);
            }
        }

        /// <summary>Builds the action body.</summary>
        /// <returns>A JObject representing the claims in Json format.</returns>
        internal override AuthenticationEventJsonElement BuildActionBody()
        {
            var body = Claims.Select(x => x.Values.Length == 1 ?
               new AuthenticationEventJsonElement($"{{\"id\":\"{x.Id}\", \"value\":\"{x.Values[0]}\" }}") :
               new AuthenticationEventJsonElement($"{{\"id\":\"{x.Id}\", \"value\":[{string.Join(", ", x.Values.Select(v => $"\"{v}\""))}] }}")
            ).ToList();

            return new AuthenticationEventJsonElement(new Dictionary<string, object> { { "claims", body } });
        }

        /// <summary>Create the ProvideClaimsForToken action
        /// from Json. </summary>
        /// <param name="actionBody">The action body.</param>
        internal override void FromJson(AuthenticationEventJsonElement actionBody)
        {
            AuthenticationEventJsonElement claims = actionBody.FindFirstElementNamed("claims");
            if (claims != null)
            {
                foreach (AuthenticationEventJsonElement claim in claims.Elements)
                {
                    var value = claim.GetPropertyValue<object>("value");
                    if (value is string sValue)
                    {
                        AddClaim(claim.GetPropertyValue("id"), sValue);
                    }
                    else if (value is AuthenticationEventJsonElement jValue)
                    {
                        AddClaim(claim.GetPropertyValue("id"), jValue.Elements.Select(x => x.Value).ToArray());
                    }
                }
            }
        }
    }
}

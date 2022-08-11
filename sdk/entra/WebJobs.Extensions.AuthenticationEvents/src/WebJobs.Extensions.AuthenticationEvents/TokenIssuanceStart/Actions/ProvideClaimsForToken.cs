// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions
{
    /// <summary>A representation of the ProvideClaimsForToken action.</summary>
    public partial class ProvideClaimsForToken : TokenIssuanceAction
    {
        /// <summary>Gets or sets the claims.</summary>
        /// <value>The claims.</value>
        [JsonPropertyName("claims")]
        public List<TokenClaim> Claims { get; } = new List<TokenClaim>();

        /// <summary>Gets the type of the action of ProvideClaimsForToken.</summary>
        /// <value>The type of the action.</value>
        [JsonPropertyName("actionType")]
        [OneOf("ProvideClaimsForToken")]
        internal override string ActionType => "ProvideClaimsForToken";

        /// <summary>Initializes a new instance of the <see cref="ProvideClaimsForToken" /> class.</summary>
        public ProvideClaimsForToken() { }
        /// <summary>Initializes a new instance of the <see cref="ProvideClaimsForToken" /> class.</summary>
        /// <param name="claim">A collection of claims to add.</param>
        public ProvideClaimsForToken(params TokenClaim[] claim)
        {
            Claims.AddRange(claim);
        }

        /// <summary>Adds a claim to the collection.</summary>
        /// <param name="Id">The claim identifier.</param>
        /// <param name="Values">The claim values.</param>
        public void AddClaim(string Id, params string[] Values)
        {
            Claims.Add(new TokenClaim(Id, Values));
        }

        /// <summary>Builds the action body.</summary>
        /// <returns>A JObject representing the claims in Json format.</returns>
        internal override AuthEventJsonElement BuildActionBody()
        {
            //Create the json based on the current claims, for example... {"id":"DateOfBirth","value":"01-01-1990"} or {"id":"Roles","value":["Writer", "Editor"]}
            var body = Claims.Select(x => x.Values.Length == 1 ?
                new AuthEventJsonElement($"{{\"{x.Id}\":\"{x.Values[0]}\" }}") :
                new AuthEventJsonElement($"{{\"{x.Id}\": [{string.Join(", ", x.Values.Select(v => $"\"{v}\""))}] }}")
             ).ToList();

            return new AuthEventJsonElement(new Dictionary<string, object> { { "claims", body } });
        }

        /// <summary>Create the ProvideClaimsForToken action
        /// from Json. </summary>
        /// <param name="actionBody">The action body.</param>
        internal override void FromJson(AuthEventJsonElement actionBody)
        {
            AuthEventJsonElement claims = actionBody.FindFirstElementNamed("claims");
            if (claims != null)
                foreach (AuthEventJsonElement claim in claims.Elements)
                {
                    var value = claim.GetPropertyValue<object>("value");
                    if (value != null)//TODO: Remove: Old preview version.
                    {
                        if (value is string sValue)
                            AddClaim(claim.GetPropertyValue("id"), sValue);
                        else if (value is AuthEventJsonElement jValue)
                            AddClaim(claim.GetPropertyValue("id"), jValue.Elements.Select(x => x.Value).ToArray());
                    }
                    else
                    {
                        foreach (var key in claim.Properties.Keys)
                        {
                            var val = claim.GetPropertyValue<object>(key);
                            if (val is string sValue)
                                AddClaim(key, sValue);
                            else if (val is AuthEventJsonElement jValue)
                                AddClaim(key, jValue.Elements.Select(x => x.Value).ToArray());
                        }
                    }
                }
        }
    }
}

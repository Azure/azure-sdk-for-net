// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>The model for ProvideClaimsForToken action</summary>
    public class ProvideClaimsForTokenAction : TokenIssuanceStartAction
    {
        /// <summary>
        /// This is needed for backward compatibility with older contract version.
        /// NOTE: DO NOT REMOVE THIS.
        /// </summary>
        public static readonly string LegacyODataTypeName = GetODataName(actionName: "ProvideClaimsForToken", eventName: null);

        /// <summary>
        /// Odata Type Name for the action.
        /// </summary>
        public static readonly string ODataTypeName = GetODataName(actionName: "ProvideClaimsForToken");

        /// <summary>Gets or sets the claims.</summary>
        /// <value>The claims.</value>
        [JsonProperty("claims")]
        public IReadOnlyDictionary<string, IList<string>> Claims { get; set; }
    }
}

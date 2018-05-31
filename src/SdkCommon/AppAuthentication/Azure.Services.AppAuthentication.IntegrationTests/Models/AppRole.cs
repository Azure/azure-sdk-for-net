// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models
{
    /// <summary>
    /// Class to deserialize Azure AD AppRole into.  
    /// </summary>
    public class AppRole
    {
        [JsonProperty("allowedMemberTypes@odata.type")]
        public string AllowedMemberTypesODataType { get; set; }

        [JsonProperty("allowedMemberTypes")]
        public IList<string> AllowedMemberTypes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

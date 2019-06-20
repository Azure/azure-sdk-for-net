// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models
{
    /// <summary>
    /// Class to deserialize Azure AD KeyCredential into.  
    /// </summary>
    public class KeyCredential
    {
        [JsonProperty("customKeyIdentifier")]
        public object CustomKeyIdentifier { get; set; }

        [JsonProperty("endDate")]
        public object EndDate { get; set; }

        [JsonProperty("keyId")]
        public object KeyId { get; set; }

        [JsonProperty("startDate")]
        public object StartDate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("usage")]
        public string Usage { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

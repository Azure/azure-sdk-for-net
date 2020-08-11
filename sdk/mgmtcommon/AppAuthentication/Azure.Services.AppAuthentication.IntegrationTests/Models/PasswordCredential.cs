// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models
{
    /// <summary>
    /// Class to deserialize Azure AD PasswordCredential into.  
    /// </summary>
    public class PasswordCredential
    {
        [JsonProperty("customKeyIdentifier")]
        public object CustomKeyIdentifier { get; set; }

        [JsonProperty("endDate")]
        public object EndDate { get; set; }

        [JsonProperty("keyId")]
        public object KeyId { get; set; }

        [JsonProperty("startDate")]
        public object StartDate { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

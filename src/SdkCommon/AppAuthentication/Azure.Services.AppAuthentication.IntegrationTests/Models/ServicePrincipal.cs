// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models
{
    /// <summary>
    /// Class to deserialize Azure AD ServicePrincipal into.  
    /// </summary>
    public class ServicePrincipal
    {
        [JsonProperty("odata.type")]
        public string OdataType { get; set; }

        [JsonProperty("accountEnabled")]
        public bool AccountEnabled { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}

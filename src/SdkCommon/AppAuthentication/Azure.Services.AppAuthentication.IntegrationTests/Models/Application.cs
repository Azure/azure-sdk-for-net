// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models
{
    /// <summary>
    /// Class to deserialize Azure AD Application into.  
    /// </summary>
    public class Application
    {
        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

        [JsonProperty("odata.type")]
        public string OdataType { get; set; }

        [JsonProperty("appRoles@odata.type")]
        public string AppRolesODataType { get; set; }

        [JsonProperty("appRoles")]
        public IList<AppRole> AppRoles { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        
        [JsonProperty("identifierUris")]
        public IList<string> IdentifierUris { get; set; }

        [JsonProperty("identifierUris@odata.type")]
        public string IdentifierUrisODataType { get; set; }

        [JsonProperty("replyUrls@odata.type")]
        public string ReplyUrlsODdataType { get; set; }

        [JsonProperty("replyUrls")]
        public IList<string> ReplyUrls { get; set; }

        [JsonProperty("keyCredentials@odata.type")]
        public string KeyCredentialsODdataType { get; set; }

        [JsonProperty("keyCredentials")]
        public IList<KeyCredential> KeyCredentials { get; set; }
        [JsonProperty("passwordCredentials@odata.type")]
        public string PasswordCredentialsODdataType { get; set; }

        [JsonProperty("passwordCredentials")]
        public IList<PasswordCredential> PasswordCredentials { get; set; }

        public ServicePrincipal ServicePrincipal { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.SignClient
{
    using Newtonsoft.Json;
    public partial class SignClientPolicyConfig : EsrpServiceModelBase<SignClientPolicyConfig>
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Intent")]
        public string Intent { get; set; }

        [JsonProperty("ContentType")]
        public string ContentType { get; set; }

        [JsonProperty("ContentOrigin")]
        public string ContentOrigin { get; set; }

        [JsonProperty("ProductState")]
        public string ProductState { get; set; }

        [JsonProperty("Audience")]
        public string Audience { get; set; }
    }
}
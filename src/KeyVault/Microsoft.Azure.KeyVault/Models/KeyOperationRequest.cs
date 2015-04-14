//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using Microsoft.Azure.KeyVault.WebKey.Json;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault
{
    [JsonObject]
    public class KeyOperationRequest
    {

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Algorithm, Required = Required.Always)]
        public string Alg { get; set; }

        // Data to be encrypted.
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always)]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value { get; set; }
        
        public override string ToString()
        {            
            return JsonConvert.SerializeObject(this);
        }
    }
}

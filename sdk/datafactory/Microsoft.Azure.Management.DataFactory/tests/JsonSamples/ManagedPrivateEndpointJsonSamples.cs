// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class ManagedPrivateEndpointJsonSamples : JsonSampleCollection<ManagedPrivateEndpointJsonSamples>
    {
        [JsonSample]
        public const string ManagedPrivateEndpointSample = @"
          {
              ""name"": ""pe1"",
              ""properties"": {
                  ""privateLinkResourceId"": ""/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/sampleResourceGroup/providers/Microsoft.Storage/storageAccounts/sampleStorageAccount"",
                  ""groupId"": ""blob""
              }
          }";

        [JsonSample]
        public const string ManagedPrivateEndpointFqdnsSample = @"
          {
              ""name"": ""pe2"",
              ""properties"": {
                  ""privateLinkResourceId"": ""/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/sampleResourceGroup/providers/Microsoft.Storage/storageAccounts/sampleStorageAccount"",
                  ""groupId"": ""blob"",
                  ""fqdns"": [
                      ""darosalestorageaccount.blob.core.windows.net""
                  ]
              }
          }";
    }
}

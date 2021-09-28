// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class IntegrationRuntimeJsonSamples : JsonSampleCollection<IntegrationRuntimeJsonSamples>
    {
        [JsonSample]
        public const string AzureSSISIntegrationRuntime = @"
{
  ""properties"": {
    ""type"": ""Managed"",
    ""typeProperties"": {
      ""computeProperties"": {
        ""location"": ""West Us"",
        ""nodeSize"": ""standard_d2_v3"",
        ""numberOfNodes"": 1,
        ""maxParallelExecutionsPerNode"": 4,
        ""vNetProperties"": {
          ""subnetId"": ""/subscriptions/1491d049-b7ce-4dc5-9833-d2947b0bd2e1/Azure_SSIS_API/providers/Microsoft.Network/virtualNetworks/FirstVNetForAzureSSIS/subnets/default""
        }
      },
      ""ssisProperties"": {
        ""licenseType"": ""BasePrice"",
        ""edition"": ""Standard""
      },
      ""customerVirtualNetwork"":{
        ""subnetId"":""fakeId""
      }
    }
  },
  ""name"": ""rpV2testIntegrationRuntime-1cec239b-0b0a-460f-9e7a-0dfff4b885e6""
}";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class DataFlowJsonSamples : JsonSampleCollection<DataFlowJsonSamples>
    {
        [JsonSample]
        public const string MappingDataFlow = @"
      {
        ""name"": ""exampleDataFlow"",
        ""properties"": {
          ""description"": ""Sample demo data flow to convert currencies showing usage of union, derive and conditional split transformation."",
          ""type"": ""MappingDataFlow"",
          ""typeProperties"": {
            ""sources"": [
              {
                ""dataset"": {
                  ""referenceName"": ""CurrencyDatasetUSD"",
                  ""type"": ""DatasetReference""
                },
                ""name"": ""USDCurrency""
              },
              {
                ""dataset"": {
                  ""referenceName"": ""CurrencyDatasetCAD"",
                  ""type"": ""DatasetReference""
                },
                ""name"": ""CADSource""
              }
            ],
            ""sinks"": [
              {
                ""dataset"": {
                  ""referenceName"": ""USDOutput"",
                  ""type"": ""DatasetReference""
                },
                ""name"": ""USDSink""
              },
              {
                ""dataset"": {
                  ""referenceName"": ""CADOutput"",
                  ""type"": ""DatasetReference""
                },
                ""name"": ""CADSink""
              }
            ],
            ""script"": ""some script""
          }
        }
      }
";
    }
}

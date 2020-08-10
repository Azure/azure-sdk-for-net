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
        [JsonSample]
        public const string MappingDataFlowWithLinkedServices = @"
      {
        ""name"": ""exampleDataFlow"",
        ""properties"": {
          ""description"": ""Sample demo data flow to convert currencies showing usage of union, derive and conditional split transformation."",
          ""type"": ""MappingDataFlow"",
          ""typeProperties"": {
            ""sources"": [
              {
                ""linkedService"": {
                  ""referenceName"": ""SourceLinkedService"",
                  ""type"": ""LinkedServiceReference""
                },
                ""schemaLinkedService"": {
                  ""referenceName"": ""SourceSchemaLinkedService"",
                  ""type"": ""LinkedServiceReference""
                },
                ""name"": ""USDCurrency""
              }
            ],
            ""sinks"": [
              {
                ""linkedService"": {
                  ""referenceName"": ""SinkLinkedService"",
                  ""type"": ""LinkedServiceReference""
                },
                ""schemaLinkedService"": {
                  ""referenceName"": ""SinkSchemaLinkedService"",
                  ""type"": ""LinkedServiceReference""
                },
                ""name"": ""USDSink""
              }
            ],
            ""script"": ""some script""
          }
        }
      }
";

        [JsonSample]
        public const string MappingDataFlowWithSourceSinkStaging = @"
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
                ""name"": ""USDCurrency"",
                ""staging"": {
                    ""linkedService"": {
                       ""referenceName"": ""blob_store_sasToken01"",
                       ""type"": ""LinkedServiceReference""
                    },
                    ""folderPath"":""testcontainer01""
                 }
              }
            ],
            ""sinks"": [
              {
                ""dataset"": {
                  ""referenceName"": ""USDOutput"",
                  ""type"": ""DatasetReference""
                },
                ""name"": ""USDSink"",
                ""staging"": {
                    ""linkedService"": {
                       ""referenceName"": ""blob_store_sasToken02"",
                       ""type"": ""LinkedServiceReference""
                    },
                    ""folderPath"":""testcontainer02""
                 }
              }
            ],
            ""script"": ""some script""
          }
        }
      }
";
    }
}

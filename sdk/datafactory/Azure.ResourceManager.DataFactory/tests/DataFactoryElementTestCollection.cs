// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory.Tests
{
    public class DataFactoryElementTestCollection
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties")]
        public Properties JsonProperties { get; set; }

        public class Properties
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("typeProperties")]
            public TypeProperties JsonTypeProperties { get; set; }

            [JsonPropertyName("schema")]
            public DataFactoryElement<IList<DatasetSchemaDataElement>> Schema { get; set; }

            [JsonPropertyName("linkedServiceName")]
            public DataFactoryLinkedServiceReference LinkedServiceName { get; set; }
        }

        public class TypeProperties
        {
            [JsonPropertyName("connectionString")]
            public DataFactoryElement<string> ConnectionString { get; set; }

            [JsonPropertyName("location")]
            public Location Location { get; set; }

            [JsonPropertyName("columnDelimiter")]
            public string ColumnDelimiter { get; set; }

            [JsonPropertyName("firstRowAsHeader")]
            public bool FirstRowAsHeader { get; set; }
        }

        public class Location
        {
            [JsonPropertyName("container")]
            public DataFactoryElement<string> Container { get; set; }

            [JsonPropertyName("type")]
            public DataFactoryElement<string> Type { get; set; }

            [JsonPropertyName("fileName")]
            public DataFactoryElement<string> FileName { get; set; }
        }
    }
}

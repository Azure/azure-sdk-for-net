// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.Storage.Files.DataLake.Models
{
    internal class DataLakeError
    {
        public DataLakeError() { }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("detail")]
        public Dictionary<string, string> Detail { get; set; }
    }
}

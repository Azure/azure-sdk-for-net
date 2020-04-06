// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Azure.Storage.Files.DataLake.Models
{
    internal class DataLakeErrorWrapper
    {
        [JsonPropertyName("error")]
        public DataLakeError Error { get; set; }

        public DataLakeErrorWrapper() { }
    }
}

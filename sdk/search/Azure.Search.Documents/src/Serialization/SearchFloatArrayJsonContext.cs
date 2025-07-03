// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Search.Documents
{
    /// <summary>
    /// JSON serialization context for AOT-safe serialization of float arrays.
    /// </summary>
    [JsonSerializable(typeof(float[]))]
    internal partial class SearchFloatArrayJsonContext : JsonSerializerContext
    {
    }
}

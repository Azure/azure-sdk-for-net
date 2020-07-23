// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

#pragma warning disable 1591

namespace Azure.Core.JsonPatch
{
    public class JsonPatchOperation
    {
        public JsonPatchOperation(JsonPatchOperationKind kind, string path, string? from, string? rawJsonValue)
        {
            Kind = kind;
            Path = path;
            From = from;
            RawJsonValue = rawJsonValue;
        }

        public JsonPatchOperationKind Kind { get; }
        public string Path { get; }
        public string? From { get; }
        public string? RawJsonValue { get; }
    }
}
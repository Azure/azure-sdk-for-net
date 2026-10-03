// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json.Nodes;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    // Prototype only: this type represents the intended public API.
    public struct ModelJsonBuilder
    {
        private JsonObject _json;

        public ModelJsonBuilder(BinaryData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _json = JsonNode.Parse(data.ToString()).AsObject();
        }

        public void Set(ReadOnlySpan<byte> path, string value) => SetValue(path, value);

        public void Set(ReadOnlySpan<byte> path, bool value) => SetValue(path, value);

        public void Set(ReadOnlySpan<byte> path, int value) => SetValue(path, value);

        public void Set(ReadOnlySpan<byte> path, long value) => SetValue(path, value);

        public void Set(ReadOnlySpan<byte> path, double value) => SetValue(path, value);

        public void Set(ReadOnlySpan<byte> path, decimal value) => SetValue(path, value);

        public BinaryData ToBinaryData() => BinaryData.FromString(GetJson().ToJsonString());

        private void SetValue(ReadOnlySpan<byte> path, object value)
        {
            string[] segments = GetPathSegments(path);
            JsonObject current = GetJson();
            for (int i = 0; i < segments.Length - 1; i++)
            {
                JsonObject child = current[segments[i]] as JsonObject;
                if (child is null)
                {
                    child = new JsonObject();
                    current[segments[i]] = child;
                }
                current = child;
            }

            current[segments[segments.Length - 1]] = JsonValue.Create(value);
        }

        private JsonObject GetJson()
        {
            return _json ??= new JsonObject();
        }

        private static string[] GetPathSegments(ReadOnlySpan<byte> path)
        {
            string jsonPath = Encoding.UTF8.GetString(path.ToArray());
            if (!jsonPath.StartsWith("$.", StringComparison.Ordinal) || jsonPath.Length == 2)
            {
                throw new ArgumentException("The JSON path must start with '$.'.", nameof(path));
            }

            return jsonPath.Substring(2).Split('.');
        }
    }
}

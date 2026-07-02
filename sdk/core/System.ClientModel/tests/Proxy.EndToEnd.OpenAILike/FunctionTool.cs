// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Tests.Proxy.OpenAILike
{
    /// <summary>A known tool the base library can deserialize on its own (no proxy needed).</summary>
    public sealed class FunctionTool : ResponseTool
    {
        public FunctionTool(string functionName) : base("function")
        {
            FunctionName = functionName;
        }

        public string FunctionName { get; }

        protected override void WriteProperties(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("function_name"u8);
            writer.WriteStringValue(FunctionName);
        }

        internal static FunctionTool DeserializeFunctionTool(JsonElement element)
        {
            string functionName = element.TryGetProperty("function_name", out var fn) ? fn.GetString() ?? "" : "";
            return new FunctionTool(functionName);
        }
    }
}

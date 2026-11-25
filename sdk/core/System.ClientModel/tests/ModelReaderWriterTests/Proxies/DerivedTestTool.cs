// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    internal sealed class DerivedTestTool : TestTool
    {
        public DerivedTestTool(string type, string name) : base(type)
        {
            Name = name;
        }

        public string Name { get; }

        protected override void WriteProperties(Utf8JsonWriter writer)
        {
            writer.WriteString("name"u8, Name);
        }

        internal static DerivedTestTool Deserialize(JsonElement element)
            => new(
                element.GetProperty("type").GetString()!,
                element.TryGetProperty("name", out JsonElement name) ? name.GetString() ?? "" : "");
    }
}

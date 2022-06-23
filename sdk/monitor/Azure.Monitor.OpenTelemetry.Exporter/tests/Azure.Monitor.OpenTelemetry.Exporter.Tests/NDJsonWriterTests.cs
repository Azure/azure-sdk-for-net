// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class NDJsonWriterTests
    {
        [Fact]
        public void CanWriteMultilineJson()
        {
            var writer = new NDJsonWriter();
            writer.JsonWriter.WriteStartObject();
            writer.JsonWriter.WriteString("property", "value");
            writer.JsonWriter.WriteEndObject();
            writer.WriteNewLine();
            writer.JsonWriter.WriteStartObject();
            writer.JsonWriter.WriteNumber("anotherProperty", 2);
            writer.JsonWriter.WriteEndObject();

            Assert.Equal("{\"property\":\"value\"}\n{\"anotherProperty\":2}", Encoding.UTF8.GetString(writer.ToBytes().Span.ToArray()));
            writer.Dispose();
        }
    }
}

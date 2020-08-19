// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using NUnit.Framework;

namespace OpenTelemetry.Exporter.AzureMonitor.Tests
{
    public class NDJsonWriterTests
    {
        [Test]
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

            Assert.AreEqual("{\"property\":\"value\"}\n{\"anotherProperty\":2}", Encoding.UTF8.GetString(writer.ToBytes().Span.ToArray()));
        }
    }
}
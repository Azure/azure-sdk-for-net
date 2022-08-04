// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class JsonRawStringListConverterTests
    {
        [Test]
        public void WriteTest()
        {
            MemoryStream memStream = new MemoryStream(100);
            Utf8JsonWriter writer = new Utf8JsonWriter(memStream);
            JsonRawStringListConverter converter = new JsonRawStringListConverter();
            List<string> value = new List<string>();
            value.Add("{\"videoType\":\"documentary\"}");
            value.Add("{\"day\":\"Monday\"}");
            converter.Write(writer, value, new JsonSerializerOptions());
            writer.Flush();
            string json = Encoding.UTF8.GetString(memStream.ToArray());
            Assert.IsTrue(json.Equals("[{\"videoType\":\"documentary\"},{\"day\":\"Monday\"}]"));
        }
    }
}

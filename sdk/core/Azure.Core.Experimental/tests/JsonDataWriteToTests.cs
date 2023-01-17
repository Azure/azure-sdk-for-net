// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    internal class JsonDataWriteToTests
    {
        [Test]
        public void CanWriteBoolean()
        {
            string json = @"true";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            jd.WriteElementTo(writer);
            writer.Flush();

            stream.Position = 0;
            string value = BinaryData.FromStream(stream).ToString();
            Assert.AreEqual(json, value);
        }

        [Test]
        public void CanWriteString()
        {
            string json = @"""Hi!""";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            jd.WriteElementTo(writer);

            writer.Flush();
            stream.Position = 0;

            string value = BinaryData.FromStream(stream).ToString();
            Assert.AreEqual(json, value);
        }
    }
}

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

        [Test]
        public void CanWriteObject()
        {
            string json = @"
                {
                  ""StringProperty"" :  ""Hi!"",
                  ""IntProperty"" :  16,
                  ""DoubleProperty"" :  16.56,
                  ""ObjectProperty"" : {
                      ""StringProperty"" :  ""Nested"",
                      ""IntProperty"" :  22,
                      ""DoubleProperty"" :  22.22
                  },
                  ""ArrayProperty"" : [
                      {
                          ""StringProperty"" :  ""First"",
                          ""IntProperty"" :  1,
                          ""DoubleProperty"" :  1.1
                      },
                      {
                          ""StringProperty"" :  ""Second"",
                          ""IntProperty"" :  2,
                          ""DoubleProperty"" :  2.2
                      },
                      {
                          ""StringProperty"" :  ""Third"",
                          ""IntProperty"" :  3,
                          ""DoubleProperty"" :  3.3
                      }
                  ]
                }";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            jd.WriteElementTo(writer);

            writer.Flush();
            stream.Position = 0;

            string jsonString = BinaryData.FromStream(stream).ToString();

            TestClass testClass = JsonSerializer.Deserialize<TestClass>(jsonString);
            Assert.AreEqual(jd.RootElement.GetProperty("StringProperty").GetString(), testClass.StringProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("IntProperty").GetInt32(), testClass.IntProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("DoubleProperty").GetDouble(), testClass.DoubleProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("ObjectProperty").GetProperty("StringProperty").GetString(), testClass.ObjectProperty.StringProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("ObjectProperty").GetProperty("IntProperty").GetInt32(), testClass.ObjectProperty.IntProperty);
            Assert.AreEqual(jd.RootElement.GetProperty("ObjectProperty").GetProperty("DoubleProperty").GetDouble(), testClass.ObjectProperty.DoubleProperty);

            Assert.AreEqual(RemoveWhiteSpace(json), jsonString);
        }

        [Test]
        public void CanWriteInt()
        {
            string json = @"16";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            jd.WriteElementTo(writer);

            writer.Flush();
            stream.Position = 0;

            string jsonString = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(json, jsonString);
        }

        [Test]
        public void CanWriteDouble()
        {
            string json = @"16.56";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            jd.WriteElementTo(writer);

            writer.Flush();
            stream.Position = 0;

            string jsonString = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(json, jsonString);
        }

        [Test]
        public void CanWriteNumberArray()
        {
            string json = @"[ 1, 2.2, 3, -4]";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            jd.WriteElementTo(writer);

            writer.Flush();
            stream.Position = 0;

            string jsonString = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(RemoveWhiteSpace(json), jsonString);
        }

        [Test]
        public void CanWriteStringArray()
        {
            string json = @"[ ""one"", ""two"", ""three""]";

            JsonData jd = JsonData.Parse(json);

            using MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);

            jd.WriteElementTo(writer);

            writer.Flush();
            stream.Position = 0;

            string jsonString = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(RemoveWhiteSpace(json), jsonString);
        }

        #region Helpers
        private class TestClass
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
            public double DoubleProperty { get; set; }
            public TestClass ObjectProperty { get; set; }
            public TestClass[] ArrayProperty { get; set; }
        }

        internal static string RemoveWhiteSpace(string value)
        {
            return value.Replace(" ", "").Replace("\r", "").Replace("\n", "");
        }
        #endregion
    }
}

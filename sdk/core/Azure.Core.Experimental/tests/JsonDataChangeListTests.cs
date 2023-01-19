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
    internal class JsonDataChangeListTests
    {
        [Test]
        public void CanGetProperty()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.0
                  },
                  ""Foo"" : 1.2,
                  ""Bar"" : ""Hi!""
                }";

            var jd = JsonData.Parse(json);

            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("Hi!", jd.RootElement.GetProperty("Bar").GetString());
            Assert.AreEqual(3.0, jd.RootElement.GetProperty("Baz").GetProperty("A").GetDouble());
        }

        [Test]
        public void CanSetProperty()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.0
                  },
                  ""Foo"" : 1.2,
                  ""Bar"" : ""Hi!""
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").Set(2.0);
            jd.RootElement.GetProperty("Bar").Set("Hello");
            jd.RootElement.GetProperty("Baz").GetProperty("A").Set(5.1);

            Assert.AreEqual(2.0, jd.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("Hello", jd.RootElement.GetProperty("Bar").GetString());
            Assert.AreEqual(5.1, jd.RootElement.GetProperty("Baz").GetProperty("A").GetDouble());
        }

        [Test]
        public void CanSetProperty_WriteTo()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.0
                  },
                  ""Foo"" : 1.2,
                  ""Bar"" : ""Hi!""
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").Set(2.2);
            jd.RootElement.GetProperty("Bar").Set("Hello");
            jd.RootElement.GetProperty("Baz").GetProperty("A").Set(5.1);

            using MemoryStream stream = new MemoryStream();
            jd.WriteTo(stream);
            stream.Position = 0;
            string jsonString = BinaryData.FromStream(stream).ToString();

            Assert.AreEqual(
                JsonDataWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Baz"" : {
                     ""A"" : 5.1
                  },
                  ""Foo"" : 2.2,
                  ""Bar"" : ""Hello""
                }"),
                jsonString);
        }

        [Test]
        public void CanSetPropertyMultipleTimes()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.0
                  },
                  ""Foo"" : 1.2,
                  ""Bar"" : ""Hi!""
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").Set(2.0);
            jd.RootElement.GetProperty("Foo").Set(3.0);

            // Last write wins
            Assert.AreEqual(3.0, jd.RootElement.GetProperty("Foo").GetDouble());
        }

        [Test]
        public void CanAddPropertyToRootObject()
        {
            string json = @"
                {
                  ""Foo"" : 1.2
                }";

            var jd = JsonData.Parse(json);

            // Has same semantics as Dictionary
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.item?view=net-7.0#property-value
            jd.RootElement.SetProperty("Bar", "hi");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());

            // 2. New property is present.
            Assert.IsNotNull(jd.RootElement.GetProperty("Bar"));
            Assert.AreEqual("hi", jd.RootElement.GetProperty("Bar").GetString());

            // 3. Type round-trips correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            stream.Position = 0;
            string jsonString = BinaryData.FromStream(stream).ToString();
            JsonDocument doc = JsonDocument.Parse(jsonString);
            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("hi", doc.RootElement.GetProperty("Bar").GetString());

            Assert.AreEqual(JsonDataWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Foo"" : 1.2,
                  ""Bar"" : ""hi""
                }"), jsonString);
        }

        [Test]
        public void CanAddPropertyToObject()
        {
            string json = @"
                {
                  ""Foo"" : {
                    ""A"": 1.2
                    }
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").SetProperty("B", "hi");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            // 2. New property is present.
            Assert.IsNotNull(jd.RootElement.GetProperty("Foo").GetProperty("B"));
            Assert.AreEqual("hi", jd.RootElement.GetProperty("Foo").GetProperty("B").GetString());

            // 3. Type round-trips correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            stream.Position = 0;
            string jsonString = BinaryData.FromStream(stream).ToString();
            JsonDocument doc = JsonDocument.Parse(jsonString);
            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());
            Assert.AreEqual("hi", doc.RootElement.GetProperty("Foo").GetProperty("B").GetString());

            Assert.AreEqual(JsonDataWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Foo"" : {
                    ""A"": 1.2,
                    ""B"": ""hi""
                    }
                }"), jsonString);
        }

        [Test]
        public void CanRemovePropertyFromRootObject()
        {
            string json = @"
                {
                  ""Foo"" : 1.2,
                  ""Bar"" : ""Hi!""
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.RemoveProperty("Bar");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());

            // 2. New property not present.
            Assert.IsFalse(jd.RootElement.TryGetProperty("Bar", out var _));

            // 3. Type round-trips correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            stream.Position = 0;
            string jsonString = BinaryData.FromStream(stream).ToString();
            JsonDocument doc = JsonDocument.Parse(jsonString);
            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetDouble());
            Assert.IsFalse(doc.RootElement.TryGetProperty("Bar", out JsonElement _));

            Assert.AreEqual(JsonDataWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Foo"" : 1.2
                }"), jsonString);
        }

        [Test]
        public void CanRemovePropertyFromObject()
        {
            string json = @"
                {
                  ""Foo"" : {
                    ""A"": 1.2,
                    ""B"": ""hi""
                    }
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").RemoveProperty("B");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            // 2. New property is absent.
            Assert.IsFalse(jd.RootElement.GetProperty("Foo").TryGetProperty("B", out var _));

            // 3. Type round-trips correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            stream.Position = 0;
            string jsonString = BinaryData.FromStream(stream).ToString();
            JsonDocument doc = JsonDocument.Parse(jsonString);
            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            Assert.AreEqual(JsonDataWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Foo"" : {
                    ""A"": 1.2
                    }
                }"), jsonString);
        }

        [Test]
        public void CanReplaceObject()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.0
                  },
                  ""Foo"" : 1.2
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Baz").Set(new { B = 5.0 });

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());

            // 2. Object structure has been rewritten
            Assert.IsNull(jd.RootElement.GetProperty("Baz").GetProperty("A"));
            Assert.AreEqual(5.0, jd.RootElement.GetProperty("Baz").GetProperty("B").GetDouble());

            // 3. Type round-trips correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            var val = new BinaryData(stream.GetBuffer()).ToString();
            BazB baz = JsonSerializer.Deserialize<BazB>(val);
            Assert.AreEqual(1.2, baz.Foo);
            Assert.AreEqual(5.0, baz.Baz.B);
        }

        private class BazA
        {
            public double Foo { get; set; }
            public A_ Baz { get; set; }
        }

        private class BazB
        {
            public double Foo { get; set; }
            public B_ Baz { get; set; }
        }

        private class A_
        {
            public double A { get; set; }
        }

        private class B_
        {
            public double B { get; set; }
        }

        [Test]
        public void CanGetArrayElement()
        {
            string json = @"
                {
                  ""Foo"" : [ 1, 2, 3 ]
                }";

            var jd = JsonData.Parse(json);

            Assert.AreEqual(1, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(2, jd.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(3, jd.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32());
        }

        [Test]
        public void CanSetArrayElement()
        {
            string json = @"
                {
                  ""Foo"" : [ 1, 2, 3 ]
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            jd.RootElement.GetProperty("Foo").GetIndexElement(1).Set(6);
            jd.RootElement.GetProperty("Foo").GetIndexElement(2).Set(7);

            Assert.AreEqual(5, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(7, jd.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32());
        }

        [Test]
        public void CanSetArrayElementMultipleTimes()
        {
            string json = @"
                {
                  ""Foo"" : [ 1, 2, 3 ]
                }";

            var jd = JsonData.Parse(json);

            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(6);

            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
        }

        [Test]
        public void CanSwapArrayElements()
        {
            string json = @"[ { ""Foo"" : 4 } ]";

            var jd = JsonData.Parse(json);

            var a = jd.RootElement.GetIndexElement(0);
            jd.RootElement.GetIndexElement(0).Set(5);

            // This is wicked because 'a' keeps a reference to the root
            // with the changelist.  Would we detach that?  How would we know to?
            a.GetProperty("Foo").Set(6);

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());
            Assert.AreEqual(6, a.GetProperty("Foo").GetInt32());

            jd.RootElement.GetIndexElement(0).Set(a);

            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(6, a.GetProperty("Foo").GetIndexElement(0).GetInt32());
        }

        [Test]
        public void CanSetProperty_StringToNumber()
        {
            // TODO: This will change how serialization works

            throw new NotImplementedException();
        }

        [Test]
        public void CanSetProperty_StringToBool()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CanSetProperty_StringToObject()
        {
            // This modifies the JSON structure

            throw new NotImplementedException();
        }

        [Test]
        public void CanSetProperty_StringToArray()
        {
            // This modifies the JSON structure

            throw new NotImplementedException();
        }
    }
}

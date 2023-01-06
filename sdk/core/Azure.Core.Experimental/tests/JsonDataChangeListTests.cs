// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Dynamic;
using System.Text.Json;
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
        public void CanAddPropertyToObject()
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

            // 3. Type serializes out correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            var val = new BinaryData(stream.GetBuffer()).ToString();
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(val);
            Assert.AreEqual(1.2, dict["Foo"]);
            Assert.AreEqual("hi", dict["Bar"]);
        }

        [Test]
        public void CanSetObject()
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

            jd.RootElement.GetProperty("Baz").Set(new { B = 5.0 });

            // Last write wins
            Assert.AreEqual(5.0, jd.RootElement.GetProperty("Baz").GetProperty("B").GetDouble());

            // This should fail
            // TODO: Is this the exception type we'd like?
            Assert.Throws<KeyNotFoundException>(() => jd.RootElement.GetProperty("Baz").GetProperty("A"));
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
            Assert.AreEqual(6, a.GetProperty("Foo").GetIndexElement(0).GetInt32());

            jd.RootElement.GetIndexElement(0).Set(a);

            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(6, a.GetProperty("Foo").GetIndexElement(0).GetInt32());
        }
    }
}

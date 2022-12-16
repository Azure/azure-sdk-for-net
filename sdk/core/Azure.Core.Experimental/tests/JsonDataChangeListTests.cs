// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
        public void CanAssignMultipleTimes()
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
        public void CanAssignObject()
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
            Assert.Throws<KeyNotFoundException>(()=> jd.RootElement.GetProperty("Baz").GetProperty("A"));
        }
    }
}

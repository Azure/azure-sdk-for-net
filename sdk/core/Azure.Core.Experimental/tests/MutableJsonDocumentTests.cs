﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    internal class MutableJsonDocumentTests
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
                  ""Bar"" : ""Hi!"",
                  ""Qux"" : false
                }";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("Hi!", jd.RootElement.GetProperty("Bar").GetString());
            Assert.AreEqual(3.0, jd.RootElement.GetProperty("Baz").GetProperty("A").GetDouble());
            Assert.AreEqual(false, jd.RootElement.GetProperty("Qux").GetBoolean());

            MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(json),
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(jsonString));
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
                  ""Bar"" : ""Hi!"",
                  ""Qux"" : false
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").Set(2.2);
            jd.RootElement.GetProperty("Bar").Set("Hello");
            jd.RootElement.GetProperty("Baz").GetProperty("A").Set(5.1);
            jd.RootElement.GetProperty("Qux").Set(true);

            Assert.AreEqual(2.2, jd.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("Hello", jd.RootElement.GetProperty("Bar").GetString());
            Assert.AreEqual(5.1, jd.RootElement.GetProperty("Baz").GetProperty("A").GetDouble());
            Assert.AreEqual(true, jd.RootElement.GetProperty("Qux").GetBoolean());

            MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Baz"" : {
                     ""A"" : 5.1
                  },
                  ""Foo"" : 2.2,
                  ""Bar"" : ""Hello"",
                  ""Qux"" : true
                }"),
                jsonString);
        }

        [Test]
        public void CanSetPropertyMultipleTimes()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.1
                  },
                  ""Foo"" : 1.2,
                  ""Bar"" : ""Hi!""
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").Set(2.2);
            jd.RootElement.GetProperty("Foo").Set(3.3);

            // Last write wins
            Assert.AreEqual(3.3, jd.RootElement.GetProperty("Foo").GetDouble());

            MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Baz"" : {
                     ""A"" : 3.1
                  },
                  ""Foo"" : 3.3,
                  ""Bar"" : ""Hi!""
                }"),
                jsonString);
        }

        [Test]
        public void CanAddPropertyToRootObject()
        {
            string json = @"
                {
                  ""Foo"" : 1.2
                }";

            var jd = MutableJsonDocument.Parse(json);

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
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetDouble());
            Assert.AreEqual("hi", doc.RootElement.GetProperty("Bar").GetString());

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
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

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").SetProperty("B", "hi");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            // 2. New property is present.
            Assert.IsNotNull(jd.RootElement.GetProperty("Foo").GetProperty("B"));
            Assert.AreEqual("hi", jd.RootElement.GetProperty("Foo").GetProperty("B").GetString());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());
            Assert.AreEqual("hi", doc.RootElement.GetProperty("Foo").GetProperty("B").GetString());

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
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

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.RemoveProperty("Bar");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());

            // 2. New property not present.
            Assert.IsFalse(jd.RootElement.TryGetProperty("Bar", out var _));

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetDouble());
            Assert.IsFalse(doc.RootElement.TryGetProperty("Bar", out JsonElement _));

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
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

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").RemoveProperty("B");

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());

            // 2. New property is absent.
            Assert.IsFalse(jd.RootElement.GetProperty("Foo").TryGetProperty("B", out var _));

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(1.2, doc.RootElement.GetProperty("Foo").GetProperty("A").GetDouble());
            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Foo"" : {
                    ""A"": 1.2
                    }
                }"), jsonString);
        }

        [Test]
        public void CanReplaceObjectWithAnonymousType()
        {
            string json = @"
                {
                  ""Baz"" : {
                     ""A"" : 3.0
                  },
                  ""Foo"" : 1.2
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Baz").Set(new { B = 5.5 });

            // Assert:

            // 1. Old property is present.
            Assert.AreEqual(1.2, jd.RootElement.GetProperty("Foo").GetDouble());

            // 2. Object structure has been rewritten
            Assert.IsFalse(jd.RootElement.GetProperty("Baz").TryGetProperty("A", out var _));
            Assert.AreEqual(5.5, jd.RootElement.GetProperty("Baz").GetProperty("B").GetDouble());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            BazB baz = JsonSerializer.Deserialize<BazB>(jsonString);
            Assert.AreEqual(1.2, baz.Foo);
            Assert.AreEqual(5.5, baz.Baz.B);

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Baz"" : {
                     ""B"" : 5.5
                  },
                  ""Foo"" : 1.2
                }"), jsonString);
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

            var jd = MutableJsonDocument.Parse(json);

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

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            jd.RootElement.GetProperty("Foo").GetIndexElement(1).Set(6);
            jd.RootElement.GetProperty("Foo").GetIndexElement(2).Set(7);

            Assert.AreEqual(5, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(7, jd.RootElement.GetProperty("Foo").GetIndexElement(2).GetInt32());
        }

        [Test]
        public void CanSetArrayElement_WriteTo()
        {
            string json = @"
                {
                  ""Foo"" : [ 1, 2, 3 ]
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            jd.RootElement.GetProperty("Foo").GetIndexElement(1).Set(6);
            jd.RootElement.GetProperty("Foo").GetIndexElement(2).Set(7);

            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(
                MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"
                {
                  ""Foo"" : [ 5, 6, 7 ]
                }"),
                jsonString);
        }

        [Test]
        public void CanSetArrayElementMultipleTimes()
        {
            string json = @"
                {
                  ""Foo"" : [ 1, 2, 3 ]
                }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(5);
            jd.RootElement.GetProperty("Foo").GetIndexElement(0).Set(6);

            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetIndexElement(0).GetInt32());
        }

        [Test]
        public void HandlesReferenceSemantics()
        {
            string json = @"[ { ""Foo"" : 4 } ]";

            var jd = MutableJsonDocument.Parse(json);

            // a's path points to "0"
            var a = jd.RootElement.GetIndexElement(0);

            // resets json to equivalent of "[ 5 ]"
            jd.RootElement.GetIndexElement(0).Set(5);

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());

            // a's path points to "0" so a.GetInt32() should return 5.
            Assert.AreEqual(5, a.GetInt32());

            // The following should throw because json[0] is now 5 and not an object.
            Assert.Throws<InvalidOperationException>(() => a.GetProperty("Foo").Set(6));

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());

            // Setting json[0] back to a makes it 5 again.
            jd.RootElement.GetIndexElement(0).Set(a);

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(5, doc.RootElement[0].GetInt32());
            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[ 5 ]"), jsonString);
        }

        [Test]
        public void CanInvalidateElement()
        {
            string json = @"[
                {
                  ""Foo"" : {
                    ""A"": 6
                    }
                } ]";

            var jd = MutableJsonDocument.Parse(json);

            // a's path points to "0.Foo.A"
            var a = jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetProperty("A");

            // resets json to equivalent of "[ 5 ]"
            jd.RootElement.GetIndexElement(0).Set(5);

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());

            // a's path points to "0.Foo.A" so a.GetInt32() should throw since this
            // in an invalid path.
            Assert.Throws<InvalidOperationException>(() => a.GetInt32());

            // Setting json[0] to a should throw as well, as the element doesn't point
            // to a valid path in the mutated JSON tree.
            Assert.Throws<InvalidOperationException>(() => jd.RootElement.GetIndexElement(0).Set(a));

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(5, doc.RootElement[0].GetInt32());
            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[ 5 ]"), jsonString);
        }

        [Test]
        public void CanAccessPropertyInChangedStructure()
        {
            string json = @"[
                {
                  ""Foo"" : {
                    ""A"": 6
                    }
                } ]";

            var jd = MutableJsonDocument.Parse(json);

            // a's path points to "0.Foo.A"
            var a = jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetProperty("A");

            // resets json to equivalent of "[ 5 ]"
            jd.RootElement.GetIndexElement(0).Set(5);

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());

            // a's path points to "0.Foo.A" so a.GetInt32() should throw since this
            // in an invalid path.
            Assert.Throws<InvalidOperationException>(() => a.GetInt32());

            // Setting json[0] to `a` should throw as well, as the element doesn't point
            // to a valid path in the mutated JSON tree.
            Assert.Throws<InvalidOperationException>(() => jd.RootElement.GetIndexElement(0).Set(a));

            // Reset json[0] to an object
            jd.RootElement.GetIndexElement(0).Set(new
            {
                Foo = new
                {
                    A = 7
                }
            });

            // We should be able to get the value of A without being tripped up
            // by earlier changes.
            int aValue = jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetProperty("A").GetInt32();
            Assert.AreEqual(7, aValue);

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[
                {
                  ""Foo"" : {
                    ""A"": 7
                    }
                } ]"), jsonString);
        }

        [Test]
        public void CanAccessChangesInDifferentBranches()
        {
            string json = @"[
                {
                  ""Foo"" : {
                    ""A"": 6
                    }
                },
                {
                    ""Bar"" : ""hi""
                }]";

            var jd = MutableJsonDocument.Parse(json);

            // resets json to equivalent of "[ 5, ... ]"
            jd.RootElement.GetIndexElement(0).Set(5);

            Assert.AreEqual(5, jd.RootElement.GetIndexElement(0).GetInt32());
            Assert.AreEqual("hi", jd.RootElement.GetIndexElement(1).GetProperty("Bar").GetString());

            // Make a structural change to json[0] but not json[1]
            jd.RootElement.GetIndexElement(0).Set(new
            {
                Foo = new
                {
                    A = 7
                }
            });

            // We should be able to get the value of A without being tripped up by earlier changes.
            // We should also be able to get the value of json[1] without it having been invalidated.
            Assert.AreEqual(7, jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetProperty("A").GetInt32());
            Assert.AreEqual("hi", jd.RootElement.GetIndexElement(1).GetProperty("Bar").GetString());

            // Now change json[1]
            jd.RootElement.GetIndexElement(1).GetProperty("Bar").Set("new");
            Assert.AreEqual("new", jd.RootElement.GetIndexElement(1).GetProperty("Bar").GetString());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[
                {
                  ""Foo"" : {
                    ""A"": 7
                    }
                },
                {
                    ""Bar"" : ""new""
                }]"), jsonString);
        }

        [Test]
        public void PriorChangeToReplacedPropertyIsIgnored()
        {
            string json = @"{ ""ArrayProperty"": [
                {
                  ""Foo"" : {
                    ""A"": 6
                    }
                } ],
                  ""Bar"" : ""hi"" }";

            var jd = MutableJsonDocument.Parse(json);

            jd.RootElement.GetProperty("ArrayProperty").GetIndexElement(0).GetProperty("Foo").GetProperty("A").Set(8);

            Assert.AreEqual(8, jd.RootElement.GetProperty("ArrayProperty").GetIndexElement(0).GetProperty("Foo").GetProperty("A").GetInt32());

            // resets json to equivalent of "[ 5 ]"
            jd.RootElement.GetProperty("ArrayProperty").GetIndexElement(0).Set(5);

            Assert.AreEqual(5, jd.RootElement.GetProperty("ArrayProperty").GetIndexElement(0).GetInt32());

            // Reset json[0] to an object
            jd.RootElement.GetProperty("ArrayProperty").GetIndexElement(0).Set(new
            {
                Foo = new
                {
                    A = 7
                }
            });

            // We should be able to get the value of A without being tripped up
            // by earlier changes.
            int aValue = jd.RootElement.GetProperty("ArrayProperty").GetIndexElement(0).GetProperty("Foo").GetProperty("A").GetInt32();
            Assert.AreEqual(7, aValue);

            // 3. Type round-trips correctly.
            using MemoryStream stream = new();
            jd.WriteTo(stream);
            stream.Position = 0;
            string jsonString = BinaryData.FromStream(stream).ToString();
            JsonDocument doc = JsonDocument.Parse(jsonString);

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"{
                ""ArrayProperty"": [
                    {
                      ""Foo"" : {
                        ""A"": 7
                        }
                    } ],
                ""Bar"" : ""hi"" }"), jsonString);
        }

        [Test]
        public void CanSetProperty_StringToNumber()
        {
            string json = @"[ { ""Foo"" : ""hi"" } ]";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            jd.RootElement.GetIndexElement(0).GetProperty("Foo").Set(1.2);

            Assert.AreEqual(1.2, jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetDouble());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(1.2, doc.RootElement[0].GetProperty("Foo").GetDouble());
            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[ { ""Foo"" : 1.2 } ]"), jsonString);
        }

        [Test]
        public void CanSetProperty_StringToBool()
        {
            string json = @"[ { ""Foo"" : ""hi"" } ]";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            jd.RootElement.GetIndexElement(0).GetProperty("Foo").Set(false);

            Assert.IsFalse(jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetBoolean());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.IsFalse(doc.RootElement[0].GetProperty("Foo").GetBoolean());
            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[ { ""Foo"" : false } ]"), jsonString);
        }

        [Test]
        public void CanSetProperty_StringToObject()
        {
            string json = @"{ ""Foo"" : ""hi"" }";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", jd.RootElement.GetProperty("Foo").GetString());

            jd.RootElement.GetProperty("Foo").Set(new
            {
                Bar = 6
            });

            Assert.AreEqual(6, jd.RootElement.GetProperty("Foo").GetProperty("Bar").GetInt32());

            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(6, doc.RootElement.GetProperty("Foo").GetProperty("Bar").GetInt32());

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(
                @"{ ""Foo"" : {""Bar"" : 6 } }"),
                jsonString);
        }

        [Test]
        public void CanSetProperty_StringToArray()
        {
            string json = @"[ { ""Foo"" : ""hi"" } ]";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            jd.RootElement.GetIndexElement(0).GetProperty("Foo").Set(new int[] { 1, 2, 3 });

            Assert.AreEqual(1, jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(0).GetInt32());
            Assert.AreEqual(2, jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(1).GetInt32());
            Assert.AreEqual(3, jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetIndexElement(2).GetInt32());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(1, doc.RootElement[0].GetProperty("Foo")[0].GetInt32());
            Assert.AreEqual(2, doc.RootElement[0].GetProperty("Foo")[1].GetInt32());
            Assert.AreEqual(3, doc.RootElement[0].GetProperty("Foo")[2].GetInt32());

            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[ { ""Foo"" : [1, 2, 3] }]"), jsonString);
        }

        [Test]
        public void CanSetProperty_StringToNull()
        {
            string json = @"[ { ""Foo"" : ""hi"" } ]";

            var jd = MutableJsonDocument.Parse(json);

            Assert.AreEqual("hi", jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            jd.RootElement.GetIndexElement(0).GetProperty("Foo").Set(null);

            Assert.IsNull(jd.RootElement.GetIndexElement(0).GetProperty("Foo").GetString());

            // 3. Type round-trips correctly.
            JsonDocument doc = MutableJsonDocumentWriteToTests.WriteToAndParse(jd, out string jsonString);

            Assert.AreEqual(JsonValueKind.Null, doc.RootElement[0].GetProperty("Foo").ValueKind);
            Assert.AreEqual(MutableJsonDocumentWriteToTests.RemoveWhiteSpace(@"[ { ""Foo"" : null } ]"), jsonString);
        }
    }
}

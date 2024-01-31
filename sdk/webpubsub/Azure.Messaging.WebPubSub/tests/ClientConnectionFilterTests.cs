// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class ClientConnectionFilterTests
    {
        [Test]
        public void NoArguments()
        {
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq 2"));
        }

        [Test]
        public void OneArgument()
        {
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {2}"));
        }

        [Test]
        public void ManyArguments()
        {
            Assert.AreEqual("Foo eq 2 and Bar eq 3",
                ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4",
                ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5",
                ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5 and Quux eq 6",
                ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5} and Quux eq {6}"));
        }

        [Test]
        public void Null()
        {
            Assert.AreEqual("Foo eq null", ClientConnectionFilter.Create($"Foo eq {null}"));
        }

        [Test]
        public void Bool()
        {
            bool x = true;
            Assert.AreEqual("Foo eq true", ClientConnectionFilter.Create($"Foo eq {x}"));
            Assert.AreEqual("Foo eq true", ClientConnectionFilter.Create($"Foo eq {true}"));

            x = false;
            Assert.AreEqual("Foo eq false", ClientConnectionFilter.Create($"Foo eq {x}"));
            Assert.AreEqual("Foo eq false", ClientConnectionFilter.Create($"Foo eq {false}"));
        }

        [Test]
        public void Zero()
        {
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(sbyte)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(byte)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(short)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(ushort)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(int)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(uint)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(long)0}"));
            Assert.AreEqual("Foo eq 0", ClientConnectionFilter.Create($"Foo eq {(ulong)0}"));
        }

        [Test]
        public void Positive()
        {
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(sbyte)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(byte)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(short)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(ushort)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(int)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(uint)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(long)2}"));
            Assert.AreEqual("Foo eq 2", ClientConnectionFilter.Create($"Foo eq {(ulong)2}"));
        }

        [Test]
        public void Negative()
        {
            Assert.AreEqual("Foo eq -2", ClientConnectionFilter.Create($"Foo eq {(sbyte)-2}"));
            Assert.AreEqual("Foo eq -2", ClientConnectionFilter.Create($"Foo eq {(short)-2}"));
            Assert.AreEqual("Foo eq -2", ClientConnectionFilter.Create($"Foo eq {(int)-2}"));
            Assert.AreEqual("Foo eq -2", ClientConnectionFilter.Create($"Foo eq {(long)-2}"));
        }

        [Test]
        public void Text()
        {
            Assert.AreEqual("Foo eq 'x'", ClientConnectionFilter.Create($"Foo eq {'x'}"));
            Assert.AreEqual("Foo eq ''''", ClientConnectionFilter.Create($"Foo eq {'\''}"));
            Assert.AreEqual("Foo eq '\"'", ClientConnectionFilter.Create($"Foo eq {'"'}"));

            Assert.AreEqual("Foo eq 'bar'", ClientConnectionFilter.Create($"Foo eq {"bar"}"));
            Assert.AreEqual("Foo eq 'bar''s'", ClientConnectionFilter.Create($"Foo eq {"bar's"}"));
            Assert.AreEqual("Foo eq '\"bar\"'", ClientConnectionFilter.Create($"Foo eq {"\"bar\""}"));

            StringBuilder sb = new StringBuilder("bar");
            Assert.AreEqual("Foo eq 'bar'", ClientConnectionFilter.Create($"Foo eq {sb}"));

            var group1 = "GroupA";
            var group2 = "GroupB";
            Assert.AreEqual("'GroupA' in groups and not('GroupB' in groups)", ClientConnectionFilter.Create($"{group1} in groups and not({group2} in groups)"));
        }

        [Test]
        public void OtherThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => ClientConnectionFilter.Create($"Foo eq {new string[] { }}"));
            Assert.AreEqual("Unable to convert argument 0 from type System.String[] to a suppported OData filter string.", ex.Message);
        }
    }
}

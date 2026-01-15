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
            Assert.That(ClientConnectionFilter.Create($"Foo eq 2"), Is.EqualTo("Foo eq 2"));
        }

        [Test]
        public void OneArgument()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {2}"), Is.EqualTo("Foo eq 2"));
        }

        [Test]
        public void ManyArguments()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3}"),
                Is.EqualTo("Foo eq 2 and Bar eq 3"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4}"),
                Is.EqualTo("Foo eq 2 and Bar eq 3 and Baz eq 4"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5}"),
                Is.EqualTo("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5} and Quux eq {6}"),
                Is.EqualTo("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5 and Quux eq 6"));
        }

        [Test]
        public void Null()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {null}"), Is.EqualTo("Foo eq null"));
        }

        [Test]
        public void Bool()
        {
            bool x = true;
            Assert.That(ClientConnectionFilter.Create($"Foo eq {x}"), Is.EqualTo("Foo eq true"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {true}"), Is.EqualTo("Foo eq true"));

            x = false;
            Assert.That(ClientConnectionFilter.Create($"Foo eq {x}"), Is.EqualTo("Foo eq false"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {false}"), Is.EqualTo("Foo eq false"));
        }

        [Test]
        public void Zero()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(sbyte)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(byte)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(short)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(ushort)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(int)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(uint)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(long)0}"), Is.EqualTo("Foo eq 0"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(ulong)0}"), Is.EqualTo("Foo eq 0"));
        }

        [Test]
        public void Positive()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(sbyte)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(byte)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(short)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(ushort)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(int)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(uint)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(long)2}"), Is.EqualTo("Foo eq 2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(ulong)2}"), Is.EqualTo("Foo eq 2"));
        }

        [Test]
        public void Negative()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(sbyte)-2}"), Is.EqualTo("Foo eq -2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(short)-2}"), Is.EqualTo("Foo eq -2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(int)-2}"), Is.EqualTo("Foo eq -2"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {(long)-2}"), Is.EqualTo("Foo eq -2"));
        }

        [Test]
        public void Text()
        {
            Assert.That(ClientConnectionFilter.Create($"Foo eq {'x'}"), Is.EqualTo("Foo eq 'x'"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {'\''}"), Is.EqualTo("Foo eq ''''"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {'"'}"), Is.EqualTo("Foo eq '\"'"));

            Assert.That(ClientConnectionFilter.Create($"Foo eq {"bar"}"), Is.EqualTo("Foo eq 'bar'"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {"bar's"}"), Is.EqualTo("Foo eq 'bar''s'"));
            Assert.That(ClientConnectionFilter.Create($"Foo eq {"\"bar\""}"), Is.EqualTo("Foo eq '\"bar\"'"));

            StringBuilder sb = new StringBuilder("bar");
            Assert.That(ClientConnectionFilter.Create($"Foo eq {sb}"), Is.EqualTo("Foo eq 'bar'"));

            var group1 = "GroupA";
            var group2 = "GroupB";
            Assert.That(ClientConnectionFilter.Create($"{group1} in groups and not({group2} in groups)"), Is.EqualTo("'GroupA' in groups and not('GroupB' in groups)"));
        }

        [Test]
        public void OtherThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => ClientConnectionFilter.Create($"Foo eq {new string[] { }}"));
            Assert.That(ex.Message, Is.EqualTo("Unable to convert argument 0 from type System.String[] to a suppported OData filter string."));
        }
    }
}

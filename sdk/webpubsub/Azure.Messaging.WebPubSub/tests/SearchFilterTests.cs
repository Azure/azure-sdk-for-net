// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

using Azure.Core;

using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class SearchFilterTests
    {
        [Test]
        public void NoArguments()
        {
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq 2"));
        }

        [Test]
        public void OneArgument()
        {
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {2}"));
        }

        [Test]
        public void ManyArguments()
        {
            Assert.AreEqual("Foo eq 2 and Bar eq 3",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5}"));
            Assert.AreEqual("Foo eq 2 and Bar eq 3 and Baz eq 4 and Qux eq 5 and Quux eq 6",
                SearchFilter.Create($"Foo eq {2} and Bar eq {3} and Baz eq {4} and Qux eq {5} and Quux eq {6}"));
        }

        [Test]
        public void Null()
        {
            Assert.AreEqual("Foo eq null", SearchFilter.Create($"Foo eq {null}"));
        }

        [Test]
        public void Bool()
        {
            bool x = true;
            Assert.AreEqual("Foo eq true", SearchFilter.Create($"Foo eq {x}"));
            Assert.AreEqual("Foo eq true", SearchFilter.Create($"Foo eq {true}"));

            x = false;
            Assert.AreEqual("Foo eq false", SearchFilter.Create($"Foo eq {x}"));
            Assert.AreEqual("Foo eq false", SearchFilter.Create($"Foo eq {false}"));
        }

        [Test]
        public void Zero()
        {
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(sbyte)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(byte)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(short)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(ushort)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(int)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(uint)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(long)0}"));
            Assert.AreEqual("Foo eq 0", SearchFilter.Create($"Foo eq {(ulong)0}"));
        }

        [Test]
        public void Positive()
        {
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(sbyte)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(byte)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(short)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(ushort)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(int)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(uint)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(long)2}"));
            Assert.AreEqual("Foo eq 2", SearchFilter.Create($"Foo eq {(ulong)2}"));
        }

        [Test]
        public void Negative()
        {
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(sbyte)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(short)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(int)-2}"));
            Assert.AreEqual("Foo eq -2", SearchFilter.Create($"Foo eq {(long)-2}"));
        }

        [Test]
        public void Text()
        {
            Assert.AreEqual("Foo eq 'x'", SearchFilter.Create($"Foo eq {'x'}"));
            Assert.AreEqual("Foo eq ''''", SearchFilter.Create($"Foo eq {'\''}"));
            Assert.AreEqual("Foo eq '\"'", SearchFilter.Create($"Foo eq {'"'}"));

            Assert.AreEqual("Foo eq 'bar'", SearchFilter.Create($"Foo eq {"bar"}"));
            Assert.AreEqual("Foo eq 'bar''s'", SearchFilter.Create($"Foo eq {"bar's"}"));
            Assert.AreEqual("Foo eq '\"bar\"'", SearchFilter.Create($"Foo eq {"\"bar\""}"));

            StringBuilder sb = new StringBuilder("bar");
            Assert.AreEqual("Foo eq 'bar'", SearchFilter.Create($"Foo eq {sb}"));

            var group1 = "GroupA";
            var group2 = "GroupB";
            Assert.AreEqual("'GroupA' in groups and not('GroupB' in groups)", SearchFilter.Create($"{group1} in groups and not({group2} in groups)"));
        }

        [Test]
        public void OtherThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => SearchFilter.Create($"Foo eq {new string[] { }}"));
            Assert.AreEqual("Unable to convert argument 0 from type System.String[] to a suppported OData filter string.", ex.Message);
        }
    }
}

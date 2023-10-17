// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringObject
    {
        [Test]
        public void BasicStorage()
        {
            A a = new();
            Variant value = new(a);
            Assert.AreEqual(typeof(A), value.Type);
            Assert.AreSame(a, value.As<A>());

            bool success = value.TryGetValue(out B result);
            Assert.False(success);
            Assert.Null(result);
        }

        [Test]
        public void DerivedRetrieval()
        {
            B b = new();
            Variant value = new(b);
            Assert.AreEqual(typeof(B), value.Type);
            Assert.AreSame(b, value.As<A>());
            Assert.AreSame(b, value.As<B>());

            bool success = value.TryGetValue(out C result);
            Assert.False(success);
            Assert.Null(result);

            Assert.Throws<InvalidCastException>(() => value.As<C>());

            A a = new B();
            value = new(a);
            Assert.AreEqual(typeof(B), value.Type);
        }

        [Test]
        public void AsInterface()
        {
            I a = new A();
            Variant value = new(a);
            Assert.AreEqual(typeof(A), value.Type);

            Assert.AreSame(a, value.As<A>());
            Assert.AreSame(a, value.As<I>());
        }

        private class A : I { }
        private class B : A, I { }
        private class C : B, I { }

        private interface I
        {
            string ToString();
        }
    }
}

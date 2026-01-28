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
            Assert.That(value.Type, Is.EqualTo(typeof(A)));
            Assert.That(value.As<A>(), Is.SameAs(a));

            bool success = value.TryGetValue(out B result);
            Assert.That(success, Is.False);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void DerivedRetrieval()
        {
            B b = new();
            Variant value = new(b);
            Assert.That(value.Type, Is.EqualTo(typeof(B)));
            Assert.That(value.As<A>(), Is.SameAs(b));
            Assert.That(value.As<B>(), Is.SameAs(b));

            bool success = value.TryGetValue(out C result);
            Assert.That(success, Is.False);
            Assert.That(result, Is.Null);

            Assert.Throws<InvalidCastException>(() => value.As<C>());

            A a = new B();
            value = new(a);
            Assert.That(value.Type, Is.EqualTo(typeof(B)));
        }

        [Test]
        public void AsInterface()
        {
            I a = new A();
            Variant value = new(a);
            Assert.That(value.Type, Is.EqualTo(typeof(A)));

            Assert.That(value.As<A>(), Is.SameAs(a));
            Assert.That(value.As<I>(), Is.SameAs(a));
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

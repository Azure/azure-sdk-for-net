// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringSByte
    {
        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteImplicit(sbyte testValue)
        {
            Variant value = testValue;
            Assert.Multiple(() =>
            {
                Assert.That(value.As<sbyte>(), Is.EqualTo(testValue));
                Assert.That(value.Type, Is.EqualTo(typeof(sbyte)));
            });

            sbyte? source = testValue;
            value = source;
            Assert.Multiple(() =>
            {
                Assert.That(value.As<sbyte?>(), Is.EqualTo(source));
                Assert.That(value.Type, Is.EqualTo(typeof(sbyte)));
            });
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteCreate(sbyte testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.Multiple(() =>
            {
                Assert.That(value.As<sbyte>(), Is.EqualTo(testValue));
                Assert.That(value.Type, Is.EqualTo(typeof(sbyte)));
            });

            sbyte? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.Multiple(() =>
            {
                Assert.That(value.As<sbyte?>(), Is.EqualTo(source));
                Assert.That(value.Type, Is.EqualTo(typeof(sbyte)));
            });
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteInOut(sbyte testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out sbyte result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(testValue));

                Assert.That(value.As<sbyte>(), Is.EqualTo(testValue));
                Assert.That((sbyte)value, Is.EqualTo(testValue));
            });
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void NullableSByteInSByteOut(sbyte? testValue)
        {
            sbyte? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out sbyte result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(testValue));

                Assert.That(value.As<sbyte>(), Is.EqualTo(testValue));

                Assert.That((sbyte)value, Is.EqualTo(testValue));
            });
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteInNullableSByteOut(sbyte testValue)
        {
            sbyte source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out sbyte? result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(testValue));

                Assert.That((sbyte?)value, Is.EqualTo(testValue));
            });
        }

        [Test]
        public void NullSByte()
        {
            sbyte? source = null;
            Variant value = source;
            Assert.Multiple(() =>
            {
                Assert.That(value.Type, Is.Null);
                Assert.That(value.As<sbyte?>(), Is.EqualTo(source));
            });
            Assert.That(value.As<sbyte?>().HasValue, Is.False);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void OutAsObject(sbyte testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.Multiple(() =>
            {
                Assert.That(o.GetType(), Is.EqualTo(typeof(sbyte)));
                Assert.That((sbyte)o, Is.EqualTo(testValue));
            });

            sbyte? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.Multiple(() =>
            {
                Assert.That(o.GetType(), Is.EqualTo(typeof(sbyte)));
                Assert.That((sbyte)o, Is.EqualTo(testValue));
            });
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringUShort
    {
        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortImplicit(ushort testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<ushort>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(ushort)));

            ushort? source = testValue;
            value = source;
            Assert.That(value.As<ushort?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(ushort)));
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortCreate(ushort testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<ushort>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(ushort)));

            ushort? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<ushort?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(ushort)));
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortInOut(ushort testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out ushort result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<ushort>(), Is.EqualTo(testValue));
            Assert.That((ushort)value, Is.EqualTo(testValue));
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void NullableUShortInUShortOut(ushort? testValue)
        {
            ushort? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out ushort result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<ushort>(), Is.EqualTo(testValue));

            Assert.That((ushort)value, Is.EqualTo(testValue));
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortInNullableUShortOut(ushort testValue)
        {
            ushort source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out ushort? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((ushort?)value, Is.EqualTo(testValue));
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void BoxedUShort(ushort testValue)
        {
            ushort i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(ushort)));
            Assert.That(value.TryGetValue(out ushort result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out ushort? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            ushort? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(ushort)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullUShort()
        {
            ushort? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<ushort?>(), Is.EqualTo(source));
            Assert.That(value.As<ushort?>().HasValue, Is.False);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void OutAsObject(ushort testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(ushort)));
            Assert.That((ushort)o, Is.EqualTo(testValue));

            ushort? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(ushort)));
            Assert.That((ushort)o, Is.EqualTo(testValue));
        }
    }
}

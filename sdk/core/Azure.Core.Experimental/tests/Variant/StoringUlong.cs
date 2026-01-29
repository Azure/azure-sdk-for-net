// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringULong
    {
        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongImplicit(ulong testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<ulong>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(ulong)));

            ulong? source = testValue;
            value = source;
            Assert.That(value.As<ulong?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(ulong)));
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongCreate(ulong testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<ulong>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(ulong)));

            ulong? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<ulong?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(ulong)));
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongInOut(ulong testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out ulong result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<ulong>(), Is.EqualTo(testValue));
            Assert.That((ulong)value, Is.EqualTo(testValue));
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void NullableULongInULongOut(ulong? testValue)
        {
            ulong? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out ulong result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<ulong>(), Is.EqualTo(testValue));

            Assert.That((ulong)value, Is.EqualTo(testValue));
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongInNullableULongOut(ulong testValue)
        {
            ulong source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out ulong? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((ulong?)value, Is.EqualTo(testValue));
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void BoxedULong(ulong testValue)
        {
            ulong i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(ulong)));
            Assert.That(value.TryGetValue(out ulong result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out ulong? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            ulong? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(ulong)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullULong()
        {
            ulong? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<ulong?>(), Is.EqualTo(source));
            Assert.That(value.As<ulong?>().HasValue, Is.False);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void OutAsObject(ulong testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(ulong)));
            Assert.That((ulong)o, Is.EqualTo(testValue));

            ulong? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(ulong)));
            Assert.That((ulong)o, Is.EqualTo(testValue));
        }
    }
}

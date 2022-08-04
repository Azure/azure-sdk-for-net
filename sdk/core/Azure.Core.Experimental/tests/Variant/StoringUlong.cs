// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure
{
    public class StoringULong
    {
        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongImplicit(ulong testValue)
        {
            Value value = testValue;
            Assert.AreEqual(testValue, value.As<ulong>());
            Assert.AreEqual(typeof(ulong), value.Type);

            ulong? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<ulong?>());
            Assert.AreEqual(typeof(ulong), value.Type);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongCreate(ulong testValue)
        {
            Value value;
            using (MemoryWatch.Create())
            {
                value = Value.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<ulong>());
            Assert.AreEqual(typeof(ulong), value.Type);

            ulong? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<ulong?>());
            Assert.AreEqual(typeof(ulong), value.Type);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongInOut(ulong testValue)
        {
            Value value = new(testValue);
            bool success = value.TryGetValue(out ulong result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<ulong>());
            Assert.AreEqual(testValue, (ulong)value);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void NullableULongInULongOut(ulong? testValue)
        {
            ulong? source = testValue;
            Value value = new(source);

            bool success = value.TryGetValue(out ulong result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<ulong>());

            Assert.AreEqual(testValue, (ulong)value);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongInNullableULongOut(ulong testValue)
        {
            ulong source = testValue;
            Value value = new(source);
            bool success = value.TryGetValue(out ulong? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (ulong?)value);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void BoxedULong(ulong testValue)
        {
            ulong i = testValue;
            object o = i;
            Value value = new(o);

            Assert.AreEqual(typeof(ulong), value.Type);
            Assert.True(value.TryGetValue(out ulong result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out ulong? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            ulong? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(ulong), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullULong()
        {
            ulong? source = null;
            Value value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<ulong?>());
            Assert.False(value.As<ulong?>().HasValue);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void OutAsObject(ulong testValue)
        {
            Value value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(ulong), o.GetType());
            Assert.AreEqual(testValue, (ulong)o);

            ulong? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(ulong), o.GetType());
            Assert.AreEqual(testValue, (ulong)o);
        }
    }
}

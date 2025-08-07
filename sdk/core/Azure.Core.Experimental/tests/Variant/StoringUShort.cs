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
            Assert.AreEqual(testValue, value.As<ushort>());
            Assert.AreEqual(typeof(ushort), value.Type);

            ushort? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<ushort?>());
            Assert.AreEqual(typeof(ushort), value.Type);
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

            Assert.AreEqual(testValue, value.As<ushort>());
            Assert.AreEqual(typeof(ushort), value.Type);

            ushort? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<ushort?>());
            Assert.AreEqual(typeof(ushort), value.Type);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortInOut(ushort testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out ushort result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<ushort>());
            Assert.AreEqual(testValue, (ushort)value);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void NullableUShortInUShortOut(ushort? testValue)
        {
            ushort? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out ushort result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<ushort>());

            Assert.AreEqual(testValue, (ushort)value);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortInNullableUShortOut(ushort testValue)
        {
            ushort source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out ushort? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (ushort?)value);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void BoxedUShort(ushort testValue)
        {
            ushort i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(ushort), value.Type);
            Assert.True(value.TryGetValue(out ushort result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out ushort? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            ushort? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(ushort), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullUShort()
        {
            ushort? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<ushort?>());
            Assert.False(value.As<ushort?>().HasValue);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void OutAsObject(ushort testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(ushort), o.GetType());
            Assert.AreEqual(testValue, (ushort)o);

            ushort? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(ushort), o.GetType());
            Assert.AreEqual(testValue, (ushort)o);
        }
    }
}

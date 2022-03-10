// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure
{
    public class StoringUShort
    {
        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortImplicit(ushort @ushort)
        {
            Value value = @ushort;
            Assert.AreEqual(@ushort, value.As<ushort>());
            Assert.AreEqual(typeof(ushort), value.Type);

            ushort? source = @ushort;
            value = source;
            Assert.AreEqual(source, value.As<ushort?>());
            Assert.AreEqual(typeof(ushort), value.Type);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortCreate(ushort @ushort)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = Value.Create(@ushort);
            }

            Assert.AreEqual(@ushort, value.As<ushort>());
            Assert.AreEqual(typeof(ushort), value.Type);

            ushort? source = @ushort;

            using (MemoryWatch.Create)
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<ushort?>());
            Assert.AreEqual(typeof(ushort), value.Type);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortInOut(ushort @ushort)
        {
            Value value = new(@ushort);
            bool success = value.TryGetValue(out ushort result);
            Assert.True(success);
            Assert.AreEqual(@ushort, result);

            Assert.AreEqual(@ushort, value.As<ushort>());
            Assert.AreEqual(@ushort, (ushort)value);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void NullableUShortInUShortOut(ushort? @ushort)
        {
            ushort? source = @ushort;
            Value value = new(source);

            bool success = value.TryGetValue(out ushort result);
            Assert.True(success);
            Assert.AreEqual(@ushort, result);

            Assert.AreEqual(@ushort, value.As<ushort>());

            Assert.AreEqual(@ushort, (ushort)value);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void UShortInNullableUShortOut(ushort @ushort)
        {
            ushort source = @ushort;
            Value value = new(source);
            bool success = value.TryGetValue(out ushort? result);
            Assert.True(success);
            Assert.AreEqual(@ushort, result);

            Assert.AreEqual(@ushort, (ushort?)value);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void BoxedUShort(ushort @ushort)
        {
            ushort i = @ushort;
            object o = i;
            Value value = new(o);

            Assert.AreEqual(typeof(ushort), value.Type);
            Assert.True(value.TryGetValue(out ushort result));
            Assert.AreEqual(@ushort, result);
            Assert.True(value.TryGetValue(out ushort? nullableResult));
            Assert.AreEqual(@ushort, nullableResult!.Value);

            ushort? n = @ushort;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(ushort), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@ushort, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(@ushort, nullableResult!.Value);
        }

        [Test]
        public void NullUShort()
        {
            ushort? source = null;
            Value value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<ushort?>());
            Assert.False(value.As<ushort?>().HasValue);
        }

        [TestCase((ushort)42)]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        public void OutAsObject(ushort @ushort)
        {
            Value value = new(@ushort);
            object o = value.As<object>();
            Assert.AreEqual(typeof(ushort), o.GetType());
            Assert.AreEqual(@ushort, (ushort)o);

            ushort? n = @ushort;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(ushort), o.GetType());
            Assert.AreEqual(@ushort, (ushort)o);
        }
    }
}

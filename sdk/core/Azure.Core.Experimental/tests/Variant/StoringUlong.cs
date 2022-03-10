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
        public void ULongImplicit(ulong @ulong)
        {
            Value value = @ulong;
            Assert.AreEqual(@ulong, value.As<ulong>());
            Assert.AreEqual(typeof(ulong), value.Type);

            ulong? source = @ulong;
            value = source;
            Assert.AreEqual(source, value.As<ulong?>());
            Assert.AreEqual(typeof(ulong), value.Type);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongCreate(ulong @ulong)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = Value.Create(@ulong);
            }

            Assert.AreEqual(@ulong, value.As<ulong>());
            Assert.AreEqual(typeof(ulong), value.Type);

            ulong? source = @ulong;

            using (MemoryWatch.Create)
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<ulong?>());
            Assert.AreEqual(typeof(ulong), value.Type);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongInOut(ulong @ulong)
        {
            Value value = new(@ulong);
            bool success = value.TryGetValue(out ulong result);
            Assert.True(success);
            Assert.AreEqual(@ulong, result);

            Assert.AreEqual(@ulong, value.As<ulong>());
            Assert.AreEqual(@ulong, (ulong)value);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void NullableULongInULongOut(ulong? @ulong)
        {
            ulong? source = @ulong;
            Value value = new(source);

            bool success = value.TryGetValue(out ulong result);
            Assert.True(success);
            Assert.AreEqual(@ulong, result);

            Assert.AreEqual(@ulong, value.As<ulong>());

            Assert.AreEqual(@ulong, (ulong)value);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void ULongInNullableULongOut(ulong @ulong)
        {
            ulong source = @ulong;
            Value value = new(source);
            bool success = value.TryGetValue(out ulong? result);
            Assert.True(success);
            Assert.AreEqual(@ulong, result);

            Assert.AreEqual(@ulong, (ulong?)value);
        }

        [TestCase(42ul)]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        public void BoxedULong(ulong @ulong)
        {
            ulong i = @ulong;
            object o = i;
            Value value = new(o);

            Assert.AreEqual(typeof(ulong), value.Type);
            Assert.True(value.TryGetValue(out ulong result));
            Assert.AreEqual(@ulong, result);
            Assert.True(value.TryGetValue(out ulong? nullableResult));
            Assert.AreEqual(@ulong, nullableResult!.Value);

            ulong? n = @ulong;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(ulong), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@ulong, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(@ulong, nullableResult!.Value);
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
        public void OutAsObject(ulong @ulong)
        {
            Value value = new(@ulong);
            object o = value.As<object>();
            Assert.AreEqual(typeof(ulong), o.GetType());
            Assert.AreEqual(@ulong, (ulong)o);

            ulong? n = @ulong;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(ulong), o.GetType());
            Assert.AreEqual(@ulong, (ulong)o);
        }
    }
}

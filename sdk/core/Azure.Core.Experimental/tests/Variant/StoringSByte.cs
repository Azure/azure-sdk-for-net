// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure
{
    public class StoringSByte
    {
        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteImplicit(sbyte @sbyte)
        {
            Value value = @sbyte;
            Assert.AreEqual(@sbyte, value.As<sbyte>());
            Assert.AreEqual(typeof(sbyte), value.Type);

            sbyte? source = @sbyte;
            value = source;
            Assert.AreEqual(source, value.As<sbyte?>());
            Assert.AreEqual(typeof(sbyte), value.Type);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteCreate(sbyte @sbyte)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = Value.Create(@sbyte);
            }

            Assert.AreEqual(@sbyte, value.As<sbyte>());
            Assert.AreEqual(typeof(sbyte), value.Type);

            sbyte? source = @sbyte;

            using (MemoryWatch.Create)
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<sbyte?>());
            Assert.AreEqual(typeof(sbyte), value.Type);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteInOut(sbyte @sbyte)
        {
            Value value = new(@sbyte);
            bool success = value.TryGetValue(out sbyte result);
            Assert.True(success);
            Assert.AreEqual(@sbyte, result);

            Assert.AreEqual(@sbyte, value.As<sbyte>());
            Assert.AreEqual(@sbyte, (sbyte)value);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void NullableSByteInSByteOut(sbyte? @sbyte)
        {
            sbyte? source = @sbyte;
            Value value = new(source);

            bool success = value.TryGetValue(out sbyte result);
            Assert.True(success);
            Assert.AreEqual(@sbyte, result);

            Assert.AreEqual(@sbyte, value.As<sbyte>());

            Assert.AreEqual(@sbyte, (sbyte)value);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void SByteInNullableSByteOut(sbyte @sbyte)
        {
            sbyte source = @sbyte;
            Value value = new(source);
            bool success = value.TryGetValue(out sbyte? result);
            Assert.True(success);
            Assert.AreEqual(@sbyte, result);

            Assert.AreEqual(@sbyte, (sbyte?)value);
        }

        [Test]
        public void NullSByte()
        {
            sbyte? source = null;
            Value value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<sbyte?>());
            Assert.False(value.As<sbyte?>().HasValue);
        }

        [TestCase(0)]
        [TestCase(42)]
        [TestCase(sbyte.MinValue)]
        [TestCase(sbyte.MaxValue)]
        public void OutAsObject(sbyte @sbyte)
        {
            Value value = new(@sbyte);
            object o = value.As<object>();
            Assert.AreEqual(typeof(sbyte), o.GetType());
            Assert.AreEqual(@sbyte, (sbyte)o);

            sbyte? n = @sbyte;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(sbyte), o.GetType());
            Assert.AreEqual(@sbyte, (sbyte)o);
        }
    }
}

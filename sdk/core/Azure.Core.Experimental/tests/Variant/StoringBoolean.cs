// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringBoolean
    {
        [TestCase(true)]
        [TestCase(false)]
        public void BooleanImplicit(bool testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = testValue;
            }

            Assert.AreEqual(testValue, value.As<bool>());
            Assert.AreEqual(typeof(bool), value.Type);

            bool? source = testValue;
            using (MemoryWatch.Create())
            {
                value = source;
            }
            Assert.AreEqual(source, value.As<bool?>());
            Assert.AreEqual(typeof(bool), value.Type);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanCreate(bool testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<bool>());
            Assert.AreEqual(typeof(bool), value.Type);

            bool? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<bool?>());
            Assert.AreEqual(typeof(bool), value.Type);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanInOut(bool testValue)
        {
            Variant value;
            bool success;
            bool result;

            using (MemoryWatch.Create())
            {
                value = new(testValue);
                success = value.TryGetValue(out result);
            }

            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<bool>());
            Assert.AreEqual(testValue, (bool)value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void NullableBooleanInBooleanOut(bool? testValue)
        {
            bool? source = testValue;
            Variant value;
            bool success;
            bool result;

            using (MemoryWatch.Create())
            {
                value = new(source);
                success = value.TryGetValue(out result);
            }

            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<bool>());

            Assert.AreEqual(testValue, (bool)value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanInNullableBooleanOut(bool testValue)
        {
            bool source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out bool? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (bool?)value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BoxedBoolean(bool testValue)
        {
            bool i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(bool), value.Type);
            Assert.True(value.TryGetValue(out bool result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out bool? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            bool? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(bool), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullBoolean()
        {
            bool? source = null;
            Variant value;

            using (MemoryWatch.Create())
            {
                value = source;
            }

            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<bool?>());
            Assert.False(value.As<bool?>().HasValue);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OutAsObject(bool testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(bool), o.GetType());
            Assert.AreEqual(testValue, (bool)o);

            bool? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(bool), o.GetType());
            Assert.AreEqual(testValue, (bool)o);
        }
    }
}

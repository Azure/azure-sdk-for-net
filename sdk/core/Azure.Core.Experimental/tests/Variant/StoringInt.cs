// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringInt
    {
        public static int[] Int32Data => new[]
        {
            0,
            42,
            int.MaxValue ,
            int.MinValue
        };

        [Test]
        public void IntImplicit([ValueSource("Int32Data")] int testValue)
        {
            Variant value = testValue;
            Assert.AreEqual(testValue, value.As<int>());
            Assert.AreEqual(typeof(int), value.Type);

            int? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<int?>());
            Assert.AreEqual(typeof(int), value.Type);
        }

        [Test]
        public void IntCreate([ValueSource("Int32Data")] int testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.AreEqual(testValue, value.As<int>());
            Assert.AreEqual(typeof(int), value.Type);

            int? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<int?>());
            Assert.AreEqual(typeof(int), value.Type);
        }

        [Test]
        public void IntInOut([ValueSource("Int32Data")] int testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out int result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<int>());
            Assert.AreEqual(testValue, (int)value);
        }

        [Test]
        public void NullableIntInIntOut([ValueSource("Int32Data")] int? testValue)
        {
            int? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out int result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<int>());

            Assert.AreEqual(testValue, (int)value);
        }

        [Test]
        public void IntInNullableIntOut([ValueSource("Int32Data")] int testValue)
        {
            int source = testValue;
            Variant value = new(source);
            Assert.True(value.TryGetValue(out int? result));
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (int?)value);
        }

        [Test]
        public void BoxedInt([ValueSource("Int32Data")] int testValue)
        {
            int i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(int), value.Type);
            Assert.True(value.TryGetValue(out int result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out int? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            int? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(int), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullInt()
        {
            int? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<int?>());
            Assert.False(value.As<int?>().HasValue);
        }

        [Test]
        public void OutAsObject([ValueSource("Int32Data")] int testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(int), o.GetType());
            Assert.AreEqual(testValue, (int)o);

            int? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(int), o.GetType());
            Assert.AreEqual(testValue, (int)o);
        }
    }
}

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
            Assert.That(value.As<int>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(int)));

            int? source = testValue;
            value = source;
            Assert.That(value.As<int?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void IntCreate([ValueSource("Int32Data")] int testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<int>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(int)));

            int? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<int?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void IntInOut([ValueSource("Int32Data")] int testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out int result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<int>(), Is.EqualTo(testValue));
            Assert.That((int)value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullableIntInIntOut([ValueSource("Int32Data")] int? testValue)
        {
            int? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out int result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<int>(), Is.EqualTo(testValue));

            Assert.That((int)value, Is.EqualTo(testValue));
        }

        [Test]
        public void IntInNullableIntOut([ValueSource("Int32Data")] int testValue)
        {
            int source = testValue;
            Variant value = new(source);
            Assert.That(value.TryGetValue(out int? result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((int?)value, Is.EqualTo(testValue));
        }

        [Test]
        public void BoxedInt([ValueSource("Int32Data")] int testValue)
        {
            int i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(int)));
            Assert.That(value.TryGetValue(out int result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out int? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            int? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(int)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullInt()
        {
            int? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<int?>(), Is.EqualTo(source));
            Assert.That(value.As<int?>().HasValue, Is.False);
        }

        [Test]
        public void OutAsObject([ValueSource("Int32Data")] int testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(int)));
            Assert.That((int)o, Is.EqualTo(testValue));

            int? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(int)));
            Assert.That((int)o, Is.EqualTo(testValue));
        }
    }
}

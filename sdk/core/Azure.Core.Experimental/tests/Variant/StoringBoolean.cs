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

            Assert.That(value.As<bool>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(bool)));

            bool? source = testValue;
            using (MemoryWatch.Create())
            {
                value = source;
            }
            Assert.That(value.As<bool?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(bool)));
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

            Assert.That(value.As<bool>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(bool)));

            bool? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<bool?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(bool)));
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

            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<bool>(), Is.EqualTo(testValue));
            Assert.That((bool)value, Is.EqualTo(testValue));
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

            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<bool>(), Is.EqualTo(testValue));

            Assert.That((bool)value, Is.EqualTo(testValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanInNullableBooleanOut(bool testValue)
        {
            bool source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out bool? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((bool?)value, Is.EqualTo(testValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BoxedBoolean(bool testValue)
        {
            bool i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(bool)));
            Assert.That(value.TryGetValue(out bool result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out bool? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            bool? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(bool)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
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

            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<bool?>(), Is.EqualTo(source));
            Assert.That(value.As<bool?>().HasValue, Is.False);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OutAsObject(bool testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(bool)));
            Assert.That((bool)o, Is.EqualTo(testValue));

            bool? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(bool)));
            Assert.That((bool)o, Is.EqualTo(testValue));
        }
    }
}

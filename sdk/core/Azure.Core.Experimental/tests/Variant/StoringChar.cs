// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class StoringChar
    {
        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharImplicit(char testValue)
        {
            Variant value = testValue;
            Assert.That(value.As<char>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(char)));

            char? source = testValue;
            value = source;
            Assert.That(value.As<char?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(char)));
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharCreate(char testValue)
        {
            Variant value;
            using (MemoryWatch.Create())
            {
                value = Variant.Create(testValue);
            }

            Assert.That(value.As<char>(), Is.EqualTo(testValue));
            Assert.That(value.Type, Is.EqualTo(typeof(char)));

            char? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.That(value.As<char?>(), Is.EqualTo(source));
            Assert.That(value.Type, Is.EqualTo(typeof(char)));
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharInOut(char testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out char result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<char>(), Is.EqualTo(testValue));
            Assert.That((char)value, Is.EqualTo(testValue));
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void NullableCharInCharOut(char? testValue)
        {
            char? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out char result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That(value.As<char>(), Is.EqualTo(testValue));

            Assert.That((char)value, Is.EqualTo(testValue));
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharInNullableCharOut(char testValue)
        {
            char source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out char? result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(testValue));

            Assert.That((char?)value, Is.EqualTo(testValue));
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void BoxedChar(char testValue)
        {
            char i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(char)));
            Assert.That(value.TryGetValue(out char result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out char? nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));

            char? n = testValue;
            o = n;
            value = new(o);

            Assert.That(value.Type, Is.EqualTo(typeof(char)));
            Assert.That(value.TryGetValue(out result), Is.True);
            Assert.That(result, Is.EqualTo(testValue));
            Assert.That(value.TryGetValue(out nullableResult), Is.True);
            Assert.That(nullableResult!.Value, Is.EqualTo(testValue));
        }

        [Test]
        public void NullChar()
        {
            char? source = null;
            Variant value = source;
            Assert.That(value.Type, Is.Null);
            Assert.That(value.As<char?>(), Is.EqualTo(source));
            Assert.That(value.As<char?>().HasValue, Is.False);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void OutAsObject(char testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(char)));
            Assert.That((char)o, Is.EqualTo(testValue));

            char? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.That(o.GetType(), Is.EqualTo(typeof(char)));
            Assert.That((char)o, Is.EqualTo(testValue));
        }
    }
}

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
            Assert.AreEqual(testValue, value.As<char>());
            Assert.AreEqual(typeof(char), value.Type);

            char? source = testValue;
            value = source;
            Assert.AreEqual(source, value.As<char?>());
            Assert.AreEqual(typeof(char), value.Type);
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

            Assert.AreEqual(testValue, value.As<char>());
            Assert.AreEqual(typeof(char), value.Type);

            char? source = testValue;

            using (MemoryWatch.Create())
            {
                value = Variant.Create(source);
            }

            Assert.AreEqual(source, value.As<char?>());
            Assert.AreEqual(typeof(char), value.Type);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharInOut(char testValue)
        {
            Variant value = new(testValue);
            bool success = value.TryGetValue(out char result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<char>());
            Assert.AreEqual(testValue, (char)value);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void NullableCharInCharOut(char? testValue)
        {
            char? source = testValue;
            Variant value = new(source);

            bool success = value.TryGetValue(out char result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, value.As<char>());

            Assert.AreEqual(testValue, (char)value);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharInNullableCharOut(char testValue)
        {
            char source = testValue;
            Variant value = new(source);
            bool success = value.TryGetValue(out char? result);
            Assert.True(success);
            Assert.AreEqual(testValue, result);

            Assert.AreEqual(testValue, (char?)value);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void BoxedChar(char testValue)
        {
            char i = testValue;
            object o = i;
            Variant value = new(o);

            Assert.AreEqual(typeof(char), value.Type);
            Assert.True(value.TryGetValue(out char result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out char? nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);

            char? n = testValue;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(char), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(testValue, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(testValue, nullableResult!.Value);
        }

        [Test]
        public void NullChar()
        {
            char? source = null;
            Variant value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<char?>());
            Assert.False(value.As<char?>().HasValue);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void OutAsObject(char testValue)
        {
            Variant value = new(testValue);
            object o = value.As<object>();
            Assert.AreEqual(typeof(char), o.GetType());
            Assert.AreEqual(testValue, (char)o);

            char? n = testValue;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(char), o.GetType());
            Assert.AreEqual(testValue, (char)o);
        }
    }
}

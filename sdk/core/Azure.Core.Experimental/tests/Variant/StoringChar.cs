// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using NUnit.Framework;

namespace Azure
{
    public class StoringChar
    {
        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharImplicit(char @char)
        {
            Value value = @char;
            Assert.AreEqual(@char, value.As<char>());
            Assert.AreEqual(typeof(char), value.Type);

            char? source = @char;
            value = source;
            Assert.AreEqual(source, value.As<char?>());
            Assert.AreEqual(typeof(char), value.Type);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharCreate(char @char)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = Value.Create(@char);
            }

            Assert.AreEqual(@char, value.As<char>());
            Assert.AreEqual(typeof(char), value.Type);

            char? source = @char;

            using (MemoryWatch.Create)
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<char?>());
            Assert.AreEqual(typeof(char), value.Type);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharInOut(char @char)
        {
            Value value = new(@char);
            bool success = value.TryGetValue(out char result);
            Assert.True(success);
            Assert.AreEqual(@char, result);

            Assert.AreEqual(@char, value.As<char>());
            Assert.AreEqual(@char, (char)value);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void NullableCharInCharOut(char? @char)
        {
            char? source = @char;
            Value value = new(source);

            bool success = value.TryGetValue(out char result);
            Assert.True(success);
            Assert.AreEqual(@char, result);

            Assert.AreEqual(@char, value.As<char>());

            Assert.AreEqual(@char, (char)value);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void CharInNullableCharOut(char @char)
        {
            char source = @char;
            Value value = new(source);
            bool success = value.TryGetValue(out char? result);
            Assert.True(success);
            Assert.AreEqual(@char, result);

            Assert.AreEqual(@char, (char?)value);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void BoxedChar(char @char)
        {
            char i = @char;
            object o = i;
            Value value = new(o);

            Assert.AreEqual(typeof(char), value.Type);
            Assert.True(value.TryGetValue(out char result));
            Assert.AreEqual(@char, result);
            Assert.True(value.TryGetValue(out char? nullableResult));
            Assert.AreEqual(@char, nullableResult!.Value);

            char? n = @char;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(char), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@char, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(@char, nullableResult!.Value);
        }

        [Test]
        public void NullChar()
        {
            char? source = null;
            Value value = source;
            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<char?>());
            Assert.False(value.As<char?>().HasValue);
        }

        [TestCase('!')]
        [TestCase(char.MaxValue)]
        [TestCase(char.MinValue)]
        public void OutAsObject(char @char)
        {
            Value value = new(@char);
            object o = value.As<object>();
            Assert.AreEqual(typeof(char), o.GetType());
            Assert.AreEqual(@char, (char)o);

            char? n = @char;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(char), o.GetType());
            Assert.AreEqual(@char, (char)o);
        }
    }
}

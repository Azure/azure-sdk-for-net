// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure
{
    public class StoringBoolean
    {
        [TestCase(true)]
        [TestCase(false)]
        public void BooleanImplicit(bool @bool)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = @bool;
            }

            Assert.AreEqual(@bool, value.As<bool>());
            Assert.AreEqual(typeof(bool), value.Type);

            bool? source = @bool;
            using (MemoryWatch.Create)
            {
                value = source;
            }
            Assert.AreEqual(source, value.As<bool?>());
            Assert.AreEqual(typeof(bool), value.Type);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanCreate(bool @bool)
        {
            Value value;
            using (MemoryWatch.Create)
            {
                value = Value.Create(@bool);
            }

            Assert.AreEqual(@bool, value.As<bool>());
            Assert.AreEqual(typeof(bool), value.Type);

            bool? source = @bool;

            using (MemoryWatch.Create)
            {
                value = Value.Create(source);
            }

            Assert.AreEqual(source, value.As<bool?>());
            Assert.AreEqual(typeof(bool), value.Type);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanInOut(bool @bool)
        {
            Value value;
            bool success;
            bool result;

            using (MemoryWatch.Create)
            {
                value = new(@bool);
                success = value.TryGetValue(out result);
            }

            Assert.True(success);
            Assert.AreEqual(@bool, result);

            Assert.AreEqual(@bool, value.As<bool>());
            Assert.AreEqual(@bool, (bool)value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void NullableBooleanInBooleanOut(bool? @bool)
        {
            bool? source = @bool;
            Value value;
            bool success;
            bool result;

            using (MemoryWatch.Create)
            {
                value = new(source);
                success = value.TryGetValue(out result);
            }

            Assert.True(success);
            Assert.AreEqual(@bool, result);

            Assert.AreEqual(@bool, value.As<bool>());

            Assert.AreEqual(@bool, (bool)value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BooleanInNullableBooleanOut(bool @bool)
        {
            bool source = @bool;
            Value value = new(source);
            bool success = value.TryGetValue(out bool? result);
            Assert.True(success);
            Assert.AreEqual(@bool, result);

            Assert.AreEqual(@bool, (bool?)value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void BoxedBoolean(bool @bool)
        {
            bool i = @bool;
            object o = i;
            Value value = new(o);

            Assert.AreEqual(typeof(bool), value.Type);
            Assert.True(value.TryGetValue(out bool result));
            Assert.AreEqual(@bool, result);
            Assert.True(value.TryGetValue(out bool? nullableResult));
            Assert.AreEqual(@bool, nullableResult!.Value);

            bool? n = @bool;
            o = n;
            value = new(o);

            Assert.AreEqual(typeof(bool), value.Type);
            Assert.True(value.TryGetValue(out result));
            Assert.AreEqual(@bool, result);
            Assert.True(value.TryGetValue(out nullableResult));
            Assert.AreEqual(@bool, nullableResult!.Value);
        }

        [Test]
        public void NullBoolean()
        {
            bool? source = null;
            Value value;

            using (MemoryWatch.Create)
            {
                value = source;
            }

            Assert.Null(value.Type);
            Assert.AreEqual(source, value.As<bool?>());
            Assert.False(value.As<bool?>().HasValue);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void OutAsObject(bool @bool)
        {
            Value value = new(@bool);
            object o = value.As<object>();
            Assert.AreEqual(typeof(bool), o.GetType());
            Assert.AreEqual(@bool, (bool)o);

            bool? n = @bool;
            value = new(n);
            o = value.As<object>();
            Assert.AreEqual(typeof(bool), o.GetType());
            Assert.AreEqual(@bool, (bool)o);
        }
    }
}

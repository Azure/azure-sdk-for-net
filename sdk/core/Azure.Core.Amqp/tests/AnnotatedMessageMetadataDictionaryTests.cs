// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AnnotatedMessageMetadataDictionaryTests
    {
        private static readonly AmqpMessageBody EmptyDataBody = AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { Array.Empty<byte>() });
        private const string ContentType = AnnotatedMessageMetadataDictionary.ContentType;

        [Test]
        public void CanAddContentType()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            dictionary.Add(ContentType, "foo");
            Assert.AreEqual("foo", message.Properties.ContentType);
            Assert.IsTrue(dictionary.ContainsKey(ContentType));
            Assert.IsTrue(dictionary.Contains(new KeyValuePair<string, object>(ContentType, "foo")));

            dictionary.Remove(ContentType);
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsFalse(dictionary.ContainsKey(ContentType));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<string, object>(ContentType, "foo")));

            dictionary.Add(new KeyValuePair<string, object>(ContentType, "foo"));
            Assert.AreEqual("foo", message.Properties.ContentType);

            dictionary.Clear();
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsFalse(dictionary.ContainsKey(ContentType));
            Assert.IsFalse(dictionary.Contains(new KeyValuePair<string, object>(ContentType, "foo")));
        }

        [Test]
        public void CanAddUsingIndexers()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            dictionary[ContentType] = "foo";
            Assert.AreEqual("foo", message.Properties.ContentType);
            Assert.IsTrue(dictionary.ContainsKey(ContentType));
            Assert.IsTrue(dictionary.Contains(new KeyValuePair<string, object>(ContentType, "foo")));

            dictionary[ContentType] = null;
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsNull(dictionary[ContentType]);
            Assert.IsTrue(dictionary.ContainsKey(ContentType));
            Assert.IsTrue(dictionary.Contains(new KeyValuePair<string, object>(ContentType, null)));
        }

        [Test]
        public void CanTryGetValues()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            dictionary[ContentType] = "foo";
            Assert.IsTrue(dictionary.TryGetValue(ContentType, out object value));
            Assert.AreEqual("foo", value);
        }

        [Test]
        public void CanListKeysAndValues()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            dictionary[ContentType] = "foo";
            dictionary["other"] = "bar";
            Assert.IsTrue(dictionary.TryGetValue(ContentType, out object value));
            Assert.AreEqual(2, dictionary.Values.Count);
            Assert.AreEqual(2, dictionary.Keys.Count);

            var values = dictionary.Values.ToList();
            Assert.AreEqual("foo", values[0]);
            Assert.AreEqual("bar", values[1]);

            var keys = dictionary.Keys.ToList();
            Assert.AreEqual(ContentType, keys[0]);
            Assert.AreEqual("other", keys[1]);
        }

        [Test]
        public void ContentTypeMustBeString()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            Assert.That(
                () => dictionary[ContentType] = 5,
                Throws.InvalidOperationException);

            Assert.That(
                () => dictionary.Add(ContentType, 5),
                Throws.InvalidOperationException);

            Assert.That(
                () => dictionary.Add(new KeyValuePair<string, object>(ContentType, 5)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void CanAddNullValues()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);
            dictionary[ContentType] = "foo";
            Assert.AreEqual("foo", dictionary[ContentType]);

            dictionary.Clear();
            dictionary.Add(ContentType, null);
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsNull(dictionary[ContentType]);

            dictionary[ContentType] = null;
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsNull(dictionary[ContentType]);

            dictionary.Clear();
            dictionary.Add(new KeyValuePair<string, object>(ContentType, null));
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsNull(dictionary[ContentType]);
        }

        [Test]
        public void CanAddArbitraryKeys()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            dictionary.Add("foo", "bar");
            dictionary.Add(ContentType, "contentType");
            Assert.AreEqual("bar", dictionary["foo"]);
            Assert.IsTrue(dictionary.ContainsKey("foo"));
            Assert.IsTrue(dictionary.Contains(new KeyValuePair<string, object>("foo", "bar")));

            Assert.AreEqual("contentType", dictionary[ContentType]);
            Assert.IsTrue(dictionary.ContainsKey(ContentType));
            Assert.IsTrue(dictionary.Contains(new KeyValuePair<string, object>(ContentType, "contentType")));
        }
    }
}
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

            Assert.IsTrue(dictionary.TryGetValue(ContentType, out object value));
            Assert.AreEqual(1, dictionary.Values.Count);
            Assert.AreEqual(1, dictionary.Keys.Count);
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
                Throws.InstanceOf<NotSupportedException>());

            Assert.That(
                () => dictionary.Add(new KeyValuePair<string, object>(ContentType, 5)),
                Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void CanSetContentTypeToNull()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);

            dictionary[ContentType] = null;
            Assert.IsNull(message.Properties.ContentType);
            Assert.IsNull(dictionary[ContentType]);
        }

        [Test]
        public void CannotAddArbitraryKeys()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);
            Assert.That(
                () => dictionary.Add("foo", "bar"),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary["foo"] = "bar",
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary.Add(new KeyValuePair<string, object>("foo", "bar")),
                Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void UnsupportedOperationsThrow()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            var dictionary = new AnnotatedMessageMetadataDictionary(message);
            Assert.That(
                () => dictionary.Add(ContentType, "bar"),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary["foo"] = "bar",
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary.Add(new KeyValuePair<string, object>(ContentType, "bar")),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary.Remove(new KeyValuePair<string, object>(ContentType, "bar")),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary.Remove(ContentType),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary.CopyTo(new KeyValuePair<string, object>[1], 0),
                Throws.InstanceOf<NotSupportedException>());
            Assert.That(
                () => dictionary.GetEnumerator(),
                Throws.InstanceOf<NotSupportedException>());
        }
    }
}
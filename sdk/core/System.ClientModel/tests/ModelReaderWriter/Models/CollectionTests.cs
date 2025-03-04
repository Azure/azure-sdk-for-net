// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public abstract class CollectionTests<TCollection, TElement> : MrwTestBase<TCollection>
    {
        protected abstract void CompareModels(TElement model, TElement model2, string format);
        protected virtual void Reverse(ref TCollection collection, ref IEnumerable enumerable) { }

        [Test]
        public void ReadListNoContextShouldFail()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(BinaryData.FromString(JsonPayload), typeof(TCollection)));
            Assert.IsNotNull(ex);
            Assert.AreEqual($"{typeof(TCollection).Name} does not implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void WriteListNoContextShouldFail()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(Instance!));
            Assert.IsNotNull(ex);
            Assert.AreEqual($"{typeof(TCollection).Name} does not implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void WriteNonJFormat()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(Instance!, ModelReaderWriterOptions.Xml));
            Assert.IsNotNull(ex);
            Assert.AreEqual($"{typeof(TCollection).Name} does not implement IPersistableModel", ex!.Message);
        }

        protected override void RoundTripTest(string format, RoundTripStrategy<TCollection> strategy)
        {
            var options = new ModelReaderWriterOptions(format);

            if (CollectionTests<TCollection, TElement>.AssertFailures(Instance, format, strategy, options))
                return;

            var collapsedPayload = format == "J" ? JsonPayload_Collapsed : WirePayload_Collapsed;

            BinaryData data = strategy.Write(Instance, options);
            Assert.IsNotNull(data);
            Assert.AreEqual(collapsedPayload, data.ToString());

            var collectionEumerable = CollectionTests<TCollection, TElement>.GetEnumerable(Instance!);

            var roundTripCollection = (TCollection)strategy.Read(data.ToString(), Instance!, options);
            Assert.IsNotNull(roundTripCollection);
            var roundTripEnumerable = CollectionTests<TCollection, TElement>.GetEnumerable(roundTripCollection!);
            Reverse(ref roundTripCollection, ref roundTripEnumerable);
            Assert.AreEqual(Instance!.GetType(), roundTripCollection!.GetType());
            var enumerator = collectionEumerable.GetEnumerator();
            var roundTripEnumerator = roundTripEnumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.IsTrue(roundTripEnumerator.MoveNext(), "Less items found in round trip collection");
                CompareModels((TElement)enumerator.Current, (TElement)roundTripEnumerator.Current, format);
            }
            //assert none left in round trip
            Assert.IsFalse(roundTripEnumerator.MoveNext(), "More items found in round trip collection");

            BinaryData data2 = strategy.Write(roundTripCollection, options);
            Assert.AreEqual(data.Length, data2.Length);
            Assert.IsTrue(data.ToMemory().Span.SequenceEqual(data2.ToMemory().Span));
        }

        private static bool AssertFailures(TCollection instance, string format, RoundTripStrategy<TCollection> strategy, ModelReaderWriterOptions options)
        {
            if (strategy is ModelReaderWriterNonGenericStrategy<TCollection>)
            {
                var ex = Assert.Throws<InvalidOperationException>(() => strategy.Write(instance, options));
                Assert.IsNotNull(ex);
                Assert.IsTrue(ex!.Message.EndsWith(" does not implement IPersistableModel"));
                return true;
            }
            return false;
        }

        protected static IEnumerable GetEnumerable(object collection)
        {
            if (collection is IDictionary dictionary)
            {
                foreach (var key in dictionary.Keys)
                {
                    yield return dictionary[key];
                }
                yield break;
            }

            if (collection is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    yield return item;
                }
                yield break;
            }

            //should be ReadOnlyMemory here for test data
            var rom = (ReadOnlyMemory<TElement>)collection;
            for (int i = 0; i < rom.Length; i++)
            {
                yield return rom.Span[i];
            }
            yield break;
        }
    }
}

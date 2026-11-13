// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.IO;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public abstract class MrwCollectionTests<TCollection, TElement> : MrwTestBase<TCollection>
    {
        protected abstract void CompareModels(TElement model, TElement model2, string format);

        protected virtual bool HasReflectionBuilderSupport => true;

        protected abstract string CollectionTypeName { get; }

        protected virtual string GetJsonCollectionType() => GetCollectionType();

        protected virtual void CompareCollections(TCollection expected, TCollection actual, string format)
            => CompareEnumerable(GetEnumerable(expected!), GetEnumerable(actual!), format, 0);

        protected virtual bool IsWriteOrderDeterministic => true;

        protected virtual bool IsRoundTripOrderDeterministic => true;

        protected override string GetJsonFolderName()
        {
            var className = GetType().Name;
            return Path.Combine(typeof(TElement).Name, GetJsonCollectionType());
        }

        private string GetCollectionType()
        {
            var className = GetType().Name;
            return className.Substring(0, className.Length - 5);
        }

        [Test]
        public void WriteNonJFormat()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(Instance!, ModelReaderWriterOptions.Xml));
            Assert.IsNotNull(ex);
            Assert.AreEqual($"Format 'X' is not supported.  Only 'J' or 'W' format can be written as collections", ex!.Message);
        }

        protected override void RoundTripTest(string format, RoundTripStrategy<TCollection> strategy)
        {
            if (!strategy.UsesContext && !HasReflectionBuilderSupport)
            {
                Assert.Ignore($"Collection type {CollectionTypeName} does not have reflection builder support.  Skipping test.");
            }

            var options = new ModelReaderWriterOptions(format);

            Assert.AreEqual(typeof(TCollection), Instance!.GetType());

            var collapsedPayload = format == "J" ? JsonPayload_Collapsed : WirePayload_Collapsed;

            BinaryData data = strategy.Write(Instance, options);
            Assert.IsNotNull(data);
            var actualPayload = data.ToString();
            Assert.AreEqual(actualPayload.Length, actualPayload.Length);

            if (IsWriteOrderDeterministic)
            {
                Assert.AreEqual(collapsedPayload, actualPayload);
            }

            var actual = strategy.Read(data.ToString(), Instance!, options);
            Assert.IsNotNull(actual);
            Assert.AreEqual(Instance!.GetType(), actual!.GetType());

            CompareCollections(Instance!, (TCollection)actual!, format);

            BinaryData data2 = strategy.Write((TCollection)actual, options);
            Assert.AreEqual(data.Length, data2.Length);
            if (IsRoundTripOrderDeterministic)
            {
                Assert.IsTrue(data.ToMemory().Span.SequenceEqual(data2.ToMemory().Span));
            }
        }

        private void CompareEnumerable(IEnumerable expected, IEnumerable actual, string format, int layer)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            var expectedEnumerator = GetEnumerable(expected!).GetEnumerator();
            var actualEnumerator = GetEnumerable(actual!).GetEnumerator();
            while (expectedEnumerator.MoveNext())
            {
                Assert.IsTrue(actualEnumerator.MoveNext(), "Less items found in round trip collection");
                if (expectedEnumerator.Current is IEnumerable)
                {
                    CompareEnumerable((IEnumerable)expectedEnumerator.Current, (IEnumerable)actualEnumerator.Current, format, layer + 1);
                }
                else
                {
                    CompareModels((TElement)expectedEnumerator.Current, (TElement)actualEnumerator.Current, format);
                }
            }

            //assert none left in round trip
            Assert.IsFalse(actualEnumerator.MoveNext(), "More items found in round trip collection");
        }

        protected static IEnumerable GetEnumerable(object collection)
        {
            if (collection is IDictionary dictionary)
            {
                return dictionary.Values;
            }

            if (collection is IEnumerable enumerable)
            {
                return enumerable;
            }

            return GetEnumerableFromReadOnlyMemory(collection);
        }

        private static IEnumerable GetEnumerableFromReadOnlyMemory(object collection)
        {
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

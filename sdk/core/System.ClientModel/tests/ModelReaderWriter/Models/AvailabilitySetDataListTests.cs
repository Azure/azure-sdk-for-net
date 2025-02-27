// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class AvailabilitySetDataListTests
    {
        private static readonly LocalContext s_readerWriterContext = new();
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataList.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly IList<AvailabilitySetData> s_availabilitySets = ModelReaderWriter.Read<List<AvailabilitySetData>>(s_data, s_readerWriterContext)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private readonly Lazy<TestModelReaderWriterContext> _LibraryContext = new(() => new());
            private Dictionary_String_AvailabilitySetData_Info? _dictionary_String_AvailabilitySetData_Info;
            private HashSet_AvailabilitySetData_Info? _hashSet_AvailabilitySetData_Info;
            private Array_AvailabilitySetData_Info? _array_AvailabilitySetData_Info;
            private Collection_AvailabilitySetData_Info? _collection_AvailabilitySetData_Info;
            private LinkedList_AvailabilitySetData_Info? _linkedList_AvailabilitySetData_Info;
            private ObservableCollection_AvailabilitySetData_Info? _observableCollection_AvailabilitySetData_Info;
            private Queue_AvailabilitySetData_Info? _queue_AvailabilitySetData_Info;
            private SortedSet_AvailabilitySetData_Info? _sortedSet_AvailabilitySetData_Info;
            private Stack_AvailabilitySetData_Info? _stack_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => _dictionary_String_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(HashSet<AvailabilitySetData>) => _hashSet_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(AvailabilitySetData[]) => _array_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Collection<AvailabilitySetData>) => _collection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(LinkedList<AvailabilitySetData>) => _linkedList_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(ObservableCollection<AvailabilitySetData>) => _observableCollection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Queue<AvailabilitySetData>) => _queue_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(SortedSet<AvailabilitySetData>) => _sortedSet_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Stack<AvailabilitySetData>) => _stack_AvailabilitySetData_Info ??= new(),
                    _ => _LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class Stack_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Stack_AvailabilitySetData_Builder();

                private class Stack_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Stack<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Push(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class SortedSet_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new SortedSet_AvailabilitySetData_Builder();

                private class SortedSet_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<SortedSet<AvailabilitySetData>> _instance = new(() => new(new AvailabilitySetDataComparer()));

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class Queue_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Queue_AvailabilitySetData_Builder();

                private class Queue_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Queue<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Enqueue(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class ObservableCollection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ObservableCollection_AvailabilitySetData_Builder();

                private class ObservableCollection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ObservableCollection<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class LinkedList_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new LinkedList_AvailabilitySetData_Builder();

                private class LinkedList_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<LinkedList<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.AddLast(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class Collection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Collection_AvailabilitySetData_Builder();

                private class Collection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Collection<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class Array_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Array_AvailabilitySetData_Builder();

                private class Array_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;

                    protected override object ToObject() => _instance.Value.ToArray();
                }
            }

            private class HashSet_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new HashSet_AvailabilitySetData_Builder();

                private class HashSet_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<HashSet<AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class Dictionary_String_AvailabilitySetData_Info : ModelInfo
            {
                private class Dictionary_String_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null)
                    {
                        _instance.Value.Add(AssertKey(key), AssertItem<AvailabilitySetData>(item));
                    }

                    protected override object GetBuilder() => _instance.Value;
                }

                public override object CreateObject() => new Dictionary_String_AvailabilitySetData_Builder();
            }
        }

        private class AvailabilitySetDataComparer : IComparer<AvailabilitySetData>
        {
            public int Compare(AvailabilitySetData? x, AvailabilitySetData? y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                else if (x == null)
                {
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.Id!.CompareTo(y.Id);
                }
            }
        }

        [Test]
        public void ReadListGeneric()
        {
            var asetList = ModelReaderWriter.Read<List<AvailabilitySetData>>(s_data, s_readerWriterContext);
            Assert.IsNotNull(asetList);

            Assert.AreEqual(2, asetList!.Count);
            Assert.IsTrue(asetList[0].Name!.Equals("testAS-3375"));
            Assert.IsTrue(asetList[1].Name!.Equals("testAS-3376"));
        }

        [Test]
        public void ReadList()
        {
            var asetList = ModelReaderWriter.Read(s_data, typeof(List<AvailabilitySetData>), new TestModelReaderWriterContext());
            Assert.IsNotNull(asetList);

            List<AvailabilitySetData>? asetList2 = asetList! as List<AvailabilitySetData>;
            Assert.IsNotNull(asetList2);

            Assert.AreEqual(2, asetList2!.Count);
            Assert.IsTrue(asetList2[0].Name!.Equals("testAS-3375"));
            Assert.IsTrue(asetList2[1].Name!.Equals("testAS-3376"));
        }

        [Test]
        public void RoundTrip_SortedSet()
        {
            RoundTripCollection(new SortedSet<AvailabilitySetData>(s_availabilitySets, new AvailabilitySetDataComparer()));
        }

        [Test]
        public void RoundTrip_LinkedList()
        {
            RoundTripCollection(new LinkedList<AvailabilitySetData>(s_availabilitySets));
        }

        [Test]
        public void RoundTrip_Stack()
        {
            //stack has the order flipped
            RoundTripCollection(new Stack<AvailabilitySetData>(s_availabilitySets.Reverse()), true);
        }

        [Test]
        public void RoundTrip_Queue()
        {
            RoundTripCollection(new Queue<AvailabilitySetData>(s_availabilitySets));
        }

        [Test]
        public void RoundTrip_HashSet()
        {
            RoundTripCollection(new HashSet<AvailabilitySetData>(s_availabilitySets));
        }

        [Test]
        public void RoundTrip_ObservableCollection()
        {
            RoundTripCollection(new ObservableCollection<AvailabilitySetData>(s_availabilitySets));
        }

        [Test]
        public void RoundTrip_Collection()
        {
            RoundTripCollection(new Collection<AvailabilitySetData>(s_availabilitySets));
        }

        [Test]
        public void RoundTrip_Array()
        {
            RoundTripCollection(new AvailabilitySetData[] { s_availabilitySets[0], s_availabilitySets[1] });
        }

        [Test]
        public void RoundTrip_List()
        {
            RoundTripCollection(new List<AvailabilitySetData>(s_availabilitySets));
        }

        private void RoundTripCollection(IEnumerable collection, bool reverse = false)
        {
            BinaryData data = ModelReaderWriter.Write(collection);
            Assert.IsNotNull(data);
            Assert.AreEqual(s_collapsedPayload, data.ToString());

            var roundTripCollection = ModelReaderWriter.Read(data, collection.GetType(), s_readerWriterContext) as IEnumerable;
            Assert.IsNotNull(roundTripCollection);
            if (reverse)
            {
                Stack<AvailabilitySetData> newStack = new Stack<AvailabilitySetData>();
                var reverseEnumerator = roundTripCollection!.GetEnumerator();
                while (reverseEnumerator.MoveNext())
                {
                    newStack.Push((AvailabilitySetData)reverseEnumerator.Current);
                }
                roundTripCollection = newStack;
            }
            Assert.AreEqual(collection.GetType(), roundTripCollection!.GetType());
            var enumerator = collection.GetEnumerator();
            var roundTripEnumerator = roundTripCollection.GetEnumerator();
            var comparer = new AvailabilitySetDataComparer();
            while (enumerator.MoveNext())
            {
                Assert.IsTrue(roundTripEnumerator.MoveNext(), "Less items found in round trip collection");
                Assert.AreEqual(0, comparer.Compare(enumerator.Current as AvailabilitySetData, roundTripEnumerator.Current as AvailabilitySetData));
            }
            //assert none left in round trip
            Assert.IsFalse(roundTripEnumerator.MoveNext(), "More items found in round trip collection");

            BinaryData data2 = ModelReaderWriter.Write(roundTripCollection);
            Assert.AreEqual(data.Length, data2.Length);
            Assert.IsTrue(data.ToMemory().Span.SequenceEqual(data2.ToMemory().Span));
        }

        [Test]
        public void ReadUnsupportedCollectionGeneric()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read<SortedDictionary<string, AvailabilitySetData>>(s_data, s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No model info found for SortedDictionary`2.", ex!.Message);
        }

        [Test]
        public void ReadDictionaryWhenList()
        {
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(s_data, s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Expected start of dictionary."));
        }

        [Test]
        public void WriteNonJFormat()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(s_availabilitySets, ModelReaderWriterOptions.Xml));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Format 'X' is not supported only 'J' or 'W' format can be written as collections", ex!.Message);
        }
    }
}

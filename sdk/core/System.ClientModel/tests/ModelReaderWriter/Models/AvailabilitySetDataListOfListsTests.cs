// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class AvailabilitySetDataListOfListsTests
    {
        private static readonly LocalContext s_readerWriterContext = new();
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataListOfLists.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static readonly HashSet<Type> s_supportedCollectionTypes =
        [
            typeof(List<>),
            typeof(Dictionary<,>)
        ];

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_LibraryContext = new(() => new());
            private List_List_AvailabilitySetData_Info? _list_List_AvailabilitySetData_Info;
            private List_Collection_AvailabilitySetData_Info? _list_Collection_AvailabilitySetData_Info;
            private Array_Array_AvailabilitySetData_Info? _array_Array_AvailabilitySetData_Info;
            private Array_AvailabilitySetData_Info? _array_AvailabilitySetData_Info;
            private Array_List_AvailabilitySetData_Info? _array_List_AvailabilitySetData_Info;
            private Collection_Collection_AvailabilitySetData_Info? _collection_Collection_AvailabilitySetData_Info;
            private Collection_AvailabilitySetData_Info? _collection_AvailabilitySetData_Info;
            private Collection_List_AvailabilitySetData_Info? _collection_List_AvailabilitySetData_Info;
            private HashSet_HashSet_AvailabilitySetData_Info? _hashSet_HashSet_AvailabilitySetData_Info;
            private HashSet_AvailabilitySetData_Info? _hashSet_AvailabilitySetData_Info;
            private HashSet_List_AvailabilitySetData_Info? _hashSet_List_AvailabilitySetData_Info;
            private LinkedList_LinkedList_AvailabilitySetData_Info? _linkedList_LinkedList_AvailabilitySetData_Info;
            private LinkedList_AvailabilitySetData_Info? _linkedList_AvailabilitySetData_Info;
            private LinkedList_List_AvailabilitySetData_Info? _linkedList_List_AvailabilitySetData_Info;
            private List_Array_AvailabilitySetData_Info? _list_Array_AvailabilitySetData_Info;
            private ArrayOfArray_AvailabilitySetData_Info? _arrayOfArray_AvailabilitySetData_Info;
            private ObservableCollection_List_AvailabilitySetData_Info? _observableCollection_List_AvailabilitySetData_Info;
            private ObservableCollection_ObservableCollection_AvailabilitySetData_Info? _observableCollection_ObservableCollection_AvailabilitySetData_Info;
            private ObservableCollection_AvailabilitySetData_Info? _observableCollection_AvailabilitySetData_Info;
            private Queue_List_AvailabilitySetData_Info? _queue_List_AvailabilitySetData_Info;
            private Queue_Queue_AvailabilitySetData_Info? _queue_Queue_AvailabilitySetData_Info;
            private Queue_AvailabilitySetData_Info? _queue_AvailabilitySetData_Info;
            private Stack_List_AvailabilitySetData_Info? _stack_List_AvailabilitySetData_Info;
            private Stack_Stack_AvailabilitySetData_Info? _stack_Stack_AvailabilitySetData_Info;
            private Stack_AvailabilitySetData_Info? _stack_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(List<List<AvailabilitySetData>>) => _list_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(List<Collection<AvailabilitySetData>>) => _list_Collection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(AvailabilitySetData[][]) => _array_Array_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(AvailabilitySetData[]) => _array_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(List<AvailabilitySetData>[]) => _array_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Collection<Collection<AvailabilitySetData>>) => _collection_Collection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Collection<AvailabilitySetData>) => _collection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Collection<List<AvailabilitySetData>>) => _collection_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(HashSet<HashSet<AvailabilitySetData>>) => _hashSet_HashSet_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(HashSet<AvailabilitySetData>) => _hashSet_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(HashSet<List<AvailabilitySetData>>) => _hashSet_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(LinkedList<LinkedList<AvailabilitySetData>>) => _linkedList_LinkedList_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(LinkedList<AvailabilitySetData>) => _linkedList_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(LinkedList<List<AvailabilitySetData>>) => _linkedList_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(List<AvailabilitySetData[]>) => _list_Array_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(AvailabilitySetData[,]) => _arrayOfArray_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(ObservableCollection<List<AvailabilitySetData>>) => _observableCollection_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(ObservableCollection<ObservableCollection<AvailabilitySetData>>) => _observableCollection_ObservableCollection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(ObservableCollection<AvailabilitySetData>) => _observableCollection_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Queue<List<AvailabilitySetData>>) => _queue_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Queue<Queue<AvailabilitySetData>>) => _queue_Queue_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Queue<AvailabilitySetData>) => _queue_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Stack<List<AvailabilitySetData>>) => _stack_List_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Stack<Stack<AvailabilitySetData>>) => _stack_Stack_AvailabilitySetData_Info ??= new(),
                    Type t when t == typeof(Stack<AvailabilitySetData>) => _stack_AvailabilitySetData_Info ??= new(),
                    _ => s_LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class Stack_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Stack_AvailabilitySetData_Builder();

                private class Stack_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Stack<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Push(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Stack_Stack_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Stack_Stack_AvailabilitySetData_Builder();

                private class Stack_Stack_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Stack<Stack<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Push(AssertItem<Stack<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Stack_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Stack_List_AvailabilitySetData_Builder();

                private class Stack_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Stack<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Push(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Queue_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Queue_AvailabilitySetData_Builder();

                private class Queue_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Queue<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Enqueue(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Queue_Queue_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Queue_Queue_AvailabilitySetData_Builder();

                private class Queue_Queue_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Queue<Queue<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Enqueue(AssertItem<Queue<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Queue_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Queue_List_AvailabilitySetData_Builder();

                private class Queue_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Queue<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Enqueue(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class ObservableCollection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ObservableCollection_AvailabilitySetData_Builder();

                private class ObservableCollection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ObservableCollection<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class ObservableCollection_ObservableCollection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ObservableCollection_ObservableCollection_AvailabilitySetData_Builder();

                private class ObservableCollection_ObservableCollection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ObservableCollection<ObservableCollection<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<ObservableCollection<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class ObservableCollection_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ObservableCollection_List_AvailabilitySetData_Builder();

                private class ObservableCollection_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<ObservableCollection<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class ArrayOfArray_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new ArrayOfArray_AvailabilitySetData_Builder();

                private class ArrayOfArray_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject()
                    {
                        int rowCount = _instance.Value.Count;
                        int colCount = _instance.Value[0].Count;
                        AvailabilitySetData[,] multiArray = new AvailabilitySetData[rowCount, colCount];

                        for (int i = 0; i < rowCount; i++)
                        {
                            for (int j = 0; j < colCount; j++)
                            {
                                multiArray[i, j] = _instance.Value[i][j];
                            }
                        }
                        return multiArray;
                    }

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class List_Array_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_Array_AvailabilitySetData_Builder();

                private class List_Array_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData[]>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData[]>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class LinkedList_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new LinkedList_List_AvailabilitySetData_Builder();

                private class LinkedList_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<LinkedList<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.AddLast(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class LinkedList_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new LinkedList_AvailabilitySetData_Builder();

                private class LinkedList_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<LinkedList<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.AddLast(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class LinkedList_LinkedList_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new LinkedList_LinkedList_AvailabilitySetData_Builder();

                private class LinkedList_LinkedList_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<LinkedList<LinkedList<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.AddLast(AssertItem<LinkedList<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class HashSet_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new HashSet_List_AvailabilitySetData_Builder();

                private class HashSet_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<HashSet<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class HashSet_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new HashSet_AvailabilitySetData_Builder();

                private class HashSet_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<HashSet<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class HashSet_HashSet_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new HashSet_HashSet_AvailabilitySetData_Builder();

                private class HashSet_HashSet_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<HashSet<HashSet<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<HashSet<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Collection_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Collection_List_AvailabilitySetData_Builder();

                private class Collection_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Collection<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Collection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Collection_AvailabilitySetData_Builder();

                private class Collection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Collection<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Collection_Collection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Collection_Collection_AvailabilitySetData_Builder();

                private class Collection_Collection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Collection<Collection<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<Collection<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Array_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Array_List_AvailabilitySetData_Builder();

                private class Array_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject() => _instance.Value.ToArray();

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Array_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Array_AvailabilitySetData_Builder();

                private class Array_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject() => _instance.Value.ToArray();

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Array_Array_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Array_Array_AvailabilitySetData_Builder();

                private class Array_Array_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData[]>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData[]>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object ToObject() => _instance.Value.ToArray();

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class List_Collection_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_Collection_AvailabilitySetData_Builder();

                private class List_Collection_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<Collection<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<Collection<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class List_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_List_AvailabilitySetData_Builder();

                private class List_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => s_LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }

        private List<List<AvailabilitySetData>>? _availabilitySets;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _availabilitySets = ModelReaderWriter.Read<List<List<AvailabilitySetData>>>(s_data, s_readerWriterContext);
        }

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
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
            var asetList = ModelReaderWriter.Read<List<List<AvailabilitySetData>>>(s_data, s_readerWriterContext);
            Assert.IsNotNull(asetList);

            Assert.AreEqual(2, asetList!.Count);

            List<AvailabilitySetData> asetList2 = asetList[0];

            Assert.AreEqual(2, asetList2.Count);
            Assert.IsTrue(asetList2[0].Name!.Equals("testAS-3375"));
            Assert.IsTrue(asetList2[1].Name!.Equals("testAS-3376"));

            List<AvailabilitySetData> asetList3 = asetList[1];

            Assert.AreEqual(2, asetList3.Count);
            Assert.IsTrue(asetList3[0].Name!.Equals("testAS-3377"));
            Assert.IsTrue(asetList3[1].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void ReadList()
        {
            var asetList = ModelReaderWriter.Read(s_data, typeof(List<List<AvailabilitySetData>>), s_readerWriterContext);
            Assert.IsNotNull(asetList);

            List<List<AvailabilitySetData>>? asetList2 = asetList! as List<List<AvailabilitySetData>>;
            Assert.IsNotNull(asetList2);

            Assert.AreEqual(2, asetList2!.Count);

            List<AvailabilitySetData> asetList3 = asetList2[0];

            Assert.AreEqual(2, asetList3.Count);
            Assert.IsTrue(asetList3[0].Name!.Equals("testAS-3375"));
            Assert.IsTrue(asetList3[1].Name!.Equals("testAS-3376"));

            List<AvailabilitySetData> asetList4 = asetList2[1];

            Assert.AreEqual(2, asetList4.Count);
            Assert.IsTrue(asetList4[0].Name!.Equals("testAS-3377"));
            Assert.IsTrue(asetList4[1].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void ReadArrayGeneric()
        {
            Assert.DoesNotThrow(() => ModelReaderWriter.Read<AvailabilitySetData[][]>(s_data, s_readerWriterContext));
        }

        [Test]
        public void RoundTrip_ListOfList()
        {
            RoundTripCollection(new List<List<AvailabilitySetData>>(_availabilitySets!));
        }

        [Test]
        public void RoundTrip_MultiDimensionalArray()
        {
            RoundTripCollection(new AvailabilitySetData[,] { { _availabilitySets![0][0], _availabilitySets[0][1] }, { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void RoundTrip_JaggedArray()
        {
            RoundTripCollection(new AvailabilitySetData[][] { new AvailabilitySetData[] { _availabilitySets![0][0], _availabilitySets[0][1] }, new AvailabilitySetData[] { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void RoundTrip_ListOfArray()
        {
            RoundTripCollection(new List<AvailabilitySetData[]>() { new AvailabilitySetData[] { _availabilitySets![0][0], _availabilitySets[0][1] }, new AvailabilitySetData[] { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void RoundTrip_ArrayOfList()
        {
            RoundTripCollection(new List<AvailabilitySetData>[] { _availabilitySets![0], _availabilitySets[1] });
        }

        [Test]
        public void RoundTrip_CollectionOfCollection()
        {
            RoundTripCollection(new Collection<Collection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_CollectionOfList()
        {
            RoundTripCollection(new Collection<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_ListOfCollection()
        {
            RoundTripCollection(new List<Collection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_ObservableOfObservable()
        {
            RoundTripCollection(new ObservableCollection<ObservableCollection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_ObservableOfList()
        {
            RoundTripCollection(new ObservableCollection<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_HashOfHash()
        {
            RoundTripCollection(new HashSet<HashSet<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_HashOfList()
        {
            RoundTripCollection(new HashSet<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void RoundTrip_QueueOfQueue()
        {
            RoundTripCollection(new Queue<Queue<AvailabilitySetData>>([new Queue<AvailabilitySetData>(_availabilitySets![0]), new Queue<AvailabilitySetData>(_availabilitySets[1])]));
        }

        [Test]
        public void RoundTrip_QueueOfList()
        {
            RoundTripCollection(new Queue<List<AvailabilitySetData>>([[.. _availabilitySets![0]], [.. _availabilitySets[1]]]));
        }

        [Test]
        public void RoundTrip_StackOfStack()
        {
            RoundTripCollection(new Stack<Stack<AvailabilitySetData>>([new Stack<AvailabilitySetData>([_availabilitySets![1][1], _availabilitySets[1][0]]), new Stack<AvailabilitySetData>([_availabilitySets[0][1], _availabilitySets[0][0]])]), [0,1]);
        }

        [Test]
        public void RoundTrip_StackOfList()
        {
            RoundTripCollection(new Stack<List<AvailabilitySetData>>([[.. _availabilitySets![1]], [.. _availabilitySets[0]]]), [0]);
        }

        [Test]
        public void RoundTrip_LinkedOfLinked()
        {
            RoundTripCollection(new LinkedList<LinkedList<AvailabilitySetData>>([new LinkedList<AvailabilitySetData>(_availabilitySets![0]), new LinkedList<AvailabilitySetData>(_availabilitySets[1])]));
        }

        [Test]
        public void RoundTrip_LinkedOfList()
        {
            RoundTripCollection(new LinkedList<List<AvailabilitySetData>>([[.. _availabilitySets![0]], [.. _availabilitySets[1]]]));
        }

        private void RoundTripCollection(IEnumerable collection, HashSet<int>? reverseLayers = default)
        {
            reverseLayers ??= [];

            BinaryData data = ModelReaderWriter.Write(collection, s_readerWriterContext);
            Assert.IsNotNull(data);
            Assert.AreEqual(s_collapsedPayload, data.ToString());

            var roundTripCollection = ModelReaderWriter.Read(data, collection.GetType(), s_readerWriterContext) as IEnumerable;
            Assert.IsNotNull(roundTripCollection);
            Assert.AreEqual(collection.GetType(), roundTripCollection!.GetType());
            CompareEnumerable(collection, roundTripCollection, reverseLayers, 0);

            BinaryData data2 = ModelReaderWriter.Write(roundTripCollection, s_readerWriterContext);
            Assert.AreEqual(data.Length, data2.Length);
            if (reverseLayers is null)
            {
                // stack will reverse the order so byte sequence will be different
                Assert.IsTrue(data.ToMemory().Span.SequenceEqual(data2.ToMemory().Span));
            }
        }

        private static void CompareEnumerable(IEnumerable expected, IEnumerable actual, HashSet<int> reverseLayers, int current)
        {
            if (reverseLayers.Contains(current))
            {
                Stack<object> newStack = new Stack<object>();
                var reverseEnumerator = actual!.GetEnumerator();
                while (reverseEnumerator.MoveNext())
                {
                    newStack.Push(reverseEnumerator.Current);
                }
                actual = newStack;
            }

            var expectedEnumerator = expected.GetEnumerator();
            var actualEnumerator = actual.GetEnumerator();
            var comparer = new AvailabilitySetDataComparer();
            while (expectedEnumerator.MoveNext())
            {
                Assert.IsTrue(actualEnumerator.MoveNext(), "Less items found in round trip collection");
                if (expectedEnumerator.Current is IEnumerable)
                {
                    CompareEnumerable((IEnumerable)expectedEnumerator.Current, (IEnumerable)actualEnumerator.Current, reverseLayers, current + 1);
                }
                else
                {
                    Assert.AreEqual(0, comparer.Compare(expectedEnumerator.Current as AvailabilitySetData, actualEnumerator.Current as AvailabilitySetData));
                }
            }
            //assert none left in round trip
            Assert.IsFalse(actualEnumerator.MoveNext(), "More items found in round trip collection");
        }

        [Test]
        public void ReadBadAbstractType()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(s_data, typeof(Stream)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Contains("must be decorated with PersistableModelProxyAttribute"));
        }

        [Test]
        public void ReadBadValueType()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(s_data, typeof(int)));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Contains("does not implement IPersistableModel"));
        }

        [Test]
        public void ReadNoPublicCtorType()
        {
#if NET5_0_OR_GREATER
            var ex = Assert.Throws<MissingMethodException>(() => ModelReaderWriter.Read(s_data, typeof(FileStream)));
            Assert.IsNotNull(ex);
#else
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Read(s_data, typeof(FileStream)));
            Assert.IsNotNull(ex);
#endif
        }

        [Test]
        public void WriteNonJFormat()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(_availabilitySets!, ModelReaderWriterOptions.Xml));
            Assert.IsNotNull(ex);
            Assert.AreEqual("List`1 does not implement IPersistableModel", ex!.Message);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
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
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataListOfLists.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static readonly HashSet<Type> s_supportedCollectionTypes =
        [
            typeof(List<>),
            typeof(Dictionary<,>)
        ];

        private List<List<AvailabilitySetData>>? _availabilitySets;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _availabilitySets = ModelReaderWriter.Read<List<List<AvailabilitySetData>>>(s_data);
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
            var asetList = ModelReaderWriter.Read<List<List<AvailabilitySetData>>>(s_data);
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
            var asetList = ModelReaderWriter.Read(s_data, typeof(List<List<AvailabilitySetData>>));
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
        public void ReadArray()
        {
            var ex = Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read(s_data, typeof(AvailabilitySetData[][])));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.StartsWith("Arrays are not supported. Use List<> instead."));
        }

        [Test]
        public void ReadArrayGeneric()
        {
            var ex = Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read<AvailabilitySetData[][]>(s_data));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.StartsWith("Arrays are not supported. Use List<> instead."));
        }

        [Test]
        public void ValidateTypeCheckingListOfList()
        {
            ValidateTypeChecking(new List<List<AvailabilitySetData>>(_availabilitySets!));
        }

        [Test]
        public void ValidateTypeCheckingMultiDimensionalArray()
        {
            ValidateTypeChecking(new AvailabilitySetData[,] { { _availabilitySets![0][0], _availabilitySets[0][1] }, { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void ValidateTypeCheckingJaggedArray()
        {
            ValidateTypeChecking(new AvailabilitySetData[][] { new AvailabilitySetData[] { _availabilitySets![0][0], _availabilitySets[0][1] }, new AvailabilitySetData[] { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void ValidateTypeCheckingListOfArray()
        {
            ValidateTypeChecking(new List<AvailabilitySetData[]>() { new AvailabilitySetData[] { _availabilitySets![0][0], _availabilitySets[0][1] }, new AvailabilitySetData[] { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void ValidateTypeCheckingArrayOfList()
        {
            ValidateTypeChecking(new List<AvailabilitySetData>[] { _availabilitySets![0], _availabilitySets[1] });
        }

        [Test]
        public void ValidateTypeCheckingCollectionOfCollection()
        {
            ValidateTypeChecking(new Collection<Collection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingCollectionOfList()
        {
            ValidateTypeChecking(new Collection<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingListOfCollection()
        {
            ValidateTypeChecking(new List<Collection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingObservableOfObservable()
        {
            ValidateTypeChecking(new ObservableCollection<ObservableCollection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingObservableOfList()
        {
            ValidateTypeChecking(new ObservableCollection<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingHashOfHash()
        {
            ValidateTypeChecking(new HashSet<HashSet<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingHashOfList()
        {
            ValidateTypeChecking(new HashSet<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void ValidateTypeCheckingQueueOfQueue()
        {
            ValidateTypeChecking(new Queue<Queue<AvailabilitySetData>>([new Queue<AvailabilitySetData>(_availabilitySets![0]), new Queue<AvailabilitySetData>(_availabilitySets[1])]));
        }

        [Test]
        public void ValidateTypeCheckingQueueOfList()
        {
            ValidateTypeChecking(new Queue<List<AvailabilitySetData>>([[.. _availabilitySets![0]], [.. _availabilitySets[1]]]));
        }

        [Test]
        public void ValidateTypeCheckingStackOfStack()
        {
            ValidateTypeChecking(new Stack<Stack<AvailabilitySetData>>([new Stack<AvailabilitySetData>([_availabilitySets![1][1], _availabilitySets[1][0]]), new Stack<AvailabilitySetData>([_availabilitySets[0][1], _availabilitySets[0][0]])]));
        }

        [Test]
        public void ValidateTypeCheckingStackOfList()
        {
            ValidateTypeChecking(new Stack<List<AvailabilitySetData>>([[.. _availabilitySets![1]], [.. _availabilitySets[0]]]));
        }

        [Test]
        public void ValidateTypeCheckingLinkedOfLinked()
        {
            ValidateTypeChecking(new LinkedList<LinkedList<AvailabilitySetData>>([new LinkedList<AvailabilitySetData>(_availabilitySets![0]), new LinkedList<AvailabilitySetData>(_availabilitySets[1])]));
        }

        [Test]
        public void ValidateTypeCheckingLinkedOfList()
        {
            ValidateTypeChecking(new LinkedList<List<AvailabilitySetData>>([[.. _availabilitySets![0]], [.. _availabilitySets[1]]]));
        }

        //[TestCaseSource(nameof(ListOfLists))]
        private void ValidateTypeChecking(object collection)
        {
            var type = collection.GetType();
            var genericType = type.IsGenericType ? type.GetGenericTypeDefinition() : null;
            if (genericType is not null && s_supportedCollectionTypes.Contains(genericType))
            {
                var elementType = type.GetGenericArguments()[0];
                Assert.IsNotNull(elementType);
                if (elementType.IsArray)
                {
                    var ex = Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read(s_data, type));
                    Assert.IsNotNull(ex);
                    Assert.IsTrue(ex!.Message.StartsWith("Arrays are not supported. Use List<> instead."));
                }
                else
                {
                    var elementGenericType = elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : null;
                    if (elementGenericType is not null && s_supportedCollectionTypes.Contains(elementGenericType))
                    {
                        Assert.DoesNotThrow(() => ModelReaderWriter.Read(s_data, type));
                    }
                    else
                    {
                        var ex = Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read(s_data, type));
                        Assert.IsNotNull(ex);
                        Assert.IsTrue(ex!.Message.StartsWith("Collection Type "));
                    }
                }
            }
            else if (type.IsArray)
            {
                var ex = Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read(s_data, type));
                Assert.IsNotNull(ex);
                Assert.IsTrue(ex!.Message.StartsWith("Arrays are not supported. Use List<> instead."));
            }
            else if (genericType is not null && !s_supportedCollectionTypes.Contains(genericType))
            {
                var ex = Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read(s_data, type));
                Assert.IsNotNull(ex);
                Assert.IsTrue(ex!.Message.Contains("Collection Type "));
            }
            else
            {
                //should never get here
                Assert.Fail("Unexpected condition");
            }
        }

        [Test]
        public void WriteListOfList()
        {
            WriteCollection(new List<List<AvailabilitySetData>>(_availabilitySets!));
        }

        [Test]
        public void WriteMultiDimensionalArray()
        {
            WriteCollection(new AvailabilitySetData[,] { { _availabilitySets![0][0], _availabilitySets[0][1] }, { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void WriteJaggedArray()
        {
            WriteCollection(new AvailabilitySetData[][] { new AvailabilitySetData[] { _availabilitySets![0][0], _availabilitySets[0][1] }, new AvailabilitySetData[] { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void WriteListOfArray()
        {
            WriteCollection(new List<AvailabilitySetData[]>() { new AvailabilitySetData[] { _availabilitySets![0][0], _availabilitySets[0][1] }, new AvailabilitySetData[] { _availabilitySets[1][0], _availabilitySets[1][1] } });
        }

        [Test]
        public void WriteArrayOfList()
        {
            WriteCollection(new List<AvailabilitySetData>[] { _availabilitySets![0], _availabilitySets[1] });
        }

        [Test]
        public void WriteCollectionOfCollection()
        {
            WriteCollection(new Collection<Collection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteCollectionOfList()
        {
            WriteCollection(new Collection<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteListOfCollection()
        {
            WriteCollection(new List<Collection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteObservableOfObservable()
        {
            WriteCollection(new ObservableCollection<ObservableCollection<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteObservableOfList()
        {
            WriteCollection(new ObservableCollection<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteHashOfHash()
        {
            WriteCollection(new HashSet<HashSet<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteHashOfList()
        {
            WriteCollection(new HashSet<List<AvailabilitySetData>>() { new(_availabilitySets![0]), new(_availabilitySets[1]) });
        }

        [Test]
        public void WriteQueueOfQueue()
        {
            WriteCollection(new Queue<Queue<AvailabilitySetData>>([new Queue<AvailabilitySetData>(_availabilitySets![0]), new Queue<AvailabilitySetData>(_availabilitySets[1])]));
        }

        [Test]
        public void WriteQueueOfList()
        {
            WriteCollection(new Queue<List<AvailabilitySetData>>([[.. _availabilitySets![0]], [.. _availabilitySets[1]]]));
        }

        [Test]
        public void WriteStackOfStack()
        {
            WriteCollection(new Stack<Stack<AvailabilitySetData>>([new Stack<AvailabilitySetData>([_availabilitySets![1][1], _availabilitySets[1][0]]), new Stack<AvailabilitySetData>([_availabilitySets[0][1], _availabilitySets[0][0]])]));
        }

        [Test]
        public void WriteStackOfList()
        {
            WriteCollection(new Stack<List<AvailabilitySetData>>([[.. _availabilitySets![1]], [.. _availabilitySets[0]]]));
        }

        [Test]
        public void WriteLinkedOfLinked()
        {
            WriteCollection(new LinkedList<LinkedList<AvailabilitySetData>>([new LinkedList<AvailabilitySetData>(_availabilitySets![0]), new LinkedList<AvailabilitySetData>(_availabilitySets[1])]));
        }

        [Test]
        public void WriteLinkedOfList()
        {
            WriteCollection(new LinkedList<List<AvailabilitySetData>>([[.. _availabilitySets![0]], [.. _availabilitySets[1]]]));
        }

        private void WriteCollection(object collection)
        {
            BinaryData data = ModelReaderWriter.Write(collection);
            Assert.IsNotNull(data);
            Assert.AreEqual(s_collapsedPayload, data.ToString());
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
    }
}

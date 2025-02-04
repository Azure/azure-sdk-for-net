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
        private static readonly List<List<AvailabilitySetData>> s_availabilitySets = ModelReaderWriter.Read<List<List<AvailabilitySetData>>>(s_data)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static readonly HashSet<Type> s_supportedCollectionTypes =
        [
            typeof(List<>),
            typeof(Dictionary<,>)
        ];

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

        private static readonly IEnumerable<TestCaseData> s_listOfLists =
        [
            new TestCaseData(new List<List<AvailabilitySetData>>(s_availabilitySets))
                .SetName("{m}-ListOfList"),
            new TestCaseData(new AvailabilitySetData[,] { { s_availabilitySets[0][0], s_availabilitySets[0][1] }, { s_availabilitySets[1][0], s_availabilitySets[1][1] } })
                .SetName("{m}-MultiDimensionalArray"),
            new TestCaseData((object)new AvailabilitySetData[][] { new AvailabilitySetData[] { s_availabilitySets[0][0], s_availabilitySets[0][1] }, new AvailabilitySetData[] { s_availabilitySets[1][0], s_availabilitySets[1][1] } })
                .SetName("{m}-JaggedArray"),
            new TestCaseData(new List<AvailabilitySetData[]>() { new AvailabilitySetData[] { s_availabilitySets[0][0], s_availabilitySets[0][1] }, new AvailabilitySetData[] { s_availabilitySets[1][0], s_availabilitySets[1][1] } })
                .SetName("{m}-ListOfArray"),
            new TestCaseData((object)new List<AvailabilitySetData>[] { s_availabilitySets[0], s_availabilitySets[1] })
                .SetName("{m}-ArrayOfList"),
            new TestCaseData(new Collection<Collection<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-CollectionOfCollection"),
            new TestCaseData(new Collection<List<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-CollectionOfList"),
            new TestCaseData(new List<Collection<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-ListOfCollection"),
            new TestCaseData(new ObservableCollection<ObservableCollection<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-ObservableOfObservable"),
            new TestCaseData(new ObservableCollection<List<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-ObservableOfList"),
            new TestCaseData(new HashSet<HashSet<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-HashOfHash"),
            new TestCaseData(new HashSet<List<AvailabilitySetData>> () { new(s_availabilitySets[0]), new(s_availabilitySets[1]) })
                .SetName("{m}-HashOfList"),
            new TestCaseData(new Queue<Queue<AvailabilitySetData>> ([new Queue<AvailabilitySetData>(s_availabilitySets[0]), new Queue<AvailabilitySetData>(s_availabilitySets[1])]))
                .SetName("{m}-QueueOfQueue"),
            new TestCaseData(new Queue<List<AvailabilitySetData>> ([[.. s_availabilitySets[0]], [.. s_availabilitySets[1]]]))
                .SetName("{m}-QueueOfList"),
            new TestCaseData(new Stack<Stack<AvailabilitySetData>> ([new Stack<AvailabilitySetData>([s_availabilitySets[1][1], s_availabilitySets[1][0]]), new Stack<AvailabilitySetData>([s_availabilitySets[0][1], s_availabilitySets[0][0]])]))
                .SetName("{m}-StackOfStack"),
            new TestCaseData(new Stack<List<AvailabilitySetData>> ([[.. s_availabilitySets[1]], [.. s_availabilitySets[0]]]))
                .SetName("{m}-StackOfList"),
            new TestCaseData(new LinkedList<LinkedList<AvailabilitySetData>> ([new LinkedList<AvailabilitySetData>(s_availabilitySets[0]), new LinkedList<AvailabilitySetData>(s_availabilitySets[1])]))
                .SetName("{m}-LinkedOfLinked"),
            new TestCaseData(new LinkedList<List<AvailabilitySetData>> ([[.. s_availabilitySets[0]], [.. s_availabilitySets[1]]]))
                .SetName("{m}-LinkedOfList"),
        ];

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

        [TestCaseSource(nameof(s_listOfLists))]
        public void ValidateTypeChecking(object collection)
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

        [TestCaseSource(nameof(s_listOfLists))]
        public void WriteCollection(object collection)
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
            var ex = Assert.Throws<MissingMethodException>(() => ModelReaderWriter.Read(s_data, typeof(FileStream)));
            Assert.IsNotNull(ex);
        }
    }
}

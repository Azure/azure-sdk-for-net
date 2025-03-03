// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    public class AvailabilitySetDataDictionaryOfListsTests
    {
        private static readonly LocalContext s_readerWriterContext = new();
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataDictionaryOfLists.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly IDictionary<string, List<AvailabilitySetData>> s_availabilitySets = ModelReaderWriter.Read<Dictionary<string, List<AvailabilitySetData>>>(s_data, s_readerWriterContext)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> _LibraryContext = new(() => new());
            private Dictionary_String_List_AvailabilitySetData_Info? _dictionary_String_List_AvailabilitySet_Info;
            private List_AvailabilitySetData_Info? _list_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, List<AvailabilitySetData>>) => _dictionary_String_List_AvailabilitySet_Info ??= new(),
                    Type t when t == typeof(List<AvailabilitySetData>) => _list_AvailabilitySetData_Info ??= new(),
                    _ => _LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_AvailabilitySetData_Builder();

                private class List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => _LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }

            private class Dictionary_String_List_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_String_List_AvailabilitySetData_Builder();

                private class Dictionary_String_List_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, List<AvailabilitySetData>>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<List<AvailabilitySetData>>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => _LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }

        [Test]
        public void ReadDictionaryGeneric()
        {
            var asetDictionary = ModelReaderWriter.Read<Dictionary<string, List<AvailabilitySetData>>>(s_data, s_readerWriterContext);
            Assert.IsNotNull(asetDictionary);

            Assert.AreEqual(2, asetDictionary!.Count);
            Assert.IsTrue(asetDictionary.ContainsKey("list1"));
            var list1 = asetDictionary["list1"];
            Assert.IsNotNull(list1);
            Assert.AreEqual(2, list1.Count);
            Assert.IsTrue(list1[0].Name!.Equals("testAS-3375"));
            Assert.IsTrue(list1[1].Name!.Equals("testAS-3376"));
            Assert.IsTrue(asetDictionary.ContainsKey("list2"));
            var list2 = asetDictionary["list2"];
            Assert.IsNotNull(list2);
            Assert.AreEqual(2, list2.Count);
            Assert.IsTrue(list2[0].Name!.Equals("testAS-3377"));
            Assert.IsTrue(list2[1].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void ReadDictionary()
        {
            var asetDictionary = ModelReaderWriter.Read(s_data, typeof(Dictionary<string, List<AvailabilitySetData>>), s_readerWriterContext);
            Assert.IsNotNull(asetDictionary);

            Dictionary<string, List<AvailabilitySetData>>? asetDictionary2 = asetDictionary! as Dictionary<string, List<AvailabilitySetData>>;
            Assert.IsNotNull(asetDictionary2);

            Assert.AreEqual(2, asetDictionary2!.Count);
            Assert.IsTrue(asetDictionary2.ContainsKey("list1"));
            var list1 = asetDictionary2["list1"];
            Assert.IsNotNull(list1);
            Assert.AreEqual(2, list1.Count);
            Assert.IsTrue(list1[0].Name!.Equals("testAS-3375"));
            Assert.IsTrue(list1[1].Name!.Equals("testAS-3376"));
            Assert.IsTrue(asetDictionary2.ContainsKey("list2"));
            var list2 = asetDictionary2["list2"];
            Assert.IsNotNull(list2);
            Assert.AreEqual(2, list2.Count);
            Assert.IsTrue(list2[0].Name!.Equals("testAS-3377"));
            Assert.IsTrue(list2[1].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void WriteDictionary()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(s_availabilitySets));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Dictionary`2 does not implement IPersistableModel", ex!.Message);
        }
    }
}

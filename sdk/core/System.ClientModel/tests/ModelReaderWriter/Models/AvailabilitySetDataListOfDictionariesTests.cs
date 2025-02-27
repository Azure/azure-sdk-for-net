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
    public class AvailabilitySetDataListOfDictionariesTests
    {
        private static readonly LocalContext s_readerWriterContext = new();
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataListOfDictionaries.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly IList<Dictionary<string, AvailabilitySetData>> s_availabilitySets = ModelReaderWriter.Read<List<Dictionary<string, AvailabilitySetData>>>(s_data, s_readerWriterContext)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private Lazy<TestModelReaderWriterContext> _LibraryContext = new Lazy<TestModelReaderWriterContext>(() => new TestModelReaderWriterContext());

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(List<Dictionary<string, AvailabilitySetData>>) => new List_Dictionary_String_AvailabilitySetData_Info(),
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => new Dictionary_String_AvailabilitySetData_Info(),
                    _ => _LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class Dictionary_String_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_String_AvailabilitySetData_Builder();

                private class Dictionary_String_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, AvailabilitySetData>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<AvailabilitySetData>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }

            private class List_Dictionary_String_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new List_Dictionary_String_AvailabilitySetData_Builder();

                private class List_Dictionary_String_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<List<Dictionary<string, AvailabilitySetData>>> _instance = new(() => []);

                    protected override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertItem<Dictionary<string, AvailabilitySetData>>(item));

                    protected override object GetBuilder() => _instance.Value;
                }
            }
        }

        [Test]
        public void ReadDictionaryGeneric()
        {
            var asetList = ModelReaderWriter.Read<List<Dictionary<string, AvailabilitySetData>>>(s_data, s_readerWriterContext);
            Assert.IsNotNull(asetList);

            Assert.AreEqual(2, asetList!.Count);
            var dictionary1 = asetList[0];
            Assert.AreEqual(2, dictionary1.Count);
            Assert.IsTrue(dictionary1.ContainsKey("testAS-3375"));
            Assert.IsTrue(dictionary1["testAS-3375"].Name!.Equals("testAS-3375"));
            Assert.IsTrue(dictionary1.ContainsKey("testAS-3376"));
            Assert.IsTrue(dictionary1["testAS-3376"].Name!.Equals("testAS-3376"));
            var dictionary2 = asetList[1];
            Assert.AreEqual(2, dictionary2.Count);
            Assert.IsTrue(dictionary2.ContainsKey("testAS-3377"));
            Assert.IsTrue(dictionary2["testAS-3377"].Name!.Equals("testAS-3377"));
            Assert.IsTrue(dictionary2.ContainsKey("testAS-3378"));
            Assert.IsTrue(dictionary2["testAS-3378"].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void ReadDictionary()
        {
            var asetList = ModelReaderWriter.Read(s_data, typeof(List<Dictionary<string, AvailabilitySetData>>), s_readerWriterContext);
            Assert.IsNotNull(asetList);

            List<Dictionary<string, AvailabilitySetData>>? asetList2 = asetList! as List<Dictionary<string, AvailabilitySetData>>;
            Assert.IsNotNull(asetList2);

            Assert.AreEqual(2, asetList2!.Count);
            var dictionary1 = asetList2[0];
            Assert.AreEqual(2, dictionary1.Count);
            Assert.IsTrue(dictionary1.ContainsKey("testAS-3375"));
            Assert.IsTrue(dictionary1["testAS-3375"].Name!.Equals("testAS-3375"));
            Assert.IsTrue(dictionary1.ContainsKey("testAS-3376"));
            Assert.IsTrue(dictionary1["testAS-3376"].Name!.Equals("testAS-3376"));
            var dictionary2 = asetList2[1];
            Assert.AreEqual(2, dictionary2.Count);
            Assert.IsTrue(dictionary2.ContainsKey("testAS-3377"));
            Assert.IsTrue(dictionary2["testAS-3377"].Name!.Equals("testAS-3377"));
            Assert.IsTrue(dictionary2.ContainsKey("testAS-3378"));
            Assert.IsTrue(dictionary2["testAS-3378"].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void WriteDictionary()
        {
            BinaryData data = ModelReaderWriter.Write(s_availabilitySets);
            Assert.IsNotNull(data);
            Assert.AreEqual(s_collapsedPayload, data.ToString());
        }
    }
}

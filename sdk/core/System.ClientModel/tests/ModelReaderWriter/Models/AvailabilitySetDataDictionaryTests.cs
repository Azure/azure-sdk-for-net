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
    public class AvailabilitySetDataDictionaryTests
    {
        private static readonly LocalContext s_readerWriterContext = new();
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataDictionary.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly IDictionary<string, AvailabilitySetData> s_availabilitySets = ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(s_data, s_readerWriterContext)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestModelReaderWriterContext> _LibraryContext = new(() => new());
            private Dictionary_String_AvailabilitySetData_Info? _dictionary_String_AvailabilitySetData_Info;

            public override ModelInfo? GetModelInfo(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => _dictionary_String_AvailabilitySetData_Info ??= new(),
                    _ => _LibraryContext.Value.GetModelInfo(type)
                };
            }

            private class Dictionary_String_AvailabilitySetData_Info : ModelInfo
            {
                public override object CreateObject() => new Dictionary_String_AvailabilitySetData_Builder();

                private class Dictionary_String_AvailabilitySetData_Builder : CollectionBuilder
                {
                    private readonly Lazy<Dictionary<string, AvailabilitySetData>> _instance = new(() => []);

                    protected internal override void AddItem(object item, string? key = null) => _instance.Value.Add(AssertKey(key), AssertItem<AvailabilitySetData>(item));

                    protected internal override object GetBuilder() => _instance.Value;

                    protected internal override object? GetElement() => _LibraryContext.Value.GetModelInfo(typeof(AvailabilitySetData))?.CreateObject();
                }
            }
        }

        [Test]
        public void ReadDictionaryGeneric()
        {
            var asetDictionary = ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(s_data, s_readerWriterContext);
            Assert.IsNotNull(asetDictionary);

            Assert.AreEqual(2, asetDictionary!.Count);
            Assert.IsTrue(asetDictionary.ContainsKey("testAS-3375"));
            Assert.IsTrue(asetDictionary["testAS-3375"].Name!.Equals("testAS-3375"));
            Assert.IsTrue(asetDictionary.ContainsKey("testAS-3376"));
            Assert.IsTrue(asetDictionary["testAS-3376"].Name!.Equals("testAS-3376"));
        }

        [Test]
        public void ReadDictionary()
        {
            var asetDictionary = ModelReaderWriter.Read(s_data, typeof(Dictionary<string, AvailabilitySetData>), s_readerWriterContext);
            Assert.IsNotNull(asetDictionary);

            Dictionary<string, AvailabilitySetData>? asetDictionary2 = asetDictionary! as Dictionary<string, AvailabilitySetData>;
            Assert.IsNotNull(asetDictionary2);

            Assert.AreEqual(2, asetDictionary2!.Count);
            Assert.IsTrue(asetDictionary2.ContainsKey("testAS-3375"));
            Assert.IsTrue(asetDictionary2["testAS-3375"].Name!.Equals("testAS-3375"));
            Assert.IsTrue(asetDictionary2.ContainsKey("testAS-3376"));
            Assert.IsTrue(asetDictionary2["testAS-3376"].Name!.Equals("testAS-3376"));
        }

        [Test]
        public void WriteDictionary()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(s_availabilitySets));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Dictionary`2 does not implement IPersistableModel", ex!.Message);
        }

        [Test]
        public void ReadListWhenDictionary()
        {
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<AvailabilitySetData>>(s_data, s_readerWriterContext));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Expected start of array."));
        }
    }
}

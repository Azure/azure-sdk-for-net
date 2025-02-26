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
    public class AvailabilitySetDataDictionaryOfDictionariesTests
    {
        private static readonly LocalContext s_readerWriterContext = new();
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataDictionaryOfDictionaries.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly IDictionary<string, Dictionary<string, AvailabilitySetData>> s_availabilitySets = ModelReaderWriter.Read<Dictionary<string, Dictionary<string, AvailabilitySetData>>>(s_data, s_readerWriterContext)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        private class LocalContext : ModelReaderWriterContext
        {
            private Lazy<TestModelReaderWriterContext> _LibraryContext = new Lazy<TestModelReaderWriterContext>(() => new TestModelReaderWriterContext());

            public override Func<object>? GetActivator(Type type)
            {
                return type switch
                {
                    Type t when t == typeof(Dictionary<string, Dictionary<string, AvailabilitySetData>>) => () => new Dictionary<string, Dictionary<string, AvailabilitySetData>>(),
                    Type t when t == typeof(Dictionary<string, AvailabilitySetData>) => () => new Dictionary<string, AvailabilitySetData>(),
                    _ => _LibraryContext.Value.GetActivator(type)
                };
            }
        }

        [Test]
        public void ReadDictionaryGeneric()
        {
            var asetDictionary = ModelReaderWriter.Read<Dictionary<string, Dictionary<string, AvailabilitySetData>>>(s_data, s_readerWriterContext);
            Assert.IsNotNull(asetDictionary);

            Assert.AreEqual(2, asetDictionary!.Count);
            Assert.IsTrue(asetDictionary.ContainsKey("dictionary1"));
            var innerDictionary1 = asetDictionary["dictionary1"];
            Assert.IsNotNull(innerDictionary1);
            Assert.AreEqual(2, innerDictionary1.Count);
            Assert.IsTrue(innerDictionary1.ContainsKey("testAS-3375"));
            Assert.IsTrue(innerDictionary1["testAS-3375"].Name!.Equals("testAS-3375"));
            Assert.IsTrue(innerDictionary1.ContainsKey("testAS-3376"));
            Assert.IsTrue(innerDictionary1["testAS-3376"].Name!.Equals("testAS-3376"));
            Assert.IsTrue(asetDictionary.ContainsKey("dictionary2"));
            var innerDictionary2 = asetDictionary["dictionary2"];
            Assert.IsNotNull(innerDictionary2);
            Assert.AreEqual(2, innerDictionary2.Count);
            Assert.IsTrue(innerDictionary2.ContainsKey("testAS-3377"));
            Assert.IsTrue(innerDictionary2["testAS-3377"].Name!.Equals("testAS-3377"));
            Assert.IsTrue(innerDictionary2.ContainsKey("testAS-3378"));
            Assert.IsTrue(innerDictionary2["testAS-3378"].Name!.Equals("testAS-3378"));
        }

        [Test]
        public void ReadDictionary()
        {
            var asetDictionary = ModelReaderWriter.Read(s_data, typeof(Dictionary<string, Dictionary<string, AvailabilitySetData>>), s_readerWriterContext);
            Assert.IsNotNull(asetDictionary);

            Dictionary<string, Dictionary<string, AvailabilitySetData>>? asetDictionary2 = asetDictionary! as Dictionary<string, Dictionary<string, AvailabilitySetData>>;
            Assert.IsNotNull(asetDictionary2);

            Assert.AreEqual(2, asetDictionary2!.Count);
            Assert.IsTrue(asetDictionary2.ContainsKey("dictionary1"));
            var innerDictionary1 = asetDictionary2["dictionary1"];
            Assert.IsNotNull(innerDictionary1);
            Assert.AreEqual(2, asetDictionary2.Count);
            Assert.IsTrue(innerDictionary1.ContainsKey("testAS-3375"));
            Assert.IsTrue(innerDictionary1["testAS-3375"].Name!.Equals("testAS-3375"));
            Assert.IsTrue(innerDictionary1.ContainsKey("testAS-3376"));
            Assert.IsTrue(innerDictionary1["testAS-3376"].Name!.Equals("testAS-3376"));
            Assert.IsTrue(asetDictionary2.ContainsKey("dictionary2"));
            var innerDictionary2 = asetDictionary2["dictionary2"];
            Assert.IsNotNull(innerDictionary2);
            Assert.AreEqual(2, asetDictionary2.Count);
            Assert.IsTrue(innerDictionary2.ContainsKey("testAS-3377"));
            Assert.IsTrue(innerDictionary2["testAS-3377"].Name!.Equals("testAS-3377"));
            Assert.IsTrue(innerDictionary2.ContainsKey("testAS-3378"));
            Assert.IsTrue(innerDictionary2["testAS-3378"].Name!.Equals("testAS-3378"));
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

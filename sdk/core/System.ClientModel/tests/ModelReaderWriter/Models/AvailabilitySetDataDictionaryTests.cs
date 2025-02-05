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
        private static readonly string s_payload = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataDictionary.json")).TrimEnd();
        private static readonly BinaryData s_data = new BinaryData(Encoding.UTF8.GetBytes(s_payload));
        private static readonly IDictionary<string, AvailabilitySetData> s_availabilitySets = ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(s_data)!;
        private static readonly string s_collapsedPayload = GetCollapsedPayload();

        private static string GetCollapsedPayload()
        {
            var jsonObject = JsonSerializer.Deserialize<object>(s_payload);
            return JsonSerializer.Serialize(jsonObject);
        }

        [Test]
        public void ReadDictionaryGeneric()
        {
            var asetDictionary = ModelReaderWriter.Read<Dictionary<string, AvailabilitySetData>>(s_data);
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
            var asetDictionary = ModelReaderWriter.Read(s_data, typeof(Dictionary<string, AvailabilitySetData>));
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
            BinaryData data = ModelReaderWriter.Write(s_availabilitySets);
            Assert.IsNotNull(data);
            Assert.AreEqual(s_collapsedPayload, data.ToString());
        }

        [Test]
        public void ReadListWhenDictionary()
        {
            var ex = Assert.Throws<FormatException>(() => ModelReaderWriter.Read<List<AvailabilitySetData>>(s_data));
            Assert.IsNotNull(ex);
            Assert.IsTrue(ex!.Message.Equals("Expected start of array."));
        }
    }
}

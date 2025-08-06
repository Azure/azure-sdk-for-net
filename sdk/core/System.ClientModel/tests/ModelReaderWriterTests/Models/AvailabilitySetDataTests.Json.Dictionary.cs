// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.IO;
using Azure.Core;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal partial class AvailabilitySetDataTests
    {
        [Test]
        public void AddItemToDictionary()
        {
            var model = GetInitialModel();

            model.Patch.Set("$.newDictionary['key1']"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Set("$.newDictionary.key2"u8, "{\"x\":\"value2\"}"u8);

            Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary['key1']"u8).ToArray());
            Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary.key1"u8).ToArray());
            Assert.AreEqual("{\"x\":\"value2\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary['key2']"u8).ToArray());
            Assert.AreEqual("{\"x\":\"value2\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary.key2"u8).ToArray());

            var data = WriteModifiedModel(model, "newDictionary", "{\"key1\":{\"x\":\"value1\"},\"key2\":{\"x\":\"value2\"}}");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model2.Patch.GetJson("$.newDictionary['key1']"u8).ToArray());
            Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model2.Patch.GetJson("$.newDictionary.key1"u8).ToArray());
            Assert.AreEqual("{\"x\":\"value2\"}"u8.ToArray(), model2.Patch.GetJson("$.newDictionary['key2']"u8).ToArray());
            Assert.AreEqual("{\"x\":\"value2\"}"u8.ToArray(), model2.Patch.GetJson("$.newDictionary.key2"u8).ToArray());

            AssertCommon(model, model2);
        }

        [Test]
        public void AddItemToDictionaryClr()
        {
            var model = GetInitialModel();

            model.Patch.Set("$.tags.insertedKey"u8, "insertedValue");

            Assert.AreEqual("insertedValue", model.Patch.GetString("$.tags.insertedKey"u8));

            var data = WriteModifiedModel(model, "tags", "{\"key\":\"value\",\"insertedKey\":\"insertedValue\"}");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("insertedValue", model2.Patch.GetString("$.tags['insertedKey']"u8));
            Assert.AreEqual("insertedValue", model2.Patch.GetString("$.tags.insertedKey"u8));

            AssertCommon(model, model2, "tags");
        }

        [Test]
        public void ReplaceItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model!.Items.Count);
            Assert.IsTrue(model.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual("testAS-3375", model.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3375", model.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model.Patch.GetString("$.testAS-3376.name"u8));

            model.Patch.Set("$.testAS-3375"u8, new AvailabilitySetData(AzureLocation.BrazilSouth)
            {
                Name = "testAS-3377",
                Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
                ResourceType = "Microsoft.Compute/availabilitySets",
            });

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model2);
            Assert.AreEqual(2, model2!.Items.Count);
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3376"));
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3375"));
            Assert.AreEqual("testAS-3377", model2.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model2.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3377", model2.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model2.Patch.GetString("$.testAS-3376.name"u8));

            Assert.AreEqual("brazilsouth", model2.Items["testAS-3375"].Location.ToString());
            Assert.AreEqual("brazilsouth", model2.Patch.GetString("$.testAS-3375.location"u8));
        }

        [Test]
        public void RemoveItemFromDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model!.Items.Count);
            Assert.IsTrue(model.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual("testAS-3375", model.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3375", model.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model.Patch.GetString("$.testAS-3376.name"u8));

            model.Patch.Remove("$.testAS-3375"u8);

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model2);
            Assert.AreEqual(1, model2!.Items.Count);
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual("testAS-3376", model2.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3376", model2.Patch.GetString("$.testAS-3376.name"u8));
        }

        [Test]
        public void AddPropertyToItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model!.Items.Count);
            Assert.IsTrue(model.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual("testAS-3375", model.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3375", model.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model.Patch.GetString("$.testAS-3376.name"u8));

            model.Patch.Set("$.testAS-3377"u8, new AvailabilitySetData(AzureLocation.BrazilSouth)
            {
                Name = "testAS-3377",
                Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
                ResourceType = "Microsoft.Compute/availabilitySets",
            });

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model2);
            Assert.AreEqual(3, model2!.Items.Count);
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3376"));
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3377"));
            Assert.AreEqual("testAS-3377", model2.Items["testAS-3377"].Name);
            Assert.AreEqual("testAS-3375", model2.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model2.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3377", model2.Patch.GetString("$.testAS-3377.name"u8));
            Assert.AreEqual("testAS-3375", model2.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model2.Patch.GetString("$.testAS-3376.name"u8));

            Assert.AreEqual("brazilsouth", model2.Items["testAS-3377"].Location.ToString());
            Assert.AreEqual("brazilsouth", model2.Patch.GetString("$.testAS-3377.location"u8));

            model2.Patch.Set("$.testAS-3377.foobar"u8, 999);

            Assert.AreEqual(999, model2.Patch.GetInt32("$.testAS-3377.foobar"u8));

            var data2 = ModelReaderWriter.Write(model2, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            var model3 = ModelReaderWriter.Read<DictionaryOfAset>(data2, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model3);
            Assert.AreEqual(3, model3!.Items.Count);
            Assert.IsTrue(model3.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model3.Items.ContainsKey("testAS-3376"));
            Assert.IsTrue(model3.Items.ContainsKey("testAS-3377"));
            Assert.AreEqual("testAS-3377", model3.Items["testAS-3377"].Name);
            Assert.AreEqual("testAS-3375", model3.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model3.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3377", model3.Patch.GetString("$.testAS-3377.name"u8));
            Assert.AreEqual("testAS-3375", model3.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model3.Patch.GetString("$.testAS-3376.name"u8));
            Assert.AreEqual("brazilsouth", model3.Items["testAS-3377"].Location.ToString());
            Assert.AreEqual("brazilsouth", model3.Patch.GetString("$.testAS-3377.location"u8));
            Assert.AreEqual(999, model3.Patch.GetInt32("$.testAS-3377.foobar"u8));
        }

        [Test]
        public void ChangePropertyInItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model!.Items.Count);
            Assert.IsTrue(model.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual(5, model.Items["testAS-3375"].PlatformUpdateDomainCount);
            Assert.AreEqual("testAS-3375", model.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3375", model.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model.Patch.GetString("$.testAS-3376.name"u8));

            model.Patch.Set("$.testAS-3375.properties.platformUpdateDomainCount"u8, 10);

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model2);
            Assert.AreEqual(2, model2!.Items.Count);
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual(10, model2.Items["testAS-3375"].PlatformUpdateDomainCount);
            Assert.AreEqual("testAS-3375", model2.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model2.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3375", model2.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model2.Patch.GetString("$.testAS-3376.name"u8));
            Assert.AreEqual(10, model2.Patch.GetInt32("$.testAS-3375.properties.platformUpdateDomainCount"u8));
        }

        [Test]
        public void RemovePropertyFromItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model!.Items.Count);
            Assert.IsTrue(model.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual("testAS-3375", model.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model.Items["testAS-3376"].Name);
            Assert.AreEqual("testAS-3375", model.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model.Patch.GetString("$.testAS-3376.name"u8));

            model.Patch.Remove("$.testAS-3375.name"u8);

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model2);
            Assert.AreEqual(2, model2!.Items.Count);
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3375"));
            Assert.IsTrue(model2.Items.ContainsKey("testAS-3376"));
            Assert.AreEqual(null, model2.Items["testAS-3375"].Name);
            Assert.AreEqual("testAS-3376", model2.Items["testAS-3376"].Name);
            Assert.Throws<Exception>(() => model2.Patch.GetString("$.testAS-3375.name"u8));
            Assert.AreEqual("testAS-3376", model2.Patch.GetString("$.testAS-3376.name"u8));
        }
    }
}

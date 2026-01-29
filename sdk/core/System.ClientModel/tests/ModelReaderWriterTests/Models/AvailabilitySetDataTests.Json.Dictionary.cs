// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
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

            Assert.That(model.Patch.GetJson("$.newDictionary['key1']"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model.Patch.GetJson("$.newDictionary.key1"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model.Patch.GetJson("$.newDictionary['key2']"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));
            Assert.That(model.Patch.GetJson("$.newDictionary.key2"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newDictionary\":{\"key1\":{\"x\":\"value1\"},\"key2\":{\"x\":\"value2\"}}}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newDictionary['key1']"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model2.Patch.GetJson("$.newDictionary.key1"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model2.Patch.GetJson("$.newDictionary['key2']"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));
            Assert.That(model2.Patch.GetJson("$.newDictionary.key2"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddItemToDictionaryClr()
        {
            var model = GetInitialModel();

            model.Patch.Set("$.tags.insertedKey"u8, "insertedValue");
            model.Patch.Set("$['tags'].insertedKey2"u8, "insertedValue2");

            Assert.That(model.Patch.GetString("$.tags.insertedKey"u8), Is.EqualTo("insertedValue"));
            Assert.That(model.Patch.GetString("$.tags.insertedKey2"u8), Is.EqualTo("insertedValue2"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\",\"insertedKey\":\"insertedValue\",\"insertedKey2\":\"insertedValue2\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetString("$['tags']['insertedKey']"u8), Is.EqualTo("insertedValue"));
            Assert.That(model2.Patch.GetString("$['tags'].insertedKey"u8), Is.EqualTo("insertedValue"));
            Assert.That(model2.Patch.GetString("$.tags.['insertedKey']"u8), Is.EqualTo("insertedValue"));
            Assert.That(model2.Patch.GetString("$.tags.insertedKey"u8), Is.EqualTo("insertedValue"));
            Assert.That(model2.Patch.GetString("$['tags']['insertedKey2']"u8), Is.EqualTo("insertedValue2"));
            Assert.That(model2.Patch.GetString("$['tags'].insertedKey2"u8), Is.EqualTo("insertedValue2"));
            Assert.That(model2.Patch.GetString("$.tags['insertedKey2']"u8), Is.EqualTo("insertedValue2"));
            Assert.That(model2.Patch.GetString("$.tags.insertedKey2"u8), Is.EqualTo("insertedValue2"));

            AssertCommon(model, model2, "tags");
        }

        [Test]
        public void ReplaceItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            model.Patch.Set<AvailabilitySetData>("$.testAS-3375"u8, new AvailabilitySetData(AzureLocation.BrazilSouth)
            {
                Name = "testAS-3377",
                Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
                ResourceType = "Microsoft.Compute/availabilitySets",
            });

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"testAS-3375\":{\"name\":\"testAS-3377\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"brazilsouth\",\"properties\":{}},\"testAS-3376\":{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}}}"));

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model2, Is.Not.Null);
            Assert.That(model2!.Items.Count, Is.EqualTo(2));
            Assert.That(model2.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model2.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model2.Items["testAS-3375"].Name, Is.EqualTo("testAS-3377"));
            Assert.That(model2.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model2.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3377"));
            Assert.That(model2.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            Assert.That(model2.Items["testAS-3375"].Location.ToString(), Is.EqualTo("brazilsouth"));
            Assert.That(model2.Patch.GetString("$.testAS-3375.location"u8), Is.EqualTo("brazilsouth"));
        }

        [Test]
        public void RemoveItemFromDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            model.Patch.Remove("$.testAS-3375"u8);

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"testAS-3376\":{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}}}"));

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model2, Is.Not.Null);
            Assert.That(model2!.Items.Count, Is.EqualTo(1));
            Assert.That(model2.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model2.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model2.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));
        }

        [Test]
        public void AddPropertyToItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            model.Patch.Set<AvailabilitySetData>("$.testAS-3377"u8, new AvailabilitySetData(AzureLocation.BrazilSouth)
            {
                Name = "testAS-3377",
                Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
                ResourceType = "Microsoft.Compute/availabilitySets",
            });

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"testAS-3375\":{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}},\"testAS-3376\":{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}},\"testAS-3377\":{\"name\":\"testAS-3377\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"brazilsouth\",\"properties\":{}}}"));

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model2, Is.Not.Null);
            Assert.That(model2!.Items.Count, Is.EqualTo(3));
            Assert.That(model2.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model2.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model2.Items.ContainsKey("testAS-3377"), Is.True);
            Assert.That(model2.Items["testAS-3377"].Name, Is.EqualTo("testAS-3377"));
            Assert.That(model2.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model2.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model2.Patch.GetString("$.testAS-3377.name"u8), Is.EqualTo("testAS-3377"));
            Assert.That(model2.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model2.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            Assert.That(model2.Items["testAS-3377"].Location.ToString(), Is.EqualTo("brazilsouth"));
            Assert.That(model2.Patch.GetString("$.testAS-3377.location"u8), Is.EqualTo("brazilsouth"));

            model2.Patch.Set("$.testAS-3377.foobar"u8, 999);

            Assert.That(model2.Patch.GetInt32("$.testAS-3377.foobar"u8), Is.EqualTo(999));

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"testAS-3375\":{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}},\"testAS-3376\":{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}},\"testAS-3377\":{\"name\":\"testAS-3377\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"brazilsouth\",\"properties\":{},\"foobar\":999}}"));

            var model3 = ModelReaderWriter.Read<DictionaryOfAset>(data2, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model3, Is.Not.Null);
            Assert.That(model3!.Items.Count, Is.EqualTo(3));
            Assert.That(model3.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model3.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model3.Items.ContainsKey("testAS-3377"), Is.True);
            Assert.That(model3.Items["testAS-3377"].Name, Is.EqualTo("testAS-3377"));
            Assert.That(model3.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model3.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model3.Patch.GetString("$.testAS-3377.name"u8), Is.EqualTo("testAS-3377"));
            Assert.That(model3.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model3.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));
            Assert.That(model3.Items["testAS-3377"].Location.ToString(), Is.EqualTo("brazilsouth"));
            Assert.That(model3.Patch.GetString("$.testAS-3377.location"u8), Is.EqualTo("brazilsouth"));
            Assert.That(model3.Patch.GetInt32("$.testAS-3377.foobar"u8), Is.EqualTo(999));
        }

        [Test]
        public void ChangePropertyInItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model.Items["testAS-3375"].PlatformUpdateDomainCount, Is.EqualTo(5));
            Assert.That(model.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            model.Patch.Set("$.testAS-3375.properties.platformUpdateDomainCount"u8, 10);

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"testAS-3375\":{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformFaultDomainCount\":3,\"platformUpdateDomainCount\":10}},\"testAS-3376\":{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}}}"));

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model2, Is.Not.Null);
            Assert.That(model2!.Items.Count, Is.EqualTo(2));
            Assert.That(model2.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model2.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model2.Items["testAS-3375"].PlatformUpdateDomainCount, Is.EqualTo(10));
            Assert.That(model2.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model2.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model2.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model2.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));
            Assert.That(model2.Patch.GetInt32("$.testAS-3375.properties.platformUpdateDomainCount"u8), Is.EqualTo(10));
        }

        [Test]
        public void RemovePropertyFromItemInDictionary()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/Dictionary/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<DictionaryOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model.Items["testAS-3375"].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model.Patch.GetString("$.testAS-3375.name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));

            model.Patch.Remove("$.testAS-3375.name"u8);

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"testAS-3375\":{\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}},\"testAS-3376\":{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}}}"));

            var model2 = ModelReaderWriter.Read<DictionaryOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model2, Is.Not.Null);
            Assert.That(model2!.Items.Count, Is.EqualTo(2));
            Assert.That(model2.Items.ContainsKey("testAS-3375"), Is.True);
            Assert.That(model2.Items.ContainsKey("testAS-3376"), Is.True);
            Assert.That(model2.Items["testAS-3375"].Name, Is.EqualTo(null));
            Assert.That(model2.Items["testAS-3376"].Name, Is.EqualTo("testAS-3376"));
            Assert.Throws<KeyNotFoundException>(() => model2.Patch.GetString("$.testAS-3375.name"u8));
            Assert.That(model2.Patch.GetString("$.testAS-3376.name"u8), Is.EqualTo("testAS-3376"));
        }
    }
}

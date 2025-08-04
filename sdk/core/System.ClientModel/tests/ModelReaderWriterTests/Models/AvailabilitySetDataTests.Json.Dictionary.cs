// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            //TODO do we need to normalize retrieving using a different syntax than inserting?
            //Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary.key1"u8).ToArray());
            //Assert.AreEqual("{\"x\":\"value2\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary['key2']"u8).ToArray());
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
            Assert.Fail("Not implemented");
        }

        [Test]
        public void RemoveItemFromDictionary()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void AddPropertyToItemInDictionary()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void ChangePropertyInItemInDictionary()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void RemovePropertyFromItemInDictionary()
        {
            Assert.Fail("Not implemented");
        }
    }
}

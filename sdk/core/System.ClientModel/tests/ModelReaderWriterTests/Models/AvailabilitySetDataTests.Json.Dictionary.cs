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

            Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model.Patch.GetJson("$.newDictionary['key1']"u8).ToArray());

            var data = WriteModifiedModel(model, "newDictionary", "{\"key1\":{\"x\":\"value1\"}}");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("{\"x\":\"value1\"}"u8.ToArray(), model2.Patch.GetJson("$.newDictionary['key1']"u8).ToArray());

            AssertCommon(model, model2);
        }

        [Test]
        public void AddItemToDictionaryClr()
        {
            Assert.Fail("Not implemented");
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

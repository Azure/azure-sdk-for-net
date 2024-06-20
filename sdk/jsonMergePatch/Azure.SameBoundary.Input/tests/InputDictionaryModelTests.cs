// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.SameBoundary.Input.Tests
{
    public class InputDictionaryModelTests
    {
        private IDictionary<string, string> _requiredStringDictionary;
        private IDictionary<string, int?> _requiredIntDictionary;
        private IDictionary<string, InputDummy> _requiredModelDictionary;
        private IDictionary<string, IDictionary<string, InputDummy>> _requiredDictionaryDictionary;
        private IDictionary<string, IList<InputDummy>> _requiredArrayDictionary;

        [SetUp]
        public void Init()
        {
            _requiredStringDictionary = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            _requiredIntDictionary = new Dictionary<string, int?>
            {
                { "key1", 1 },
                { "key2", 2 }
            };

            _requiredModelDictionary = new Dictionary<string, InputDummy>
            {
                { "key1", new InputDummy() { Property = "p1" }},
                { "key2", new InputDummy() { Property = "p2" } }
            };

            _requiredDictionaryDictionary = new Dictionary<string, IDictionary<string, InputDummy>>
            {
                { "key1", new Dictionary<string, InputDummy> { { "a", new InputDummy() { Property = "aa" } } } },
                { "key2", new Dictionary<string, InputDummy> { { "b", new InputDummy() { Property = "bb" } } } }
            };

            _requiredArrayDictionary = new Dictionary<string, IList<InputDummy>>
            {
                { "key1", new List<InputDummy> { new InputDummy() { Property = "a1" } } },
                { "key2", new List<InputDummy> { new InputDummy() { Property = "b2" } } }
            };
        }

        [Test]
        public void Case1_DeleteADictionary()
        {
            // This is an open question. We need a way to let customer delete a dictionary.
            // Solution 1: We allow `_dictionary = null;` by adding a set.
            // Solution 2: We interpret `_dictionary.Clear()` as delete operation.
            // Further, we should decide the behavior of `_dictionary.Clear()`
            // Explanation 1: {"dictionary" : null}
            // Explanation 2: {"dictionary" : {"key1": null, "key2": null}}
            // Explanation 3: {"dictionary" : {}}
        }

        [Test]
        public void Case2_RequiredPropertyShouldBeRegardedAsChanged()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case2_RequiredPropertyShouldBeRegardedAsChanged.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case3_OperateOnPrimitiveDictionary()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            // Delete by `Remove()`
            model.RequiredStringDictionary.Remove("key1");
            // Delete by `= null`
            model.RequiredIntDictionary["key1"] = null;
            // Add by `Add()`
            model.OptionalStringDictionary.Add("key3", "value3");
            // Add by `= value`
            model.OptionalIntDictionary["key4"] = 4;
            // Change value
            model.RequiredStringDictionary["key2"] = "changed";
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case3_OperateOnPrimitiveDictionary.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case4_OperateOnModelDictionary_ModelLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            // Delete an item by `Remove()`
            model.RequiredModelDictionary.Remove("key1");
            // Delete an item by `= null`
            model.RequiredModelDictionary["key2"] = null;
            // Add an item by `Add()`
            model.OptionalModelDictionary.Add("key3", new InputDummy() { Property = "p3" });
            // Add an item by `= value`
            model.OptionalModelDictionary["key4"] = new InputDummy() { Property = "p4" };
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case4_OperateOnModelDictionary_ModelLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case5_OperateOnModelDictionary_ModelPropertyLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            model.RequiredModelDictionary["key1"].Property = null;
            model.RequiredModelDictionary["key2"].Property = "changed";
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case5_OperateOnModelDictionary_ModelPropertyLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case6_OperateOnDictionaryDictionary_DictionaryLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            // Delete an item by `Remove()`
            model.RequiredDictionaryDictionary.Remove("key1");
            // Delete an item by `= null`
            model.RequiredDictionaryDictionary["key2"] = null;
            // Add an item by `Add()`. The type of dictionary is `Dictionary<string, InputDummy>`
            model.OptionalDictionaryDictionary.Add("key3", new Dictionary<string, InputDummy> { { "c", new InputDummy() } });
            // Add an item by `= value`. The type of dictionary is `Dictionary<string, InputDummy>`
            model.OptionalDictionaryDictionary["key4"] = new Dictionary<string, InputDummy> { { "d", new InputDummy() } };
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case6_OperateOnDictionaryDictionary_DictionaryLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case7_OperateOnDictionaryDictionary_InnerDictionaryLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            // Delete an item by `Remove()`
            // I'm thinking whether we should send {"a": null}. I think it is better to send
            model.RequiredDictionaryDictionary["key1"].Remove("a");
            // Delete an item by `= null`
            model.RequiredDictionaryDictionary["key2"]["b"] = null;
            // Add an item by `Add()`.
            model.RequiredDictionaryDictionary["key1"].Add("c", new InputDummy());
            // Add an item by `= value`.
            model.RequiredDictionaryDictionary["key2"]["d"] = new InputDummy();
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case7_OperateOnDictionaryDictionary_InnerDictionaryLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case8_OperateOnDictionaryDictionary_InnerModelPropertyLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            model.RequiredDictionaryDictionary["key1"]["a"].Property = null;
            model.RequiredDictionaryDictionary["key2"]["b"].Property = "changed";
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case8_OperateOnDictionaryDictionary_InnerModelPropertyLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case9_OperateOnArrayDictionary_ArrayLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            // Delete an item by `Remove()`
            model.RequiredArrayDictionary.Remove("key1");
            // Delete an item by `= null`
            model.RequiredArrayDictionary["key2"] = null;
            // Add an item by `Add()`. The type of array is `List<InputDummy>`
            model.OptionalArrayDictionary.Add("key3", new List<InputDummy>() { new InputDummy() { Property = "a" }, new InputDummy() { Property = "b" } });
            // Add an item by `= value`. The type of array is `List<InputDummy>`
            model.OptionalArrayDictionary["key4"] = new List<InputDummy>() { new InputDummy() { Property = "c" }, new InputDummy() { Property = "d" } };
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case9_OperateOnArrayDictionary_ArrayLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case10_OperateOnArrayDictionary_ArrayItemLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            // Delete an item by `Remove()`
            model.RequiredArrayDictionary["key1"].RemoveAt(0);
            // Delete an item by `= null`
            // This is an open question. From spec, `null` is not an acceptable value, but user could do this.
            model.RequiredArrayDictionary["key2"][0] = null;
            // Add an item by `Add()`.
            model.OptionalArrayDictionary["key1"] = new List<InputDummy>();
            model.OptionalArrayDictionary["key1"].Add(new InputDummy() { Property = "a" });
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case10_OperateOnArrayDictionary_ArrayItemLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case11_OperateOnArrayDictionary_ArrayItemPropertyLevel()
        {
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            model.RequiredArrayDictionary["key1"][0].Property = null;
            model.RequiredArrayDictionary["key2"][0].Property = "changed";
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputDictionary_Case11_OperateOnArrayDictionary_ArrayItemPropertyLevel.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case12_MultiThreadOnArrayDictionary()
        {
            // A very difference of array from dictionary is that every change in dictionary just make the change itself sent to server, while every change in array will make the whole array sent to server. This produces the below concurrent problem.
            // Thread 1: Do nothing and try to serializa the model. If finds `OptionalArrayDictionary.IsChanged(item.Key)` is `false`.
            // Thread 2: Add an item to `OptionalArrayDictionary.Add("newKey", new List<InputDummy>())`.
            // Thread 1: Starts to `OptionalArrayDictionary.Any(item => item.Value.IsChanged())`
            // Thread 1: Should not write "newKey"
            // Thread 2: Should write "newKey"
        }

        [Test]
        public void Case13_MultipleOperationsOnTheSameKey()
        {
            // This is just to illustarte operation on the same key will override the previous one, because there is no harm to do this.
            var model = new InputDictionaryModel(_requiredStringDictionary, _requiredIntDictionary, _requiredModelDictionary, _requiredDictionaryDictionary, _requiredArrayDictionary);
            model.RequiredIntDictionary["key3"] = 3;
            model.RequiredIntDictionary.Remove("key3");
            // Though adding "key3" + removing "key3" means doing nothing, we will still send {"key3": null}
        }
    }
}

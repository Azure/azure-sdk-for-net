// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.SameBoundary.Input.Tests
{
    public class InputArrayModelTests
    {
        private IList<string> _requiredStringArray;
        private IList<int> _requiredIntArray;
        private IList<InputDummy> _requiredModelArray;
        private IList<IList<InputDummy>> _requiredArrayArray;
        private IList<IDictionary<string, InputDummy>> _requiredDictionaryArray;

        [SetUp]
        public void SetUp()
        {
            _requiredStringArray = new List<string> { "string1", "string2", "string3", "string4" };
            _requiredIntArray = new List<int> { 1, 2, 3, 4 };
            _requiredModelArray = new List<InputDummy> { new InputDummy() { Property = "dummy1" }, new InputDummy() { Property = "dummy2" }, new InputDummy() { Property = "dummy3"}, new InputDummy() { Property = "dummy4"} };
            _requiredArrayArray = new List<IList<InputDummy>> {
                new List<InputDummy> { new InputDummy() { Property = "x" }, new InputDummy() { Property = "y" }, new InputDummy() { Property = "z" } },
                new List<InputDummy> { new InputDummy() { Property = "a" }, new InputDummy() { Property = "b" }, new InputDummy() { Property = "c" }, new InputDummy() { Property = "d" } }};
            _requiredDictionaryArray = new List<IDictionary<string, InputDummy>> {
                new Dictionary<string, InputDummy> { { "key1", new InputDummy { Property = "value1" } }, { "key2", new InputDummy { Property = "value2" } } },
                new Dictionary<string, InputDummy> { { "k1", new InputDummy { Property = "value1" } }, { "k2", new InputDummy { Property = "value2" } } }};
        }

        [Test]
        public void Case1_DeleteAnArray()
        {
            // This is an open question. We need a way to let customer delete an array.
            // Solution 1: We allow `_array = null;` by adding a set.
            // Solution 2: We interpret `_array.Clear()` as delete operation.
            // Further, we should decide the behavior of `_array.Clear()`
            // Explanation 1: {"array" : null}
            // Explanation 2: {"array" : []}
        }

        [Test]
        public void Case2_RequiredPropertyShouldBeRegardedAsChanged()
        {
            var model = new InputArrayModel(_requiredStringArray, _requiredIntArray, _requiredModelArray, _requiredArrayArray, _requiredDictionaryArray);
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputArray_Case2_RequiredPropertyShouldBeRegardedAsChanged.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case3_OperateOnPrimitiveArray()
        {
            var model = new InputArrayModel(_requiredStringArray, _requiredIntArray, _requiredModelArray, _requiredArrayArray, _requiredDictionaryArray);
            model.RequiredStringArray.Remove("string3");
            model.RequiredIntArray.RemoveAt(3);
            model.OptionalIntArray.Add(9);
            model.OptionalStringArray.Add("string9");
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputArray_Case3_OperateOnPrimitiveArray.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case4_OperateOnModelArray()
        {
            var model = new InputArrayModel(_requiredStringArray, _requiredIntArray, _requiredModelArray, _requiredArrayArray, _requiredDictionaryArray);
            model.RequiredModelArray[0].Property = "changed";
            model.RequiredModelArray.Add(new InputDummy() { Property = "dummy5" });
            model.OptionalModelArray.Add(new InputDummy() { Property = "dummy6" });
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputArray_Case4_OperateOnModelArray.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case5_DiscussMultiThreadOnPrimitiveArray()
        {
            var model = new InputArrayModel(_requiredStringArray, _requiredIntArray, _requiredModelArray, _requiredArrayArray, _requiredDictionaryArray);
            // Initial state: ["string1", "string2", "string3", "string4"]
            // Thread 1
            model.RequiredStringArray.Remove("string3");
            // When thread 1 is serializing
            // Thread 2
            model.RequiredStringArray.Add("string5");
            // Thread 1
            // Payload for Thread 1: ["string1", "string2", "string4", "string5"]
            // As long as Thread 2 is expected to serialize, the payload for Thread 1 is expected
        }

        [Test]
        // A very difference of array from dictionary is that every change in dictionary just make the change itself sent to server, while every change in array will make the whole array sent to server. This produces the below concurrent problem.
        public void Case6_DicussMultiThreadOnArrayArray()
        {
            var model = new InputArrayModel(_requiredStringArray, _requiredIntArray, _requiredModelArray, _requiredArrayArray, _requiredDictionaryArray);
            // Thread 1: do nothing and start to serialize. It finds `RequiredArrayArray.IsChanged()` is `false`.
            // Thread 2: RequiredArrayArray.Add(new List<InputDummy>() { <some value> })
            // Thread 1: starts to check `OptionalArrayArray.Any(item => item.IsChanged())`. One of the arrays is type of `List`, so don't have `IsChanged()`.
            // Option 1: Write all the items in that List
            // Option 2: Skip that List.
        }
    }
}

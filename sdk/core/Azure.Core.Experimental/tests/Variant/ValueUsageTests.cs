// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class ValueUsageTests
    {
        [Test]
        public void CanSetValuePropertyToInt()
        {
            ValueModel model = new ValueModel();
            model.Value = 1;

            Assert.IsTrue(1 == model.Value);

            // Requiring the cast for AreEqual is consistent with what we do in DynamicData
            Assert.AreEqual(1, (int)model.Value);
        }

        [Test]
        public void CanSetValuePropertyToLong()
        {
            ValueModel model = new ValueModel();
            model.Value = 1L;

            Assert.IsTrue(1L == model.Value);

            // Requiring the cast for AreEqual is consistent with what we do in DynamicData
            Assert.AreEqual(1L, (long)model.Value);
        }

        [Test]
        public void CanSetValuePropertyToNull()
        {
            ValueModel model = new ValueModel();

            // TODO: we will want a simpler API for this
            model.Value = new((object)null);

            Assert.IsNull((int?)model.Value);

            // TODO: This fails.  Also, I think we will want to do the equals without a cast
            Assert.IsTrue(null == (object)model.Value);

            // TODO: This fails currently, but it would be nice to get consistency with DynamicData
            Assert.IsNull(model.Value);
        }

        [Test]
        public void CanSetValuePropertyToString()
        {
            ValueModel model = new ValueModel();

            model.Value = "hi";

            Assert.IsTrue("hi" == model.Value);
            Assert.IsTrue(model.Value == "hi");

            Assert.AreEqual("hi", (string)model.Value);
        }

        [Test]
        public void CanSetValueAsIntAndGetAsLong()
        {
            // TODO: Do we want to do this, or no?
            ValueModel model = new ValueModel();

            model.Value = 1;

            // TODO: This fails
            // TODO: we will want to do the equals without a cast
            Assert.IsTrue(1L == model.Value);
            Assert.AreEqual(1L, (long)model.Value);
        }

        [Test]
        public void CanSetValuesInDictionaryToNull()
        {
            Dictionary<string, Value> d = new Dictionary<string, Value>();

            // TODO: address API
            d["a"] = new((object)null);

            Assert.IsNull((int?)d["a"]);

            Assert.IsTrue(null == (object)d["a"]);

            // TODO: should this work?
            Assert.IsTrue(null == (string)d["a"]);

            // TODO: This fails.  Should it work?
            Assert.IsNull((string)d["a"]);

            // TODO: if we accept null for Value, should we have an analyzer
            // to prevent nullable Value?, e.g. List<Value?>
        }

        // TODO: Questions
        //   - Can Value hold an array?
        //   - List of Value?
        //   - Dictionary of Value?
        //   - Cast value to Model type?  Cycles if Model has a Value?

        #region Helpers
        internal class ValueModel
        {
            public Value Value { get; set; }
        }
        #endregion
    }
}

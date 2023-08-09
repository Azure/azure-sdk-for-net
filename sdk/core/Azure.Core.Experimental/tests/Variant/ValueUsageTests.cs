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
            Assert.IsTrue(model.Value == 1);

            // Requiring the cast for AreEqual is consistent with what we do in DynamicData
            Assert.AreEqual(1, (int)model.Value);
        }

        [Test]
        public void CanSetValuePropertyToLong()
        {
            ValueModel model = new ValueModel();
            model.Value = 1L;

            Assert.IsTrue(1L == model.Value);
            Assert.IsTrue(model.Value == 1L);

            // Requiring the cast for AreEqual is consistent with what we do in DynamicData
            Assert.AreEqual(1L, (long)model.Value);
        }

        [Test]
        public void CanSetNullablePrimitives()
        {
            ValueModel model = new ValueModel();

            bool? b = true;

            // TODO: This tests whether we can assign a nullable boolean even without
            // a constructor that takes it explicitly.  What is lost by removing that constructor?

            // Ah, the answer is that it is boxed without the constructor, because it
            // uses the object constructor instead.
            model.Value = b;

            //model.Value = true;

            //Assert.IsNull((bool?)model.Value);

            Assert.IsTrue(model.Value == b);
            Assert.IsTrue(b == model.Value);
        }

        [Test]
        public void CanSetValuePropertyToNull()
        {
            ValueModel model = new ValueModel();

            // TODO: we will want a simpler API for this
            model.Value = new((object)null);

            // TODO: this results in an ambiguous call site, but I think
            // we can maybe address it by removing constructors that take
            // nullable primitives.  See CanSetNullablePrimitives() experiment.
            //
            // model.Value = new(null);

            // TODO: what would it take to achieve
            // model.Value = null?

            Assert.IsNull((int?)model.Value);

            // TODO: This fails.  Also, I think we will want to do the equals without a cast
            Assert.IsTrue(null == (object)model.Value);
            Assert.IsTrue((object)model.Value == null);

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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public void CanSetValuePropertyToString()
        {
            ValueModel model = new ValueModel();

            model.Value = "hi";

            Assert.IsTrue("hi" == model.Value);
            Assert.IsTrue(model.Value == "hi");

            Assert.AreEqual("hi", (string)model.Value);
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
            //
            // No, the answer is that we can't do it this way because then
            // Nullable primitives use the object constructor and are boxed.

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

        [Test]
        public void CanUseValueInPropertyBag()
        {
            PropertyBag bag = new();
            bag["foo"] = 5;
            bag["bar"] = 6;

            int x = bag["foo"] == 5 ? bag["bar"] : 0;

            Assert.AreEqual(6, x);
        }

        [Test]
        public void CanUseValueInPropertyBagDynamic()
        {
            //dynamic dj = BinaryData.FromString("""{"foo": "a"}""").ToDynamicFromJson();
            //dj.foo = 5;
            //int a = dj.foo;

            dynamic d = new PropertyBag();
            d.foo = 5;
            d.bar = 6;

            // Note: these both work now, with Value implementing IDynamicMetaObject provider.
            Value x = d.foo;
            int b = x;

            int y = d.foo;
            int z = d.bar;

            // TODO: this still fails because the DLR can't apply `==` to int and Value.
            //   Microsoft.CSharp.RuntimeBinder.RuntimeBinderException : Operator '==' cannot be applied to operands of type 'Azure.Value' and 'int'
            //   Idea: can we add an `==` operator?  We will hit ambiguous overloads if we enable nullability, but maybe we can box nullable primitives in this context.
            int w = d.foo == 5 ? d.bar : 0;
            Assert.AreEqual(6, w);
        }

        #region Helpers
        internal class ValueModel
        {
            public Value Value { get; set; }
        }
        #endregion
    }
}

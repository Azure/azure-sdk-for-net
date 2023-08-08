// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.GeoJson;
using Azure.Core.Serialization;
using Microsoft.CSharp.RuntimeBinder;
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

            // TODO: we will want to do the equals without a cast
            Assert.IsTrue(1 == (int)model.Value);

            // Requiring the cast for AreEqual is consistent with what we do in DynamicData
            Assert.AreEqual(1, (int)model.Value);
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

            // TODO: we will want a simpler API for this
            model.Value = new("hi");

            // TODO: This fails
            // TODO: Add cast to string
            Assert.AreEqual("hi", model.Value);
        }

        #region Helpers
        internal class ValueModel
        {
            public Value Value { get; set; }
        }
        #endregion
    }
}

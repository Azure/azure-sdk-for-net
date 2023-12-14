// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Reflection;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal class ModelReaderWriterOptionsTests
    {
        [Test]
        public void AllInstancesInMapShouldBeFrozen()
        {
            ValidateFrozenInstance(ModelReaderWriterOptions.Json, true);
            ValidateFrozenInstance(ModelReaderWriterOptions.Xml, true);
        }

        public void ValidateFrozenInstance(ModelReaderWriterOptions frozen, bool expected)
        {
            var field = frozen.GetType().GetField("_isFrozen", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            var value = field!.GetValue(frozen);
            Assert.IsNotNull(value);
            bool isFrozen = (bool)value!;
            Assert.AreEqual(expected, isFrozen);
        }

        [Test]
        public void NewInstanceShouldNotBeFrozen()
        {
            ModelReaderWriterOptions nonFrozen = new ModelReaderWriterOptions("J");
            ValidateFrozenInstance(nonFrozen, false);
        }
    }
}

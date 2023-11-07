// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    internal class ModelReaderWriterOptionsTests
    {
        [Test]
        public void ValidatePropertyIsFrozen() => ValidateFrozenInstance(ModelReaderWriterOptions.GetWireOptions());

        [Test]
        public void AllInstancesInMapShouldBeFrozen()
        {
            Dictionary<ModelReaderWriterFormat, ModelReaderWriterOptions>? optionsDictionary = typeof(ModelReaderWriterOptions)
                .GetField("_singletonMap", BindingFlags.NonPublic | BindingFlags.Static)
                ?.GetValue(null) as Dictionary<ModelReaderWriterFormat, ModelReaderWriterOptions>;
            Assert.IsNotNull(optionsDictionary);
            foreach (var frozen in optionsDictionary!.Values)
            {
                ValidateFrozenInstance(frozen);
            }
        }

        public void ValidateFrozenInstance(ModelReaderWriterOptions frozen)
        {
            //Assert.Throws<InvalidOperationException>(() => frozen.ObjectSerializerResolver = type => null);
        }

        [Test]
        public void NewInstanceShouldNotBeFrozen()
        {
            ModelReaderWriterOptions nonFrozen = ModelReaderWriterOptions.GetOptions();
            //Assert.DoesNotThrow(() => nonFrozen.ObjectSerializerResolver = type => null);
        }
    }
}

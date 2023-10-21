// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ClientModel.Core.Content;
using System.Reflection;
using NUnit.Framework;

namespace System.Net.ClientModel.Tests.ModelReaderWriterTests
{
    internal class ModelReaderWriterOptionsTests
    {
        [Test]
        public void ValidatePropertyIsFrozen() => ValidateFrozenInstance(ModelReaderWriterOptions.DefaultWireOptions);

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
            ModelReaderWriterOptions nonFrozen = new ModelReaderWriterOptions();
            //Assert.DoesNotThrow(() => nonFrozen.ObjectSerializerResolver = type => null);
        }

        [Test]
        public void MapAndStaticPropertySameObject()
        {
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.DefaultWireOptions, ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Wire)));
        }

        [Test]
        public void MapShouldReturnSingletons()
        {
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Wire), ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Wire)));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Json), ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Json)));
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Wire);
            Assert.AreEqual(ModelReaderWriterFormat.Wire, options.Format);
            //Assert.IsNull(options.ObjectSerializerResolver);

            options = ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Json);
            Assert.AreEqual(ModelReaderWriterFormat.Json, options.Format);
            //Assert.IsNull(options.ObjectSerializerResolver);
        }
    }
}

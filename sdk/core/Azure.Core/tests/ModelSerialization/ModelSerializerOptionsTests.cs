// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerialization
{
    internal class ModelSerializerOptionsTests
    {
        [Test]
        public void ValidatePropertyIsFrozen() => ValidateFrozenInstance(ModelSerializerOptions.DefaultWireOptions);

        [Test]
        public void AllInstancesInMapShouldBeFrozen()
        {
            Dictionary<ModelSerializerFormat, ModelSerializerOptions> optionsDictionary = typeof(ModelSerializerOptions)
                .GetField("_singletonMap", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null) as Dictionary<ModelSerializerFormat, ModelSerializerOptions>;
            foreach (var frozen in optionsDictionary.Values)
            {
                ValidateFrozenInstance(frozen);
            }
        }

        public void ValidateFrozenInstance(ModelSerializerOptions frozen)
        {
            Assert.Throws<InvalidOperationException>(() => frozen.ObjectSerializerResolver = type => null);
        }

        [Test]
        public void NewInstanceShouldNotBeFrozen()
        {
            ModelSerializerOptions nonFrozen = new ModelSerializerOptions();
            Assert.DoesNotThrow(() => nonFrozen.ObjectSerializerResolver = type => null);
        }

        [Test]
        public void MapAndStaticPropertySameObject()
        {
            Assert.IsTrue(ReferenceEquals(ModelSerializerOptions.DefaultWireOptions, ModelSerializerOptions.GetOptions(ModelSerializerFormat.Wire)));
        }

        [Test]
        public void MapShouldReturnSingletons()
        {
            Assert.IsTrue(ReferenceEquals(ModelSerializerOptions.GetOptions(ModelSerializerFormat.Wire), ModelSerializerOptions.GetOptions(ModelSerializerFormat.Wire)));
            Assert.IsTrue(ReferenceEquals(ModelSerializerOptions.GetOptions(ModelSerializerFormat.Json), ModelSerializerOptions.GetOptions(ModelSerializerFormat.Json)));
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = ModelSerializerOptions.GetOptions(ModelSerializerFormat.Wire);
            Assert.AreEqual(ModelSerializerFormat.Wire, options.Format);
            Assert.IsNull(options.ObjectSerializerResolver);

            options = ModelSerializerOptions.GetOptions(ModelSerializerFormat.Json);
            Assert.AreEqual(ModelSerializerFormat.Json, options.Format);
            Assert.IsNull(options.ObjectSerializerResolver);
        }
    }
}

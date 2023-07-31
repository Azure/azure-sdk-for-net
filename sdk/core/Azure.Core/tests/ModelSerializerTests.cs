// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class ModelSerializerTests
    {
        [Test]
        public void ValidateFrozenInstance()
        {
            ModelSerializerOptions frozen = ModelSerializerOptions.DefaultServiceOptions;
            ModelSerializerOptions nonFrozen = new ModelSerializerOptions();

            Assert.Throws<InvalidOperationException>(() => frozen.GenericTypeSerializerCreator = type => null);
            Assert.DoesNotThrow(() => nonFrozen.GenericTypeSerializerCreator = type => null);
        }
    }
}

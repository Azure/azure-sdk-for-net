// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace System.Net.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class ModelReaderWriterOptionsTests
    {
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

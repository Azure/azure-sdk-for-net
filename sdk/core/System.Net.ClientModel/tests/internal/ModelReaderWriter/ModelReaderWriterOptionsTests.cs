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
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.GetWireOptions(), ModelReaderWriterOptions.GetOptions("W")));
        }

        [Test]
        public void MapShouldReturnSingletons()
        {
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.GetOptions("W"), ModelReaderWriterOptions.GetOptions("W")));
            Assert.IsFalse(ReferenceEquals(ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Json), ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Json)));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.GetDataOptions(ModelReaderWriterFormat.Json), ModelReaderWriterOptions.GetDataOptions(ModelReaderWriterFormat.Json)));
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = ModelReaderWriterOptions.GetWireOptions();
            Assert.AreEqual("W", options.Format);
            //Assert.IsNull(options.ObjectSerializerResolver);

            options = ModelReaderWriterOptions.GetOptions(ModelReaderWriterFormat.Json);
            Assert.AreEqual(ModelReaderWriterFormat.Json.ToString(), options.Format);
            //Assert.IsNull(options.ObjectSerializerResolver);
        }
    }
}

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
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Wire, ModelReaderWriterOptions.Wire));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Json, ModelReaderWriterOptions.Json));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Xml, ModelReaderWriterOptions.Xml));
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = ModelReaderWriterOptions.Wire;
            Assert.AreEqual("W", options.Format);

            options = ModelReaderWriterOptions.Json;
            Assert.AreEqual("J", options.Format);
        }
    }
}

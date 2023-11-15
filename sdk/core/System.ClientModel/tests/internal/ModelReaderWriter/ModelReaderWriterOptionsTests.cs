// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Internal;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class ModelReaderWriterOptionsTests
    {
        [Test]
        public void MapAndStaticPropertySameObject()
        {
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterHelper.WireOptions, ModelReaderWriterHelper.WireOptions));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Json, ModelReaderWriterOptions.Json));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Xml, ModelReaderWriterOptions.Xml));
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = ModelReaderWriterHelper.WireOptions;
            Assert.AreEqual("W", options.Format);

            options = ModelReaderWriterOptions.Json;
            Assert.AreEqual("J", options.Format);
        }
    }
}

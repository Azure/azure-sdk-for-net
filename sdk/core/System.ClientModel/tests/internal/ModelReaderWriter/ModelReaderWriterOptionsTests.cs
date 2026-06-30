// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class ModelReaderWriterOptionsTests
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void MapAndStaticPropertySameObject()
        {
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Json, ModelReaderWriterOptions.Json));
            Assert.IsTrue(ReferenceEquals(ModelReaderWriterOptions.Xml, ModelReaderWriterOptions.Xml));
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = _wireOptions;
            Assert.AreEqual("W", options.Format);

            options = ModelReaderWriterOptions.Json;
            Assert.AreEqual("J", options.Format);
        }
    }
}

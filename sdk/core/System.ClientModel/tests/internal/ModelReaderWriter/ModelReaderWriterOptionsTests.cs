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
            Assert.That(ReferenceEquals(ModelReaderWriterOptions.Json, ModelReaderWriterOptions.Json), Is.True);
            Assert.That(ReferenceEquals(ModelReaderWriterOptions.Xml, ModelReaderWriterOptions.Xml), Is.True);
        }

        [Test]
        public void MapShouldHaveRightValues()
        {
            var options = _wireOptions;
            Assert.That(options.Format, Is.EqualTo("W"));

            options = ModelReaderWriterOptions.Json;
            Assert.That(options.Format, Is.EqualTo("J"));
        }
    }
}

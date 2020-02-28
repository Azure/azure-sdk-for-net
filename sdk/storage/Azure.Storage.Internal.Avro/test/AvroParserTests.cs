// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Internal.Avro;
using NUnit.Framework;

namespace Azure.Storage.Internal.Avro.Tests
{
    public class AvroParserTests
    {
        [Test]
        public void GetStarted()
        {
            Assert.AreEqual(42, AvroParser.Parse("Hello, World."));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaFormatTests
    {
        [Test]
        public void VerifyAvroFormat()
        {
            Assert.AreEqual("Avro", SchemaFormat.Avro.ToString());
        }
    }
}
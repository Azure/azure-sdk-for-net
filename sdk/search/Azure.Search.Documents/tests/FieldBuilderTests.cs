// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class FieldBuilderTests
    {
        [Test]
        public void BuildThrowsTypeNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => FieldBuilder.Build(null));
            Assert.AreEqual("type", ex.ParamName);
        }

        // TODO: Add more tests when FieldBuilder is implemented thoroughly.
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class DataTypeTests
    {
        [TestCase("Edm.String")]
        [TestCase("Collection(Edm.String)")]
        public void Collection(string value)
        {
            DataType type = DataType.Collection(value);
            Assert.AreEqual("Collection(Edm.String)", type.ToString());
        }

        [TestCase("Edm.String", false)]
        [TestCase("Collection(Edm.String)", true)]
        public void IsCollection(string value, bool expected)
        {
            DataType type = value;
            Assert.AreEqual(expected, type.IsCollection);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class DataTypeTests
    {
        [TestCase("Edm.String")]
        [TestCase("Collection(Edm.String)")]
        public void Collection(string value)
        {
            SearchFieldDataType type = SearchFieldDataType.Collection(value);
            Assert.AreEqual("Collection(Edm.String)", type.ToString());
        }

        [TestCase("Edm.String", false)]
        [TestCase("Collection(Edm.String)", true)]
        public void IsCollection(string value, bool expected)
        {
            SearchFieldDataType type = value;
            Assert.AreEqual(expected, type.IsCollection);
        }
    }
}

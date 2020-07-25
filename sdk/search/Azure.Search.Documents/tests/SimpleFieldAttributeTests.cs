// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SimpleFieldAttributeTests
    {
        [Test]
        [Parallelizable]
        public void CreatesEquivalentField(
            [EnumValues] SearchFieldDataType type,
            [Values] bool key,
            [Values] bool hidden,
            [Values] bool filterable,
            [Values] bool facetable,
            [Values] bool sortable)
        {
            SimpleFieldAttribute sut = new SimpleFieldAttribute
            {
                IsKey = key,
                IsHidden = hidden,
                IsFilterable = filterable,
                IsFacetable = facetable,
                IsSortable = sortable,
            };

            SearchField field = new SearchField("test", type);
            ((ISearchFieldAttribute)sut).SetField(field);

            Assert.AreEqual("test", field.Name);
            Assert.AreEqual(type, field.Type);
            Assert.AreEqual(key, field.IsKey ?? false);
            Assert.AreEqual(hidden, field.IsHidden ?? false);
            Assert.AreEqual(filterable, field.IsFilterable ?? false);
            Assert.AreEqual(facetable, field.IsFacetable ?? false);
            Assert.AreEqual(sortable, field.IsSortable ?? false);
        }
    }
}

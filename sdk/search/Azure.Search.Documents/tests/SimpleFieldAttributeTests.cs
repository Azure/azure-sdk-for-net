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
        public void CreatesEquivalentField(
            [EnumValues] SearchFieldDataType type,
            [Values] bool collection,
            [Values] bool key,
            [Values] bool hidden,
            [Values] bool filterable,
            [Values] bool facetable,
            [Values] bool sortable)
        {
            SimpleFieldAttribute sut = new SimpleFieldAttribute(type, collection)
            {
                IsKey = key,
                IsHidden = hidden,
                IsFilterable = filterable,
                IsFacetable = facetable,
                IsSortable = sortable,
            };

            SearchFieldDataType actualType = collection ? SearchFieldDataType.Collection(type) : type;
            Assert.AreEqual(actualType, sut.Type);

            SearchField field = ((ISearchFieldAttribute)sut).CreateField("test");
            Assert.AreEqual("test", field.Name);
            Assert.AreEqual(actualType, field.Type);
            Assert.AreEqual(key, field.IsKey);
            Assert.AreEqual(hidden, field.IsHidden);
            Assert.AreEqual(filterable, field.IsFilterable);
            Assert.AreEqual(facetable, field.IsFacetable);
            Assert.AreEqual(sortable, field.IsSortable);
        }
    }
}

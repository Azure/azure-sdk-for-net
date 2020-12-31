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

        [Test]
        [Parallelizable]
        public void IsSearchableNotOverwritten()
        {
            SearchField field = new SearchField("test", SearchFieldDataType.String);
            ISearchFieldAttribute attribute = new SearchableFieldAttribute
            {
                AnalyzerName = LexicalAnalyzerName.Values.EnLucene,
                IsFilterable = true,
                IsSortable = true,
            };

            attribute.SetField(field);

            Assert.AreEqual("test", field.Name);
            Assert.AreEqual(SearchFieldDataType.String, field.Type);
            Assert.IsFalse(field.IsFacetable);
            Assert.IsTrue(field.IsFilterable);
            Assert.IsFalse(field.IsHidden);
            Assert.IsFalse(field.IsKey);
            Assert.IsTrue(field.IsSearchable);
            Assert.IsTrue(field.IsSortable);
            Assert.AreEqual(LexicalAnalyzerName.EnLucene.ToString(), field.AnalyzerName?.ToString());
            Assert.IsNull(field.IndexAnalyzerName);
            Assert.IsNull(field.SearchAnalyzerName);
            Assert.IsEmpty(field.SynonymMapNames);

            // Make sure that if a SimpleFieldAttribute were also specified, it does not overwrite IsSearchable
            // but does overwrite every other SimpleField property not set otherwise.
            attribute = new SimpleFieldAttribute
            {
                IsKey = true,
            };

            attribute.SetField(field);

            Assert.AreEqual("test", field.Name);
            Assert.AreEqual(SearchFieldDataType.String, field.Type);
            Assert.IsFalse(field.IsFacetable);
            Assert.IsFalse(field.IsFilterable);
            Assert.IsFalse(field.IsHidden);
            Assert.IsTrue(field.IsKey);
            Assert.IsTrue(field.IsSearchable);
            Assert.IsFalse(field.IsSortable);
            Assert.AreEqual(LexicalAnalyzerName.EnLucene.ToString(), field.AnalyzerName?.ToString());
            Assert.IsNull(field.IndexAnalyzerName);
            Assert.IsNull(field.SearchAnalyzerName);
            Assert.IsEmpty(field.SynonymMapNames);
        }
    }
}

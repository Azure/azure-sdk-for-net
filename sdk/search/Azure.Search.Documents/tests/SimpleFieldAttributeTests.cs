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

            Assert.That(field.Name, Is.EqualTo("test"));
            Assert.That(field.Type, Is.EqualTo(type));
            Assert.That(field.IsKey ?? false, Is.EqualTo(key));
            Assert.That(field.IsHidden ?? false, Is.EqualTo(hidden));
            Assert.That(field.IsFilterable ?? false, Is.EqualTo(filterable));
            Assert.That(field.IsFacetable ?? false, Is.EqualTo(facetable));
            Assert.That(field.IsSortable ?? false, Is.EqualTo(sortable));
        }

        [Test]
        [Parallelizable]
        public void IsSearchableNotOverwritten()
        {
            SearchField field = new SearchField("test", SearchFieldDataType.String);
            ISearchFieldAttribute attribute = new SearchableFieldAttribute
            {
                AnalyzerName = LexicalAnalyzerName.Values.EnLucene,
                NormalizerName = LexicalNormalizerName.Values.Lowercase,
                IsFilterable = true,
                IsSortable = true,
            };

            attribute.SetField(field);

            Assert.That(field.Name, Is.EqualTo("test"));
            Assert.That(field.Type, Is.EqualTo(SearchFieldDataType.String));
            Assert.That(field.IsFacetable, Is.False);
            Assert.That(field.IsFilterable, Is.True);
            Assert.That(field.IsHidden, Is.False);
            Assert.That(field.IsKey, Is.False);
            Assert.That(field.IsSearchable, Is.True);
            Assert.That(field.IsSortable, Is.True);
            Assert.That(field.AnalyzerName?.ToString(), Is.EqualTo(LexicalAnalyzerName.EnLucene.ToString()));
            Assert.IsNull(field.IndexAnalyzerName);
            Assert.IsNull(field.SearchAnalyzerName);
            Assert.That(field.NormalizerName?.ToString(), Is.EqualTo(LexicalNormalizerName.Lowercase.ToString()));
            Assert.IsEmpty(field.SynonymMapNames);

            // Make sure that if a SimpleFieldAttribute were also specified, it does not overwrite IsSearchable
            // but does overwrite every other SimpleField property not set otherwise.
            attribute = new SimpleFieldAttribute
            {
                IsKey = true,
            };

            attribute.SetField(field);

            Assert.That(field.Name, Is.EqualTo("test"));
            Assert.That(field.Type, Is.EqualTo(SearchFieldDataType.String));
            Assert.That(field.IsFacetable, Is.False);
            Assert.That(field.IsFilterable, Is.False);
            Assert.That(field.IsHidden, Is.False);
            Assert.That(field.IsKey, Is.True);
            Assert.That(field.IsSearchable, Is.True);
            Assert.That(field.IsSortable, Is.False);
            Assert.That(field.AnalyzerName?.ToString(), Is.EqualTo(LexicalAnalyzerName.EnLucene.ToString()));
            Assert.IsNull(field.IndexAnalyzerName);
            Assert.IsNull(field.SearchAnalyzerName);
            Assert.That(field.NormalizerName?.ToString(), Is.EqualTo(LexicalNormalizerName.Lowercase.ToString()));
            Assert.IsEmpty(field.SynonymMapNames);
        }
    }
}

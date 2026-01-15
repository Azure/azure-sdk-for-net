// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchableFieldAttributeTests
    {
        [Test]
        [Parallelizable]
        public void CreatesEquivalentField(
            [Values] bool key,
            [Values] bool hidden,
            [Values] bool filterable,
            [Values] bool facetable,
            [Values] bool sortable,
            [Values(null, "AnalyzerName")] string analyzerName,
            [Values(null, "SearchAnalyzerName")] string searchAnalyzerName,
            [Values(null, "IndexAnalyzerName")] string indexAnalyzerName,
            [Values(null, "NormalizerName")] string normalizerName,
            [Values(null, new[] { "synonynMapName" })] string[] synonymMapNames)
        {
            SearchableFieldAttribute sut = new SearchableFieldAttribute
            {
                IsKey = key,
                IsHidden = hidden,
                IsFilterable = filterable,
                IsFacetable = facetable,
                IsSortable = sortable,
            };

            if (analyzerName != null)
            {
                sut.AnalyzerName = analyzerName;
            }

            if (searchAnalyzerName != null)
            {
                sut.SearchAnalyzerName = searchAnalyzerName;
            }

            if (indexAnalyzerName != null)
            {
                sut.IndexAnalyzerName = indexAnalyzerName;
            }

            if (normalizerName != null)
            {
                sut.NormalizerName = normalizerName;
            }

            if (synonymMapNames != null)
            {
                sut.SynonymMapNames = synonymMapNames;
            }

            SearchField field = new SearchField("test", SearchFieldDataType.String);
            ((ISearchFieldAttribute)sut).SetField(field);

            Assert.That(field.Name, Is.EqualTo("test"));
            Assert.That(field.Type, Is.EqualTo(SearchFieldDataType.String));
            Assert.That(field.IsKey ?? false, Is.EqualTo(key));
            Assert.That(field.IsHidden ?? false, Is.EqualTo(hidden));
            Assert.That(field.IsFilterable ?? false, Is.EqualTo(filterable));
            Assert.That(field.IsFacetable ?? false, Is.EqualTo(facetable));
            Assert.That(field.IsSearchable, Is.True);
            Assert.That(field.IsSortable ?? false, Is.EqualTo(sortable));
            Assert.That(field.AnalyzerName?.ToString(), Is.EqualTo(analyzerName));
            Assert.That(field.SearchAnalyzerName?.ToString(), Is.EqualTo(searchAnalyzerName));
            Assert.That(field.IndexAnalyzerName?.ToString(), Is.EqualTo(indexAnalyzerName));
            Assert.That(field.NormalizerName?.ToString(), Is.EqualTo(normalizerName));
            Assert.That(field.SynonymMapNames, Is.EqualTo(synonymMapNames ?? Array.Empty<string>()));
        }
    }
}

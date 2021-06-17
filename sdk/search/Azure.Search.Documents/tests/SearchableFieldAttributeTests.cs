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

            if (synonymMapNames != null)
            {
                sut.SynonymMapNames = synonymMapNames;
            }

            SearchField field = new SearchField("test", SearchFieldDataType.String);
            ((ISearchFieldAttribute)sut).SetField(field);

            Assert.AreEqual("test", field.Name);
            Assert.AreEqual(SearchFieldDataType.String, field.Type);
            Assert.AreEqual(key, field.IsKey ?? false);
            Assert.AreEqual(hidden, field.IsHidden ?? false);
            Assert.AreEqual(filterable, field.IsFilterable ?? false);
            Assert.AreEqual(facetable, field.IsFacetable ?? false);
            Assert.IsTrue(field.IsSearchable);
            Assert.AreEqual(sortable, field.IsSortable ?? false);
            Assert.AreEqual(analyzerName, field.AnalyzerName?.ToString());
            Assert.AreEqual(searchAnalyzerName, field.SearchAnalyzerName?.ToString());
            Assert.AreEqual(indexAnalyzerName, field.IndexAnalyzerName?.ToString());
            Assert.AreEqual(synonymMapNames ?? Array.Empty<string>(), field.SynonymMapNames);
        }
    }
}

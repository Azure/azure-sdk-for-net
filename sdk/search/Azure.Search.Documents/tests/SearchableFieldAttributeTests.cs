// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchableFieldAttributeTests
    {
        [Test]
        public void CreatesEquivalentField(
            [Values] bool collection,
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
            SearchableFieldAttribute sut = new SearchableFieldAttribute(collection)
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

            SearchFieldDataType actualType = collection ? SearchFieldDataType.Collection(SearchFieldDataType.String) : SearchFieldDataType.String;
            Assert.AreEqual(actualType, sut.Type);

            SearchField field = ((ISearchFieldAttribute)sut).CreateField("test");
            Assert.AreEqual("test", field.Name);
            Assert.AreEqual(actualType, field.Type);
            Assert.AreEqual(key, field.IsKey);
            Assert.AreEqual(hidden, field.IsHidden);
            Assert.AreEqual(filterable, field.IsFilterable);
            Assert.AreEqual(facetable, field.IsFacetable);
            Assert.AreEqual(sortable, field.IsSortable);
            Assert.AreEqual(analyzerName, field.AnalyzerName?.ToString());
            Assert.AreEqual(searchAnalyzerName, field.SearchAnalyzerName?.ToString());
            Assert.AreEqual(indexAnalyzerName, field.IndexAnalyzerName?.ToString());
            Assert.AreEqual(synonymMapNames ?? Enumerable.Empty<string>(), field.SynonymMapNames);
        }
    }
}

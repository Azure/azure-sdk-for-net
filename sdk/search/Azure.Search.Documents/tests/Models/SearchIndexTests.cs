// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SearchIndexTests
    {
        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SearchIndex sut = new SearchIndex(
                name: null,
                description: null,
                new SearchField[0],
                scoringProfiles: null,
                defaultScoringProfile: null,
                corsOptions: null,
                suggesters: null,
                analyzers: null,
                tokenizers: null,
                tokenFilters: null,
                charFilters: null,
                normalizers: null,
                encryptionKey: null,
                similarity: null,
                semanticSearch: null,
                vectorSearch: null,
                permissionFilterOption: null,
                purviewEnabled: null,
                etag: value,
                serializedAdditionalRawData: null);
            Assert.AreEqual(expected, sut.ETag?.ToString());
        }

        [Test]
        public void SettingFieldsNullThrows()
        {
            SearchIndex sut = new SearchIndex("test");

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => sut.Fields = null);
            Assert.AreEqual("value", ex.ParamName);
        }

        [Test]
        public void SettingFieldsOverwrites()
        {
            SearchIndex sut = new SearchIndex("test", new SearchField[]
            {
                new SimpleField("a", SearchFieldDataType.String) { IsKey = true },
                new SearchableField("b") { IsSortable = true },
            });

            SearchField[] fields = new SearchField[]
            {
                new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
                new SearchableField("name") { IsSortable = true },
            };

            sut.Fields = fields;

            Assert.That(sut.Fields, Is.EqualTo(fields).Using(SearchFieldComparer.SharedFieldsCollection));
        }
    }
}

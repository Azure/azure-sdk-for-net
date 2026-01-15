// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SynonymMapTests
    {
        [Test]
        public void StringConstructorTests()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap(null, (string)null));
            Assert.That(ex.ParamName, Is.EqualTo("name"));

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap(string.Empty, (string)null));
            Assert.That(ex.ParamName, Is.EqualTo("name"));

            ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap("test", (string)null));
            Assert.That(ex.ParamName, Is.EqualTo("synonyms"));

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap("test", string.Empty));
            Assert.That(ex.ParamName, Is.EqualTo("synonyms"));
        }

        [Test]
        public void TextReaderConstructorTests()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap(null, (TextReader)null));
            Assert.That(ex.ParamName, Is.EqualTo("name"));

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap(string.Empty, (TextReader)null));
            Assert.That(ex.ParamName, Is.EqualTo("name"));

            ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap("test", (TextReader)null));
            Assert.That(ex.ParamName, Is.EqualTo("reader"));
        }

        [Test]
        public void SynonymsFromTextReader()
        {
            using StringReader reader = new StringReader("ms,msft=>Microsoft\naz=>Azure");

            SynonymMap map = new SynonymMap("test", reader);
            Assert.That(map.Synonyms, Is.EqualTo("ms,msft=>Microsoft\naz=>Azure"));
        }

        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SynonymMap sut = new SynonymMap(null, null, null, null, value, serializedAdditionalRawData: null);
            Assert.That(sut.ETag?.ToString(), Is.EqualTo(expected));
        }
    }
}

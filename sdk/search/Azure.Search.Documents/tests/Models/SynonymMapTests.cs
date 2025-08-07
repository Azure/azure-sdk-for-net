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
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap(string.Empty, (string)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap("test", (string)null));
            Assert.AreEqual("synonyms", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap("test", string.Empty));
            Assert.AreEqual("synonyms", ex.ParamName);
        }

        [Test]
        public void TextReaderConstructorTests()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap(null, (TextReader)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap(string.Empty, (TextReader)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap("test", (TextReader)null));
            Assert.AreEqual("reader", ex.ParamName);
        }

        [Test]
        public void SynonymsFromTextReader()
        {
            using StringReader reader = new StringReader("ms,msft=>Microsoft\naz=>Azure");

            SynonymMap map = new SynonymMap("test", reader);
            Assert.AreEqual("ms,msft=>Microsoft\naz=>Azure", map.Synonyms);
        }

        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SynonymMap sut = new SynonymMap(null, null, null, null, value, serializedAdditionalRawData: null);
            Assert.AreEqual(expected, sut.ETag?.ToString());
        }
    }
}

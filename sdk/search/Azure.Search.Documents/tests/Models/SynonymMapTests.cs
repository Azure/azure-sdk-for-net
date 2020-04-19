// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Search.Documents.Models;
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

        [Test]
        public void CanonicalizesNullPropertyNames()
        {
            Assert.IsNull(SynonymMap.CanonicalizePropertyNames(null));
        }

        [Test]
        public void CanonicalizesPropertyNames()
        {
            IEnumerable<string> actual = SynonymMap.CanonicalizePropertyNames(new[]
            {
                nameof(SynonymMap.Name),
                nameof(SynonymMap.Format),
                nameof(SynonymMap.Synonyms),
                nameof(SynonymMap.EncryptionKey),
                nameof(SynonymMap.ETag),
                "Other",
            });

            IEnumerable<string> expected = new[]
            {
                "name",
                "format",
                "synonyms",
                "encryptionKey",
                "@odata.etag",
                "Other",
            };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

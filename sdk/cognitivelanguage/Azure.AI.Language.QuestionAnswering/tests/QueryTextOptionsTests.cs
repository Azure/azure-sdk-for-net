// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.Language.QuestionAnswering.Models;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QueryTextOptionsTests
    {
        [Test]
        public void FromStringRecordsQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => QueryTextOptions.From(null, Array.Empty<string>(), null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void FromStringRecordsRecordsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => QueryTextOptions.From("question", (IEnumerable<string>)null, null));
            Assert.AreEqual("records", ex.ParamName);
        }

        [Test]
        public void FromStringRecordsAutomaticIds()
        {
            QueryTextOptions options = QueryTextOptions.From("question", new[] { "a", "b", "c" }, null);
            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.Records.Count);
            Assert.AreEqual("1", options.Records[0].Id);
            Assert.AreEqual("a", options.Records[0].Text);
            Assert.AreEqual("2", options.Records[1].Id);
            Assert.AreEqual("b", options.Records[1].Text);
            Assert.AreEqual("3", options.Records[2].Id);
            Assert.AreEqual("c", options.Records[2].Text);
        }

        [Test]
        public void FromTextRecordsQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => QueryTextOptions.From(null, (IEnumerable<TextRecord>)null, null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void FromTextRecordsRecordsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => QueryTextOptions.From("question", (IEnumerable<TextRecord>)null, null));
            Assert.AreEqual("records", ex.ParamName);
        }

        [Test]
        public void FromTextRecordsAutomaticIds()
        {
            IEnumerable<TextRecord> records = new[]
            {
                new TextRecord("1", "a"),
                new TextRecord("2", "b"),
                new TextRecord("3", "c"),
            };

            QueryTextOptions options = QueryTextOptions.From("question", records, null);
            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.Records.Count);
            Assert.AreEqual("1", options.Records[0].Id);
            Assert.AreEqual("a", options.Records[0].Text);
            Assert.AreEqual("2", options.Records[1].Id);
            Assert.AreEqual("b", options.Records[1].Text);
            Assert.AreEqual("3", options.Records[2].Id);
            Assert.AreEqual("c", options.Records[2].Text);
        }

        [Test]
        public void StringIndexTypeAlwaysUtf16CodeUnit()
        {
            IEnumerable<TextRecord> records = new[]
            {
                new TextRecord("1", "a"),
                new TextRecord("2", "b"),
                new TextRecord("3", "c"),
            };

            QueryTextOptions options = new("question", records);

            Assert.AreEqual(StringIndexType.Utf16CodeUnit, options.StringIndexType);
        }

        [Test]
        public void ClonesSetLanguage()
        {
            IEnumerable<TextRecord> records = new[]
            {
                new TextRecord("1", "a"),
                new TextRecord("2", "b"),
                new TextRecord("3", "c"),
            };

            QueryTextOptions options = new("question", records)
            {
                Language = "en",
            };

            options = options.Clone("de");

            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.Records.Count);
            Assert.AreEqual("1", options.Records[0].Id);
            Assert.AreEqual("a", options.Records[0].Text);
            Assert.AreEqual("2", options.Records[1].Id);
            Assert.AreEqual("b", options.Records[1].Text);
            Assert.AreEqual("3", options.Records[2].Id);
            Assert.AreEqual("c", options.Records[2].Text);
            Assert.AreEqual("en", options.Language);
        }

        [Test]
        public void ClonesWithDefaultLanguage()
        {
            IEnumerable<TextRecord> records = new[]
            {
                new TextRecord("1", "a"),
                new TextRecord("2", "b"),
                new TextRecord("3", "c"),
            };

            QueryTextOptions options = new("question", records);
            options = options.Clone("de");

            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.Records.Count);
            Assert.AreEqual("1", options.Records[0].Id);
            Assert.AreEqual("a", options.Records[0].Text);
            Assert.AreEqual("2", options.Records[1].Id);
            Assert.AreEqual("b", options.Records[1].Text);
            Assert.AreEqual("3", options.Records[2].Id);
            Assert.AreEqual("c", options.Records[2].Text);
            Assert.AreEqual("de", options.Language);
        }
    }
}

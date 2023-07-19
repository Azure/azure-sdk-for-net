// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class AnswersFromTextOptionsTests
    {
        [Test]
        public void FromStringTextDocumentsQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From(null, Array.Empty<string>(), null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void FromStringTextDocumentsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From("question", (string[])null, null));
            Assert.AreEqual("textDocuments", ex.ParamName);
        }

        [Test]
        public void FromStringTextDocumentsAutomaticIds()
        {
            AnswersFromTextOptions options = AnswersFromTextOptions.From("question", new[] { "a", "b", "c" }, null);
            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.TextDocuments.Count);
            Assert.AreEqual("1", options.TextDocuments[0].Id);
            Assert.AreEqual("a", options.TextDocuments[0].Text);
            Assert.AreEqual("2", options.TextDocuments[1].Id);
            Assert.AreEqual("b", options.TextDocuments[1].Text);
            Assert.AreEqual("3", options.TextDocuments[2].Id);
            Assert.AreEqual("c", options.TextDocuments[2].Text);
        }

        [Test]
        public void FromTextDocumentsQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From(null, (TextDocument[])null, null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void FromTextDocumentsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From("question", (TextDocument[])null, null));
            Assert.AreEqual("textDocuments", ex.ParamName);
        }

        [Test]
        public void FromTextDocumentsAutomaticIds()
        {
            IEnumerable<TextDocument> textDocuments = new[]
            {
                new TextDocument("1", "a"),
                new TextDocument("2", "b"),
                new TextDocument("3", "c"),
            };

            AnswersFromTextOptions options = AnswersFromTextOptions.From("question", textDocuments, null);
            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.TextDocuments.Count);
            Assert.AreEqual("1", options.TextDocuments[0].Id);
            Assert.AreEqual("a", options.TextDocuments[0].Text);
            Assert.AreEqual("2", options.TextDocuments[1].Id);
            Assert.AreEqual("b", options.TextDocuments[1].Text);
            Assert.AreEqual("3", options.TextDocuments[2].Id);
            Assert.AreEqual("c", options.TextDocuments[2].Text);
        }

        [Test]
        public void StringIndexTypeAlwaysUtf16CodeUnit()
        {
            IEnumerable<TextDocument> textDocuments = new[]
            {
                new TextDocument("1", "a"),
                new TextDocument("2", "b"),
                new TextDocument("3", "c"),
            };

            AnswersFromTextOptions options = new("question", textDocuments);

            Assert.AreEqual(StringIndexType.Utf16CodeUnit, options.StringIndexType);
        }

        [Test]
        public void ClonesSetLanguage()
        {
            IEnumerable<TextDocument> textDocuments = new[]
            {
                new TextDocument("1", "a"),
                new TextDocument("2", "b"),
                new TextDocument("3", "c"),
            };

            AnswersFromTextOptions options = new("question", textDocuments)
            {
                Language = "en",
            };

            options = options.Clone("de");

            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.TextDocuments.Count);
            Assert.AreEqual("1", options.TextDocuments[0].Id);
            Assert.AreEqual("a", options.TextDocuments[0].Text);
            Assert.AreEqual("2", options.TextDocuments[1].Id);
            Assert.AreEqual("b", options.TextDocuments[1].Text);
            Assert.AreEqual("3", options.TextDocuments[2].Id);
            Assert.AreEqual("c", options.TextDocuments[2].Text);
            Assert.AreEqual("en", options.Language);
        }

        [Test]
        public void ClonesWithDefaultLanguage()
        {
            IEnumerable<TextDocument> textDocuments = new[]
            {
                new TextDocument("1", "a"),
                new TextDocument("2", "b"),
                new TextDocument("3", "c"),
            };

            AnswersFromTextOptions options = new("question", textDocuments);
            options = options.Clone("de");

            Assert.AreEqual("question", options.Question);
            Assert.AreEqual(3, options.TextDocuments.Count);
            Assert.AreEqual("1", options.TextDocuments[0].Id);
            Assert.AreEqual("a", options.TextDocuments[0].Text);
            Assert.AreEqual("2", options.TextDocuments[1].Id);
            Assert.AreEqual("b", options.TextDocuments[1].Text);
            Assert.AreEqual("3", options.TextDocuments[2].Id);
            Assert.AreEqual("c", options.TextDocuments[2].Text);
            Assert.AreEqual("de", options.Language);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Inference.Tests
{
    public class AnswersFromTextOptionsTests
    {
        [Test]
        public void FromStringTextDocumentsQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From(null, Array.Empty<string>(), null));
            Assert.That(ex.ParamName, Is.EqualTo("question"));
        }

        [Test]
        public void FromStringTextDocumentsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From("question", (string[])null, null));
            Assert.That(ex.ParamName, Is.EqualTo("textDocuments"));
        }

        [Test]
        public void FromStringTextDocumentsAutomaticIds()
        {
            AnswersFromTextOptions options = AnswersFromTextOptions.From("question", new[] { "a", "b", "c" }, null);
            Assert.Multiple(() =>
            {
                Assert.That(options.Question, Is.EqualTo("question"));
                Assert.That(options.TextDocuments, Has.Count.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(options.TextDocuments[0].Id, Is.EqualTo("1"));
                Assert.That(options.TextDocuments[0].Text, Is.EqualTo("a"));
                Assert.That(options.TextDocuments[1].Id, Is.EqualTo("2"));
                Assert.That(options.TextDocuments[1].Text, Is.EqualTo("b"));
                Assert.That(options.TextDocuments[2].Id, Is.EqualTo("3"));
                Assert.That(options.TextDocuments[2].Text, Is.EqualTo("c"));
            });
        }

        [Test]
        public void FromTextDocumentsQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From(null, (TextDocument[])null, null));
            Assert.That(ex.ParamName, Is.EqualTo("question"));
        }

        [Test]
        public void FromTextDocumentsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => AnswersFromTextOptions.From("question", (TextDocument[])null, null));
            Assert.That(ex.ParamName, Is.EqualTo("textDocuments"));
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
            Assert.Multiple(() =>
            {
                Assert.That(options.Question, Is.EqualTo("question"));
                Assert.That(options.TextDocuments, Has.Count.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(options.TextDocuments[0].Id, Is.EqualTo("1"));
                Assert.That(options.TextDocuments[0].Text, Is.EqualTo("a"));
                Assert.That(options.TextDocuments[1].Id, Is.EqualTo("2"));
                Assert.That(options.TextDocuments[1].Text, Is.EqualTo("b"));
                Assert.That(options.TextDocuments[2].Id, Is.EqualTo("3"));
                Assert.That(options.TextDocuments[2].Text, Is.EqualTo("c"));
            });
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

            Assert.That(options.StringIndexType, Is.EqualTo(StringIndexType.Utf16CodeUnit));
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

            Assert.Multiple(() =>
            {
                Assert.That(options.Question, Is.EqualTo("question"));
                Assert.That(options.TextDocuments, Has.Count.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(options.TextDocuments[0].Id, Is.EqualTo("1"));
                Assert.That(options.TextDocuments[0].Text, Is.EqualTo("a"));
                Assert.That(options.TextDocuments[1].Id, Is.EqualTo("2"));
                Assert.That(options.TextDocuments[1].Text, Is.EqualTo("b"));
                Assert.That(options.TextDocuments[2].Id, Is.EqualTo("3"));
                Assert.That(options.TextDocuments[2].Text, Is.EqualTo("c"));
                Assert.That(options.Language, Is.EqualTo("en"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(options.Question, Is.EqualTo("question"));
                Assert.That(options.TextDocuments, Has.Count.EqualTo(3));
            });
            Assert.Multiple(() =>
            {
                Assert.That(options.TextDocuments[0].Id, Is.EqualTo("1"));
                Assert.That(options.TextDocuments[0].Text, Is.EqualTo("a"));
                Assert.That(options.TextDocuments[1].Id, Is.EqualTo("2"));
                Assert.That(options.TextDocuments[1].Text, Is.EqualTo("b"));
                Assert.That(options.TextDocuments[2].Id, Is.EqualTo("3"));
                Assert.That(options.TextDocuments[2].Text, Is.EqualTo("c"));
                Assert.That(options.Language, Is.EqualTo("de"));
            });
        }
    }
}

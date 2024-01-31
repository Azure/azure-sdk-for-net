// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringClientTests
    {
        public Uri Endpoint => new("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

        public QuestionAnsweringClient Client => new(Endpoint, new AzureKeyCredential("test"));

        [Test]
        public void QuestionAnswerClientEndpointNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(null, (AzureKeyCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringClientCredentialNull()
        {
            Uri endpoint = new Uri("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(endpoint, (AzureKeyCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(null, (TokenCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(endpoint, (TokenCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void GetAnswersQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswers(null, null));
            Assert.AreEqual("question", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersAsync(null, null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void GetAnswersQuestionEmpty()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => Client.GetAnswers(string.Empty, null));
            Assert.AreEqual("question", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(async () => await Client.GetAnswersAsync(string.Empty, null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void GetAnswersProjectNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswers("question", null));
            Assert.AreEqual("project", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswers(1, null));
            Assert.AreEqual("project", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersAsync("question", null));
            Assert.AreEqual("project", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersAsync(1, null));
            Assert.AreEqual("project", ex.ParamName);
        }

        [Test]
        public void GetAnswersFromTextQuestionNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswersFromText(null, (string[])null));
            Assert.AreEqual("question", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersFromTextAsync(null, (string[])null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void GetAnswersFromTextQuestionEmpty()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => Client.GetAnswersFromText(string.Empty, (string[])null));
            Assert.AreEqual("question", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(async () => await Client.GetAnswersFromTextAsync(string.Empty, (string[])null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void GetAnswersFromTextTextDocumentsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswersFromText("question", (string[])null));
            Assert.AreEqual("textDocuments", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswersFromText("question", (TextDocument[])null));
            Assert.AreEqual("textDocuments", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersFromTextAsync("question", (string[])null));
            Assert.AreEqual("textDocuments", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersFromTextAsync("question", (TextDocument[])null));
            Assert.AreEqual("textDocuments", ex.ParamName);
        }

        [Test]
        public void GetAnswersFromTextOptionsNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => Client.GetAnswersFromText(null));
            Assert.AreEqual("options", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetAnswersFromTextAsync(null));
            Assert.AreEqual("options", ex.ParamName);
        }
    }
}

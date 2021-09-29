// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(null, null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void QuestionAnsweringClientCredentialNull()
        {
            Uri endpoint = new Uri("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new QuestionAnsweringClient(endpoint, null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void QueryKnowledgeBaseProjectNameNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Client.QueryKnowledgeBase(null, null, null));
            Assert.AreEqual("projectName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.QueryKnowledgeBaseAsync(null, null, null));
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void QueryKnowledgeBaseDeploymentNameNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Client.QueryKnowledgeBase("projectName", null, null));
            Assert.AreEqual("deploymentName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.QueryKnowledgeBaseAsync("projectName", null, null));
            Assert.AreEqual("deploymentName", ex.ParamName);
        }

        [Test]
        public void QueryKnowledgeBaseQuestionNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Client.QueryKnowledgeBase("projectName", "deploymentName", null));
            Assert.AreEqual("question", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.QueryKnowledgeBaseAsync("projectName", "deploymentName", null));
            Assert.AreEqual("question", ex.ParamName);
        }

        [Test]
        public void QueryKnowledgeBaseOptionsNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Client.QueryKnowledgeBase(null));
            Assert.AreEqual("options", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.QueryKnowledgeBaseAsync(null));
            Assert.AreEqual("options", ex.ParamName);
        }

        [Test]
        public void QueryTextOptionsNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Client.QueryText(null));
            Assert.AreEqual("options", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.QueryTextAsync(null));
            Assert.AreEqual("options", ex.ParamName);
        }
    }
}

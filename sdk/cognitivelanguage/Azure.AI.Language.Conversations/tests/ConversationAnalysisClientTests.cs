// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientTests
    {
        public Uri Endpoint => new("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

        public ConversationAnalysisClient Client => new(Endpoint, new AzureKeyCredential("test"));

        [Test]
        public void ConversationAnalysisClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(null, null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void ConversationAnalysisClientCredentialNull()
        {
            Uri endpoint = new Uri("https://test.api.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new ConversationAnalysisClient(endpoint, null));
            Assert.AreEqual("credential", ex.ParamName);
        }
        [Test]
        public void ValidateConversationsProject()
        {
            // Validate query parameter first given the order the constructors get called.
            Assert.That<ConversationsProject>(() => new ConversationsProject(null, "test"), Throws.ArgumentNullException.WithParamName("projectName"));
            Assert.That<ConversationsProject>(() => new ConversationsProject("test", null), Throws.ArgumentNullException.WithParamName("deploymentName"));
        }

        [Test]
        public void ValidateAnalyzeConversation()
        {
            ConversationsProject conversationsProject = new ConversationsProject("project","deployment");

            // Validate query parameter first given the order the constructors get called.
            Assert.That<Response<AnalyzeConversationResult>>(() => Client.AnalyzeConversation(null, conversationsProject), Throws.ArgumentNullException.WithParamName("query"));
            Assert.That<Task<Response<AnalyzeConversationResult>>>(async () => await Client.AnalyzeConversationAsync(null, conversationsProject), Throws.ArgumentNullException.WithParamName("query"));

            Assert.That<Response<AnalyzeConversationResult>>(() => Client.AnalyzeConversation("test", null), Throws.ArgumentNullException.WithParamName("conversationsProject"));
            Assert.That<Task<Response<AnalyzeConversationResult>>>(async () => await Client.AnalyzeConversationAsync("test", null), Throws.ArgumentNullException.WithParamName("conversationsProject"));

            Assert.That<Response<AnalyzeConversationResult>>(() => Client.AnalyzeConversation(null, new AnalyzeConversationOptions("test")), Throws.ArgumentNullException.WithParamName("conversationsProject"));
            Assert.That<Task<Response<AnalyzeConversationResult>>>(async () => await Client.AnalyzeConversationAsync(null, new AnalyzeConversationOptions("test")), Throws.ArgumentNullException.WithParamName("conversationsProject"));

            Assert.That<Response<AnalyzeConversationResult>>(() => Client.AnalyzeConversation(conversationsProject, null), Throws.ArgumentNullException.WithParamName("options"));
            Assert.That<Task<Response<AnalyzeConversationResult>>>(async () => await Client.AnalyzeConversationAsync(conversationsProject, null), Throws.ArgumentNullException.WithParamName("options"));
        }
    }
}

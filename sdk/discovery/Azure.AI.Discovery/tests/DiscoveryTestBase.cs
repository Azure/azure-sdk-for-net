// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Base class for Azure.AI.Discovery recorded/live tests. A single test class
    /// written against the async API is executed in both sync and async modes via
    /// <see cref="ClientTestBase"/> instrumentation (the <c>isAsync</c> flag).
    /// </summary>
    public abstract class DiscoveryTestBase : RecordedTestBase<DiscoveryTestEnvironment>
    {
        protected DiscoveryTestBase(bool isAsync) : base(isAsync)
        {
            // The service returns a placeholder Location header (https://example.com)
            // for LROs; drop it so the poller falls back to operation-location.
            SanitizedHeaders.Add("Location");

            // Never record the real subscription / ARM resource ids that appear in a
            // KnowledgeBase's storageAssetReferences (both request and response bodies).
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..storageAssetReferences[*].id") { Value = "Sanitized" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..storageAssetReferences[*].userAssignedIdentity") { Value = "Sanitized" });

            // Replace the real workspace/bookshelf endpoint hostnames with the shared
            // placeholders (request URIs, LRO operation-location headers, and the
            // bookshelfName body field, which mirrors the bookshelf host subdomain).
            const string WorkspaceHost = "https://test-wkspc.workspace.discovery.azure.com";
            const string BookshelfHost = "https://test-bkshlf.bookshelf.discovery.azure.com";
            UriRegexSanitizers.Add(new UriRegexSanitizer("https://[^/.]+\\.workspace\\.discovery\\.azure\\.com") { Value = WorkspaceHost });
            UriRegexSanitizers.Add(new UriRegexSanitizer("https://[^/.]+\\.bookshelf\\.discovery\\.azure\\.com") { Value = BookshelfHost });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("operation-location") { Regex = "https://[^/.]+\\.workspace\\.discovery\\.azure\\.com", Value = WorkspaceHost });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("operation-location") { Regex = "https://[^/.]+\\.bookshelf\\.discovery\\.azure\\.com", Value = BookshelfHost });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..bookshelfName") { Value = "test-bkshlf" });
        }

        protected WorkspaceClient CreateWorkspaceClient()
        {
            WorkspaceClientOptions options = InstrumentClientOptions(new WorkspaceClientOptions());
            var client = new WorkspaceClient(new Uri(TestEnvironment.WorkspaceEndpoint), TestEnvironment.Credential, options);
            return InstrumentClient(client);
        }

        protected BookshelfClient CreateBookshelfClient()
        {
            BookshelfClientOptions options = InstrumentClientOptions(new BookshelfClientOptions());
            var client = new BookshelfClient(new Uri(TestEnvironment.BookshelfEndpoint), TestEnvironment.Credential, options);
            return InstrumentClient(client);
        }

        protected DiscoveryConversationsClient CreateConversationsClient()
            => CreateWorkspaceClient().GetDiscoveryConversationsClient();

        protected DiscoveryInvestigationsClient CreateInvestigationsClient()
            => CreateWorkspaceClient().GetDiscoveryInvestigationsClient();

        protected DiscoveryTasksClient CreateTasksClient()
            => CreateWorkspaceClient().GetDiscoveryTasksClient();

        protected DiscoveryToolsClient CreateToolsClient()
            => CreateWorkspaceClient().GetDiscoveryToolsClient();

        protected KnowledgeBases CreateKnowledgeBasesClient()
            => CreateBookshelfClient().GetKnowledgeBasesClient();

        /// <summary>Full resource path used by the service to reference an investigation.</summary>
        protected string InvestigationPath(string projectName = null, string investigationName = null)
            => $"/projects/{projectName ?? TestEnvironment.ProjectName}/investigations/{investigationName ?? TestEnvironment.InvestigationName}";

        /// <summary>
        /// Extracts the server-assigned operation id from an LRO's initial response
        /// <c>operation-location</c> header. Call on the response captured with
        /// <see cref="Azure.WaitUntil.Started"/> before awaiting completion.
        /// </summary>
        protected static string ExtractOperationId(Response response)
        {
            string opLocation = response.Headers.TryGetValue("operation-location", out string value) ? value : "";
            string[] segments = opLocation.Split(new[] { "/operations/" }, System.StringSplitOptions.None);
            return segments[segments.Length - 1].Split('?')[0];
        }
    }
}

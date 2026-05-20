// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Discovery;
using Azure.Identity;

namespace Azure.AI.Discovery.Samples.Snippets
{
    /// <summary>
    /// Snippets demonstrating how to construct Discovery clients and select a service API version.
    /// </summary>
    public partial class AuthenticationSnippets
    {
        /// <summary>
        /// Construct <see cref="WorkspaceClient"/> and <see cref="BookshelfClient"/> with Microsoft Entra ID authentication.
        /// </summary>
        public void CreateDiscoveryClients()
        {
            #region Snippet:CreateDiscoveryClients
            WorkspaceClient workspaceClient = new WorkspaceClient(
                new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
                new DefaultAzureCredential());

            BookshelfClient bookshelfClient = new BookshelfClient(
                new Uri("https://<bookshelfName>.bookshelf.discovery.azure.com"),
                new DefaultAzureCredential());
            #endregion
        }

        /// <summary>
        /// Construct a <see cref="WorkspaceClient"/> pinned to a specific service API version.
        /// </summary>
        public void CreateDiscoveryClientForSpecificApiVersion()
        {
            #region Snippet:CreateDiscoveryClientForSpecificApiVersion
            WorkspaceClientOptions options = new WorkspaceClientOptions(
                WorkspaceClientOptions.ServiceVersion.V2026_02_01_Preview);

            WorkspaceClient client = new WorkspaceClient(
                new Uri("https://<workspaceName>.workspace.discovery.azure.com"),
                new DefaultAzureCredential(),
                options);
            #endregion
        }
    }
}

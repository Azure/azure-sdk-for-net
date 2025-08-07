// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class ConversationAnalysisAuthoringClientOptions : ClientOptions
    {
        /// <summary>
        /// Gets or sets the audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="ConversationsAuthoringAudience.AzurePublicCloud" /> will be assumed.</value>
        internal ConversationsAuthoringAudience? Audience { get; set; }
    }
}

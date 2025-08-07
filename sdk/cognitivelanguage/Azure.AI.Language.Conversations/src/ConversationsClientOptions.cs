// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    [CodeGenModel("ConversationAnalysisClientOptions")]
    public partial class ConversationsClientOptions : ClientOptions
    {
        /// <summary>
        /// Gets or sets the audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="ConversationsAudience.AzurePublicCloud" /> will be assumed.</value>
        internal ConversationsAudience? Audience { get; set; }
    }
}

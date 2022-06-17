// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationTaskParameters
    {
        /// <summary>
        /// Gets the method used to interpret string offsets, which always returns <see cref="ConversationAnalysisClientOptions.DefaultStringIndexType"/> for .NET.
        /// </summary>
#pragma warning disable CA1822 // Mark members as static
        internal StringIndexType? StringIndexType => ConversationAnalysisClientOptions.DefaultStringIndexType;
#pragma warning restore CA1822 // Mark members as static
    }
}

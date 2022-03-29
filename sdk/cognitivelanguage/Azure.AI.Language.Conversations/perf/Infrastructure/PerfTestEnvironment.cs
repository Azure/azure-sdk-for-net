// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Language.Conversations.Tests;

namespace Azure.AI.Language.Conversations.Perf.Infrastructure
{
    public sealed class PerfTestEnvironment : ConversationAnalysisTestEnvironment
    {
        /// <summary>
        /// The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();
    }
}

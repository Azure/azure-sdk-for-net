// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        public void AnalyzeConversation()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversation

#if SNIPPET
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Menu",
                "production",
                "We'll have 2 plates of seared salmon nigiri.");
#else
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName,
                "We'll have 2 plates of seared salmon nigiri.");
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion
        }

        [AsyncOnly]
        public async Task AnalyzeConversationAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationAsync

#if SNIPPET
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Menu",
                "production",
                "We'll have 2 plates of seared salmon nigiri.");
#else
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName,
                "We'll have 2 plates of seared salmon nigiri.");
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion
        }
    }
}

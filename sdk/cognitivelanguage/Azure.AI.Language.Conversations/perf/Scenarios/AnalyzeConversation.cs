// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Perf.Infrastructure;
using Azure.Core;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.AI.Language.Conversations.Perf.Scenarios
{
    public class AnalyzeConversation : AnalysisScenarioBase<AnalyzeConversation.ConversationAnalysisClient>
    {
        private RequestContent _content;

        public AnalyzeConversation(ConversationAnalysisClient options) : base(options)
        {
        }

        public override Task SetupAsync()
        {
            var data = new
            {
                analysisInput = new
                {
                    conversationItem = new
                    {
                        text = "Send an email to Carol about the tomorrow's demo",
                        id = "1",
                        participantId = "1",
                    }
                },
                parameters = new
                {
                    projectName = TestEnvironment.ProjectName,
                    deploymentName = TestEnvironment.DeploymentName,

                    // Use Utf16CodeUnit for Strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            _content = RequestContent.Create(data);
            return Task.CompletedTask;
        }

        public override void Run(CancellationToken cancellationToken)
        {
            Client.AnalyzeConversation(_content);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await Client.AnalyzeConversationAsync(_content);
        }

        public class ConversationAnalysisClient : PerfOptions
        {
            // TODO: Replace with actual options.
            [Option("delay", Default = 100, HelpText = "Delay between gets (milliseconds)")]
            public int Delay { get; set; }
        }
    }
}

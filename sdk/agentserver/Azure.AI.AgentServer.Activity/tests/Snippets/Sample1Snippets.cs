// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample1_GettingStarted.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample1Snippets
    {
        public void EchoAgent(string[] args)
        {
            #region Snippet:Activity_Sample1_EchoAgent

            // Build the host (initializes the Microsoft 365 Agents SDK stack from the environment)
            // and capture the underlying AgentApplication to register handlers on.
            var host = ActivityServer.Create();
            var app = host.AgentApp;

            // Echo the user's message back.
            app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                var userText = turnContext.Activity.Text ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(userText))
                {
                    await turnContext.SendActivityAsync($"Echo: {userText}", cancellationToken: cancellationToken);
                }
            });

            host.Run(args);

            #endregion
        }
    }
}

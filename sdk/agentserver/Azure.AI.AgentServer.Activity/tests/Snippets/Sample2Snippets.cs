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
    /// Code snippets backing Activity Sample2_WelcomeAndCommands.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample2Snippets
    {
        public void WelcomeAndCommands(string[] args)
        {
            var host = ActivityServer.Create();
            var app = host.AgentApp;

            #region Snippet:Activity_Sample2_Welcome

            // Greet members as they join the conversation.
            app.OnConversationUpdate(ConversationUpdateEvents.MembersAdded, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                foreach (var member in turnContext.Activity.MembersAdded ?? [])
                {
                    // Skip the bot itself, which also appears in MembersAdded.
                    if (member.Id != turnContext.Activity.Recipient?.Id)
                    {
                        await turnContext.SendActivityAsync($"Welcome, {member.Name}!", cancellationToken: cancellationToken);
                    }
                }
            });

            #endregion

            #region Snippet:Activity_Sample2_Command

            // Handle a keyword command before the general message handler.
            app.OnMessage("/help", async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync("Send me any message and I'll echo it back.", cancellationToken: cancellationToken);
            });

            app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
            });

            #endregion

            host.Run(args);
        }
    }
}

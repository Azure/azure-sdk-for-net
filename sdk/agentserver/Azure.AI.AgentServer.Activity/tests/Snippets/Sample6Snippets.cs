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
    /// Code snippets backing Activity Sample6_InjectedApplication.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample6Snippets
    {
        // In a real app you build the AgentApplication yourself (with your own options, storage,
        // and DI); this snippet takes it as a parameter to keep the example focused on hosting it.
        public void HostInjectedApplication(AgentApplication app, string[] args)
        {
            #region Snippet:Activity_Sample6_Injected

            // Register handlers on your own AgentApplication as usual.
            app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
            });

            // Host the pre-built AgentApplication as-is.
            ActivityServer.Run(app, args);

            #endregion
        }
    }
}

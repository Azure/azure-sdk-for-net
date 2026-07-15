// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample12_InvokeActivities.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample12Snippets
    {
        public void InvokeAgent(string[] args)
        {
            #region Snippet:Activity_Sample12_Invoke

            ActivityServer.Run(
                (AgentApplication app) =>
            // Invoke activities are synchronous request/response (e.g. Teams message extensions,
            // task modules, adaptive card Action.Execute). Reply with an "invokeResponse" activity
            // carrying an InvokeResponse (HTTP-style status + body).
            app.OnActivity(ActivityTypes.Invoke, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                var name = turnContext.Activity.Name; // e.g. "composeExtension/query", "task/fetch"

                var response = new Microsoft.Agents.Core.Models.Activity
                {
                    Type = "invokeResponse",
                    Value = new InvokeResponse
                    {
                        Status = 200,
                        Body = new { message = $"Handled invoke: {name}" },
                    },
                };

                await turnContext.SendActivityAsync(response, cancellationToken: cancellationToken);
            }),
                args);

            #endregion
        }
    }
}

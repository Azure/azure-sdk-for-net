// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample7_M365NativeHosting.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample7Snippets
    {
        #region Snippet:Activity_Sample7_Agent
        // A standard Microsoft 365 Agents SDK agent — unchanged when hosting in Foundry.
        public class EchoAgent : AgentApplication
        {
            public EchoAgent(AgentApplicationOptions options)
                : base(options)
            {
                // Register handlers by referencing named methods (the common Microsoft 365 Agents SDK style).
                OnActivity(ActivityTypes.Message, OnMessageAsync, rank: RouteRank.Last);
            }

            private async Task OnMessageAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
            {
                var userText = turnContext.Activity.Text ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(userText))
                {
                    await turnContext.SendActivityAsync($"Echo: {userText}", cancellationToken: cancellationToken);
                }
            }
        }
        #endregion

        public void Host(string[] args)
        {
            #region Snippet:Activity_Sample7_M365NativeHosting

            var builder = WebApplication.CreateBuilder(args);

            // Register the agent — UNCHANGED from the Microsoft 365 Agents SDK.
            builder.AddAgent<EchoAgent>();

            // Register storage — UNCHANGED from the Microsoft 365 Agents SDK.
            builder.Services.AddSingleton<IStorage, MemoryStorage>();

            // Foundry conversion (1/2): replaces the Microsoft 365 auth registration
            // (AddAgentAspNetAuthentication / AddAgentAuthorization).
            builder.AddFoundryActivity();

            var app = builder.Build();

            // Foundry conversion (2/2): replaces the Microsoft 365 pipeline + endpoint mapping
            // (UseAgents / UseAuthentication + MapDefaultAgentEndpoints / MapAgentApplicationEndpoints).
            app.MapFoundryActivity();

            app.Run();

            #endregion
        }
    }
}

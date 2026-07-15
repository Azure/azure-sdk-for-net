// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Storage;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample9_Tier2HostingBuilder.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample9Snippets
    {
        #region Snippet:Activity_Sample9_Agent
        // A standard Microsoft 365 Agents SDK agent hosted via the Tier 2 builder.
        public sealed class EchoAgent : AgentApplication
        {
            public EchoAgent(AgentApplicationOptions options) : base(options)
            {
                OnActivity(ActivityTypes.Message, OnMessageAsync, rank: RouteRank.Last);
            }

            private async Task OnMessageAsync(ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken)
            {
                await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
            }
        }
        #endregion

        public void BuilderGeneric(string[] args)
        {
            #region Snippet:Activity_Sample9_BuilderGeneric

            var builder = AgentHost.CreateBuilder(args);

            // Optional: register your own storage and services on the Core host builder.
            builder.Services.AddSingleton<IStorage, MemoryStorage>();

            // Register the Activity protocol with your AgentApplication type.
            builder.AddActivity<EchoAgent>();

            var app = builder.Build();
            app.Run();

            #endregion
        }

        public void BuilderWithTracing(string[] args)
        {
            #region Snippet:Activity_Sample9_BuilderWithTracing

            var builder = AgentHost.CreateBuilder(args);

            builder.AddActivity<EchoAgent>(options =>
            {
                options.DigitalWorker = true;
            });

            // Configuration and tracing work the same as the other protocols.
            builder.ConfigureTracing(tracing => tracing.AddSource("MyAgent.BusinessLogic"));
            builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

            var app = builder.Build();
            app.Run();

            #endregion
        }

        public void BuilderWithInstance(string[] args, AgentApplication prebuiltAgent)
        {
            #region Snippet:Activity_Sample9_BuilderWithInstance

            var builder = AgentHost.CreateBuilder(args);

            // Host a pre-built AgentApplication instance (with its handlers already registered)
            // instead of a type — useful when you construct the application yourself.
            builder.AddActivity(prebuiltAgent);

            var app = builder.Build();
            app.Run();

            #endregion
        }

        public void BuilderWithFactory(string[] args)
        {
            #region Snippet:Activity_Sample9_BuilderWithFactory

            var builder = AgentHost.CreateBuilder(args);

            // Use a factory delegate for full control over how the application is constructed,
            // while still having access to the IServiceProvider. This mirrors the Microsoft 365
            // Agents SDK's builder.AddAgent(sp => ...) factory registration.
            builder.AddActivity(sp =>
            {
                var options = sp.GetRequiredService<AgentApplicationOptions>();
                return new EchoAgent(options);
            });

            var app = builder.Build();
            app.Run();

            #endregion
        }
    }
}

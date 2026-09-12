// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample8_Tier1Hosting.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample8Snippets
    {
        public interface IGreetingService
        {
            string Greet(string name);
        }

        public sealed class GreetingService : IGreetingService
        {
            public string Greet(string name) => $"Hello, {name}!";
        }

        #region Snippet:Activity_Sample8_Agent
        // A standard Microsoft 365 Agents SDK agent. Its handlers are registered in the constructor,
        // so the Tier 1 one-liner can host it by type.
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

        public void OneLiner(string[] args)
        {
            #region Snippet:Activity_Sample8_OneLiner

            // The fastest path to a running Activity agent — one line.
            ActivityServer.Run<EchoAgent>(args);

            #endregion
        }

        public void SelectAuthModel(string[] args)
        {
            #region Snippet:Activity_Sample8_SelectAuthModel

            // Select the outbound-auth model (or override storage) via the options callback.
            ActivityServer.Run<EchoAgent>(args, configureOptions: options =>
            {
                options.DigitalWorker = true;
            });

            #endregion
        }

        public void RegisterServicesAndTracing(string[] args)
        {
            #region Snippet:Activity_Sample8_RegisterServicesAndTracing

            // Use the configure callback for the underlying Core AgentHostBuilder: register services,
            // add a custom OpenTelemetry source, and set a shutdown timeout.
            ActivityServer.Run<EchoAgent>(args, configure: builder =>
            {
                builder.Services.AddSingleton<IGreetingService, GreetingService>();
                builder.ConfigureTracing(tracing => tracing.AddSource("MyAgent.BusinessLogic"));
                builder.ConfigureShutdown(TimeSpan.FromSeconds(10));
            });

            #endregion
        }

        public void WebAppAccess(string[] args)
        {
            #region Snippet:Activity_Sample8_WebAppAccess

            // Reach the ASP.NET Core WebApplicationBuilder for middleware, authentication, or CORS.
            ActivityServer.Run<EchoAgent>(args, configure: builder =>
            {
                builder.WebApplicationBuilder.Services.AddCors(cors =>
                {
                    cors.AddDefaultPolicy(policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
                });
            });

            #endregion
        }
    }
}

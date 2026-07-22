// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenTelemetry;
using NUnit.Framework;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample10_Tier3SelfHosting.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample10Snippets
    {
        #region Snippet:Activity_Sample10_Agent
        // A standard Microsoft 365 Agents SDK agent hosted in your own ASP.NET Core app.
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

        public void SelfHost(string[] args)
        {
            #region Snippet:Activity_Sample10_SelfHost

            var builder = WebApplication.CreateBuilder(args);

            // Your existing agent + storage registration (unchanged Microsoft 365 Agents SDK setup).
            builder.AddAgent<EchoAgent>();
            builder.Services.AddSingleton<IStorage, MemoryStorage>();

            // Add the Activity protocol to your own host. AddActivityServer() is the alias for
            // AddFoundryActivity().
            builder.AddActivityServer();

            var app = builder.Build();

            // Your existing endpoints coexist with the Activity endpoints.
            app.MapGet("/", () => "My existing app");

            // Map the Activity endpoint (/activity/messages) and /readiness.
            // MapActivityServer() is the alias for MapFoundryActivity().
            app.MapActivityServer();

            app.Run();

            #endregion
        }

        public void SelfHostFullControl(string[] args)
        {
            #region Snippet:Activity_Sample10_FullControl

            var builder = WebApplication.CreateBuilder(args);

            builder.AddAgent<EchoAgent>();
            builder.Services.AddSingleton<IStorage, MemoryStorage>();

            // Register the Activity protocol services without the bundled endpoint/middleware wiring,
            // so you own the pipeline order and can add your own middleware and observability.
            builder.Services.AddActivityServer();

            // Observability: the Microsoft OpenTelemetry distro with traces and metrics. The bundled
            // MapActivityServer() path does not wire this for you, so add it here for full control.
            var otel = builder.Services.AddOpenTelemetry();
            otel.UseMicrosoftOpenTelemetry(options => { });
            otel.WithTracing(tracing => tracing.AddSource("Azure.AI.AgentServer.Activity"))
                .WithMetrics(metrics => metrics.AddMeter("Azure.AI.AgentServer.Activity"));

            var app = builder.Build();

            // You order the middleware pipeline and health probe yourself.
            app.UseAgentServerCore();
            app.MapHealthChecks("/readiness");

            app.MapGet("/", () => "My existing app");

            // Map only the Activity endpoints via the IEndpointRouteBuilder overload (no bundled
            // middleware/health — you wired those above).
            ((IEndpointRouteBuilder)app).MapActivityServer();

            app.Run();

            #endregion
        }

        public void SelfHostRawHandler(string[] args)
        {
            #region Snippet:Activity_Sample10_RawHandler

            var builder = WebApplication.CreateBuilder(args);

            // Register only the Activity package services (for the session-id / baggage stamping).
            // The Microsoft 365 Agents SDK is not initialized on the raw-handler path.
            builder.Services.AddActivityServer();

            var app = builder.Build();

            // Foundry platform middleware (request-id, correlation baggage, inbound logging).
            app.UseAgentServerCore();
            app.MapHealthChecks("/readiness");

            // Your existing endpoints coexist with the Activity endpoints.
            app.MapGet("/", () => "My existing app");

            // Own the request pipeline: map the Activity endpoints to your own RequestDelegate.
            // You read the request and write the response yourself — no Microsoft 365 adapter —
            // while the platform still stamps the session-id header, correlation baggage, and
            // error-source classification around your handler.
            ((IEndpointRouteBuilder)app).MapFoundryActivity(async context =>
            {
                using var reader = new System.IO.StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();

                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync($"Received {body.Length} bytes.");
            });

            app.Run();

            #endregion
        }
    }
}

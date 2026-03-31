// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample2_Configuration.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample2Snippets
    {
        [Test]
        public void TracingAndShutdown()
        {
            #region Snippet:Core_Sample2_TracingAndShutdown

            var builder = AgentHost.CreateBuilder();

            // Add a custom OpenTelemetry tracing source.
            builder.ConfigureTracing(tracing =>
            {
                tracing.AddSource("MyAgent.BusinessLogic");
            });

            // Set a custom shutdown timeout (default is 30s).
            builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

            // Register a protocol endpoint.
            builder.RegisterProtocol("MyProtocol", endpoints =>
            {
                endpoints.MapGet("/ping", () => "pong");
            });

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void HealthChecks()
        {
            #region Snippet:Core_Sample2_HealthChecks

            var builder = AgentHost.CreateBuilder();

            // Add a custom health check alongside the default liveness probe.
            builder.ConfigureHealth(health =>
            {
                health.AddCheck("database", () =>
                    Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("DB reachable"));
            });

            builder.RegisterProtocol("MyProtocol", endpoints =>
            {
                endpoints.MapGet("/ping", () => "pong");
            });

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void EscapeHatch()
        {
            #region Snippet:Core_Sample2_EscapeHatch

            var builder = AgentHost.CreateBuilder();

            // Access the underlying WebApplicationBuilder for CORS, auth, etc.
            builder.WebApplicationBuilder.Services.AddCors(cors =>
            {
                cors.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Register services on the builder's DI container.
            builder.Services.AddSingleton<MyService>();

            // Read configuration values.
            var setting = builder.Configuration["MySetting"];

            builder.RegisterProtocol("MyProtocol", endpoints =>
            {
                endpoints.MapGet("/ping", () => $"pong: {setting}");
            });

            var app = builder.Build();
            app.Run();

            #endregion
        }

        private class MyService { }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity;
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
    /// Code snippets backing Activity Sample4_CustomizeTheBuild.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample4Snippets
    {
        public void CustomStorage(string[] args)
        {
            #region Snippet:Activity_Sample4_Storage

            // Override just the storage backend; the host builds the rest of the stack from the
            // environment. Leave Storage unset to use the default in-memory store.
            ActivityServer.Run(
                (AgentApplication app) =>
                    app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
                    {
                        await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
                    }),
                args,
                configureOptions: options => options.Storage = new MemoryStorage());

            #endregion
        }

        public void ConfigureServices(string[] args)
        {
            #region Snippet:Activity_Sample4_ConfigureServices

            // Register additional services (a custom adapter, authorization, channel-service
            // factory, ...) before the Microsoft 365 Agents SDK defaults are added. Anything
            // registered here takes precedence over the SDK defaults.
            ActivityServer.Run(
                (AgentApplication app) =>
                    app.OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
                    {
                        await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
                    }),
                args,
                configureOptions: options =>
                {
                    options.ConfigureServices = services =>
                    {
                        services.AddSingleton<IStorage, MemoryStorage>();
                    };
                });

            #endregion
        }
    }
}

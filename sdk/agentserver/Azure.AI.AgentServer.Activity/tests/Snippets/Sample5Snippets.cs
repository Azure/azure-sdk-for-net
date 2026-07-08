// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample5_CustomRequestHandler.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample5Snippets
    {
        public void CustomRequestHandler(string[] args)
        {
            #region Snippet:Activity_Sample5_CustomHandler

            // Own the request pipeline entirely: the Microsoft 365 Agents SDK is not initialized.
            // The delegate receives each inbound POST /activity/messages request. The parsed
            // activity is available at request.HttpContext for custom processing.
            var host = ActivityServer.Create(async (HttpContext context) =>
            {
                using var reader = new StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();

                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync($"Received {body.Length} bytes.");
            });

            host.Run(args);

            #endregion
        }
    }
}

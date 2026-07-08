// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Activity Sample3_DigitalWorker.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a hosted environment to execute.")]
    public class Sample3Snippets
    {
        public void DigitalWorker(string[] args)
        {
            #region Snippet:Activity_Sample3_DigitalWorker

            // Select the digital-worker outbound-auth model: the blueprint identity performs a
            // federated-identity (FMI) token exchange to obtain an agentic user token.
            var host = ActivityServer.Create(options =>
            {
                options.DigitalWorker = true;
            });

            host.Run(args);

            #endregion
        }
    }
}

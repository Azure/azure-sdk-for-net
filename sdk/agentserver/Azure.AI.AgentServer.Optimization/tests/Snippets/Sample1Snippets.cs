// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample1_GettingStarted.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require optimization env vars to execute.")]
    public class Sample1Snippets
    {
        [Test]
        public async Task UseOptions()
        {
            #region Snippet:Optimization_Sample1_UseOptions
            AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), new StubCredential());
            string candidateId = Environment.GetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID");
            CandidateDeployConfig? options = await client.ResolveOptionsAsync(candidateId);

            string instructions = options?.Instructions ?? "You are a helpful assistant.";
            string model = options?.Model ?? "gpt-4o-mini";

            Console.WriteLine($"Using model: {model}");
            Console.WriteLine($"Instructions length: {instructions.Length} chars");
            #endregion

            Assert.That(instructions, Is.Not.Null);
        }

        private sealed class StubCredential : Azure.Core.TokenCredential
        {
            public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) =>
                throw new NotImplementedException();

            public override ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) =>
                throw new NotImplementedException();
        }
    }
}

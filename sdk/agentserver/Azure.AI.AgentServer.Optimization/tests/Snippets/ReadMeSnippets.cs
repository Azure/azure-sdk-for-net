// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the Optimization README.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require optimization env vars to execute.")]
    public class ReadMeSnippets
    {
        [Test]
        public async Task LoadOptionsWithDefaults()
        {
            #region Snippet:Optimization_ReadMe_Load
            AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), new StubCredential());
            OptimizationOptions options = await client.ResolveOptionsAsync();

            if (options is not null)
            {
                Console.WriteLine($"Source: {options.Source}");
                Console.WriteLine($"Instructions: {options.Instructions}");
                Console.WriteLine($"Model: {options.Model}");
            }
            #endregion
        }

        [Test]
        public async Task LoadOptionsWithCredential()
        {
            #region Snippet:Optimization_ReadMe_LoadWithCredential
            LoadOptions loadOptions = new LoadOptions
            {
                Credential = new StubCredential(),
            };

            AgentOptimizationClient client = new(new Uri("https://my-project.services.ai.azure.com/api/projects/my-project"), loadOptions.Credential);
            OptimizationOptions options = await client.ResolveOptionsAsync(loadOptions);
            #endregion

            Assert.That(loadOptions.Credential, Is.Not.Null);
        }

        /// <summary>Stub credential for snippet compilation.</summary>
        private sealed class StubCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                throw new NotImplementedException();

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                throw new NotImplementedException();
        }
    }
}

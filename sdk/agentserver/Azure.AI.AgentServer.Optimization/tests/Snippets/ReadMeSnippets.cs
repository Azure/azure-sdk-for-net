// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync();

            if (options is not null)
            {
                Console.WriteLine($"Source: {options.Source}");
                Console.WriteLine($"Instructions: {options.Instructions}");
                Console.WriteLine($"Model: {options.Model}");
            }
            #endregion
        }

        [Test]
        public async Task LoadOptionsWithTokenProvider()
        {
            #region Snippet:Optimization_ReadMe_LoadWithTokenProvider
            LoadOptions loadOptions = new LoadOptions
            {
                TokenProvider = new MyTokenProvider(),
            };

            OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync(loadOptions);
            #endregion

            Assert.That(loadOptions.TokenProvider, Is.Not.Null);
        }

        #region Snippet:Optimization_ReadMe_TokenProvider
        private sealed class MyTokenProvider : AuthenticationTokenProvider
        {
            public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);

            public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken) =>
                throw new NotImplementedException();

            public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken) =>
                throw new NotImplementedException();
        }
        #endregion
    }
}

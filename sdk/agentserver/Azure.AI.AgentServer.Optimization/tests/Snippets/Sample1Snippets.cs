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
            OptimizationOptions options = await OptimizationOptionsLoader.LoadAsync();

            string instructions = options?.Instructions ?? "You are a helpful assistant.";
            string model = options?.Model ?? "gpt-4o-mini";

            Console.WriteLine($"Using model: {model}");
            Console.WriteLine($"Instructions length: {instructions.Length} chars");
            #endregion

            Assert.That(instructions, Is.Not.Null);
        }
    }
}

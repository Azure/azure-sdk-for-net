// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Extensions.Plugin.Visitors;

namespace Extensions.Plugin
{
    /// <summary>
    /// ExtensionsPlugin is a generator plugin that applies visitors to mutate the generated
    /// Azure.AI.Projects, Azure.AI.Extensions.OpenAI and Azure.AI.Projects.Agents libraries,
    /// analogous to the OpenAI library's codegen plugin.
    /// </summary>
    internal sealed class ExtensionsPlugin : GeneratorPlugin
    {
        /// <inheritdoc />
        public override void Apply(CodeModelGenerator generator)
        {
            //System.Console.WriteLine("Applying ExtensionsPlugin...!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            var debug = System.Environment.GetEnvironmentVariable("DEBUG_EXTENSION");
            System.Console.Error.WriteLine($"DEBUG_EXTENSION environment variable is {debug}");

            if (debug == "1")
            {
                System.Console.Error.WriteLine("DEBUG_EXTENSION environment variable is set. Breaking into the debugger...");
                System.Diagnostics.Debugger.Break();
            }
            generator.AddVisitor(new ExperimentalAttributeVisitor());
        }
    }
}

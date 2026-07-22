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
            generator.AddVisitor(new SerializationOverrideVisitor());
            // Runs before ExperimentalAttributeVisitor so declarations exposing OpenAI-experimental types
            // are attributed with the correct OpenAI diagnostic id (OPENAI001/OPENAICUA001); the AAIP001
            // visitor then only marks our own new/preview surface. Both skip already-attributed declarations.
            generator.AddVisitor(new OpenAIExperimentalVisitor());
            generator.AddVisitor(new ExperimentalAttributeVisitor());
        }
    }
}

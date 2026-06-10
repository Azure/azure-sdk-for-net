// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Extensions.Plugin.Visitors;

namespace Extensions.Plugin
{
    /// <summary>
    /// ExtensionsPlugin is a generator plugin that applies visitors to mutate the generated
    /// Azure.AI.Extensions.OpenAI library, analogous to the OpenAI library's codegen plugin.
    /// </summary>
    internal sealed class ExtensionsPlugin : GeneratorPlugin
    {
        /// <inheritdoc />
        public override void Apply(CodeModelGenerator generator)
        {
            generator.AddVisitor(new ExperimentalAttributeVisitor());
        }
    }
}

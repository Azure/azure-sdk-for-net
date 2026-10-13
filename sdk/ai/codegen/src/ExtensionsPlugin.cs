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
            // ExperimentalAttributeVisitor runs first so our intentional AAIP001 marking (driven by the
            // typespec x-ms-foundry-meta CSV tables) wins for any declaration that is experimental both because
            // we intend it to be and because it exposes OpenAI-experimental surface. OpenAIExperimentalVisitor
            // then marks the remaining OpenAI-dependency surface with AAIP002. Both skip already-attributed
            // declarations, and because C# suppresses experimental references inside any [Experimental] scope
            // regardless of id, neither ordering requires an assembly-wide NoWarn.
            generator.AddVisitor(new ExperimentalAttributeVisitor());
            generator.AddVisitor(new OpenAIExperimentalVisitor());
        }
    }
}
